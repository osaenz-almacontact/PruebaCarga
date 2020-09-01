<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PruebaCarga.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LOGIN</title>

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Theme -->
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Content/Themes/Site.css" rel="stylesheet" />
</head>
<body class="bg-primary">
    <div id="layoutAuthentication">
        <div id="layoutAuthentication_content">
            <main>
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-lg-5">
                            <div class="card shadow-lg border-0 rounded-lg mt-5">
                                <div class="card-header">
                                    <h3 class="text-center font-weight-light my-4">PRAĆENJE</h3>
                                </div>
                                <div class="card-body">
                                    <form id="form1" runat="server">
                                        <div class="form-group">
                                            <label class="small mb-1" for="inputEmailAddress">Usuairo</label>
                                            <input class="form-control py-4" runat="server" id="TxtUsuario" type="text" placeholder="Ingrese su usuario" />
                                        </div>
                                        <div class="form-group">
                                            <label class="small mb-1" for="inputPassword">Password</label>
                                            <input class="form-control py-4" runat="server" id="TxtPassword" type="password" placeholder="Ingrese su password" />
                                        </div>
                                       <%-- <div class="form-group">
                                            <div class="custom-control custom-checkbox">
                                                <input class="custom-control-input" id="rememberPasswordCheck" type="checkbox" />
                                                <label class="custom-control-label" for="rememberPasswordCheck">Recordar password</label>
                                            </div>
                                        </div>--%>
                                        <div class="form-group d-flex align-items-center justify-content-between mt-4 mb-0">
                                            <a class="small" href="password.html">Olvido su Password?</a>
                                            <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-info" OnClick="BtnIngresar_Click" />
                                        </div>
                                    </form>
                                </div>
                                <div class="card-footer text-center">
                                    <asp:Label ID="LabMensaje" runat="server" Text="" BackColor="Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </main>
        </div>
        <div id="layoutAuthentication_footer">
            <footer class="py-4 bg-light mt-auto">
                <div class="container-fluid">
                    <div class="d-flex align-items-center justify-content-between small">
                        <div class="text-muted">Copyright &copy; Almacontact 2020</div>
                        <div>
                            <a href="#">Privacy Policy</a>
                            &middot;
                                <a href="#">Terms &amp; Conditions</a>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
</body>
</html>
