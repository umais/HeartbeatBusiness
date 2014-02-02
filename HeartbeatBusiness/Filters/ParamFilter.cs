using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using HeartbeatBusiness.BusinessObjects;
namespace HeartbeatBusiness.Filters
{
    public class ParamFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
           public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //var json = actionContext.Request.RequestUri.ParseQueryString()["json"];
            var queryParams = actionContext.Request.RequestUri.Query;

            var json = HttpUtility.ParseQueryString(queryParams).Get("json");

            var serializer = new JavaScriptSerializer();
            actionContext.ActionArguments["filters"] = serializer.Deserialize(json, typeof(List<HeartbeatParams>));
        }
    }
    }
