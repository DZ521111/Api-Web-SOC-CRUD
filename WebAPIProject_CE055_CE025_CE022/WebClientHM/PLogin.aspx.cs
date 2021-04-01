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
    public partial class PLogin : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://localhost:44360/");
        }

        protected void btnplogin_Click(object sender, EventArgs e)
        {
            string url = "api/patientauth";
            var am = new AuthModel();
            am.username = plemail.Text;
            am.password = plpasswd.Text;
            var res = client.PostAsJsonAsync(url, am).Result;
            if (res.IsSuccessStatusCode)
            {
                Session["curruser"] = plemail.Text.ToString();
                Response.Redirect("Default");
            }
            else
            {
                errplogin.Text = "Invalid Credentials!";
            }
        }
    }
}