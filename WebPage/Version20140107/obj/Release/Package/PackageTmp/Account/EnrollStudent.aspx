<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollStudent.aspx.cs" Inherits="Version20140107.Account.EnrollStudent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">


        function ShowYears(sender, args) {
            sender._switchMode("years", true);
        }

        function Reset() {
            //document.getElementById('FirstName').value = '';
            document.getElementById("FirstName").value = "";
            //var seText = document.getElementById("TextBox2");
            //htText.value = "";

            //return true;
        }
    </script>
   <%-- <link href="../CSSFile/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/languages/jquery.validationEngine-en.js"
        charset="utf-8"></script>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/jquery.validationEngine.js"
        charset="utf-8"></script>--%>
    <script type="text/javascript">
        function reset() {
            //document.getElementById('FirstName').value = '';
            document.getElementById('FirstName').value = "";
            document.getElementById('LastName').value = "";
            document.getElementById('MatricNumber').value = "";
            document.getElementById('EmailAddress').value = "";
            document.getElementById('Birthday').value = "";
            document.getElementById('Gender').value = "";
            document.getElementById('YearOfStudy').value = "";
            document.getElementById('SchoolName').value = "";

        }
        function checkValidation() {



        }

        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });

        function StudentName(field, rules, i, options) {
            var regex = /^[a-zA-Z ]+$/;
            if (!regex.test(field.val())) {
                return "Please enter a valid student name."
            }
        }


        function DateFormat(field, rules, i, options) {

            var regex = /^[0-9]{4}[\/\-](0[1-9]|1[0-2])[\/\-](0[1-9]|[1-2][0-9]|3[0-1])$/;
            if (!regex.test(field.val())) {
                return "Please enter date in yyyy/MM/dd format."
            }
        }


    </script>
