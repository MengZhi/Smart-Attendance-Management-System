<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetClassTime.aspx.cs" Inherits="Version20140107.Account.SetClassTime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                Course Code:<%=Session["CourseCode"]%>
                <br />
            </div>
            <div>
                Course Name:<%=Session["CourseName"] %>
            </div>

            <div>
                Lecturer Name:<%=Session["FirstName"]%>  <%=Session["SecondName"] %>
                <br />
            </div>
            <div>
                Staff Number:<%=Session["StaffNumber"] %>
            </div>



            <div>
                Semester:
                <asp:DropDownList ID="Semester" runat="server">
                    <asp:ListItem Text="Ⅰ" Value="Ⅰ"></asp:ListItem>
                    <asp:ListItem Text="Ⅱ" Value="Ⅱ"></asp:ListItem>
                    <asp:ListItem Text="Ⅲ" Value="Ⅲ"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                Teaching Year:
                <asp:TextBox ID="TeachingYear" runat="server"></asp:TextBox>YYYY/YYYY
            </div>

            <div>
                Building Number:
                <asp:TextBox ID="BuildingNumber" runat="server"></asp:TextBox>
            </div>

            <div>
                Room Number:
                <asp:TextBox ID="RoomNumber" runat="server"></asp:TextBox>
            </div>

            <div>
                Time Start:
                <asp:TextBox ID="TimeStart" runat="server"></asp:TextBox>HHMMSS
            </div>

            <div>
                Time End:
                <asp:TextBox ID="TimeEnd" runat="server"></asp:TextBox>HHMMSS
            </div>

            <div>
                Date:
                <asp:TextBox ID="CourseDate" runat="server"></asp:TextBox>YYYY/MM/DD
            </div>

            <div>
                <asp:Button ID="Set" Text="Confirm Setting" runat="server" OnClick="Set_Click" />
                <asp:Button ID="FinishSetting" Text="Finish Setting" runat="server" OnClick="FinishSetting_Click" />
                <asp:Button ID="Cancle" Text="Cancle" runat="server" OnClick="Cancle_Click" />
            </div>

            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None"
                    AllowPaging="True"
                    OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowDeleting="GridView1_RowDeleting"
                    OnRowEditing="GridView1_RowEditing"
                    OnRowUpdating="GridView1_RowUpdating"
                    OnRowDataBound="GridView1_RowDataBound"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="15" FirstPageText="First" LastPageText="Last" />

                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>

                        <asp:TemplateField HeaderText="NO.">
                            <ItemTemplate>
                                <asp:Label ID="lblNumber" runat="server"
                                    Text='Number'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtNumber" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblCourseTimeInfoId" runat="server"
                                    Text='<%# Eval("CourseTimeInfoId")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtCourseTimeInfoId" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="lblLastName" runat="server"
                                    Text='<%# Eval("LLastName")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtLastName" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label ID="lblFirstName" runat="server"
                                    Text='<%# Eval("LFirstName")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtFirstName" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Staff Number">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffNumber" runat="server"
                                    Text='<%# Eval("StaffNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtStaffNumber" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Semester">
                            <ItemTemplate>
                                <asp:Label ID="lblSemester" runat="server"
                                    Text='<%# Eval("Semester")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSemester" runat="server" Text='<%# Eval("Semester")%>'>
                                    <asp:ListItem Text="Ⅰ" Value="Ⅰ"></asp:ListItem>
                                    <asp:ListItem Text="Ⅱ" Value="Ⅱ"></asp:ListItem>
                                    <asp:ListItem Text="Ⅲ" Value="Ⅲ"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="TeachingYear" HeaderText="Teaching Year" />
                        <asp:BoundField DataField="BuildingNumber" HeaderText="Building Number" />

                        <asp:BoundField DataField="RoomNumber" HeaderText="Room Number" />
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
                        
                        <asp:TemplateField HeaderText="CourseName">
                            <ItemTemplate>
                                <asp:Label ID="lblCourseName" runat="server"
                                    Text='<%# Eval("CourseName")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtCourseName" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>

                        

                        <asp:BoundField DataField="CourseDate" HeaderText="Course Date" DataFormatString="{0:yyyy/MM/dd}" ApplyFormatInEditMode="true" />
                        <asp:BoundField DataField="StartTime" HeaderText="Start Time"  />
                        <asp:BoundField DataField="EndTime" HeaderText="End Time"  />
                                                                                                                    
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>


            </div>



        </div>
    </form>
</body>
</html>
