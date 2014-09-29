using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.SQLServer;
using POS.Domain.Common;
using System.Data;


namespace POS.Repository.SQLServer
{
   public class CustomerRepository
    {
       SQLServerRepository sqlServerRepost = new SQLServerRepository();
       int result;
       #region Customer
       public CustomerClass CustomerInfo(CustomerClass objCusClass)
       {
           try
           {
               if (objCusClass.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer(CustNum,First_Name,Last_Name,Company, " +
                   "Address_1,Address_2,City,State,Zip_Code,Phone_1,Phone_2,CC_Type,CC_Num,CC_Exp,Discount_Level,Discount_Percent, "+
                   "Acct_Open_Date,Acct_Close_Date,Acct_Balance,Acct_Max_Balance,Bonus_Plan_Member,Bonus_Points,Tax_Exempt, "+
                   "Member_Exp,Dirty,Phone_3,Phone_4,EMail,County,Def_SP,CreateDate,Referral,Birthday,Last_Birthday_Bonus,Last_Visit, "+
                   "Require_PONum,Max_Charge_NumDays,Max_Charge_Amount,License_Num,ID_Last_Checked,Next_Start_Date,Checking_AcctNum, "+
                   "PrintNotes,Loyalty_Plan_ID,Tax_Rate_ID,Bill_To_Name,Contact_1,Contact_2,Terms,Resale_Num,Last_Coupon,Account_Type, "+
                   "ChargeAtCost,Disabled,ImagePath,License_ExpDate,TaxID,SecretCode,OnlineUserName,OnlinePassword) values "+
                   "('" + objCusClass.CustNum + "','" + objCusClass.First_Name + "','" + objCusClass.Last_Name + "','" + objCusClass.Company+ "', "+
                   "'" + objCusClass.Address_1 + "','" + objCusClass.Address_2 + "','"+ objCusClass.City +"','"+ objCusClass.State +"' "+
                   "'"+ objCusClass.Zip_Code +"','"+ objCusClass.Phone_1 +"','"+ objCusClass.Phone_2 +"','"+ objCusClass.CC_Type +"' "+
                   "'"+ objCusClass.CC_Num +"','"+ objCusClass.CC_Exp +"','"+ objCusClass.Discount_Level +"','"+ objCusClass.Discount_Percent +"' "+
                   "'"+ objCusClass.Acct_Open_Date +"','"+ objCusClass.Acct_Close_Date +"','"+ objCusClass.Acct_Balance +"','"+ objCusClass.Acct_Max_Balance +"' "+
                   "'"+ objCusClass.Bonus_Plan_Member +"','"+ objCusClass.Bonus_Points +"','"+ objCusClass.Tax_Exempt +"','"+ objCusClass.Member_Exp +"' "+
                   "'"+ objCusClass.Dirty +"','"+ objCusClass.Phone_3 +"','"+ objCusClass.Phone_4 +"','"+ objCusClass.EMail +"' "+
                   "'"+ objCusClass.County +"','"+ objCusClass.Def_SP +"','"+ objCusClass.CreateDate +"','"+ objCusClass.Referral +"' "+
                   "'"+ objCusClass.Birthday +"','"+ objCusClass.Last_Birthday_Bonus +"','"+ objCusClass.Last_Visit +"','"+ objCusClass.Require_PONum +"' "+
                   "'"+ objCusClass.Max_Charge_NumDays +"','"+ objCusClass.Max_Charge_Amount +"','"+ objCusClass.License_Num +"' "+
                   "'"+ objCusClass.ID_Last_Checked +"','"+ objCusClass.Next_Start_Date +"','"+ objCusClass.Checking_AcctNum +"' "+
                   "'"+ objCusClass.PrintNotes +"','"+ objCusClass.Loyalty_Plan_ID +"','"+ objCusClass.Tax_Rate_ID +"','"+ objCusClass.Bill_To_Name +"' "+
                   "'"+ objCusClass.Contact_1 +"','"+ objCusClass.Contact_2 +"','"+ objCusClass.Terms +"','"+ objCusClass.Resale_Num +"' "+
                   "'"+ objCusClass.Last_Coupon +"','"+ objCusClass.Account_Type +"','"+ objCusClass.ChargeAtCost +"','"+ objCusClass.Disabled +"' "+
                   "'"+ objCusClass.ImagePath +"','"+ objCusClass.License_ExpDate +"','"+ objCusClass.TaxID +"','"+ objCusClass.SecretCode +"' "+
                   "'"+ objCusClass.OnlineUserName +"','"+ objCusClass.OnlinePassword +"')");
               }
               if (result > 0)
               {
                   objCusClass.IsSuccessfull = true;
               }
               else
               {
                   objCusClass.IsSuccessfull = false;
               }    
           }
           catch(Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCusClass;
       }
       #endregion

       #region CustomerAccountingTransaction
       public CustomerAccountingTransactionClass CustomerAccTrnsInfo(CustomerAccountingTransactionClass objCusAccTrans)
       {
           try
           {
               if (objCusAccTrans.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Accounting_Transaction(CustNum,EditSequence) " +
                       "values('" + objCusAccTrans.CustNum + "','" + objCusAccTrans.EditSequence + "')");
               }


               if (result > 0)
               {
                   objCusAccTrans.IsSuccessfull = true;
               }
               else
               {
                   objCusAccTrans.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCusAccTrans;
       }
       #endregion

       #region CustomerAuthorizedClass
       public CustomerAuthorizedClass CustomerAuthorInfo(CustomerAuthorizedClass objCustAuthorized)
       {
           try
           {
               if (objCustAuthorized.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Authorized(CustNum,Member,Dirty) " +
                   "values('" + objCustAuthorized.CustNum + "','" + objCustAuthorized.Member + "','"+ objCustAuthorized.Dirty +"')");
               }


               if (result > 0)
               {
                   objCustAuthorized.IsSuccessfull = true;
               }
               else
               {
                   objCustAuthorized.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustAuthorized;
       }
       #endregion

       #region CustomerAutoClass
       public CustomerAutoClass CustAutoInfo(CustomerAutoClass objCustAutoInfo)
       {
           try
           {
               if (objCustAutoInfo.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Auto(CustNum,License,Make,Model) " +
                   "values('" + objCustAutoInfo.CustNum + "','" + objCustAutoInfo.License + "','" + objCustAutoInfo.Make + "','"+ objCustAutoInfo.Model +"')");
               }


               if (result > 0)
               {
                   objCustAutoInfo.IsSuccessfull = true;
               }
               else
               {
                   objCustAutoInfo.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustAutoInfo;
       }
       #endregion

        #region CustomerEvents
       public CustomerEventsClass custEventsIngo(CustomerEventsClass objCustEvents)
       {
           try
           {
               if (objCustEvents.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Events (CustNum,Event_Date,Event_Desc,Dirty) " +
                   "values('" + objCustEvents.CustNum + "','" + objCustEvents.Event_Date + "','" + objCustEvents.Event_Desc + "','" + objCustEvents.Dirty + "')");
               }


               if (result > 0)
               {
                   objCustEvents.IsSuccessfull = true;
               }
               else
               {
                   objCustEvents.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustEvents;

       }
        #endregion

       #region CustomerGiftRegistry
       public CustomerGiftRegistryClass CustomerGiftRegInfo(CustomerGiftRegistryClass objCustomerGiftReg)
       {
           try
           {
               if (objCustomerGiftReg.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Gift_Registry (Registry_ID,CustNum,Description,Event_Date,Date_Created,Dirty) " +
                   "values('" + objCustomerGiftReg.Registry_ID + "','" + objCustomerGiftReg.CustNum + "','" + objCustomerGiftReg.Description + "', "+
                   "'" + objCustomerGiftReg.Event_Date + "','" + objCustomerGiftReg.Date_Created + "','"+ objCustomerGiftReg.Dirty +"')");
               }


               if (result > 0)
               {
                   objCustomerGiftReg.IsSuccessfull = true;
               }
               else
               {
                   objCustomerGiftReg.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustomerGiftReg;
       }
        #endregion

        #region CustomerGiftRegistryItems
       public CustomerGiftRegistryItemsClass CustGftRegItemInfo(CustomerGiftRegistryItemsClass objCusGftRegItems)
       {
           try
           {
               if (objCusGftRegItems.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Gift_Registry_Items (Registry_ID,Store_ID,ItemNum,Quan_Req,Quan_Purch) " +
                   "values('" + objCusGftRegItems.Registry_ID + "','" + objCusGftRegItems.Store_ID + "','" + objCusGftRegItems.ItemNum + "', " +
                   "'" + objCusGftRegItems.Quan_Req + "','" + objCusGftRegItems.Quan_Purch + "' )");
               }


               if (result > 0)
               {
                   objCusGftRegItems.IsSuccessfull = true;
               }
               else
               {
                   objCusGftRegItems.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCusGftRegItems;
       }
        #endregion

        #region CustomerNotes

       public CustomerNotesClass CustomerNotesInfo(CustomerNotesClass objCustomerNotes)
       {
           try
           {
               if (objCustomerNotes.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Notes (CustNum,Notes) " +
                   "values('" + objCustomerNotes.CustNum + "','" + objCustomerNotes.Notes + "' )");
               }


               if (result > 0)
               {
                   objCustomerNotes.IsSuccessfull = true;
               }
               else
               {
                   objCustomerNotes.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustomerNotes;
       }

        #endregion

        #region

       public CustomerPropertiesClass CustomerProprtiesInfo(CustomerPropertiesClass objCustProprty)
       {
           try
           {
               if (objCustProprty.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Notes (CustNum,Value_ID) " +
                   "values('" + objCustProprty.CustNum + "','" + objCustProprty.Value_ID+ "' )");
               }


               if (result > 0)
               {
                   objCustProprty.IsSuccessfull = true;
               }
               else
               {
                   objCustProprty.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustProprty;
       }
        #endregion

       #region CustomerRefernce
       public CustomerReferenceClass custRefrenceInfo(CustomerReferenceClass objCustRefrnce)
       {
           try
           {
               if (objCustRefrnce.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Reference (ID,CustNum) " +
                   "values('" + objCustRefrnce.ID + "','" + objCustRefrnce.CustNum + "' )");
               }


               if (result > 0)
               {
                   objCustRefrnce.IsSuccessfull = true;
               }
               else
               {
                   objCustRefrnce.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustRefrnce;
       }
       #endregion

       #region CustomerShip
       public CustomerShipTosClass CustShipTosInfo(CustomerShipTosClass objCustomerShp)
       {
           try
           {
               if (objCustomerShp.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_ShipTos (CustNum,First_Name,Last_Name, "+
                       "Company,Address_1,Address_2,City,State,Zip_Code,Phone,Dirty,County,DeliveryAddressSpecialInstructions) " +
                   "values('" + objCustomerShp.CustNum + "','" + objCustomerShp.First_Name + "','"+ objCustomerShp.Last_Name +"', "+
                   "'"+ objCustomerShp.Company +"','"+ objCustomerShp.Address_1 +"','"+ objCustomerShp.Address_2 +"', "+
                   "'"+ objCustomerShp.City +"','"+ objCustomerShp.State +"','"+ objCustomerShp.Zip_Code +"','"+ objCustomerShp.Phone +"', "+
                   "'"+ objCustomerShp.County +"','"+ objCustomerShp.DeliveryAddressSpecialInstructions +"')");
               }


               if (result > 0)
               {
                   objCustomerShp.IsSuccessfull = true;
               }
               else
               {
                   objCustomerShp.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustomerShp;
       }
       #endregion

       #region CustomerStore
       public CustomerStoresClass customerStoresInfo(CustomerStoresClass objCustStore)
       {
           try
           {
               if (objCustStore.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Stores (CustNum,Store_ID) " +
                   "values('" + objCustStore.CustNum + "','" + objCustStore.Store_ID + "' )");
               }


               if (result > 0)
               {
                   objCustStore.IsSuccessfull = true;
               }
               else
               {
                   objCustStore.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCustStore;
       }
       #endregion

        #region CustomerSwip

       public CustomerSwipesClass CustomerSwipInfo(CustomerSwipesClass objCusSwip)
       {
           try
           {
               if (objCusSwip.flage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Customer_Swipes (CustNum,Swipe_ID) " +
                   "values('" + objCusSwip.CustNum + "','" + objCusSwip.Swipe_ID + "' )");
               }


               if (result > 0)
               {
                   objCusSwip.IsSuccessfull = true;
               }
               else
               {
                   objCusSwip.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objCusSwip;
       }

        #endregion

    }
   
}
