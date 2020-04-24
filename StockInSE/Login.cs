using StockInSE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockInSE
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!=null)
            {
                if(Employee.login(Convert.ToInt32(textBox1.Text),textBox2.Text))
                {
                    Home h = new Home();
                    h.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    label3.Text = "Invalid ID/Password.";
                }
            }
            else
            {
                label3.Text = "Enter valid ID/Password.";
            }
        }
    }
}
