<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calenderevent.aspx.cs" Inherits="calenderevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calendar Event</title>
    <link href="CalendarStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Calendar ID="Calendar1" runat="server" AutoPostBack="True" OnSelectionChanged="Calendar1_SelectionChanged" CssClass="result"></asp:Calendar>
        <asp:Label ID="showevent" runat="server" Text="" CssClass="result"></asp:Label>
    </div>
    </form>
</body>
</html>
