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
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Sto.StockAddForm sa = new Sto.StockAddForm();
            sa.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            List<Stock> l= Stock.checkInventory();
            if (l.Count > 0)
            {
                var l2 = (from cat in l
                          select new
                          {
                              cat.StockId,
                              cat.Product.ProductId,
                              cat.ProductName,
                              cat.LastRestockedDate,
                              cat.LastRestockedQuantity,
                              cat.Quantity,
                              cat.shelf,
                              cat.UnitPrice,

                          }).ToList();
                dataGridView1.DataSource = l2;

            }
            else
            {
                label6.Text = "No Stocks.";
                dataGridView1.DataSource = null;
            }
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Stock l = Stock.checkInventory(Convert.ToInt32(textBox1.Text));
            List<Stock> li = new List<Stock>();
            li.Add(l);
            if (l != null)
            {
                var l2 = (from cat in li
                          select new
                          {
                              cat.StockId,
                              cat.Product.ProductId,
                              cat.ProductName,
                              cat.LastRestockedDate,
                              cat.LastRestockedQuantity,
                              cat.Quantity,
                              cat.shelf,
                              cat.UnitPrice,

                          }).ToList();
                dataGridView1.DataSource = l2;
            }
            else
            {
                dataGridView1.DataSource = null;
                label6.Text = "No Stocks.";
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Visible = true;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Sto.RestockForm rs = new Sto.RestockForm();
            rs.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Sto.SetThresholdForm st = new Sto.SetThresholdForm();
            st.Visible = true;
        }

        private void StockForm_Load(object sender, EventArgs e)
        {

        }
    }
}
