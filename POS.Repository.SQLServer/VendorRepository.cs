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
   public class VendorRepository
    {
       SQLServerRepository sqlRepository = new SQLServerRepository();
       // Retriving vendor information for select inventory form
       public VendorsClass RetriveVendor(VendorsClass objRetriveVendor)
       {
           try
           {
               objRetriveVendor.dtVendor = sqlRepository.GetDataTable("select Vendor_Number, First_Name + ' ' + Last_Name as Vendor_name from Vendors");
           }
           catch(Exception)
           {

           }
           return objRetriveVendor;
       }
       //retrive all vendor information
       public VendorsClass RetriveAllVendor(VendorsClass VendorRep)
       {
           try
           {
               VendorRep.dtAllVendor = sqlRepository.GetDataTable("select * from Vendors where Vendor_Number = '" + VendorRep.Vendor_Number + "'");
           }
           catch (Exception)
           {

           }
           return VendorRep;
       }
       // insertion of vendor information from inventory maintenace form
       int result;
       public VendorsClass InsertVendorInfo(VendorsClass VendorRep)
       {
           try
           {
               if (VendorRep.quryFlage == "insert")
               {
                   result = sqlRepository.ExecuteNonQuery("insert into Vendors(" +
                                                                "Vendor_Number, " +
                                                                "First_Name, " +
                                                                "Last_Name, " +
                                                                "Company, " +
                                                                "Address_1, " +
                                                                "Address_2, " +
                                                                "City, " +
                                                                "State, " +
                                                                "Zip_Code, " +
                                                                "Phone, " +
                                                                "Fax, " +
                                                                "Vendor_Tax_ID, " +
                                                                "Vendor_Terms, " +
                                                                "SSN, " +
                                                                "Commission, " +
                                                                "Rent, " +
                                                                "Default_Billable_Department, " +
                                                                "Dirty, " +
                                                                "County, " +
                                                                "Email, " +
                                                                "Website, " +
                                                                "Minimum_Order, " +
                                                                "Default_PO_Delivery)" +
                                                                " values(" +
                                                                "'" + VendorRep.Vendor_Number + "', " +
                                                                "'" + VendorRep.First_Name + "', " +
                                                                "'" + VendorRep.Last_Name + "', " +
                                                                "'" + VendorRep.Company + "', " +
                                                                "'" + VendorRep.Address_1 + "', " +
                                                                "'" + VendorRep.Address_2 + "', " +
                                                                "'" + VendorRep.City + "', " +
                                                                "'" + VendorRep.State + "', " +
                                                                "'" + VendorRep.Zip_Code + "', " +
                                                                "'" + VendorRep.Phone + "', " +
                                                                "'" + VendorRep.Fax + "', " +
                                                                "'" + VendorRep.Vendor_Tax_ID + "', " +
                                                                "'" + VendorRep.Vendor_Terms + "', " +
                                                                "'" + VendorRep.SSN + "', " +
                                                                "'" + VendorRep.Commission + "', " +
                                                                "'" + VendorRep.Rent + "', " +
                                                                "'" + VendorRep.Default_Billable_Department + "', " +
                                                                "'" + VendorRep.Dirty + "', " +
                                                                "'" + VendorRep.County + "', " +
                                                                "'" + VendorRep.Email + "', " +
                                                                "'" + VendorRep.Website + "', " +
                                                                "'" + VendorRep.Minimum_Order + "', " +
                                                                "'" + VendorRep.Default_PO_Delivery + "')");
               }
               else if(VendorRep.quryFlage == "update")
               {
                   result = sqlRepository.ExecuteNonQuery("update Vendors set " +
                      
                       "First_Name = '" + VendorRep.Vendor_Number + "', " +
                       "Last_Name = '" + VendorRep.Last_Name + "', " +
                       "Company = '" + VendorRep.Company + "', " +
                       "Address_1 = '" + VendorRep.Address_1 + "', " +
                       "Address_2 = '" + VendorRep.Address_2 + "', " +
                       "City = '" + VendorRep.City + "', " +
                       "State = '" + VendorRep.State + "', " +
                       "Zip_Code = '" + VendorRep.Zip_Code + "', " +
                       "Phone = '" + VendorRep.Phone + "', " +
                       "Fax = '" + VendorRep.Fax + "', " +
                       "Vendor_Tax_ID = '" + VendorRep.Vendor_Tax_ID + "', " +
                       "Vendor_Terms = '" + VendorRep.Vendor_Terms + "', " +
                       "SSN = '" + VendorRep.SSN + "', " +
                       "Commission = '" + VendorRep.Commission + "', " +
                       "Rent = '" + VendorRep.Rent + "', " +
                       "Default_Billable_Department = '" + VendorRep.Default_Billable_Department + "', " +
                       "Dirty = '" + VendorRep.Dirty + "', " +
                       "County = '" + VendorRep.County + "', " +
                       "Email = '" + VendorRep.Email + "', " +
                       "Website = '" + VendorRep.Website + "', " +
                       "Minimum_Order = '" + VendorRep.Minimum_Order + "', " +
                       "Default_PO_Delivery =  '" + VendorRep.Default_PO_Delivery + "'" +
                       " where Vendor_Number =  '" + VendorRep.Vendor_Number + "'");
               }
               else if(VendorRep.quryFlage == "delete")
               {
                   result = sqlRepository.ExecuteNonQuery("delete from Vendor where Vendor_Number = '" + VendorRep.Vendor_Number + "'");
               }
              
               if (result > 0)
               {
                   VendorRep.IsSuccessfull = true;
               }
               else
               {
                   VendorRep.IsSuccessfull = false;
               }
           }
           catch (Exception)
           {

           }
           return VendorRep;
       }
       DataTable dtGetRocords;
       // get vendors recoreds for search inventory form
       public System.Data.DataTable getVendorRep()
       {
           try
           {
               dtGetRocords = sqlRepository.GetDataTable("select 'ALL RECORDS' as records_comp, 'No vendor' as id_compny union all select Company as records_comp, Vendor_Number as id_compny from Vendors");
           }
           catch(Exception ex)
           {

           }
           return dtGetRocords;
       }
    }
}
