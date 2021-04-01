using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementWebApiServer.Models
{
    public class AppointmentModel
    {
        public int a_id { get; set; }
        public string ap_email { get; set; }
        public string ad_email { get; set; }
        public string a_date { get; set; }
        public string a_desc { get; set; }
    }
}