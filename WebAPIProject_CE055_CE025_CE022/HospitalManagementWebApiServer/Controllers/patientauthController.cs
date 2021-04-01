using HospitalManagementWebApiServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HospitalManagementWebApiServer.Controllers
{
    public class patientauthController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage validatePatient(AuthModel am)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Patient", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.Text;
            //DataTable dt = new DataTable("PTable");
            //da.Fill(dt);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (am.username.Equals(dr["p_email"]) && am.password.Equals(dr["p_passwd1"]))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    continue;
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Credentials");
            dr.Close();
        }
    }
}
