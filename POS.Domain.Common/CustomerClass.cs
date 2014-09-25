using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class CustomerClass
    {
        public string CustNum  {get; set; }
        public string First_Name  {get; set; }
        public string Last_Name  {get; set; }
        public string Company  {get; set; }
        public string Address_1  {get; set; }
        public string Address_2  {get; set; }
        public string City  {get; set; }
        public string State  {get; set; }
        public string Zip_Code  {get; set; }
        public string Phone_1  {get; set; }
        public string Phone_2 {get; set; }
        public string CC_Type  {get; set; }
        public string CC_Num  {get; set; }
        public string CC_Exp  {get; set; }
        public string Discount_Level  {get; set; }
        public decimal Discount_Percent  {get; set; }
        public DateTime Acct_Open_Date  {get; set; }
        public DateTime Acct_Close_Date  {get; set; }
        public decimal Acct_Balance  {get; set; }
        public decimal Acct_Max_Balance  {get; set; }
        public int Bonus_Plan_Member  {get; set; }
        public int Bonus_Points  {get; set; }
        public int Tax_Exempt  {get; set; }  
        public DateTime Member_Exp  {get; set; }
        public int Dirty  {get; set; } 
        public string Phone_3  {get; set; }
        public string Phone_4  {get; set; }
        public string EMail  {get; set; } 
        public string County  {get; set; }
        public string Def_SP  {get; set; }
        public DateTime CreateDate  {get; set; }
        public string Referral  {get; set; }
        public DateTime Birthday  {get; set; }
        public string Last_Birthday_Bonus  {get; set; }
        public DateTime Last_Visit  {get; set; }
        public int Require_PONum  {get; set; } 
        public int Max_Charge_NumDays  {get; set; }
        public decimal Max_Charge_Amount  {get; set; } 
        public string License_Num  {get; set; }
        public DateTime ID_Last_Checked  {get; set; }
        public DateTime Checking_AcctNum  {get; set; }
        public int PrintNotes  {get; set; }
        public int Loyalty_Plan_ID  {get; set; }
        public int Tax_Rate_ID  {get; set; }
        public string Bill_To_Name  {get; set; }
        public string Contact_1  {get; set; }
        public string Contact_2  {get; set; }
        public string Terms  {get; set; }
        public string Resale_Num  {get; set; }
        public DateTime Last_Coupon  {get; set; }
        public string Account_Type  {get; set; }
        public int ChargeAtCost  {get; set; } 
        public int Disabled  {get; set; } 
        public string ImagePath  {get; set; }
        public DateTime License_ExpDate  {get; set; }
        public string TaxID  {get; set; } 
        public string SecretCode  {get; set; }
        public string OnlineUserName  {get; set; }
        public string OnlinePassword  {get; set; }
    }
}
