﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetClassTime.aspx.cs" Inherits="Version20140107.Account.SetClassTime" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<%@ Register TagPrefix="atv" Namespace="AdamTibi.Web.UI.Validators" Assembly="AdamTibi.Web.UI.Validators" %>--%>
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
        function clientvalidate() {

            if (document.getElementById("StartTimeHH").value == "0" ||
            document.getElementById("StartTimeMM").value == "0") {

                document.getElementById('checkStatus').value = "";
            }
            else
                document.getElementById('checkStatus').value = "@";
        }
        function reset() {
            //document.getElementById('FirstName').value = '';
            var hello = 2;
            document.getElementById('Semester').value = "";
            document.getElementById('TeachingYear').value = "";
            document.getElementById('BuildingNumber').value = "";
            document.getElementById('RoomNumber').value = "";
            document.getElementById('StartTimeHH').value = "";
            document.getElementById('StartTimeMM').value = "";
            document.getElementById('EndTimeHH').value = "";
            document.getElementById('EndTimeMM').value = "";
            document.getElementById('ClassDate').value = "";

        }

        function DateFormat(field, rules, i, options) {
            //var regex = /^[a-zA-Z ]+$/;
            var regex = /^[0-9]{4}[\/\-](0[1-9]|1[0-2])[\/\-](0[1-9]|[1-2][0-9]|3[0-1])$/;
            if (!regex.test(field.val())) {
                return "Please enter date in yyyy/MM/dd format."
            }
        }

    </script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    //Dropdownlist Selectedchange event
        //    $('#ClassDate1').change(function () {
        //        // Get Dropdownlist seleted item text
        //        $("#Label1").text($("#ClassDate1 option：").text());
        //        // Get Dropdownlist selected item value
        //        //$("#lblid").text($("#BuildingNumber").val());
        //        return false;
        //    })
        //});
        function classDateInfoFun() {
            
            var datefrom = document.getElementById("ClassDate1").value;
            var dateto = document.getElementById("ClassDate2").value;
            var buildingnumber = document.getElementById("BuildingNumber");
            var buildingnumberitem = buildingnumber.options[buildingnumber.selectedIndex].textContent;
            var roomnumber = document.getElementById("RoomNumber");
            var roomnumberitem = roomnumber.options[roomnumber.selectedIndex].textContent;

            var starttimehh = document.getElementById("StartTimeHH");
            var starttimehhitem = starttimehh.options[starttimehh.selectedIndex].textContent;

            var starttimemm = document.getElementById("StartTimeMM");
            var starttimemmitem = starttimemm.options[starttimemm.selectedIndex].textContent;

            var endtimehh = document.getElementById("EndTimeHH");
            var endtimehhitem = endtimehh.options[endtimehh.selectedIndex].textContent;

            var endtimemm = document.getElementById("EndTimeMM");
            var endtimemmitem = endtimemm.options[endtimemm.selectedIndex].textContent;

            var starttime = starttimehhitem + ":" + starttimemmitem;
            var endtime = endtimehhitem + ":" + endtimemmitem;

            var daynumber = new Date(datefrom);
            var weekday = new Array(7);
            weekday[0] = "Sunday";
            weekday[1] = "Monday";
            weekday[2] = "Tuesday";
            weekday[3] = "Wednesday";
            weekday[4] = "Thursday";
            weekday[5] = "Friday";
            weekday[6] = "Saturday";
            var n = weekday[daynumber.getDay()];           
            document.getElementById("ClassDateInfo").textContent
            var dateinfo = "The class will be set from " + datefrom + " to " + dateto + " every " + n;
            var information="Building Number: "+buildingnumberitem+"\n"+"Room Number: "+roomnumberitem+"\n"+"Start Time: "+starttime+"\n"+ "End Time: "+endtime+"\n"+dateinfo;
            
            var retVal = confirm(information);
            if (retVal == true) {               
                return true;
            } else {
                return false;
            }
        }
    </script>

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
                Teaching Year:<%=Session["TeachingYear"] %>
            </div>
            <div>
                Semester:<%=Session["Semester"] %>
            </div>
            
            <div>
                Building Number:
                
                <asp:DropDownList ID="BuildingNumber" runat="server">
                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                    <asp:ListItem Text="G31" Value="G31"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="BuildingNumber"
                    ForeColor="Red"
                    ID="RequiredFieldValidator1" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
            </div>

            <div>
                Room Number:
                <asp:DropDownList ID="RoomNumber" runat="server">
                    <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                    <asp:ListItem Text="DKG31" Value="DKG31"></asp:ListItem>
                    <asp:ListItem Text="AV Room" Value="AVRoom"></asp:ListItem>
                    <asp:ListItem Text="ELL" Value="ELL"></asp:ListItem>
                    <asp:ListItem Text="Lab1" Value="Lab1"></asp:ListItem>
                    <asp:ListItem Text="Lab2" Value="Lab2"></asp:ListItem>
                    <asp:ListItem Text="Lab3" Value="Lab3"></asp:ListItem>
                    <asp:ListItem Text="Lab4" Value="Lab4"></asp:ListItem>
                    <asp:ListItem Text="Lab5" Value="Lab5"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ControlToValidate="RoomNumber"
                    ForeColor="Red"
                    ID="RequiredFieldValidator2" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
            </div>

            <div>
                Start Time:                
                <asp:DropDownList ID="StartTimeHH" runat="server">
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
                </asp:DropDownList>:   
                <asp:RequiredFieldValidator ControlToValidate="StartTimeHH"
                    ForeColor="Red"
                    ID="RequiredFieldValidator6" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
                <%--<asp:RequiredFieldValidator ControlToValidate="TimeStartHH"
                    ForeColor="Red"
                    ID="RequiredFieldValidator3" runat="server"
                    ValidationGroup="PersonalInfoGroup"></asp:RequiredFieldValidator>--%>

                <asp:DropDownList ID="StartTimeMM" runat="server">
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
                <asp:RequiredFieldValidator ControlToValidate="StartTimeMM"
                    ForeColor="Red"
                    ID="RequiredFieldValidator7" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
                <%-- <asp:Label ID="checkStatus" runat="server" Text="hello"></asp:Label>--%>
                <%--<atv:multiplefieldsvalidator id="mfv" runat="server" condition="OR"
                    controlstovalidate="TimeStartHH,TimeStartMM">*</atv:multiplefieldsvalidator>--%>
                <%--<asp:RequiredFieldValidator ControlToValidate="TimeStartMM,TimeStartHH"
                    ForeColor="Red" Condition="OR"
                    ID="RequiredFieldValidator6" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>--%>
            </div>

            <div>
                End Time:                
                <asp:DropDownList ID="EndTimeHH" runat="server">
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
                </asp:DropDownList>:   
                <asp:RequiredFieldValidator ControlToValidate="EndTimeHH"
                    ForeColor="Red"
                    ID="RequiredFieldValidator8" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
                <%--<asp:RequiredFieldValidator ControlToValidate="TimeStartHH"
                    ForeColor="Red"
                    ID="RequiredFieldValidator3" runat="server"
                    ValidationGroup="PersonalInfoGroup"></asp:RequiredFieldValidator>--%>

                <asp:DropDownList ID="EndTimeMM" runat="server">
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
                <asp:RequiredFieldValidator ControlToValidate="EndTimeMM"
                    ForeColor="Red"
                    ID="RequiredFieldValidator9" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
                 
                <%--<atv:multiplefieldsvalidator id="mfv" runat="server" condition="OR"
                    controlstovalidate="TimeStartHH,TimeStartMM">*</atv:multiplefieldsvalidator>--%>
                <%--<asp:RequiredFieldValidator ControlToValidate="TimeStartMM,TimeStartHH"
                    ForeColor="Red" Condition="OR"
                    ID="RequiredFieldValidator6" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>--%>
            </div>

            <div>
                Class Date From:
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                <asp:TextBox ID="ClassDate1" runat="server" ></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="CalendarExtender1"
                    TargetControlID="ClassDate1"
                    Format="yyyy/MM/dd"
                    PopupPosition="Right">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ControlToValidate="ClassDate1"
                    ForeColor="Red"
                    ID="RequiredFieldValidator5" runat="server"
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                    ForeColor="Red"
                    ControlToValidate="ClassDate1"
                    ErrorMessage="Not a Valid Class Date"
                    SetFocusOnError="True" ValidationExpression="\d{4}/((0\d)|(1[012]))/(([012]\d)|3[01])*"
                    ValidationGroup="PersonalInfoGroup">
                </asp:RegularExpressionValidator>
            </div>

            <div>
                Class Date To:
                
                <asp:TextBox ID="ClassDate2" runat="server"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="CalendarExtender3"
                    TargetControlID="ClassDate2"
                    Format="yyyy/MM/dd"
                    PopupPosition="Right">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ControlToValidate="ClassDate2"
                    ForeColor="Red"
                    ID="RequiredFieldValidator3" runat="server" ToolTip="Please choose your birthday."
                    ValidationGroup="PersonalInfoGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorClassDate2" runat="server"
                    ForeColor="Red"
                    ControlToValidate="ClassDate2"
                    ErrorMessage="Not a Valid Class Date"
                    SetFocusOnError="True" ValidationExpression="\d{4}/((0\d)|(1[012]))/(([012]\d)|3[01])*"
                    ValidationGroup="PersonalInfoGroup">
                </asp:RegularExpressionValidator>
            </div>

            <asp:Label ID="ClassDateInfo" runat="server" Text=""></asp:Label>

            <div>
                <asp:Button ID="Set" Text="Set" runat="server" ValidationGroup="PersonalInfoGroup"
                    CausesValidation="true" OnClick="Set_Click" OnClientClick="return  classDateInfoFun()"/>

                <asp:Button ID="FinishSetting" Text="Finish" runat="server" OnClick="FinishSetting_Click" />
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
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="text-align: center">
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

                        <%--<asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lblClassId" runat="server"
                                    Text='<%# Eval("ClassId")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="txtCourseTimeInfoId" Width="40px"
                                    runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>--%>

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




                        <asp:TemplateField HeaderText="Class Date">
                            <ItemTemplate>
                                <asp:Label ID="lblClassDate" runat="server"
                                    Text='<%# Bind("ClassDate", "{0:yyyy/MM/dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="tbClassDate" runat="server" Text='<%# Bind("ClassDate", "{0:yyyy/MM/dd}") %>'></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2"
                                    TargetControlID="tbClassDate"
                                    Format="yyyy/MM/dd"
                                    PopupPosition="Right"
                                    runat="server">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ControlToValidate="tbClassDate"
                                    ForeColor="Red"
                                    ID="RequiredFieldValidatorClassDate" runat="server" ToolTip="Please choose your birthday."
                                    ValidationGroup="PersonalInfoGroup2">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorBirthday" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="tbClassDate"
                                    ErrorMessage="Not a Valid Birthday"
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
                                <asp:DropDownList ID="ddlStartTime1" runat="server">
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
                                    ValidationGroup="PersonalInfoGroup2"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartTime1" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlStartTime1"
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup2" BorderStyle="None">*
                                </asp:RegularExpressionValidator>

                                <asp:DropDownList ID="ddlStartTime2" runat="server" CssClass="validate[required,custom[integer]]">
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
                                    ValidationGroup="PersonalInfoGroup2"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlStartTime2"
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup2" BorderStyle="None">*
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
                                    ValidationGroup="PersonalInfoGroup2"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndTime1" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlEndTime1"
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup2" BorderStyle="None">*
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
                                    ValidationGroup="PersonalInfoGroup2"
                                    runat="Server">*
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndTime2" runat="server"
                                    ForeColor="Red"
                                    ControlToValidate="ddlEndTime2"
                                    SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                    ValidationGroup="PersonalInfoGroup2" BorderStyle="None">*
                                </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" ValidationGroup="PersonalInfoGroup2" CausesValidation="true" />
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
