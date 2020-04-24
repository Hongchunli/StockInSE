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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductForm c = new ProductForm();
            c.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CompanyForm c = new CompanyForm();
            c.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockForm c = new StockForm();
            c.Visible = true;
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OrderForm c = new OrderForm();
            c.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VendorForm c = new VendorForm();
            c.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CategoryForm c = new CategoryForm();
            c.Visible = true;
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StockTransactionForm c = new StockTransactionForm();
            c.Visible = true;
            this.Visible = false;
        }
    }
}
