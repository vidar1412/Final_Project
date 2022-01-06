using System;
using System.Collections.Generic;
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
    public partial class Form2 : Form
    {
        public static Form2 Current;
        public Form2()
        {
            Current = this;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True";
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.Current.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True";
            con.Open();
            string Accountant_ID = textBox1.Text;
            string pwd = textBox2.Text;
            string pwdRepeat = textBox3.Text;
            string fullName = textBox4.Text;
            string gender = "";
            if (checkBox1.Checked)
            {
                gender = checkBox1.Text;
            } else
            {
                gender = checkBox2.Text;
            }
            string email = textBox5.Text;
            string phoneNum = textBox6.Text;

            SqlCommand cmd = new SqlCommand("INSERT INTO ACCOUNTANT_ACCOUNT VALUES('" + Accountant_ID + "', '" + pwd + "','"  + fullName + "','" + gender + "','" + email + "','" + phoneNum + "','" + textBox7.Text + "')", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Create account sucess");
            con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
   
}
