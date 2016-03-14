<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentMovement.aspx.cs" Inherits="Version20140107.Account.StudentAttentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>Course Code:<span>CPT111</span></div>
        <div>Date:<span>06/09/2013</span></div>
        <div>
            <table border="1">
                <tr><td>No.</td><td>Matric No.</td><td>Student Name</td><td>Come Time</td><td>Leave Time</td><td>Status</td></tr>
                <tr><td>1</td><td>109578</td><td>Zhi Meng</td><td>09:05:24</td><td>10:03:24</td><td>Attended</td></tr>
                            
            </table> 
        <div><input type="button" tabindex="5" value="Back"onclick=" window.location = 'StudentAttInfo.aspx';" /></div>

        </div>
    </div>
    </form>
</body>
</html>