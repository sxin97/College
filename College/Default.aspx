<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Default.aspx.cs" Inherits="College.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<html>--%>
   
<%--<head runat="server">--%>
    <title></title>
    <%--<link href="bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="bootstrap/bootstrap-grid.css" rel="stylesheet" />
    <link href="bootstrap/bootstrap-grid.min.css" rel="stylesheet" />--%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    
    <link href="bootstrap/cover.css" rel="stylesheet" />

    <%--</head>--%>
    <script>
        function load() {
            document.getElementById("TextBoxSearch").focus();
            $("#ButtonSearch").click();
}
</script>
   
<%--<body>--%>
    <%--<form id="form1" runat="server">--%>
    
        <div>
            
            <br />
            <br />
            Page Size :
            <asp:TextBox ID="TextBoxPaging" CssClass="textbox" BackColor="#efefef" runat="server" Width="20px" AutoPostBack="true" OnTextChanged="TextBoxPaging_TextChanged"></asp:TextBox>
            &nbsp;&nbsp;&nbsp; Search :
            <asp:TextBox ID="TextBoxSearch" runat="server" BackColor="#efefef" AutoPostBack="true" OnTextChanged="TextBoxSearch_TextChanged"></asp:TextBox>
            <asp:Button ID="ButtonSearch" runat="server" Text="Search" Visible="false" OnClick="ButtonSearch_Click"/>

            

            

            &nbsp;&nbsp;&nbsp; Sort :
            <asp:DropDownList ID="DropDownList2" runat="server" BackColor="#efefef" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>StudentName</asp:ListItem>
                <asp:ListItem>StudentId</asp:ListItem>
                <asp:ListItem>GroupCode</asp:ListItem>
                <asp:ListItem>StudentEmail</asp:ListItem>
                <asp:ListItem>StudentPhone</asp:ListItem>
            </asp:DropDownList>

            

            

            &nbsp;Order :
            <asp:DropDownList ID="DropDownList3" runat="server" BackColor="#efefef" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                <asp:ListItem>Ascending</asp:ListItem>
                <asp:ListItem>Descending</asp:ListItem>
            </asp:DropDownList>

            

            

            <br />
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="StudentID" ShowFooter="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="10" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <AlternatingRowStyle BackColor="#efefef" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="StudentID" SortExpression="StudentID">
                        <EditItemTemplate>
                            <asp:Label ID="LabelStudId" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                            
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="itemStudId" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxID" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ErrorMessage="ID is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxID" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StudentName" SortExpression="StudentName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" BackColor="#efefef" runat="server" Text='<%# Bind("StudentName") %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorName2" runat="server" ErrorMessage="Name is required" Text="*" ForeColor="Red" ControlToValidate="TextBox1">
                            </asp:RequiredFieldValidator>--%>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("StudentName") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxName" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Name is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxName" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StudentPassword" SortExpression="StudentPass">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox" runat="server" BackColor="#efefef" Text='<%# Bind("StudentPass") %>'></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorPass2" runat="server" ErrorMessage="Password is required" Text="*" ForeColor="Red" ControlToValidate="TextBox">
                            </asp:RequiredFieldValidator>--%>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("StudentPass") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxPassword" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxPassword" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="StudentPhone" SortExpression="StudentPhone">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" BackColor="#efefef" Text='<%# Bind("StudentPhone") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("StudentPhone") %>'></asp:Label>
                        </ItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxPhone" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ErrorMessage="Phone No. is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxPhone" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="StudentEmail" SortExpression="StudentEmail">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" BackColor="#efefef" Text='<%# Bind("StudentEmail") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("StudentEmail") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxEmail" BackColor="#efefef" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email is required" Text="*" ForeColor="Red" ControlToValidate="TextBoxPassword" ValidationGroup="insertGroup">
                            </asp:RequiredFieldValidator>--%>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GroupCode" SortExpression="GroupCode">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" BackColor="#efefef" runat="server" DataSourceID="SqlDataSource2" DataTextField="GroupCode" DataValueField="GroupCode" AutoPostBack="True" SelectedValue='<%# Bind("GroupCode") %>' ></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("GroupCode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="DropDownListGroupCode" BackColor="#efefef" runat="server" DataSourceID="SqlDataSource2" DataTextField="GroupCode" DataValueField="GroupCode">
            </asp:DropDownList>
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
            <br />
            <br />
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDBConnectionString %>" DeleteCommand="DELETE FROM [Student] WHERE [StudentId] = @StudentId" InsertCommand="INSERT INTO [Student] ([StudentId], [StudentName], [StudentPass], [StudentPhone], [StudentEmail], [GroupCode]) VALUES (@StudentId, @StudentName, @StudentPass, @StudentPhone, @StudentEmail, @GroupCode)" SelectCommand="SELECT * FROM [Student] WHERE ([StudentName] LIKE '%' + @StudentName + '%') ORDER BY [StudentName]" UpdateCommand="UPDATE [Student] SET [StudentName] = @StudentName, [StudentPass] = @StudentPass, [StudentPhone] = @StudentPhone, [StudentEmail] = @StudentEmail, [GroupCode] = @GroupCode WHERE [StudentId] = @StudentId">
                <DeleteParameters>
                    <asp:Parameter Name="StudentId" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="StudentId" Type="String" />
                    <asp:Parameter Name="StudentName" Type="String" />
                    <asp:Parameter Name="StudentPass" Type="String" />
                    <asp:Parameter Name="StudentPhone" Type="String" />
                    <asp:Parameter Name="StudentEmail" Type="String" />
                    <asp:Parameter Name="GroupCode" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBoxSearch" DefaultValue=" " Name="StudentName" PropertyName="Text" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="StudentName" Type="String" />
                    <asp:Parameter Name="StudentPass" Type="String" />
                    <asp:Parameter Name="StudentPhone" Type="String" />
                    <asp:Parameter Name="StudentEmail" Type="String" />
                    <asp:Parameter Name="GroupCode" Type="String" />
                    <asp:Parameter Name="StudentId" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>--%>
            <br />
            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="None" ForeColor="#FF3300" ValidationGroup="insertGroup" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor ="Red"/>
            
            <br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDBConnectionString %>" SelectCommand="SELECT [GroupCode] FROM [Group]"></asp:SqlDataSource>
            
            <br />
            

            <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Register student.aspx">Register</asp:HyperLink>--%>

            

            <br />
            <br />
            <br />

            

        </div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
<%--    </form>--%>
<%--</body>--%>
<%--</html>--%>
</asp:Content>
