using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
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
        private const string VERSION = "1.0 LST";
        private const string AJLINK = "https://alijenadeleh.ir";
        private const string SUCCESSTEMPLATE = "Success : {0} ";
        private const string FAILTEMPLATE = "Failed : {0} ";
        private const string SCRIPTALLDATA = "select * from [{0}]";
        private const string SCRIPTCLEARTABLE = "truncate table [{0}] ;";
        private const string SCRIPTDBVERSION = "update [tblControlPanel] set [fldVersion]='{0}' ";
        private const string BACKUPTEMPLATE =
@"USE [{0}];

BACKUP DATABASE [{0}]
TO DISK = '{1}'
   WITH FORMAT,
      MEDIANAME = 'SQLServerBackups',
      NAME = 'Full Backup of [{0}]';";

        private const string STRINGCONNECTIONTEMPLATE = @"Data Source={0};Initial Catalog={1};Integrated Security=True;";
        private const string SCRIPTTABLELIST = @"SELECT TABLE_NAME 
FROM [{0}].INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'";
        
        private DataTable SourceTables,ServersTable;
        private List<int> ErrorIndex;

        
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
            }
            else if(string.IsNullOrEmpty(txtServerSrc.Text))
            {
                Message = "Source server name required .";
                result = false;
            }else if (string.IsNullOrEmpty(txtServerTarget.Text))
            {
                Message = "Target server name required .";
                result = false;
            }
            else if (txtSrcDB.Text == txtTargetDB.Text)
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
            progressMain.Value = 0;
            ErrorIndex = new List<int>();
        }

        /// <summary>
        /// Reload and set connection string text box's
        /// </summary>
        private void ReLoadConnectionString()
        {
            txtSource.Text = string.Format(STRINGCONNECTIONTEMPLATE,txtServerSrc.Text, txtSrcDB.Text);
            txtTarget.Text = string.Format(STRINGCONNECTIONTEMPLATE,txtServerTarget.Text, txtTargetDB.Text);
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
            int Success = 0, Fail = 0,RowCount = 0,CIndex = -1;
            var insScript = new StringBuilder();
            DataTable tblSrc = new DataTable();
            SqlDataAdapter datSrc = new SqlDataAdapter();

            SqlCommand cmdSrc = new SqlCommand("",CnnSrc)
                       , cmdTarget = new SqlCommand("",CnnTarget);
            bool errorTest;
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
                    listOutput.Items.Add($"{tableName} Cleared.");
                    errorTest = false;
                    if (tblSrc.Rows.Count > 0)
                    {

                        string columns = GetColumnName(tblSrc);
                        RowCount = 0;

                        string cmd = "";
                        foreach (DataRow row in tblSrc.Rows)
                        {
                            cmd = $" insert into {tableName}({columns}) select {RowToString(row)} ; ";
                            try
                            {
                                cmdTarget.CommandText = cmd;
                                cmdTarget.ExecuteNonQuery();
                                if(chkVerbose.Checked)
                                        listOutput.Items.Add($"++++++ {cmd} ok.");

                            }
                            catch(Exception exp)
                            {

                                 CIndex = listOutput.Items.Add($"{tableName} {RowCount} {exp.Message}.");
                                 listOutput.Items.Add(cmd);

                                if (!errorTest)
                                {
                                    Fail++;
                                    lblFail.Text = string.Format(FAILTEMPLATE, Fail);                                 
                                    errorTest = true;
                                }
                                if (CIndex != -1)
                                    ErrorIndex.Add(CIndex);
                                
                            }
                            RowCount++;
                            Application.DoEvents();
                        }

                        Success++;

                            
                            lblSuccess.Text = string.Format(SUCCESSTEMPLATE, Success);

                    }
                    listOutput.Items.Add($"{tableName} {RowCount} rows copied done.");
                }catch(Exception ex)
                {
                    CIndex = listOutput.Items.Add($"{tableName} copy failed. {ex.Message}");
                    Fail++;
                    if (CIndex != -1)
                        ErrorIndex.Add(CIndex);
                }
            }


            if (chkLastVersion.Checked)
            {
                try
                {
                    cmdTarget.CommandText = string.Format(SCRIPTDBVERSION, txtDbVersion.Text);
                    cmdTarget.ExecuteNonQuery();
                    listOutput.Items.Add($"DB Version set to {txtDbVersion.Text} .");
                }
                catch
                {
                    CIndex = listOutput.Items.Add($"DB Version set to {txtDbVersion.Text} failed.");
                    if (CIndex != -1)
                        ErrorIndex.Add(CIndex);
                }
            }

            if (CnnSrc.State != ConnectionState.Closed)
                CnnSrc.Close();

            if (CnnTarget.State != ConnectionState.Closed)
                CnnTarget.Close();

            lblFail.Text = string.Format(FAILTEMPLATE, Fail);
            lblSuccess.Text = string.Format(SUCCESSTEMPLATE, Success);
            // check if the src is not empty
            // clear target
            // copy to target            
        }

        /// <summary>
        /// Convert DataTable columns to a SQL like string
        /// </summary>
        /// <param name="dataTable">Source Data Table</param>
        /// <returns>string</returns>
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
        /// <returns>string</returns>
        private string RowToString(DataRow row)
        {
            bool test = false;
            var res = new StringBuilder();
            string tmp;
            for(int i = 0; i < row.ItemArray.Count(); i++)
            {
                if(row[i].GetType() == Type.GetType("System.String")){
                    tmp = $"'{row[i].ToString()}'";
                }else if(row[i].GetType() == Type.GetType("System.DateTime")){
                    tmp = $"'{row[i].ToString()}'";
                }
                else{
                    tmp = row[i].ToString();
                    if (string.IsNullOrEmpty(tmp))
                        tmp = "0";
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
            
            ErrorIndex = new List<int>();

            lblVersion.Text = $"Version : {VERSION}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            progressMain.Value = 0;
            timer1.Start();
            btnClear.Enabled =
             btnClose.Enabled =
                btnBackup.Enabled = 
            (sender as Button).Enabled = false;
            txtSrcDB.Enabled = false;
            txtTargetDB.Enabled = false;
            txtServerSrc.Enabled = false;
            txtServerTarget.Enabled = false;

            ClearOutput();
            listOutput.Items.Add($"Copy start {DateTime.Now.ToString()}");
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

            int inx = listOutput.Items.Add($"Copy done {DateTime.Now.ToString()}");
           
            txtSrcDB.Enabled = true;
            txtTargetDB.Enabled = true;
            txtServerSrc.Enabled = true;
            txtServerTarget.Enabled = true;
            progressMain.Value = 100;
            timer1.Stop();
            MessageBox.Show("Operation done successfuly");
            btnClear.Enabled =
           btnClose.Enabled =
           btnBackup.Enabled =
           (sender as Button).Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            ClearOutput();
            ErrorIndex.Clear();
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
                p.SrcServername = txtServerSrc.Text;
                p.TargetServerName = txtServerTarget.Text;
                p.DBVersion = txtDbVersion.Text;
                p.Save();
            }
            catch { }
        }

        private void frmClone_Load(object sender, EventArgs e)
        {
            lblVersion.Text = VERSION;
            var p = new Properties.Settings();
            try
            {
                txtSrcDB.Text = p.SrcDBName;
                txtTargetDB.Text = p.TargetDBName;
                txtServerSrc.Text = p.SrcServername;
                txtServerTarget.Text = p.TargetServerName;
                txtDbVersion.Text = p.DBVersion;
                ReLoadConnectionString();
            }
            catch { }
        }

        private void linkMain_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AJLINK);
        }

        private void txtServerSrc_TextChanged(object sender, EventArgs e)
        {
            ReLoadConnectionString();
        }

        private void txtServerTarget_TextChanged(object sender, EventArgs e)
        {
            ReLoadConnectionString();
        }

        private void listOutput_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                if (ErrorIndex != null && ErrorIndex.Count > 0 && ErrorIndex.IndexOf(e.Index) != -1)
                {
                    e = new DrawItemEventArgs(e.Graphics,
                                      e.Font,
                                      e.Bounds,
                                      e.Index,
                                      e.State,// ^ DrawItemState.Selected,
                                      e.ForeColor,
                                      Color.Yellow);//Choose the color


                }

                e.DrawBackground();
                // Draw the current item text
                e.Graphics.DrawString(listOutput.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
                // If the ListBox has focus, draw a focus rectangle around the selected item.
                e.DrawFocusRectangle();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Forms.frmList();
            if (frm.SafeShow(Classes.Models.SelectState.ServerList) == DialogResult.OK)
            {
                txtServerSrc.Text = frm.SelectedItem;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Forms.frmList();
            if (frm.SafeShow(Classes.Models.SelectState.ServerList) == DialogResult.OK)
            {
                txtServerTarget.Text = frm.SelectedItem;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new Forms.frmList();
            if (frm.SafeShow(Classes.Models.SelectState.DbList, txtServerSrc.Text) == DialogResult.OK)
            {
                txtSrcDB.Text = frm.SelectedItem;
            }
        }

        private void listOutput_DoubleClick(object sender, EventArgs e)
        {
            if(listOutput.SelectedIndex > 0)
            {
                Clipboard.SetText(listOutput.SelectedItem.ToString());
                MessageBox.Show("Selected Item copied to clipboard.");
            }
        }

        private void chkLastVersion_CheckedChanged(object sender, EventArgs e)
        {
            bool tst = (sender as CheckBox).Checked;
            txtDbVersion.Enabled = tst;
            if (tst)
                txtDbVersion.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new Forms.frmList();
            if (frm.SafeShow(Classes.Models.SelectState.DbList, txtServerTarget.Text) == DialogResult.OK)
            {
                txtTargetDB.Text = frm.SelectedItem;
            }
        }

        private void txtDbVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar != (char)Keys.Back && e.KeyChar != '.' 
                                    && (e.KeyChar > '9' || e.KeyChar < '0'))
                                                                    e.KeyChar = '\0';
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressMain.Value < 100)
                progressMain.Value += 10;
            else
                progressMain.Value = 0;
            Application.DoEvents();
        }

        private async void btnBackup_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            
            dlg.FileName = $"{txtTargetDB.Text}.bak";
            dlg.Filter = "Backup Files | *.bak";
            dlg.Title = "Select backup file location";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                var cnn = await GetConnectionAsync(txtTarget.Text);
                if (cnn != null)
                {
                    try
                    {
                        var cmd = new SqlCommand(string.Format(BACKUPTEMPLATE, txtTargetDB.Text, path), cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Backup file created successfuly");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Exception happend. " + ex.Message);
                    }
                    finally
                    {
                        if(cnn.State != ConnectionState.Closed)
                            cnn.Close();
                    }
                    // make backup file
                    // saveit
                }
                else
                {
                    MessageBox.Show("Database could't be found !");
                }
            }
        }
    }
}
