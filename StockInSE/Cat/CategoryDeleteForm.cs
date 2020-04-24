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

namespace StockInSE.Cat
{
    public partial class CategoryDeleteForm : Form
    {
        public CategoryDeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            Category c = Category.findCategory(Convert.ToInt32(textBox2.Text));
            if (c != null)
            {
                label2.Text = c.CategoryId.ToString();
                label6.Text = c.CategoryName.ToString();
            }
            else
            {
                label4.Text = "Invalid Category ID.";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            if (label2.Text != null)
            {
                if (Category.deleteCategory(Convert.ToInt32(label2.Text)))
                {
                    label4.Text = "Deleted successfully.(" + label2.Text + ")";
                }
                else
                {
                    label4.Text = "Invalid Category ID.";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CategoryDeleteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
