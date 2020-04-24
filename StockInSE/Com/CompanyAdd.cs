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
    public partial class CompanyAdd : Form
    {
        public CompanyAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text!=null && textBox2.Text != null && textBox3.Text != null)
            {
                Company c = new Company() { CompanyName = textBox1.Text, CompanyEmail = textBox2.Text, CompanyContact = textBox3.Text};
                c=Company.addCompany(c); 
                if(c!=null)
                {
                    label5.Text = "Company added succefully with ID:" + c.CompanyId.ToString();
                }
                else
                {
                    label5.Text = "Company already exist/Something went wrong.";
                }
            }
        }

        private void CompanyAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
