<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Confiteria.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema Encode || Login</title>

    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet"/>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="shortcut icon" href="imagesLogin/LoginImg.jpg"/>

    <link rel="stylesheet" href="css/style.css"/>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="jsLogin/Login.js"></script>

    <style>
        input:invalid{
            border-color:red;
        }
        
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>--%>
            <div style="height:609px;">
                <div class="row no-gutters">
                    <div class="col-md-8">
                        <img src="https://cdn.pixabay.com/photo/2016/04/04/14/12/monitor-1307227__340.jpg" style="height:624px; width:100%;" alt="..."/>
                    </div>
                    <div class="col-md-4">
                        <div class="card-body">
                            <div class="row">
                                <div id="login">
                                    <div class="container ml-4">
                                        
                                    <img class="img-fluid mx-auto d-block rounded"
                                        src="imagesLogin/loginImg4.png" />
                                    </div>

                                   
                                        <div class="container form-group ml-4 mt-5">
                                            <label for="correo">Nombre de Usuario</label>
                                            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" placeholder="Nombre de Usuario" pattern="[A-Za-z0-9]{4,20}" title="El Nombre de Usuario solo puede contener numeros y letras. Un minimo de 8 caracteres y un maximo de 20"/>
                                        </div>
                                        <div class="container form-group ml-4">
                                            <label for="palabraSecreta">Contraseña</label>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" Type="password" pattern="(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]){8,12}" title="La contraseña debe contener al menos una letra mayuscula, minuscula y  un valor numerico. Un minimo de 8 caracteres y un maximo de 12."/>
                                        </div>
                                    <div class="container ml-4">
                                        <asp:Button ID="btnIniciarSesion" Text="Iniciar Sesión" runat="server" CssClass="btn btn-primary mb-2 mt-3" style="width:100%;" OnClick="btnIniciarSesion_Click"/>
                                        
                                    </div>
                                        
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <%--</div>--%>
    </form>





    <%--<script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>--%>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>      
    

    

</body>
</html>
