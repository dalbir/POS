using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
    class Inventory_Transfers_InClass
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public string Quantity { get; set; }
        public decimal CostPer { get; set; }
        public DateTime DateTime { get; set; }
        public string Vendor_Number { get; set; }
        public int Dirty { get; set; }
        public string TransType { get; set; }
        public string Originator { get; set; }
        public string Description { get; set; }
        public string Cashier_ID { get; set; }
        public int PO_Number { get; set; }
        public string Delivery_Number { get; set; }
        public string Trans_ID { get; set; }
        public string Description2 { get; set; }
    }
}
