using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class ScheduleClass
    {
        public string Cashier_ID { get; set; }
        public string Store_ID { get; set; }
        public string CustNum { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Type { get; set; }
        public decimal Tip_Amount { get; set; }
        public int NumMinutes { get; set; }
        public decimal WagesEarned { get; set; }
        public decimal WageTaxes { get; set; }
        public int Dirty { get; set; }
        public string AssignedJobCode { get; set; }
        public int RowID { get; set; }
    }
}
