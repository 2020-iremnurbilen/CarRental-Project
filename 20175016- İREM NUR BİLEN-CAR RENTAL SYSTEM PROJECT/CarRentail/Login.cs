using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRentail
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            string uname = txtuname.Text;
            string pass = txtpass.Text;


            if (uname.Equals("Admin") && pass.Equals("123"))
           {

                Main m = new Main();
                this.Hide();
                m.Show();
            }


            else
            {

                MessageBox.Show("Username or password do not match!");

            txtuname.Clear();
            txtpass.Clear();
            txtuname.Focus();

        }
    }

        


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          

        }

        private void role_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
