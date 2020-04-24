using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockInSE.Models;

namespace StockInSE.Cat
{
    public partial class CategoryUpdateForm : Form
    {
        public CategoryUpdateForm()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            Category c = Category.findCategory(Convert.ToInt32(textBox4.Text));
            if (c != null)
            {
                label10.Text = c.CategoryId.ToString();
                textBox5.Text = c.CategoryName;
            }
            else
            {
                label10.Text = "";
                textBox5.Text = "";
                label8.Text = "Invalid Category ID.";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            if (label10.Text != null && textBox5.Text != null)
            {
                Category c = Category.updateCategory(Convert.ToInt32(label10.Text), textBox5.Text);
                if (c != null)
                {
                    label8.Text = "Updated succussfully.";
                }
                else
                {
                    label8.Text = "Something went wrong.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CategoryUpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
