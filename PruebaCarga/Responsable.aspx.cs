using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PruebaCarga
{
    public partial class Responsable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
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

                ObtenerResponsables();
                ObtenerDetalleResponsables();
            }
        }
        public void ObtenerResponsables()
        {
            string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand CmdObtenerResponsables = new SqlCommand("ObtenerResponsable"))
                {
                    CmdObtenerResponsables.Connection = con;
                    CmdObtenerResponsables.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sdaObtenerResponsables = new SqlDataAdapter(CmdObtenerResponsables))
                    {
                        DataTable dtObtenerResponsables = new DataTable();
                        sdaObtenerResponsables.Fill(dtObtenerResponsables);
                        RepterResponsables.DataSource = dtObtenerResponsables;
                        RepterResponsables.DataBind();
                    }
                }


            }
        }
        protected void BtnGuardarResponsable_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtResponsable.Text != "")
                {
                    int userMensaje = 0;
                    string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("AgregarResponsable"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Responsable", TxtResponsable.Text);
                            cmd.Connection = con;
                            con.Open();
                            userMensaje = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                        switch (userMensaje)
                        {
                            case 1:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','El Responsable ya se encuentra registrado.');", true);
                                TxtResponsable.Text = "";
                                break;
                            case 2:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Responsable ingresado con éxito');", true);
                                TxtResponsable.Text = "";
                                break;
                            default:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                                TxtResponsable.Text = "";
                                break;
                        }
                    }

                    ObtenerResponsables();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','Debe diligenciar el campo Responsable.');", true);
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','" + ex.Message + "');", true);
            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddlSeleccioarDetalle = (e.Item.FindControl("DropCambiarResponsable") as DropDownList);
                string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand CmdObtenerDetalleResponsables = new SqlCommand("ObtenerResponsable"))
                    {
                        CmdObtenerDetalleResponsables.Connection = con;
                        CmdObtenerDetalleResponsables.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdaObtenerResponsables = new SqlDataAdapter(CmdObtenerDetalleResponsables))
                        {
                            DataTable dtObtenerResponsables = new DataTable();
                            sdaObtenerResponsables.Fill(dtObtenerResponsables);
                            ddlSeleccioarDetalle.DataSource = dtObtenerResponsables;
                            ddlSeleccioarDetalle.DataTextField = "NombreResponsable";
                            ddlSeleccioarDetalle.DataValueField = "Id";
                            ddlSeleccioarDetalle.DataBind();
                            ddlSeleccioarDetalle.Items.Insert(0, new ListItem("(Seleccionar)", "0"));
                        }
                    }

                }

                //Select the Country of Customer in DropDownList.
                //string DetalleResponsable = (e.Item.DataItem as DataRowView)["NombreResponsable"].ToString();
                //DropResponsable.Items.FindByValue(DetalleResponsable).Selected = true;
            }
        }

        public void ObtenerDetalleResponsables()
        {
            string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand CmdObtenerDetalleResponsables = new SqlCommand("ObtenerDetalleResponsable"))
                {
                    CmdObtenerDetalleResponsables.Connection = con;
                    CmdObtenerDetalleResponsables.CommandType = CommandType.StoredProcedure;
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@Id", "-1");
                    using (SqlDataAdapter daObtenerDetalleResponsables = new SqlDataAdapter(CmdObtenerDetalleResponsables))
                    {
                        DataTable dtObtenerDetalleResponsables = new DataTable();
                        daObtenerDetalleResponsables.Fill(dtObtenerDetalleResponsables);
                        RepterDetalleResponsables.DataSource = dtObtenerDetalleResponsables;
                        RepterDetalleResponsables.DataBind();
                    }
                }


            }
        }

        protected void BtnGuardarDetalleResponsable_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDetalleResponsable.Text != "" || DropResponsable.SelectedValue != "0")
                {
                    int userMensaje = 0;
                    string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("AgregarDetalleResponsable"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IdResponsable", DropResponsable.SelectedValue);
                            cmd.Parameters.AddWithValue("@DetalleResponsable", TxtDetalleResponsable.Text);
                            cmd.Connection = con;
                            con.Open();
                            userMensaje = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                        switch (userMensaje)
                        {
                            case 1:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','El Responsable ya se encuentra registrado.');", true);
                                TxtResponsable.Text = "";
                                break;
                            case 2:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Responsable ingresado con éxito');", true);
                                TxtResponsable.Text = "";
                                break;
                            default:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                                TxtResponsable.Text = "";
                                break;
                        }
                    }
                    ObtenerDetalleResponsables();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('warning','Debe diligenciar el campo Responsable.');", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','" + ex.Message + "');", true);
            }
        }

        //TODO: Evento ItemCommand BORRAR
        //protected void RepterDetalleResponsables_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case ("Eliminar"):
        //            int ID = Convert.ToInt32(e.CommandArgument);
        //            EliminarDetalleResponsable(ID);
        //            break;
        //        case ("Actualizar"):
        //            ID = Convert.ToInt32(e.CommandArgument);
        //            ActualizarDetalleResponsable(ID);
        //            break;
        //    }
        //}

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        protected void OnEditDetalle(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElementsDetalle(item, true);
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Buttons
            item.FindControl("LnkEditar").Visible = !isEdit;
            item.FindControl("BtnActualizar").Visible = isEdit;

            //Toggle Labels.
            item.FindControl("LabResponsableAnterior").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("TxtResponsableNuevo").Visible = isEdit;
        }

        private void ToggleElementsDetalle(RepeaterItem item, bool isEdit)
        {
            //Buttons
            item.FindControl("LnkEditarDetalle").Visible = !isEdit;
            item.FindControl("BtnActualizarDetalle").Visible = isEdit;

            //Toggle Labels.
            item.FindControl("LabNombreResponsable").Visible = !isEdit;
            item.FindControl("LabNombreDetalleResponsable").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("DropCambiarResponsable").Visible = isEdit;
            item.FindControl("TxtDetalleResponsable").Visible = isEdit;
        }


        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int Id = int.Parse((item.FindControl("LabIdResponsable") as Label).Text);
            string Responsable = (item.FindControl("LabResponsableAnterior") as Label).Text.Trim();
            string ResponsableNuevo = (item.FindControl("TxtResponsableNuevo") as TextBox).Text.Trim();

            string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand CmdObtenerDetalleResponsables = new SqlCommand("ActualizarResponsable"))
                {
                    int userMensaje = 0;
                    CmdObtenerDetalleResponsables.Connection = con;
                    CmdObtenerDetalleResponsables.CommandType = CommandType.StoredProcedure;
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@IdResponsable", Id);
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@ResponsableAnterior", Responsable);
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@Responsable", ResponsableNuevo);
                    CmdObtenerDetalleResponsables.Connection = con;
                    con.Open();
                    userMensaje = Convert.ToInt32(CmdObtenerDetalleResponsables.ExecuteScalar());
                    con.Close();

                    switch (userMensaje)
                    {
                        case 1:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Responsable no encontrado..');", true);
                            TxtResponsable.Text = "";
                            break;
                        case 2:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Responsable actualizado con éxito');", true);
                            TxtResponsable.Text = "";
                            break;
                        default:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                            TxtResponsable.Text = "";
                            break;
                    }

                    ObtenerResponsables();
                }

            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int Id = int.Parse((item.FindControl("LabIdResponsable") as Label).Text);
            string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand CmdObtenerDetalleResponsables = new SqlCommand("EliminarResponsable"))
                {
                    int userMensaje = 0;
                    CmdObtenerDetalleResponsables.Connection = con;
                    CmdObtenerDetalleResponsables.CommandType = CommandType.StoredProcedure;
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@Id", Id);
                    CmdObtenerDetalleResponsables.Connection = con;
                    con.Open();
                    userMensaje = Convert.ToInt32(CmdObtenerDetalleResponsables.ExecuteScalar());
                    con.Close();

                    switch (userMensaje)
                    {
                        case 1:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Responsable no encontrado..');", true);
                            TxtResponsable.Text = "";
                            break;
                        case 2:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Responsable eliminado con éxito');", true);
                            TxtResponsable.Text = "";
                            break;
                        default:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                            TxtResponsable.Text = "";
                            break;
                    }

                    ObtenerResponsables();
                }

            }
        }

        protected void BtnActualizarDetalle_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            int Id = int.Parse((item.FindControl("LabDetalleResponsable") as Label).Text);
            int NombreResponsable = int.Parse((item.FindControl("DropCambiarResponsable") as DropDownList).SelectedValue);
            string NombreDetalleResponsableAnterior = (item.FindControl("LabNombreDetalleResponsable") as Label).Text;
            string NombreDetalleResponsable = (item.FindControl("TxtDetalleResponsable") as TextBox).Text;

            string constr = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand CmdObtenerDetalleResponsables = new SqlCommand("ActualizarDetalleResponsable"))
                {
                    int userMensaje = 0;
                    CmdObtenerDetalleResponsables.Connection = con;
                    CmdObtenerDetalleResponsables.CommandType = CommandType.StoredProcedure;
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@Id", Id);
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@IdResponsable", NombreResponsable);
                    CmdObtenerDetalleResponsables.Parameters.AddWithValue("@DetalleResponsable", NombreDetalleResponsable);
                    CmdObtenerDetalleResponsables.Connection = con;
                    con.Open();
                    userMensaje = Convert.ToInt32(CmdObtenerDetalleResponsables.ExecuteScalar());
                    con.Close();

                    switch (userMensaje)
                    {
                        case 1:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Detalle responsable no encontrado..');", true);
                            TxtResponsable.Text = "";
                            break;
                        case 2:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('success','Detalle responsable actualizado con éxito');", true);
                            TxtResponsable.Text = "";
                            break;
                        default:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "showContent('error','Error al tratar de ingresar el registro.');", true);
                            TxtResponsable.Text = "";
                            break;
                    }

                    ObtenerDetalleResponsables();
                }

            }
        }
    }
}