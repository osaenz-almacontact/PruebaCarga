using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCarga
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = 0;
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Validar_Ususario"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsusario", TxtUsuario.Value);
                        cmd.Parameters.AddWithValue("@Password", TxtPassword.Value);
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                    switch (userId)
                    {
                        case -1:
                            LabMensaje.Text = "Username and/or password is incorrect.";
                            break;
                        case -2:
                            LabMensaje.Text = "Account has not been activated.";
                            break;
                        default:
                            ObtenerPerfil();
                            FormsAuthentication.RedirectFromLoginPage(TxtUsuario.Value, true);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LabMensaje.Text = ex.ToString();
            }
        }

        public void ObtenerPerfil()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ObtenerPerfilUsusario"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsusario", TxtUsuario.Value);
                        cmd.Parameters.AddWithValue("@Password", TxtPassword.Value);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataAdapter DaObtenerPerfil = new SqlDataAdapter(cmd))
                        {
                            DataTable DtObtenerPerfil = new DataTable();
                            DaObtenerPerfil.Fill(DtObtenerPerfil);
                            Session["Nombres"] = DtObtenerPerfil.Rows[0]["Nombres"].ToString().Trim();
                            Session["TipoUsuario"] = DtObtenerPerfil.Rows[0]["TipoUsuario"];
                        }
                        con.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                LabMensaje.Text = ex.ToString();
            }
        }
    }
}