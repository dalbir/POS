using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Common;
using POS.Repository.SQLServer;


namespace POS.Repository.SQLServer
{
    public class CategoryRepository
    {
        SQLServerRepository sqlServerRepository = new SQLServerRepository();
        //repository to retrive categ id to fill combo
        public CategoriesClass LoadCategory(CategoriesClass obLoadCategory)
        {
            try
            {
                if (obLoadCategory.flage == "comboFill")
                {
                    obLoadCategory.loadCategory = sqlServerRepository.GetDataTable("SELECT * FROM Categories");
                }
                else if (obLoadCategory.flage == "RetriveRecord")
                {
                    obLoadCategory.loadCategorydt = sqlServerRepository.GetDataTable("SELECT * FROM Categories where Cat_ID = '"+ obLoadCategory.Cat_ID +"'");
                }
            }
            catch(Exception)
            {

            }
            return obLoadCategory;
        }
        // repository for insert, update, delete category information
        int result;
        public CategoriesClass insertCategory(CategoriesClass objinsertCategory)
        {
            
            try
            {
                
                if (objinsertCategory.flage == "insert")
                {
                    result = sqlServerRepository.ExecuteNonQuery("INSERT INTO Categories (Cat_ID, Store_ID, Description) VALUES('" + objinsertCategory.Cat_ID + "','1001','" + objinsertCategory.Description + "')");
                }
                else if (objinsertCategory.flage == "update")
                {
                    result = sqlServerRepository.ExecuteNonQuery("UPDATE Categories SET Cat_ID ='" + objinsertCategory.Cat_ID + "', Store_ID = '1001', Description ='" + objinsertCategory.Description + "' WHERE Cat_ID = '" + objinsertCategory.Cat_ID + "'");
                }
                else if (objinsertCategory.flage == "delete")
                {
                    result = sqlServerRepository.ExecuteNonQuery("DELETE FROM Categories WHERE Cat_ID ='" + objinsertCategory.Cat_ID + "'");
                }
                if(result > 0)
                {
                    objinsertCategory.IsSuccessfull = true;
                } 
                else
                {
                    objinsertCategory.IsSuccessfull = false;
                }
            }
            catch(Exception)
            {

            }
            return objinsertCategory;
        }
        DataTable dtRecods;
        // getting catetory records for combobox for search inventory form
        public DataTable getCategorys()
        {
            try
            {
                dtRecods = sqlServerRepository.GetDataTable("select 'ALL RECORDS' as records, 'No Category' as id union all select  Description as records, [Cat_ID] as id from Categories");
            }
            catch(Exception)
            {

            }
            return dtRecods;

        }
    }
}
