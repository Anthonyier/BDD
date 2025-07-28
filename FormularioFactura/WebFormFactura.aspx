<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormFactura.aspx.cs" Inherits="FormularioFactura.WebFormFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Campos Cabecera:</h3>
            <table>
                
                <tr>
                    
                    <td>
                        <asp:Label ID="label1" runat="server" >Codigo Cliente:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClienteCodigo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClienteCodigo_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label2" runat="server">Nombre Cliente:</asp:Label>
                    </td>
                    <td>
                       <asp:TextBox ID="textCliente" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label3" runat="server">Tipo Pago</asp:Label>
                    </td>
                 <td>
                     <asp:DropDownList ID="ddlTipoPago" runat="server" ></asp:DropDownList>
                 </td> 
                </tr>
            </table>
            <h3>Campos Detalle:</h3>
            <table>
                <tr>
                    <td>
                       <asp:Label ID="label4" runat="server">Producto</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProducto" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label ID="label5" runat="server">Cantidad</asp:label>
                    </td>
                    <td>
                        <asp:TextBox ID="textCantidad" runat="server"></asp:TextBox>
                    </td>
                    <td >
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="textCantidad" Display="Dynamic" 
                        ErrorMessage="Cantidad debe ser un numero" ForeColor="Red" Operator="DataTypeCheck" 
                        Type="Integer">Cantidad debe ser un numero</asp:CompareValidator>
                       </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="label6" runat="server">Precio</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:GridView ID="gridViewFactura" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table>
                <tr>

                 <td>
                <asp:Label ID="label7" runat="server">total</asp:Label>
                </td>
                <td>
                <asp:TextBox ID="TextBoxtotal" runat="server">0</asp:TextBox>
                </td>
                   </tr>
            </table>
          <table>
              <tr>
                  <td>
                      <asp:Button ID="BotonGuardarFacturaVenta" text="Guardar" runat="server" OnClick="BotonGuardarFacturaVenta_Click"/>
                      
                  </td>
                 <td>
                     <asp:Label ID="LabelFacturaGuardar" runat="server" Text="label" ForeColor="Green" Visible="false">Se Creo la factura</asp:Label>
                 </td>
              </tr>
          </table>  
        </div>
        
    </form>
</body>
</html>
