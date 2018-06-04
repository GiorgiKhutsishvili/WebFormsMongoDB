<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="WebFormsMongoDB.AddCar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
                <tr>
                    <td class="label" colspan="3" style="padding-left: 50px;"><strong>Inserting Cars Information to Mongo DB </strong></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCar" CssClass="label" runat="server" Text="Car"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCar" runat="server" Width="151px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNameForCar" runat="server"
                            ErrorMessage="ჩაწერეთ ავტომობილი" ForeColor="Red" ControlToValidate="txtCar">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCarModel" CssClass="label" runat="server" Text="Car Model"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCarModel" runat="server" Width="151px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNameForCarModel" runat="server"
                            ErrorMessage="ჩაწერეთ ავტომობილის მოდელი" ForeColor="Red" ControlToValidate="txtCarModel">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProductionYear" CssClass="label" runat="server" Text="Production Year"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductionYear" runat="server" Width="151px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNameForProductionYear" runat="server"
                            ErrorMessage="ჩაწერეთ გამოშვების წელი" ForeColor="Red" ControlToValidate="txtProductionYear">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button  ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="128px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
