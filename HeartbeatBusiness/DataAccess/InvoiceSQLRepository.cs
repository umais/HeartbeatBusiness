using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HeartbeatBusiness.BusinessObjects;

namespace HeartbeatBusiness.DataAccess
{
    //Will have to implement interface to apply repo pattern but later.
    public class InvoiceSQLRepository
    {
       
          public string HeartbeatConnectionString { get; set; }


        public InvoiceSQLRepository()
        {
            //Need To take this out at some point
            HeartbeatConnectionString = ConfigurationManager.ConnectionStrings["HeartbeatConnectionString"].ConnectionString;
        }

        public List<Invoice> GetInvoice(string startDate,string endDate)
        {
            List<Invoice> invoicelist = new List<Invoice>();
            using (var conn = new SqlConnection(HeartbeatConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("GetInvoice", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StartDate", System.Data.SqlDbType.Date);
                    cmd.Parameters["@StartDate"].Value = startDate;

                    cmd.Parameters.Add("@EndDate", System.Data.SqlDbType.Date);
                    cmd.Parameters["@EndDate"].Value = endDate;

                    var myReader = cmd.ExecuteReader();

                    try
                    {
                      

                        
                        while (myReader.Read())
                        {


                            invoicelist.Add(new Invoice(myReader));



                            

                        }

                        

                       

                    }
                    catch (Exception ex)
                    {
                        // LOG ERROR
                        throw ex;
                    }
                    return invoicelist;
                }
            }
        }
//Get Users


        public List<HeartbeatParams> GetAllWorkers()
        {
            List<HeartbeatParams> workers = new List<HeartbeatParams>();
            using (var conn = new SqlConnection(HeartbeatConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("GetAllWorkers", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                   

                    var myReader = cmd.ExecuteReader();

                    try
                    {



                        while (myReader.Read())
                        {


                            workers.Add(new HeartbeatParams(myReader,"users"));





                        }





                    }
                    catch (Exception ex)
                    {
                        // LOG ERROR
                        throw ex;
                    }
                    return workers;
                }
            }
        }
        //End Get Workers

        //Get Tasks
        public List<HeartbeatParams> GetAllTasks()
        {
            List<HeartbeatParams> workers = new List<HeartbeatParams>();
            using (var conn = new SqlConnection(HeartbeatConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("GetAllTasks", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    var myReader = cmd.ExecuteReader();

                    try
                    {



                        while (myReader.Read())
                        {


                            workers.Add(new HeartbeatParams(myReader, "tasks"));





                        }





                    }
                    catch (Exception ex)
                    {
                        // LOG ERROR
                        throw ex;
                    }
                    return workers;
                }
            }
        }


        //End Get Tasks


        //Insert Invoice

        public int InsertInvoice(List<HeartbeatParams> parameters)
        {
            List<Invoice> invoicelist = new List<Invoice>();
            int result=0;
            using (var conn = new SqlConnection(HeartbeatConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("InsertTime", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    
                    cmd.Parameters.Add(parameters[0].ParamName, System.Data.SqlDbType.Int);
                    cmd.Parameters[parameters[0].ParamName].Value = parameters[0].ParamValue;

                    cmd.Parameters.Add(parameters[1].ParamName, System.Data.SqlDbType.Int);
                    cmd.Parameters[parameters[1].ParamName].Value = parameters[1].ParamValue;

                    cmd.Parameters.Add(parameters[2].ParamName, System.Data.SqlDbType.Date);
                    cmd.Parameters[parameters[2].ParamName].Value = parameters[2].ParamValue;

                    cmd.Parameters.Add(parameters[3].ParamName, System.Data.SqlDbType.Int);
                    cmd.Parameters[parameters[3].ParamName].Value = parameters[3].ParamValue;

                    cmd.Parameters.Add(parameters[4].ParamName, System.Data.SqlDbType.VarChar);
                    cmd.Parameters[parameters[4].ParamName].Value = parameters[4].ParamValue;
                    

                    try
                    {
                    result= cmd.ExecuteNonQuery();

                   



                    }
                    catch (Exception ex)
                    {
                        // LOG ERROR
                        throw ex;
                    }
                
                }
            }

            return result;
        }
        //End Insert Invoice


    }
}
