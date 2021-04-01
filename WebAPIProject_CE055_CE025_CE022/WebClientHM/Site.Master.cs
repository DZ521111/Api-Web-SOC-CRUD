using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClientHM
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curruser"] == null)
            {
                Session["curruser"] = null;
            }
            /*if (((string)Session["curruser"]) == "admin")
            {
                adminuser.Text = "admin";
            }*/
            else
            {
                cuser.Text = Session["curruser"].ToString();
            }
        }
    }
}