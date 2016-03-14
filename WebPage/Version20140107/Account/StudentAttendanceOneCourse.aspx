<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAttendanceOneCourse.aspx.cs" Inherits="Version20140107.Account.StudentShowAllClasses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                Student Name: <%=Session["StudentName"]%>
            </div>
            <div>
                Matric Number: <%=Session["MatricNumber"]%>
            </div>
            <div>
                Email Address: <%=Session["UserName"]%>
            </div>
            <div>
                Teaching Year: <%=Session["TeachingYear"]%>
            </div>
            <div>
                Semester: <%=Session["Semester"]%>
            </div>
            <div>
                Course Code: <%=Session["CourseCode"]%>
            </div>
            <div>
                Course Name: <%=Session["CourseName"]%>
            </div>

            <div>
                <a href="StudentWelcome.aspx">
                    <asp:Label ID="HomePage" Text='Home' runat="server" />
                </a>
            </div>
            <div>
                <a href="Login.aspx">
                    <asp:Label ID="logoutLink" Text='Logout' runat="server" />
                </a>
            </div>

            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None"
                    OnRowDataBound= "GridView1_RowDataBound">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>                    


                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblNumber" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="StudentAttendanceId">
                            <ItemTemplate>
                                <asp:Label ID="lblStudentAttendanceId" runat="server"
                                    Text='<%# Eval("StudentAttendanceId")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtStudentAttendanceId" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Class Date">
                            <ItemTemplate>
                                <asp:Label ID="lblClassDate" runat="server"
                                    Text='<%# Eval("ClassDate", "{0:yyyy/MM/dd}")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtClassDate" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblAttendanceStatus" runat="server"
                                    Text='<%# Eval("AttendanceStatus")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtAttendanceStatus" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>                       
                                         

                        <asp:TemplateField HeaderText="Check Movement">
                            <ItemTemplate>
                                <asp:Button ID="Check" Text="Check" runat="server" OnClick= "Check_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>
             <div>
                <asp:Button ID="ChooseAnotherCourse" runat="server" Text="Choose Another Course" OnClick= "ChooseAnotherCourse_Click" />
            </div>
        </div>


    </form>
</body>
</html>
