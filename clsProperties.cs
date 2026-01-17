using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tax_Consultant_25.Data_Layer;

namespace Tax_Consultant_25
{
    internal class clsProperties
    {
        #region COMMON

        public string search { get; set; }

        public int rowID { get; set; }

        #endregion

        #region CLIENTS

        public int clientID { get; set; }

        public string clientName { get; set; }

        public string clientFatherName { get; set; }

        public string clientAddress { get; set; }

        public DateTime clientDOB { get; set; }

        public string clientMobile { get; set; }

        public string clientPAN { get; set; }

        public string clientMarritialStatus { get; set; }

        public string clientGender { get; set; }

        public string clientResidencial { get; set; }

        public string clientEmail { get; set; }

        public string clientAdharNo { get; set; }

        public string clientBusinessName { get; set; }

        public string clientStatus { get; set; }

        public string clientGSTNo { get; set; }

        public string clientGSTtype { get; set; }

        public bool isGSTClient { get; set; }

        #endregion

        #region WORK MASTER

        public int workID { get; set; }

        public string workAllocatedEmpName { get; set; }

        public string workService { get; set; }

        public string workQueryByEmp { get; set; }

        public string workQuerySolution { get; set; }

        public int workQueryByEmpId { get; set; }

        #endregion

        #region WORK TYPE MASTER

        public int workTypeID { get; set; }

        public string workTypeName { get; set; }

        #endregion

        #region EMPLOYEE

        public int empId { get; set; }

        public string empName { get; set; }

        public string empMobile { get; set; }

        public string empUsername { get; set; }

        public string empPassword { get; set; }

        public string empRole { get; set; }

        #endregion

        #region SQL

        public SqlDataAdapter objDa { get; set; }

        public SqlCommand objCmd { get; set; }

        public clsConnection objCon { get; set; }

        public DataSet objDs { get; set; }

        public int flag { get; set; }

        #endregion

        #region USERNAME PASSWORD

        public string username { get; set; }

        public string password { get; set; }

        #endregion

        #region INCOME TAX

        public int incomeId { get; set; }

        public string incomeService { get; set; }

        public string incomeTaskName { get; set; }

        public string incomeTradeName { get; set; }

        public DateTime incomeInputDate { get; set; }

        public string incomeAllocatedEmpName { get; set; }

        public DateTime incomeDueDate { get; set; }

        public string incomeTypeOfReturn { get; set; }

        public string incomeYear { get; set; }

        public string incomeRecurringTask { get; set; }

        public string incomePeriodicity { get; set; }

        public int incomeFees { get; set; }

        public string incomeFeeStatus { get; set; }

        public string incomeStatus { get; set; }

        public string incomeDescription { get; set; }

        #endregion

        #region ACCOUNTING

        public int accountId { get; set; }

        public string accountService { get; set; }

        public DateTime accountInputDate { get; set; }

        public string accountWorktype { get; set; }

        public string accountAllocatedEmp { get; set; }

        public DateTime accountDueDate { get; set; }

        public string accountWorkPeriod { get; set; }

        public string accountStatus { get; set; }

        public string accountYear {  get; set; }

        #endregion

        #region PAN TAN

        public int panId { get; set; }

        public string panService { get; set; }

        public DateTime panInputDate { get; set; }

        public string panWorkType { get; set; }

        public string panAllocatedEmp { get; set; }

        public DateTime panDueDate { get; set; }

        public string panTanNo { get; set; }

        public int panFees { get; set; }

        public string panFeeStatus { get; set; }

        public string panStatus { get; set; }

        #endregion

        #region PTEC / PTRC

        public int ptecId { get; set; }

        public string ptecService { get; set; }

        public DateTime ptecInputDate { get; set; }

        public string ptecWorktype { get; set; }

        public string ptecAllocatedEmp { get; set; }

        public DateTime ptecDueDate { get; set; }

        public string ptecYear { get; set; }

        public string ptecNo { get; set; }

        public int ptecFees { get; set; }

        public string ptecFeeStatus { get; set; }

        public string ptecStatus { get; set; }

        #endregion

        #region SHOPACT

        public int shopActId { get; set; }

        public string shopActService { get; set; }

        public DateTime shopActInputDate { get; set; }

        public string shopActWorktype { get; set; }

        public string shopActAllocatedEmp { get; set; }

        public DateTime shopActDueDate { get; set; }

        public int shopActFees { get; set; }

        public string shopActFeeStatus { get; set; }

        public string shopActStatus { get; set; }

        #endregion

        #region UDYAM

        public int udyamId { get; set; }

        public string udyamService { get; set; }

        public DateTime udyamInputDate { get; set; }

        public string udyamWorktype { get; set; }

        public string udyamAllocatedEmp { get; set; }

        public DateTime udyamDueDate { get; set; }

        public int udyamFees { get; set; }

        public string udyamFeeStatus { get; set; }

        public string udyamStatus { get; set; }

        #endregion

        #region LOGIN

        public string loginUsername { get; set; }

        public string loginPassword { get; set; }

        public string loginRole { get; set; }

        #endregion

        #region TDS

        public int tdsId { get; set; }

        public string tdsService { get; set; }

        public DateTime tdsInputDate { get; set; }

        public string tdsWorktype { get; set; }

        public string tdsAllocatedEmp { get; set; }

        public DateTime tdsDueDate { get; set; }

        public string tdsYear { get; set; }

        public string tdsPeriod { get; set; }

        public string tdsStatus { get; set; }

        #endregion

        #region ALL IN ONE

        public int allOneId { get; set; }

        public string allOneService { get; set; }

        public DateTime allOneInputDate { get; set; }

        public string allOneWorktype { get; set; }

        public string allOneAllocatedEmp { get; set; }

        public DateTime allOneDueDate { get; set; }

        public string allOneYear { get; set; }

        public string allOneNumber { get; set; }

        public int allOneFee { get; set; }

        public string allOneFeeStatus { get; set; }

        public string allOneStatus { get; set; }


        #endregion

        #region GST

        public int gstId { get; set; }

        public string gstService { get; set; }

        public DateTime gstInputDate { get; set; }

        public string gstTradeName { get; set; }

        public string gstAllocatedTo { get; set; }

        public DateTime gstDueDate { get; set; }

        public string gstPeriodicity { get; set; }

        public string gstTaskName { get; set; }

        public string gstRecurringTask { get; set; }

        public string gstReturn { get; set; }

        public string gstFinancialYear { get; set; }

        public string gstStatus { get; set; }

        public string gstWorkType { get; set; }

        public string gstNumber { get; set; }

        public string gstClientType { get; set; }

        public string gstPeriod { get; set; }

        #endregion

        #region ENQUIRY

        public int enquiryId { get; set; }

        public string enquiryName { get; set; }

        public string enquiryService { get; set; }

        public string enquiryMobile { get; set; }

        public string enquiryEmail { get; set; }

        public DateTime enquiryDate { get; set; }

        #endregion

        #region FEEDBACK

        public int feedbackId { get; set; }

        public int feedbackEnqID { get; set; }

        public string feedbackName { get; set; }

        public string feedbackService { get; set; }

        public string feedbackMobile { get; set; }

        public DateTime feedbackDate { get; set; }

        public string feedbackGiven { get; set; }

        #endregion

        #region BILL

        public string billClientName { get; set; }

        public string billBusinessName { get; set; }

        public string billClientAddress { get; set; }

        public string billAmount { get; set; }

        public string billTotalAmount { get; set; }

        public string billService { get; set; }

        public string billWorkType { get; set; }

        public string billNarration { get; set; }

        #endregion

    }
}
