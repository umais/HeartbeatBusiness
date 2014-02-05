using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HeartbeatBusiness.DataAccess;
namespace HeartbeatBusiness.BusinessObjects
{
    public class HeartbeatParams
    {
        public string ParamName { get; set; }
        public string ParamValue { get; set; }

        public HeartbeatParams() { }

        public HeartbeatParams(IDataReader dbReader,string callType)
        {
         if(callType=="users")
         {
               if (dbReader.HasColumn("WorkerID") && dbReader["WorkerID"] != DBNull.Value) ParamValue = dbReader["WorkerID"].ToString();
            if (dbReader.HasColumn("Name") && dbReader["Name"] != DBNull.Value) ParamName = dbReader["Name"].ToString();
         }

         if (callType == "tasks")
         {
             if (dbReader.HasColumn("TaskID") && dbReader["TaskID"] != DBNull.Value) ParamValue = dbReader["TaskID"].ToString();
             if (dbReader.HasColumn("TaskName") && dbReader["TaskName"] != DBNull.Value) ParamName = dbReader["TaskName"].ToString();
         }
        }
    }
}