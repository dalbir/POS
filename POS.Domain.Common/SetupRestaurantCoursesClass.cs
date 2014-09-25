using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class SetupRestaurantCoursesClass
    {
        public int CourseID { get; set; }
        public string Store_ID { get; set; }
        public string Course { get; set; }
        public int SuggestedSelection { get; set; }
        public int ForcedSelection { get; set; }
        public int CourseOrderNumber { get; set; } 
    }
}
