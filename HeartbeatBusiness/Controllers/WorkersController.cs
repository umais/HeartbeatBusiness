using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HeartbeatBusiness.DataAccess;
using HeartbeatBusiness.BusinessObjects;
namespace HeartbeatBusiness.Controllers
{
    public class WorkersController : ApiController
    {

            InvoiceSQLRepository repo;
        public WorkersController()
        {
            repo = new InvoiceSQLRepository();
        }

        public List<HeartbeatParams> getAllUsers()
        {
            List<HeartbeatParams> workers = repo.GetAllWorkers();

            return workers;
        }
    }
}
