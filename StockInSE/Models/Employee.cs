using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInSE.Models
{
    public class Employee
    {
        [Required]
        public long EmployeeId { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public string EmployeeContact { get; set; }


        public static bool login(long eid, string pswd)
        {
            StockInventory db = new StockInventory();
            Employee e=db.Employees.FirstOrDefault(x => x.EmployeeId == eid && x.password == pswd);
            if (e != null)
                return true;
            else
                return false;
        }
    }
}
