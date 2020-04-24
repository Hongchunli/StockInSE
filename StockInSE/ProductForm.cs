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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Pro.ProductAddForm pa = new Pro.ProductAddForm();
            pa.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (textBox1.Text!="")
            {
                Product p = Product.findProduct(Convert.ToInt32(textBox1.Text));
                
                if (p != null)
                {
                    var l2 = new
                    {
                        p.ProductId,
                        p.ProductName,
                        p.Description,
                        p.size,
                        p.Category.CategoryName,
                    };
                    dataGridView1.DataSource = l2;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    label6.Text = "No product with ID:" + textBox1.Text;

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
            List<Product> l = Product.allProducts();
            var l2= (from cat in l
                select new
                {
                   cat.ProductId,
                   cat.ProductName,
                   cat.Description,
                   cat.size,
                   cat.Category.CategoryName,
            }).ToList();
            if (l2.Count > 0)
            { 
                dataGridView1.DataSource = l2;
                //MessageBox.Show(l[0].Category.CategoryName);
            }
            else
            {
                label6.Text = "No Products.";
                dataGridView1.DataSource = null;
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Pro.ProductDeleteForm pd = new Pro.ProductDeleteForm();
            pd.Visible = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Visible = true;
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Pro.ProductUpdateForm pu = new Pro.ProductUpdateForm();
            pu.Visible = true;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
