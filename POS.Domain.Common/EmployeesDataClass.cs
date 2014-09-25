using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common.Employee
{
   public class EmployeesDataClass
    {
      public string CashierID {get; set;}
	  public string CustNo {get; set;}
	  public string DepartmentID {get; set;}
	  public string Passwd {get; set;}
      public string SwipeID {get; set;}
	  public decimal HourlyWage {get; set;}
	  public int FormColor {get; set;}
	  public string varCDL {get; set;}
	  public string varName {get; set;}
	  public string CFASetupCompany {get; set;}
	  public string CFASetupTax {get; set;}
      public string CFASetupBonus {get; set;}
	  public string CFASetupAccounting {get; set;}
	  public string CFASetupDiscounts {get; set;}
      public string CFASetupDisplay {get; set;}
	  public string CFASetupDefPrinter {get; set;}
	  public string CFAInvenAdd {get; set;}
	  public string CFAInvenEdit {get; set;}
 	  public string CFAVendorsAdd {get; set;}
	  public string CFAVendorsEdit {get; set;}
	  public string CFADeptsAdd {get; set;}
	  public string CFADeptsEdit {get; set;}
	  public string CFAInvenTickVouch {get; set;}
	  public string CFACustadd {get; set;}
	  public string CFACustEdit {get; set;}
	  public string CFAReportsDisplay {get; set;}
	  public string CFAReportsDDR {get; set;}
	  public string CFAReportsPrint {get; set;}
	  public string CFAInvoiceDiscount {get; set;}
	  public string CFAInvoicePriceChange {get; set;}
	  public string CFAInvoiceDeleteItems {get; set;}
	  public string CFAInvoiceVoid {get; set;}
	  public string CFACREAcct {get; set;}
	  public string CFACREExit {get; set;}
	  public int varDirty {get; set;}
	  public DateTime LastDDR {get; set;}
	  public string CFADisplayBalance {get; set;}
	  public string CFARefundItem {get; set;}
	  public int DispPayOption {get; set;}
	  public int DispItemOption {get; set;}
	  public string varEmpName {get; set;}
	  public string CFAReceiveItems {get; set;}
	  public string CFADOPOS {get; set;}
	  public string CFAINSTANTPOS {get; set;}
	  public string SectionID {get; set;}
      public string CFAOtherTables {get; set;}
	  public string CFAAcceptCash {get; set;}
	  public string CFATRANSFERNOSWIPE {get; set;}
	  public string CFAADDCCTIPS {get; set;}
	  public int varDisabled {get; set;}
	  public string CFAPRINTHOLD {get; set;}
	  public string CFAOpenCashDrawer {get; set;}
	  public int varCCTipsNow {get; set; }
	  public int varReqClockIn {get; set;}
	  public string CFASplitChecks {get; set;}
	  public string CFATransferTables {get; set;}
	  public string CFAExtraItem {get; set;}
	  public string CFATaxExempt {get; set;}
	  public string CFAGCSell {get; set;}
	  public string CFAGCRedeem {get; set;}
	  public string CFASELLSPECIALITEM {get; set;}
	  public string CFAVENDORPAYOUT {get; set;}
	  public string CFAAPPLYGRATUITY {get; set;}
	  public string FirstName {get; set;}
	  public string MiddleName {get; set;}
	  public string LastName  {get; set;}
	  public string varSSN {get; set;}
	  public string Address1 {get; set;}
	  public string Address2 {get; set;}
	  public string varCity {get; set;}
	  public string varState {get; set;}
	  public string ZipCode {get; set;}
	  public string Phone1 {get; set;}
	  public string varEMail {get; set;}
	  public DateTime varBirthday {get; set;}
	  public string varPicture {get; set;}
	  public string CFABUYBACKSTRADES {get; set;}
	  public string CFACCForce {get; set;}
	  public string CFACCBelowFloor {get; set;}
	  public decimal CurrentCash {get; set;}
	  public string CFACashAlerts {get; set;}
	  public string CFACashPickup {get; set;}
	  public string CDLStationsID {get; set;}
	  public string CFAIssueCreditSlip {get; set;}
	  public string CFARedeemCreditSlip {get; set;}
	  public string CFAREFUNDOVERRIDE {get; set;}
	  public string CFADRAWERTRANSFER {get; set;}
	  public string CFALARGEPURCHASES {get; set;}
	  public string CFAAUCTIONPHOTO {get;set;}
	  public string CFAAUCTIONLISTREDEEM {get; set;}
	  public string CFAAUCTIONSHIP {get; set;}
	  public string CFAAPPROVECASHCOUNT {get; set;}
	  public string OrigEmpID {get; set;}
	  public string OrigStoreID {get; set;}
	  public string CDName {get; set;}
	  public string CFAAPPROVEOLDRETURNS {get; set;}
	  public string CFAAPPROVEEMERGENCYCLOCKOUT {get; set;}
	  public float varTimeWorkedThisPeriod {get; set;}
 	  public int varOvertimeThreshold {get; set;}
	  public string CFAPULLBACKINVOICE {get; set;}
	  public string varCFAMANAGETIMECLOCK {get; set;}
	  public string CFAPERFORMENDOFDAY {get; set;}
	  public string CFAHOSTLOGIN {get; set;}
	  public string CFARESTOPENTABS {get; set;}
	  public string CFARESTTAKEOUT {get; set;}
	  public string CFARESTDELIVERY {get; set;}
	  public string CFAINVOICEDELETESENT {get; set;}
	  public string CFAINVENVIEW {get; set;}
	  public string CFAINVENVIEWCOST {get; set;}
	  public string CFAINVENNEGATIVEINSTANTPOS {get; set;}
	  public string CFAENDTRANSCASH {get; set;}
	  public string CFAENDTRANSACCOUNT {get; set;}
      public string CFARESTCOMP { get; set; }
    public string CFA_CH_FORCE {get; set; }
	public string CFA_TS_CONFIG {get; set; }
	public string CFA_TRANSFER_SERVER {get; set; }
	public string CFA_BACKUP_DATABASE {get; set; }
	public string CFA_CREDIT_CARD_SETTLEMENT {get; set; }
	public string CFA_KITCHEN_REPRINT {get; set; }
	public string CFA_SETUP_RECEIPT_NOTES {get; set; }
	public string CFA_MANAGE_TIMECLOCK_OWNTIME {get; set; }
	public string CFA_SETUP_ADD_EMPLOYEES {get; set; }
	public string CFA_SETUP_EDIT_EMPLOYEES {get; set; }
	public string CFA_INVENTORY_PROMOTIONS {get; set; }
	public string CFA_INVOICE_DISCOUNTS_BELOW_X {get; set; }
	public string CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT {get; set; }
	public string CFA_REPORTS_VIEW_HISTORICAL_DATA {get; set; }
	public string CFA_INVEN_MISC_FIELD_LOCKDOWN {get; set; }
	public string CFA_HH_Create_PO {get; set; }
	public string CFA_HH_DSD {get; set; }
	public string CFA_HH_DSD_Credit {get; set; }
	public string CFA_HH_PO_Receive {get; set; }
	public string CFA_HH_Inv_Edit {get; set; }
	public string CFA_HH_Inv_Adjust {get; set; }
	public string CFA_HH_Inv_Count {get; set; }
	public string CFA_HH_Setup {get; set; }
	public string CFA_CASHIER_OVERRIDE_LICENSESCAN {get; set; }
	public string CFA_INVEN_DELETE {get; set; }
	public string CFA_CASHIER_MANUALY_ENTER_AGE {get; set; }
	public DateTime CreateDate {get; set; }
	public DateTime DateDisabled {get; set; }
	public string CFA_INVEN_ADD_COUPON {get; set; }
	public string CFA_INVEN_GLOBALPRICING {get; set; }
	public string CFA_EMP_SCHEDULE_OVERRIDE {get; set; }
	public string CFA_LABOR_SCHEDULER {get; set; }
	public string GLNumber {get; set; }
	public string CFA_NEGATIVE_PRICE_CHANGE {get; set; }
	public string CFA_CUSTOMER_EDIT_CHARGEATCOST {get; set; }
	public string CFA_GPI_FUEL_DRIVE_OFF {get; set; }
	public string CFA_SETUP_VPDCONFIGURATION {get; set; }
	public string CFA_CLOSE_SHIFT {get; set; }
	public string CFA_REPRINT_RECEIPT {get; set; }
	public DateTime Locked_Time {get; set; }
	public int Retry_Count {get; set; }
	public string Password_Hash {get; set; }
	public string Salt_Key {get; set; }
    }
}
