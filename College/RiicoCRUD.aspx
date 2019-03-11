<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiicoCRUD.aspx.cs" Inherits="College.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found" AutoGenerateColumns="False" DataKeyNames="Id" ShowFooter="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="10" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <AlternatingRowStyle BackColor="#efefef" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="ID" SortExpression="StudentID">
                        <EditItemTemplate>
                            <asp:Label ID="LabelStudId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                            
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="itemStudId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" SortExpression="StudentName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" BackColor="#efefef" runat="server" Text='<%# Bind("CustomerName") %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorName2" runat="server" ErrorMessage="Name is required" Text="*" ForeColor="Red" ControlToValidate="TextBox1">
                            </asp:RequiredFieldValidator>--%>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxName" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Name is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxName" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address" SortExpression="StudentPass">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox" runat="server" BackColor="#efefef" Text='<%# Bind("CustomerAddress") %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorPass2" runat="server" ErrorMessage="Password is required" Text="*" ForeColor="Red" ControlToValidate="TextBox">
                            </asp:RequiredFieldValidator>--%>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("CustomerAddress") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxAddress" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxPassword" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="CustomerPhone" SortExpression="StudentPhone">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" BackColor="#efefef" Text='<%# Bind("CustomerPhone") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("CustomerPhone") %>'></asp:Label>
                        </ItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxPhone" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ErrorMessage="Phone No. is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxPhone" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" ForeColor="Blue" runat="server" CausesValidation="True" CommandName="Update" Text="Update" ></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Blue" CausesValidation="False" CommandName="Edit" Text="Edit" ></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" ForeColor="Blue" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButtonInsert" runat="server" ForeColor="Blue" OnClick="LinkButtonInsert_Click" >Insert</asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
