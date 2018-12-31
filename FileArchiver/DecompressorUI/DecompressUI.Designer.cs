namespace DecompressorUI
{
    partial class DecompressUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFolderPath = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lbltarget = new System.Windows.Forms.Label();
            this.lblSearchPattern = new System.Windows.Forms.Label();
            this.txtSearchPattern = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbflyover = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderPath.Location = new System.Drawing.Point(16, 80);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(510, 23);
            this.txtFolderPath.TabIndex = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(16, 99);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(8);
            this.monthCalendar1.MaxSelectionCount = 365;
            this.monthCalendar1.MinimumSize = new System.Drawing.Size(495, 198);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateChanged);
            this.monthCalendar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.monthCalendar1_MouseMove);
            // 
            // lbltarget
            // 
            this.lbltarget.AutoSize = true;
            this.lbltarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltarget.Location = new System.Drawing.Point(16, 57);
            this.lbltarget.Name = "lbltarget";
            this.lbltarget.Size = new System.Drawing.Size(112, 17);
            this.lbltarget.TabIndex = 5;
            this.lbltarget.Text = "Target Folder:";
            // 
            // lblSearchPattern
            // 
            this.lblSearchPattern.AutoSize = true;
            this.lblSearchPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPattern.Location = new System.Drawing.Point(16, 0);
            this.lblSearchPattern.Name = "lblSearchPattern";
            this.lblSearchPattern.Size = new System.Drawing.Size(122, 17);
            this.lblSearchPattern.TabIndex = 6;
            this.lblSearchPattern.Text = "Search Pattern:";
            // 
            // txtSearchPattern
            // 
            this.txtSearchPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPattern.Location = new System.Drawing.Point(16, 23);
            this.txtSearchPattern.Name = "txtSearchPattern";
            this.txtSearchPattern.Size = new System.Drawing.Size(233, 23);
            this.txtSearchPattern.TabIndex = 7;
            this.txtSearchPattern.Text = "*";
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Location = new System.Drawing.Point(134, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(54, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRetrieve.Location = new System.Drawing.Point(194, 54);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(55, 23);
            this.btnRetrieve.TabIndex = 9;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.Enabled = false;
            this.btnExpand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExpand.Location = new System.Drawing.Point(278, 54);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(75, 23);
            this.btnExpand.TabIndex = 10;
            this.btnExpand.Text = "Expand - ";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Visible = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GrayText;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(248, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = ".gz";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbflyover
            // 
            this.cbflyover.AutoSize = true;
            this.cbflyover.Location = new System.Drawing.Point(335, 0);
            this.cbflyover.Name = "cbflyover";
            this.cbflyover.Size = new System.Drawing.Size(127, 17);
            this.cbflyover.TabIndex = 12;
            this.cbflyover.Text = "Turn On Flyover stats";
            this.cbflyover.UseVisualStyleBackColor = true;
            // 
            // DecompressUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(554, 306);
            this.Controls.Add(this.cbflyover);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchPattern);
            this.Controls.Add(this.lblSearchPattern);
            this.Controls.Add(this.lbltarget);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.monthCalendar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.MinimumSize = new System.Drawing.Size(570, 345);
            this.Name = "DecompressUI";
            this.Text = "Decompress User Interface";
            this.Resize += new System.EventHandler(this.DecompressUI_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox txtFolderPath;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lbltarget;
        private System.Windows.Forms.Label lblSearchPattern;
        private System.Windows.Forms.TextBox txtSearchPattern;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbflyover;
    }
}

