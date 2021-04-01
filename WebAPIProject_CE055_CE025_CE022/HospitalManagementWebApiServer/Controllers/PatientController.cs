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
    public class PatientController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage insertPatient(PatientModel patient)
        {
            string msg = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query = "select p_email from Patient where p_email = @pemail";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.Parameters.AddWithValue("@pemail", patient.p_email);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Already Exists!");
            }
            else
            {
                dr.Close();
                SqlCommand cmd2 = new SqlCommand("Insert into Patient (p_name, p_email, p_contact, p_passwd1, p_passwd2) values(@pname, @pemail, @pcontact, @pass1, @pass2)", con);
                cmd2.Parameters.AddWithValue("@pname", patient.p_name);
                cmd2.Parameters.AddWithValue("@pemail", patient.p_email);
                cmd2.Parameters.AddWithValue("@pcontact", patient.p_contact);
                cmd2.Parameters.AddWithValue("@pass1", patient.p_passwd1);
                cmd2.Parameters.AddWithValue("@pass2", patient.p_passwd2);
                int g = cmd2.ExecuteNonQuery();
                if (g == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Registered Successfully!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to Register!");
                }
            }
        }

        [HttpPut]
        public HttpResponseMessage updatePatient(PatientModel patient)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Patient set p_name = @pname, p_email = @pemail, p_contact = @pcontact, p_passwd1 = @pass1, p_passwd2 = @pass2 where p_email = @pemail", con);
            cmd.Parameters.AddWithValue("@pname", patient.p_name);
            cmd.Parameters.AddWithValue("@pemail", patient.p_email);
            cmd.Parameters.AddWithValue("@pcontact", patient.p_contact);
            cmd.Parameters.AddWithValue("@pass1", patient.p_passwd1);
            cmd.Parameters.AddWithValue("@pass2", patient.p_passwd2);
            int g = cmd.ExecuteNonQuery();
            if (g == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Updated!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Email does not exists!");
            }
        }
    }
}
