<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageBuildings.aspx.cs" Inherits="Capstone.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvBuildings" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
        DataSourceID="EntityDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" Visible="False" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddBldg" runat="server" Text="Add" />
    <asp:Button ID="btnOK" runat="server" Text="OK" />
    <asp:EntityDataSource ID="Buildings" runat="server" 
        ConnectionString="name=CapstoneEntities" 
        DefaultContainerName="CapstoneEntities" EnableDelete="True" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Buildings" EntityTypeFilter="Building">
    </asp:EntityDataSource>
</asp:Content>
