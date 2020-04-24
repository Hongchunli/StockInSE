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
    public partial class ProductAddForm : Form
    {
        public ProductAddForm()
        {
            InitializeComponent();
        }

        private void ProductAddForm_Load(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            l.Add("MM");
            l.Add("CM");
            l.Add("M");
            l.Add("ML");
            l.Add("L");
            l.Add("MG");
            l.Add("KG");
            l.Add("Watt");
            l.Add("Other");
            comboBox2.DataSource = l;
            comboBox1.DataSource = Category.allCategories();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (textBox2.Text!=null && textBox3.Text != null)
            {
                
                Product p = new Product() { ProductName = textBox3.Text, Description = richTextBox1.Text.ToLower(), size = textBox2.Text +" "+comboBox2.SelectedItem,Category=(Category)comboBox1.SelectedItem };
                p=Product.addProduct(p);
                if(p!=null)
                {
                    label6.Text = "Product added successfully with ID:" + p.ProductId;
                }
                else
                {
                    label6.Text = "Product name exist.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            this.Dispose();
        }
    }
}
