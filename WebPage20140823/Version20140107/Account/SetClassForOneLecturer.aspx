<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetClassForOneLecturer.aspx.cs" Inherits="Version20140107.Account.SetClassForOneLecturer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSSFile/Login.css" rel="stylesheet" type="text/css" />
    <%--<link href="../CSSFile/templatemo_style.css" rel="stylesheet" type="text/css" />
    <link href="../CSSFile/layout.css" rel="stylesheet" type="text/css" />
    <link href="../CSSFile/ValidationEngine.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/languages/jquery.validationEngine-en.js"
        charset="utf-8"></script>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/jquery.validationEngine.js"
        charset="utf-8">
    </script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });

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

        function StaffName(field, rules, i, options) {
            var regex = /^[a-zA-Z ]+$/;
            if (!regex.test(field.val())) {
                return "Please enter a valid staff name."
            }
        }


        function DateFormat(field, rules, i, options) {
            //var regex = /^[a-zA-Z ]+$/;
            var regex = /^[0-9]{4}[\/\-](0[1-9]|1[0-2])[\/\-](0[1-9]|[1-2][0-9]|3[0-1])$/;
            if (!regex.test(field.val())) {
                return "Please enter date in yyyy/MM/dd format."
            }
        }
    </script>
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
                        <asp:BoundField DataField="TeachingYear" HeaderText="Teaching Year" />
                        <asp:BoundField DataField="Semester" HeaderText="Semester" />

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
                    OnPageIndexChanging="GridView2_PageIndexChanging"
                    OnRowDeleting="GridView2_RowDeleting"
                    OnRowEditing="GridView2_RowEditing"
                    OnRowUpdating="GridView2_RowUpdating"
                    OnRowDataBound="GridView2_RowDataBound"
                    OnRowCancelingEdit="GridView2_RowCancelingEdit"
                    OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
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
                                <asp:Label ID="lblClassId" runat="server"
                                    Text='<%# Eval("ClassId")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtClassId" Width="40px"
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

                        <asp:TemplateField HeaderText="TeachingYear">
                            <ItemTemplate>
                                <asp:Label ID="lblTeachingYear" runat="server"
                                    Text='<%# Eval("TeachingYear")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlTeachingYear" runat="server" Text='<%# Eval("TeachingYear")%>'>
                                    <asp:ListItem Text="2013/2014" Value="2013/2014"></asp:ListItem>
                                    <asp:ListItem Text="2014/2015" Value="2014/2015"></asp:ListItem>
                                    <asp:ListItem Text="2015/2016" Value="2015/2016"></asp:ListItem>
                                    <asp:ListItem Text="2016/2017" Value="2016/2017"></asp:ListItem>
                                    <asp:ListItem Text="2017/2018" Value="2017/2018"></asp:ListItem>
                                    <asp:ListItem Text="2018/2019" Value="2018/2019"></asp:ListItem>
                                    <asp:ListItem Text="2019/2020" Value="2019/2020"></asp:ListItem>
                                    <asp:ListItem Text="2020/2021" Value="2020/2021"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Building Number">
                            <ItemTemplate>
                                <asp:Label ID="lblBuildingNumber" runat="server"
                                    Text='<%# Eval("BuildingNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlBuildingNumber" runat="server" Text='<%# Eval("BuildingNumber")%>'>
                                    <asp:ListItem Text="G31" Value="G31"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="RoomNumber">
                            <ItemTemplate>
                                <asp:Label ID="lblRoomNumber" runat="server"
                                    Text='<%# Eval("RoomNumber")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRoomNumber" runat="server" Text='<%# Eval("RoomNumber")%>'>
                                    <asp:ListItem Text="DKG31" Value="DKG31"></asp:ListItem>
                                    <asp:ListItem Text="AV Room" Value="AVRoom"></asp:ListItem>
                                    <asp:ListItem Text="ELL" Value="ELL"></asp:ListItem>
                                    <asp:ListItem Text="Lab1" Value="Lab1"></asp:ListItem>
                                    <asp:ListItem Text="Lab2" Value="Lab2"></asp:ListItem>
                                    <asp:ListItem Text="Lab3" Value="Lab3"></asp:ListItem>
                                    <asp:ListItem Text="Lab4" Value="Lab4"></asp:ListItem>
                                    <asp:ListItem Text="Lab5" Value="Lab5"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

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

                        <asp:TemplateField HeaderText="Class Date">
                            <ItemTemplate>
                                <asp:Label ID="lblClassDate" runat="server"
                                    Text='<%# Bind("ClassDate", "{0:yyyy/MM/dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                                <asp:TextBox ID="tbClassDate" runat="server" Text='<%# Bind("ClassDate", "{0:yyyy/MM/dd}") %>'></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2"
                                    TargetControlID="tbClassDate"
                                    Format="yyyy/MM/dd"
                                    PopupPosition="Right"
                                    runat="server">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ControlToValidate="tbClassDate"
                                    ForeColor="Red"
                                    ID="RequiredFieldValidatorClassDate" runat="server" 
                                    ValidationGroup="PersonalInfoGroup2">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorClassDate" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="tbClassDate"
                                    ErrorMessage="Not a Valid Class Date"
                                    SetFocusOnError="True" ValidationExpression="\d{4}/((0\d)|(1[012]))/(([012]\d)|3[01])*"
                                    ValidationGroup="PersonalInfoGroup2">
                                </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Start Time">
                            <ItemTemplate>
                                <asp:Label ID="lblStartTime" runat="server"
                                    Text='<%# Eval("StartTime")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlStartTime1" runat="server" >
                                    <asp:ListItem Text="HH" Value=""></asp:ListItem>
                                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStartTime1"
                                    ForeColor="Red"
                                    ControlToValidate="ddlStartTime1"
                                    ValidationGroup="PersonalInfoGroup"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartTime1" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlStartTime1"
                                    
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup" BorderStyle="None">*
                                </asp:RegularExpressionValidator>

                                <asp:DropDownList ID="ddlStartTime2" runat="server" >
                                    <asp:ListItem Text="MM" Value=""></asp:ListItem>
                                    <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStartTime2"
                                    ForeColor="Red"
                                    ControlToValidate="ddlStartTime2"
                                    ValidationGroup="PersonalInfoGroup"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlStartTime2"
                                    
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup" BorderStyle="None">*
                                </asp:RegularExpressionValidator>

                            </EditItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="End Time">
                            <ItemTemplate>
                                <asp:Label ID="lblEndTime" runat="server"
                                    Text='<%# Eval("EndTime")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEndTime1" runat="server">
                                    <asp:ListItem Text="HH" Value=""></asp:ListItem>
                                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEndTime1"
                                    ForeColor="Red"
                                    ControlToValidate="ddlEndTime1"
                                    ValidationGroup="PersonalInfoGroup"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndTime1" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlEndTime1"
                                    
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup" BorderStyle="None">*
                                </asp:RegularExpressionValidator>

                                <asp:DropDownList ID="ddlEndTime2" runat="server">
                                    <asp:ListItem Text="MM" Value=""></asp:ListItem>
                                    <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEndTime2"
                                    ForeColor="Red"
                                    ControlToValidate="ddlEndTime2"
                                    ValidationGroup="PersonalInfoGroup"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndTime2" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlEndTime2"
                                    
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup" BorderStyle="None">*
                                </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" ValidationGroup="PersonalInfoGroup" CausesValidation="true" />
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
