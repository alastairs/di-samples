<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="Composing_ASP.NET.Post" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Blog - <asp:Literal ID="PageTitle" runat="server"></asp:Literal></title>
</head>
<body>
    <h1>My Blog</h1>
    <h2><asp:Literal ID="PostTitle" runat="server"></asp:Literal></h2>
    <div><asp:Literal ID="Summary" runat="server"></asp:Literal></div>
    <div><asp:Literal ID="Body" runat="server"></asp:Literal></div>
</body>
</html>
