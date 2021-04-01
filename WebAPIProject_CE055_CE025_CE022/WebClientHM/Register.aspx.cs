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
    public partial class Register : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://localhost:44360/");
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            string text = "";
            string url = "api/patient";
            var pm = new PatientModel();
            pm.p_name = ptname.Text;
            pm.p_email = ptemail.Text;
            pm.p_contact = ptcontact.Text;
            pm.p_passwd1 = ptpasswd1.Text;
            pm.p_passwd2 = ptpasswd2.Text;
            if (ptpasswd1.Text.Equals(ptpasswd2.Text))
            {
                var res = client.PostAsJsonAsync(url, pm).Result;
                if (res.IsSuccessStatusCode)
                {
                    Response.Redirect("PLogin");
                }
                else
                {
                    text = "Email is already Exists!";
                }
            }
            else
            {
                text = "Password Doesn't Match!";
            }
            errreg.Text = text;
        }
    }
}