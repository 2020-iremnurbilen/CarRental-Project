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
    public partial class Rentail : Form
    {
        public Rentail()
        {
            InitializeComponent();
            carload();
            rentalload();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UGKEN29;Initial Catalog=CarRental;User ID=sa;Password=123");
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;
        string proid;
        string sql;
        string sql1;
        bool Mode = true;
        string id;




        public void carload()
        {

            cmd = new SqlCommand("Select * from CarRegistration ", con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                txtcarid.Items.Add(dr["RegNo"].ToString());

            }

            con.Close();


        }

        public void rentalload()
        {

            sql = "select * from RentalTable";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);

            }

            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Rentail_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }


        private void txtcustid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                cmd = new SqlCommand("Select * from CustomerTable where custid = '" + txtcustid.Text + "'  ", con);
                con.Open();
                dr = cmd.ExecuteReader();


                if (dr.Read())

                {

                    txtcustname.Text = dr["custname"].ToString();


                }

                else
                {
                    MessageBox.Show("Customer ID Not Found");
                }

                con.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string carid = txtcarid.SelectedItem.ToString();
            string custid = txtcustid.Text;
            string custname = txtcustname.Text;
            string fee = txtfee.Text;
            string date = txtdate.Value.Date.ToString("yyyy-MM-dd");
            string due = txtdue.Value.Date.ToString("yyyy-MM-dd");


                sql = "insert into RentalTable(car_id,cust_id,cust_name,fee,date,due)values(@car_id,@cust_id,@cust_name,@fee,@date,@due)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@car_id", carid);
                cmd.Parameters.AddWithValue("@cust_id", custid);
                cmd.Parameters.AddWithValue("@cust_name", custname);
                cmd.Parameters.AddWithValue("@fee", fee);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@due", due);   
                cmd.ExecuteNonQuery();
               




            sql1 = "update CarRegistration set Available = 'No' where RegNo = @RegNo ";
            
            cmd1 = new SqlCommand(sql1, con);
            cmd1.Parameters.AddWithValue("@RegNo", carid);
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Record Added.");
            con.Close();

            }

        private void txtcarid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from CarRegistration where RegNo = '" + txtcarid.Text + "'   ", con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string aval;
                aval = dr["Available"].ToString();
                label9.Text = aval;

                if (aval == "No")
                {
                    txtcustid.Enabled = false;
                    txtcustname.Enabled = false;
                    txtfee.Enabled = false;
                    txtdate.Enabled = false;
                    txtdue.Enabled = false;

                }

                else
                {
                    txtcustid.Enabled = true;
                    txtcustname.Enabled = true;
                    txtfee.Enabled = true;
                    txtdate.Enabled = true;
                    txtdue.Enabled = true;
                }


            }

            else
            {
                label9.Text = "Car Not Available";
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            carload();
            rentalload();
            
            txtcustname.Clear();
            txtdate.Value.Date.ToString();
            txtdue.Value.Date.ToString();
            txtfee.Clear();
            txtcustname.Focus();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }
    }
}

