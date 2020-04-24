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

namespace StockInSE.Pro
{
    public partial class ProductDeleteForm : Form
    {
        public ProductDeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            if (textBox2.Text!="")
            {
                Product p = Product.findProduct(Convert.ToInt32(textBox2.Text));
                if(p!=null)
                {
                    label2.Text = p.ProductId.ToString();
                    label6.Text = p.ProductName;
                    label8.Text = p.Description;
                    label10.Text = p.Category.CategoryName;
                    label12.Text = p.size;
                }
                else
                {
                    label2.Text = "";
                    label6.Text = "";
                    label8.Text = "";
                    label10.Text = "";
                    label12.Text ="";
                    label4.Text = "No product.";
                }
            }
            else
            {
                label4.Text = "Enter valid ID.";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            if (label2.Text!="")
            {
                if (Product.deleteProduct(Convert.ToInt32(label2.Text)))
                    label4.Text = "Product deleted with ID:" + label2.Text;
                else
                    label4.Text = "Something went wrong.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ProductDeleteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
