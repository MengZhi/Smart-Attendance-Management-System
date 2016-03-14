<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollStudent.aspx.cs" Inherits="Version20140107.Account.EnrollStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function FinishEnrollStudent() {
            //var message = "";
            //if (document.getElementById("FirstName").value == "")
            //{
            //    message = "Finished Enrolling Student.";
            //}
            //document.write("hello");

            //return true;
        }
        function EnrollStudent() {
            var message = "";
            if (document.getElementById("FirstName").nodeValue == "")
                message = "Finished Enrolling Student.";


        }

    </script>


</head>
<body>
    <h3>Enroll Student</h3>
    <form id="form1" runat="server">
        <div>
            <div>First Name:</div>
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            <div>Last Name:</div>
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <div>Matric No.:</div>
            <asp:TextBox ID="MatricNumber" runat="server"></asp:TextBox>
            <div>Email Address:</div>
            <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>
            <div>Birthday: </div>
            <asp:TextBox ID="Birthday" runat="server"></asp:TextBox>

            <div>Gender:</div>
            <asp:DropDownList ID="Gender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>

            <div>Year of Study:</div>
            <asp:DropDownList ID="YearOfStudy" runat="server">
                <asp:ListItem Text="First Year" Value="First"></asp:ListItem>
                <asp:ListItem Text="Second Year" Value="Second"></asp:ListItem>
                <asp:ListItem Text="Third Year" Value="Third"></asp:ListItem>
                <asp:ListItem Text="Final Year" Value="Final"></asp:ListItem>
            </asp:DropDownList>

            <div>SchoolName:</div>
            <asp:TextBox ID="SchoolName" runat="server"></asp:TextBox>

           

            <div id="submit">
                <asp:Button ID="Register" runat="server" Text="Register" OnClick="Add_Click" OnClientClick="return EnrollStudent();" />
                <asp:Button ID="Reset" runat="server" Text="Reset" OnClick="Reset_Click" OnClientClick="return FinishEnrollStudent()" />
                <asp:Button ID="Refash" runat="server" Text="Refash Record" OnClick="RefashRecord" />
            </div>
        </div>


            
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" 
                    AllowPaging="True"
                    OnPageIndexChanging="gridView_PageIndexChanging"
                    OnRowDeleting="GridView1_RowDeleting" 
                    OnRowEditing="GridView1_RowEditing"
                    OnRowUpdating="GridView1_RowUpdating"
                    OnRowDataBound="GridView1_RowDataBound"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged2">
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
                    OnClick="Finish_Click" Text="Finish Registration" />
                <asp:Button ID="test" runat="server" Text="test" OnClick="test_Click" />
            </div>
    </form>
</body>
</html>
