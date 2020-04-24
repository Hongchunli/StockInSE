using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInSE.Models
{
    public class Category
    {
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        
        public static List<Category> allCategories()
        {
            StockInventory db = new StockInventory();
            List<Category> l = db.Categories.ToList();
            return l;
        }
        public static Category findCategory(long id)
        {
            StockInventory db = new StockInventory();
            Category c = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            return c;
        }
        public static Category addCategory(Category c)
        {
            StockInventory db = new StockInventory();
            Category m = db.Categories.FirstOrDefault(x => x.CategoryName == c.CategoryName);
            if (m == null)
            {
                m = db.Categories.Add(c);
                db.SaveChanges();
                return m;
            }
            else
                return null;
        }

        public static bool deleteCategory(long id)
        {
            StockInventory db = new StockInventory();
            Category c = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (c != null)
            {
                db.Categories.Remove(c);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Category updateCategory(long id, string categoryName)
        {
            StockInventory db = new StockInventory();
            Category c = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (c != null)
            {
                c.CategoryName = categoryName;
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
