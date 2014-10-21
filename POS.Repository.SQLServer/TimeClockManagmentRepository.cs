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
   public class TimeClockManagmentRepository
    {
       SQLServerRepository objSQLServerRepository = new SQLServerRepository();
       DataTable dtempClock;
        public DataTable FillDgTimeClock(Time_ClockClass objTimeClockClass)
        {
            try
            {
                dtempClock = objSQLServerRepository.GetDataTable("select ID, Cashier_ID, StartDateTime, EndDateTime, NumMinutes, Wages, JobCodeID from Time_Clock where Cashier_ID like '" + objTimeClockClass.Cashier_ID + "' and (StartDateTime >= '" + objTimeClockClass.StartDateTime + "') and ((EndDateTime <= '" + objTimeClockClass.EndDateTime + "') or (EndDateTime is null)) and Store_ID = '"+ objTimeClockClass.Store_ID +"'");
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtempClock;
        }

        public Time_ClockClass delelteItem(Time_ClockClass objTimeClockClass)
        {
            try
            {
                int result = objSQLServerRepository.ExecuteNonQuery("delete from Time_Clock where ID = '"+ objTimeClockClass.ID +"' and Cashier_ID = '"+ objTimeClockClass.Cashier_ID +"'");
                if(result > 0)
                {
                    objTimeClockClass.IsSuccessfull = true;
                }
                else
                {
                    objTimeClockClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objTimeClockClass;
        }

        public Time_ClockClass deleteTimeOut(Time_ClockClass objTimeClockClass)
        {
            try
            {
                int result = objSQLServerRepository.ExecuteNonQuery("update Time_Clock set EndDateTime = null where ID = '" + objTimeClockClass.ID + "' and Cashier_ID = '" + objTimeClockClass.Cashier_ID + "'");
                if (result > 0)
                {
                    objTimeClockClass.IsSuccessfull = true;
                }
                else
                {
                    objTimeClockClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objTimeClockClass;
        }
        DataTable dtEmpJobCodes;
        public DataTable getEmpJobCodes(EmployeeJobCodeClass objEmployeeJobCodeClass)
        {
            try
            {
                dtEmpJobCodes = objSQLServerRepository.GetDataTable("select J.Cashier_ID, J.JobCodeID, J.Hourly_Wage, J.OvertimeHourly_Wage, C.JobCodeName from Employee_JobCode as J inner join JobCode as C on J.JobCodeID = C.JobCodeID where J.Cashier_ID = '" + objEmployeeJobCodeClass.Cashier_ID + "'");
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtEmpJobCodes;
        }

        public Time_ClockClass updateEmployeJobCodes(Time_ClockClass objTimeClockClass)
        {
            try
            {
                int result = objSQLServerRepository.ExecuteNonQuery("update Time_Clock set JobCodeID = '"+ objTimeClockClass.JobCodeID +"' where ID = '" + objTimeClockClass.ID + "' and Cashier_ID = '" + objTimeClockClass.Cashier_ID + "'");
                if(result > 0)
                {
                    objTimeClockClass.IsSuccessfull = true;
                }
                else
                {
                    objTimeClockClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objTimeClockClass;
        }
        DataTable dtTimeClockBreak;
        public DataTable getTimeClockBreak(Time_Clock_BreaksClass objTimeClockBreakClass)
        {
            try
            {
                dtTimeClockBreak = objSQLServerRepository.GetDataTable("select * from Time_Clock_Breaks where ID = '"+ objTimeClockBreakClass.ID +"' and Store_ID = '"+ objTimeClockBreakClass.Store_ID +"'");
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtTimeClockBreak;
        }

        public Time_ClockClass updateClockDateTime(Time_ClockClass objTimeClockClass)
        {
            try
            {
                int result = objSQLServerRepository.ExecuteNonQuery("update Time_Clock set "+ objTimeClockClass.updateColumn +" = '"+ objTimeClockClass.updateValeDate +"' where ID = '"+ objTimeClockClass.ID +"' and Cashier_ID = '"+ objTimeClockClass.Cashier_ID +"' and Store_ID = '"+ objTimeClockClass.Store_ID +"'");
                if(result > 0)
                {
                    objTimeClockClass.IsSuccessfull = true;
                }
                else
                {
                    objTimeClockClass.IsSuccessfull = false;
                }
            }
            catch (Exception ex)
            {
                
               CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return objTimeClockClass;
        }
    }
}
