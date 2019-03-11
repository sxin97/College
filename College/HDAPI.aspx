<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HDAPI.aspx.cs" Inherits="College.HDAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="Scripts/jquery-3.0.0.min.js"></script>



    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <link href="Content/bootstrap-grid.min.css" rel="stylesheet" />


    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>



    


    



</head>
<body>
    <form id="form1" runat="server">
        <div>


           

            <asp:Table runat="server">
                <asp:TableRow>

                    <asp:TableCell>
                        <asp:Label ID="lblSize" CssClass="col-form-label" runat="server" Text="Page Size: "></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlSize" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSize_SelectedIndexChanged">
                            <asp:ListItem Value="5"></asp:ListItem>
                            <asp:ListItem Value="10"></asp:ListItem>
                            <asp:ListItem Value="15"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <%--<asp:TableCell>
                        <asp:Label ID="lblSearch" runat="server" Text="Search by Name: "></asp:Label>
                    </asp:TableCell>--%>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSearch" placeholder="Search by Name" CssClass="form-control" runat="server"></asp:TextBox>
                    </asp:TableCell>

                    <asp:TableCell>
                        <asp:Button ID="btnSearch" CssClass="btn btn-info" runat="server" Text="Search" OnClick="Search_Click" />
                    </asp:TableCell>

                </asp:TableRow>

            </asp:Table>





            <div style="align-self: center">
                <asp:GridView ID="GridView1" runat="server" InsertMethod="" AutoGenerateColumns="False" DataKeyNames="StudentID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True"
                    OnRowEditing="GridView1_RowEditing1" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting"
                    OnRowCommand="GridView1_RowCommand"  OnSorting="GridView1_Sorting"       OnPageIndexChanging="GridView1_PageIndexChanging"
                    CurrentSortField="StudentID" CurrentSortDirection="ASC" AllowPaging="True" OnPreRender="GridView1_PreRender" PageSize="8" AllowSorting="True" CellPadding="4" Width="100%" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>





                        <asp:TemplateField HeaderText="ID" SortExpression="StudentID">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name" SortExpression="StudentFirstName">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbStudentFirstName" pattern="^([\sA-Za-z]+)$" CssClass="form-control" runat="server" Text='<%# Bind("StudentFirstName") %>'></asp:TextBox>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("StudentFirstName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtStudFirstName" PlaceHolder="First Name" pattern="^([\sA-Za-z]+)$" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name" SortExpression="StudentLastName">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbStudentLastName" pattern="^([\sA-Za-z]+)$" CssClass="form-control" runat="server" Text='<%# Bind("StudentLastName") %>'></asp:TextBox>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("StudentLastName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtStudLastName" PlaceHolder="Last Name" pattern="^([\sA-Za-z]+)$" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlGenderEdit" CssClass="form-control" runat="server" SelectedValue='<%# Bind("Gender") %>'>
                                    <asp:ListItem>Select Gender</asp:ListItem>
                                    <asp:ListItem Value="Male"></asp:ListItem>
                                    <asp:ListItem Value="Female"></asp:ListItem>
                                </asp:DropDownList>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlGenderInsert" CssClass="form-control" runat="server">
                                    <asp:ListItem>Select Gender</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                </asp:DropDownList>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact" SortExpression="PhoneNum">
                            <EditItemTemplate>

                                <asp:TextBox ID="tbPhoneNum" CssClass="form-control" runat="server" MaxLength="10" pattern="[0]{1}[0-9]{9}" Text='<%# Bind("PhoneNum") %>'></asp:TextBox>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("PhoneNum") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPhoneNum" PlaceHolder="Phone Number" MaxLength="10" pattern="[0]{1}[0-9]{9}" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Group ID" SortExpression="GroupID">
                            <EditItemTemplate>
                                
                                <asp:TextBox ID="tbGroupID" CssClass="form-control" runat="server" Text='<%# Bind("GroupID") %>'></asp:TextBox>
                               
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("GroupID") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%--<asp:DropDownList ID="ddlGroupIDInsert" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="GroupID" DataValueField="GroupID" runat="server"></asp:DropDownList>--%>
                                <asp:TextBox ID="txtGroupID" PlaceHolder="Group ID" CssClass="form-control" runat="server"></asp:TextBox>
                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Delete" SortExpression="isDelete">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbIsDelete" CssClass="form-control" runat="server" Text='<%# Bind("isDelete") %>'></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvEditStudentFirstName" runat="server" ErrorMessage="First Name is required" ControlToValidate="tbStudentFirstName"
                                    Text="*" ForeColor="Red">                          
                                </asp:RequiredFieldValidator>--%>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("isDelete") %>'></asp:Label>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                                <asp:TextBox ID="txtIsDelete" PlaceHolder="First Name" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="INSERT" ID="rfvInsertStudentFirstName" runat="server" ErrorMessage="First Name is required" ControlToValidate="txtStudFIrstName"
                                    Text="*" ForeColor="Red">                          
                                </asp:RequiredFieldValidator>
                            </FooterTemplate>--%>
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                <asp:LinkButton ID="RecoverBtn" runat="server" Text="Recover" CausesValidation="False" CommandName="Recover" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="AddBtn" CssClass="btn btn-success form-control" runat="server" Text="Add" CommandName="Insert" OnClick="AddBtn_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>

            
        </div>
    </form>
</body>
</html>
