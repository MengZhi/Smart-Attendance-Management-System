<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAttendance.aspx.cs" Inherits="Version20140107.Account.StudentAttInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="courseCode">Course Code:</div>
                <input type="text"/>
            <div id="date">Date:</div>
                <input type="text"/>
            <input type="button" tabindex="5" value="Search"/>
        </div>
        <div>
            <table border="1">
                <tr><td>No.</td><td>Date</td><td>Time</td><td>Course Code</td><td>Course Name</td><td>Check Detail</td></tr>
                <tr><td>1</td><td>06/09/2013</td><td>09:05:24</td><td>CPT111</td><td>Principles of programming</td><td><input type="button" tabindex="5" value="Check"onclick=" window.location = 'StudentAttentDetail.aspx';"/></td></tr>
                <tr><td>2</td><td>07/09/2013</td><td>09:32:20</td><td>CPT113</td><td>Computer Organization</td><td><input type="button" tabindex="5" value="Check"onclick=" window.location = 'StudentAttentDetail.aspx';"/></td></tr>            
            </table> 

        </div>
    </form>
</body>
</html>