using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInSE.Models
{
    public class Company
    {
        [Required]
        public long CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyContact { get; set; }

        public static Company addCompany(Company c)
        {
            StockInventory db = new StockInventory();
            Company m = db.Companies.FirstOrDefault(x => x.CompanyName == c.CompanyName);
            if (m == null)
            {
                m = db.Companies.Add(c);
                db.SaveChanges();
                return m;
            }
            else
                return null;
        }

        public static Company findCompany(long id)
        {
            StockInventory db = new StockInventory();
            Company p = db.Companies.FirstOrDefault(x => x.CompanyId == id);
            return p;
        }

        public static List<Company> allCompanies()
        {
            StockInventory db = new StockInventory();
            return db.Companies.ToList();
        }

        public static bool deleteCompany(long id)
        {
            StockInventory db = new StockInventory();
            Company c = db.Companies.FirstOrDefault(x => x.CompanyId == id);
            if (c != null)
            {
                db.Companies.Remove(c);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Company updateCompany(long id, Company p)
        {
            StockInventory db = new StockInventory();
            Company c = db.Companies.FirstOrDefault(x => x.CompanyId == id);
            if (c != null)
            {
                c.CompanyName = p.CompanyName;
                c.CompanyEmail = p.CompanyEmail;
                c.CompanyContact = p.CompanyContact;
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
