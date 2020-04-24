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
    public partial class VendorAdd : Form
    {
        public VendorAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && richTextBox1.Text!="")
            {
                Vendor c = new Vendor() { VendorName = textBox1.Text, VendorEmail = textBox2.Text, VendorContact = textBox3.Text,VendorAddress=richTextBox1.Text };
                c = Vendor.addVendor(c);
                if (c != null)
                {
                    label5.Text = "Vendor added succefully with ID:" + c.VendorId.ToString();
                }
                else
                {
                    label5.Text = "Vendor already exist/Something went wrong.";
                }
            }
            else
            {
                label5.Text = "Enter valid data.";
            }
        }
    }
}
