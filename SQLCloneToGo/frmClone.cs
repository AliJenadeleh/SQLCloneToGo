using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCloneToGo
{
    public partial class frmClone : Form
    {
        private const string AJLINK = "https://alijenadeleh.ir";
        private const string SCRIPTALLDATA = "select * from [{0}]";
        private const string SCRIPTCLEARTABLE = "delete from [{0}]";
        private const string STRINGCONNECTIONTEMPLATE = @"Data Source=.\ZOMOROD;Initial Catalog={0};Integrated Security=True;";
        private const string SCRIPTTABLELIST = @"SELECT TABLE_NAME 
FROM [{0}].INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'";
        private DataTable SourceTables;
        
        /// <summary>
        /// check the inputs values
        /// </summary>
        /// <returns>bool</returns>
        private bool IsValidate()
        {
            bool result = true;
            string Message = "";

            if (string.IsNullOrEmpty(txtSrcDB.Text))
            {
                Message = "Source database name required .";
                result = false;
            }else if (string.IsNullOrEmpty(txtTargetDB.Text))
            {
                Message = "Target database name required .";
                result = false;
            }else
            if (txtSrcDB.Text == txtTargetDB.Text)
            {
                Message = "Source database name and target database name can`t be the same .";
                result = false;
            }

            if (!result)
                MessageBox.Show(Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return result;
        }

        /// <summary>
        /// Clear input control`s
        /// </summary>
        private void ClearInputs()
        {
            txtSrcDB.Clear();
            txtTargetDB.Clear();
        }

        /// <summary>
        /// Clear the output list
        /// </summary>
        private void ClearOutput()
        {
            listOutput.Items.Clear();
        }

        /// <summary>
        /// Reload and set connection string text box's
        /// </summary>
        private void ReLoadConnectionString()
        {
            txtSource.Text = string.Format(STRINGCONNECTIONTEMPLATE, txtSrcDB.Text);
            txtTarget.Text = string.Format(STRINGCONNECTIONTEMPLATE, txtTargetDB.Text);
        }

        /// <summary>
        /// Check and return a SqlConnection Object
        /// </summary>
        /// <param name="ConnectionString">Connection String to link</param>
        /// <returns>SqlConnection</returns>
        private async Task<SqlConnection> GetConnectionAsync(string ConnectionString)
        {
            var cnn = new SqlConnection(ConnectionString);
            try
            {
                await cnn.OpenAsync();
                return cnn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get All tables in a Sql Data Base
        /// </summary>
        /// <param name="Connection">SqlConnection Object</param>
        /// <param name="DbName">DataBase Name</param>
        /// <returns>string[]</returns>
        private async Task<string[]> GetTablesAsync(SqlConnection Connection,string DbName)
        {
            return await Task.Run(() => { 
                var cmd = new SqlCommand(string.Format(SCRIPTTABLELIST, DbName), Connection);
                var dat = new SqlDataAdapter(cmd);
                var tbl = new DataTable();
                dat.Fill(tbl);
                var res = new List<string>();
                string tmp;
                foreach (DataRow Row in tbl.Rows)
                {
                    tmp = Row[0].ToString();
                    res.Add(tmp);
                    listOutput.Invoke(new Action(() => { 
                        listOutput.Items.Add($"{tmp} from {DbName} detected.");
                    }));
                }

                return res.ToArray();
            });
        }

        /// <summary>
        /// Copy all data from Source to Target
        /// </summary>
        /// <param name="Tables">Table name list</param>
        /// <param name="CnnSrc">Source Connection Object</param>
        /// <param name="CnnTarget">Target Connection Object</param>
        public void CopyTo(string[] Tables,SqlConnection CnnSrc,SqlConnection CnnTarget)
        {
            var insScript = new StringBuilder();
            DataTable tblSrc = new DataTable();
            SqlDataAdapter datSrc = new SqlDataAdapter();

            SqlCommand cmdSrc = new SqlCommand("",CnnSrc)
                       , cmdTarget = new SqlCommand("",CnnTarget);

            foreach(string tableName in Tables)
            {
                listOutput.Items.Add($"{tableName} copy start.");
                cmdSrc.CommandText = string.Format(SCRIPTALLDATA, tableName);
                datSrc.SelectCommand = cmdSrc;
                tblSrc = new DataTable();
                datSrc.Fill(tblSrc);
                try
                {
                    cmdTarget.CommandText = string.Format(SCRIPTCLEARTABLE, tableName);
                    cmdTarget.ExecuteNonQuery();

                    if (tblSrc.Rows.Count > 0)
                    {

                        string columns = GetColumnName(tblSrc);

                        foreach (DataRow row in tblSrc.Rows)
                        {
                            cmdTarget.CommandText = $" insert into {tableName}({columns}) select {RowToString(row)} ";
                            cmdTarget.ExecuteNonQuery();
                        }

                    }
                    listOutput.Items.Add($"{tableName} copy done.");
                }catch(Exception ex)
                {
                    listOutput.Items.Add($"{tableName} copy failed.");
                    listOutput.Items.Add(ex.Message);
                }
            }

            // check if the src is not empty
            // clear target
            // copy to target            
        }

        private string GetColumnName(DataTable dataTable)
        {
            bool test = false;
            var res = new StringBuilder();

            for(int i = 0; i < dataTable.Columns.Count; i++)
            {
                if (test)
                {
                    res.Append("," + dataTable.Columns[i].ColumnName);
                }
                else
                {
                    res.Append(dataTable.Columns[i].ColumnName);
                    test = true;
                }



            }

            return res.ToString();
        }

        /// <summary>
        /// Convert an DataRow Object to SQL like string
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string RowToString(DataRow row)
        {
            bool test = false;
            var res = new StringBuilder();
            string tmp;
            for(int i = 0; i < row.ItemArray.Count(); i++)
            {
                if(row[i].GetType() == Type.GetType("System.String")){
                    tmp = $"'{row[i].ToString()}'";
                }else if(row[i].GetType() == Type.GetType("System.String")){
                    tmp = $"'{row[i].ToString()}'";
                }
                else{
                    tmp = row[i].ToString();
                }
                
                if (string.IsNullOrEmpty(tmp)) tmp = "null";

                    if (test)
                        res.Append($",{tmp}");
                    else
                    {
                        res.Append(tmp);
                        test = true;
                    }

            }

            return res.ToString();
        }

        public frmClone()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            txtSrcDB.Enabled = false;
            txtTargetDB.Enabled = false;
            ClearOutput();
            if (IsValidate())
            {
                var cnnsrc = await GetConnectionAsync(txtSource.Text);
                var cnndest =await GetConnectionAsync(txtTarget.Text);

                if(cnnsrc != null && cnndest != null)
                {
                    // get source tables list
                    var tables =await GetTablesAsync(cnnsrc, txtSrcDB.Text);
                    // Copy Data
                    CopyTo(tables, cnnsrc, cnndest);
                }
                else
                {
                    MessageBox.Show("Connection Instance set to null");
                }
                
                // foreach tbl in tables
                // copy from source to target
                // Make backup
                // done
            }

            (sender as Button).Enabled = true;
            txtSrcDB.Enabled = true;
            txtTargetDB.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            ClearOutput();
        }

        private void txtSrcDB_TextChanged(object sender, EventArgs e)
        {
            ReLoadConnectionString();
        }

        private void txtTargetDB_TextChanged(object sender, EventArgs e)
        {
            ReLoadConnectionString();
        }

        private void frmClone_FormClosing(object sender, FormClosingEventArgs e)
        {
            var p = new Properties.Settings();
            try
            {
                p.SrcDBName = txtSrcDB.Text;
                p.TargetDBName = txtTargetDB.Text;
                p.Save();
            }
            catch { }
        }

        private void frmClone_Load(object sender, EventArgs e)
        {
            var p = new Properties.Settings();
            try
            {
                txtSrcDB.Text = p.SrcDBName;
                txtTargetDB.Text = p.TargetDBName;
                ReLoadConnectionString();
            }
            catch { }
        }

        private void linkMain_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AJLINK);
        }
    }
}
