using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_ImageClass
    {
        public int ID { get; set; }
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public int Position { get; set; }
        public string ImageLocation { get; set; }
        public DataTable dtmaxID { get; set; }
    }
}
