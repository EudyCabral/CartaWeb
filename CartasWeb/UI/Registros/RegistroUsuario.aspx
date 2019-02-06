<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="CartasWeb.UI.Registros.RegistroDestinatario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

   

        <div class="container">
            <div class="form-group">
                <div style="text-align: center;">

                    <asp:Label ID="LabelCuentas" runat="server" Text="Registro de Usuario" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="columns" style="width: 350px;">
                    <div class="form-group ">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorId" ControlToValidate="UsuarioidTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionBE"></asp:RequiredFieldValidator>

                            <div style="width: 85px;">
                                <asp:Label for="UsuarioidTextBox" ID="Label6" runat="server" Text="Usuario Id:"></asp:Label>

                            </div>

                            <asp:TextBox ID="UsuarioidTextBox" runat="server" class="form-control" TextMode="Number" placeholder="Usuario Id" Width="250px"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorNombre" ControlToValidate="NombreTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 85px;">
                                <asp:Label for="NombreTextBox" ID="Label1" runat="server" Text="Nombre:"></asp:Label>
                            </div>

                            <asp:TextBox ID="NombreTextBox" runat="server" class="form-control" placeholder="Nombre" Width="250px"></asp:TextBox>
                        </div>

                    </div>

                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidatorBalance" ControlToValidate="DireccionTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 85px;">

                                <asp:Label for="DireccionTextBox" ID="Label5" runat="server" Text="Direccion:"></asp:Label>
                            </div>

                            <asp:TextBox ID="DireccionTextBox" runat="server" class="form-control" placeholder="Direccion" Width="250px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:RequiredFieldValidator ErrorMessage="*" ID="RequiredFieldValidator1" ControlToValidate="DireccionTextBox" Display="Static" runat="server" ForeColor="Red" ValidationGroup="ValidacionGuardar">*</asp:RequiredFieldValidator>

                            <div style="width: 85px;">

                                <asp:Label for="CartasTextbox" ID="Label2" runat="server" Text="Cartas:"></asp:Label>
                            </div>

                            <asp:TextBox ID="CartasTextbox" runat="server" class="form-control" placeholder="Cartas" Width="250px" ReadOnly="True">0</asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="columns" style="width: 400px;">
                    <div class="form-group">
                        <div class="row" style="align-items: center;">
                            <asp:Button ValidationGroup="ValidacionBE" ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" />
                        </div>
                    </div>
                </div>

               

            </div>
        </div>

        <div class="row" style="justify-content: center;">
            <div class="form-group">

                <asp:Button ID="LimpiarButton" class="btn btn-info" runat="server" Text="Limpiar"  />

                <asp:Button ValidationGroup="ValidacionGuardar" ID="GuardarButton" class="btn btn-success" runat="server" Text="Guardar" />

                <asp:Button ValidationGroup="ValidacionBE" ID="ElminarButton" class="btn btn-danger" runat="server" Text="Eliminar"/>


            </div>
        </div>

 

</asp:Content>
