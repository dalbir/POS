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
   public class GlobalPriceRepository
    {
       SQLServerRepository objSqlServerRepostory = new SQLServerRepository();
       DataTable dtdept;
       DataTable dtItems;
        public DataTable GetDepatment(DepartmentClass objDepartment)
        {
            try
            {
                dtdept = objSqlServerRepostory.GetDataTable("SELECT DISTINCT Description, Dept_ID, Dept_ID + '-' + Description as DetpDes FROM Departments WHERE (Store_ID = '" + objDepartment.Store_ID + "')");
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtdept;
        }

        public DataTable getItems(string storeID)
        {
            try
            {
                dtItems = objSqlServerRepostory.GetDataTable("SELECT DISTINCT Inventory.ItemNum, Inventory.ItemName FROM Inventory WHERE IsDeleted = 0 AND ItemType IN (0,2) AND (Store_ID = '" + storeID + "')");
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtItems;
        }
        DataTable dtItemsData;
        public DataTable getItemsData(InventoryClass objInventoryClass)
        {
            try
            {
                if (objInventoryClass.qryType == "ItemInDept")
                {
                    dtItemsData = objSqlServerRepostory.GetDataTable("SELECT ItemNum, ItemName, Price, 0.00 AS [Sale Price] FROM Inventory WHERE IsDeleted = 0 AND ItemType IN (0,2) AND Dept_ID = '" + objInventoryClass.Dept_ID + "' AND (Store_ID = '" + objInventoryClass.Store_ID + "')");
                }
                else if (objInventoryClass.qryType == "Item")
                {
                    //dtItemsData = objSqlServerRepostory.GetDataTable("select ItemNum, ItemName, Price, Cost from Inventory where Store_ID = '"+ objInventoryClass.Store_ID +"' and ItemNum = '" + objInventoryClass.ItemNum + "'");
                    dtItemsData = objSqlServerRepostory.GetDataTable("select I.ItemNum, I.ItemName, I.Price, S.Price as SalePrice from Inventory as I left outer join Inventory_OnSale_Info as S on I.ItemNum = S.ItemNum where I.Store_ID = '"+ objInventoryClass.Store_ID +"' and I.ItemNum = '"+ objInventoryClass.ItemNum +"'");
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtItemsData;
        }
        int rest;
        public InventoryClass updatePriceRep(InventoryClass objInventoryClass)
        {
            try
            {
                if(objInventoryClass.qryType == "AllItems")
                {
                    rest = objSqlServerRepostory.ExecuteNonQuery("UPDATE Inventory SET Price = '" + objInventoryClass.Price + "', Dirty = '"+ objInventoryClass.Dirty +"' WHERE (Store_ID = '"+ objInventoryClass.Store_ID +"')");
                }
                else if (objInventoryClass.qryType == "itemsInDept")
                {
                    rest = objSqlServerRepostory.ExecuteNonQuery("UPDATE Inventory SET Price = '" + objInventoryClass.Price + "', Dirty = '"+ objInventoryClass.Dirty +"' WHERE (Store_ID = '"+ objInventoryClass.Store_ID +"') and Dept_ID = '"+ objInventoryClass.Dept_ID +"'");
                }
                else if (objInventoryClass.qryType == "selectedItems")
                {
                    rest = objSqlServerRepostory.ExecuteNonQuery("update Inventory set Price = '" + objInventoryClass.Price + "', Dirty = '"+ objInventoryClass.Dirty +"' WHERE (Store_ID = '"+ objInventoryClass.Store_ID +"') and ItemNum = '" + objInventoryClass.ItemNum + "'");
                }
                if(rest > 0)
                {
                    objInventoryClass.IsSuccessfull = true;
                }
                else
                {
                    objInventoryClass.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objInventoryClass;
        }
       // update sale price
        int reslt;
        public Inventory_OnSale_InfoClass updateSalePriceRep(Inventory_OnSale_InfoClass objInvOnSaleInfo)
        {
            try
            {
                if(objInvOnSaleInfo.qurryFlage == "allItems")
                {
                    objSqlServerRepostory.ExecuteNonQuery("delete from Inventory_OnSale_Info where Store_ID = '"+ objInvOnSaleInfo.Store_ID +"'");
                    reslt = objSqlServerRepostory.ExecuteNonQuery("INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '"+ objInvOnSaleInfo.Store_ID +"' AS Store_ID, '" + objInvOnSaleInfo.Sale_Start + "' AS Sale_Start, '" + objInvOnSaleInfo.Sale_End + "' AS Sale_End,  0 As [Percent], '" + objInvOnSaleInfo.Price + "' AS [Price], 1 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '"+ objInvOnSaleInfo.Store_ID +"'");
                }
                else if(objInvOnSaleInfo.qurryFlage == "itemsInDept")
                {
                    objSqlServerRepostory.ExecuteNonQuery("DELETE FROM Inventory_OnSale_Info WHERE (Store_ID = '"+ objInvOnSaleInfo.Store_ID +"') AND  EXISTS (Select ItemNum FROM Inventory WHERE Inventory.ItemNum = Inventory_OnSale_Info.ItemNum AND Inventory.Store_ID = Inventory_OnSale_Info.Store_ID AND Inventory.ItemType IN (0,2) AND Inventory.Dept_ID = '" + objInvOnSaleInfo.Dept_ID + "')");
                    reslt = objSqlServerRepostory.ExecuteNonQuery("INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '1001' AS Store_ID, '" + objInvOnSaleInfo.Sale_Start + "' AS Sale_Start, '" + objInvOnSaleInfo.Sale_End + "' AS Sale_End, 0 As [Percent], '" + objInvOnSaleInfo.Price + "' AS [Price], 1 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '"+ objInvOnSaleInfo.Store_ID +"' AND Dept_ID = '" + objInvOnSaleInfo.Dept_ID + "'");
                }
                else if(objInvOnSaleInfo.qurryFlage == "selectedItems")
                {
                    reslt = objSqlServerRepostory.ExecuteNonQuery("INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '"+ objInvOnSaleInfo.Store_ID +"' AS Store_ID, '" + objInvOnSaleInfo.Sale_Start + "' AS Sale_Start, '" + objInvOnSaleInfo.Sale_End + "' AS Sale_End, 0 As [Percent], '" + objInvOnSaleInfo.Price + "' AS [Price], 1 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '"+ objInvOnSaleInfo.Store_ID +"' and Inventory.ItemNum ='" + objInvOnSaleInfo.ItemNum + "'");
                }
                if(reslt > 0)
                {
                    objInvOnSaleInfo.IsSuccessfull = true;
                }
                else
                {
                    objInvOnSaleInfo.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objInvOnSaleInfo;
        }
       // delete selected items for sale price change
        public Inventory_OnSale_InfoClass deleteSelectItemsRep(Inventory_OnSale_InfoClass objInvOnSaleInfo)
        {
            try
            {
                for (int i = 0; i < objInvOnSaleInfo.ListSelectItems.Count; i++)
                {
                    int result = objSqlServerRepostory.ExecuteNonQuery("DELETE FROM Inventory_OnSale_Info WHERE (Store_ID = '"+ objInvOnSaleInfo.Store_ID +"') AND ItemNum = '" + objInvOnSaleInfo.ListSelectItems[i].ToString() + "'");
                }
                
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objInvOnSaleInfo;
                
        }
        int relt;
        public InventoryClass increasPriceRep(InventoryClass objInventoryClass)
        {
            try
            {
                if (objInventoryClass.qryType == "allItems")
                {
                    relt = objSqlServerRepostory.ExecuteNonQuery("update Inventory set Price = Price + Price * " + objInventoryClass.Price + "/100, Dirty = '" + objInventoryClass.Dirty + "'  where Store_ID = '" + objInventoryClass.Store_ID + "'");
                }
                else if (objInventoryClass.qryType == "itemsInDept")
                {
                    relt = objSqlServerRepostory.ExecuteNonQuery("update Inventory set Price = Price + Price * " + objInventoryClass.Price + "/100, Dirty = '" + objInventoryClass.Dirty + "'  where Store_ID = '" + objInventoryClass.Store_ID + "' and Dept_ID = '"+ objInventoryClass.Dept_ID +"'");
                }
                else if (objInventoryClass.qryType == "selectedItems")
                {
                    relt = objSqlServerRepostory.ExecuteNonQuery("update Inventory set Price = Price + Price * " + objInventoryClass.Price + "/100, Dirty = '" + objInventoryClass.Dirty + "'  where Store_ID = '" + objInventoryClass.Store_ID + "' and ItemNum = '" + objInventoryClass.ItemNum + "'");
                }
                if(relt > 0)
                {
                    objInventoryClass.IsSuccessfull = true;
                }
                else
                {
                    objInventoryClass.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objInventoryClass;
        }
       // repository for apply discounts
        public Inventory_OnSale_InfoClass applyDiscountsRep(Inventory_OnSale_InfoClass objInvOnSaleInfo)
        {
            try
            {
                if (objInvOnSaleInfo.qurryFlage == "allItems")
                {
                    objSqlServerRepostory.ExecuteNonQuery("delete from Inventory_OnSale_Info where Store_ID = '" + objInvOnSaleInfo.Store_ID + "'");
                    reslt = objSqlServerRepostory.ExecuteNonQuery("INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '" + objInvOnSaleInfo.Store_ID + "' AS Store_ID, '" + objInvOnSaleInfo.Sale_Start + "' AS Sale_Start, '" + objInvOnSaleInfo.Sale_End + "' AS Sale_End,  '" + objInvOnSaleInfo.Price + "' As [Percent], 0.00 AS [Price], 0 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '" + objInvOnSaleInfo.Store_ID + "'");
                }
                else if (objInvOnSaleInfo.qurryFlage == "itemsInDept")
                {
                    objSqlServerRepostory.ExecuteNonQuery("DELETE FROM Inventory_OnSale_Info WHERE (Store_ID = '"+ objInvOnSaleInfo.Store_ID +"') AND  EXISTS (Select ItemNum FROM Inventory WHERE Inventory.ItemNum = Inventory_OnSale_Info.ItemNum AND Inventory.Store_ID = Inventory_OnSale_Info.Store_ID AND Inventory.ItemType IN (0,2) AND Inventory.Dept_ID = '" + objInvOnSaleInfo.Dept_ID + "')");
                    reslt = objSqlServerRepostory.ExecuteNonQuery("INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '" + objInvOnSaleInfo.Store_ID + "' AS Store_ID, '" + objInvOnSaleInfo.Sale_Start + "' AS Sale_Start, '" + objInvOnSaleInfo.Sale_End + "' AS Sale_End, '" + objInvOnSaleInfo.Price + "' As [Percent], 0.00 AS [Price], 0 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '" + objInvOnSaleInfo.Store_ID + "' AND Dept_ID = '" + objInvOnSaleInfo.Dept_ID + "'");
                }
                else if (objInvOnSaleInfo.qurryFlage == "selectedItems")
                {
                    reslt = objSqlServerRepostory.ExecuteNonQuery("INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '" + objInvOnSaleInfo.Store_ID + "' AS Store_ID, '" + objInvOnSaleInfo.Sale_Start + "' AS Sale_Start, '" + objInvOnSaleInfo.Sale_End + "' AS Sale_End, '" + objInvOnSaleInfo.Price + "' As [Percent], 0.00 AS [Price], 0 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '" + objInvOnSaleInfo.Store_ID + "' and Inventory.ItemNum ='" + objInvOnSaleInfo.ItemNum + "'");
                }
                if (reslt > 0)
                {
                    objInvOnSaleInfo.IsSuccessfull = true;
                }
                else
                {
                    objInvOnSaleInfo.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objInvOnSaleInfo; 
        }
        int rslt;
        public InventoryClass applyTaxRep(InventoryClass objInventoryClass)
        {
            try
            {
                if (objInventoryClass.qryType == "allItems")
                {
                    rslt = objSqlServerRepostory.ExecuteNonQuery("update Inventory set "+ objInventoryClass.Tax +" = '" + objInventoryClass.taxValue + "', Dirty = '" + objInventoryClass.Dirty + "'  where Store_ID = '" + objInventoryClass.Store_ID + "'");
                }
                else if (objInventoryClass.qryType == "itemsInDept")
                {
                    rslt = objSqlServerRepostory.ExecuteNonQuery("update Inventory set " + objInventoryClass.Tax + " = '" + objInventoryClass.taxValue + "', Dirty = '" + objInventoryClass.Dirty + "'  where Store_ID = '" + objInventoryClass.Store_ID + "' and Dept_ID = '" + objInventoryClass.Dept_ID + "'");
                }
                else if (objInventoryClass.qryType == "selectedItems")
                {
                    rslt = objSqlServerRepostory.ExecuteNonQuery("update Inventory set " + objInventoryClass.Tax + " = '" + objInventoryClass.taxValue + "', Dirty = '" + objInventoryClass.Dirty + "'  where Store_ID = '" + objInventoryClass.Store_ID + "' and ItemNum = '" + objInventoryClass.ItemNum + "'");
                }
                if (rslt > 0)
                {
                    objInventoryClass.IsSuccessfull = true;
                }
                else
                {
                    objInventoryClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objInventoryClass;
        }
    }
}
