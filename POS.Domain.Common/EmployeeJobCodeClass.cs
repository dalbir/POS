using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class EmployeeJobCodeClass
    {
        public string Cashier_ID   {get; set; }
        public string JobCodeID   {get; set; }
        public decimal Hourly_Wage  {get; set; }
        public decimal OvertimeHourly_Wage  {get; set; }
    }
}
