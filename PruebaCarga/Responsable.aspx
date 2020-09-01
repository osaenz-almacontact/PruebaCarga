<%@ Page Title="Responsable" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Responsable.aspx.cs" Inherits="PruebaCarga.Responsable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/jquery/jquery.js"></script>
    <script src="/Scripts/jquery/jquery.min.js"></script>
    <script src="/Scripts/bootstrap.bundle.min.js"></script>
    <script src="/Scripts/Toast/toastr.min.js"></script>
    <script>
        function showContent(tipo, mensaje) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "progressBar": true,
                "preventDuplicates": false,
                "positionClass": "toast-top-right",
                "showDuration": "400",
                "hideDuration": "1000",
                "timeOut": "7000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["" + tipo + ""]("" + mensaje + "");
        }
    </script>

    <h1 class="mt-4">Responsable</h1>
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Responsable</li>
    </ol>

    <div class="card" runat="server" id="DivResponable">
        <div class="card-header"><b>Agregar Responsable</b></div>
        <div class="card-body">
            <div class="form-row">
                <div class="col">
                    <label>Responsable</label>
                    <asp:TextBox ID="TxtResponsable" runat="server" placeholder="Nuevo Responsable" class="form-control"></asp:TextBox>
                </div>
                <div class="col">
                    <br />
                    <asp:Button ID="BtnGuardarResponsable" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="BtnGuardarResponsable_Click" />
                </div>
            </div>
            <hr />

            <div class="table-responsive">
                <asp:Repeater ID="RepterResponsables" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col" style="width: 80%">Responsable</th>
                                    <th scope="col" style="text-align: center;" colspan="2">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdResponsable" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" />
                            </td>
                            <td>
                                <asp:Label  ID="LabResponsableAnterior" runat="server" Text='<%#Eval("NombreResponsable") %>' class="form-control"></asp:Label>
                                <asp:TextBox ID="TxtResponsableNuevo" runat="server" Text='<%#Eval("NombreResponsable") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkEditar" Text="Editar" runat="server" OnClick="OnEdit" CssClass="btn btn-secondary"/>
                                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="BtnActualizar_Click" Visible="false" />
                            </td>
                            <td>
                                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>  
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <br />
    <div class="card" runat="server" id="DivDetalleResponsable">
        <div class="card-header"><b>Agregar Detalle Responsable</b></div>
        <div class="card-body">
            <div class="form-row">
                <div class="col">
                    <label>Responsable</label>
                    <asp:DropDownList ID="DropResponsable" class="form-control" runat="server">
                        <Items>
                            <asp:ListItem Text="(Seleccionar)" Value="-1" />
                        </Items>
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <label>Detalle Responsable</label>
                    <asp:TextBox ID="TxtDetalleResponsable" runat="server" placeholder="Nuevo detalle responsable" class="form-control"></asp:TextBox>
                </div>
                <div class="col">
                    <br />
                    <asp:Button ID="BtnGuardarDetalleResponsable" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="BtnGuardarDetalleResponsable_Click" />
                </div>
            </div>

            <hr />

            <div class="table-responsive">
                <asp:Repeater ID="RepterDetalleResponsables" runat="server" OnItemDataBound="OnItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Responsable</th>
                                    <th scope="col">Detalle Responsable</th>
                                    <th scope="col" style="text-align: center; width: 18%" colspan="2">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabDetalleResponsable" runat="server" Text='<%#Eval("Id") %>' Font-Bold="true" />
                            </td>
                            <td>
                                <asp:DropDownList ID="DropCambiarResponsable" class="form-control" runat="server" Visible="false" >
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="-1" />
                                    </Items>
                                </asp:DropDownList>
                                <asp:Label ID="LabNombreResponsable" runat="server" Text='<%#Eval("NombreResponsable") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="TxtDetalleResponsable" runat="server" Text='<%#Eval("NombreDescripcionResponsable") %>' class="form-control" Visible="false" ></asp:TextBox>
                                <asp:Label ID="LabNombreDetalleResponsable" runat="server" Text='<%#Eval("NombreDescripcionResponsable") %>' />
                            </td>
                            <td>
                                <asp:LinkButton ID="LnkEditarDetalle" Text="Editar" runat="server" OnClick="OnEditDetalle" CssClass="btn btn-secondary"/>
                                <asp:Button ID="BtnActualizarDetalle" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="BtnActualizarDetalle_Click" Visible="false"  />
                            </td>
                            <td>
                                <asp:Button ID="BtnEliminarDetalle" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>  
                    </FooterTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>

</asp:Content>
