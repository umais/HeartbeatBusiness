using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HeartbeatBusiness.BusinessObjects;
using HeartbeatBusiness.DataAccess;
namespace HeartbeatBusiness.Controllers
{
    public class TasksController : ApiController
    {
            InvoiceSQLRepository repo;
        public TasksController()
        {
            repo = new InvoiceSQLRepository();
        }

        public List<HeartbeatParams> getAllTasks()
        {
          return  repo.GetAllTasks();
        }

    }
}
