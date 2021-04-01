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
using System.Data;

namespace WebClientHM
{
    public partial class AllDoctors : System.Web.UI.Page
    {
        HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://localhost:44360/");
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            var url = "api/doctor";
            IEnumerable<DoctorModel> dm = null;
            //List<string> data = new List<string>();
            var res = client.GetAsync(url);
            res.Wait();
            var dataread = res.Result;
            if (dataread.IsSuccessStatusCode)
            {
                var data = dataread.Content.ReadAsAsync<IList<DoctorModel>>();
                data.Wait();
                dm = data.Result;
                gridview.DataSource = dm.ToList();
                gridview.DataBind();
            }
            
        }
    }
}