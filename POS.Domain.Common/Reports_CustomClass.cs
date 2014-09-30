using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Reports_CustomClass
    {
        public int Special { get; set; }
        public string Store_ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Report_Type { get; set; }
        public string Author { get; set; }
        public DateTime Create_Date { get; set; }
        public string Report_Definition { get; set; }
        public int SuppressZeros { get; set; }
        public int PrintCompanyHeader { get; set; }
        public int PrintCompanyHeaderAllPages { get; set; }
        public int PrintSubTotalsEveryPage { get; set; }
        public int PrintSubTotalsEveryGroup { get; set; }
        public int PrintLandscape { get; set; }
        public string GUIDident { get; set; }
    }
}
