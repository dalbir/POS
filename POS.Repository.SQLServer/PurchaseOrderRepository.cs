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
   public class PurchaseOrderRepository
    {
        int maxId; 
       SQLServerRepository objSQLServerRepository = new SQLServerRepository();
       public PO_SummaryClass insertPosummaryRep(PO_SummaryClass objPOSummaryClass)
        {
            try
            {
                string value = objSQLServerRepository.ExecuteScalar("select isnull(max(PO_Number), 0) + 1 as po_no from PO_Summary");
                if (value != "")
                    objPOSummaryClass.PO_Number = Convert.ToInt32(value);
                int result = objSQLServerRepository.ExecuteNonQuery("insert into PO_Summary(PO_Number,Store_ID,DateTime,Reference,Vendor_Number,Total_Cost,Terms,Due_Date,Ship_Via,ShipTo_1,ShipTo_2,ShipTo_3,ShipTo_4,ShipTo_5,Instructions,Status,Last_Modified,ExpectedAmountToReceive,POType) values('" + objPOSummaryClass.PO_Number + "', '" + objPOSummaryClass.Store_ID + "', '" + objPOSummaryClass.DateTime + "','" + objPOSummaryClass.Reference + "','" + objPOSummaryClass.Vendor_Number + "','" + objPOSummaryClass.Total_Cost + "','" + objPOSummaryClass.Terms + "','" + objPOSummaryClass.Due_Date + "','" + objPOSummaryClass.Ship_Via + "','" + objPOSummaryClass.ShipTo_1 + "','" + objPOSummaryClass.ShipTo_2 + "','" + objPOSummaryClass.ShipTo_3 + "','" + objPOSummaryClass.ShipTo_4 + "','" + objPOSummaryClass.ShipTo_5 + "','" + objPOSummaryClass.Instructions + "','" + objPOSummaryClass.Status + "','" + objPOSummaryClass.Last_Modified + "','" + objPOSummaryClass.ExpectedAmountToReceive + "','" + objPOSummaryClass.POType + "')");
                if (result == 0)
                {
                    objPOSummaryClass.IsSuccessfull = true;
                }
                else
                {
                    objPOSummaryClass.IsSuccessfull = false;
                }
            }
            catch(Exception ex)
            {

            }
            return objPOSummaryClass;
        }

       public PO_DetailsClass insertPoDetail(PO_DetailsClass objPODetailClass)
       {
           try
           {
               int result = objSQLServerRepository.ExecuteNonQuery("insert into PO_Details(PO_Number,ItemNum,LineNum,Quan_Ordered,CostPer,Quan_Received,CasePack,Store_ID,NumberPerCase,Quan_Damaged,destStore_ID) values('" + objPODetailClass.PO_Number + "', '" + objPODetailClass.ItemNum + "','" + objPODetailClass.LineNum + "','" + objPODetailClass.Quan_Ordered + "','" + objPODetailClass.CostPer + "','" + objPODetailClass.Quan_Received + "','" + objPODetailClass.CasePack + "','"+ objPODetailClass.Store_ID +"','" + objPODetailClass.NumberPerCase + "','" + objPODetailClass.Quan_Damaged + "','" + objPODetailClass.destStore_ID + "')");
               if (result == 0)
               {
                   objPODetailClass.IsSuccessfull = true;
               }
               else
               {
                   objPODetailClass.IsSuccessfull = false;
               }
           }
           catch(Exception ex)
           {

           }
           return objPODetailClass;
       }
       DataTable dtRecords;
       public DataTable GetStoresRep()
       {
           try
           {
               dtRecords = objSQLServerRepository.GetDataTable("select Store_ID, Company_Info_1, Company_Info_2,Company_Info_3 from Setup");
           }
           catch(Exception ex)
           {

           }
           return dtRecords;
       }
       DataTable dt;
       public DataTable getPoDeatil(int po_id)
       {
           
           try
           {
               dt = objSQLServerRepository.GetDataTable("select * from PO_Details where PO_Number = '" + po_id + "' order by LineNum");
           }
           catch (Exception ex)
           {

           }
           return dt;
       }

       DataTable dtt;
       public DataTable getPoSummary(int po_id)
       {
           try
           {
               dtt = objSQLServerRepository.GetDataTable("select * from PO_Summary where PO_Number = '" + po_id + "'");
           }
           catch (Exception ex)
           {

           }
           return dtt;
       }
       DataTable dtPo;
       public DataTable getPoSummayByType(PO_SummaryClass objPoSummaryClass)
       {
           try
           {
               dtPo = objSQLServerRepository.GetDataTable("select * from PO_Summary where Status = '" + objPoSummaryClass.Status + "' and POType = '" + objPoSummaryClass.POType + "'");
           }
           catch (Exception ex)
           {

           }
           return dtPo;
       }

       public PO_SummaryClass updatePoSummaryRep(PO_SummaryClass objPoSummaryClass)
       {
           try
           {
               if (objPoSummaryClass.qryFlage == 1)
               {
                   int result = objSQLServerRepository.ExecuteNonQuery("update PO_Summary set " +
                           "Reference = '" + objPoSummaryClass.Reference + "' , " +
                           "Vendor_Number = '" + objPoSummaryClass.Vendor_Number + "', " +
                           "Total_Cost = '" + objPoSummaryClass.Total_Cost + "', " +
                           "Terms = '" + objPoSummaryClass.Terms + "', " +
                           "Due_Date = '" + objPoSummaryClass.Due_Date + "', " +
                           "Ship_Via = '" + objPoSummaryClass.Ship_Via + "', " +
                           "ShipTo_1 = '" + objPoSummaryClass.ShipTo_1 + "', " +
                           "ShipTo_2 = '" + objPoSummaryClass.ShipTo_2 + "', " +
                           "ShipTo_3 = '" + objPoSummaryClass.ShipTo_3 + "', " +
                           "ShipTo_4 = '" + objPoSummaryClass.ShipTo_4 + "', " +
                           "ShipTo_5 = '" + objPoSummaryClass.ShipTo_5 + "', " +
                           "Instructions = '" + objPoSummaryClass.Instructions + "', " +
                           "Status = '" + objPoSummaryClass.Status + "', " +
                           "Last_Modified = '" + objPoSummaryClass.Last_Modified + "' " +
                           "where PO_Number = '" + objPoSummaryClass.PO_Number + "'");
                   if (result == 0)
                   {
                       objPoSummaryClass.IsSuccessfull = true;
                   }
                   else
                   {
                       objPoSummaryClass.IsSuccessfull = false;
                   }
               }
               else if(objPoSummaryClass.qryFlage == 2)
               {
                   int result = objSQLServerRepository.ExecuteNonQuery("update PO_Summary set " +
                    
                    "Status = '" + objPoSummaryClass.Status + "', " +
                    "Last_Modified = '" + objPoSummaryClass.Last_Modified + "' " +
                    "where PO_Number = '" + objPoSummaryClass.PO_Number + "'");  
               }
           }
           catch (Exception ex)
           {

           }
           return objPoSummaryClass;
       }

       public PO_DetailsClass DeletePoDetails(PO_DetailsClass objPO_DetailsClass)
       {
           try
           {
               int result = objSQLServerRepository.ExecuteNonQuery("delete from PO_Details where PO_Number = '" + objPO_DetailsClass.PO_Number + "'");
               if (result == 0)
               {
                   objPO_DetailsClass.IsSuccessfull = true;
               }
               else
               {
                   objPO_DetailsClass.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {

           }
           return objPO_DetailsClass;
       }
       DataTable dtFileter;
       public DataTable FilterDataRep(string flage, string search)
       {
           try
           {
               string where = "";
               if(flage == "")
               {
                   where = " where 1 = 1";
               }
               else if(flage == "ItemNum")
               {
                   where = "where ItemNum = " + search;
               }
               else if(flage == "ItemName")
               {
                   where = "where ItemName = " + search;
               }
               else if(flage == "Vendor_Number")
               {
                   where = "where Vendor_Number =" + search;
               }
               else if(flage == "Vendor_Part_Num")
               {
                   where = "where Vendor_Part_Num =" + search;
               }
               dtFileter = objSQLServerRepository.GetDataTable("select * from VIEW_INVEN_PURCH_ORDER " + where + "");
           }
           catch(Exception ex)
           {

           }
           return dtFileter;
       }
       DataTable dtVewDetailPo;
       public DataTable viewDetailPo(string id, string ven_id)
       {
           try
           {
               dtVewDetailPo = objSQLServerRepository.GetDataTable("SELECT * FROM VIEW_DETAIL_PO WHERE ItemNum = '" + id + "' and Vendor_Number = '" + ven_id + "'");
           }
           catch(Exception ex)
           {

           }
           return dtVewDetailPo;
       }
    }
}
