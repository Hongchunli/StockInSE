using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockInSE.Models
{
    public class Stock
    {
        [Required]
        public long StockId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [StringLength(maximumLength:3)]//Eg:B22,A11
        public string shelf { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public DateTime LastRestockedDate { get; set; }
        [Required]
        public int LastRestockedQuantity { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Threshold { get; set; } 
        [Required]
        public Product Product { get; set; }

        public static int setThreshold(long id,int limit)
        {
            StockInventory db = new StockInventory();
            Stock s=db.Stocks.Include(x => x.Product.Category).FirstOrDefault(x => x.StockId == id);
            if(s!=null && limit!=0)
            {
                s.Threshold = limit;
                db.SaveChanges();
                return s.Threshold;
            }
            else
            {
                return 0;
            }
        }
        public static Stock addStock(Stock s)
        {
            StockInventory db = new StockInventory();
            Product a = db.Products.FirstOrDefault(x => x.ProductName == s.ProductName);
            Stock p = db.Stocks.Include(x => x.Product.Category).FirstOrDefault(x => x.ProductName == s.ProductName);
            if(p==null && a!=null)
            {
                s.Product = a;
                p=db.Stocks.Add(s);
                db.SaveChanges();
                return p;
            }
            else
            {
                return null;
            }
        }
        public static int deductStock(long id,int qua)
        {
            StockInventory db = new StockInventory();
            Stock p = db.Stocks.Include(x=>x.Product.Category).FirstOrDefault(x => x.StockId == id);
            if (p != null && p.Quantity >= qua)
            {
                try
                { 
                    p.Quantity = p.Quantity - qua;
                    if (p.Quantity <= p.Threshold)
                    {
                        //sendAlert(p);
                    }
                    db.SaveChanges();
                    return p.Quantity;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                        Debug.WriteLine("- Property: \"{0}\"",p.Product.ProductName);
                    }
                    throw;
                }
            }
            else
            {
                return 0;
            }
        }

        public static Stock checkInventory(long productid)
        {
            StockInventory db = new StockInventory();
            Stock c=db.Stocks.Include(x => x.Product.Category).FirstOrDefault(x=>x.Product.ProductId==productid);
            if(c!=null)
            {
                return c;
            }
            else
            {
                return null;
            }
        }

        public static Stock checkInventoryByStock(long id)
        {
            StockInventory db = new StockInventory();
            Stock c = db.Stocks.Include(x => x.Product.Category).FirstOrDefault(x => x.StockId == id);
            if (c != null)
            {
                return c;
            }
            else
            {
                return null;
            }
        }


        public static List<Stock> checkInventory()
        {
            StockInventory db = new StockInventory();
            return db.Stocks.Include(x => x.Product.Category).ToList();
        }


        public static bool sendAlert(Stock s)
        {
            StockInventory db = new StockInventory();
            Stock y = db.Stocks.Include(x => x.Product.Category).FirstOrDefault(x => x.StockId == s.StockId);
            y.Quantity = y.LastRestockedQuantity;
            db.SaveChanges();
            return true;
        }
        public static int RevertStock(long id,int qua)
        {
            StockInventory db = new StockInventory();
            Stock p = db.Stocks.Include(x => x.Product.Category).FirstOrDefault(x => x.StockId == id);
            if (p != null)
            {
                p.Quantity = p.Quantity + qua;
                db.SaveChanges();
                return p.Quantity;
            }
            else
            {
                return 0;
            }
        } 
        public static Stock Restock(long id,Stock s)
        {
            StockInventory db = new StockInventory();
            Product a = db.Products.FirstOrDefault(x => x.ProductName == s.ProductName);
            Stock p = db.Stocks.FirstOrDefault(x => x.StockId == id);
            if (p != null && a!=null)
            {
                p.shelf = s.shelf;
                p.Threshold = s.Threshold;
                p.LastRestockedDate = s.LastRestockedDate;
                p.LastRestockedQuantity = s.LastRestockedQuantity;
                p.Quantity = s.Quantity;
                p.UnitPrice = s.UnitPrice;
                db.SaveChanges();
                return p;
            }
            else
            {
                return null;
            }
        } 
    }
}
