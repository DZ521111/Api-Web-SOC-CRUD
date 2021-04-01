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
    public partial class BookAppointment : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["curruser"] == null)
            {
                Response.Redirect("PLogin");
            }
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://localhost:44360/");
        }

        protected void book_Click(object sender, EventArgs e)
        {
            string msg = "";
            string url = "api/appointment";
            var bapp = new AppointmentModel();
            bapp.ad_email = doctoremail.Text;
            bapp.ap_email = patientemail.Text;
            bapp.a_desc = description.Text;
            bapp.a_date = date.Text.ToString();
            var res = client.PostAsJsonAsync(url, bapp).Result;
            if (res.IsSuccessStatusCode)
            {
                msg = "Appointment Booked Successfully!";
            }
            else
            {
                msg = "Failed to Book or Doctor does not exists!";
            }
            errbook.Text = msg;
        }
    }
}