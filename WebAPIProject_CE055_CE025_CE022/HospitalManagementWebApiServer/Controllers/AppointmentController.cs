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
    //Appointment Methods
    public class AppointmentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage bookAppointment(AppointmentModel bapp)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from DoctorModel", con);
            cmd1.CommandType = CommandType.Text;
            SqlDataReader dr;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                if (bapp.ad_email.Equals(dr["d_email"]))
                {
                    dr.Close();
                    SqlCommand cmd2 = new SqlCommand("Insert into Appointment (ad_email, ap_email, a_desc, a_date) values(@ademail, @apemail, @adesc, @date)", con);
                    cmd2.Parameters.AddWithValue("@ademail", bapp.ad_email);
                    cmd2.Parameters.AddWithValue("@apemail", bapp.ap_email);
                    cmd2.Parameters.AddWithValue("@adesc", bapp.a_desc);
                    cmd2.Parameters.AddWithValue("@date", bapp.a_date);
                    int g = cmd2.ExecuteNonQuery();
                    if (g == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Booked");

                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Failed");
                    }
                }
                else
                {
                    continue;
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        public IHttpActionResult getAllAppointment(string pid)
        {
            List<AppointmentModel> dm = new List<AppointmentModel>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Appointment where ap_email like'" + pid.ToString() + "%'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                dm.Add(new AppointmentModel()
                {
                    a_id = Convert.ToInt32(sdr.GetValue(0)),
                    ap_email = sdr.GetValue(1).ToString(),
                    ad_email = sdr.GetValue(2).ToString(),
                    a_date = sdr.GetValue(3).ToString(),
                    a_desc = sdr.GetValue(4).ToString(),
                });
            }
            return Ok(dm);
        }
    }
}
