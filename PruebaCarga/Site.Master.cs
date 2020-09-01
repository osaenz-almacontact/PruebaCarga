using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCarga
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                else
                {
                    if ((string)Session["Nombres"] == "" || (string)Session["Nombres"] == null)
                    {
                        FormsAuthentication.RedirectToLoginPage();
                    }
                    else
                    {
                        string NombresYApellidos = Convert.ToString(Session["Nombres"]);
                        int TipoUsuario = Convert.ToInt32(Session["TipoUsuario"]);
                        LabNombres.Text = NombresYApellidos;
                        if (TipoUsuario == 1 || TipoUsuario == 2)
                        {
                            DivMenu.Visible = true;
                        }
                        else
                        {
                            DivMenu.Visible = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}