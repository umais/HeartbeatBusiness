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
        public List<Invoice> InvoiceListing([FromBody] List<HeartbeatParams> lst)
        {
            List<Invoice> invoiceList=new List<Invoice>();
            if (lst.Count == 2)
              invoiceList=  repo.GetInvoice(lst[0].ParamValue, lst[1].ParamValue);

            return invoiceList;
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
