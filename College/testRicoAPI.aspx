<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testRicoAPI.aspx.cs" Inherits="College.testRicoAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="Id" HeaderText="ID"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="CustomerName" HeaderText="Name"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="CustomerAddress" HeaderText="Address"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="CustomerPhone" HeaderText="Phone"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="CustomerStatus" HeaderText="Status"/>
        
    </Columns>
</asp:GridView>
        </div>
    </form>
</body>
</html>
