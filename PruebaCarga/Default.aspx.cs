using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaCarga
{
    public partial class _Default : Page
    {
        String strConnection = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                int TipoUsuario = Convert.ToInt32(Session["TipoUsuario"]);
                if (TipoUsuario == 3)
                {
                    DivBackOffice.Visible = false;
                    DivCargarDatos.Visible = false;
                }
                else
                {
                    DivBackOffice.Visible = true;
                    DivCargarDatos.Visible = true;
                }

                ObetnerOrdenes();
                ObetnerContadorOrdenes();

                try
                {
                    if (!IsPostBack)
                    {
                        using (SqlConnection con = new SqlConnection(strConnection))
                        {
                            using (SqlCommand CmdObtenerResponsables = new SqlCommand("ObtenerResponsable"))
                            {
                                CmdObtenerResponsables.Connection = con;
                                CmdObtenerResponsables.CommandType = CommandType.StoredProcedure;
                                using (SqlDataAdapter sdaObtenerResponsables = new SqlDataAdapter(CmdObtenerResponsables))
                                {
                                    DataTable dtObtenerResponsables = new DataTable();
                                    sdaObtenerResponsables.Fill(dtObtenerResponsables);
                                    DropResponsable.DataSource = dtObtenerResponsables;
                                    DropResponsable.DataTextField = "NombreResponsable";
                                    DropResponsable.DataValueField = "Id";
                                    DropResponsable.DataBind();
                                    DropResponsable.Items.Insert(0, "(Seleccionar)");
                                }
                            }


                        }
                        using (SqlConnection con = new SqlConnection(strConnection))
                        {
                            using (SqlCommand CmdObtenerDepartamentos = new SqlCommand("ObtenerDepartamentos"))
                            {
                                CmdObtenerDepartamentos.Connection = con;
                                CmdObtenerDepartamentos.CommandType = CommandType.StoredProcedure;
                                using (SqlDataAdapter sdaObtenerDepartamentos = new SqlDataAdapter(CmdObtenerDepartamentos))
                                {
                                    DataTable dtObtenerDepartamentos = new DataTable();
                                    sdaObtenerDepartamentos.Fill(dtObtenerDepartamentos);
                                    DropDepartamento.DataSource = dtObtenerDepartamentos;
                                    DropDepartamento.DataTextField = "NombreDepartamento";
                                    DropDepartamento.DataValueField = "Id";
                                    DropDepartamento.DataBind();
                                    DropDepartamento.Items.Insert(0, "(Seleccionar)");
                                }
                            }


                        }
                        using (SqlConnection con = new SqlConnection(strConnection))
                        {
                            using (SqlCommand CmdObtenerBackOffice = new SqlCommand("ObtenerBackOffice"))
                            {
                                CmdObtenerBackOffice.Connection = con;
                                CmdObtenerBackOffice.CommandType = CommandType.StoredProcedure;
                                using (SqlDataAdapter DaObtenerBackOffice = new SqlDataAdapter(CmdObtenerBackOffice))
                                {
                                    DataTable DtObtenerBackOffice = new DataTable();
                                    DaObtenerBackOffice.Fill(DtObtenerBackOffice);
                                    DropBuscarBackoffice.DataSource = DtObtenerBackOffice;
                                    DropBuscarBackoffice.DataTextField = "Backoffice";
                                    DropBuscarBackoffice.DataBind();
                                    DropBuscarBackoffice.Items.Insert(0, "(Seleccionar)");
                                }
                            }


                        }

                        using (SqlConnection con = new SqlConnection(strConnection))
                        {
                            using (SqlCommand CmdObtenerBackOffice = new SqlCommand("ObtenerProyeccion"))
                            {
                                CmdObtenerBackOffice.Connection = con;
                                CmdObtenerBackOffice.CommandType = CommandType.StoredProcedure;
                                using (SqlDataAdapter DaObtenerBackOffice = new SqlDataAdapter(CmdObtenerBackOffice))
                                {
                                    DataTable DtObtenerBackOffice = new DataTable();
                                    DaObtenerBackOffice.Fill(DtObtenerBackOffice);
                                    DropProyeccion.DataSource = DtObtenerBackOffice;
                                    DropProyeccion.DataTextField = "Proyeccion";
                                    DropProyeccion.DataBind();
                                    DropProyeccion.Items.Insert(0, "(Seleccionar)");
                                }
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('" + ex.Message + "');", true);
                }

            }
        }

        public void ObetnerOrdenes()
        {
            int TipoUsuario = Convert.ToInt32(Session["TipoUsuario"]);
            string NonbreAsesor = Convert.ToString(Session["Nombres"]);
            if (TipoUsuario != 3)
            {
                NonbreAsesor = "0";
            }
            DataTable DataMarshal;
            using (SqlCommand CmdObtenerOrdenes = new SqlCommand("ObtenerOrdenes"))
            {
                using (SqlConnection connex = new SqlConnection(strConnection))
                {
                    CmdObtenerOrdenes.Connection = connex;
                    CmdObtenerOrdenes.CommandType = CommandType.StoredProcedure;
                    CmdObtenerOrdenes.Parameters.AddWithValue("@NombreAsesor", NonbreAsesor);

                    SqlDataAdapter adapter = new SqlDataAdapter(CmdObtenerOrdenes);
                    connex.Open();
                    CmdObtenerOrdenes.ExecuteNonQuery();

                    DataMarshal = new DataTable();
                    adapter.Fill(DataMarshal);
                    DataInforme.DataSource = DataMarshal;
                    DataInforme.DataBind();

                }
            }

        }

        public void ObtenerTopOrdenes(int IdOrden)
        {
            string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
            if (IdOrden != null)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand CmdObtenerTopOrdenes = new SqlCommand("ObtenerTopOrdenes"))
                    {
                        CmdObtenerTopOrdenes.Connection = con;
                        CmdObtenerTopOrdenes.CommandType = CommandType.StoredProcedure;
                        CmdObtenerTopOrdenes.Parameters.AddWithValue("@IdOrden", IdOrden);
                        using (SqlDataAdapter daObtenerTopOrdenes = new SqlDataAdapter(CmdObtenerTopOrdenes))
                        {
                            DataTable dtObtenerTopOrdenes = new DataTable();
                            daObtenerTopOrdenes.Fill(dtObtenerTopOrdenes);
                            RepterUltimosComentarios.DataSource = dtObtenerTopOrdenes;
                            RepterUltimosComentarios.DataBind();
                        }
                    }


                }
            }
        }
        public void ObetnerContadorOrdenes()
        {
            DataTable DataConteoOrdenes;
            int TipoUsuario = Convert.ToInt32(Session["TipoUsuario"]);
            string NonbreAsesor = Convert.ToString(Session["Nombres"]);
            if (TipoUsuario != 3)
            {
                NonbreAsesor = "0";
            }
            using (SqlCommand CmdObtenerContadorOrdenes = new SqlCommand("ObtenerContadorOrdenes"))
            {
                using (SqlConnection connex = new SqlConnection(strConnection))
                {
                    CmdObtenerContadorOrdenes.Connection = connex;
                    CmdObtenerContadorOrdenes.CommandType = CommandType.StoredProcedure;
                    CmdObtenerContadorOrdenes.Parameters.AddWithValue("@Perfil", TipoUsuario);
                    CmdObtenerContadorOrdenes.Parameters.AddWithValue("@NombreAsesor", NonbreAsesor);

                    SqlDataAdapter adapter = new SqlDataAdapter(CmdObtenerContadorOrdenes);
                    connex.Open();
                    CmdObtenerContadorOrdenes.ExecuteNonQuery();

                    DataConteoOrdenes = new DataTable();
                    adapter.Fill(DataConteoOrdenes);
                    LabPorVencer.Text = DataConteoOrdenes.Rows[0]["POR VENCER"].ToString();
                    LabVencidos.Text = DataConteoOrdenes.Rows[0]["VENCIDO"].ToString();
                    LabActualizados.Text = DataConteoOrdenes.Rows[0]["ACTUALIZADO"].ToString();

                }
            }
        }
        protected void DataInforme_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                if (e.Row.Cells[7].Text == "VENCIDO")
                {
                    e.Row.Cells[7].BackColor = Color.Red;
                }
                else if (e.Row.Cells[7].Text == "POR VENCER")
                {
                    e.Row.Cells[7].BackColor = Color.Orange;
                }
                else if (e.Row.Cells[7].Text == "ACTUALIZADO")
                {
                    e.Row.Cells[7].BackColor = Color.Green;
                }
            }
        }
        protected void DropDepartamento_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDepartamento.SelectedIndex >= 0)
            {
                using (SqlCommand CmdObtenerCiudades = new SqlCommand("ObtenerCiudades"))
                {
                    using (SqlConnection con = new SqlConnection(strConnection))
                    {
                        CmdObtenerCiudades.Connection = con;
                        CmdObtenerCiudades.CommandType = CommandType.StoredProcedure;
                        CmdObtenerCiudades.Parameters.AddWithValue("@Id", DropDepartamento.SelectedValue);
                        using (SqlDataAdapter sdaObtenerCiudades = new SqlDataAdapter(CmdObtenerCiudades))
                        {
                            DataTable dtObtenerCiudades = new DataTable();
                            sdaObtenerCiudades.Fill(dtObtenerCiudades);
                            DropCiudad.DataSource = dtObtenerCiudades;
                            DropCiudad.DataTextField = "NombreCiudad";
                            DropCiudad.DataValueField = "Id";
                            DropCiudad.DataBind();
                        }
                    }
                }
            }

        }

        protected void DropResponsable_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropResponsable.SelectedIndex >= 0)
            {
                int IdOrden = DropResponsable.SelectedIndex;
                using (SqlCommand CmdObtenerDetalleResponsables = new SqlCommand("ObtenerDetalleResponsable"))
                {
                    using (SqlConnection con = new SqlConnection(strConnection))
                    {
                        CmdObtenerDetalleResponsables.Connection = con;
                        CmdObtenerDetalleResponsables.CommandType = CommandType.StoredProcedure;
                        CmdObtenerDetalleResponsables.Parameters.AddWithValue("@Id", DropResponsable.SelectedValue);
                        using (SqlDataAdapter DaObtenerResponsables = new SqlDataAdapter(CmdObtenerDetalleResponsables))
                        {
                            DataTable DtObtenerResponsables = new DataTable();
                            DaObtenerResponsables.Fill(DtObtenerResponsables);
                            DropDetalleResponsable.DataSource = DtObtenerResponsables;
                            DropDetalleResponsable.DataTextField = "NombreDescripcionResponsable";
                            DropDetalleResponsable.DataValueField = "Id";
                            DropDetalleResponsable.DataBind();
                        }
                    }
                }

            }
        }

        protected void BrnCargar_Click(object sender, EventArgs e)
        {
            if (FlpCargarArchivo.PostedFile.FileName != null)
            {
                try
                {
                    //Upload and save the file
                    DateTime ahora = DateTime.Now;

                    string fecha = ahora.ToString("yyyyMMddHHmmss");

                    string path = Server.MapPath("~/Files/") + Path.GetFileName(fecha + FlpCargarArchivo.PostedFile.FileName);
                    FlpCargarArchivo.SaveAs(path);
                    //string path="C:\\ Users\\ Hemant\\Documents\\example.xlsx";
                    //Create connection string to Excel work book
                    string excelConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + path + ";Extended Properties='Excel 8.0;HDR=YES'";
                    //Create Connection to Excel work book
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    //Create OleDbCommand to fetch data from Excel
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [DataApertura$]", excelConnection);

                    excelConnection.Open();
                    OleDbDataReader dReader;
                    dReader = cmd.ExecuteReader();
                    SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection);
                    //Give your Destination table name
                    sqlBulk.DestinationTableName = "Carga_Data";
                    sqlBulk.WriteToServer(dReader);
                    excelConnection.Close();

                    using (SqlConnection connex = new SqlConnection(strConnection))
                    {
                        SqlCommand comm = new SqlCommand("CargarOrdenes", connex);
                        comm.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        connex.Open();
                        comm.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','" + ex + "');", true);
                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Debe seleccionar un archivo');", true);
            }

        }

        public void DataInforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = DataInforme.SelectedRow;
            try
            {
                LabNumeroOrden.Text = row.Cells[2].Text;

                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand CmdObtenerTopOrdenes = new SqlCommand("ObtenerTopOrdenes"))
                    {
                        CmdObtenerTopOrdenes.Connection = con;
                        CmdObtenerTopOrdenes.CommandType = CommandType.StoredProcedure;
                        CmdObtenerTopOrdenes.Parameters.AddWithValue("@IdOrden", row.Cells[2].Text);
                        using (SqlDataAdapter daObtenerTopOrdenes = new SqlDataAdapter(CmdObtenerTopOrdenes))
                        {
                            DataTable dtObtenerTopOrdenes = new DataTable();
                            daObtenerTopOrdenes.Fill(dtObtenerTopOrdenes);
                            RepterUltimosComentarios.DataSource = dtObtenerTopOrdenes;
                            RepterUltimosComentarios.DataBind();
                        }
                    }

                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalAgainShow", "$('#ModActualizacion').modal();", true);

            }
            catch (Exception ex)
            {
                //   throw ex;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','" + ex + "');", true);
            }
        }

        //Paginador
        protected void DataInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataInforme.PageIndex = e.NewPageIndex;
            DataInforme.DataBind();
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

            DataTable DtBuscar;
            string consultaRegistros = "ObtenerRegistros";
            int TipoUsuario = Convert.ToInt32(Session["TipoUsuario"]);
            string NonbreAsesor = Convert.ToString(Session["Nombres"]);
            if (TipoUsuario != 3)
            {
                NonbreAsesor = "0";
            }
            using (SqlConnection connex = new SqlConnection(strConnection))
            {
                SqlCommand comm = new SqlCommand(consultaRegistros, connex);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add("@Backoffice", SqlDbType.VarChar);
                comm.Parameters.Add("@OBJECT_ID", SqlDbType.VarChar);
                comm.Parameters.Add("@Proyeccion", SqlDbType.VarChar);

                comm.Parameters["@Backoffice"].Value = DropBuscarBackoffice.SelectedValue == "(Seleccionar)" ? NonbreAsesor : DropBuscarBackoffice.SelectedValue.Trim();
                comm.Parameters["@OBJECT_ID"].Value = TxtOrdenDeServicio.Text == "" ? "0" : TxtOrdenDeServicio.Text;
                comm.Parameters["@Proyeccion"].Value = DropProyeccion.SelectedValue == "(Seleccionar)" ? "0" : DropProyeccion.SelectedValue.Trim();

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                connex.Open();
                comm.ExecuteNonQuery();

                DtBuscar = new DataTable();
                adapter.Fill(DtBuscar);
                DataInforme.DataSource = DtBuscar;
                DataInforme.DataBind();

            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable DtDatos;
                string consultaPersona = "GardarComentario";

                using (SqlConnection connex = new SqlConnection(strConnection))
                {
                    SqlCommand comm = new SqlCommand(consultaPersona, connex);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.Add("@IdComentario", SqlDbType.VarChar);
                    comm.Parameters.Add("@Responsable", SqlDbType.VarChar);
                    comm.Parameters.Add("@DatalleResponsable", SqlDbType.VarChar);
                    comm.Parameters.Add("@Depatamento", SqlDbType.VarChar);
                    comm.Parameters.Add("@Ciudad", SqlDbType.VarChar);
                    comm.Parameters.Add("@Comentario", SqlDbType.VarChar);
                    comm.Parameters.Add("@Localidad", SqlDbType.VarChar);
                    comm.Parameters.Add("@Barrio", SqlDbType.VarChar);
                    comm.Parameters.Add("@Direccion", SqlDbType.VarChar);

                    comm.Parameters["@IdComentario"].Value = LabNumeroOrden.Text;
                    comm.Parameters["@Responsable"].Value = DropResponsable.SelectedItem.ToString();
                    comm.Parameters["@DatalleResponsable"].Value = DropDetalleResponsable.SelectedItem.ToString();
                    comm.Parameters["@Depatamento"].Value = DropDepartamento.SelectedItem.ToString();
                    comm.Parameters["@Ciudad"].Value = DropCiudad.SelectedItem.ToString();
                    comm.Parameters["@Comentario"].Value = TxtComentario.Text == "" ? "Sin Comentario" : TxtComentario.Text;
                    comm.Parameters["@Localidad"].Value = TxtLocalidad.Text;
                    comm.Parameters["@Barrio"].Value = TxtBarrio.Text;
                    comm.Parameters["@Direccion"].Value = TxtDireccion.Text;

                    SqlDataAdapter adapter = new SqlDataAdapter(comm);
                    connex.Open();
                    comm.ExecuteNonQuery();

                    DtDatos = new DataTable();
                    adapter.Fill(DtDatos);
                    DataInforme.DataSource = DtDatos;
                    DataInforme.DataBind();

                }
                //ObetnerOrdenes();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Actualización guardada exitosamente.');", true);

                LabNumeroOrden.Text = "";
                TxtComentario.Text = "";
                TxtLocalidad.Text = "";
                TxtBarrio.Text = "";
                TxtDireccion.Text = "";
            }
            catch (Exception ex)
            {
                //   throw ex;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','" + ex.Message + "');", true);
            }
        }
    }
}