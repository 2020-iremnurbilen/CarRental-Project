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
    public partial class CarRegistration : Form
    {
        public CarRegistration()
        {
            InitializeComponent();
            Autono();
            load();
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
            sql = "Select RegNo from CarRegistration order by RegNo desc";
            cmd = new SqlCommand(sql,con);
            con.Open();
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proid = id.ToString("00000");

            }
            else if(Convert.IsDBNull(dr))
            {
                proid = ("00001");

            }
            else
            {
                proid = ("00001");
            }

            txtregno.Text = proid.ToString();

            con.Close();


        }


        public void load()
        {

            sql = "select * from CarRegistration";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while(dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);

            }

            con.Close();

        }

        public void getid(String id)
        {
            sql = "select * from CarRegistration where RegNo =  '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                txtregno.Text = dr[0].ToString();
                txtbrand.Text = dr[1].ToString();
                txtmodel.Text = dr[2].ToString();
                txtavl.Text = dr[3].ToString();
            }

            con.Close();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                txtregno.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getid(id);
            }

            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {

                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from CarRegistration where RegNo = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted!");
                con.Close();
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarRegistration_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string regno = txtregno.Text;
            string brand = txtbrand.Text;
            string model = txtmodel.Text;
            string aval = txtavl.Text;
           
           // id = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            if (Mode == true)
            {
                sql = "insert into CarRegistration(RegNo,Brand,CarModel,Available)values(@RegNo,@Brand,@CarModel,@Available)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@RegNo", regno);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@CarModel", model);
                cmd.Parameters.AddWithValue("@Available", aval);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added.");

                txtbrand.Clear();
                txtmodel.Clear();
                txtavl.Items.Clear();
                txtbrand.Focus();
               


            }
            else
            {

                sql = "update CarRegistration set Brand= @Brand, CarModel= @CarModel , Available= @Available where RegNo = @RegNo" ;
                con.Open();
                cmd = new SqlCommand(sql, con);
                
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@CarModel", model);
                cmd.Parameters.AddWithValue("@Available", aval);
                cmd.Parameters.AddWithValue("@RegNo", regno);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated.");
                txtregno.Enabled = true;
                Mode = true;

                txtbrand.Clear();
                txtmodel.Clear();
                txtavl.Items.Clear();
                txtbrand.Focus();
              


            }

            con.Close();



        }

        private void txtrefresh_Click(object sender, EventArgs e)
        {
            load();
            Autono();
            txtbrand.Clear();
            txtmodel.Clear();
            txtavl.Items.Clear();
            txtbrand.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtavl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

