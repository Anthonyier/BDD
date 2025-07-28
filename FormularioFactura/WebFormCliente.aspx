<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCliente.aspx.cs" Inherits="FormularioFactura.WebFormCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td style="text-align:right">Codigo</td>
                     <td><asp:TextBox ID="txtCodigo" runat="server" Width="300px"></asp:TextBox></td>
                </tr>
                <tr>

                    <td style="text-align: right">Nombres: </td>
                    <td><asp:TextBox ID="txtNombres" runat="server" Width="300px" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                    <td>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombres" 
                            Display="Dynamic" ErrorMessage="Porfavor Inserte el  nombre" ForeColor="#CC0000">Porfavor Inserte el  nombre</asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                 <tr>
                    <td style="text-align: right" class="auto-style2">C.I.: </td>
                    <td ><asp:TextBox ID="txtCI" runat="server" Width="85px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> </td> 
                     <td >
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtCI" Display="Dynamic" 
                             ErrorMessage="Inserte bien el CI con numeros" ForeColor="Red" Operator="DataTypeCheck" 
                             Type="Integer">Inserte bien el CI con numeros</asp:CompareValidator>
                     </td>
                 </tr>
                  <tr>
                     <td style="text-align:right">Tipo Doc:</td>
                     <td class="auto-style2"><asp:DropDownList ID="ddlTipoDoc" runat="server"></asp:DropDownList></td>
                 </tr>
             
                
                <tr>
                    <td style="text-align: right">Teléfono: </td>
                    <td><asp:TextBox ID="txtTelefono" runat="server" Width="300px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" BorderStyle="Solid" BorderWidth="1px" >0</asp:TextBox></td>
                </tr>
               
                 <tr>
                    <td style="text-align: right">Email: </td>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="300px" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox> </td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" 
                            ErrorMessage="Email is required" SetFocusOnError ="True" ></asp:RequiredFieldValidator></td>
                     <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"  Display="Dynamic"
                        ControlToValidate="txtEmail" SetFocusOnError="True"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                    </td>
                   
                </tr>          
            </table> 
            <table>
                 <tr>
                    <td>
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="X-Small" 
                         BackColor="Aqua" Font-Bold="True" Font-Italic="False" OnClick="BtnGuardar_Click"/>
                        <asp:Label ID="LabelGuardar" runat="server" Text="Label" ForeColor="green" Visible="false">El Cliente Ha sido creado satisfactoriamente</asp:Label>
                    </td>
                    
                 </tr>
        </table>  
        </div>
    </form>
</body>
</html>
