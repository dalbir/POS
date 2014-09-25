using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PO_Details_StoreListingClass
    {
        public int PO_Number { get; set; }
        public string Store_ID { get; set; }
        public int LineNum { get; set; }
        public string destStore_ID { get; set; }
        public decimal Quan_Ordered { get; set; }
        public decimal Quan_Received { get; set; }
        public int CasePack { get; set; }
        public decimal Quan_Damaged { get; set; }
        public decimal Current_Batch_Quan { get; set; }
        public float Quan_OutofDate { get; set; }
    }
}
