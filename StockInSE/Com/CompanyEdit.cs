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

namespace StockInSE.Com
{
    public partial class CompanyEdit : Form
    {
        public CompanyEdit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox4.Text != "")
            {
                Company c = Company.findCompany(Convert.ToInt32(textBox4.Text));
                if (c != null)
                {
                    label7.Text = c.CompanyId.ToString();
                    textBox1.Text = c.CompanyName;
                    textBox2.Text = c.CompanyEmail;
                    textBox3.Text = c.CompanyContact.ToString();
                }
                else
                {
                    label7.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    label5.Text = "Company doesn't exist  with ID" + textBox1.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
            {
                Company c = new Company() {CompanyName = textBox1.Text, CompanyEmail = textBox2.Text, CompanyContact =textBox3.Text };
                c = Company.updateCompany(Convert.ToInt32(label7.Text), c);
                if (c != null)
                {
                    label5.Text = "Company updated successfully.";
                }
                else
                {
                    label5.Text = "Something went wrong/Try again.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CompanyEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
