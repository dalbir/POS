using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;
using System.Data;

namespace POS.Domain.Common
{
   public class GroupsClass: BaseDomain
    {
        public string Group_ID { get; set; }
        public string Store_ID { get; set; }
        public string Description { get; set; }
        public string ItemNumPrefix { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Tax_1 { get; set; }
        public int Tax_2 { get; set; }
        public int Tax_3 { get; set; }
        public string Dim_1_Name { get; set; }
        public string Dim_2_Name { get; set; }
        public string Dept_ID { get; set; }
        public string Vendor_Number { get; set; }
        public int AutoGenerate { get; set; }
        public int isDeleted { get; set; }

        //Updated
        public string flage { get; set; }
        public DataTable LoadGroupData { get; set; }
    }
}
