using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PO_DetailsClass
    {
        public int PO_Number { get; set; }
        public string ItemNum { get; set; }
        public int LineNum { get; set; }
        public float Quan_Ordered { get; set; }
        public decimal CostPer { get; set; }
        public float Quan_Received { get; set; }
        public string Vendor_Part_Number { get; set; }
        public int CasePack { get; set; }
        public string Store_ID { get; set; }
        public string destStore_ID { get; set; }
        public float Current_Batch_Quan { get; set; }
        public float Quan_Damaged { get; set; }
        public string Reason { get; set; }
        public float NumberPerCase { get; set; }
        public int OverrideCommission { get; set; }
        public float Quan_OutofDate { get; set; }
    }
}
