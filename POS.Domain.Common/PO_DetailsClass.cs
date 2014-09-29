using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class PO_DetailsClass: BaseDomain
    {
        public int PO_Number { get; set; }
        public string ItemNum { get; set; }
        public int LineNum { get; set; }
        public decimal Quan_Ordered { get; set; }
        public double CostPer { get; set; }
        public decimal Quan_Received { get; set; }
        public string Vendor_Part_Number { get; set; }
        public int CasePack { get; set; }
        public string Store_ID { get; set; }
        public string destStore_ID { get; set; }
        public double Current_Batch_Quan { get; set; }
        public decimal Quan_Damaged { get; set; }
        public string Reason { get; set; }
        public decimal NumberPerCase { get; set; }
        public int OverrideCommission { get; set; }
        public double Quan_OutofDate { get; set; }
    }
}
