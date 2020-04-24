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
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Home j = new Home();
            j.Visible = true;
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            if (textBox1.Text!="")
            {
                List<Company> l = new List<Company>();
                Company c = Company.findCompany(Convert.ToInt32(textBox1.Text));
                if(c!=null)
                {
                    l.Add(c);
                    dataGridView1.DataSource = l;
                }
                else
                {
                    dataGridView1.DataSource =null;
                    label1.Text = "No Company found with ID:" + textBox1.Text;
                }
            }
            else
            {
                label1.Text = "Enter valid data.";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            List<Company> l = Company.allCompanies();
            if (l.Count>0)
            {
                dataGridView1.DataSource = l;
            }
            else
            {
                dataGridView1.DataSource = l;
                label1.Text = "No Companies.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Com.CompanyAdd ac = new Com.CompanyAdd();
            ac.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Com.CompanyDelete  dc= new Com.CompanyDelete();
            dc.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Com.CompanyEdit cu = new Com.CompanyEdit();
            cu.Visible = true;
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
