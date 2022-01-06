using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CNPM_FinalProject
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public static Form1 Current;
        private static string AC_NAME = "";
        public Form1()
        {
           
            Current = this;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True";
            InitializeComponent();
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True");
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            AC_NAME = textBox1.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True";
            con.Open();
            
            SqlCommand cmd = new SqlCommand("select AC_ID, AC_PWD from ACCOUNTANT_ACCOUNT where AC_ID='" + textBox1.Text + "'and AC_PWD='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login sucess  " + AC_NAME);
                Hide();
                MANAGE form3 = new MANAGE();
                form3.Closed += (s, args) => Close();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.Closed += (s, args) => Close();
            form2.Show();
        }

        public string getAC_NAME
        {
            get
            {
                return AC_NAME;
            }
        }
    }
}
