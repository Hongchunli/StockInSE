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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (textBox1.Text != "")
            {
                Order cat = Order.findOrder(Convert.ToInt32(textBox1.Text));
                
                if (cat != null)
                {
                    var v = new
                    {
                        cat.OrderId,
                        cat.Stock.StockId,
                        cat.OrderDate,
                        cat.Quantity,
                        cat.Status,
                        cat.Company.CompanyName,
                        cat.Vendor.VendorName,

                    };
                    dataGridView1.DataSource = v;
                }
                else
                {
                    label6.Text = "No Order with ID:" + textBox1.Text;
                    dataGridView1.DataSource = null;
                }
                    
            }
            else
            {
                label6.Text = "Enter valid ID.";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            List<Order> l = Order.allOrders();
            if (l.Count > 0)
            {
                var l2 = (from cat in l
                          select new
                          {
                              cat.OrderId,
                              cat.Stock.StockId,
                              cat.OrderDate,
                              cat.Quantity,
                              cat.Status,
                              cat.Company.CompanyName,
                              cat.Vendor.VendorName,

                          }).ToList();
                dataGridView1.DataSource = l2;
            }
            else
            {
                dataGridView1.DataSource = null;
                label6.Text = "No Orders.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ord.PlaceOrder po = new Ord.PlaceOrder();
            po.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ord.CancelOrder co = new Ord.CancelOrder();
            co.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ord.PrintInvoice po = new Ord.PrintInvoice();
            po.Visible = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Visible = true;
            this.Dispose();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
