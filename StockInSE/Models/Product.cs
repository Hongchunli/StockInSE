using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockInSE.Models
{
    public class Product
    {  

        [Required]
        public long ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public Category Category { get; set; }
        
        public static Product addProduct(Product p)
        {
            StockInventory db = new StockInventory();
            Category c = db.Categories.FirstOrDefault(x => x.CategoryName == p.Category.CategoryName);
            p.Category = c;
            Product m = db.Products.FirstOrDefault(x => x.ProductName == p.ProductName);
            if (m == null)
            {
                m = db.Products.Add(p);
                db.SaveChanges();
                return m;
            }
            else
                return null;
        }

        public static Product findProduct(long id)
        {
            StockInventory db = new StockInventory();
            Product p = db.Products.Include("Category").FirstOrDefault(x => x.ProductId == id);
            return p;
        }

        public static List<Product> allProducts()
        {
            StockInventory db = new StockInventory();
            return db.Products.Include("Category").ToList();
        }

        public static bool deleteProduct(long id)
        {
            StockInventory db = new StockInventory();
            Product c = db.Products.FirstOrDefault(x => x.ProductId == id);
            if (c != null)
            {
                db.Products.Remove(c);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Product updateProduct(long id, Product p)
        {
            StockInventory db = new StockInventory();
            Product c = db.Products.FirstOrDefault(x => x.ProductId == id);
            if(c!=null)
            {
                c.ProductName = p.ProductName;
                c.Category = db.Categories.FirstOrDefault(x => x.CategoryName == p.Category.CategoryName);
                c.Description = p.Description;
                c.size = p.size;
                db.SaveChanges();
                return c;
            }
            else
            {
                return null;
            }
        }
    }
}
