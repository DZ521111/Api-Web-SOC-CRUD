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
    public partial class DeleteDoctor : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://localhost:44360/");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string text = "";
            var url = "api/doctor/";
            //deleteDoctor dd = new deleteDoctor();
            int did = int.Parse(docid.Text);
            var res = client.DeleteAsync(url + "?did=" + did.ToString());
            res.Wait();
            var msg = res.Result;
            if (msg.IsSuccessStatusCode)
            {
                text = "Doctor Deleted Successfully!";
            }
            else
            {
                text = "Failed to Delete!";
            }
            errdelete.Text = text;
        }
    }
}