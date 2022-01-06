using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CNPM_FinalProject
{
    public partial class MANAGE : Form
    {
        private static string accountant_Name = "";
        private static string receiptID = "";
        private static string receiptID2 = "";
        private static string itemID = "";
        private static string warehouseID = "";
        private static string item_Quantity = "";
       
        private static DateTime date;

        public MANAGE()
        {

            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form1 tmp = new Form1();
            accountant_Name = tmp.getAC_NAME;
            Label AC_NAME = new Label();

            AC_NAME.Text = accountant_Name;
            AC_NAME.Location = new Point(215, 115);
            AC_NAME.AutoSize = true;
            AC_NAME.Font = new Font("Microsoft Sans Serif", 18);
            AC_NAME.BorderStyle = BorderStyle.Fixed3D;
            AC_NAME.ForeColor = Color.Green;
            AC_NAME.Padding = new Padding(6);

            // Adding this control to the form
            this.Controls.Add(AC_NAME);


            // TODO: This line of code loads data into the 'importReceipt.IMPORTRECEIPT' table. You can move, or remove it, as needed.
            //this.iMPORTRECEIPTTableAdapter.Fill(this.importReceipt.IMPORTRECEIPT);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM IMPORTRECEIPT", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Fill sucess Welcome");
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data");
            }
            con.Close();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True";
            con.Open();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            receiptID = textBox1.Text;
            receiptID2 = textBox5.Text;
            itemID = textBox2.Text;
            warehouseID = textBox3.Text;
            item_Quantity = textBox4.Text;
            date = dateTimePicker1.Value;

            SqlCommand cmd = new SqlCommand("INSERT INTO IMPORTRECEIPT (RECEIPT_ID, ITEM_ID, AC_ID, WAREHOUSE_ID, ITEM_QUANTITY, IMPORT_DATE, TOTAL_MONEY) SELECT '" + receiptID + "', '" + itemID + "', '" + accountant_Name + "', '" + warehouseID + "', " + item_Quantity + ", '" + date + "', ITEM.ITEM_PRICE * " + item_Quantity + " FROM ITEM WHERE ITEM_ID = '" + itemID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                int a = cmd.ExecuteNonQuery();
                if (a == 0)
                    MessageBox.Show("PLEASE CHECK YOUR INPUT AGAIN!!!");
                else
                    MessageBox.Show("ADDED SUCCESSFULLY");
                    Form3_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string getAC_NAME
        {
            get
            {
                return accountant_Name;
            }
        }

        public string getReceiptID
        {
            get
            {
                return receiptID;
            }
        }

        public string getReceiptID2
        {
            get
            {
                return receiptID2;
            }
        }

        public string getItemID
        {
            get
            {
                return itemID;
            }
        }

        public string getWarehouseID
        {
            get
            {
                return warehouseID;
            }
        }

        public string getItemQuantity
        {
            get
            {
                return item_Quantity;
            }
        }

        public DateTime getDate
        {
            get
            {
                return date;
            }
        }



        private void label10_Click_1(object sender, EventArgs e)
        {

        }

/*        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ADMIN\\VIDAR1715;Initial Catalog=SaleDB;Integrated Security=True"))
            {
                con.Open();

                using (SqlCommand q = con.CreateCommand())
                {
                    q.CommandText = String.Format(
                      @"SELECT ITEM.ITEM_PRICE
                        from ITEM
                        where ITEM_ID = @receiptID2");



                    using (var reader = q.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                totalMoney = (int)reader[0];



                            }
                        }
                        else
                        {
                            Console.WriteLine("NO RETURN DATA!!!");
                        }
                    }
                }


                Hide();
                Form4 form4 = new Form4();
                form4.Closed += (s, args) => Close();
                form4.Show();
            }
        }*/
    }
}
