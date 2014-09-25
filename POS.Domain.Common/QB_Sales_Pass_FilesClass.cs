using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class QB_Sales_Pass_FilesClass
    {
        public DateTime QB_Sales_Todays_Date { get; set; }
        public string QB_Sales_FileName { get; set; }
        public int QB_Sales_FIleCounter { get; set; }
        public string Store_ID { get; set; }
        public decimal QB_Sales_Undeposited_Funds { get; set; }
        public decimal QB_Sales_Income { get; set; }
        public decimal QB_Sales_Tax { get; set; }
        public decimal QB_Sales_COGS { get; set; }
        public decimal QB_Sales_Inventory { get; set; }
        public decimal QB_Sales_Tax2 { get; set; }
        public decimal QB_Sales_Tax3 { get; set; }
        public DateTime QB_Sales_Todays_Date_New { get; set; }
    }
}
