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
    public partial class VendorForm : Form
    {
        public VendorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Ven.VendorAdd va = new Ven.VendorAdd();
            va.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Ven.VendorDelete vd = new Ven.VendorDelete();
            vd.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Ven.VendorUpdate vu = new Ven.VendorUpdate();
            vu.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                label1.Text = "";
                List<Vendor> l = new List<Vendor>();
                Vendor c = Vendor.findVendor(Convert.ToInt32(textBox1.Text));
                if (c != null)
                {
                    l.Add(c);
                    dataGridView1.DataSource = l;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    label1.Text = "No Vendor found with ID:" + textBox1.Text;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            List<Vendor> l = Vendor.allVendors();
            if (l.Count > 0)
            {
                dataGridView1.DataSource = l;
            }
            else
            {
                dataGridView1.DataSource = null;
                label1.Text = "No Vendors.";
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Visible = true;
            this.Dispose();
        }

        private void VendorForm_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }
    }
}
