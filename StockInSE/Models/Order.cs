using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInSE.Models
{
    public class Order
    {
        [Required]
        public long OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public Stock Stock { get; set; }
        [Required]
        public Company Company { get; set; }
        [Required]
        public Vendor Vendor { get; set; }


        public static Order findOrder(long v)
        {
            StockInventory db = new StockInventory();
            Order o = db.Orders.Include(x => x.Stock).Include(x=>x.Stock.Product).Include(x => x.Vendor).Include(x => x.Company).FirstOrDefault(x => x.OrderId == v);
            if (o != null)
                return o;
            else
                return null;
        }

        public static List<Order> allOrders()
        {
            StockInventory db = new StockInventory();
            return db.Orders.Include(x=>x.Stock).Include(x=>x.Vendor).Include(x => x.Company).ToList();
        }
        
        public static Order printInvoice(long id)
        {
            StockInventory db = new StockInventory();
            Order o=db.Orders.FirstOrDefault(x => x.OrderId == id);
            if (o != null)
            {
                return o;
            }
            else
            {
                return null;
            }
        }
        public static Order placeOrder(Stock p, int qua,Vendor v,Company c)
        {
            StockInventory db = new StockInventory();
            Stock a = db.Stocks.Include("Product").FirstOrDefault(x => x.Product.ProductId == p.Product.ProductId);
            Company m = Company.findCompany(c.CompanyId);
            Vendor n = Vendor.findVendor(v.VendorId);
            Order o=new Order { Stock=a,Quantity = qua, Vendor = n, Company = m, OrderDate = DateTime.Now,Status="confirmed" };
            o = db.Orders.Add(o);
            if (a!=null && o!=null)
            {
                a.Quantity = a.Quantity + qua;
                a.LastRestockedQuantity = a.Quantity;
                db.SaveChanges();
                return o;
            }
            else
            {
                return null;
            }
            
        }
        public static bool cancelOrder(long id)
        {
            StockInventory db = new StockInventory();
            Order o=db.Orders.Include(x=>x.Stock).FirstOrDefault(x => x.OrderId == id);
            Stock a = db.Stocks.Include("Product").FirstOrDefault(x => x.StockId == o.Stock.StockId);
            if (o!=null)
            {
                if((a.Quantity - o.Quantity)>=0)
                {
                    a.Quantity = a.Quantity - o.Quantity;
                    a.LastRestockedQuantity = a.Quantity;
                    db.Orders.Remove(o);
                    db.SaveChanges();
                    return true;
                }
                return false;
                
            }
            else
            {
                return false;
            }
        }
        public static Order showOrder(long id)
        {
            StockInventory db = new StockInventory();
            Order o = db.Orders.FirstOrDefault(x => x.OrderId == id);
            if(o!=null)
            {
                return o;
            }
            else
            {
                return null;
            }
        }
        public static List<Order> showOrders()
        {
            StockInventory db = new StockInventory();
            return db.Orders.ToList();
        }
    }
}
