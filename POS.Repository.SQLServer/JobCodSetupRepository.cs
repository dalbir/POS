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
   public class JobCodSetupRepository
    {
       SQLServerRepository objSQLServerRepository = new SQLServerRepository();
        public JobCodeClass insertJobCodes(JobCodeClass objJobCodeClass)
        {
            try
            {
                int result = objSQLServerRepository.ExecuteNonQuery("INSERT INTO JobCode" +
                                                                "(JobCodeID,"+
                                                                "AccessToPos,"+
                                                                "Print_DDR,"+
                                                                "DDR_Num_Copies,"+
                                                                "Picture,"+
                                                                "Prompt_Cash_Tips,"+
                                                                "Record_Cash_Bank,"+
                                                                "Default_Wage,"+
                                                                "DDR_CC_Itemize,"+
                                                                "Require_CD_Select,"+
                                                                "Require_Clockout_CashBreakdown,"+
                                                                "Default_OvertimeWage,"+
                                                                "AccessToDonationCenter,"+
                                                                "AccessToProductionSoftware,"+
                                                                "DeliveryTracking,"+
                                                                "RoleVisibility,"+
                                                                "JobCodeName)"+
                                                            "VALUES"+
                                                                "('"+objJobCodeClass.JobCodeID+"',"+
                                                                "'"+objJobCodeClass.AccessToPos+"',"+
                                                                "'"+objJobCodeClass.Print_DDR+"',"+
                                                                "'"+objJobCodeClass.DDR_Num_Copies+"',"+
                                                                "'"+objJobCodeClass.Picture+"',"+
                                                                "'"+objJobCodeClass.Prompt_Cash_Tips+"',"+
                                                                "'"+objJobCodeClass.Record_Cash_Bank+"',"+
                                                                "'"+objJobCodeClass.Default_Wage+"',"+
                                                                "'"+objJobCodeClass.DDR_CC_Itemize+"',"+
                                                                "'"+objJobCodeClass.Require_CD_Select+"',"+
                                                                "'"+objJobCodeClass.Require_Clockout_CashBreakdown+"',"+
                                                                "'"+objJobCodeClass.Default_OvertimeWage+"',"+
                                                                "'"+objJobCodeClass.AccessToDonationCenter+"',"+
                                                                "'"+objJobCodeClass.AccessToProductionSoftware+"',"+
                                                                "'"+objJobCodeClass.DeliveryTracking+"',"+
                                                                "'"+objJobCodeClass.RoleVisibility+"',"+
                                                                "'"+objJobCodeClass.JobCodeName+"')");
                if(result > 0)
                {
                    objJobCodeClass.IsSuccessfull = true;
                }
                else
                {
                    objJobCodeClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objJobCodeClass;
        }

        public JobCodeClass updateJobCodes(JobCodeClass objJobCodeClass)
        {
            try
            {
                int result = objSQLServerRepository.ExecuteNonQuery("update CRELiquorStore set " +
                   "AccessToPos = '" + objJobCodeClass.AccessToPos + "'," +
                   "Print_DDR = '" + objJobCodeClass.Print_DDR + "'," +
                   "DDR_Num_Copies = '" + objJobCodeClass.DDR_Num_Copies + "'," +
                   "Picture = '" + objJobCodeClass.Picture + "'," +
                   "Prompt_Cash_Tips = '" + objJobCodeClass.Prompt_Cash_Tips + "'," +
                   "Record_Cash_Bank = '" + objJobCodeClass.Record_Cash_Bank + "'," +
                   "Default_Wage = '" + objJobCodeClass.Default_Wage + "'," +
                   "DDR_CC_Itemize = '" + objJobCodeClass.DDR_CC_Itemize + "'," +
                   "Require_CD_Select = '" + objJobCodeClass.Require_CD_Select + "'," +
                   "Require_Clockout_CashBreakdown = '" + objJobCodeClass.Require_Clockout_CashBreakdown + "'," +
                   "Default_OvertimeWage = '" + objJobCodeClass.Default_OvertimeWage + "'," +
                   "AccessToDonationCenter = '" + objJobCodeClass.AccessToDonationCenter + "'," +
                   "AccessToProductionSoftware = '" + objJobCodeClass.AccessToProductionSoftware + "'," +
                   "DeliveryTracking = '" + objJobCodeClass.DeliveryTracking + "'," +
                   "RoleVisibility = '" + objJobCodeClass.RoleVisibility + "'," +
                   "JobCodeName = " + objJobCodeClass.JobCodeName + "'" +
                   "where JobCodeID = '" + objJobCodeClass.JobCodeID + "'");
                if(result > 0)
                {
                    objJobCodeClass.IsSuccessfull = true;
                }
                else
                {
                    objJobCodeClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objJobCodeClass;
        }

        public JobCodeClass deleteJobCode(JobCodeClass objjobcodeClass)
        {
            try
            {
                int result = objSQLServerRepository.ExecuteNonQuery("DELETE FROM JobCode WHERE JobCodeID = '" + objjobcodeClass.JobCodeID + "'");
                if(result > 0)
                {
                    objjobcodeClass.IsSuccessfull = true;
                }
                else
                {
                    objjobcodeClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objjobcodeClass;
        }
        DataTable dtJobCode;
        public DataTable getJobCodes()
        {
            try
            {
                dtJobCode = objSQLServerRepository.GetDataTable("SELECT JobCodeID, JobCodeName FROM JobCode");
            }
            catch ( Exception ex)
            {
                
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtJobCode;
        }
        DataTable dtJobCodeRecord;
        public DataTable retriveJobCodeRecord(JobCodeClass objJobCodeClass)
        {
            try
            {
                dtJobCodeRecord = objSQLServerRepository.GetDataTable("SELECT * FROM JobCode where JobCodeID = '" + objJobCodeClass.JobCodeID + "'");
            }
            catch (Exception ex)
            {              
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtJobCodeRecord;
        }
    }
}
