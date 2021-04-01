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
    public partial class ViewAppointment : System.Web.UI.Page
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

        protected void btnapp_Click(object sender, EventArgs e)
        {
            IEnumerable <AppointmentModel> apm = null;
            string url = "api/appointment/";
            string pid = ((string)Session["curruser"]);
            var res = client.GetAsync(url + "?pid=" + pid.ToString());
            res.Wait();
            var data = res.Result;
            if (data.IsSuccessStatusCode)
            {
                var all = data.Content.ReadAsAsync<IList<AppointmentModel>>();
                all.Wait();
                apm = all.Result;
                allapp.DataSource = apm.ToList();
                allapp.DataBind();
            }
        }
    }
}