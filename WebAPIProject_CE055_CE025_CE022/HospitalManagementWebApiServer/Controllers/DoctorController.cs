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
    public class DoctorController : ApiController
    {
        /*[HttpGet]
        public string Greet(string name)
        {
            return ("Hello " + name);
        }*/
        [HttpGet]
        public IHttpActionResult getDoctos()
        {
            //DoctorModel dm = new DoctorModel();
            //getAllDoctors gd = new getAllDoctors();
            List<DoctorModel> dm = new List<DoctorModel>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DoctorModel", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                dm.Add(new DoctorModel()
                {
                    d_id = Convert.ToInt32(sdr.GetValue(0)),
                    d_name = sdr.GetValue(1).ToString(),
                    d_email = sdr.GetValue(2).ToString(),
                    d_address = sdr.GetValue(3).ToString(),
                    d_contact = sdr.GetValue(4).ToString(),
                    d_experience = sdr.GetValue(5).ToString(),
                    d_speciality = sdr.GetValue(6).ToString(),
                });
            }
            //gd.allDoctor = dt;
            //con.Close();
            return Ok(dm);
        }

        [HttpPost]
        public string addDoctor(DoctorModel dm)
        {
            string msg;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into DoctorModel (d_name, d_address, d_email, d_contact, d_experience, d_speciality) values(@dname, @daddress, @demail, @dcontact, @dexperience, @dspeciality)", con);
            cmd.Parameters.AddWithValue("@dname", dm.d_name);
            cmd.Parameters.AddWithValue("@daddress", dm.d_address);
            cmd.Parameters.AddWithValue("@demail", dm.d_email);
            cmd.Parameters.AddWithValue("@dcontact", dm.d_contact);
            cmd.Parameters.AddWithValue("@dexperience", dm.d_experience);
            cmd.Parameters.AddWithValue("@dspeciality", dm.d_speciality);

            int g = cmd.ExecuteNonQuery();
            if (g == 1)
            {
                msg = "Doctor Successfully Added!";
            }
            else
            {
                msg = "Failed to Insert Doctor!";
            }
            con.Close();
            return (msg);
        }

        [HttpPut]
        public HttpResponseMessage updateDoctor(DoctorModel dm)
        {
            string msg = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update DoctorModel set d_name = @dname, d_address = @daddress, d_email = @demail, d_contact = @dcontact, d_experience = @dexperience, d_speciality = @dspeciality where d_email = @demail", con);
            cmd.Parameters.AddWithValue("@dname", dm.d_name);
            cmd.Parameters.AddWithValue("@daddress", dm.d_address);
            cmd.Parameters.AddWithValue("@demail", dm.d_email);
            cmd.Parameters.AddWithValue("@dcontact", dm.d_contact);
            cmd.Parameters.AddWithValue("@dexperience", dm.d_experience);
            cmd.Parameters.AddWithValue("@dspeciality", dm.d_speciality);

            int g = cmd.ExecuteNonQuery();
            con.Close();
            if (g == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to Update");
            }
            //return (msg);
        }

        [HttpDelete]
        public HttpResponseMessage deleteDoctor(int did)
        {
            string msg = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Soc_Web_Api\HospitalManagementWebApi\HospitalManagementWebApiServer\hpdb.mdf;Integrated Security=True;Connect Timeout=30");
            //con.Open();
            Console.WriteLine(did);
            SqlCommand cmd = new SqlCommand("Delete DoctorModel where d_id = @did", con);
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Connection = con;
            con.Open();
            int g = cmd.ExecuteNonQuery();
            if (g >= 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to Delete");
            }
            //return (msg);
        }
    }
}
