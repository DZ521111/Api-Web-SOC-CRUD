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
    public partial class Profile : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://localhost:44360/");
        }

        protected void btnprupdate_Click(object sender, EventArgs e)
        {
            string msg = "";
            string url = "api/patient";
            var pm = new PatientModel();
            pm.p_name = prname.Text;
            pm.p_email = premail.Text;
            pm.p_contact = prcontact.Text;
            pm.p_passwd1 = prpasswd1.Text;
            pm.p_passwd2 = prpasswd2.Text;
            if (prpasswd1.Text.Equals(prpasswd2.Text))
            {
                var res = client.PutAsJsonAsync(url, pm).Result;
                if (res.IsSuccessStatusCode)
                {
                    msg = "Profile Updated Successfully!";
                }
                else
                {
                    msg = "Email is not valid!";
                }
            }
            else
            {
                msg = "Password Doesn't Match!";
            }
            prerr.Text = msg;
        }
    }
}