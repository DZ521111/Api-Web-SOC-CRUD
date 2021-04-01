using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementWebApiServer.Models
{
    public class PatientModel
    {
        public int p_id { get; set; }
        public string p_name { get; set; }
        public string p_email { get; set; }
        public string p_contact { get; set; }
        public string p_passwd1 { get; set; }
        public string p_passwd2 { get; set; }
    }
}