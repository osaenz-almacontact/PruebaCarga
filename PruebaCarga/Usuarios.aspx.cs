using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PruebaCarga
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand CmdObtenerResponsables = new SqlCommand("ObtenerTipoDeUsuarios"))
                    {
                        CmdObtenerResponsables.Connection = con;
                        CmdObtenerResponsables.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdaObtenerResponsables = new SqlDataAdapter(CmdObtenerResponsables))
                        {
                            DataTable dtObtenerResponsables = new DataTable();
                            sdaObtenerResponsables.Fill(dtObtenerResponsables);
                            DropTipoUsuario.DataSource = dtObtenerResponsables;
                            DropTipoUsuario.DataTextField = "TipoUsuario";
                            DropTipoUsuario.DataValueField = "Id";
                            DropTipoUsuario.DataBind();
                            DropTipoUsuario.Items.Insert(0, "(Seleccionar)");

                        }
                    }


                }
                ObtenerUsuarios();
            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlCambiarTipo = (e.Item.FindControl("DropCambiarTipo") as DropDownList);
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand CmdObtenerDetalleResponsables = new SqlCommand("ObtenerTipoDeUsuarios"))
                    {
                        CmdObtenerDetalleResponsables.Connection = con;
                        CmdObtenerDetalleResponsables.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdaObtenerResponsables = new SqlDataAdapter(CmdObtenerDetalleResponsables))
                        {
                            DataTable dtObtenerResponsables = new DataTable();
                            sdaObtenerResponsables.Fill(dtObtenerResponsables);
                            ddlCambiarTipo.DataSource = dtObtenerResponsables;
                            ddlCambiarTipo.DataTextField = "TipoUsuario";
                            ddlCambiarTipo.DataValueField = "Id";
                            ddlCambiarTipo.DataBind();
                            ddlCambiarTipo.Items.Insert(0, new ListItem("(Seleccionar)", "0"));
                        }
                    }

                }

            }
        }
        public void ObtenerUsuarios()
        {
            string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand CmdObtenerUsuarios = new SqlCommand("ObtenerUsuarios"))
                {
                    CmdObtenerUsuarios.Connection = con;
                    CmdObtenerUsuarios.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter daObtenerUsuarios = new SqlDataAdapter(CmdObtenerUsuarios))
                    {
                        DataTable dtObtenerUsuarios = new DataTable();
                        daObtenerUsuarios.Fill(dtObtenerUsuarios);
                        RepterUsuarios.DataSource = dtObtenerUsuarios;
                        RepterUsuarios.DataBind();
                    }
                }
            }


        }
        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Buttons
            item.FindControl("LnkEditar").Visible = !isEdit;
            item.FindControl("BtnActualizar").Visible = isEdit;

            //Toggle Labels.
            item.FindControl("LabNombreCompleto").Visible = !isEdit;
            item.FindControl("LabNombreUsuario").Visible = !isEdit;
            item.FindControl("LabPassword").Visible = !isEdit;
            item.FindControl("LabNombreTipoUsuario").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("TxtNombreCompleto").Visible = isEdit;
            item.FindControl("TxtNombreUsuario").Visible = isEdit;
            item.FindControl("TxtPassword").Visible = isEdit;
            item.FindControl("DropCambiarTipo").Visible = isEdit;
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        protected void BtnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNombreUsuario.Text != "")
                {
                    int userMensaje = 0;
                    string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("AgregarUsuarios"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Nombres", TxtNombreCompleto.Text);
                            cmd.Parameters.AddWithValue("@NombreUsuario", TxtNombreUsuario.Text);
                            cmd.Parameters.AddWithValue("@Password", TxtPassword.Text);
                            cmd.Parameters.AddWithValue("@TipoUsuario", DropTipoUsuario.SelectedValue);
                            cmd.Connection = con;
                            con.Open();
                            userMensaje = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                        switch (userMensaje)
                        {
                            case 1:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','El Usuario ya se encuentra registrado.');", true);
                                break;
                            case 2:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Usuario ingresado con éxito');", true);
                                break;
                            default:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                                break;
                        }
                    }
                    TxtNombreCompleto.Text = "";
                    TxtNombreUsuario.Text = "";
                    TxtPassword.Text = "";
                    DropTipoUsuario.SelectedIndex = 0;
                    ObtenerUsuarios();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','Debe diligenciar el campo Responsable.');", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','" + ex.Message + "');", true);
            }
        }


        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int userMensaje = 0;
                //Find the reference of the Repeater Item.
                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdUsuario") as Label).Text);
                string NombreCompleto = (item.FindControl("TxtNombreCompleto") as TextBox).Text.Trim();
                string NombreUsuarioAnterior = (item.FindControl("LabNombreUsuario") as Label).Text.Trim();
                string NombreUsuario = (item.FindControl("TxtNombreUsuario") as TextBox).Text.Trim();
                string Password = (item.FindControl("TxtPassword") as TextBox).Text.Trim();
                int IdTipoUsuario = int.Parse((item.FindControl("LabIdTipo") as Label).Text.Trim());
                int TipoUsuario = int.Parse((item.FindControl("DropCambiarTipo") as DropDownList).SelectedValue);
                int Estado = (item.FindControl("ChkTipoUsuario") as CheckBox).Checked ? 1 : 0;

                if (TipoUsuario == 0)
                {
                    TipoUsuario = IdTipoUsuario;
                }
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ActualizarUsuario"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Nombres", NombreCompleto);
                        cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@TipoUsuario", TipoUsuario);
                        cmd.Parameters.AddWithValue("@Activo", Estado);
                        cmd.Connection = con;
                        con.Open();
                        userMensaje = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                    switch (userMensaje)
                    {
                        case 1:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','El Usuario ya se encuentra registrado.');", true);
                            break;
                        case 2:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Usuario Actualizado con éxito');", true);
                            break;
                        default:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','" + ex.Message + "');", true);
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int userMensaje = 0;
                //Find the reference of the Repeater Item.
                RepeaterItem item = (sender as Button).Parent as RepeaterItem;
                int Id = int.Parse((item.FindControl("LabIdUsuario") as Label).Text);
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("EliminarUsuario"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Connection = con;
                        con.Open();
                        userMensaje = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                    switch (userMensaje)
                    {
                        case 1:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','El Usuario no se encuentra registrado.');", true);
                            break;
                        case 2:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Usuario eliminado con éxito');", true);
                            break;
                        default:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                            break;
                    }
                }

                ObtenerUsuarios();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','" + ex.Message + "');", true);
            }
        }

    }
}