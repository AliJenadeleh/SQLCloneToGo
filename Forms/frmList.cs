using SQLCloneToGo.Classes.Models;
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


namespace SQLCloneToGo.Forms
{
    public partial class frmList : Form
    {
        private const string SERVERFIELD = "ServerName";
        private const string INSTANCEFIELD = "InstanceName";
        private const string DBSCRIPT = "SELECT [name] from sys.databases";
        private SelectState state;
        private static DataTable ServersTable,DBTable;
        private string ServerName;
        public string SelectedItem { get;private set; }

        private void LoadInstances()
        {

            if (ServersTable == null)
                ServersTable = SqlDataSourceEnumerator.Instance.GetDataSources();
            
            string myServer = Environment.MachineName;

            foreach (DataRow row in ServersTable.Rows)
                if(row[SERVERFIELD].ToString() == myServer)
                    listMain.Items.Add($"{row[SERVERFIELD].ToString()}\\{row[INSTANCEFIELD]}");
        }
        private void LoadItems()
        {
            listMain.Items.Clear();

            if (state == SelectState.ServerList) {
                LoadInstances();
            }else if(state == SelectState.DbList)
            {
                if (DBTable == null)
                {
                    string cnnStr = $"Data Source={ServerName}; Integrated Security=True;";
                    var cnn = new SqlConnection(cnnStr);
                    var cmd = new SqlCommand(DBSCRIPT, cnn);
                    var dat = new SqlDataAdapter(cmd);
                    DBTable = new DataTable();
                    dat.Fill(DBTable);
                    cnn.Close();
                }

                foreach (DataRow row in DBTable.Rows)
                    listMain.Items.Add(row[0].ToString());
            }
        }

        public DialogResult SafeShow(SelectState state,string Server="")
        {
            this.state = state;
            this.ServerName = Server;
            LoadItems();
            return this.ShowDialog();
        }

        private void DoSelect()
        {
            if(listMain.SelectedIndex > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.SelectedItem = listMain.SelectedItem.ToString();
                this.Close();
            }
        }

        public frmList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmList_Load(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DoSelect();
        }

        private void listMain_DoubleClick(object sender, EventArgs e)
        {
            DoSelect();
        }
    }
}
