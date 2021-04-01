using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalManagementWebApiServer.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebClientHM
{
    public partial class AddDoctor : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://localhost:44360/");
            /*client = new HttpClient();
            client.BaseAddress = baseAddress;*/
            //get();
        }

        /*public void get()
        {
            var url = "api/doctor";
            HttpResponse response = client.GetAsync(url).Result;

        }*/

        protected void btnadd_Click(object sender, EventArgs e)
        {
            //client = new HttpClient();
            //client.BaseAddress = baseAddress;
            string msg = "";
            var dm = new DoctorModel();
            dm.d_name = docname.Text;
            dm.d_email = docemail.Text;
            dm.d_address = docaddress.Text;
            dm.d_contact = doccontact.Text;
            dm.d_experience = docexperience.Text;
            dm.d_speciality = docspeciality.Text;
            //string data = JsonConvert.SerializeObject(dm);
            //StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var res = client.PostAsJsonAsync("api/doctor", dm).Result;
            if (res.IsSuccessStatusCode)
            {
                msg = "Doctor Added Successfully!";
            }
            else
            {
                msg = "Failed to Add!";
            }
            //HttpResponse res = client.PostAsync(client.BaseAddress + "api/doctor", content).Result;
            //string msg = client.PostAsync(client.BaseAddress + "doctor", content).Result.ToString();
            errmsg.Text = msg;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string msg = "";
            var dm = new DoctorModel();
            dm.d_name = docname.Text;
            dm.d_email = docemail.Text;
            dm.d_address = docaddress.Text;
            dm.d_contact = doccontact.Text;
            dm.d_experience = docexperience.Text;
            dm.d_speciality = docspeciality.Text;
            //string data = JsonConvert.SerializeObject(dm);
            //StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var res = client.PutAsJsonAsync("api/doctor", dm).Result;
            //var result = res.Content.ReadAsAsync<String>().ToString();
            if (res.IsSuccessStatusCode)
            {
                msg = "Doctor Updated Successfully!";
            }
            else
            {
                msg = "Failed to Update!";
            }
            //HttpResponse res = client.PostAsync(client.BaseAddress + "api/doctor", content).Result;
            //string msg = client.PostAsync(client.BaseAddress + "doctor", content).Result.ToString();
            errmsg.Text = msg;
        }
    }
}