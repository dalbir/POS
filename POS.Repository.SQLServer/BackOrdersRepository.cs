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
  public  class BackOrdersRepository
    {
      SQLServerRepository objSQLServerRepository = new SQLServerRepository();
      public BackOrdersClass LoadBackOrdersData(BackOrdersClass objBackOrdersClass)
      {
          if (objBackOrdersClass.flage == "LoadBackOrderesGrid")
          {
              objBackOrdersClass.LoadOrderes = objSQLServerRepository.GetDataTable("SELECT ROW_NUMBER() OVER(ORDER BY BoNum DESC) AS Line_number, * FROM view_BackOrderes where Status='"+objBackOrdersClass.Status+"'");
//              objBackOrdersClass.LoadOrderes = objSQLServerRepository.GetDataTable(@"SELECT ROW_NUMBER() OVER(ORDER BY BoNum DESC) AS Line_number,
//	            case [Type] when 'BO' then 'NO' else  'YES' END as TypeNew
//	           ,BONum,[DateTime],CustNum,ItemNum,ItemName,Quan,In_Stock,Invoice_Number,[Status] FROM view_BackOrderes");
          }
          if (objBackOrdersClass.flage == "LoadFBOrders")
          {
              objBackOrdersClass.LoadOrderes = objSQLServerRepository.GetDataTable("SELECT ROW_NUMBER() OVER(ORDER BY BoNum DESC) AS Line_number, * FROM view_BackOrderes where Status='"+ objBackOrdersClass.Status +"'");
          }
          if (objBackOrdersClass.flage == "SearchBObyItem")
          {
              objBackOrdersClass.LoadOrderes = objSQLServerRepository.GetDataTable("SELECT ROW_NUMBER() OVER(ORDER BY BoNum DESC) AS Line_number, * FROM view_BackOrderes where ItemNum like '" + objBackOrdersClass.ItemNum + "%'");
          }
          if (objBackOrdersClass.flage == "SearchBObyCustomer")
          {
              objBackOrdersClass.LoadOrderes = objSQLServerRepository.GetDataTable("SELECT ROW_NUMBER() OVER(ORDER BY BoNum DESC) AS Line_number, * FROM view_BackOrderes where CustNum like '" + objBackOrdersClass.CustNum + "%'");
          }
          return objBackOrdersClass;
      }
      string strStatus;
      public string SelectBackOrdersInfo(BackOrdersClass objBackOrdersClass)
      {
          try
          {
              if (objBackOrdersClass.flage == "getstatus")
              {
                  strStatus = objSQLServerRepository.ExecuteScalar("SELECT Status FROM BackOrders WHERE BONum='" + objBackOrdersClass.BONum + "'");
              }
              else if (objBackOrdersClass.flage == "gettype")
              {
                  strStatus = objSQLServerRepository.ExecuteScalar("SELECT Type FROM BackOrders WHERE BONum='" + objBackOrdersClass.BONum + "'");
              }
              //else if (objBackOrdersClass.flage == "getStock")
              //{
              //    strStatus = objSQLServerRepository.ExecuteScalar("SELECT In_Stock FROM Inventory WHERE ItemNum='" + objBackOrdersClass.ItemNum + "'");
              //}
          }
          catch (Exception)
          {

          }
          return strStatus;
      }
//      public DataTable LoadBackOrdersData1(BackOrdersClass objBackOrdersClass)
//      {
//          DataTable dt = new DataTable();
//          if (objBackOrdersClass.flage == "LoadBackOrderesGrid")
//          {
//              dt = objSQLServerRepository.GetDataTable(@"SELECT ROW_NUMBER() OVER(ORDER BY BoNum DESC) AS Line_number,
//	case [Type] when 'BO' then 'NO' else  'YES' END as TypeNew
//	 ,BONum,[DateTime],CustNum,ItemNum,ItemName,Quan,In_Stock,Invoice_Number FROM view_BackOrderes");
//          }
//          if (objBackOrdersClass.flage == "LoadFBOrders")
//          {
//              dt = objSQLServerRepository.GetDataTable("SELECT ROW_NUMBER() OVER(ORDER BY BoNum DESC) AS Line_number, * FROM view_BackOrderes where Status='" + objBackOrdersClass.Status + "'");
//          }
//          return dt;
//      }
      public BackOrdersClass DeleteBackOrderes(BackOrdersClass objBackOrdersClass)
      {
          try
          {
              if (objBackOrdersClass.flage == "DeleteOrders")
              {
                  objSQLServerRepository.ExecuteNonQuery("DELETE FROM BackOrders WHERE BONum='" + objBackOrdersClass.BONum + "'");
              }
          }
          catch (Exception ex)
          {
              CustomLogging.Log("[Error]", ex.Message);
          }
          return objBackOrdersClass;
      }
      public BackOrdersClass FillBackOrders(BackOrdersClass objBackOrdersClass)
      {
          try
          {
              if (objBackOrdersClass.flage == "updateStatus")
              {
                  objSQLServerRepository.ExecuteNonQuery("UPDATE BackOrders SET Status='" + objBackOrdersClass.Status + "',FillDate='" + objBackOrdersClass.FillDate + "' WHERE BONum='" + objBackOrdersClass.BONum + "'");
              }
              else if (objBackOrdersClass.flage == "UpdateInstock")
              {
                  objSQLServerRepository.ExecuteNonQuery("UPDATE Inventory SET In_Stock='" + objBackOrdersClass.Quan + "' WHERE ItemNum='" + objBackOrdersClass.ItemNum + "'");
              }
          }
          catch (Exception ex)
          {
              CustomLogging.Log("[Error]", ex.Message);
          }
          return objBackOrdersClass;
      }
    }
}
