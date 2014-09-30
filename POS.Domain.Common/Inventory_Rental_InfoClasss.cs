using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_Rental_InfoClasss: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public double Late_Charge { get; set; }
        public int Days_Rent { get; set; }
        public DateTime Due_Date { get; set; }
        public string Status { get; set; }
        public string CurrCust { get; set; }
        public string LastCust { get; set; }
        public int NumRentals { get; set; }
        public string Rating { get; set; }
        public string Actor_Last_Name { get; set; }
        public string Actress_Last_Name { get; set; }
        public string Inv_Approval_Code { get; set; }
        public int Primary { get; set; }
        public string RowID { get; set; }
        public int Invoice_Number { get; set; } 

       //
        public string quryFlage { get; set; }
    }
}
