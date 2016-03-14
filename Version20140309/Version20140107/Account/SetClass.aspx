<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetClass.aspx.cs" Inherits="Version20140107.Account.SetClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Set Class for Lecturer</h2>
    <form id="form1" runat="server">
        <div>
            <h3>Please choose a lecturer and set the class</h3>
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnRowDataBound= "GridView1_RowDataBound">
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
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" DataFormatString="{0:yyyyMMdd}" ApplyFormatInEditMode="true" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="SchoolName" HeaderText="School Name" />
                    <asp:BoundField DataField="EPC" HeaderText="EPC" />

                    <asp:TemplateField HeaderText="Register Course">
                        <ItemTemplate>
                            <asp:Button ID="SetClass" Text="Set Class" runat="server" OnClick="SetClass_Click" />
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
            <asp:Button ID="FinishSetting" Text="Finish Setting" runat="server" OnClick="FinishSetting_Click"/>
        </div>



    </form>
</body>
</html>
