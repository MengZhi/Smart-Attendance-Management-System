<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LVAStudentMovement.aspx.cs" Inherits="Version20140107.Account.LAVStudentMovement" %>

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
                Course Date: <%=Session["ClassDate"]%>
            </div>

            <div>
                <asp:Button ID="refresh" runat="server" Text="Refresh" OnClick="refresh_Click" />
            </div>

            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None"
                    OnRowDataBound="GridView1_RowDataBound">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>

                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblMovementId" runat="server"
                                    Text='<%# Eval("MovementId")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtMovementId" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblMovementStatus" runat="server"
                                    Text='<%# Eval("MovementStatus")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtMovementStatus" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                                <asp:Label ID="lblTimeRecord" runat="server"
                                    Text='<%# Eval("TimeRecord")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtTimeRecord" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>
            <div>
                <asp:Label ID="summary" runat="server"></asp:Label>
            </div>


            <asp:Button ID="ChooseAnotherStudent" runat="server" Text="Choose Another Student" OnClick="ChooseAnotherStudent_Click" />

        </div>
    </form>
</body>
</html>
