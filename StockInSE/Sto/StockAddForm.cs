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
    public partial class StockAddForm : Form
    {
        public StockAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        List<Product> l;
        private void StockAddForm_Load(object sender, EventArgs e)
        {
            l = Product.allProducts();
            comboBox1.DataSource = Product.allProducts();
            textBox6.Text ="1";
            label11.Text = DateTime.Now.ToString();
            label12.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            if (textBox1.Text!="" && textBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                Product p=Product.findProduct(((Product)comboBox1.SelectedItem).ProductId);
                if(p!=null)
                {
                    Stock s = new Stock() { Product = p,ProductName=label9.Text,shelf=textBox1.Text,UnitPrice=Convert.ToInt32(textBox2.Text),LastRestockedDate=DateTime.Now,LastRestockedQuantity=Convert.ToInt32(label12.Text),Quantity=Convert.ToInt32(textBox5.Text),Threshold=Convert.ToInt32(textBox6.Text) };
                    s=Stock.addStock(s);
                    if(s!=null)
                    {
                        label10.Text = "New stock product added with ID:" + s.StockId;
                    }
                    else
                    {
                        label10.Text = "Already product in stock.";
                    }
                }
                else
                {
                    label10.Text = "Enter valid details.";
                }
            }
            else
            {
                label10.Text = "Enter valid data.";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = l.FirstOrDefault(x => x.ProductId == ((Product)comboBox1.SelectedValue).ProductId).ProductName;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label12.Text = textBox5.Text;
        }
    }
}
