using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInSE.Models
{
    public class Vendor
    {
        [Required]
        public long VendorId { get; set; }
        [Required]
        public string VendorName { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public string VendorAddress { get; set; }
        [Required]
        public string VendorEmail { get; set; }
        [Required]
        public string VendorContact { get; set; }

        public static Vendor addVendor(Vendor c)
        {
            StockInventory db = new StockInventory();
            Vendor m = db.Vendors.FirstOrDefault(x => x.VendorName == c.VendorName);
            if (m == null)
            {
                m = db.Vendors.Add(c);
                db.SaveChanges();
                return m;
            }
            else
                return null;
        }

        public static Vendor findVendor(long id)
        {
            StockInventory db = new StockInventory();
            Vendor p = db.Vendors.FirstOrDefault(x => x.VendorId == id);
            return p;
        }

        public static List<Vendor> allVendors()
        {
            StockInventory db = new StockInventory();
            return db.Vendors.ToList();
        }

        public static bool deleteVendor(long id)
        {
            StockInventory db = new StockInventory();
            Vendor c = db.Vendors.FirstOrDefault(x => x.VendorId == id);
            if (c != null)
            {
                db.Vendors.Remove(c);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Vendor updateVendor(long id, Vendor p)
        {
            StockInventory db = new StockInventory();
            Vendor c = db.Vendors.FirstOrDefault(x => x.VendorId == id);
            if (c != null)
            {
                c.VendorName = p.VendorName;
                c.VendorEmail = p.VendorEmail;
                c.VendorAddress = p.VendorAddress;
                c.VendorContact = p.VendorContact;
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
