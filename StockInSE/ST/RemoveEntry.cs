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
    public partial class RemoveEntry : Form
    {
        public RemoveEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            StockTransaction st=StockTransaction.findStocktransactionByID(Convert.ToInt32(textBox1.Text));
            if(st!=null)
            {
                label7.Text = st.Stock.StockId.ToString();
                label8.Text = st.Stock.ProductName;
                label9.Text = st.time.ToString();
                label10.Text = st.comment;
                label11.Text = (st.QuantityAfter - st.QuantityBefore).ToString();
            }
            else
            {
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
                label10.Text = "";
                label11.Text ="";
                label2.Text = "No Transaction with ID:" + textBox1.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            if (textBox1.Text!="")
            {
                long x = StockTransaction.removeEntry(Convert.ToInt32(textBox1.Text));
                if(x>0)
                {
                    label2.Text = "Transaction deleted with ID:" + x;
                }
                else
                    label2.Text = "Something went wrong.";
            }
            else
            {
                label2.Text = "Something went wrong.";
            }
        }

        private void RemoveEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
