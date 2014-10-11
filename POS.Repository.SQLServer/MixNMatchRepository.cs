using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Common;
using POS.Repository.SQLServer;

namespace POS.Repository.SQLServer
{
   public class MixNMatchRepository
    {
       SQLServerRepository objSQLServerRepository = new SQLServerRepository();
        public Inventory_OnSale_InfoClass insertOnsaleInfo(Inventory_OnSale_InfoClass objIvnOnsaleInfo)
        {
            try
            {
                objSQLServerRepository.ExecuteNonQuery("delete from Inventory_OnSale_Info where ItemNum = '" + objIvnOnsaleInfo.ItemNum + "'");
                int result = objSQLServerRepository.ExecuteNonQuery("insert into Inventory_OnSale_Info(ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], Price, SalePriceType) values('"+ objIvnOnsaleInfo.ItemNum +"', '"+ objIvnOnsaleInfo.Store_ID +"','"+ objIvnOnsaleInfo.Sale_Start +"','"+ objIvnOnsaleInfo.Sale_End +"', '"+ objIvnOnsaleInfo.Percent +"', '"+ objIvnOnsaleInfo.Price +"', '"+ objIvnOnsaleInfo.SalePriceType +"')");
            }
            catch(Exception ex)
            {

            }
            return objIvnOnsaleInfo;
        }
    }
}
