using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInSE.Models
{
    public class StockTransaction
    {
        [Required]
        public long StockTransactionId { get; set; }
        [Required]
        public int QuantityBefore { get; set; }
        [Required]
        public int QuantityAfter { get; set; }
        [Required]
        public string comment { get; set; }
        [Required]
        public DateTime time { get; set; }
        [Required]
        public Stock Stock { get; set; }


        public static List<StockTransaction> allStocktransactions()
        {
            StockInventory db = new StockInventory();
            return db.StockTransactions.Include("Stock").ToList();
        }

        public static StockTransaction findStocktransaction(long stockid)
        {
            StockInventory db = new StockInventory();
            return db.StockTransactions.Include("Stock").Include("Stock.Product.Category").FirstOrDefault(x=>x.Stock.StockId==stockid);
        }

        public static StockTransaction findStocktransactionByID(long id)
        {
            StockInventory db = new StockInventory();
            return db.StockTransactions.Include("Stock").Include("Stock.Product.Category").FirstOrDefault(x => x.StockTransactionId == id);
        }

        public static StockTransaction transact(long sid,int qua,string comment)
        {
            StockInventory db = new StockInventory();
            StockTransaction st = new StockTransaction();
            Stock s= db.Stocks.Include("Product.Category").FirstOrDefault(x => x.StockId == sid);
            st.Stock = s;
            st.comment = comment;
            st.time = DateTime.Now;
            st.QuantityBefore = s.Quantity;
            if(s.Quantity>=qua)
            {
                int x = Stock.deductStock(s.StockId, qua);
                if (x >= 0)
                {
                    try
                    { 
                        st.QuantityAfter = x;
                        Stock m = st.Stock;
                        long c = m.Product.ProductId;
                        st = db.StockTransactions.Add(st);
                        db.SaveChanges();
                        if (st != null)
                        {
                            return st;
                        }
                        else
                            return null;
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
                            
                        }
                        throw;
                    }
                }
            }
            return null;
        }

        public static long removeEntry(long stid)
        {
            StockInventory db = new StockInventory();
            StockTransaction st = db.StockTransactions.FirstOrDefault(x => x.StockTransactionId == stid);
            if (st != null)
            {
                db.StockTransactions.Remove(st);
                db.SaveChanges();
                return st.StockTransactionId;
            }
            else
                return 0;
        }
        public static StockTransaction returnStock(long pid,int qua,string comment)
        {
            StockInventory db = new StockInventory();
            StockTransaction st = new StockTransaction();
            Stock s=db.Stocks.Include("Product.Category").FirstOrDefault(xx => xx.Product.ProductId == pid);
            st.Stock = s;
            st.comment = comment;
            st.time = DateTime.Now;
            st.QuantityBefore = s.Quantity;
            int x = Stock.RevertStock(s.StockId, qua);
            if (x > 0)
            {
                st.QuantityAfter = x;
                st = db.StockTransactions.Add(st);
                db.SaveChanges();
                if (st != null)
                {
                    return st;
                }
                else
                    return null;
            }
            return null;
        } 
    }
}
