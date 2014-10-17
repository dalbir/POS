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
   public class StylesMatrixRepository
    {
       SQLServerRepository sqlServerRepository = new SQLServerRepository();
       int result;
       string maxID;
       
       public GroupsClass LoadvendorsInfo(GroupsClass objGroupsClass)
       {
           try
           {
               if (objGroupsClass.flage == "loadVindors")
               {
                   objGroupsClass.LoadGroupData = sqlServerRepository.GetDataTable("SELECT Vendor_number,Company FROM Vendors");
               }
               else if (objGroupsClass.flage == "fillList")
               {
                   objGroupsClass.LoadGroupData = sqlServerRepository.GetDataTable("SELECT Group_ID FROM Groups");
               }
               else if (objGroupsClass.flage == "LoadGroupsToTextBoxes")
               {
                   objGroupsClass.LoadGroupData = sqlServerRepository.GetDataTable("SELECT * FROM Groups WHERE Group_ID='" + objGroupsClass.Group_ID+ "'");
               }
               else if (objGroupsClass.flage == "SelectStyle")
               {
                   objGroupsClass.LoadGroupData = sqlServerRepository.GetDataTable("SELECT Group_ID,Group_ID+'-'+Description as stlname FROM Groups WHERE isDeleted='False'");
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objGroupsClass;
 
       }
       public string GetMaxGroupRefrnceID(Groups_ReferenceClass objGroups_ReferenceClass)
       {
           try
           {
               maxID = sqlServerRepository.ExecuteScalar("select isnull(max(ID),0)+1 from Groups_Reference");
           }
           catch (Exception)
           {

           }
           return maxID;
       }
       string GroupsIDs;
       public string ReadGroupID(GroupsClass objGroupsClass)
       {
           if (objGroupsClass.flage == "ReadGroup")
           {
               GroupsIDs = sqlServerRepository.ExecuteScalar("SELECT Group_ID FROM Groups where Group_ID='" + objGroupsClass.Group_ID + "' ");

           }
           return GroupsIDs;
       }
       public GroupsClass GroupsInfo(GroupsClass objGroupsClass)
       {
           try
           {
               if (objGroupsClass.flage == "insert")
               {

                   result = sqlServerRepository.ExecuteNonQuery("INSERT INTO Groups(Group_ID,Store_ID, "+
                   "Description,ItemNumPrefix,Cost,Price,Tax_1,Tax_2,Tax_3,Dim_1_Name,Dim_2_Name,Dept_ID, "+
                   "Vendor_Number,AutoGenerate,isDeleted) VALUES( "+
                   "'"+ objGroupsClass.Group_ID +"', "+
                   "'"+objGroupsClass.Store_ID+"', "+
                   "'"+objGroupsClass.Description+"', "+
                   "'"+objGroupsClass.ItemNumPrefix+"', "+
                   "'"+ objGroupsClass.Cost +"', "+
                   "'"+ objGroupsClass.Price +"', "+
                   "'"+ objGroupsClass.Tax_1 +"', "+
                   "'"+ objGroupsClass.Tax_2 +"', "+
                   "'"+ objGroupsClass.Tax_3 +"', "+
                   "'"+ objGroupsClass.Dim_1_Name +"', "+
                   "'"+ objGroupsClass.Dim_2_Name +"', "+
                   "'"+ objGroupsClass.Dept_ID +"', "+
                   "'"+ objGroupsClass.Vendor_Number +"', "+
                   "'"+ objGroupsClass.AutoGenerate +"', "+
                   "'"+ objGroupsClass.isDeleted +"')");
               }
               else if (objGroupsClass.flage == "update")
               {
                   result = sqlServerRepository.ExecuteNonQuery("UPDATE Groups SET " +
                   "Store_ID ='" + objGroupsClass.Store_ID + "', " +
                   "Description='" + objGroupsClass.Description + "', " +
                   "ItemNumPrefix='" + objGroupsClass.ItemNumPrefix + "', " +
                   "Cost='" + objGroupsClass.Cost + "', " +
                   "Price='" + objGroupsClass.Price + "', " +
                   "Tax_1='" + objGroupsClass.Tax_1 + "', " +
                   "Tax_2='" + objGroupsClass.Tax_2 + "', " +
                   "Tax_3='" + objGroupsClass.Tax_3 + "', " +
                   "Dim_1_Name='" + objGroupsClass.Dim_1_Name + "', " +
                   "Dim_2_Name='" + objGroupsClass.Dim_2_Name + "', " +
                   "Dept_ID='" + objGroupsClass.Dept_ID + "', " +
                   "Vendor_Number='" + objGroupsClass.Vendor_Number + "', " +
                   "AutoGenerate='" + objGroupsClass.AutoGenerate + "', " +
                   "isDeleted='" + objGroupsClass.isDeleted + "' WHERE "+
                   "Group_ID='"+ objGroupsClass.Group_ID +"'");
               }
               else if (objGroupsClass.flage == "delete")
               {
                   result = sqlServerRepository.ExecuteNonQuery("UPDATE Groups SET isDeleted='" + objGroupsClass.isDeleted + "' WHERE Group_ID='"+ objGroupsClass.Group_ID +"'");
               }
               if (result > 0)
               {
                   objGroupsClass.IsSuccessfull = true;
               }
               else
               {
                   objGroupsClass.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objGroupsClass;
       }
       public Groups_ReferenceClass GroupsReferenceInfo(Groups_ReferenceClass objGroups_ReferenceClass)
       {
           try
           {
               if (objGroups_ReferenceClass.flage == "insert")
               {

                   result = sqlServerRepository.ExecuteNonQuery("INSERT INTO Groups_Reference(ID,Group_ID,Store_ID) "+
                   "values('"+ objGroups_ReferenceClass.ID +"', "+
                   "'"+ objGroups_ReferenceClass.Group_ID +"', "+
                   "'"+ objGroups_ReferenceClass.Store_ID +"')");
               }
               else if (objGroups_ReferenceClass.flage == "update")
               {
                   result = sqlServerRepository.ExecuteNonQuery("");
               }
               else if (objGroups_ReferenceClass.flage == "delete")
               {
                   result = sqlServerRepository.ExecuteNonQuery("DELETE FROM Groups_Reference WHERE Group_ID='" + objGroups_ReferenceClass.Group_ID + "'");
               }
               if (result > 0)
               {
                   objGroups_ReferenceClass.IsSuccessfull = true;
               }
               else
               {
                   objGroups_ReferenceClass.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[Error]", ex.Message);
           }
           return objGroups_ReferenceClass;
       }

    }
}
