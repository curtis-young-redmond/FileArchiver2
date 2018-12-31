using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO.Compression;
using System.Configuration;

namespace DecompressorUI
{
    public partial class DecompressUI : Form
    {
        private DateTime mindate;
        private DateTime maxdate;
        private DateTime minDT;
        public DateTime MinDT
        {
            get
            {
                var tmp = Convert.ToDateTime(minDT.ToString("MM/dd/yyy"));
                return tmp;
            }
            set { minDT = value; }
        }
        private DateTime maxDT;
        public DateTime MaxDT
        {
            get
            {
                var tmp = Convert.ToDateTime(maxDT.ToString("MM/dd/yyy")).AddDays(1.0).AddMilliseconds(-1.0);
                return tmp;
            }
            set { maxDT = value; }
        }
        private DateTime previouslysetDatetime = DateTime.MinValue;

        protected StatusBar mainStatusBar = new StatusBar();
        protected StatusBarPanel statusPanel = new StatusBarPanel();
        protected StatusBarPanel datetimePanel = new StatusBarPanel();
        ToolTip toolTipPath = new ToolTip();
        ToolTip toolTipSearch = new ToolTip();
        ToolTip toolTipRetrieve = new ToolTip();
        ToolTip toolTippattern = new ToolTip();
        ToolTip toolTipCalendar = new ToolTip();

