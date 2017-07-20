<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBuilding.aspx.cs" Inherits="Capstone.AddBuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="lblBuildingName" runat="server" Text="Building Name:"></asp:Label>
        <asp:TextBox ID="txtBuildingName" runat="server" ValidationGroup="add" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvBuildingName" runat="server" 
            ErrorMessage="Forgot to enter the name of the Building" ValidationGroup="add" 
            Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtBuildingName"></asp:RequiredFieldValidator>
    </asp:Panel>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" ValidationGroup="add" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</asp:Content>
