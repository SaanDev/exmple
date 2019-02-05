using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Data.SqlClient.SqlConnection con;
        DataSet ds1;
        System.Data.SqlClient.SqlDataAdapter da;
        int MaxRows = 0;
        int inc = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            ds1 = new DataSet();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\example.mdf;Integrated Security=True";

            string sql = "SELECT*From example";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(ds1, "example");
            NavigateRecords();
            MaxRows = ds1.Tables["example"].Rows.Count;
           con.Open();
         //  MessageBox.Show("Database Opened");
          
         con.Close();
          // MessageBox.Show("Database Closed");
          //  con.Dispose();
        }
            private void NavigateRecords()
            {
            DataRow dRow = ds1.Tables["example"].Rows[inc];
                txtindexno.Text = dRow.ItemArray.GetValue(0).ToString();
                txtname.Text = dRow.ItemArray.GetValue(1).ToString();
                txtaddress.Text = dRow.ItemArray.GetValue(2).ToString();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inc !=MaxRows-1)
            {
                inc++;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("No more Rows");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(inc>0)
            {
                inc--;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("This is First Record");
            }
        }
    }
    }