</head>
<body>
    <h3>Enroll Student</h3>
    <form id="form1" runat="server">

        <%--CssClass="validate[required,funcCall[StudentName[]]"--%>

        <div>
            <div>First Name:</div>
            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                ForeColor="Red"
                ControlToValidate="FirstName"
                ValidationGroup="PersonalInfoGroup"
                runat="Server">*
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ForeColor="Red"
                ControlToValidate="FirstName"
                ErrorMessage="Not a Valid Name"
                SetFocusOnError="True" ValidationExpression="^[a-zA-Z]+$"
                ValidationGroup="PersonalInfoGroup" BorderStyle="None" Height="16px"></asp:RegularExpressionValidator>

            <div>Last Name:</div>
            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                ForeColor="Red"
                ControlToValidate="LastName"
                ValidationGroup="PersonalInfoGroup"
                runat="Server">*
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                ForeColor="Red"
                ControlToValidate="LastName"
                ErrorMessage="Not a Valid Name"
                SetFocusOnError="True" ValidationExpression="^[a-zA-Z]+$"
                ValidationGroup="PersonalInfoGroup" BorderStyle="None">
            </asp:RegularExpressionValidator>

            <div>Matric No.:</div>
            <asp:TextBox ID="MatricNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                ForeColor="Red"
                ControlToValidate="MatricNumber"
                ValidationGroup="PersonalInfoGroup"
                runat="Server">*
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                ForeColor="Red"
                ControlToValidate="MatricNumber"
                ErrorMessage="Not a Valid Matric Number"
                SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                ValidationGroup="PersonalInfoGroup" BorderStyle="None">
            </asp:RegularExpressionValidator>

            <div>Email Address:</div>
            <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="EmailAddress"
                ForeColor="Red"
                runat="server" ToolTip="E-mail is required."
                ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                ForeColor="Red"
                ControlToValidate="EmailAddress"
                ErrorMessage="Not a Valid Email Address"
                SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ValidationGroup="PersonalInfoGroup"></asp:RegularExpressionValidator>

            <div>Birthday: </div>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <asp:TextBox ID="Birthday" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1"
                TargetControlID="Birthday"
                Format="yyyy/MM/dd"
                PopupPosition="Right"
                runat="server">
            </asp:CalendarExtender>
            <asp:RequiredFieldValidator ControlToValidate="Birthday"
                ForeColor="Red"
                ID="RequiredFieldValidator5" runat="server" ToolTip="Please choose your birthday."
                ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                ForeColor="Red"
                ControlToValidate="Birthday"
                ErrorMessage="Not a Valid Birthday"
                SetFocusOnError="True" ValidationExpression="\d{4}/((0\d)|(1[012]))/(([012]\d)|3[01])*"
                ValidationGroup="PersonalInfoGroup">
            </asp:RegularExpressionValidator>


            <asp:Label ID="checkDate" runat="server"></asp:Label>




            <div>Gender:</div>
            <asp:DropDownList ID="Gender" runat="server">
                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ControlToValidate="Gender"
                ForeColor="Red"
                ID="RequiredFieldValidator6" runat="server" ToolTip="Please choose student gender."
                ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>


            <div>Year of Study:</div>
            <asp:DropDownList ID="YearOfStudy" runat="server">
                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                <asp:ListItem Text="First Year" Value="First"></asp:ListItem>
                <asp:ListItem Text="Second Year" Value="Second"></asp:ListItem>
                <asp:ListItem Text="Third Year" Value="Third"></asp:ListItem>
                <asp:ListItem Text="Final Year" Value="Final"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ControlToValidate="YearOfStudy"
                ForeColor="Red"
                ID="RequiredFieldValidator7" runat="server" ToolTip="Please choose the study year of student."
                ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>

            <div>School Name:</div>
            <asp:DropDownList ID="SchoolName" runat="server">
                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                <asp:ListItem Text="Computer Science" Value="ComputerScience"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ControlToValidate="SchoolName"
                ForeColor="Red"
                ID="RequiredFieldValidator8" runat="server" ToolTip="Please choose the school Name."
                ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>



            <div id="submit">
                <asp:Button ID="Register" runat="server" Text="Register" ValidationGroup="PersonalInfoGroup" CausesValidation="true" OnClick="Add_Click" />
                <asp:Button ID="Reset" runat="server" Text="Reset" OnClientClick="reset()" />
                <asp:Button ID="Refash" runat="server" Text="Refash Record" CauseValidation="False" OnClick="RefashRecord" />
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


                    <asp:TemplateField HeaderText="FirstName">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server"
                                Text='<%# Bind("FirstName")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="tbFirstName"
                                ForeColor="Red"
                                ID="RequiredFieldValidator9" runat="server" ToolTip="Please choose the school Name."
                                ValidationGroup="PersonalInfoGroup2">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                ForeColor="Red"
                                ControlToValidate="tbFirstName"
                                ErrorMessage="Not a Valid Name"
                                SetFocusOnError="True" ValidationExpression="^[a-zA-Z]+$"
                                ValidationGroup="PersonalInfoGroup2" BorderStyle="None">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="LastName">
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server"
                                Text='<%# Bind("LastName")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="tbLastName"
                                ForeColor="Red"
                                ID="RequiredFieldValidatorLastName" runat="server" ToolTip="Please choose the school Name."
                                ValidationGroup="PersonalInfoGroup2">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLastName" runat="server"
                                ForeColor="Red"
                                ControlToValidate="tbLastName"
                                ErrorMessage="Not a Valid Name"
                                SetFocusOnError="True" ValidationExpression="^[a-zA-Z]+$"
                                ValidationGroup="PersonalInfoGroup2" BorderStyle="None">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="EmailAddress">
                        <ItemTemplate>
                            <asp:Label ID="lblEmailAddress" runat="server"
                                Text='<%# Bind("EmailAddress")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbEmailAddress" runat="server" Text='<%# Bind("EmailAddress") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="tbEmailAddress"
                                ForeColor="Red"
                                ID="RequiredFieldValidatorEmailAddress" runat="server" ToolTip="Please choose the school Name."
                                ValidationGroup="PersonalInfoGroup2">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmailAddress" runat="server"
                                ForeColor="Red"
                                ControlToValidate="tbEmailAddress"
                                ErrorMessage="Not a Valid Email Address"
                                SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="PersonalInfoGroup2"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Birthday">
                        <ItemTemplate>
                            <asp:Label ID="lblBirthday" runat="server"
                                Text='<%# Bind("Birthday", "{0:yyyy/MM/dd}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbBirthday" runat="server" Text='<%# Bind("Birthday", "{0:yyyy/MM/dd}") %>'></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2"
                                TargetControlID="tbBirthday"
                                Format="yyyy/MM/dd"
                                PopupPosition="Right"
                                runat="server">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ControlToValidate="tbBirthday"
                                ForeColor="Red"
                                ID="RequiredFieldValidator11" runat="server" ToolTip="Please choose your birthday."
                                ValidationGroup="PersonalInfoGroup2">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                                ForeColor="Red"
                                ControlToValidate="tbBirthday"
                                ErrorMessage="Not a Valid Birthday"
                                SetFocusOnError="True" ValidationExpression="\d{4}/((0\d)|(1[012]))/(([012]\d)|3[01])*"
                                ValidationGroup="PersonalInfoGroup2">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server"
                                Text='<%# Eval("Gender")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlGender" runat="server" Text='<%# Eval("Gender")%>' CssClass="validate[required]">
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
                            <asp:DropDownList ID="ddlYearOfStudy" runat="server" Text='<%# Eval("YearOfStudy")%>' CssClass="validate[required]">
                                <asp:ListItem Text="First Year" Value="First Year"></asp:ListItem>
                                <asp:ListItem Text="Second Year" Value="Second Year"></asp:ListItem>
                                <asp:ListItem Text="Third Year" Value="Third Year"></asp:ListItem>
                                <asp:ListItem Text="Final Year" Value="Final Year"></asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="School Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSchoolName" runat="server"
                                Text='<%# Eval("SchoolName")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="txtSchoolName" Width="40px"
                                runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="EPC">
                        <ItemTemplate>
                            <asp:Label ID="lblEPC" runat="server"
                                Text='<%# Eval("EPC")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="txtEPC" Width="40px"
                                runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Register Course">
                        <ItemTemplate>
                            <asp:Button ID="RegisterCourse" Text="Register Course" runat="server" CauseValidation="False" OnClick="RegisterCourse_Click" />
                        </ItemTemplate>

                    </asp:TemplateField>


                    <asp:CommandField HeaderText="Edit" ShowEditButton="True"
                        ValidationGroup="PersonalInfoGroup2" CausesValidation="true" />
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

            <asp:Button ID="Finish" runat="server" OnClick="Finish_Click" CausesValidation="false" Text="Finish Registration" />
            
        </div>
    </form>
</body>
</html>
