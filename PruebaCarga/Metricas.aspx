<%@ Page Title="Metricas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Metricas.aspx.cs" Inherits="PruebaCarga.Metricas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="mt-4">Metricas</h1>
    <ol class="breadcrumb mb-4">
        <li class="breadcrumb-item active">Metricas</li>
    </ol>
    <div class="row">
        <!-- LEFT COLUMN -->
        <div class="col-4">
            <!-- PROFILE HEADER -->
            <div class="card text-white bg-info ">
                <div class="card-body">
                    <div class="text-center">
                        <img src="Content/Images/user-medium.png" class="rounded-circle" alt="Avatar">
                    </div>

                    <h3 class="name">
                        <asp:Label ID="LabNombresApellidos" runat="server"></asp:Label></h3>
                </div>

            </div>
            <hr />
            <div class="form-row">
                <div class="col" runat="server">
                    <label><b>Asesor</b></label>
                    <asp:DropDownList ID="DropAgente" class="form-control border-input" runat="server" AppendDataBoundItems="true" AutoPostBack="false">
                        <Items>
                            <asp:ListItem Text="(Seleccionar)" Value="" />
                        </Items>
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="BtnBuscar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
                </div>
            </div>

            <!-- END PROFILE DETAIL -->
        </div>
        <!-- END LEFT COLUMN -->
        <!-- RIGHT COLUMN -->
        <div class="col-8">
            <!-- AWARDS -->
            <style>
                #h1 {
                    font-size: 45px;
                }
            </style>
            <style>
                .award-item {
                    display: inline-block;
                    vertical-align: middle;
                    *vertical-align: auto;
                    *zoom: 1;
                    *display: inline;
                    text-align: center;
                    margin-bottom: 30px;
                }

                    .award-item .hexagon {
                        margin: 35px 0;
                    }

                .hexagon {
                    width: 100px;
                    height: 55px;
                    background: #ececec;
                    position: relative;
                }

                    .hexagon:before {
                        content: "";
                        position: absolute;
                        top: -25px;
                        left: 0;
                        width: 0;
                        height: 0;
                        border-left: 50px solid transparent;
                        border-right: 50px solid transparent;
                        border-bottom: 25px solid #ececec;
                    }

                    .hexagon:after {
                        content: "";
                        position: absolute;
                        bottom: -25px;
                        left: 0;
                        width: 0;
                        height: 0;
                        border-left: 50px solid transparent;
                        border-right: 50px solid transparent;
                        border-top: 25px solid #ececec;
                    }
            </style>
            <div class="row">
                <div class="col-xl-4 col-md-4">
                    <div class="text-center">
                        <div class="award-item">
                            <div class="hexagon">
                                <h1 id="h1">
                                    <asp:Label ID="LabSoporteTecnico" runat="server"></asp:Label></h1>
                            </div>
                            <span>Por vencer</span>
                        </div>
                    </div>
                </div>
                <div class="col-xl-4 col-md-4">
                    <div class="text-center">
                        <div class="award-item">
                            <div class="hexagon">
                                <h1 id="h1">
                                    <asp:Label ID="Label2" runat="server"></asp:Label></h1>
                            </div>
                            <span>Vencidos</span>
                        </div>
                    </div>
                </div>

                <div class="col-xl-4s col-md-4">
                    <div class="text-center">
                        <div class="award-item">
                            <div class="hexagon">
                                <h1 id="h1">
                                    <asp:Label ID="Label3" runat="server"></asp:Label></h1>
                            </div>
                            <span>Actualizados</span>
                        </div>
                    </div>
                </div>

            </div>

            <!-- TASKS -->
            <script type="text/javascript">
                function updateProgress(NumServiciotecnico) {
                    var LlamadaServicioTecnico = parseInt(NumServiciotecnico);
                    $("#ProgServicioTecnico").css("width", LlamadaServicioTecnico + "%");
                    if (LlamadaServicioTecnico > 0 && LlamadaServicioTecnico < 10) {
                        $("#ProgServicioTecnico").addClass("progress-bar progress-bar-danger");
                    } else if (LlamadaServicioTecnico > 11 && LlamadaServicioTecnico < 30) {
                        $("#ProgServicioTecnico").addClass("progress-bar progress-bar-warning");
                    } else {
                        $("#ProgServicioTecnico").addClass("progress-bar progress-bar-success");
                    }
                }

                function updateProgressFacturacion(NumFacturacion) {
                    var LlamadaFacturacion = parseInt(NumFacturacion);
                    $("#ProgFacturacion").css("width", LlamadaFacturacion + "%");
                    if (LlamadaFacturacion > 0 && LlamadaFacturacion < 10) {
                        $("#ProgFacturacion").addClass("progress-bar progress-bar-danger");
                    } else if (LlamadaFacturacion > 11 && LlamadaFacturacion < 30) {
                        $("#ProgFacturacion").addClass("progress-bar progress-bar-warning");
                    } else {
                        $("#ProgFacturacion").addClass("progress-bar progress-bar-success");
                    }
                }

                function updateProgressMayorista(NumMayorista) {
                    var LlamadaMayorista = parseInt(NumMayorista);
                    $("#ProgMayorista").css("width", LlamadaMayorista + "%");
                    if (LlamadaMayorista > 0 && LlamadaMayorista < 10) {
                        $("#ProgMayorista").addClass("progress-bar progress-bar-danger");
                    } else if (LlamadaMayorista > 11 && LlamadaMayorista < 30) {
                        $("#ProgMayorista").addClass("progress-bar progress-bar-warning");
                    } else {
                        $("#ProgMayorista").addClass("progress-bar progress-bar-success");
                    }
                }

                function updateProgressFallida(NumFallida) {
                    var LlamadaFallida = parseInt(NumFallida);
                    $("#ProgFallida").css("width", LlamadaFallida + "%");
                    if (LlamadaFallida > 0 && LlamadaFallida < 10) {
                        $("#ProgFallida").addClass("progress-bar progress-bar-danger");
                    } else if (LlamadaFallida > 11 && LlamadaFallida < 30) {
                        $("#ProgFallida").addClass("progress-bar progress-bar-warning");
                    } else {
                        $("#ProgFallida").addClass("progress-bar progress-bar-success");
                    }
                }

                function TotalLlamadasMes(NumeroLlamadasMes, LlamadasMesAnterior) {
                    var LlamadasMes = parseInt(LlamadasMes);
                    var LlamadasMesAnterior = parseInt(LlamadasMesAnterior);
                    if (LlamadasMes < LlamadasMesAnterior) {
                        $("#PorcentajeLlamadas").addClass("fa fa-caret-up text-danger");
                    } else {
                        $("#PorcentajeLlamadas").addClass("fa fa-caret-up text-success");
                    }
                }

            </script>

            <div class="panel">
                <div class="custom-tabs-line tabs-line-bottom left-aligned">
                    <ul class="nav" role="tablist">
                        <li class="active"><a href="#tab-bottom-left1" role="tab" data-toggle="tab">Porcentaje de llamadas</a></li>
                        <li><a href="#tab-bottom-left2" role="tab" data-toggle="tab">Regiones que mas llaman</a></li>
                    </ul>

                </div>
                <div class="tab-content">
                    <div class="tab-pane fade in active" id="tab-bottom-left1">

                        <div class="panel-heading">
                            <%-- <h3 class="panel-title">Porcentaje de llamadas</h3>--%>
                            <div class="right">
                                <button type="button" class="btn-toggle-collapse"><i class="lnr lnr-chevron-up"></i></button>
                            </div>
                        </div>
                        <div class="panel-body">
                            <ul class="list-unstyled task-list">
                                <li>
                                    <p>
                                        Servicio Técnico <span class="label-percent">
                                            <asp:Label ID="LabLlamadaServicioTecnico" runat="server"></asp:Label>%</span>
                                    </p>
                                    <div class="progress progress-xs">
                                        <div id="ProgServicioTecnico" role="progressbar" aria-valuenow="1" aria-valuemin="0" aria-valuemax="50" style="width: 0%">
                                            <span class="sr-only">1 </span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <p>
                                        Facturación <span class="label-percent">
                                            <asp:Label ID="LabLlamadaFacturacion" runat="server"></asp:Label>%</span>
                                    </p>
                                    <div class="progress progress-xs">
                                        <div id="ProgFacturacion" role="progressbar" aria-valuenow="1" aria-valuemin="0" aria-valuemax="50" style="width: 0%">
                                            <span class="sr-only">1</span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <p>
                                        Info de Mayoristas - Canales - CAS <span class="label-percent">
                                            <asp:Label ID="LabLlamadaMayorista" runat="server"></asp:Label>%</span>
                                    </p>
                                    <div class="progress progress-xs">
                                        <div id="ProgMayorista" role="progressbar" aria-valuenow="1" aria-valuemin="0" aria-valuemax="50" style="width: 0%">
                                            <span class="sr-only">1</span>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <p>
                                        Fallas Comunicación <span class="label-percent">
                                            <asp:Label ID="LabLlamadaFallida" runat="server"></asp:Label>%</span>
                                    </p>
                                    <div class="progress progress-xs">
                                        <div id="ProgFallida" role="progressbar" aria-valuenow="1" aria-valuemin="0" aria-valuemax="50" style="width: 0%">
                                            <span class="sr-only">1</span>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!---END PANEL BODY ---->
                    </div>
                    <!---END TAB PANEL FATE ---->
                    <div class="tab-pane fade" id="tab-bottom-left2">
                        <div class="panel-heading">
                            <div class="right">
                                <button type="button" class="btn-toggle-collapse"><i class="lnr lnr-chevron-up"></i></button>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="col-lg-6">
                                <style>
                                    .ct-label {
                                        font-size: 18px;
                                        fill: white;
                                    }
                                </style>
                                <div class="ct-chart ct-perfect-fourth"></div>
                            </div>
                            <div class="col-lg-6">
                                <div class="table-responsive">
                                    <table class="table project-table">
                                        <thead>
                                            <tr>
                                                <th>Pais</th>
                                                <th>Color</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabPaisUno" runat="server"></asp:Label></td>
                                                <td><span class="label" style="background-color: #028fd0">
                                                    <asp:Label ID="LabTotalRegionUno" runat="server"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabPaisDos" runat="server"></asp:Label></td>
                                                <td><span class="label" style="background-color: #83c6ea">
                                                    <asp:Label ID="LabTotalRegionDos" runat="server"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabPaisTres" runat="server"></asp:Label></td>
                                                <td><span class="label" style="background-color: #f4c63d">
                                                    <asp:Label ID="LabTotalRegionTres" runat="server"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabPaisCuatro" runat="server"></asp:Label></td>
                                                <td><span class="label" style="background-color: #d17905">
                                                    <asp:Label ID="LabTotalRegionCuatro" runat="server"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabPaisCinco" runat="server"></asp:Label></td>
                                                <td><span class="label" style="background-color: #453d3f">
                                                    <asp:Label ID="LabTotalRegionCinco" runat="server"></asp:Label></span></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!---END  PANEL BODY ---->
                    </div>
                    <!---END TAB PANEL FATE ---->
                </div>
                <!---END TAB CONTENT---->
            </div>
            <!-- END TASKS -->

        </div>
    </div>
</asp:Content>
