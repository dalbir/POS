using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Common;
using POS.Repository.SQLServer;
using System.Data;

namespace POS.Repository.SQLServer
{
   public class MixNMatchRepository
    {
       SQLServerRepository objSQLServerRepository = new SQLServerRepository();
        public Inventory_OnSale_InfoClass insertOnsaleInfo(Inventory_OnSale_InfoClass objIvnOnsaleInfo)
        {
            try
            {
                //insertion in inventory onsale info
                objSQLServerRepository.ExecuteNonQuery("delete from Inventory_OnSale_Info where ItemNum = '" + objIvnOnsaleInfo.ItemNum + "'");
                int result = objSQLServerRepository.ExecuteNonQuery("insert into Inventory_OnSale_Info(ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], Price, SalePriceType) values('"+ objIvnOnsaleInfo.ItemNum +"', '"+ objIvnOnsaleInfo.Store_ID +"','"+ objIvnOnsaleInfo.Sale_Start +"','"+ objIvnOnsaleInfo.Sale_End +"', '"+ objIvnOnsaleInfo.Percent +"', '"+ objIvnOnsaleInfo.Price +"', '"+ objIvnOnsaleInfo.SalePriceType +"')");
                //insertion in Inventory_Reference
                string checkRecord = objSQLServerRepository.ExecuteScalar("select ItemNum from Inventory_Reference where ItemNum = '" + objIvnOnsaleInfo.ItemNum + "'");
                if (checkRecord != null)
                {
                    int nextID = Convert.ToInt32(objSQLServerRepository.ExecuteScalar("select MAX(ID)+ 1 from Inventory_Reference"));
                    int res = objSQLServerRepository.ExecuteNonQuery("insert into Inventory_Reference(ID, ItemNum, Store_ID) values('"+ nextID +"', '" + objIvnOnsaleInfo.ItemNum + "', '" + objIvnOnsaleInfo.Store_ID + "')");
                }
            }
            catch(Exception ex)
            {

            }
            return objIvnOnsaleInfo;
        }

        public Kit_IndexClass insertItemsInKitIndex(Kit_IndexClass objKitIndex)
        {
           try
           {
               if (objKitIndex.quryFlage == "delete")
               {
                   objSQLServerRepository.ExecuteNonQuery("delete from Kit_Index where Kit_ID = '" + objKitIndex.Kit_ID + "' and Store_ID = '" + objKitIndex.Store_ID + "'");
                   objKitIndex.quryFlage = "";
               }
               int result = objSQLServerRepository.ExecuteNonQuery("insert into Kit_Index(Kit_ID, Store_ID, ItemNum, Discount, Quantity) values('" + objKitIndex.Kit_ID + "', '" + objKitIndex.Store_ID + "', '" + objKitIndex.ItemNum + "', '"+ objKitIndex.Discount +"', '"+ objKitIndex.Quantity +"')");
           }
            catch(Exception ex)
           {

           }
           return objKitIndex;
        }

        public Inventory_MixNMatch_LevelsClass insertDiscountLevel(Inventory_MixNMatch_LevelsClass objMixNMatchLevel)
        {
           try
           {
               if (objMixNMatchLevel.qryFlage == "delete")
               {
                   objSQLServerRepository.ExecuteNonQuery("delete from Inventory_MixNMatch_Levels where ItemNum = '" + objMixNMatchLevel.ItemNum + "' and Store_ID = '" + objMixNMatchLevel.Store_ID + "'");
                   objMixNMatchLevel.qryFlage = "";
               }
               int result = objSQLServerRepository.ExecuteNonQuery("insert into Inventory_MixNMatch_Levels(ItemNum, Store_ID, Amount, Quantity) values('"+ objMixNMatchLevel.ItemNum +"', '"+ objMixNMatchLevel.Store_ID +"', '"+ objMixNMatchLevel.Amount +"', '"+ objMixNMatchLevel.Quantity +"')");
           }
            catch(Exception ex)
           {

           }
           return objMixNMatchLevel;
        }

