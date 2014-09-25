using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class DepartmentClass
    {
        public string Dept_ID   {get; set; }
        public string Store_ID   {get; set; }
        public string Description   {get; set; }
        public int Type  {get; set; }
        public int TSDisplay  {get; set; }
        public string Cost_MarkUp  {get; set; } 
        public int Dirty  {get; set; } 
        public string SubType   {get; set; }
        public int Print_Dept_Notes  {get; set; } 
        public string Dept_Notes{get; set; } 
        public int Require_Permission  {get; set; }
        public int Require_Serials  {get; set; } 
        public int BarTaxInclusive  {get; set; } 
        public string Cost_Calculation_Percentage  {get; set; } 
        public int Square_Footage {get; set; } 
        public int AvailableOnline  {get; set; } 
        public int IncludeInScaleExport  {get; set; } 
    }
}
