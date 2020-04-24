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

namespace StockInSE.Ven
{
    public partial class VendorDelete : Form
    {
        public VendorDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            if (textBox1.Text != "")
            {
                Vendor c = Vendor.findVendor(Convert.ToInt32(textBox1.Text));
                if (c != null)
                {
                    label9.Text = c.VendorId.ToString();
                    label4.Text = c.VendorName;
                    label5.Text = c.VendorEmail;
                    label6.Text = c.VendorContact.ToString();
                    label12.Text = c.VendorAddress;
                }
                else
                {
                    label9.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label12.Text = "";
                    label8.Text = "Vendor doesn't exist  with ID" + textBox1.Text;
                }
            }
            else
            {
                label8.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            if (label9.Text != "")
            {
                if (Vendor.deleteVendor(Convert.ToInt32(label9.Text)))
                {
                    label8.Text = "Vendor deleted successfully.";
                }
                else
                {
                    label8.Text = "Something went wrong.";
                }
            }
            else
            {
                label8.Text = "Invalid Vendor ID.";
            }
        }
    }
}