        List<DTFile> fileList = new List<DTFile>();
        public DecompressUI()
        {
            InitializeComponent();
            LoadDropDownListFromConfigValues();
            toolTipPath.IsBalloon = true;
            toolTipSearch.IsBalloon = true;
            toolTipRetrieve.IsBalloon = true;
            toolTippattern.IsBalloon = true;
            toolTipCalendar.IsBalloon = true;
            toolTipPath.SetToolTip(lbltarget, "Enter a path, partial or full.\r\nIf partial use the SEARCH button to drill down.\r\nIf full use the RETRIEVE button to review all files from folder.");
            toolTipSearch.SetToolTip(btnSearch, "Use to open a folder search dialog.\r\nIf looking for a server try the UNC.\r\nIf you have a full path in Target folder text box you can confirm its existence.");
            toolTipRetrieve.SetToolTip(btnRetrieve, "Retrieves an internal list of all files matching the search pattern\r\nand determines the maximum and minimum dates of all those files.");
            toolTippattern.SetToolTip(lblSearchPattern, "Pattern always assumes a GZ file.\r\nYou can filter by partial file names but don't add an extension, it's done automatically.");
            toolTipCalendar.SetToolTip(monthCalendar1, "");
            CreateStatusBar();
        }
        private void btnChooseFolder_Click(object sender, System.EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Find Source Compression file (i.e., *.gz)";
                fbd.SelectedPath = RemoveSpecialCharacters(txtFolderPath.Text);
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFolderPath.Text = "";
                    //txtFolderPath.SelectedValue = fbd.SelectedPath;
                    txtFolderPath.SelectedText = fbd.SelectedPath;
                    statusPanel.Text = "";
                    datetimePanel.Text = "";
                    btnExpand.Visible = false;
                    monthCalendar1.BoldedDates = null;
                }
            }
        }
        private void GetFileStatistics(string folderPath)
        {
            if (folderPath.Trim().Length == 0) return;
            try
            {
                btnExpand.Visible = false;
                Regex regex = new Regex(@"\\\\[A-Z,a-z,0-9]+\\");
                char[] separator = { '\\' };
                //ServerName = regex.Match(folderPath).Value.Split(separator, StringSplitOptions.RemoveEmptyEntries)[0];
                Cursor.Current = Cursors.WaitCursor;
                string[] files=null;
                if (Directory.Exists(folderPath))
                    files = Directory.GetFiles(folderPath, txtSearchPattern.Text + ".gz");
                if (files==null || files.Length == 0)
                {
                    monthCalendar1.ResetText();
                    monthCalendar1.BoldedDates = null;
                    monthCalendar1.SetSelectionRange(DateTime.Now, DateTime.Now);
                    MessageBox.Show("There are no files matching the current criteria!");
                    RemoveFromDropDownTargetFolder();
                    return;
                }
                else
                {
                    AddToDropDownTargetFolder();
                }
                fileList.Clear();
                foreach (var item in files)
                {
                    var filedateTime = File.GetCreationTime(item);
                    fileList.Add(new DTFile(Convert.ToDateTime(filedateTime.ToString("MM/dd/yyyy")), item));
                }
                fileList.Sort((x, y) => x.dateTime.CompareTo(y.dateTime));
                mindate = fileList[0].dateTime;
                maxdate = fileList[fileList.Count - 1].dateTime;
                bool bfileAvailable;
                StatusBarUpdate(mindate, maxdate, out bfileAvailable);
                datetimePanel.Text = String.Format("from {0:MM/dd/yy}  to {1:MM/dd/yy}", mindate, maxdate);
                datetimePanel.AutoSize = StatusBarPanelAutoSize.Contents;
                Cursor.Current = Cursors.Arrow;
                //monthCalendar1.SelectionStart = mindate;
                //monthCalendar1.SelectionEnd = maxdate;
                List<DateTime> mydates = new List<DateTime>();
                DateTime dateincrementer = Convert.ToDateTime(mindate.ToString("MM/dd/yyyy"));
                while (true)
                {
                    if (fileList.FindAll(x => x.dateTime == dateincrementer).Count > 0)
                        mydates.Add(dateincrementer);
                    dateincrementer = dateincrementer.AddDays(1.0);
                    if (dateincrementer > maxdate)
                        break;
                }
                monthCalendar1.BoldedDates = mydates.ToArray();
                monthCalendar1.SetSelectionRange(mindate, maxdate);
                monthCalendar1.SetSelectionRange(mindate, mindate);
                //SelectionRange myrange = new SelectionRange(mindate, maxdate);
                //monthCalendar1.SelectionRange = myrange;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadDropDownListFromConfigValues(string currentkey = "")
        {
            var dataSource = new List<KeyValuePair<string, string>>();

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            var enumer = settings.AllKeys;
            foreach (var item in enumer)
            {
                dataSource.Add(new KeyValuePair<string, string>(settings[item].Key, settings[item].Key));
            }
            txtFolderPath.DataSource = dataSource;
            txtFolderPath.DisplayMember = "Key";
            txtFolderPath.ValueMember = "Value";
            txtFolderPath.Text = currentkey;
        }
        private void RemoveFromDropDownTargetFolder()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            var key = txtFolderPath.Text;
            settings.Remove(key);
            configFile.Save(ConfigurationSaveMode.Modified);
            LoadDropDownListFromConfigValues();
        }
        private void AddToDropDownTargetFolder()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                var key = txtFolderPath.Text;
                //var value = txtFolderPath.Text;
                string value = null;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                LoadDropDownListFromConfigValues(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Path not save for Drop down because {0}", ex.Message));
            }
        }

        private void StatusBarUpdate(DateTime startDate, DateTime endDate, out bool bfilesAvail)
        {
            int filecount = 0;
            foreach (var item in fileList)
            {
                if (item.dateTime >= startDate && item.dateTime <= endDate)
                    filecount++;
            }
            if (filecount == 0)
                bfilesAvail = false;
            else
                bfilesAvail = true;
            if ((startDate == mindate && endDate == maxdate) || !bfilesAvail)
                statusPanel.Text = String.Format("{0} files in Folder", fileList.Count);
            else
                statusPanel.Text = String.Format("{0} files in Folder        {3} File(s) from {1:MM/dd/yy}  to  {2:MM/dd/yy}", fileList.Count, startDate, endDate, filecount);
        }
        private void CreateStatusBar()
        {
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(statusPanel);
            datetimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            mainStatusBar.Panels.Add(datetimePanel);
            mainStatusBar.ShowPanels = true;
            this.Controls.Add(mainStatusBar);
            mainStatusBar.BringToFront();
        }
        private void DecompressUI_Resize(object sender, EventArgs e)
        {
            monthCalendar1.Width = this.Width - monthCalendar1.Left;
            monthCalendar1.Height = this.Height - monthCalendar1.Top;
            txtFolderPath.Width = monthCalendar1.Width;

        }
        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            bool bfilesAvailable;
            StatusBarUpdate(e.Start, e.End, out bfilesAvailable);
            MinDT = e.Start;
            MaxDT = e.End;
            if (bfilesAvailable)
            {
                btnExpand.Enabled = true;
                btnExpand.Text = String.Format("Expand - {0:MM/dd/yy} to {1:MM/dd/yy}", e.Start, e.End);
                btnExpand.AutoSize = true;
                btnExpand.Visible = true;
            }
            else
            {
                btnExpand.Enabled = false;
                btnExpand.Visible = false;
            }
        }
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            GetFileStatistics(txtFolderPath.Text);
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Choose a location to Expand files to.";
                fbd.SelectedPath = txtFolderPath.Text;
                DialogResult result = fbd.ShowDialog();
                if (!(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)))
                    return;

                string myrestoredfile;
                DialogResult myresult = DialogResult.None;
                foreach (var file in fileList.FindAll(x => x.dateTime >= MinDT && x.dateTime <= MaxDT))
                {
                    switch (myresult)
                    {
                        case DialogResult.Yes:
                        case DialogResult.None:
                            myresult = MessageBox.Show(String.Format("Getting ready to Expand {0}\r\n\r\nDo you want to continue to be notified?\r\n\r\n  Press Yes for receive notification for each file.\r\n  Press No to extract all remaining files without notification.\r\n  Press Cancel to stop extraction.", file.strPath), "Expanding...", MessageBoxButtons.YesNoCancel);
                            if (myresult == DialogResult.Cancel) return;
                            break;
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }

                    if (DeCompressMyFile(file.strPath, out myrestoredfile))
                    {
                        var fileInfo = new FileInfo(myrestoredfile);
                        var finalrestingplace = fbd.SelectedPath + "\\" + fileInfo.Name;
                        File.Copy(myrestoredfile, finalrestingplace);
                        SetFileDate(finalrestingplace);
                        if (File.Exists(myrestoredfile))
                            File.Delete(myrestoredfile);
                    }
                }
            }
        }

        private static void SetFileDate(string file)
        {
            DateTime mydate = DateTime.MinValue;
            try
            {
                Regex dx = new Regex(@"[1-2][0-1][0-9][0-9][0-1][0-9][0-3][0-9]_[0-2][0-9][0-9][0-9][0-5][0-9]");
                char[] separator = { '_' };
                var datenumber = dx.Match(file).Value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                CultureInfo provider = CultureInfo.InvariantCulture;
                string format = "yyyyMMddHHmmss";
                mydate = DateTime.ParseExact(datenumber[0] + datenumber[1], format, provider);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("File:{0} failed to update its dates because of {1}. \r\nSetting to current time.", file, ex.Message));
                //if the format of the file name doesn't conform to the de-facto standard then just put the current time in the compressed file.
                mydate = DateTime.Now;
            }
            File.SetCreationTime(file, mydate);
            File.SetLastAccessTime(file, mydate);
            File.SetLastWriteTime(file, mydate);
        }
        private static Boolean DeCompressMyFile(string fullname, out string myrestoredfile)
        {
            FileInfo info = null;
            FileInfo fileToDeCompress = new FileInfo(fullname);
            var getOriginalFilearray = fileToDeCompress.FullName.Split('.');
            string OriginalFileName = null;
            foreach (var myfile in getOriginalFilearray)
                if (myfile != "gz")
                    OriginalFileName += "." + myfile;
            OriginalFileName = OriginalFileName.Substring(1);
            if (File.Exists(OriginalFileName))
                File.Delete(OriginalFileName);//this is incase there was a previous failure leaving a extracted file in place.
            using (FileStream originalFileStream = fileToDeCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToDeCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    using (FileStream compressedFileStream = File.Create(OriginalFileName))
                    {
                        using (GZipStream mydecompressionStream = new GZipStream(originalFileStream,
                           CompressionMode.Decompress))
                        {
                            mydecompressionStream.CopyTo(compressedFileStream);
                        }
                    }

                    info = new FileInfo(fileToDeCompress.FullName);
                    Console.WriteLine("DeCompressed {0} from {1} to {2} bytes.",
                    fileToDeCompress.Name, fileToDeCompress.Length.ToString(), info.Length.ToString());
                }
                myrestoredfile = OriginalFileName;
                if (info == null)
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// Removes weird characters that would not normally be used in a path
        /// Normal path and 
        /// </summary>
        /// <param name="str">originally typed path</param>
        /// <returns>clean path string</returns>
        public static string RemoveSpecialCharacters(string str)
        {
            string rtnstr = Regex.Replace(str, "^[[A-Z]{1,}?:?[\\]{2,}?][a-zA-Z0-9_.]+", " ", RegexOptions.Compiled);
            return rtnstr;
        }

        private void monthCalendar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!cbflyover.Checked) { toolTipCalendar.SetToolTip(monthCalendar1, ""); return; }
            var hitArea = monthCalendar1.HitTest(e.Location);
            if (previouslysetDatetime == hitArea.Time) return; else previouslysetDatetime = hitArea.Time;
            if (hitArea.HitArea.ToString() == "Date")
                toolTipCalendar.SetToolTip(monthCalendar1, GetFileTypeStatistics(hitArea.Time));
            return;
        }

        private string GetFileTypeStatistics(DateTime time)
        {
            SortedDictionary<string, int> mydict = new SortedDictionary<string, int>();
            string myreturn = null;
            if (fileList.FindAll(x => x.dateTime == time).Count == 0) return "";
            string truncatedFileName = null;
            Regex regex = new Regex(@"^[A-z]+");
            foreach (var item in fileList.FindAll(x => x.dateTime == time))
            {
                char[] separate = { '\\' };
                var arra = item.strPath.Split(separate, StringSplitOptions.RemoveEmptyEntries);
                var fileName = arra[arra.Length - 1];
                truncatedFileName = regex.Match(fileName).Value.ToString();

                if (mydict.ContainsKey(truncatedFileName))
                    mydict[truncatedFileName] += 1;
                else
                    mydict.Add(truncatedFileName, 1);
            }
            foreach (var kvpair in mydict)
            {
                myreturn += kvpair.Key + "=" + kvpair.Value + "\r\n";
            }
            return myreturn;
        }
    }

}
