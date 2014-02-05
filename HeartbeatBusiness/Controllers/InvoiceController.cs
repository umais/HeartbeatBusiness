using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HeartbeatBusiness.DataAccess;
using HeartbeatBusiness.BusinessObjects;
using HeartbeatBusiness.Filters;
namespace HeartbeatBusiness.Controllers
{
    public class InvoiceController : ApiController
    {
        InvoiceSQLRepository repo;
        public InvoiceController()
        {
            repo = new InvoiceSQLRepository();
        }

        [HttpPost]
        public int InvoiceListing([FromBody] List<HeartbeatParams> lst)
        {
           return repo.InsertInvoice(lst);
        }


        [ParamFilter]
        public List<Invoice> getInvoiceByParams(List<HeartbeatParams> filters)
        {
            List<Invoice> invoiceList = new List<Invoice>();
            if (filters.Count == 2)
                invoiceList = repo.GetInvoice(filters[0].ParamValue, filters[1].ParamValue);

            return invoiceList;
        }
    }
}
