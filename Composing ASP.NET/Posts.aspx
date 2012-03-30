<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="Composing_ASP.NET.Post" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Blog - <asp:Literal ID="PageTitle" runat="server"></asp:Literal></title>
</head>
<body>
    <h1>My Blog</h1>
    <h2>All posts</h2>
    <form id="form1" runat="server">
    <asp:GridView runat="server" ID="postsGridView" DataSourceID="postsDataSource" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowEditButton="True"/>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="PublicationDate" HeaderText="Date Published" SortExpression="PublicationDate" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="postsDataSource" runat="server" DataObjectTypeName="Composing_ASP.NET_Presentation_Logic.IndividualPostPresenter" 
    SelectMethod="SelectAll" TypeName="Composing_ASP.NET.PostsDataSource" UpdateMethod="Update"></asp:ObjectDataSource>
    </form>
</body>
</html>
