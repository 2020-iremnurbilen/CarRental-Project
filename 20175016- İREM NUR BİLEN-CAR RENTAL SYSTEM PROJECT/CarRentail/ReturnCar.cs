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
    public partial class ReturnCar : Form
    {
        public ReturnCar()
        {
            InitializeComponent();
            load();
            
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UGKEN29;Initial Catalog=CarRental;User ID=sa;Password=123");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;


      

        public void load()
        {

            sql = "SELECT Car_id,Cust_id,Date,Elapsed,Fine FROM Return0";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);

            }

            con.Close();

        }




        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar == 13)
            {

                cmd = new SqlCommand("Select car_id,cust_id,date,due,DATEDIFF(dd,due,GETDATE()) AS elapsed from RentalTable where car_id = '" + txtcarid.Text  +  "'" ,con);
                con.Open();
                dr = cmd.ExecuteReader();


                if (dr.Read())

                {


                    txtcustid.Text = dr["cust_id"].ToString();
                    txtdate.Text = dr["due"].ToString();

                    string elapsed = dr["Elapsed"].ToString();

                    int elap = int.Parse(elapsed);

                    if( elap > 0 )
                    {
                        txtelap.Text = elapsed;
                        int fine = elap * 100;
                        txtfine.Text = fine.ToString();
                    }

         

                }

                else
                {
                    txtfine.Text = "0";
                    txtfine.Text = "0";
                }

                con.Close();


            }


        }

        private void ReturnCar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            load();
            txtcarid.Clear();
            txtcustid.Clear();
            txtdate.Clear();
            txtelap.Clear();
            txtfine.Clear();
            txtcarid.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string carid = txtcarid.Text;
            string custid = txtcustid.Text;
            string date = txtdate.Text;
            string elap = txtelap.Text;
            string fine = txtfine.Text;


            sql = "insert into dbo.Return0(Car_id,Cust_id,Date,Elapsed,Fine)values(@Car_id,@Cust_id,@Date,@Elapsed,@Fine)";
       
            con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Car_id", carid);
                cmd.Parameters.AddWithValue("@Cust_id", custid);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Elapsed", elap);
                cmd.Parameters.AddWithValue("@Fine", fine);
               

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added.");

            con.Close();
           
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
