namespace ConfigurationManagement
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fileCleanupConfigurationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eTRM_SupportDataSet = new ConfigurationManagement.ETRM_SupportDataSet();
            this.fileCleanupConfigurationTableAdapter = new ConfigurationManagement.ETRM_SupportDataSetTableAdapters.FileCleanupConfigurationTableAdapter();
            this.DeleteCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cleanUpTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.serverNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceFolderPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceFilePatternDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retentionDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationFolderPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compressDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.orderofExecutionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileCleanupConfigurationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTRM_SupportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteCol,
            this.cleanUpTypeDataGridViewTextBoxColumn,
            this.serverNameDataGridViewTextBoxColumn,
            this.sourceFolderPathDataGridViewTextBoxColumn,
            this.sourceFilePatternDataGridViewTextBoxColumn,
            this.retentionDaysDataGridViewTextBoxColumn,
            this.destinationFolderPathDataGridViewTextBoxColumn,
            this.compressDataGridViewCheckBoxColumn,
            this.orderofExecutionDataGridViewTextBoxColumn});
            this.tableLayoutPanel2.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.DataSource = this.fileCleanupConfigurationBindingSource;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // fileCleanupConfigurationBindingSource
            // 
            this.fileCleanupConfigurationBindingSource.DataMember = "FileCleanupConfiguration";
            this.fileCleanupConfigurationBindingSource.DataSource = this.eTRM_SupportDataSet;
            // 
            // eTRM_SupportDataSet
            // 
            this.eTRM_SupportDataSet.DataSetName = "ETRM_SupportDataSet";
            this.eTRM_SupportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fileCleanupConfigurationTableAdapter
            // 
            this.fileCleanupConfigurationTableAdapter.ClearBeforeFill = true;
            // 
            // DeleteCol
            // 
            this.DeleteCol.DataPropertyName = "Delete Row";
            this.DeleteCol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.DeleteCol, "DeleteCol");
            this.DeleteCol.Name = "DeleteCol";
            this.DeleteCol.Text = "Delete Row";
            this.DeleteCol.UseColumnTextForButtonValue = true;
            // 
            // cleanUpTypeDataGridViewTextBoxColumn
            // 
            this.cleanUpTypeDataGridViewTextBoxColumn.DataPropertyName = "CleanUpType";
            resources.ApplyResources(this.cleanUpTypeDataGridViewTextBoxColumn, "cleanUpTypeDataGridViewTextBoxColumn");
            this.cleanUpTypeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "Delete",
            "Archive"});
            this.cleanUpTypeDataGridViewTextBoxColumn.Name = "cleanUpTypeDataGridViewTextBoxColumn";
            this.cleanUpTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cleanUpTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // serverNameDataGridViewTextBoxColumn
            // 
            this.serverNameDataGridViewTextBoxColumn.DataPropertyName = "ServerName";
            resources.ApplyResources(this.serverNameDataGridViewTextBoxColumn, "serverNameDataGridViewTextBoxColumn");
            this.serverNameDataGridViewTextBoxColumn.Name = "serverNameDataGridViewTextBoxColumn";
            // 
            // sourceFolderPathDataGridViewTextBoxColumn
            // 
            this.sourceFolderPathDataGridViewTextBoxColumn.DataPropertyName = "SourceFolderPath";
            resources.ApplyResources(this.sourceFolderPathDataGridViewTextBoxColumn, "sourceFolderPathDataGridViewTextBoxColumn");
            this.sourceFolderPathDataGridViewTextBoxColumn.Name = "sourceFolderPathDataGridViewTextBoxColumn";
            // 
            // sourceFilePatternDataGridViewTextBoxColumn
            // 
            this.sourceFilePatternDataGridViewTextBoxColumn.DataPropertyName = "SourceFilePattern";
            resources.ApplyResources(this.sourceFilePatternDataGridViewTextBoxColumn, "sourceFilePatternDataGridViewTextBoxColumn");
            this.sourceFilePatternDataGridViewTextBoxColumn.Name = "sourceFilePatternDataGridViewTextBoxColumn";
            // 
            // retentionDaysDataGridViewTextBoxColumn
            // 
            this.retentionDaysDataGridViewTextBoxColumn.DataPropertyName = "RetentionDays";
            resources.ApplyResources(this.retentionDaysDataGridViewTextBoxColumn, "retentionDaysDataGridViewTextBoxColumn");
            this.retentionDaysDataGridViewTextBoxColumn.Name = "retentionDaysDataGridViewTextBoxColumn";
            // 
            // destinationFolderPathDataGridViewTextBoxColumn
            // 
            this.destinationFolderPathDataGridViewTextBoxColumn.DataPropertyName = "DestinationFolderPath";
            resources.ApplyResources(this.destinationFolderPathDataGridViewTextBoxColumn, "destinationFolderPathDataGridViewTextBoxColumn");
            this.destinationFolderPathDataGridViewTextBoxColumn.Name = "destinationFolderPathDataGridViewTextBoxColumn";
            // 
            // compressDataGridViewCheckBoxColumn
            // 
            this.compressDataGridViewCheckBoxColumn.DataPropertyName = "Compress";
            resources.ApplyResources(this.compressDataGridViewCheckBoxColumn, "compressDataGridViewCheckBoxColumn");
            this.compressDataGridViewCheckBoxColumn.Name = "compressDataGridViewCheckBoxColumn";
            // 
            // orderofExecutionDataGridViewTextBoxColumn
            // 
            this.orderofExecutionDataGridViewTextBoxColumn.DataPropertyName = "OrderofExecution";
            resources.ApplyResources(this.orderofExecutionDataGridViewTextBoxColumn, "orderofExecutionDataGridViewTextBoxColumn");
            this.orderofExecutionDataGridViewTextBoxColumn.Name = "orderofExecutionDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileCleanupConfigurationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTRM_SupportDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ETRM_SupportDataSet eTRM_SupportDataSet;
        private System.Windows.Forms.BindingSource fileCleanupConfigurationBindingSource;
        private ETRM_SupportDataSetTableAdapters.FileCleanupConfigurationTableAdapter fileCleanupConfigurationTableAdapter;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn cleanUpTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceFolderPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceFilePatternDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn retentionDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationFolderPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn compressDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderofExecutionDataGridViewTextBoxColumn;
    }
}

