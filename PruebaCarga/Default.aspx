<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaCarga._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
    <script type="text/javascript">
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8 && unicode != 44) {
                if (unicode < 48 || unicode > 57) //if not a number
                { return false } //disable key press    
            }
        }
    </script>
    <style>
        /*gridview*/
        .table table tbody tr td a,
        .table table tbody tr td span {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #337ab7;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }

        .table table > tbody > tr > td > span {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #337ab7;
            border-color: #337ab7;
        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus {
            z-index: 2;
            color: #337ab7;
            background-color: #eee;
            border-color: #ddd;
        }
        /*end gridview */
        ul.timeline {
            list-style-type: none;
            position: relative;
        }

            ul.timeline:before {
                content: ' ';
                background: #d4d9df;
                display: inline-block;
                position: absolute;
                left: 29px;
                width: 2px;
                height: 100%;
                z-index: 400;
            }

            ul.timeline > li {
                margin: 20px 0;
                padding-left: 20px;
            }

                ul.timeline > li:before {
                    content: ' ';
                    background: white;
                    display: inline-block;
                    position: absolute;
                    border-radius: 50%;
                    border: 3px solid #22c0e8;
                    left: 20px;
                    width: 20px;
                    height: 20px;
                    z-index: 400;
                }
    </style>

    <h1 class="mt-4">Dashboard</h1>
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Dashboard</li>
    </ol>
    <div class="row">
        <div class="col-xl-3 col-md-6">
            <div class="card bg-primary text-white mb-4">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-8 col-xs-8 text-left" style="margin-top: 18px">
                            <h4>Datos cargados</h4>
                        </div>
                        <div class="col-md-4 col-xs-3 text-right">
                            <asp:Label ID="LabCargados" runat="server" Font-Size="40px" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small text-white stretched-link" href="#">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6">
            <div class="card bg-warning text-white mb-4">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-8 col-xs-8 text-left" style="margin-top: 18px">
                            <h4>Por vencer</h4>
                        </div>
                        <div class="col-md-4 col-xs-3 text-right">
                            <asp:Label ID="LabPorVencer" runat="server" Font-Size="40px" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small text-white stretched-link" href="#">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6">
            <div class="card bg-success text-white mb-4">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-8 col-xs-8 text-left" style="margin-top: 18px">
                            <h4>Actualizados</h4>
                        </div>
                        <div class="col-md-4 col-xs-3 text-right">
                            <asp:Label ID="LabActualizados" runat="server" Font-Size="40px" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small text-white stretched-link" href="#">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>
        <div class="col-xl-3 col-md-6">
            <div class="card bg-danger text-white mb-4">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-8 col-xs-8 text-left" style="margin-top: 18px">
                            <h4>Vencidos</h4>
                        </div>
                        <div class="col-md-4 col-xs-3 text-right">
                            <asp:Label ID="LabVencidos" runat="server" Font-Size="40px" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small text-white stretched-link" href="#">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>
    </div>


    <div class="card" runat="server" id="DivCargarDatos">
        <div class="card-header"><b>Cagar archivo</b></div>
        <div class="card-body">
            <div class="row">
                <div class="col-sm-4">
                    <asp:FileUpload ID="FlpCargarArchivo" runat="server" CssClasss="custom-file" />
                </div>
                <div class="col-sm-3">
                    <asp:Button ID="BrnCargar" runat="server" Text="Cargar" OnClick="BrnCargar_Click" CssClass="btn btn-info" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-12">
                    <h3><b>Instrucciones:</b></h3>
                    <ul>
                        <li>Descargar la platilla para cargar los datos desde <a href="Files/Template/carga.xls">AQUÍ.</a></li>
                        <li>No modificar los encabezados de la tabla.</li>
                        <li>Agregar la información que se desea importar.</li>
                    </ul>
                </div>
            </div>

        </div>
    </div>
    <br />
    <br />
    <div class="card mb-4">
        <div class="card-header"><b>Datos Cargados</b></div>
        <div class="card-body">
            <div class="form-row">
                <div class="col" id="DivBackOffice" runat="server">
                    <label>Backoffice</label>
                    <asp:DropDownList ID="DropBuscarBackoffice" class="form-control" runat="server">
                        <asp:ListItem>(Seleccionar)</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col" id="DivOrden" runat="server">
                    <label>Orden de servicio</label>
                    <asp:TextBox ID="TxtOrdenDeServicio" runat="server" placeholder="# Orden" class="form-control" onkeypress="return numbersonly(event);"></asp:TextBox>
                </div>
                <div class="col" id="DivProyeccion" runat="server">
                    <label>Proyección</label>
                    <asp:DropDownList ID="DropProyeccion" class="form-control" runat="server">
                        <asp:ListItem>(Seleccionar)</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <br />
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="BtnBuscar_Click" />
                </div>
            </div>


            <br />

            <div class="panel-body">
                <div class="table-responsive">
                    <asp:GridView ID="DataInforme" runat="server" AutoGenerateColumns="False" class="table table-striped" OnRowDataBound="DataInforme_RowDataBound" OnSelectedIndexChanged="DataInforme_SelectedIndexChanged" OnPageIndexChanging="DataInforme_PageIndexChanging" GridLines="None" AllowPaging="true" PageSize="15">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="a" />
                            <asp:BoundField DataField="SERVICE_TYPE" HeaderText="SERVICE TYPE" />
                            <asp:BoundField DataField="OBJECT_ID" HeaderText="OBJECT ID" />
                            <asp:BoundField DataField="Responsable" HeaderText="RESPONSABLE" />
                            <asp:BoundField DataField="Detalle_Responsable" HeaderText="DETALLE RESPONSABLE" />
                            <asp:BoundField DataField="TAT_RAZON" HeaderText="TAT RAZON" />
                            <asp:BoundField DataField="FechaActualizacion" HeaderText="ULTIMA MODIFICACION" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="form-group">
                <%--<asp:Button ID="BtnRegresar" runat="server" Text="Regresar" CssClass="btn btn-success btn-lg " OnClick="BtnRegresar_Click" />
            <asp:Button ID="BtnExportar" runat="server" Text="Exportar" CssClass="btn btn-success btn-lg " OnClick="BtnExportar_Click" />--%>
            </div>
        </div>
    </div>
    <!----End card mb-4----->

    <!------Modal----->
    <div class="modal fade" id="ModActualizacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">

                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Actualización seguimiento -
                        <asp:Label ID="LabNumeroOrden" runat="server" Text=""></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-sm-12">
                                    <p class="bg-warning"><strong>Nota:</strong> No olvidar diligenciar el <b>“Responsable”</b> y <b>“Detalle Responsable”</b></p>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Responsable</label>
                                        <asp:DropDownList ID="DropResponsable" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropResponsable_OnSelectedIndexChanged">
                                            <Items>
                                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                                            </Items>
                                        </asp:DropDownList>
                                    </div>
                                    <!-----Time line---->
                                    <div class="card bg-light">
                                        <div class="card-body">
                                            <asp:Repeater ID="RepterUltimosComentarios" runat="server">
                                                <HeaderTemplate>
                                                    <ul class="timeline">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <li>
                                                        <a target="_blank"><b><%#Eval("Responsable") %></b></a>
                                                        <a class="float-right"><%#Eval("FechaActualizacion") %></a>
                                                        <p><%#Eval("Comentario") %></p>
                                                    </li>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </ul>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label>Detalle Responsable</label>
                                        <asp:DropDownList ID="DropDetalleResponsable" class="form-control" runat="server">
                                            <Items>
                                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                                            </Items>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Ciudad</label>
                                        <asp:DropDownList ID="DropCiudad" class="form-control" runat="server">
                                            <Items>
                                                <asp:ListItem Text="(Seleccionar)" Value="-1" />
                                            </Items>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Departamento</label>
                                        <asp:DropDownList ID="DropDepartamento" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDepartamento_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>Localidad</label>
                                        <asp:TextBox ID="TxtLocalidad" runat="server" placeholder="Localidad" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Dirección</label>
                                        <asp:TextBox ID="TxtDireccion" runat="server" placeholder="Direccion" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Barrio</label>
                                        <asp:TextBox ID="TxtBarrio" runat="server" placeholder="Barrio" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-12">
                                    <label>Comentario</label>
                                    <div class="form-group">
                                        <asp:TextBox ID="TxtComentario" runat="server" class="form-control" TextMode="Multiline" Rows="3" placeholder="Enter text"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>



                </div>

                <!-- Modal footer -->
                <div class="modal-footer">
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="BtnGuardar_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
