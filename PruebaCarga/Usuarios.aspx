<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PruebaCarga.Usuarios" %>

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

    <h1 class="mt-4">Usuarios</h1>
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Usuarios</li>
    </ol>
    <div class="card" runat="server" id="DivUsuarios">
        <div class="card-header"><b>Agregar Usuario</b></div>
        <div class="card-body">
            <div class="form-row">
                <div class="col">
                    <label>Nombre Completo</label>
                    <asp:TextBox ID="TxtNombreCompleto" runat="server" placeholder="Nuevo Usuario" class="form-control"></asp:TextBox>
                </div>
                <div class="col">
                    <label>Nombre Usuario</label>
                    <asp:TextBox ID="TxtNombreUsuario" runat="server" placeholder="Nuevo Usuario" class="form-control" MaxLength="50"></asp:TextBox>
                </div>
                <div class="col">
                    <label>Password</label>
                    <asp:TextBox ID="TxtPassword" runat="server" placeholder="Nuevo Usuario" class="form-control"></asp:TextBox>
                </div>
                <div class="col">
                    <label>Tipo Usuario</label>
                    <asp:DropDownList ID="DropTipoUsuario" class="form-control" runat="server">
                        <Items>
                            <asp:ListItem Text="(Seleccionar)" Value="-1" />
                        </Items>
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <br />
                    <asp:Button ID="BtnGuardarUsuario" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="BtnGuardarUsuario_Click" />
                </div>
            </div>
            <hr />

            <div class="table-responsive">
                <asp:Repeater ID="RepterUsuarios" runat="server" OnItemDataBound="OnItemDataBound">
                    <HeaderTemplate>
                        <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th scope="col">Nomnbres</th>
                                    <th scope="col">Usuario</th>
                                    <th scope="col">Password</th>
                                    <th scope="col">Tipo Usuario</th>
                                    <th scope="col">Activo</th>
                                    <th scope="col" style="text-align: center;" colspan="2">X</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="LabIdUsuario" runat="server" Text='<%#Eval("IdUsuario") %>' Font-Bold="true" Visible="false" />
                                <asp:Label ID="LabNombreCompleto" runat="server" Text='<%#Eval("Nombres") %>' class="form-control"></asp:Label>
                                <asp:TextBox ID="TxtNombreCompleto" runat="server" Text='<%#Eval("Nombres") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LabNombreUsuario" runat="server" Text='<%#Eval("NombreUsuario") %>' class="form-control"></asp:Label>
                                <asp:TextBox ID="TxtNombreUsuario" runat="server" Text='<%#Eval("NombreUsuario") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label  ID="LabPassword" runat="server" Text='<%#Eval("Password") %>' class="form-control"></asp:Label>
                                <asp:TextBox ID="TxtPassword" runat="server" Text='<%#Eval("Password") %>' class="form-control" Visible="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropCambiarTipo" class="form-control" runat="server" Visible="false">
                                    <Items>
                                        <asp:ListItem Text="(Seleccionar)" Value="0" />
                                    </Items>
                                </asp:DropDownList>
                                <asp:Label ID="LabNombreTipoUsuario" runat="server" Text='<%#Eval("TipoUsuario") %>' />
                                <asp:Label ID="LabIdTipo" runat="server" Text='<%#Eval("IdTipo") %>' Visible="false"/>
                            </td>
                            <td>
                                <div class="text-center">
                                    <%--<input type="checkbox" id="ChkTipoUsuario" <%# Convert.ToBoolean(Eval("Acctivo")) ? "checked" : string.Empty %> />--%>
                                    <asp:CheckBox runat="server" id="ChkTipoUsuario" CssClass="status"  Checked='<%# (Eval("Acctivo")).ToString() == "1" ? true : false %>' />
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:LinkButton ID="LnkEditar" Text="Editar" runat="server" OnClick="OnEdit" CssClass="btn btn-secondary" />
                                    <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="BtnActualizar_Click" Visible="false" />
                                </div>
                            </td>
                            <td>
                                <div class="text-center">
                                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="BtnEliminar_Click" />
                                </div>
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
