using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading;

namespace FileArchiver
{ 
    /// <summary>
    /// Class Name: FileManagement
    /// Description:  This class provides a file management algorithm for Archive, Move and Purge
    /// </summary>
    class FileManagement
    {
        private static readonly log4net.ILog log = FileArchiver.LogHelper.GetLogger(); //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CmdLineParser cmdLineParser { get; private set; }
        protected List<FileCleanupConfiguration> configList { get; set; }
        protected Dictionary<string, List<FileCleanupConfiguration>> threaddictlist;
        protected Dictionary<DateTime, String> filedict { get; set; }
        public FileManagement() { }
        public FileManagement(List<FileCleanupConfiguration> myconfig, CmdLineParser CmdLineParser)
        {
            cmdLineParser = CmdLineParser;

            configList = myconfig;
            threaddictlist = new Dictionary<string, List<FileCleanupConfiguration>>();
            foreach (var config in configList)
            {
                if (threaddictlist.ContainsKey(config.SourceFolderPath))
                {
                    var test = threaddictlist[config.SourceFolderPath];
                    test.Add(config);
                }
                else
                {
                    var configSpecList = new List<FileCleanupConfiguration>();
                    configSpecList.Add(config);
                    threaddictlist.Add(config.SourceFolderPath, configSpecList);
                }
            }
        }

        /// <summary>
        /// ProcessFiles
        /// This method sets up and launches processing threads depending upon the configuration.
        /// </summary>
        public void ProcessFilesInParallel()
        {
            #region Parallel processing
            if (CheckDirectorySettingsForExistence(configList))
            {

                try
                {
                    log.Debug("Start FileManagement ProcessFiles");
                    List<Thread> mythreadlist = new List<Thread>();

                    foreach (var tlist in threaddictlist)
                    {
                        mythreadlist.Add(
                    new Thread(() =>
                                       {
                                           Thread.CurrentThread.Name = FileCleanupConfiguration.threadName(tlist.Key);
                                           Thread.CurrentThread.IsBackground = true;
                                           ProcessSingleFolderofFiles(tlist.Value);
                                       }));
                    }
                    foreach (var thread in mythreadlist)
                    {
                        thread.Start();
                    }
                    foreach (var thread in mythreadlist)
                    {
                        thread.Join();
                    }
                    if (cmdLineParser.TestMode) throw new ControlException("because it is in test mode");
                }
                catch (ControlException cx)
                {
                    throw cx;
                }
                catch (Exception ex)
                {
                    log.Error("File ProcessFiles ERROR:", ex);
                }
                log.Debug("Stop FileManagement ProcessFiles");
            }
            else
                throw new ControlException("folders called out in the configuration database have NOT been established\r\nUse the -T -B flags to automatically create folders.");
            #endregion
        }

