using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRentail
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            Autono();
            customerload();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UGKEN29;Initial Catalog=CarRental;User ID=sa;Password=123");
        SqlCommand cmd;
        SqlDataReader dr;
        string proid;
        string sql;
        bool Mode = true;
        string id;



        public void Autono()
        {
            sql = "Select custid from CustomerTable order by custid desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proid = id.ToString("00000");

            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("00001");

            }
            else
            {
                proid = ("00001");
            }

            txtid.Text = proid.ToString();

            con.Close();


        }

        public void customerload()
        {

            sql = "select * from CustomerTable";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);

            }

            con.Close();

        }

        public void getid(String id)
        {
            sql = "select * from CustomerTable where custid =  '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtid.Text = dr[0].ToString();
                txtcustname.Text = dr[1].ToString();
                txtaddress.Text = dr[2].ToString();
                txtphone.Text = dr[3].ToString();
            }

            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                txtid.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getid(id);
            }

            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {

     
                MessageBox.Show("You are not authorized for this transaction. Please inform the database advisor!");
               
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string custid = txtid.Text;
            string custname = txtcustname.Text;
            string address = txtaddress.Text;
            string mobile = txtphone.Text;

          // id = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            if (Mode == true)
            {
                sql = "insert into CustomerTable(custid,custname,address,mobile)values(@custid,@custname,@address,@mobile)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@custid", custid);
                cmd.Parameters.AddWithValue("@custname", custname);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added.");

                txtcustname.Clear();
                txtaddress.Clear();
                txtphone.Clear();
                txtcustname.Focus();



            }
            else
            {

                sql = "update CustomerTable set  custname = @custname, address = @address, mobile = @mobile where custid = @custid";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@custname", custname);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@custid", custid);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated.");
                txtid.Enabled = true;
                Mode = true;

                txtcustname.Clear();
                txtaddress.Clear();
                txtphone.Clear();
                txtcustname.Focus();



            }

            con.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            customerload();
            Autono();
        
            txtcustname.Clear();
            txtaddress.Clear();
            txtphone.Clear();
            txtcustname.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
    }

