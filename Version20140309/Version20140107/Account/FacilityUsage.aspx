<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacilityUsage.aspx.cs" Inherits="Version20140107.Account.FacilityUsage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <h1>Situation of Facilities Usage</h1>
        </div>
        <div id="courseCode">Date:</div><input type="text"/>
        <div id="time">Date:</div><input type="text"/>
        <div>
            <input type="button" tabindex="5" value="Set"onclick=""/>
        </div>
        <div>
            <input type="button" tabindex="5" value="Current"onclick=""/>
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        </div>




    </div>
    </form>
</body>
</html>