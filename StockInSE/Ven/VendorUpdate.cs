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
    public partial class VendorUpdate : Form
    {
        public VendorUpdate()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox4.Text != "")
            {
                Vendor c = Vendor.findVendor(Convert.ToInt32(textBox4.Text));
                if (c != null)
                {
                    label7.Text = c.VendorId.ToString();
                    textBox1.Text = c.VendorName;
                    textBox2.Text = c.VendorEmail;
                    textBox3.Text = c.VendorContact.ToString();
                    richTextBox1.Text = c.VendorAddress;
                }
                else
                {
                    label5.Text = "Vendor doesn't exist  with ID" + textBox1.Text;
                }
            }
            else
            {
                label5.Text = "Enter valid data.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && richTextBox1.Text!="")
            {
                Vendor c = new Vendor() { VendorName = textBox1.Text, VendorEmail = textBox2.Text, VendorContact = textBox3.Text,VendorAddress=richTextBox1.Text };
                c = Vendor.updateVendor(Convert.ToInt32(label7.Text), c);
                if (c != null)
                {
                    label5.Text = "Vendor updated successfully.";
                }
                else
                {
                    label5.Text = "Something went wrong/Try again.";
                }
            }
            else
            {
                label5.Text = "Enter valid data.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
