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
    public class CustomerSpecificServicesRepsitory
    {
        SQLServerRepository objSqlServerRepostory = new SQLServerRepository();
        DataTable dt;

        public DataTable getRequredDataRep(Inventory_CustPricesClass objInveCust)
        {
            try
            {
                if(objInveCust.message == "item")
                {
                    dt = objSqlServerRepostory.GetDataTable("select * from CUSTOMER_SEPECIFIC_ITEM_PRICES where ItemNum = '" + objInveCust.ItemNum + "'");
                    if(dt.Rows.Count == 0)
                    {
                        dt = objSqlServerRepostory.GetDataTable("select ItemNum, ItemName from Inventory where ItemNum = '" + objInveCust.ItemNum + "'");
                        objInveCust.message = "no";
                    }                  
                }
                else if(objInveCust.message == "customer")
                {
                    dt = objSqlServerRepostory.GetDataTable("select * from CUSTOMER_SEPECIFIC_ITEM_PRICES where CustNum = '" + objInveCust.CustNum + "'");
                    if (dt.Rows.Count == 0)
                    {
                        dt = objSqlServerRepostory.GetDataTable("select CustNum, First_Name + ' ' + Last_Name as CustName from Customer where CustNum = '" + objInveCust.CustNum + "'");
                        objInveCust.message = "no";
                    }     
                }
            }
            catch(Exception ex)
            {

            }
            return dt;
        }

        public Inventory_CustPricesClass insertCustmerwithSpeItemRep(Inventory_CustPricesClass objInvCustPricesClass)
        {
            try
            {
                int result = objSqlServerRepostory.ExecuteNonQuery("INSERT INTO Inventory_CustPrices (Store_ID, ItemNum, CustNum, Price, Allow_Discounts) VALUES ('"+ objInvCustPricesClass.Store_ID +"', '"+ objInvCustPricesClass.ItemNum +"', '"+ objInvCustPricesClass.CustNum +"', '"+ objInvCustPricesClass.Price +"', '"+ objInvCustPricesClass.Allow_Discounts +"')");
                if(result == 1)
                {
                    objInvCustPricesClass.IsSuccessfull = true;
                }
                else
                {
                    objInvCustPricesClass.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {

            }
            return objInvCustPricesClass;
        }

        public Inventory_CustPricesClass updateCustPrice(Inventory_CustPricesClass objCustPrice)
        {
            try
            {
                int result = objSqlServerRepostory.ExecuteNonQuery("UPDATE Inventory_CustPrices SET Price = '"+ objCustPrice.Price +"' WHERE ItemNum = '"+ objCustPrice.ItemNum +"' and CustNum = '"+ objCustPrice.CustNum +"' and Store_ID = '"+ objCustPrice.Store_ID +"'");
                if(result == 1)
                {
                    objCustPrice.IsSuccessfull = true;
                }
                else
                {
                    objCustPrice.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {

            }
            return objCustPrice;
        }

        public Inventory_CustPricesClass updateAllowDiscounts(Inventory_CustPricesClass objCustPrices)
        {
            try
            {
                int result = objSqlServerRepostory.ExecuteNonQuery("UPDATE Inventory_CustPrices SET Allow_Discounts = '" + objCustPrices.Allow_Discounts + "' WHERE ItemNum = '" + objCustPrices.ItemNum + "' and CustNum = '" + objCustPrices.CustNum + "' and Store_ID = '" + objCustPrices.Store_ID + "'");
                if(result == 1)
                {
                    objCustPrices.IsSuccessfull = true;
                }
                    else
                {
                    objCustPrices.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {

            }
            return objCustPrices;
        }

        public Inventory_CustPricesClass removeCustPriceRep(Inventory_CustPricesClass objCustPrcies)
        {
            try
            {
                int result = objSqlServerRepostory.ExecuteNonQuery("delete from Inventory_CustPrices WHERE ItemNum = '" + objCustPrcies.ItemNum + "' and CustNum = '" + objCustPrcies.CustNum + "' and Store_ID = '" + objCustPrcies.Store_ID + "'");
                if(result == 1)
                {
                    objCustPrcies.IsSuccessfull = true;
                }
                else
                {
                    objCustPrcies.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {

            }
            return objCustPrcies;
        }
        DataTable dtForGrids;
        public DataTable fillDataGrids(Inventory_CustPricesClass objCustPrcies)
        {
            try
            {
                if (objCustPrcies.message == "itemDg")
                {
                    dtForGrids = objSqlServerRepostory.GetDataTable("select * from CUSTOMER_SEPECIFIC_ITEM_PRICES where ItemNum = '" + objCustPrcies.ItemNum + "'");
                }
                else if(objCustPrcies.message == "customerDg")
                {
                    dtForGrids = objSqlServerRepostory.GetDataTable("select * from CUSTOMER_SEPECIFIC_ITEM_PRICES where CustNum = '" + objCustPrcies.CustNum + "'");
                }
            }
            catch(Exception ex)
            {

            }
            return dtForGrids;
        }
    }
}
