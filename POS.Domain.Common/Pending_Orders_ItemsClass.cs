using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Pending_Orders_ItemsClass
    {
        public string Area { get; set; }
        public int Invoice_Number { get; set; }
        public string ItemName { get; set; }
        public float Quan { get; set; }
        public int IsModifier { get; set; }
        public DateTime Time_Started { get; set; }
        public string Store_ID { get; set; }
        public int LineNum { get; set; }
        public string ObjectID { get; set; }
        public string ParentObjectID { get; set; }
        public string Station_ID { get; set; }
        public string Cashier_ID { get; set; }
        public string OnHoldID { get; set; }
        public int Priority { get; set; }
        public int ForeColor { get; set; }
        public int BackColor { get; set; }
        public string ItemNum { get; set; }
        public int Progress { get; set; }
        public int PaidStatus { get; set; }
        public int OrderType { get; set; }
        public string Identifier { get; set; }
        public string TransferFromID { get; set; }
        public string TransferToID { get; set; }
    }
}
