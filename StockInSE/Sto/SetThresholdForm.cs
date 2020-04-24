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

namespace StockInSE.Sto
{
    public partial class SetThresholdForm : Form
    {
        public SetThresholdForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            if (textBox1.Text!="")
            {
                Stock s = Stock.checkInventory(Convert.ToInt32(textBox1.Text));
                if (s != null)
                {
                    label6.Text = s.StockId.ToString();
                    label7.Text = s.ProductName;
                    label8.Text = s.Threshold.ToString();
                }
                else
                {
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    label9.Text = "No Stock with ID:" + textBox1.Text;
                }
            }
            else
            {
                label9.Text = "Enter valid data.";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            if(textBox2.Text!="" && label6.Text!="")
            {
                int x=Stock.setThreshold(Convert.ToInt32(label6.Text), Convert.ToInt16(textBox2.Text));
                if (x != 0)
                    label9.Text = "New Threshold for Stock ID:" + label6.Text + " is" + x;
                else
                    label9.Text = "Something went wrong.";
            }
            else
            {
                label9.Text = "Enter valid data.";
            }
        }
    }
}
