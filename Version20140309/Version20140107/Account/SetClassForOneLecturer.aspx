<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetClassForOneLecturer.aspx.cs" Inherits="Version20140107.Account.SetClassForOneLecturer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3>Setting Class For Lecturer</h3>
    <form id="form1" runat="server">
        <div>
            <div>
                Lecturer Name:<%=Session["FirstName"]%>  <%=Session["SecondName"] %>
                <br />
            </div>
            <div>
                Staff Number:<%=Session["StaffNumber"] %>
            </div>

            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SRId" HeaderText="Registration ID" ReadOnly="True" />
                        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />

                        <asp:TemplateField HeaderText="Set Time">
                            <ItemTemplate>
                                <asp:Button ID="SetTime" Text="Set Time" runat="server" OnClick="SetTime_Click" />
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
                <asp:Button ID="FinishSetting" Text="Finish Setting" runat="server" OnClick="FinishSetting_Click" />
            </div>

            <div>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None"
                    AllowPaging="True"
                    OnPageIndexChanging= "GridView2_PageIndexChanging"
                    OnRowDeleting= "GridView2_RowDeleting"
                    OnRowEditing= "GridView2_RowEditing"
                    OnRowUpdating= "GridView2_RowUpdating"
                    OnRowDataBound= "GridView2_RowDataBound"
                    OnRowCancelingEdit= "GridView2_RowCancelingEdit"
                    OnSelectedIndexChanged= "GridView2_SelectedIndexChanged">
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

                        <asp:TemplateField HeaderText="Record ID">
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
