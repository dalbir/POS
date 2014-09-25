using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_ConsignmentClass
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public string CustNum { get; set; }
        public int Auction_Type { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
        public string Pics { get; set; }
        public int Auction_Duration { get; set; }
        public DateTime Auction_Start { get; set; }
        public DateTime Auction_End { get; set; }
        public decimal Opening_Bid { get; set; }
        public decimal BuyItNow { get; set; }
        public decimal Selling_Price { get; set; }
        public string Buyer { get; set; }
        public decimal Handling_Fee { get; set; }
        public float Weight { get; set; }
        public string Manufacturer { get; set; }
        public string Condition { get; set; }
        public int Missing_Parts { get; set; }
        public string Missing_Parts_Itemized { get; set; }
        public string Item_Age { get; set; }
        public string Auction_ID { get; set; }
        public decimal Fees { get; set; }
        public string Tracking_Num { get; set; }
        public string Ship_Method { get; set; }
        public string Buyer_Email { get; set; }
        public int Previously_Listed { get; set; }
        public string Buyer_Name { get; set; }
        public int Paid_Online { get; set; }
        public DateTime Payment_DateTime { get; set; }
        public string Payment_Method { get; set; }
        public int Check_Sent { get; set; }
        public DateTime Check_Sent_DateTime { get; set; }
    }
}
