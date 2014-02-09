using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using HeartbeatBusiness.DataAccess;
namespace HeartbeatBusiness.BusinessObjects
{
    public class Invoice
    {
        public string InvoiceID { get; set; }
        public string CompanyName { get; set; }
        public string BillTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkDate { get; set; }
        public int HoursWorked { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string ChargeRate { get; set; }
        public string TotalAmount { get; set; }

        public Invoice() { }

        public Invoice(IDataReader dbReader)
        {

            if (dbReader.HasColumn("FirstName") && dbReader["FirstName"] != DBNull.Value) FirstName = dbReader["FirstName"].ToString();
            if (dbReader.HasColumn("LastName") && dbReader["LastName"] != DBNull.Value) LastName = dbReader["LastName"].ToString();
            if (dbReader.HasColumn("ProjectName") && dbReader["ProjectName"] != DBNull.Value) ProjectName = dbReader["ProjectName"].ToString();
            if (dbReader.HasColumn("TaskName") && dbReader["TaskName"] != DBNull.Value) TaskName = dbReader["TaskName"].ToString();
            if (dbReader.HasColumn("WorkDate") && dbReader["WorkDate"] != DBNull.Value) WorkDate = Convert.ToDateTime(dbReader["WorkDate"]).ToShortDateString();
            if (dbReader.HasColumn("HoursWorked") && dbReader["HoursWorked"] != DBNull.Value) HoursWorked = Convert.ToInt32(dbReader["HoursWorked"].ToString());
            if (dbReader.HasColumn("WorkDescription") && dbReader["WorkDescription"] != DBNull.Value) Description = dbReader["WorkDescription"].ToString();
            if (dbReader.HasColumn("ChargeRate") && dbReader["ChargeRate"] != DBNull.Value) ChargeRate = dbReader["ChargeRate"].ToString();
            if (dbReader.HasColumn("Total") && dbReader["Total"] != DBNull.Value) TotalAmount = dbReader["Total"].ToString();
            if (dbReader.HasColumn("TimeID") && dbReader["TimeID"] != DBNull.Value) InvoiceID = dbReader["TimeID"].ToString();
        
        
        }


    }
}