        public Inventory_BumpBarSettingsClass insertBumpBarSetting(Inventory_BumpBarSettingsClass objBumpBarSetting)
        {
            try
            {
                objSQLServerRepository.ExecuteNonQuery("delete from Inventory_BumpBarSettings where ItemNum = '"+ objBumpBarSetting.ItemNum +"' and Store_ID = '"+ objBumpBarSetting.Store_ID +"'");
                int result = objSQLServerRepository.ExecuteNonQuery("insert into Inventory_BumpBarSettings(Store_ID, ItemNum, Backcolor, Forecolor) values('"+ objBumpBarSetting.Store_ID +"', '"+ objBumpBarSetting.ItemNum +"', '"+ objBumpBarSetting.Backcolor +"', '"+ objBumpBarSetting.Forecolor +"')");
            }
            catch(Exception ex)
            {

            }
            return objBumpBarSetting;
        }

        public Inventory_AdditionalInfoClass insertAdditionalInfo(Inventory_AdditionalInfoClass objinvAdditionalInfo)
        {
            try
            {
                objSQLServerRepository.ExecuteNonQuery("delete from Inventory_AdditionalInfo where ItemNum = '"+ objinvAdditionalInfo.ItemNum +"' and Store_ID = '"+ objinvAdditionalInfo.Store_ID +"'");
                int result = objSQLServerRepository.ExecuteNonQuery("INSERT INTO Inventory_AdditionalInfo " +
                           "(Store_ID, " +
                           "ItemNum, " +
                           "ExtendedDescription, " +
                           "Keywords, " +
                           "Brand, " +
                           "Theme, " +
                           "SubCategory, " +
                           "LeadTime, " +
                           "ProductOnPromotionPreOrder, " +
                           "ProductOnSpecialOffer, " +
                           "NewProduct, " +
                           "Discountable, " +
                           "WebPrice, " +
                           "ReleaseDate, " +
                           "Weight, " +
                           "NoWebSales, " +
                           "IsPrimaryMatrixItem, " +
                           "Priority, " +
                           "Rating, " +
                           "CustomNumber1, " +
                           "CustomNumber2, " +
                           "CustomNumber3, " +
                           "CustomNumber4, " +
                           "CustomNumber5, " +
                           "CustomText1, " +
                           "CustomText2, " +
                           "CustomText3, " +
                           "CustomText4, " +
                           "CustomText5, " +
                           "CustomExtendedText1, " +
                           "CustomExtendedText2, " +
                           "SubDescription1, " +
                           "SubDescription2, " +
                           "SubDescription3)" +
                     "VALUES" +
                           "('" +objinvAdditionalInfo.Store_ID + "'," +
                           "'" +objinvAdditionalInfo.ItemNum + "'," +
                           "'" +objinvAdditionalInfo.ExtendedDescription + "'," +
                           "'" +objinvAdditionalInfo.Keywords + "'," +
                           "'" +objinvAdditionalInfo.Brand + "'," +
                           "'" +objinvAdditionalInfo.Theme + "'," +
                           "'" +objinvAdditionalInfo.SubCategory + "'," +
                           "'" +objinvAdditionalInfo.LeadTime + "'," +
                           "'" +objinvAdditionalInfo.ProductOnPromotionPreOrder + "'," +
                           "'" +objinvAdditionalInfo.ProductOnSpecialOffer + "'," +
                           "'" +objinvAdditionalInfo.NewProduct + "'," +
                           "'" +objinvAdditionalInfo.Discountable + "'," +
                           "'" +objinvAdditionalInfo.WebPrice + "'," +
                           "'" +objinvAdditionalInfo.ReleaseDate + "'," +
                           "'" +objinvAdditionalInfo.Weight + "'," +
                           "'" +objinvAdditionalInfo.NoWebSales + "'," +
                           "'" +objinvAdditionalInfo.IsPrimaryMatrixItem + "'," +
                           "'" +objinvAdditionalInfo.Priority + "'," +
                           "'" +objinvAdditionalInfo.Rating + "'," +
                           "'" +objinvAdditionalInfo.CustomNumber1 + "'," +
                           "'" +objinvAdditionalInfo.CustomNumber2 + "'," +
                           "'" +objinvAdditionalInfo.CustomNumber3 + "'," +
                           "'" +objinvAdditionalInfo.CustomNumber4 + "'," +
                           "'" +objinvAdditionalInfo.CustomNumber5 + "'," +
                           "'" +objinvAdditionalInfo.CustomText1 + "'," +
                           "'" +objinvAdditionalInfo.CustomText2 + "'," +
                           "'" +objinvAdditionalInfo.CustomText3 + "'," +
                           "'" +objinvAdditionalInfo.CustomText4 + "'," +
                           "'" +objinvAdditionalInfo.CustomText5 + "'," +
                           "'" +objinvAdditionalInfo.CustomExtendedText1 + "'," +
                           "'" +objinvAdditionalInfo.CustomExtendedText2 + "'," +
                           "'" +objinvAdditionalInfo.SubDescription1 + "'," +
                           "'" +objinvAdditionalInfo.SubDescription2 + "'," +
                           "'" +objinvAdditionalInfo.SubDescription3 + "')");
            }
            catch (Exception ex)
            {
 
            }
            return objinvAdditionalInfo;

        }

