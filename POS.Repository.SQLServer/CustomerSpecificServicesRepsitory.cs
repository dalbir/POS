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
    public class CustomerSpecificServicesRepsitory
    {
        SQLServerRepository objSqlServerRepostory = new SQLServerRepository();
        DataTable dt;

        public DataTable getRequredDataRep(Inventory_CustPricesClass objInveCust)
        {
            try
            {
                if(objInveCust.message == "item")
                {
                    dt = objSqlServerRepostory.GetDataTable("select * from CUSTOMER_SEPECIFIC_ITEM_PRICES where ItemNum = '" + objInveCust.ItemNum + "'");
                    if(dt.Rows.Count == 0)
                    {
                        dt = objSqlServerRepostory.GetDataTable("select ItemNum, ItemName from Inventory where ItemNum = '" + objInveCust.ItemNum + "'");
                        objInveCust.message = "no";
                    }                  
                }
                else if(objInveCust.message == "customer")
                {
                    dt = objSqlServerRepostory.GetDataTable("select * from CUSTOMER_SEPECIFIC_ITEM_PRICES where ItemNum = '" + objInveCust.ItemNum + "'");
                    if (dt.Rows.Count == 0)
                    {
                        dt = objSqlServerRepostory.GetDataTable("select ItemNum, ItemName from Inventory where ItemNum = '" + objInveCust.ItemNum + "'");
                        objInveCust.message = "no";
                    }     
                }
            }
            catch(Exception ex)
            {

            }
            return dt;
        }
    }
}
