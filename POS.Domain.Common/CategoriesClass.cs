using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class CategoriesClass: BaseDomain
    {
        public string Cat_ID { get; set; }
        public string Store_ID { get; set; }
        public string Description { get; set; }
        public string flage { get; set; }
        public DataTable loadCategory { get; set; }
        public DataTable loadCategorydt { get; set; }
    }
}
