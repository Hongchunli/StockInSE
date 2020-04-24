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
    public partial class CategoryAddForm : Form
    {
        public CategoryAddForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            Category c = new Category();
            c.CategoryName = textBox1.Text;
            c = Category.addCategory(c);
            if (c == null)
                label2.Text = "Category Already present";
            else
                label2.Text = "Successfully added with CategoryID:" + c.CategoryId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CategoryAddForm_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }
        
    }
}
