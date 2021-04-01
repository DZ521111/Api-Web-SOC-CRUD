using HospitalManagementWebApiServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HospitalManagementWebApiServer.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage validCredentials(AuthModel am)
        {
            string msg = "";
            if (am.username.Equals("Admin") && am.password.Equals("admin2021"))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid");
            }
        }
    }
}
