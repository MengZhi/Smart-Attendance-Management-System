<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonteCarloSimulation.aspx.cs" Inherits="Version20140107.Account.MonteCarloSimulation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please choose the course code:
    <asp:DropDownList ID="CourseCode" runat="server">
        <asp:ListItem Text="CPT111" Value="CPT111"></asp:ListItem>
        <asp:ListItem Text="CPT112" Value="CPT112"></asp:ListItem>
        <asp:ListItem Text="CPT113" Value="CPT113"></asp:ListItem>
        <asp:ListItem Text="CST131" Value="CST131"></asp:ListItem>
    </asp:DropDownList>
        </div>
        <div>
            Please choose the room:
    <asp:DropDownList ID="room" runat="server">
        <asp:ListItem Text="DKG31" Value="DKG31"></asp:ListItem>
        <asp:ListItem Text="Lab5" Value="Lab5"></asp:ListItem>
    </asp:DropDownList>
        </div>

        <div>
            Please choose the year of student batch:
    <asp:DropDownList ID="StudentBatch" runat="server">
        <asp:ListItem Text="2013/2014" Value="2013/2014"></asp:ListItem>
        <asp:ListItem Text="2014/2015" Value="2014/2015"></asp:ListItem>
    </asp:DropDownList>
        </div>

        <div>
            <asp:Button ID="Generate" runat="server" Text="Generate" OnClick="Generate_Click" />
            <asp:Button ID="CreateStudents" runat="server" Text="Create Students" OnClick="CreateStudents_Click" />
            <asp:Button ID="RegisterCourseID" runat="server" Text="Register Course" OnClick="RegisterCourse_Click" />
            <asp:Button ID="Refresh" runat="server" Text="Refresh" OnClick="Refresh_Click" />
        </div>


        <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" 
                    
                    OnPageIndexChanging="gridView_PageIndexChanging"
                    OnRowDeleting= "GridView1_RowDeleting"
                    OnRowDataBound= "GridView1_RowDataBound" >
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="15" FirstPageText="First" LastPageText="Last" />
                    
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="StudentId" HeaderText="Number" />

                        <asp:TemplateField HeaderText="MatricNumber">
                            <ItemTemplate>
                                <asp:Label ID="lblMatricNumber" runat="server"
                                    Text='<%# Eval("MatricNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtMatricNumber" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        
                        <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" />
                        <asp:BoundField DataField="Birthday" HeaderText="Birthday" DataFormatString="{0:yyyyMMdd}" ApplyFormatInEditMode="true"/>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <asp:Label ID="lblGender" runat="server"
                                    Text='<%# Eval("Gender")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlGender" runat="server" Text='<%# Eval("Gender")%>'>
                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Year Of Study">
                            <ItemTemplate>
                                <asp:Label ID="lblYearOfStudy" runat="server"
                                    Text='<%# Eval("YearOfStudy")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlYearOfStudy" runat="server" Text='<%# Eval("YearOfStudy")%>'>
                                    <asp:ListItem Text="First Year" Value="First Year"></asp:ListItem>
                                    <asp:ListItem Text="Second Year" Value="Second Year"></asp:ListItem>
                                    <asp:ListItem Text="Third Year" Value="Third Year"></asp:ListItem>
                                    <asp:ListItem Text="Final Year" Value="Final Year"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="SchoolName" HeaderText="School Name" />
                        <asp:BoundField DataField="EPC" HeaderText="EPC" />

                        <asp:TemplateField HeaderText="Register Course">
                            <ItemTemplate>
                                <asp:Button ID="RegisterCourse" Text="Register Course" runat="server" OnClick="RegisterCourse_Click" />
                            </ItemTemplate>

                        </asp:TemplateField>

                        
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>

            </div>



    </form>
</body>
</html>
