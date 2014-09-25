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
   public class TaxRepository
    {

        public Tax_RateClass GetTaxRates(Tax_RateClass objTaxRate)
        {
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                objTaxRate.dtTaxRates = objSqlRep.GetDataTable("select Store_ID, Tax1_Rate,Tax1_Name,Tax2_Rate,Tax2_Name,Tax3_Rate,Tax3_Name,Tax2OnTax1,Tax2Threshold from Tax_Rate where Store_ID = '"+ objTaxRate.Store_ID +"'");
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return objTaxRate;
        }
        DataTable dt;
        public System.Data.DataTable GetTaxRateAreas(Tax_Rate_AreasClass objTaxRateAreas)
        {
           
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                dt = objSqlRep.GetDataTable("SELECT Tax_Rate_ID, Area, [Description],Percent1*100  as per  FROM Tax_Rate_Areas");
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return dt;
        }
       // update tax Rates
        public Tax_RateClass updateTaxRateRep(Tax_RateClass objTaxRates)
        {
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                int result = objSqlRep.ExecuteNonQuery("update Tax_Rate set Tax1_Rate = '" + objTaxRates.Tax1_Rate + "',Tax1_Name = '" + objTaxRates.Tax1_Name + "',Tax2_Rate = '" + objTaxRates.Tax2_Rate + "',Tax2_Name = '" + objTaxRates.Tax2_Name + "',Tax3_Rate = '" + objTaxRates.Tax3_Rate + "',Tax3_Name = '" + objTaxRates.Tax3_Name + "',Tax2OnTax1 = '" + objTaxRates.Tax2OnTax1 + "',Tax2Threshold = '" + objTaxRates.Tax2Threshold + "' where Store_ID = '" + objTaxRates.Store_ID + "'");
                if (result > 0)
                {
                    objTaxRates.IsSuccessfull = true;
                }
                else
                {
                    objTaxRates.IsSuccessfull = false;
                }
            }
            catch (Exception)
            {

            }
            return objTaxRates;
        }
        string result;
        public string GetMaxTaxIDRep()
        {
           
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                result = objSqlRep.ExecuteScalar("select isnull(max(Tax_Rate_ID), 0) + 1 as tax_id from Tax_Rate_Areas");
               
            }
            catch (Exception)
            {

            }
            return result;
        }
       // repository insertion of tax rates arreas
        public Tax_Rate_AreasClass insertTaxAreras(Tax_Rate_AreasClass objTaxRatesAreras)
        {
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                int result = objSqlRep.ExecuteNonQuery("insert into Tax_Rate_Areas(Tax_Rate_ID,Area,Description,Percent1) values('" + objTaxRatesAreras.Tax_Rate_ID + "','" + objTaxRatesAreras.Area + "','" + objTaxRatesAreras.Description + "','" + objTaxRatesAreras.Percent1 + "')");
                if (result == 1)
                {
                    objTaxRatesAreras.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objTaxRatesAreras.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
            return objTaxRatesAreras;
        }
        public Tax_Rate_AreasClass ChangeTaxRatesAreasRep(Tax_Rate_AreasClass objTaxRatesAreas)
        {
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                int result = objSqlRep.ExecuteNonQuery("update Tax_Rate_Areas set Percent1 = '" + objTaxRatesAreas.Percent1 + "' where Tax_Rate_ID = '" + objTaxRatesAreas.Tax_Rate_ID + "'");
                if (result == 1)
                {
                    objTaxRatesAreas.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objTaxRatesAreas.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
            return objTaxRatesAreas;
        }
        public Tax_Rate_AreasClass DeleteTaxRates(Tax_Rate_AreasClass objDeleteTaxRates)
        {
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                int result = objSqlRep.ExecuteNonQuery("delete from Tax_Rate_Areas where Tax_Rate_ID ='" + objDeleteTaxRates.Tax_Rate_ID + "'");
                if (result == 1)
                {
                    objDeleteTaxRates.IsSuccessfull = true;
                    //ObjUpdateDrverNaFlageInB.Message = "Process executed successfully.";
                }
                else
                {
                    objDeleteTaxRates.IsSuccessfull = false;
                    // ObjUpdateDrverNaFlageInB.Message = "Process failed.";
                }

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
            return objDeleteTaxRates;
        }

        public DataTable RetriveTaxRates(Tax_RateClass objTaxRates)
        {
            try
            {
                SQLServerRepository objSqlRep = new SQLServerRepository();
                dt = objSqlRep.GetDataTable("select Store_ID, Tax1_Rate,Tax1_Name,Tax2_Rate,Tax2_Name,Tax3_Rate,Tax3_Name,Tax2OnTax1,Tax2Threshold from Tax_Rate where Store_ID = '" + objTaxRates.Store_ID + "'");
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Sql server Repository]", ex.Message);
            }
            return dt;
        }
    }
}
