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
    public partial class PlaceOrder : Form
    {
        public PlaceOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label17.Text = "";
            if (textBox1.Text!="")
            {
                List<Vendor> l1 = Vendor.allVendors();
                List<Company> l2 = Company.allCompanies();
                Stock s = Stock.checkInventoryByStock(Convert.ToInt32(textBox1.Text));
                if(s!=null)
                {
                    label11.Text =s.Product.ProductId.ToString();
                    label12.Text =s.ProductName;
                    label13.Text =s.Quantity.ToString();
                    label14.Text =s.Threshold.ToString();
                    label15.Text =s.LastRestockedDate.ToString();
                    label16.Text =s.LastRestockedQuantity.ToString();
                    comboBox1.DataSource = l1;
                    comboBox2.DataSource = l2;
                }
                else
                {
                    label11.Text = "";
                    label12.Text = "";
                    label13.Text = "";
                    label14.Text = "";
                    label15.Text = "";
                    label16.Text = "";
                    label17.Text = "No Stock found. Please check whether for Stock Entry with ID:" + textBox1.Text;
                }
            }
            else
            {
                label17.Text = "Enter valid ID.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label17.Text = "";
            if (label11.Text!=null && textBox2.Text!=null)
            {
                Stock s=Stock.checkInventory(Convert.ToInt32(label11.Text));
                Order o = Order.placeOrder(s, Convert.ToInt16(textBox2.Text), (Vendor)comboBox1.SelectedItem, (Company)comboBox2.SelectedItem);
                if(o!=null)
                {
                    label17.Text = "Order successfully placed with ID:" + o.OrderId.ToString();
                }
                else
                {
                    label17.Text = "Something went wrong.";
                }
            }
            else
            {
                label17.Text = "Enter valid data.";
            }
        }

        private void PlaceOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
