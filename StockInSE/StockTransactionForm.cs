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
    public partial class StockTransactionForm : Form
    {
        public StockTransactionForm()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Visible = true;
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            StockTransaction s =StockTransaction.findStocktransaction(Convert.ToInt32(textBox1.Text));
            List<StockTransaction> l = new List<StockTransaction>();
            l.Add(s);
            var l2 = (from cat in l
                      select new
                      {
                          cat.StockTransactionId,
                          cat.Stock.StockId,
                          cat.Stock.ProductName,
                          cat.QuantityAfter,
                          cat.QuantityBefore,
                          cat.time,
                          cat.comment,
                      }).ToList();
            if (l.Count > 0)
                dataGridView1.DataSource = l2;
            else
                label6.Text = "No transaction for ID:" + textBox1.Text+"/Invalid ID.";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            List<StockTransaction> l  = StockTransaction.allStocktransactions();

            if (l.Count > 0)
            {
                var l2 = (from cat in l
                          select new
                          {
                              cat.StockTransactionId,
                              cat.Stock.StockId,
                              cat.Stock.ProductName,
                              cat.QuantityAfter,
                              cat.QuantityBefore,
                              cat.time,
                              cat.comment,
                          }).ToList();
                dataGridView1.DataSource = l2;
            }
            else
            {
                dataGridView1.DataSource = null;
                label6.Text = "No transactions / Invalid ID.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            ST.Transact t = new ST.Transact();
            t.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            ST.Return rt = new ST.Return();
            rt.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            ST.RemoveEntry re = new ST.RemoveEntry();
            re.Visible = true;
        }

        private void StockTransactionForm_Load(object sender, EventArgs e)
        {
            label6.Text = "";
        }
    }
}
