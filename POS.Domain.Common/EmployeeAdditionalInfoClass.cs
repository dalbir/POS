using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class EmployeeAdditionalInfoClass: BaseDomain
    {
        public string Cashier_ID { get; set; }
        public int FederalAllowances { get; set; }
        public string AdditionalFederalWithholdingAmount { get; set; }
        public int StateAllowances { get; set; }
        public string AdditionalStateWithholdingAmount { get; set; }
        public string StateAdditionalCredits { get; set; }
        public int Exempt { get; set; }
        public int TaxFilingStatus { get; set; }
        public int ExcludeInPayrollExp { get; set; }
    }
}
