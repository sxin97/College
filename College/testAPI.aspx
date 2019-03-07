<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testAPI.aspx.cs" Inherits="College.testAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name:
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
<hr/>
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField ItemStyle-Width="150px" DataField="StudentId" HeaderText="ID"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="StudentName" HeaderText="Name"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="StudentPass" HeaderText="Password"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="StudentPhone" HeaderText="Phone"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="StudentEmail" HeaderText="Email"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="GroupCode" HeaderText="Group"/>
        <asp:BoundField ItemStyle-Width="150px" DataField="Deleted" HeaderText="Deleted"/>
    </Columns>
</asp:GridView>
        </div>
    </form>
</body>
</html>
