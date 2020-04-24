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

namespace StockInSE.ST
{
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
        Stock s;
        private void button2_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            if (textBox1.Text != null)
            {
                s = Stock.checkInventory(Convert.ToInt32(textBox1.Text));
                if (s != null)
                {
                    label8.Text = s.StockId.ToString();
                    label9.Text = s.ProductName;
                }
                else
                {
                    label8.Text = "";
                    label9.Text = "";
                    label13.Text = "No Stock found.";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            if (s != null && label8.Text != "" && textBox2.Text != "" && richTextBox1.Text != "")
            {

                Stock m = Stock.checkInventory(s.Product.ProductId);
                if (m == null)
                {
                    label13.Text = label8.Text;
                }
                else
                {
                    StockTransaction st = StockTransaction.returnStock(Convert.ToInt32(textBox1.Text), Convert.ToInt16(textBox2.Text), richTextBox1.Text);
                    label13.Text = "Transaction successful. Remaining Quantity:" + st.QuantityAfter;
                }
            }
            else
            {
                label13.Text = "Enter valid Quantity.";
            }
        }
    }
}
