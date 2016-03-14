<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollStaff.aspx.cs" Inherits="Version20140107.Account.EnrollStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .lbBottom {
                font-family: Verdana, Arial, Geneva, Helvetica, sans-serif;
	            font-size: 10px;
	            color: #666;
	            line-height: 1.4em;
	            text-align: left;
	            border: 10px solid #fff;
	            border-top-style: none;
            }
        .button {
            height: 2.142em;
            min-width: 6em;
            font-family: "Segoe UI Semibold", "Segoe UI Web Semibold", "Segoe UI Web Regular", "Segoe UI", "Segoe UI Symbol","HelveticaNeue-Medium", "Helvetica Neue", Arial, sans-serif;
            font-weight: normal;
            font-size: 100%;
            background-color: #0072C6;
            color: #212121;
            padding: 3px 12px 5px;
            border: 0px;
                }
        .default {
            background-color: #0072C6;
                }
    </style>
    <link rel="stylesheet" href="C:/Users/workshop/Desktop/Version20131222/WebApplication2/Content/themes/base/sampleTest2.css" type="text/css" />
</head>
<body>
    <h3>Enroll Staff</h3>
    <form id="form1" runat="server">
    <div>
            <div>First Name:</div>
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            <div>Last Name:</div>
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <div>Staff No.:</div>
            <asp:TextBox ID="StaffNumber" runat="server"></asp:TextBox>
            <div>Email Address:</div>
            <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>
            <div>Birthday: </div>
            <asp:TextBox ID="Birthday" runat="server"></asp:TextBox>
            <div>Gender:</div>
            <asp:DropDownList ID="Gender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>

            <div>SchoolName:</div>
            <asp:TextBox ID="SchoolName" runat="server"></asp:TextBox>

            

        <div >           
            <asp:Button ID="Register" runat="server" Text ="Register" CssClass="button" OnClick="Register_Click" />
            <asp:Button ID="Reset" runat="server" Text ="Reset" CssClass="button" OnClick="Reset_Click" />          
        </div>
  
        <div>
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" 
                    OnRowDeleting= "GridView1_RowDeleting" 
                    OnRowEditing= "GridView1_RowEditing"
                    OnRowUpdating= "GridView1_RowUpdating"
                    OnRowDataBound= "GridView1_RowDataBound"
                    OnRowCancelingEdit= "GridView1_RowCancelingEdit" 
                    OnSelectedIndexChanged= "GridView1_SelectedIndexChanged">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="StaffId" HeaderText="Number" />

                        <asp:TemplateField HeaderText="StaffNumber">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffNumber" runat="server"
                                    Text='<%# Eval("StaffNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtStaffNumber" Width="40px"
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
                        

                        <asp:BoundField DataField="SchoolName" HeaderText="School Name" />
                        <asp:BoundField DataField="EPC" HeaderText="EPC" />

                        <asp:TemplateField HeaderText="Register Course">
                            <ItemTemplate>
                                <asp:Button ID="RegisterCourse" Text="Register Course" runat="server" OnClick="RegisterCourse_Click" />
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Select" ShowSelectButton="true" />
                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>



        </div>
        <div>              
                <br />              
                <asp:Button ID="Finish" runat="server"
                    OnClick= "Finish_Click" Text="Finish Registration" />
            </div>
    </div>
    </form>
</body>
</html>
