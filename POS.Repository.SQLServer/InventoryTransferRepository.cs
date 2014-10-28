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
    public class InventoryTransferRepository
    {
        SQLServerRepository objSQLServerRepository = new SQLServerRepository();

        DataTable dtTransfers;
        public DataTable getTransfers(InventoryOrdersClass objInventoryOrdersClass)
        {
            try
            {
                dtTransfers = objSQLServerRepository.GetDataTable("select * from InventoryOrders");
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtTransfers;
        }
        DataTable dtStores;
        public DataTable getStoreIds()
        {
            try
            {
                dtStores = objSQLServerRepository.GetDataTable("select Store_ID from Setup");
            }
            catch (Exception ex)
            {
                
                CustomLogging.Log("[SQLServerRepository:]", ex.Message);
            }
            return dtStores;
        }
    }
}
