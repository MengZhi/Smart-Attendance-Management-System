<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LVAOneClass.aspx.cs" Inherits="Version20140107.Account.LVAOneCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                Class Date: <%=Session["ClassDate"]%>
            </div>
            <div>
                <asp:Button ID="Refresh" runat="server" Text="Refresh" OnClick="Refresh_Click" />
            </div>
          

            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="Both"
                    OnRowDataBound="GridView1_RowDataBound">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>

                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblStudentAttendanceId" runat="server"
                                    Text='<%# Eval("StudentAttendanceId")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtStudentAttendanceId" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" runat="server"
                                    Text='<%# Eval("FirstName")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtFirstName" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server"
                                    Text='<%# Eval("LastName")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtLastName" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Matric Number">
                            <ItemTemplate>
                                <asp:Label ID="lblMatricNumber" runat="server"
                                    Text='<%# Eval("MatricNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtMatricNumber" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Email Address">
                            <ItemTemplate>
                                <asp:Label ID="lblEmailAddress" runat="server"
                                    Text='<%# Eval("EmailAddress")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtEmailAddress" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblAttendanceStatus" runat="server"
                                    Text='<%# Eval("AttendanceStatus")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlAttendanceStatus" runat="server" Text='<%# Eval("AttendanceStatus")%>'>
                                    <asp:ListItem Text="Absent" Value="Absent"></asp:ListItem>
                                    <asp:ListItem Text="Attend" Value="Attend"></asp:ListItem>

                                </asp:DropDownList>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtStatus" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <%--<asp:CommandField HeaderText="Edit" ShowEditButton="True"/>--%>


                        <asp:TemplateField HeaderText="Check Movement">
                            <ItemTemplate>
                                <asp:Button ID="CheckMovement" Text="Check" runat="server" OnClick="CheckMovement_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>

            Statistic of This Class

            <div>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="Both" >
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>

                        <%--<asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatusInfo" runat="server"></asp:Label>
                            </ItemTemplate>                          
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Student Number">
                            <ItemTemplate>
                                <asp:Label ID="lblStudentNumberInfo" runat="server"></asp:Label>
                            </ItemTemplate>                          
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Persentage">
                            <ItemTemplate>
                                <asp:Label ID="lblPersentageInfo" runat="server"></asp:Label>
                            </ItemTemplate>                          
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="StudentNumberInfo" HeaderText="Student Number" />
                        <asp:BoundField DataField="Persentage" HeaderText="Persentage" />

                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>




            <div>
                <asp:Label ID="StudentNumberInfo" runat="server"></asp:Label>
            </div>
           

            <div>
                <asp:Button ID="ChooseAnotherClass" runat="server" Text="Choose Another Class" OnClick="ChooseAnotherClass_Click" />
            </div>


        </div>
    </form>
</body>
</html>