        public Setup_TS_ButtonsClass insertSetupTsButtons(Setup_TS_ButtonsClass objSetupTsButtons)
        {
            try
            {
                objSQLServerRepository.ExecuteNonQuery("delete from Setup_TS_Buttons where Ident = '"+ objSetupTsButtons.Ident +"' and Store_ID = '"+ objSetupTsButtons.Store_ID +"'");
                int result = objSQLServerRepository.ExecuteNonQuery("INSERT INTO Setup_TS_Buttons"+
                                                                    "(Store_ID,"+
                                                                   "Station_ID,"+
                                                                   "[Index],"+
                                                                   "Caption,"+
                                                                   "Picture,"+
                                                                   "[Function],"+
                                                                   "Option1,"+
                                                                   "BackColor,"+
                                                                   "ForeColor,"+
                                                                   "Visible,"+
                                                                   "BtnType,"+
                                                                   "Ident,"+
                                                                   "ScheduleIndex,"+
                                                                   "Option2,"+
                                                                   "Option3,"+
                                                                   "Option4)"+
                                                             "VALUES" +
                                                                   "('"+objSetupTsButtons.Store_ID+"',"+
                                                                   "'"+objSetupTsButtons.Station_ID+"',"+
                                                                   "'"+objSetupTsButtons.Index+"',"+
                                                                   "'"+objSetupTsButtons.Caption+"',"+
                                                                   "'"+objSetupTsButtons.Picture+"',"+
                                                                   "'"+objSetupTsButtons.Function+"',"+
                                                                   "'"+objSetupTsButtons.Option1+"',"+
                                                                   "'"+objSetupTsButtons.BackColor+"',"+
                                                                   "'"+objSetupTsButtons.ForeColor+"',"+
                                                                   "'"+objSetupTsButtons.Visible+"',"+
                                                                   "'"+objSetupTsButtons.BtnType+"',"+
                                                                   "'"+objSetupTsButtons.Ident+"',"+
                                                                   "'"+objSetupTsButtons.ScheduleIndex+"',"+
                                                                   "'"+objSetupTsButtons.Option2+"',"+
                                                                   "'"+objSetupTsButtons.Option3+"',"+
                                                                   "'"+objSetupTsButtons.Option4+"')");
            }
            catch (Exception ex)
            {
 
            }
            return objSetupTsButtons;
        }
        DataTable dt;
        public DataTable getMixnMatch(int objItemType)
        {
            try
            {
                dt = objSQLServerRepository.GetDataTable("select itemNum, ItemNum + '-' + ItemName as ItemName from inventory where ItemType = " + objItemType + " order by Date_Created desc");
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        DataTable dtData;
        public DataTable retriveDataRep(string ItemNum)
        {
            try
            {
                dtData = objSQLServerRepository.GetDataTable("select * from VIEW_MIXN_MATCH WHERE ItemNum = '"+ ItemNum +"'");
            }
            catch (Exception ex)
            {
            }
            return dtData;
        }
    }
}