        /// <summary>
        /// ProcessSingleFolderofFiles 
        /// This method is launched in a separate thread for each unique source file path value of configuration records.
        /// </summary>
        /// <param name="configs">
        /// This parameter is a list of configurations that have equal source file path values
        /// </param>
        private void ProcessSingleFolderofFiles(List<FileCleanupConfiguration> configs)
        {
            foreach (var config in configs)
            {
                Thread.Yield();
                var filelist = new List<FileDetails>();
                DirectoryInfo directory = new DirectoryInfo(config.SourceFolderPath);

                FileInfo[] completeFileList = directory.GetFiles(config.SourceFilePattern, SearchOption.TopDirectoryOnly);
                var totalFileCount = completeFileList.Length;
                foreach (var arrayfile in completeFileList)
                {
                    Thread.Yield();
                    if (arrayfile.CreationTime.AddDays(config.RetentionDays) < DateTime.Now && (arrayfile.Extension != ".gz" || config.SourceFilePattern == "*.gz"))
                        filelist.Add(new FileDetails(arrayfile));
                }
                var filecount = filelist.Count;
                string processPhrase;
                if (cmdLineParser.TestMode)
                    processPhrase = "Test Mode check ";
                else
                    processPhrase = "Start  processing";
                log.Info(string.Format(processPhrase+" {3} - {0} out {1} files matching config settings and will be {2}d.", filecount, totalFileCount, config.CleanUpType, config.SourceFolderPath));
                if (!cmdLineParser.TestMode)
                {
                    for (int i = 0; i < filelist.Count; i++)
                    {
                        FileDetails file = filelist[i];
                        Thread.Yield();
                        try
                        {
                            var numberOfDays = (DateTime.Now - file.CreationTime).Days;
                            if (config.CleanUpType == "delete")
                            {
                                log.Debug(string.Format("{0} older than {1} days. File: {2} is older by {3} days", config.CleanUpType, config.RetentionDays, file.Name, numberOfDays));
                                if (!cmdLineParser.TestMode)
                                    File.Delete(file.FullName);
                            }

                            if (config.CleanUpType == "archive")
                            {
                                string compressedFileName;
                                log.Debug(string.Format("{0} older than {1} days. File: {2} is older by {3} days", config.CleanUpType, config.RetentionDays, file.Name, numberOfDays));
                                if (config.Compress == true)
                                {
                                    if (!cmdLineParser.TestMode)
                                        if (CompressMyFile(file.FullName, out compressedFileName))
                                        {
                                            if (config.DestinationFolderPath.Trim() != "" && config.SourceFolderPath != config.DestinationFolderPath)
                                            {
                                                //the destination folder is defined in the config so move the .gz to the new location and delete the original
                                                File.Delete(file.FullName);
                                                var compfileName = new FileInfo(compressedFileName).Name;
                                                File.Copy(compressedFileName, config.DestinationFolderPath + compfileName, true);
                                                var compfile = config.DestinationFolderPath.Trim() + compfileName.Trim();
                                                SetFileDate(compfile);
                                                if (File.Exists(config.DestinationFolderPath + compfileName))
                                                    File.Delete(config.SourceFolderPath + compfileName);
                                            }
                                            if (config.DestinationFolderPath.Trim() == "" || config.SourceFolderPath == config.DestinationFolderPath)
                                            {
                                                //destination folder not defined or is equal to the source; leave the .gz in this folder and delete original
                                                if (File.Exists(compressedFileName))
                                                    File.Delete(file.FullName);
                                            }
                                        }
                                }
                                else
                                {
                                    if (!cmdLineParser.TestMode)
                                        if (config.SourceFolderPath != config.DestinationFolderPath)
                                        {
                                            //if no compression but a valid destination folder then copy the file over and delete orginal
                                            var src = config.SourceFolderPath + file.Name;
                                            var dest = config.DestinationFolderPath + file.Name;
                                            File.Copy(src, dest, true);
                                            SetFileDate(dest);
                                            if (File.Exists(dest))
                                                File.Delete(src);
                                        }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error(String.Format("Ensure you don't have duplicate configuration values. Problem with File {0} : {1}", file.Name, ex.Message));
                        }
                    }

                    log.Info(string.Format("Finish processing {3} - {0} out {1} files matching config settings and will be {2}d.", filecount, totalFileCount, config.CleanUpType, config.SourceFolderPath));
                }
            }
        }


        private bool CheckDirectorySettingsForExistence(List<FileCleanupConfiguration> configList)
        {
            Boolean rtnbool = true;
            foreach (var config in configList)
            {
                if (!(new DirectoryInfo(config.SourceFolderPath)).Exists)
                {
                    rtnbool = false;
                    if (cmdLineParser.DIRMode && cmdLineParser.TestMode)
                    {
                        //creat the directory
                        log.Info(string.Format("Creating folder {0}", config.SourceFolderPath));
                        Directory.CreateDirectory(config.SourceFolderPath);
                    }
                    else
                        log.Error(String.Format("ERROR: Source Folder {0} does not exist ", config.SourceFolderPath));
                }
                if (config.DestinationFolderPath.Length > 0 && !(new DirectoryInfo(config.DestinationFolderPath)).Exists)
                {
                    rtnbool = false;
                    if (cmdLineParser.DIRMode && cmdLineParser.TestMode)
                    {
                        //creat the directory
                        log.Info(string.Format("Creating folder {0}", config.DestinationFolderPath));
                        Directory.CreateDirectory(config.DestinationFolderPath);
                    }
                    else
                        log.Error(String.Format("ERROR: Destination Folder {0} does not exist ", config.DestinationFolderPath));
                }
            }
            return rtnbool;
        }

        /// <summary>
        /// CompressMyFiles
        /// </summary>
        /// <param name="string fullname"></param>
        /// <param name="string out compressedFileName"></param>
        /// path and name of candidate file for compression
        /// <returns>
        /// returns true or false of successful compression
        /// </returns>
        private Boolean CompressMyFile(string fullname, out string compressedFileName)
        {
            log.Debug("Start file compression");
            log.Debug(String.Format("working on {0}", fullname));
            FileInfo info = null;
            FileInfo fileToCompress = new FileInfo(fullname);

            compressedFileName = fileToCompress.FullName + ".gz";
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) &
                   FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(compressedFileName))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                           CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                    info = new FileInfo(compressedFileName);
                    log.Debug(String.Format("Compressed {0} from {1} to {2} bytes.",
                    fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString()));
                }
                log.Debug("Stop file compression");
                if (info == null)
                    return false;
                else
                    return true;
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
                log.Warn(string.Format("File:{0} failed to update its dates because of {1}", file, ex.Message));
                //if the format of the file name doesn't conform to the de-facto standard then just put the current time in the compressed file.
                mydate = DateTime.Now;
            }
            File.SetCreationTime(file, mydate);
            File.SetLastAccessTime(file, mydate);
            File.SetLastWriteTime(file, mydate);

        }
    }
}

