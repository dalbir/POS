using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class EmployeeJobCodeClass: BaseDomain
    {
        public string Cashier_ID   {get; set; }
        public string JobCodeID   {get; set; }
        public double Hourly_Wage  {get; set; }
        public double OvertimeHourly_Wage  {get; set; }
    }
}
