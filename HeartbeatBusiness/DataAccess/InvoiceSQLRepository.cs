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

    }
}
