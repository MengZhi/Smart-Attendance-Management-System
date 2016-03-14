<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LVAShowAllClasses.aspx.cs" Inherits="Version20140107.Account.LVAShowAllClasses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Massege" runat="server" Text="Massege"></asp:Label>
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
                Course Code: <%=Session["CourseCode"]%>
            </div>
            <div>
                Course Name: <%=Session["CourseName"]%>
            </div>
            <div>
                Teaching Year: <%=Session["TeachingYear"]%>
            </div>
            <div>
                Semester: <%=Session["Semester"]%>
            </div>
            <div>
                <a href="LecturerWelcome.aspx">
                    <asp:Label ID="HomePage" Text='Home' runat="server" />
                </a>
                <br />
                <a href="Login.aspx">
                <asp:Label ID="logoutLink" Text='Logout' runat="server" />
                </a>
            </div>
            <div style="text-align: center">
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

                        <asp:TemplateField HeaderText="Class ID">
                            <ItemTemplate>
                                <asp:Label ID="lblClassId" runat="server"
                                    Text='<%# Eval("ClassId")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtClassId" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Building Number">
                            <ItemTemplate>
                                <asp:Label ID="lblBuildingNumber" runat="server"
                                    Text='<%# Eval("BuildingNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtBuildingNumber" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Room Number">
                            <ItemTemplate>
                                <asp:Label ID="lblRoomNumber" runat="server"
                                    Text='<%# Eval("RoomNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtCourseName" Width="40px"
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



                        <asp:TemplateField HeaderText="Start Time">
                            <ItemTemplate>
                                <asp:Label ID="lblStartTime" runat="server"
                                    Text='<%# Eval("StartTime")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtStartTime" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="End Time">
                            <ItemTemplate>
                                <asp:Label ID="lblEndTime" runat="server"
                                    Text='<%# Eval("EndTime")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtEndTime" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Check Attendance">
                            <ItemTemplate>
                                <asp:Button ID="CheckAttendance" Text="Check" runat="server" OnClick= "CheckAttendance_Click" />
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
                    <asp:Button ID="ChooseAnotherCourse" Text='Choose Another Course' runat="server" OnClick="ChooseAnotherCourse_Click"/>               
            </div>








        </div>
    </form>
</body>
</html>
