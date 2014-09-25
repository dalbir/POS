using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PackagesClass
    {
        public int RowID { get; set; }
        public string ParentRowID { get; set; }
        public string Weight { get; set; }
        public decimal PackageValue { get; set; }
        public string Carrier { get; set; }
        public string ShipMethod { get; set; }
        public decimal ShipCost { get; set; }
        public decimal InsuredValue { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime EstimatedDate { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
        public string Store_ID { get; set; }
    }
}
