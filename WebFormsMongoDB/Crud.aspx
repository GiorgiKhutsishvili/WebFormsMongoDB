<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="WebFormsMongoDB.Crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="scripts/jquery-3.3.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButtonAddCar" runat="server" PostBackUrl="~/AddCar.aspx">მანქანის დამატება</asp:LinkButton>
            <br />
            <asp:GridView DataKeyNames="_id" ID="GridView1" runat="server" Width="1000px" AutoPostBack="true"  AutoGenerateSelectButton="True"
                AutoGenerateColumns="false" PageSize="5" HeaderStyle-BackColor="#6699ff" HeaderStyle-ForeColor="WhiteSmoke" AllowPaging="False">
                <Columns>
                    <asp:BoundField DataField="_id" HeaderText="Id"  />
                    <asp:BoundField DataField="Car" HeaderText="Car Name"  />
                    <asp:BoundField DataField="CarModel" HeaderText="Car Model" />
                    <asp:BoundField DataField="ProductionYear" HeaderText="ProductionYear"  />
                    <%--<asp:TemplateField ItemStyle-Width="80px" HeaderText="Edit">    
                                <ItemTemplate>    
                                     <asp:LinkButton ID="lnkbtn" runat="server"  OnClick="Edit" CommandArgument='<%# Eval("_id") %>'>Edit</asp:LinkButton>      
                                     <asp:LinkButton ID="lnkDel" runat="server"   OnClick="delete" CommandArgument='<%# Eval("_id") %>'>Delete</asp:LinkButton>    
                                </ItemTemplate>    
                            </asp:TemplateField>  --%>
                </Columns>
            </asp:GridView>
            <%--<asp:TemplateField ItemStyle-Width="80px" HeaderText="Edit">    
                                <ItemTemplate>    
                                     <asp:LinkButton ID="lnkbtn" runat="server"  OnClick="Edit" CommandArgument='<%# Eval("_id") %>'>Edit</asp:LinkButton>      
                                     <asp:LinkButton ID="lnkDel" runat="server"   OnClick="delete" CommandArgument='<%# Eval("_id") %>'>Delete</asp:LinkButton>    
                                </ItemTemplate>    
                            </asp:TemplateField>  --%>
            <br />
            <asp:DropDownList AppendDataBoundItems="true" DataValueField="_id"  DataTextField="Car" ID="DropDownListCar" runat="server">
                <asp:ListItem Text="აირჩიეთ მანქანა" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList AppendDataBoundItems="true" DataValueField="_id" DataTextField="CarModel" ID="DropDownListCarModel" runat="server">
                <asp:ListItem Text="აირჩიეთ მოდელი" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList AppendDataBoundItems="true" DataValueField="_id" DataTextField="ProductionYear" ID="DropDownListProductionYear" runat="server">
                <asp:ListItem Text="აირჩიეთ გამოშვების წელი" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:Label ForeColor="Red" ID="lblErrorMessage" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
