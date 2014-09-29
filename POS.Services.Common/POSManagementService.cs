using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.SQLServer;
using POS.Domain.Common;
using System.Data;

namespace POS.Services.Common
{
    public class POSManagementService
    {
        #region Category maintenance
        //category 
        //load catogry ids
        public CategoriesClass LoadCategoryInfo(CategoriesClass objCategoryinfo)
        {
            CategoryRepository categoryRepositry = new CategoryRepository();
            return categoryRepositry.LoadCategory(objCategoryinfo);
        }
        //insert category
        public CategoriesClass InsertCategoryInfo(CategoriesClass objInsertCategoryInfo)
        {
            CategoryRepository categoryRepositry = new CategoryRepository();
            return categoryRepositry.insertCategory(objInsertCategoryInfo);
        }
        #endregion

        #region inventory module
        public InventoryClass FillDeptCmb(InventoryClass objFillDeptCmb)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.FillDeptCombo(objFillDeptCmb);
        }
        // geting max id from invertyimage table
        public Inventory_ImageClass GetMaixId(Inventory_ImageClass objGetMaixId)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.GetinventoryImgaeInfo(objGetMaixId);
        }
        //insert Skus
        public Inventory_SKUSClass InsertSukus(Inventory_SKUSClass objInsertSukus)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.insertSkus(objInsertSukus);
        }
        // insert tag
        public Inventory_TagAlongsClass insertTag(Inventory_TagAlongsClass objinsertTag)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.insertTagAlongs(objinsertTag);
        }
        // insert modifiers goups 
        public Kit_IndexClass InsertKit(Kit_IndexClass objKitIndex)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.InsertKit(objKitIndex);
        }
        // insert modifiers with items 
        public ModifiersClass InsertModifierWitem(ModifiersClass objModifiers)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.InsertModifersWItem(objModifiers);
        }
        // get sku 
        public Inventory_SKUSClass getSku(Inventory_SKUSClass objinventorySku)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.RetriveSku(objinventorySku);
        }
        public string GetItemType(InventoryClass objInventory)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.GetItemTypeRepo(objInventory);
        }
        public Inventory_DiscLevelsClass ExectueInvDisLevel(Inventory_DiscLevelsClass objInventoryDisLevel)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.ExecuteInvDislevel(objInventoryDisLevel);
        }
        public Inventory_VendorsClass ExecuteOredringInfo(Inventory_VendorsClass objInventoryVendor)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.executeOrderingInfoRep(objInventoryVendor);
        }
        public Inventory_OnSale_InfoClass ExecuteInventoryOnsaleInfo(Inventory_OnSale_InfoClass objInventoryOnsaleInfo)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.ExecuteInventoryOnsaleInfoRep(objInventoryOnsaleInfo);
        }
        public DataTable getIventory(string id_item)
        {
            InventoryRepository inventoryRep = new InventoryRepository();
            return inventoryRep.getInventoryRep(id_item);
        }
        public DataTable getModifiers()
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.getModifiersRepository();
        }
        public Inventory_Bulk_InfoClass ExecuteInvBulkInfor(Inventory_Bulk_InfoClass objInventory_Bulk_InfoClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.ExecuteInvBulkInfoRep(objInventory_Bulk_InfoClass);
        }
        public Inventory_PricesClass ExecuteInvnPrice(Inventory_PricesClass objInventory_PricesClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.executeInventoryPrice(objInventory_PricesClass);
        }
        public ChoiceItemsPropertyClass ExecuteChoiceItemsProperties(ChoiceItemsPropertyClass objChoiceItemsPropertyClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.executeChoiceItemRep(objChoiceItemsPropertyClass);
        }
        public Inventory_CouponClass ExecuteCoupon(Inventory_CouponClass objInventory_CouponClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.executeCouponRep(objInventory_CouponClass);
        }
        public Inventory_Coupon_RulesClass ExectueInvCouponRules(Inventory_Coupon_RulesClass objInventoryCoupnRules)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.executeCouponRulesRep(objInventoryCoupnRules);
        }
        public Inventory_Rental_InfoClasss ExecuteRentalInfo(Inventory_Rental_InfoClasss objRentalInfo)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.executeRentalInfoRep(objRentalInfo);
        }
        public InventoryClass insertInventory(InventoryClass objInventoryClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.insertInventoryRep(objInventoryClass);
        }
        public DataTable GetInventoryFullInfo()
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.GetInventoryFullInfoRep();
        }
        public Inventory_PendingOrdersClass updatePendingOreders(Inventory_PendingOrdersClass objInvPendingOrders)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.updatePendingOrdersRep(objInvPendingOrders);
        }
        public InventoryClass updateImnventory(InventoryClass objInventory)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.updateInventoryRep(objInventory);
        }
        public string getInventoryId(string p)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.getItemId(p);
        }
        public DataTable getKit(string p)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.getdtkitIdRep(p);
        }
        public DataTable getProperty(string p)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.getgetPropertyRep(p);
        }
        public DataTable GetInventoryPendingOrders(Inventory_PendingOrdersClass objInventoryPendingOrder)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.GetInventoryPendingOrders(objInventoryPendingOrder);
        }
        public InventoryClass SaveChangesInventory(InventoryClass objInventoryClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.SaveChangesInventoryRep(objInventoryClass);
        }
        public DataTable RetrivingInformation(InventoryClass objRetrivingInformation)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.RetrivingInformationRep(objRetrivingInformation);
        }
        public DataTable GetData(string qryType, string itemNum)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.GetDataRep(qryType, itemNum);
        }
        #endregion

        #region Vendor Service
        public VendorsClass RetriveVendor(VendorsClass objVendor)
        {
            VendorRepository VendorRep = new VendorRepository();
            return VendorRep.RetriveVendor(objVendor);
        }
        //vendor informaiton insertion, Table: vendor, Form: inventory maintanence
        public VendorsClass InsertVendorInfo(VendorsClass objVendor)
        {
            VendorRepository VendorRep = new VendorRepository();
            return VendorRep.InsertVendorInfo(objVendor);
        }
        public VendorsClass RetriveAllVendorRecord(VendorsClass objVendor)
        {
            VendorRepository VendorRep = new VendorRepository();
            return VendorRep.RetriveAllVendor(objVendor);
        }
        #endregion

        #region Tax related Repositories
        // retriving tax rates for tax rates form
        public Tax_RateClass RetriveTaxRate(Tax_RateClass objTaxRate)
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.GetTaxRates(objTaxRate);
        }
        //retriving tax rates arreas
        public DataTable GetTaxRateAreas(Tax_Rate_AreasClass objTaxRateAreas)
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.GetTaxRateAreas(objTaxRateAreas); 
        }
        public Tax_RateClass updateTaxRates(Tax_RateClass objTaxRates)
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.updateTaxRateRep(objTaxRates);
        }
        public string GetMaxTaxId()
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.GetMaxTaxIDRep();
        }
        // inserton of tax rates arreas
        public Tax_Rate_AreasClass intsertTaxRates(Tax_Rate_AreasClass objTaxRatesAreras)
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.insertTaxAreras(objTaxRatesAreras);
        }
        // change tax rates arreas
        public Tax_Rate_AreasClass ChangeTaxRateAreas(Tax_Rate_AreasClass objTaxRatesAreas)
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.ChangeTaxRatesAreasRep(objTaxRatesAreas);
        }
        public Tax_Rate_AreasClass DeleteTaxAreas(Tax_Rate_AreasClass objTaxRatesAreas)
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.DeleteTaxRates(objTaxRatesAreas);
        }
        public DataTable RetriveTaxRat(Tax_RateClass objTaxRate)
        {
            TaxRepository objTaxRepository = new TaxRepository();
            return objTaxRepository.RetriveTaxRates(objTaxRate);
        }
        #endregion

        #region Department Maintenance

        //load dept ids
        public DepartmentClass LoadCatIdToDpt(DepartmentClass objDptClass)
        {
            DepartmentRepository objDptRep = new DepartmentRepository();
            return objDptClass = objDptRep.LoadCategoryToDpt(objDptClass);
        }
        //insert Dept info
        public DepartmentClass InsertDeptInfo(DepartmentClass objdptclass)
        {
            DepartmentRepository objdptRep = new DepartmentRepository();
            return objdptclass = objdptRep.insertDepartementinfo(objdptclass);
        }
        public string loadReadedData(DepartmentClass objDptclass)
        {
            DepartmentRepository objDptRep = new DepartmentRepository();
            return objDptRep.ReadDeptID(objDptclass);
        }

        #endregion

        #region Customer

        public CustomerClass InsertCustomerInfo(CustomerClass objCustomerInfo)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustomerInfo(objCustomerInfo);
        }
        public CustomerAccountingTransactionClass insertCusAccTrans(CustomerAccountingTransactionClass objCusAccTrns)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustomerAccTrnsInfo(objCusAccTrns);
        }
        public CustomerAuthorizedClass insertCusAutho(CustomerAuthorizedClass objCusAuth)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustomerAuthorInfo(objCusAuth);
        }
        public CustomerAutoClass insertCusauto(CustomerAutoClass objCusAuto)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustAutoInfo(objCusAuto);
        }
        public CustomerEventsClass insertCusEvents(CustomerEventsClass objCusevnt)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.custEventsIngo(objCusevnt);
        }
        public CustomerGiftRegistryClass insertCusGftReg(CustomerGiftRegistryClass objCusGftReg)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustomerGiftRegInfo(objCusGftReg);
        }
        public CustomerGiftRegistryItemsClass insertcusGfRegItems(CustomerGiftRegistryItemsClass objCusGftRegItm)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustGftRegItemInfo(objCusGftRegItm);
        }
        public CustomerNotesClass insertCusNotes(CustomerNotesClass objCusNotes)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustomerNotesInfo(objCusNotes);
        }
        public CustomerPropertiesClass insertCusProperties(CustomerPropertiesClass objCusProperties)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustomerProprtiesInfo(objCusProperties);
        }
        public CustomerReferenceClass insertCusRefrnce(CustomerReferenceClass objCusProperties)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.custRefrenceInfo(objCusProperties);
        }
        public CustomerShipTosClass insertCusShipTos(CustomerShipTosClass objCusshptos)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustShipTosInfo(objCusshptos);
        }
        public CustomerStoresClass insertCusStores(CustomerStoresClass objCusStores)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.customerStoresInfo(objCusStores);
        }
        public CustomerSwipesClass insertCusSwipes(CustomerSwipesClass objCusSwip)
        {
            CustomerRepository objCusRep = new CustomerRepository();
            return objCusRep.CustomerSwipInfo(objCusSwip);
        }
        #endregion







    }
}
