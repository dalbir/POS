using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PO_SummaryClass
    {
        public int PO_Number { get; set; }
        public string Store_ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Reference { get; set; }
        public string Vendor_Number { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Total_Cost_Received { get; set; }
        public string Terms { get; set; }
        public string Due_Date { get; set; }
        public string Ship_Via { get; set; }
        public string ShipTo_1 { get; set; }
        public string ShipTo_2 { get; set; }
        public string ShipTo_3 { get; set; }
        public string ShipTo_4 { get; set; }
        public string ShipTo_5 { get; set; }
        public string Instructions { get; set; }
        public string Status { get; set; }
        public DateTime Last_Modified { get; set; }
        public int Dirty { get; set; }
        public string Cashier_ID { get; set; }
        public string Billable_Department { get; set; }
        public string ShipTo_Destination { get; set; }
        public int Ordering_Mode { get; set; }
        public int Fully_Authorized { get; set; }
        public int Print_Notes_On_PO { get; set; }
        public DateTime Cancel_Date { get; set; }
        public decimal Total_Charges { get; set; }
        public int Fully_Paid { get; set; }
        public int POType { get; set; }
        public int ExpectedAmountToReceive { get; set; }
        public string Order_Reason { get; set; }
        public string Distributor { get; set; }
    }
}
