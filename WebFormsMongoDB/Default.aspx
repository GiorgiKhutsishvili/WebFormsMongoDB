<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsMongoDB.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1></h1>
        <asp:Button ID="showButton" runat="server" Text="Show Cars" OnClick="showButton_Click" />
    </div>
        <asp:Label ID="nameLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
