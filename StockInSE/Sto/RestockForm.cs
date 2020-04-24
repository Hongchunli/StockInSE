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
    public partial class RestockForm : Form
    {
        public RestockForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text!="")
            {
                Stock s = Stock.checkInventory(Convert.ToInt32(textBox3.Text));
                if (s != null)
                {
                    label9.Text = s.ProductName;
                    textBox1.Text = s.shelf;
                    textBox2.Text = s.UnitPrice.ToString();
                    label11.Text = s.LastRestockedDate.ToString();
                    label12.Text = s.LastRestockedQuantity.ToString();
                    textBox6.Text = s.Threshold.ToString();
                    label14.Text = s.StockId.ToString();
                    textBox5.Text = s.Quantity.ToString();
                }
                else
                {
                    label9.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    label11.Text = "";
                    label12.Text = "";
                    textBox6.Text = "";
                    label14.Text = "";
                    textBox5.Text = "";
                    label10.Text = "No Stock found.";
                }
            }
            else
            {
                label10.Text = "Enter valid data.";
            }
            
        }

        private void RestockForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                    Stock s = new Stock() { ProductName = label9.Text, shelf = textBox1.Text, UnitPrice = Convert.ToInt32(textBox2.Text), LastRestockedDate = DateTime.Now, LastRestockedQuantity = Convert.ToInt32(textBox5.Text), Quantity = Convert.ToInt32(textBox5.Text), Threshold = Convert.ToInt32(textBox6.Text) };
                    s = Stock.Restock(Convert.ToInt32(label14.Text),s);
                    if (s != null)
                    {
                        label10.Text = "Stock Updated.";
                    }
                    else
                    {
                        label10.Text = "Something went wrong.";
                    }
                
            }
            else
            {
                label10.Text = "Enter valid data.";
            }
        }
    }
}
