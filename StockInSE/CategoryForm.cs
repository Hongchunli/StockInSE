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

namespace StockInSE
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Cat.CategoryAddForm ca = new Cat.CategoryAddForm();
            ca.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Cat.CategoryDeleteForm cd = new Cat.CategoryDeleteForm();
            cd.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            Cat.CategoryUpdateForm cu = new Cat.CategoryUpdateForm();
            cu.Visible = true;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            if (textBox3.Text != "")
            {
                Category c = Category.findCategory(Convert.ToInt32(textBox3.Text));
                if (c != null)
                {
                    List<Category> l = new List<Category>();
                    l.Add(c);
                    dataGridView1.DataSource = l;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    label6.Text = "No categories.";
                }
            }
            else
            {
                label6.Text = "Enter valid ID.";
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            label6.Text = "";
            List<Category> l= Category.allCategories();
            if (l.Count > 0)
                dataGridView1.DataSource = l;
            else
            {
                dataGridView1.DataSource = null;
                label6.Text = "No Categories.";
            }
                


        }

        private void back_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Visible = true;
            this.Dispose();
        }
    }
}
