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
    public partial class CompanyDelete : Form
    {
        public CompanyDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            if (textBox1.Text!="")
            {
                Company c = Company.findCompany(Convert.ToInt32(textBox1.Text));
                if(c!=null)
                {
                    label9.Text = c.CompanyId.ToString();
                    label4.Text = c.CompanyName;
                    label5.Text = c.CompanyEmail;
                    label6.Text = c.CompanyContact.ToString();
                }
                else
                {
                    label9.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text ="";
                    label8.Text = "Company doesn't exist  with ID"+textBox1.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            if (label9.Text!="")
            {
                if(Company.deleteCompany(Convert.ToInt32(label9.Text)))
                {
                    label8.Text = "Company deleted successfully.";
                }
                else
                {
                    label8.Text = "Something went wrong.";
                }
            }
            else
            {
                label8.Text = "Invalid Company ID.";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CompanyDelete_Load(object sender, EventArgs e)
        {

        }
    }
}
