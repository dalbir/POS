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
    public class DepartmentRepository
    {
        SQLServerRepository sqlServerRepository = new SQLServerRepository();
        public DepartmentClass LoadCategoryToDpt(DepartmentClass objDeptClass)
        {
            try
            {
                if (objDeptClass.flage == "comboFill")
                {
                    objDeptClass.LoadDept = sqlServerRepository.GetDataTable("select Cat_ID,Cat_ID+'-'+Description as CatName from Categories");
                }
                else if (objDeptClass.flage == "loadDpt")
                {
                    objDeptClass.LoadDept = sqlServerRepository.GetDataTable("SELECT Dept_ID,Description FROM Departments ");
                }
                else if (objDeptClass.flage == "SelectDept")
                {
                    objDeptClass.LoadDept = sqlServerRepository.GetDataTable("SELECT * FROM Departments where Dept_ID='" + objDeptClass.Dept_ID + "' ");
                }
                else if (objDeptClass.flage == "selectCateg")
                {
                    objDeptClass.LoadDept = sqlServerRepository.GetDataTable("select Cat_ID,Cat_ID+'-'+Description as CatName from Categories where Cat_ID ='" + objDeptClass.SubType + "' ");
                }
                else if (objDeptClass.flage == "fillList")
                {
                    objDeptClass.LoadDept = sqlServerRepository.GetDataTable("SELECT Dept_ID FROM Departments ");
                }
               
            }
            catch (Exception)
            {

            }
            return objDeptClass;
        }
        string DptIDs;
        public string ReadDeptID(DepartmentClass objDptClass)
        {
            if (objDptClass.flage == "ReadDept")
            {
                 DptIDs = sqlServerRepository.ExecuteScalar("SELECT Dept_ID FROM Departments where Dept_ID='" + objDptClass.Dept_ID + "' ");
                
            }
            return DptIDs;
        }
        int result;
        public DepartmentClass insertDepartementinfo(DepartmentClass objdeptClass)
        {

            try
            {

                if (objdeptClass.flage == "insert")
                {
                    result = sqlServerRepository.ExecuteNonQuery("INSERT INTO Departments (Dept_ID, Store_ID, Description, Type, TSDisplay, Cost_MarkUp, Dirty, SubType, " +
                        "Print_Dept_Notes, Dept_Notes, Require_Permission, Require_Serials,BarTaxInclusive, Cost_Calculation_Percentage, Square_Footage, AvailableOnline, IncludeInScaleExport)" +
                     "VALUES('" + objdeptClass.Dept_ID + "','" + objdeptClass.Store_ID + "','" + objdeptClass.Description + "','" + objdeptClass.Type + "','" + objdeptClass.TSDisplay + "', " +
                     "'" + objdeptClass.Cost_MarkUp + "','" + objdeptClass.Dirty + "','" + objdeptClass.SubType + "','" + objdeptClass.Print_Dept_Notes + "','" + objdeptClass.Dept_Notes + "', " +
                     "'" + objdeptClass.Require_Permission + "','" + objdeptClass.Require_Serials + "','" + objdeptClass.BarTaxInclusive + "','" + objdeptClass.Cost_Calculation_Percentage + "', " +
                     "'" + objdeptClass.Square_Footage + "','" + objdeptClass.AvailableOnline + "','" + objdeptClass.IncludeInScaleExport + "')");
                }
                else if (objdeptClass.flage == "update")
                {
                    result = sqlServerRepository.ExecuteNonQuery("Update Departments set Store_ID = '" + objdeptClass.Store_ID + "', Description = '" + objdeptClass.Description + "', Type = '" + objdeptClass.Type + "'," +
                    "TSDisplay = '" + objdeptClass.TSDisplay + "', Cost_MarkUp = '" + objdeptClass.Cost_MarkUp + "', Dirty = '" + objdeptClass.Dirty + "', SubType = '" + objdeptClass.SubType + "', " +
                    "Print_Dept_Notes ='" + objdeptClass.Print_Dept_Notes + "', Dept_Notes = '" + objdeptClass.Dept_Notes + "', Require_Permission = '" + objdeptClass.Require_Permission + "'," +
                    "Require_Serials = '" + objdeptClass.Require_Serials + "', BarTaxInclusive = '" + objdeptClass.BarTaxInclusive + "', " +
                    "Cost_Calculation_Percentage = '" + objdeptClass.Cost_Calculation_Percentage + "', Square_Footage = '" + objdeptClass.Square_Footage + "'," +
                    "AvailableOnline = '" + objdeptClass.AvailableOnline + "', IncludeInScaleExport = '" + objdeptClass.IncludeInScaleExport + "' WHERE Dept_ID ='" + objdeptClass.Dept_ID + "'");
                }

                else if (objdeptClass.flage == "delete")
                {
                    result = sqlServerRepository.ExecuteNonQuery("DELETE FROM Departments WHERE Dept_ID ='" + objdeptClass.Dept_ID + "'");
                }
                if (result > 0)
                {
                    objdeptClass.IsSuccessfull = true;
                }
                else
                {
                    objdeptClass.IsSuccessfull = false;
                }
            }
            catch (Exception)
            {

            }
            return objdeptClass;
        }


    }
}
