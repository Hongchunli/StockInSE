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
    public partial class ProductUpdateForm : Form
    {
        public ProductUpdateForm()
        {
            InitializeComponent();
        }
        List<string> l;
        private void ProductUpdateForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource=Category.allCategories();
            l = new List<string>();
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (textBox1.Text!="")
            {
                Product p=Product.findProduct(Convert.ToInt32(textBox1.Text));
                if(p!=null)
                {
                    label8.Text = p.ProductId.ToString();
                    textBox3.Text = p.ProductName;
                    comboBox1.SelectedIndex=comboBox1.FindStringExact(p.Category.CategoryName);
                    richTextBox1.Text = p.Description;
                    textBox2.Text= p.size.Split()[0];
                    comboBox2.SelectedIndex = l.FindIndex(x=>x.Equals(p.size.Split()[1]));
                }
                else
                {
                    label8.Text = "";
                    textBox3.Text ="";
                    comboBox1.SelectedIndex =0;
                    richTextBox1.Text ="";
                    textBox2.Text = "";
                    label6.Text = "No Product with ID:" + textBox1.Text;
                }
            }
            else
            {
                label6.Text = "Enter valid ID.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Product p = new Product() { ProductId=Convert.ToInt32(label8.Text),ProductName = textBox3.Text, Description = richTextBox1.Text.ToLower(), size = textBox2.Text + " " + comboBox2.SelectedItem, Category = (Category)comboBox1.SelectedItem };
            p = Product.updateProduct(Convert.ToInt32(label8.Text),p);
            if (p != null)
            {
                label6.Text = "Product updated successfully.";
            }
            else
            {
                label6.Text = "Something went wrong.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
