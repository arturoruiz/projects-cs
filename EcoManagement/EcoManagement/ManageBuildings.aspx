<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageBuildings.aspx.cs" Inherits="EcoManagement.ManageBuildings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnInsert" runat="server" Text="Insert" onclick="Button1_Click" />
    <asp:GridView ID="gvBuildings" runat="server" AllowPaging="True" 
        AllowSorting="True" DataSourceID="edsBuildings" 
        AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="GridView1_OnRowCommand1">
        <Columns>
            
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" Visible="False"/>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtBuildingName" runat="server" ValidationGroup="add" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBuildingName" runat="server" ErrorMessage="Forgot to enter the name of the Building" ValidationGroup="add" Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtBuildingName" />
                    <asp:Button ID="btnInsert" runat="Server" Text="Insert" CommandName="Insert" UseSubmitBehavior="False" ValidationGroup="add"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" Visible="False"  />
            <asp:CommandField ShowEditButton="True" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you certain you want to delete this product?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblBuildingName" runat="server" Text="Building Name:"></asp:Label>
        <asp:TextBox ID="txtBuildingName" runat="server" ValidationGroup="add" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvBuildingName" runat="server" 
            ErrorMessage="Forgot to enter the name of the Building" ValidationGroup="add" 
            Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtBuildingName"></asp:RequiredFieldValidator>
        <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="add" CommandName="EmptyInsert" UseSubmitBehavior="False"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    <asp:EntityDataSource ID="edsBuildings" runat="server" 
        ConnectionString="name=EcoManagementEntities" 
        DefaultContainerName="EcoManagementEntities" EnableDelete="True" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Buildings">
    </asp:EntityDataSource>
</asp:Content>
