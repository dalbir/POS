using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.SQLServer;
using POS.Domain.Common;
using System.Data;

using POS.Domain.Common.Employee;

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
        public DataTable GetCategory()
        {
            CategoryRepository categoryRepositry = new CategoryRepository();
            return categoryRepositry.getCategorys();
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
        public DataTable RetiveModifeirs(ModifiersClass objModifiesClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.getModifers(objModifiesClass);
        }
        public DataTable searchItem(string flag, string p)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.searhItem(flag, p);
        }
        public DataTable filterInventory(InventoryClass objInventoryClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.filterInventoryRep(objInventoryClass);
        }
        public DataTable getInventoryId(Domain.Common.InventoryClass objInventory)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.getInventoryRepository(objInventory);
        }
        public Domain.Common.InventoryClass deleteItem(Domain.Common.InventoryClass objInvenoryClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.deleteItemRep(objInvenoryClass);
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
        public DataTable getVendors()
        {
            VendorRepository VendorRep = new VendorRepository();
            return VendorRep.getVendorRep();
        }
        public DataTable getVendorRecords()
        {
            VendorRepository VendorRep = new VendorRepository();
            return VendorRep.getVendorRecords();
        }
        #endregion

        #region Tax Services
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
        // get departments for combobox on search inventory screen
        public DataTable getDepartments()
        {
            DepartmentRepository objDptRep = new DepartmentRepository();
            return objDptRep.getDeptRep();
        }

        #endregion

        #region Purchase Oreder Repository
        public PO_SummaryClass insertPOSummary(PO_SummaryClass objPOSummary)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.insertPosummaryRep(objPOSummary);
        }
        public PO_DetailsClass insertPoDetail(PO_DetailsClass objPODetailClass)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.insertPoDetail(objPODetailClass);
        }
        // geting stores ids
        public DataTable GetStores()
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.GetStoresRep();
        }
        public DataTable getPoDetail(int po_id)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.getPoDeatil(po_id);
        }
        public DataTable getPoSummary(int po_id)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.getPoSummary(po_id);
        }
        public DataTable getPoSummaryByType(PO_SummaryClass objPoSummaryClass)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.getPoSummayByType(objPoSummaryClass);
        
        }
        public DataTable CheckStandardItem(InventoryClass objInventoryClass)
        {
            InventoryRepository objPurchaseOrderRepository = new InventoryRepository();
            return objPurchaseOrderRepository.checkStandardItem(objInventoryClass);
        }

        public PO_SummaryClass updatePoSummary(PO_SummaryClass objPoSummaryClass)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.updatePoSummaryRep(objPoSummaryClass);
        }
        public PO_DetailsClass deletePoDetails(PO_DetailsClass objPoDetail)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.DeletePoDetails(objPoDetail);
        }
        public DataTable getVendors(VendorsClass objVendorClass)
        {
            VendorRepository objPurchaseOrderRepository = new VendorRepository();
            return objPurchaseOrderRepository.getVendorsRep(objVendorClass);
        }
        public DataTable FilterData(string flage, string str)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.FilterDataRep(flage, str);
        }
        public DataTable veiwDetailPo(string id, string ven_id)
        {
            PurchaseOrderRepository objPurchaseOrderRepository = new PurchaseOrderRepository();
            return objPurchaseOrderRepository.viewDetailPo(id, ven_id);
        }
        public InventoryClass updateInventory(InventoryClass objInventoryClass)
        {
            InventoryRepository objPurchaseOrderRepository = new InventoryRepository();
            return objPurchaseOrderRepository.updateInventory(objInventoryClass);
        }
        #endregion

        #region Customer specific Item prices services
        public DataTable GetRequrdData(Inventory_CustPricesClass objInveCust)
        {
            CustomerSpecificServicesRepsitory objCustSpecificSercRep = new CustomerSpecificServicesRepsitory();
            return objCustSpecificSercRep.getRequredDataRep(objInveCust);
        }
        public POS.Domain.Common.Inventory_CustPricesClass insertCustomerWithSpecifedITem(Inventory_CustPricesClass objInvCustPricesClass)
        {
            CustomerSpecificServicesRepsitory objCustSpecificSercRep = new CustomerSpecificServicesRepsitory();
            return objCustSpecificSercRep.insertCustmerwithSpeItemRep(objInvCustPricesClass);
        }
        public POS.Domain.Common.Inventory_CustPricesClass updateCustPrice(Domain.Common.Inventory_CustPricesClass objCustPrice)
        {
            CustomerSpecificServicesRepsitory objCustSpecificSercRep = new CustomerSpecificServicesRepsitory();
            return objCustSpecificSercRep.updateCustPrice(objCustPrice);
        }
        public POS.Domain.Common.Inventory_CustPricesClass updateAllowDiscounts(Domain.Common.Inventory_CustPricesClass objCustPrices)
        {
            CustomerSpecificServicesRepsitory objCustSpecificSercRep = new CustomerSpecificServicesRepsitory();
            return objCustSpecificSercRep.updateAllowDiscounts(objCustPrices);
        }
        public Domain.Common.Inventory_CustPricesClass removeCustPrice(Domain.Common.Inventory_CustPricesClass objCustPrcies)
        {
            CustomerSpecificServicesRepsitory objCustSpecificSercRep = new CustomerSpecificServicesRepsitory();
            return objCustSpecificSercRep.removeCustPriceRep(objCustPrcies);
        }
        public DataTable fillDataGrids(Domain.Common.Inventory_CustPricesClass objCustPrcies)
        {
            CustomerSpecificServicesRepsitory objCustSpecificSercRep = new CustomerSpecificServicesRepsitory();
            return objCustSpecificSercRep.fillDataGrids(objCustPrcies);
        }
        #endregion

        #region Global Price change Services
        public DataTable getDepartment(Domain.Common.DepartmentClass objDepartment)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.GetDepatment(objDepartment);
        }
        public DataTable getItems(string storeID)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.getItems(storeID);
        }
        public DataTable getItemsData(Domain.Common.InventoryClass objInventoryClass)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.getItemsData(objInventoryClass);
        }
        public Domain.Common.InventoryClass updatePrice(Domain.Common.InventoryClass objInventoryClass)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.updatePriceRep(objInventoryClass);
        }
        public Domain.Common.Inventory_OnSale_InfoClass updateSalePrice(Domain.Common.Inventory_OnSale_InfoClass objInvOnSaleInfo)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.updateSalePriceRep(objInvOnSaleInfo);
        }
        public Domain.Common.Inventory_OnSale_InfoClass deleteSelectedItems(Domain.Common.Inventory_OnSale_InfoClass objInvOnSaleInfo)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.deleteSelectItemsRep(objInvOnSaleInfo);
        }
        public Domain.Common.InventoryClass IncreasePrice(Domain.Common.InventoryClass objInventoryClass)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.increasPriceRep(objInventoryClass);
        }
        // service for apply discounts
        public Domain.Common.Inventory_OnSale_InfoClass applyDiscounts(Domain.Common.Inventory_OnSale_InfoClass objInvOnSaleInfo)
        {
            GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
            return objGlobalPriceRep.applyDiscountsRep(objInvOnSaleInfo);
        }
        public Domain.Common.InventoryClass applyTax(Domain.Common.InventoryClass objInventoryClass)
        {
             GlobalPriceRepository objGlobalPriceRep = new GlobalPriceRepository();
             return objGlobalPriceRep.applyTaxRep(objInventoryClass);
        }
        #endregion

        #region Mix'n Match Service
        public Inventory_OnSale_InfoClass insertOnSaleInfo(Inventory_OnSale_InfoClass objIvnOnsaleInfo)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.insertOnsaleInfo(objIvnOnsaleInfo);
        }
        public Kit_IndexClass InsertItemsinKitindex(Kit_IndexClass objKitIndex)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.insertItemsInKitIndex(objKitIndex);
        }
        public Inventory_MixNMatch_LevelsClass insertDiscountLevels(Inventory_MixNMatch_LevelsClass objMixNMatchLevel)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.insertDiscountLevel(objMixNMatchLevel);
        }
        public Inventory_BumpBarSettingsClass insertBumpBarSetting(Inventory_BumpBarSettingsClass objBumpBarSetting)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.insertBumpBarSetting(objBumpBarSetting);
        }
        public Inventory_AdditionalInfoClass insertAdditionalInfo(Inventory_AdditionalInfoClass objinvAdditionalInfo)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.insertAdditionalInfo(objinvAdditionalInfo);
        }
        public Setup_TS_ButtonsClass insertSetupTsButtons(Setup_TS_ButtonsClass objSetupTsButtons)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.insertSetupTsButtons(objSetupTsButtons);
        }
        public InventoryClass checkItemExist(InventoryClass objInventoryClass)
        {
            InventoryRepository objInventoryRepository = new InventoryRepository();
            return objInventoryRepository.checkItemExist(objInventoryClass);
        }
        public DataTable getMixnMatch(int objItemType)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.getMixnMatch(objItemType);
        }
        public DataTable RetriveData(string ItemNum)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.retriveDataRep(ItemNum);
        }
        public DataTable retriveSubItems(string ItemNum, string storeId)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.retriveSubItems(ItemNum, storeId);
        }
        public DataTable retriveDiscountLevel(string ItemNum, string storeId)
        {
            MixNMatchRepository objMixNMatchRepository = new MixNMatchRepository();
            return objMixNMatchRepository.retriveDiscountLevel(ItemNum, storeId);
        }
        #endregion
 
        #region [CUSTOMER SERVICES]
        //     insertCusNotes

        public CustomerClass InsertCustomerInfo(CustomerClass objCustomerClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.CustomerInfo(objCustomerClass);
        }
        public CustomerAccountingTransactionClass insertCusAccTrans(CustomerAccountingTransactionClass objCustomerAccountingTransactionClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.CustomerAccTrnsInfo(objCustomerAccountingTransactionClass);
        }
        public CustomerAuthorizedClass insertCusAutho(CustomerAuthorizedClass objCustomerAuthorizedClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.CustomerAuthorInfo(objCustomerAuthorizedClass);
        }
        public CustomerAutoClass insertCusauto(CustomerAutoClass objCustomerAutoClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.CustAutoInfo(objCustomerAutoClass);
        }
        public CustomerNotesClass insertCusNotes(CustomerNotesClass objCustomerNotesClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.CustomerNotesInfo(objCustomerNotesClass);
        }
        public CustomerEventsClass insertCusEvents(CustomerEventsClass objCustomerEventsClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.custEventsIngo(objCustomerEventsClass);
        }
        public string loadMaxID(CustomerReferenceClass objCustomerReferenceClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.GetMaxRefrenceID(objCustomerReferenceClass);
        }
        public CustomerReferenceClass insertCustomerRefrenceInfor(CustomerReferenceClass objCustomerReferenceClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.custRefrenceInfo(objCustomerReferenceClass);
        }
        public CustomerShipTosClass InsertCustomerShipTos(CustomerShipTosClass objCustomerShipTosClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.CustShipTosInfo(objCustomerShipTosClass);
        }
        public CustomerStoresClass insertStoreInfo(CustomerStoresClass objCustomerStoresClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.customerStoresInfo(objCustomerStoresClass);
        }
        public CustomerSwipesClass insertCustomerSwips(CustomerSwipesClass objCustomerSwipesClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerRepository.CustomerSwipInfo(objCustomerSwipesClass);
        }
        public CustomerClass GetCustomerInfor(CustomerClass objCustomerClass)
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            return objCustomerClass = objCustomerRepository.LoadCustomerInfo(objCustomerClass);
        }
        #endregion

        #region [EMPLOYEE SERVICES]
        public EmployeesDataClass insertEmpData(EmployeesDataClass objEmployeesData)
        {
            EmployeeRepository objEmployeeRepository = new EmployeeRepository();
            return objEmployeeRepository.insertEmployeeData(objEmployeesData);
        }
        public DataTable getDeptforEmployee(DepartmentClass objDept)
        {
            EmployeeRepository objEmployeeRepository = new EmployeeRepository();
            return objEmployeeRepository.getDepforEmployee(objDept);
        }
        public EmployeeJobCodeClass insertEmployeejob(EmployeeJobCodeClass objEmployeeJobCodeClass)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.insertEmpJob(objEmployeeJobCodeClass);
        }
        public EmployeeAdditionalInfoClass insertPayrolInfo(EmployeeAdditionalInfoClass objAddtionalInfo)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.insertAddInfoPayrol(objAddtionalInfo);
        }
        public DataTable getEmplyeeIds(EmployeesDataClass objEmployeesDataClass)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.getEmployeeIds(objEmployeesDataClass);
        }
        public DataTable RetriveEmpRecord(EmployeesDataClass objEmployeesDataClass)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.retriveEmployeeRecored(objEmployeesDataClass);
        }
        public DataTable retriveAddionalInfo(EmployeeAdditionalInfoClass objAdditionalInfo)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.retriveAdditionalInfo(objAdditionalInfo);
        }
        public DataTable retriveEmployeJob(EmployeeJobCodeClass objEmployeeJobCodeClass)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.retriveEmpJobcode(objEmployeeJobCodeClass);
        }
        public EmployeesDataClass updateEmployeeRecord(EmployeesDataClass objEmployeesData)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.updateEmployeeRecord(objEmployeesData);
        }
        public EmployeeAdditionalInfoClass updateEmpAdditionalInfo(EmployeeAdditionalInfoClass objAddtionalInfo)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.updateEmpAdditionalInfo(objAddtionalInfo);
        }
        public EmployeeJobCodeClass updateEmpJobCose(EmployeeJobCodeClass objEmployeeJobCodeClass)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.updateEmpJobCode(objEmployeeJobCodeClass);
        }
        public EmployeeJobCodeClass deleteSelectedJob(EmployeeJobCodeClass objEmployeeJobCode)
        {
            EmployeeRepository objJobCodSetupRepository = new EmployeeRepository();
            return objJobCodSetupRepository.deleteSelectedJob(objEmployeeJobCode);
        }
        #endregion

        #region [Job Code Setup]
        public JobCodeClass insertJobCodes(JobCodeClass objJobCodeClass)
        {
            JobCodSetupRepository objJobCodSetupRepository = new JobCodSetupRepository();
            return objJobCodSetupRepository.insertJobCodes(objJobCodeClass);
        }
        public JobCodeClass updateJobCodes(JobCodeClass objJobCodeClass)
        {
            JobCodSetupRepository objJobCodSetupRepository = new JobCodSetupRepository();
            return objJobCodSetupRepository.updateJobCodes(objJobCodeClass);
        }
        public JobCodeClass deleteJobCode(JobCodeClass objjobcodeClass)
        {
            JobCodSetupRepository objJobCodSetupRepository = new JobCodSetupRepository();
            return objJobCodSetupRepository.deleteJobCode(objjobcodeClass);
        }
        public DataTable getJobCodes()
        {
            JobCodSetupRepository objJobCodSetupRepository = new JobCodSetupRepository();
            return objJobCodSetupRepository.getJobCodes();
        }
        public DataTable RetriveJobCodeRecord(JobCodeClass objJobCodeClass)
        {
            JobCodSetupRepository objJobCodSetupRepository = new JobCodSetupRepository();
            return objJobCodSetupRepository.retriveJobCodeRecord(objJobCodeClass);
        }
 
        #endregion

        #region Styles Matrix Services

        public GroupsClass GetGroupLoadedData(GroupsClass objGroupsClass)
        {
            StylesMatrixRepository objStylesMatrixRepository = new StylesMatrixRepository();
            return objStylesMatrixRepository.LoadvendorsInfo(objGroupsClass);
        }
        public GroupsClass GetGroupsInfo(GroupsClass objGroupsClass)
        {
            StylesMatrixRepository objStylesMatrixRepository = new StylesMatrixRepository();
            return objStylesMatrixRepository.GroupsInfo(objGroupsClass);
        }
        public string loadMaxGroupRefrnceID(Groups_ReferenceClass objGroupsReferenceClass)
        {
            StylesMatrixRepository objStylesMatrixRepository = new StylesMatrixRepository();
            return objStylesMatrixRepository.GetMaxGroupRefrnceID(objGroupsReferenceClass);
        }
        public Groups_ReferenceClass GetGroupRefereceInfo(Groups_ReferenceClass objGroups_ReferenceClass)
        {
            StylesMatrixRepository objStylesMatrixRepository = new StylesMatrixRepository();
            return objStylesMatrixRepository.GroupsReferenceInfo(objGroups_ReferenceClass);
        }
        public string loadReadedGroupID(GroupsClass objGroupsClass)
        {
            StylesMatrixRepository objStylesMatrixRepository = new StylesMatrixRepository();
            return objStylesMatrixRepository.ReadGroupID(objGroupsClass);
        }
        #endregion

        #region [Time Clock Management]
        public DataTable filldagaGrid(Time_ClockClass objTimeClockClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.FillDgTimeClock(objTimeClockClass);
        }
        public Time_ClockClass deleteItemRecord(Time_ClockClass objTimeClockClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.delelteItem(objTimeClockClass);
        }
        public Time_ClockClass deleteTimeOut(Time_ClockClass objTimeClockClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.deleteTimeOut(objTimeClockClass);
        }
        public DataTable getEmpjobCodes(EmployeeJobCodeClass objEmployeeJobCodeClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.getEmpJobCodes(objEmployeeJobCodeClass);
        }
        public Time_ClockClass updateEmployeJobCode(Time_ClockClass objTimeClockClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.updateEmployeJobCodes(objTimeClockClass);
        }
        public DataTable getClockBreak(Time_Clock_BreaksClass objTimeClockBreakClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.getTimeClockBreak(objTimeClockBreakClass);
        }
        public Time_ClockClass updateClockDate(Time_ClockClass objTimeClockClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.updateClockDateTime(objTimeClockClass);
        }
        public Time_Clock_BreaksClass updateBreckClock(Time_Clock_BreaksClass objTimeClockClass)
        {
            TimeClockManagmentRepository objTimeClockMangRepository = new TimeClockManagmentRepository();
            return objTimeClockMangRepository.updateBreckClock(objTimeClockClass);
        }
        #endregion














    }
}
































 

