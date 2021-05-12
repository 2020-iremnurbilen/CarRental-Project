using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarRentail
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
               ReturnCar r = new ReturnCar();
            r.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarRegistration c = new CarRegistration();
            c.Show();


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Rentail r = new Rentail();
            r.Show();


        }
    }
}
