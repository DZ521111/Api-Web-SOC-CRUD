using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementWebApiServer.Models
{
    public class DoctorModel
    {
        public int d_id { get; set; }
        public string d_name { get; set; }
        public string d_email { get; set; }
        public string d_address { get; set; }
        public string d_contact { get; set; }
        public string d_experience { get; set; }
        public string d_speciality { get; set; }
    }
}