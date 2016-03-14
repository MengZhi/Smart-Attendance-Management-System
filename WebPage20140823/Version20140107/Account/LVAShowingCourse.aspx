<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LVAShowingCourse.aspx.cs" Inherits="Version20140107.Account.LAVShowingCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSFile/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                Staff Name: <%=Session["StaffName"]%>
            </div>
            <div>
                Staff Number: <%=Session["StaffNumber"]%>
            </div>
            <div>
                Email Address: <%=Session["UserName"]%>
            </div>
            <div>
                <a href="LecturerWelcome.aspx">
                    <asp:Label ID="HomePage" Text='Home' runat="server" />
                </a>
            </div>
            <div>
                <a href="Login.aspx">
                    <asp:Label ID="logoutLink" Text='Logout' runat="server" />
                </a>
            </div>

            <h3>Please search your courses</h3>
            <asp:Label ID="Massege" runat="server" Text=""></asp:Label>
            <div>
                Teaching Year: 
                <asp:DropDownList ID="TeachingYear" runat="server">
                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                    <asp:ListItem Text="2013/2014" Value="2013/2014"></asp:ListItem>
                    <asp:ListItem Text="2014/2015" Value="2014/2015"></asp:ListItem>
                    <asp:ListItem Text="2015/2016" Value="2015/2016"></asp:ListItem>
                    <asp:ListItem Text="2016/2017" Value="2016/2017"></asp:ListItem>
                    <asp:ListItem Text="2017/2018" Value="2017/2018"></asp:ListItem>
                    <asp:ListItem Text="2018/2019" Value="2018/2019"></asp:ListItem>
                    <asp:ListItem Text="2019/2020" Value="2019/2020"></asp:ListItem>
                    <asp:ListItem Text="2020/2021" Value="2020/2021"></asp:ListItem>
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ControlToValidate="TeachingYear"
                    ForeColor="Red"
                    ID="RequiredFieldValidatorSelectTeachingYear" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>--%>
            </div>

            <div>
                Semester:
                <asp:DropDownList ID="Semester" runat="server">
                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                    <asp:ListItem Text="Ⅰ" Value="Ⅰ"></asp:ListItem>
                    <asp:ListItem Text="Ⅱ" Value="Ⅱ"></asp:ListItem>
                    <asp:ListItem Text="Ⅲ" Value="Ⅲ"></asp:ListItem>
                </asp:DropDownList>
               <%-- <asp:RequiredFieldValidator ControlToValidate="Semester"
                    ForeColor="Red"
                    ID="RequiredFieldValidatorSemester" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>--%>
            </div>
            <div>
                <asp:Button ID="Search" Text="Search" runat="server" ValidationGroup="PersonalInfoGroup" CausesValidation="true" OnClick= "Search_Click" />
                <asp:Button ID="ShowAll" runat="server" Text="ShowAll" OnClick= "ShowAll_Click" />
            </div>

            <div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None"
                        OnRowDataBound= "GridView1_RowDataBound" style="text-align: center">
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <Columns>                          

                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblRIId" runat="server"
                                        Text='<%# Eval("SRId")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="txtRIId" Width="40px"
                                        runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Course Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblCourseCode" runat="server"
                                        Text='<%# Eval("CourseCode")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="txtCourseCode" Width="40px"
                                        runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Course Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCourseName" runat="server"
                                        Text='<%# Eval("CourseName")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="txtCourseName" Width="40px"
                                        runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Teaching Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblTeachingYear" runat="server"
                                        Text='<%# Eval("TeachingYear")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="txtTeachingYear" Width="40px"
                                        runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Semester">
                                <ItemTemplate>
                                    <asp:Label ID="lblSemester" runat="server"
                                        Text='<%# Eval("Semester")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="txtSemester" Width="40px"
                                        runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Check Class">
                                <ItemTemplate>
                                    <asp:Button ID="CheckClass" Text="Check" runat="server" OnClick= "CheckClass_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>





        </div>
    </form>
</body>
</html>
