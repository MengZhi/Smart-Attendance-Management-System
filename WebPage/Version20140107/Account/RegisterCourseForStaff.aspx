﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourseForStaff.aspx.cs" Inherits="Version20140107.Account.RegisterCourseForStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="label1" runat="server"></asp:Label>

    <h3>Register Courses For Lecturer</h3>
    
        <div>
            <div>
                Lecturer Name:<%=Session["FirstName"]%>  <%=Session["LastName"] %>
                
                <br />
            </div>
            <div>
                Staff Number:<%=Session["StaffNumber"] %>
                
            </div>

            <div>
                Please select teaching year: 
                <asp:DropDownList ID="SelectTeachingYear" runat="server">
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
                <asp:RequiredFieldValidator ControlToValidate="SelectTeachingYear"
                    ForeColor="Red"
                    ID="RequiredFieldValidatorSelectTeachingYear" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
            </div>
            <div>
                Please select semester:
                <asp:DropDownList ID="SelectSemester" runat="server">
                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                    <asp:ListItem Text="Ⅰ" Value="Ⅰ"></asp:ListItem>
                    <asp:ListItem Text="Ⅱ" Value="Ⅱ"></asp:ListItem>
                    <asp:ListItem Text="Ⅲ" Value="Ⅲ"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="SelectSemester"
                    ForeColor="Red"
                    ID="RequiredFieldValidatorSemester" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
            </div>

            <asp:Label ID="CourseRegistered" runat="server" Text="Registered Course List"></asp:Label>

            <asp:Button ID="test" runat="server" OnClick= "test_Click" Text="refrash"/>

            <div>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" 
                    OnRowDeleting= "GridView2_RowDeleting" 
                    OnRowEditing= "GridView2_RowEditing"
                    OnRowUpdating= "GridView2_RowUpdating" 
                    OnRowCancelingEdit= "GridView2_RowCancelingEdit">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SRId" HeaderText="Registration ID" ReadOnly="True" />
                        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                        <asp:BoundField DataField="TeachingYear" HeaderText="Teaching Year" />
                        <asp:BoundField DataField="Semester" HeaderText="Semester" />
                        
                        
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>

            <asp:Button ID="finish" runat="server" OnClick= "finished_Click" Text="finished"/>

            </br>
            <asp:Label ID="Courseregistration" runat="server" Text="Course List For Registration"></asp:Label>

            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    AllowPaging="True"
                    OnPageIndexChanging= "GridView1_PageIndexChanging"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First" LastPageText="Last" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <Columns>

                        <asp:BoundField DataField="CourseId" HeaderText="Number" />
                        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />

                        <asp:TemplateField HeaderText="Register">
                            <ItemTemplate>
                                <asp:Button ID="Register" Text="Register" runat="server" ValidationGroup="PersonalInfoGroup" CausesValidation="true" OnClick= "Register_Click" />
                            </ItemTemplate>

                        </asp:TemplateField>
                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
