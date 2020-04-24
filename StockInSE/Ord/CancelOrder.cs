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

namespace StockInSE.Ord
{
    public partial class CancelOrder : Form
    {
        public CancelOrder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label17.Text = "";
            if (textBox1.Text!=null)
            {
                Order o = Order.findOrder(Convert.ToInt32(textBox1.Text));
                Stock s = o.Stock;
                if(o!=null)
                {
                    label22.Text = o.OrderId.ToString();
                    label24.Text = o.OrderDate.ToString();
                    label11.Text = s.Product.ProductId.ToString();
                    label12.Text = s.ProductName;
                    label13.Text = s.Quantity.ToString();
                    label14.Text = s.Threshold.ToString();
                    label15.Text = s.LastRestockedDate.ToString();
                    label16.Text = s.LastRestockedQuantity.ToString();
                    label18.Text = o.Vendor.VendorName;
                    label19.Text = o.Company.CompanyName;
                    label20.Text = o.Quantity.ToString();
                }
                else
                {
                    label22.Text = "";
                    label24.Text = "";
                    label11.Text = "";
                    label12.Text = "";
                    label13.Text = "";
                    label14.Text = "";
                    label15.Text = "";
                    label16.Text = "";
                    label18.Text = "";
                    label19.Text = "";
                    label20.Text = "";
                    label17.Text = "No order found with ID:"+textBox1.Text;
                }
            }
            else
            {
                label17.Text = "Invalid ID.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label17.Text = "";
            if (label22.Text!="")
            {
                if(Order.cancelOrder(Convert.ToInt32(label22.Text)))
                {
                    label17.Text = "Order cancelled.";
                }
                else
                {
                    label17.Text = "Something went wrong.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CancelOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
