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
    public class InventoryRepository
    {
        SQLServerRepository sqlServerRepost = new SQLServerRepository();

        public InventoryClass FillDeptCombo(InventoryClass objFillDeptCombo)
        {
            try
            {
                if (objFillDeptCombo.dptFlage == "fillcombo")
                {
                    objFillDeptCombo.dtDeptCmb = sqlServerRepost.GetDataTable("select Dept_ID, Dept_ID + ' - ' + Description as dept from Departments where Type in(0, 1)");
                }
                else if (objFillDeptCombo.dptFlage == "index")
                {
                    objFillDeptCombo.dtDeptCmb = sqlServerRepost.GetDataTable("select Type from Departments where Dept_ID = '" + objFillDeptCombo.Dept_ID + "'");
                }
            }
            catch (Exception)
            {

            }
            return objFillDeptCombo;
        }
        public Inventory_ImageClass GetinventoryImgaeInfo(Inventory_ImageClass objGetinventoryImgaeInfo)
        {
            try
            {
                objGetinventoryImgaeInfo.dtmaxID = sqlServerRepost.GetDataTable("select isnull(max(ID),0) + 1 from Inventory_Image");
            }
            catch (Exception)
            {

            }
            return objGetinventoryImgaeInfo;
        }
        #region insertion into tables
        // insertion sku in Inventory_SKUS
        int result;
        public Inventory_SKUSClass insertSkus(Inventory_SKUSClass objInventory_SKUSClass)
        {
             try
           {
               if (objInventory_SKUSClass.quryFlage == "delete")
               {
                   result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_SKUS where ItemNum = '" + objInventory_SKUSClass.ItemNum + "'");
               }
               else if (objInventory_SKUSClass.quryFlage == "insert")
               {
                   result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_SKUS(Store_ID,ItemNum,AltSKU) values('1001', '" + objInventory_SKUSClass.ItemNum + "','" + objInventory_SKUSClass.lisBoxValue + "')");
               }
               if (result == 1)
               {
                   objInventory_SKUSClass.IsSuccessfull = true;
                   //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
               }
               else
               {
                   objInventory_SKUSClass.IsSuccessfull = false;
                  // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
               }

           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
             return objInventory_SKUSClass;
       }
        // retriving skus 
        public Inventory_SKUSClass RetriveSku(Inventory_SKUSClass objRetriveSku)
        {
            try
            {
                objRetriveSku.dtSku = sqlServerRepost.GetDataTable("Select AltSKU from Inventory_SKUS");
            }
            catch(Exception)
            { }
            return objRetriveSku;
        }
        // insert tag Inventory_TagAlongs

        public Inventory_TagAlongsClass insertTagAlongs(Inventory_TagAlongsClass objinsertTagAlongs)
        {
            try
            {
                if (objinsertTagAlongs.quryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_TagAlongs where ItemNum = '" + objinsertTagAlongs.ItemNum + "'");
                }
                else if (objinsertTagAlongs.quryFlage == "insert")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_TagAlongs(ItemNum,Store_ID,TagAlong_ItemNum,Quantity) values('" + objinsertTagAlongs.ItemNum + "','1001','" + objinsertTagAlongs.listBoxValueTag + "','" + objinsertTagAlongs.Quantity + "')");
                }
                if (result == 1)
                {
                    objinsertTagAlongs.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objinsertTagAlongs.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objinsertTagAlongs;
        }
        // insertion of modifers groups
        public Kit_IndexClass InsertKit(Kit_IndexClass objKitIndex)
        {
            try
            {
                if (objKitIndex.quryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Kit_Index where ItemNum = '" + objKitIndex.ItemNum + "'");
                }
                else if (objKitIndex.quryFlage == "insert")
                {
                    result = sqlServerRepost.ExecuteNonQuery("Kit_ID,Store_ID,ItemNum,Quantity,Price,Description) values('" + objKitIndex.Kit_ID + "','"+ objKitIndex.Store_ID +"','" + objKitIndex.ItemNum + "','" + objKitIndex.Quantity + "','" + objKitIndex.Price + "','" + objKitIndex.Description + "')");
                }
                if (result == 1)
                {
                    objKitIndex.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objKitIndex.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objKitIndex;
        }
        // insertion of modifiers with items
        public ModifiersClass InsertModifersWItem(ModifiersClass objModifiers)
        {

            try
            {
                if (objModifiers.quryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Modifiers where ItemNum = '" + objModifiers.ItemNum + "'");
                }
                else if (objModifiers.quryFlage == "insert")
                {
                    result = sqlServerRepost.ExecuteNonQuery("ItemNum,Store_ID,ModNum,ModName,Group_Or_Individual,ChargePrice,NumToSelect,Prompt,[Index],Forced) values('" + objModifiers.ItemNum + "','"+ objModifiers.Store_ID +"','" + objModifiers.ModNum + "','" + objModifiers.ModName + "','"+ objModifiers.Group_Or_Individual +"','" + objModifiers.ChargePrice + "','" + objModifiers.NumToSelect + "','" + objModifiers.Prompt + "','" + objModifiers.Index + "','" + objModifiers.Forced + "')");
                }
                else if (objModifiers.quryFlage == "loopinsertion")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Modifiers(ItemNum,Store_ID,ModNum,ModName,Group_Or_Individual,[Index]) values('" + objModifiers.ItemNum + "','"+ objModifiers.Store_ID +"','" + objModifiers.ModNum + "','" + objModifiers.ModName + "','"+ objModifiers.Group_Or_Individual +"','" + objModifiers.Index + "')");
                }
                if (result == 1)
                {
                    objModifiers.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objModifiers.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objModifiers;
        }
        // get item type
        string res;
        public string GetItemTypeRepo(InventoryClass objInventory)
        {
            try
            {
               SQLServerRepository objSqlRep = new SQLServerRepository();
               res = objSqlRep.ExecuteScalar("select ItemType from Inventory where ItemNum = '" + objInventory.ItemNum + "'");

            }
            catch (Exception)
            {

            }
            return res;
        }
        public Inventory_DiscLevelsClass ExecuteInvDislevel(Inventory_DiscLevelsClass objInventoryDisLevel)
        {
            try
            {
                if (objInventoryDisLevel.qFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_DiscLevels where ItemNum = '" + objInventoryDisLevel.ItemNum + "'");
                }
              
                else if (objInventoryDisLevel.qFlage == "loopinsertion")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_DiscLevels(Store_ID,ItemNum,Level,Perc) values('"+ objInventoryDisLevel.Store_ID +"','" + objInventoryDisLevel.ItemNum + "','" + objInventoryDisLevel.Level + "','" + objInventoryDisLevel.Perc + "')");
                }
                if (result == 1)
                {
                    objInventoryDisLevel.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventoryDisLevel.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objInventoryDisLevel;
        }
        public Inventory_VendorsClass executeOrderingInfoRep(Inventory_VendorsClass objInventoryVendor)
        {
            try
            {
                if (objInventoryVendor.qryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_Vendors where ItemNum = '" + objInventoryVendor.ItemNum + "'");
                }

                else if (objInventoryVendor.qryFlage == "loopinsertion")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_Vendors(ItemNum,Store_ID,Vendor_Number,CostPer,Case_Cost,NumPerVenCase,Vendor_Part_Num) values('" + objInventoryVendor.ItemNum + "','"+ objInventoryVendor.Store_ID +"','" + objInventoryVendor.Vendor_Number + "','" + objInventoryVendor.CostPer + "','" + objInventoryVendor.Case_Cost + "','" + objInventoryVendor.NumPerVenCase + "','" + objInventoryVendor.Vendor_Part_Num + "')");
                }
                if (result == 1)
                {
                    objInventoryVendor.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventoryVendor.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objInventoryVendor;
        }
        public Inventory_OnSale_InfoClass ExecuteInventoryOnsaleInfoRep(Inventory_OnSale_InfoClass objInventoryOnsaleInfo)
        {
            try
            {
                if (objInventoryOnsaleInfo.qurryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_OnSale_Info where ItemNum = '" + objInventoryOnsaleInfo.ItemNum + "'");
                }

                else if (objInventoryOnsaleInfo.qurryFlage == "loopinsertion")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_OnSale_Info(ItemNum,Store_ID,Sale_Start,Sale_End,[Percent],Price,SalePriceType) values('" + objInventoryOnsaleInfo.ItemNum + "','"+ objInventoryOnsaleInfo.Store_ID +"','" + objInventoryOnsaleInfo.Sale_Start + "','" + objInventoryOnsaleInfo.Sale_End + "','" + objInventoryOnsaleInfo.Percent + "','" + objInventoryOnsaleInfo.Price + "','"+ objInventoryOnsaleInfo.SalePriceType +"')");
                }
                if (result == 1)
                {
                    objInventoryOnsaleInfo.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventoryOnsaleInfo.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objInventoryOnsaleInfo;
        }
        DataTable dtt;
        public DataTable getInventoryRep(string id_item)
        {
            try
            {
                SQLServerRepository objSqlServerRepository = new SQLServerRepository();
                dtt = objSqlServerRepository.GetDataTable("select ItemNum, ItemName, In_Stock,Price, ItemName_Extra from Inventory where ItemNum = '" + id_item + "'");
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return dtt;
        }
        DataTable dtModifiers;
        public DataTable getModifiersRepository()
        {
            try
            {
                SQLServerRepository objSqlServerRep = new SQLServerRepository();
                dtModifiers = objSqlServerRep.GetDataTable("select ItemNum,ItemName from Inventory where IsModifier = 1");
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return dtModifiers;
        }
        public Inventory_Bulk_InfoClass ExecuteInvBulkInfoRep(Inventory_Bulk_InfoClass objInventory_Bulk_InfoClass)
        {
            try
            {
                if (objInventory_Bulk_InfoClass.quryFlg == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_Bulk_Info where ItemNum = '" + objInventory_Bulk_InfoClass.ItemNum + "'");
                }

                else if (objInventory_Bulk_InfoClass.quryFlg == "loopinsertion")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_Bulk_Info(ItemNum,Store_ID,Bulk_Price,Bulk_Quan,Price_Type,Description) values('" + objInventory_Bulk_InfoClass.ItemNum + "','"+ objInventory_Bulk_InfoClass.Store_ID +"','" + objInventory_Bulk_InfoClass.Bulk_Price + "','" + objInventory_Bulk_InfoClass.Bulk_Quan + "','" + objInventory_Bulk_InfoClass.Price_Type + "','" + objInventory_Bulk_InfoClass.Description + "')");
                }
                if (result == 1)
                {
                    objInventory_Bulk_InfoClass.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventory_Bulk_InfoClass.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objInventory_Bulk_InfoClass;
        }
        public Inventory_PricesClass executeInventoryPrice(Inventory_PricesClass objInventory_PricesClass)
        {
            try
            {
                if (objInventory_PricesClass.quryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_Prices where ItemNum = '" + objInventory_PricesClass.ItemNum + "'");
                }

                else if (objInventory_PricesClass.quryFlage == "loopinsertion")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_Prices(ItemNum,Store_ID,Price,Criteria1,Criteria2,Criteria3,Enabled,PriceType) values('" + objInventory_PricesClass.ItemNum + "','" + objInventory_PricesClass.Store_ID + "','" + objInventory_PricesClass.Price + "','" + objInventory_PricesClass.Criteria1 + "','" + objInventory_PricesClass.Criteria2 + "','" + objInventory_PricesClass.Criteria3 + "', '" + objInventory_PricesClass.Enabled + "','" + objInventory_PricesClass.PriceType + "')");
                }
                if (result == 1)
                {
                    objInventory_PricesClass.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventory_PricesClass.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository: Error:]", ex.Message);
            }
            return objInventory_PricesClass;
        }
        public ChoiceItemsPropertyClass executeChoiceItemRep(ChoiceItemsPropertyClass objChoiceItemsPropertyClass)
        {
            try
            {
                if (objChoiceItemsPropertyClass.quryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from ChoiceItems_Properties where ItemNum = '" + objChoiceItemsPropertyClass.ItemNum + "'");
                }

                else if (objChoiceItemsPropertyClass.quryFlage == "loopinsertion")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into ChoiceItems_Properties(Store_ID,ItemNum,Value_ID) values('"+ objChoiceItemsPropertyClass.Store_ID +"','" + objChoiceItemsPropertyClass.ItemNum + "','" + objChoiceItemsPropertyClass.Value_ID + "')");
                }
                if (result == 1)
                {
                    objChoiceItemsPropertyClass.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objChoiceItemsPropertyClass.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository: Error:]", ex.Message);
            }
            return objChoiceItemsPropertyClass;
        }
        public Inventory_CouponClass executeCouponRep(Inventory_CouponClass objInventory_CouponClass)
        {
            try
            {
                if (objInventory_CouponClass.qruyFalge == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_Coupon where ItemNum = '" + objInventory_CouponClass.ItemNum + "'");
                }

                else if (objInventory_CouponClass.qruyFalge == "insert")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_Coupon(Store_ID,ItemNum,Exp_Date,Enforce_Exp,Include_All_Except,Coupon_Flat_Percent,Coupon_Bonus_Only,Apply_To_Parent,Suppress_Bonus,Minimum_Amount_Restriction,NumDays_Restriction,ApplyOnDiscountedItems,ApplyOnSpecialPricing) values('"+ objInventory_CouponClass.Store_ID +"','" + objInventory_CouponClass.ItemNum + "','" + objInventory_CouponClass.Exp_Date + "','" + objInventory_CouponClass.Enforce_Exp + "','" + objInventory_CouponClass.Include_All_Except + "','" + objInventory_CouponClass.Coupon_Flat_Percent + "','" + objInventory_CouponClass.Coupon_Bonus_Only + "','" + objInventory_CouponClass.Apply_To_Parent + "','" + objInventory_CouponClass.Suppress_Bonus + "','" + objInventory_CouponClass.Minimum_Amount_Restriction + "','" + objInventory_CouponClass.NumDays_Restriction + "','" + objInventory_CouponClass.ApplyOnDiscountedItems + "','" + objInventory_CouponClass.ApplyOnSpecialPricing + "')");
                }
                if (result == 1)
                {
                    objInventory_CouponClass.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventory_CouponClass.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository: Error:]", ex.Message);
            }
            return objInventory_CouponClass;
        }
        public Inventory_Coupon_RulesClass executeCouponRulesRep(Inventory_Coupon_RulesClass objInventoryCoupnRules)
        {
            try
            {
                if (objInventoryCoupnRules.qruFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_Coupon_Rules where ItemNum = '" + objInventoryCoupnRules.ItemNum + "'");
                }

                else if (objInventoryCoupnRules.qruFlage == "insert")
                {
                    result = sqlServerRepost.ExecuteNonQuery("insert into Inventory_Coupon_Rules(Store_ID,ItemNum,Type,ID,Allow_Or_Disallow) values('"+ objInventoryCoupnRules.Store_ID +"','" + objInventoryCoupnRules.ItemNum + "','" + objInventoryCoupnRules.Type + "','" + objInventoryCoupnRules.ID + "','" + objInventoryCoupnRules.Allow_Or_Disallow + "')");
                }
                if (result == 1)
                {
                    objInventoryCoupnRules.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventoryCoupnRules.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository: Error:]", ex.Message);
            }
            return objInventoryCoupnRules;
        }
        public Inventory_Rental_InfoClasss executeRentalInfoRep(Inventory_Rental_InfoClasss objRentalInfo)
        {
            try
            {
                if (objRentalInfo.quryFlage == "delete")
                {
                    result = sqlServerRepost.ExecuteNonQuery("delete from Inventory_Rental_Info where ItemNum = '" + objRentalInfo.ItemNum + "'");
                }

                else if (objRentalInfo.quryFlage == "insert")
                {
                    result = sqlServerRepost.ExecuteNonQuery("");
                }
                if (result == 1)
                {
                    objRentalInfo.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objRentalInfo.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository: Error:]", ex.Message);
            }
            return objRentalInfo;
        }
        public InventoryClass insertInventoryRep(InventoryClass objInventoryClass)
        {
            try
            {
               int result = sqlServerRepost.ExecuteNonQuery("INSERT INTO Inventory "+
           "(ItemNum, "+ 
           "ItemName, "+ 
           "Store_ID, "+
           "Cost, "+ 
           "Price, "+ 
           "Retail_Price, "+ 
           "In_Stock, "+ 
           "Reorder_Level, "+ 
           "Reorder_Quantity, "+ 
           "Tax_1, "+ 
           "Tax_2, "+ 
           "Tax_3, "+ 
           "Vendor_Number, "+ 
           "Dept_ID, "+ 
           "IsKit, "+ 
           "IsModifier, "+ 
           "Kit_Override, "+ 
           "Inv_Num_Barcode_Labels, "+ 
           "Use_Serial_Numbers, "+ 
           "Num_Bonus_Points, "+ 
           "IsRental, "+ 
           "Use_Bulk_Pricing, "+ 
           "Print_Ticket, "+ 
           "Print_Voucher, "+ 
           "Num_Days_Valid, "+ 
           "IsMatrixItem, "+ 
           "Vendor_Part_Num, "+ 
           "Location, "+ 
           "AutoWeigh, "+ 
           "numBoxes, "+ 
           "Dirty, "+ 
           "Tear, "+ 
           "NumPerCase, "+ 
           "FoodStampable, "+ 
           "ReOrder_Cost, "+ 
           "Helper_ItemNum, "+ 
           "ItemName_Extra, "+ 
           "Exclude_Acct_Limit, "+ 
           "Check_ID, "+ 
           "Old_InStock, "+ 
           "Date_Created, "+ 
           "ItemType, "+ 
           "Prompt_Price, "+ 
           "Prompt_Quantity, "+ 
           "Inactive, "+ 
           "Allow_BuyBack, "+ 
           "Last_Sold, "+ 
           "Unit_Type, "+ 
           "Unit_Size, "+ 
           "Fixed_Tax, "+ 
           "DOB, "+ 
           "Special_Permission, "+ 
           "Prompt_Description, "+ 
           "Check_ID2, "+ 
           "Count_This_Item, "+ 
           "Transfer_Cost_Markup, "+ 
           "Print_On_Receipt, "+ 
           "Transfer_Markup_Enabled, "+ 
           "As_Is, "+ 
           "InStock_Committed, "+ 
           "RequireCustomer, "+ 
           "PromptCompletionDate, "+ 
           "PromptInvoiceNotes, "+ 
           "Prompt_DescriptionOverDollarAmt, "+ 
           "Exclude_From_Loyalty, "+ 
           "BarTaxInclusive, "+ 
           "ScaleSingleDeduct, "+ 
           "GLNumber, "+ 
           "ModifierType, "+ 
           "Position, "+ 
           "numberOfFreeToppings, "+ 
           "ScaleItemType, "+ 
           "DiscountType, "+ 
           "AllowReturns, "+ 
           "SuggestedDeposit, "+ 
           "Liability, "+ 
           "IsDeleted, "+ 
           "ItemLocale, "+ 
           "QuantityRequired, "+ 
           "AllowOnDepositInvoices, "+ 
           "Import_Markup, "+ 
           "PricePerMeasure, "+ 
           "UnitMeasure, "+ 
           "ShipCompliantProductType, "+ 
           "AlcoholContent, "+ 
           "AvailableOnline, "+ 
           "AllowOnFleetCard, "+ 
           "DoughnutTax, "+ 
           "DisplayTaxInPrice, "+ 
           "NeverPrintInKitchen) "+
     "VALUES "+
           "('"+ objInventoryClass.ItemNum +"', "+
           "'"+ objInventoryClass.ItemName +"', "+
           "'"+ objInventoryClass.Store_ID +"', "+
           "'"+ objInventoryClass.Cost +"', "+
           "'"+ objInventoryClass.Price +"', "+
           "'"+ objInventoryClass.Retail_Price +"', "+
           "'"+ objInventoryClass.In_Stock +"', "+
           "'"+ objInventoryClass.Reorder_Level +"', "+
           "'"+ objInventoryClass.Reorder_Quantity +"', "+
           "'"+ objInventoryClass.Tax_1 +"', "+
           "'"+ objInventoryClass.Tax_2 +"', "+
           "'"+ objInventoryClass.Tax_3 +"', "+
           "'"+ objInventoryClass.Vendor_Number +"', "+
           "'"+ objInventoryClass.Dept_ID +"', "+
           "'"+ objInventoryClass.IsKit +"', "+
           "'"+ objInventoryClass.IsModifier +"', "+
           "'"+ objInventoryClass.Kit_Override +"', "+
           "'"+ objInventoryClass.Inv_Num_Barcode_Labels +"', "+
           "'"+ objInventoryClass.Use_Serial_Numbers +"', "+
           "'"+ objInventoryClass.Num_Bonus_Points +"', "+
           "'"+ objInventoryClass.IsRental +"', "+
           "'"+ objInventoryClass.Use_Bulk_Pricing +"', "+
           "'"+ objInventoryClass.Print_Ticket +"', "+
           "'"+ objInventoryClass.Print_Voucher +"', "+
           "'"+ objInventoryClass.Num_Days_Valid +"', "+
           "'"+ objInventoryClass.IsMatrixItem +"', "+
           "'"+ objInventoryClass.Vendor_Part_Num +"', "+
           "'"+ objInventoryClass.Location +"', "+
           "'"+ objInventoryClass.AutoWeigh +"', "+
           "'"+ objInventoryClass.numBoxes +"', "+
           "'"+ objInventoryClass.Dirty +"', "+
           "'"+ objInventoryClass.Tear +"', "+
           "'"+ objInventoryClass.NumPerCase +"', "+
           "'"+ objInventoryClass.FoodStampable +"', "+
           "'"+ objInventoryClass.ReOrder_Cost +"', "+
           "'"+ objInventoryClass.Helper_ItemNum +"', "+
           "'"+ objInventoryClass.ItemName_Extra +"', "+
           "'"+ objInventoryClass.Exclude_Acct_Limit +"', "+
           "'"+ objInventoryClass.Check_ID +"', "+
           "'"+ objInventoryClass.Old_InStock +"', "+
           "'"+ objInventoryClass.Date_Created +"', "+
           "'"+ objInventoryClass.ItemType +"', "+
           "'"+ objInventoryClass.Prompt_Price +"', "+
           "'"+ objInventoryClass.Prompt_Quantity +"', "+
           "'"+ objInventoryClass.Inactive +"', "+
           "'"+ objInventoryClass.Allow_BuyBack +"', "+
           "'"+ objInventoryClass.Last_Sold +"', "+
           "'"+ objInventoryClass.Unit_Type +"', "+
           "'"+ objInventoryClass.Unit_Size +"', "+
           "'"+ objInventoryClass.Fixed_Tax +"', "+
           "'"+ objInventoryClass.DOB +"', "+
           "'"+ objInventoryClass.Special_Permission +"', "+
           "'"+ objInventoryClass.Prompt_Description +"', "+
           "'"+ objInventoryClass.Check_ID2 +"', "+
           "'"+ objInventoryClass.Count_This_Item +"', "+
           "'"+ objInventoryClass.Transfer_Cost_Markup +"', "+
           "'"+ objInventoryClass.Print_On_Receipt +"', "+
           "'"+ objInventoryClass.Transfer_Markup_Enabled +"', "+
           "'"+ objInventoryClass.As_Is +"', "+
           "'"+ objInventoryClass.InStock_Committed +"', "+
           "'"+ objInventoryClass.RequireCustomer +"', "+
           "'"+ objInventoryClass.PromptCompletionDate +"', "+
           "'"+ objInventoryClass.PromptInvoiceNotes +"', "+
           "'"+ objInventoryClass.Prompt_DescriptionOverDollarAmt +"', "+
           "'"+ objInventoryClass.Exclude_From_Loyalty +"', "+
           "'"+ objInventoryClass.BarTaxInclusive +"', "+
           "'"+ objInventoryClass.ScaleSingleDeduct +"', "+
           "'"+ objInventoryClass.GLNumber +"', "+
           "'"+ objInventoryClass.ModifierType +"', "+
           "'"+ objInventoryClass.Position +"', "+
           "'"+ objInventoryClass.numberOfFreeToppings +"', "+
           "'"+ objInventoryClass.ScaleItemType +"', "+
           "'"+ objInventoryClass.DiscountType +"', "+
           "'"+ objInventoryClass.AllowReturns +"', "+
           "'"+ objInventoryClass.SuggestedDeposit +"', "+
           "'"+ objInventoryClass.Liability +"', "+
           "'"+ objInventoryClass.IsDeleted +"', "+
           "'"+ objInventoryClass.ItemLocale +"', "+
           "'"+ objInventoryClass.QuantityRequired +"', "+
           "'"+ objInventoryClass.AllowOnDepositInvoices +"', "+
           "'"+ objInventoryClass.Import_Markup +"', "+
           "'"+ objInventoryClass.PricePerMeasure +"', "+
           "'"+ objInventoryClass.UnitMeasure +"', "+
           "'"+ objInventoryClass.ShipCompliantProductType +"', "+
           "'"+ objInventoryClass.AlcoholContent +"', "+
           "'"+ objInventoryClass.AvailableOnline +"', "+
           "'"+ objInventoryClass.AllowOnFleetCard +"', "+
           "'"+ objInventoryClass.DoughnutTax +"', "+
           "'"+ objInventoryClass.DisplayTaxInPrice +"', "+
           "'"+ objInventoryClass.NeverPrintInKitchen +"')");
                if (result == 1)
                {
                    objInventoryClass.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objInventoryClass.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository: Error:]", ex.Message);
            }
            return objInventoryClass;
        }
        #endregion






 
    }
}

