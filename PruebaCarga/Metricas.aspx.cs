using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PruebaCarga
{
    public partial class Metricas : System.Web.UI.Page
    {
        String strConnection = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObtenerAsesor();
        }

        private void ObtenerAsesor()
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(strConnection))
                {
                    using (SqlCommand CmdObtenerResponsables = new SqlCommand("ObtenerBackOffice"))
                    {
                        CmdObtenerResponsables.Connection = con;
                        CmdObtenerResponsables.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdaObtenerResponsables = new SqlDataAdapter(CmdObtenerResponsables))
                        {
                            DataTable dtObtenerResponsables = new DataTable();
                            sdaObtenerResponsables.Fill(dtObtenerResponsables);
                            DropAgente.DataSource = dtObtenerResponsables;
                            DropAgente.DataTextField = "Backoffice";
                            DropAgente.DataBind();
                            DropAgente.Items.Insert(0, "(Seleccionar)");
                        }
                    }


                }
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}