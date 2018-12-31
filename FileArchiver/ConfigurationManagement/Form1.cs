using System;
using System.Data;
using System.Windows.Forms;

namespace ConfigurationManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.fileCleanupConfigurationTableAdapter.Fill(this.eTRM_SupportDataSet.FileCleanupConfiguration);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            fileCleanupConfigurationTableAdapter.Update(eTRM_SupportDataSet);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;
            if (e.ColumnIndex == dataGridView1.Columns["DeleteCol"].Index)
                fileCleanupConfigurationBindingSource.RemoveAt(e.RowIndex);
        }
    }
}
