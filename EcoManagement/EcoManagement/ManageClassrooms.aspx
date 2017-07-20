<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageClassrooms.aspx.cs" Inherits="EcoManagement.ManageClassrooms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="ddlBuilding" runat="server" AutoPostBack="True" 
        DataSourceID="edsBuildings" DataTextField="Name" DataValueField="ID" 
        onselectedindexchanged="ddlBuilding_SelectedIndexChanged" 
        ondatabound="ddlBuilding_DataBound">
    </asp:DropDownList>
    <asp:Button ID="btnInsert" runat="server" Text="Insert" onclick="Button1_Click" />
    <asp:GridView ID="gvClassrooms" runat="server" AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" 
        OnRowCommand="GridView1_OnRowCommand1" OnRowEditing="edit" 
        onrowupdating="gvClassrooms_RowUpdating" 
        onrowcancelingedit="gvClassrooms_RowCancelingEdit">
        <Columns>            
            <asp:CommandField ShowEditButton="True" />            
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" Visible="False"/>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvClassroomName" runat="server" 
            ErrorMessage="Forgot to enter the name of the Classroom" ValidationGroup="add" 
            Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="ddlBuildingsEdit" runat="server" DataSourceID="edsBuildings" 
                DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>            
        <br />     
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtClassroomName" runat="server" ValidationGroup="add" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvClassroomName" runat="server" ErrorMessage="Forgot to enter the name of the Classroom" ValidationGroup="add" Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtClassroomName" />
                    <asp:Button ID="btnInsert" runat="Server" Text="Insert" CommandName="Insert" UseSubmitBehavior="False" ValidationGroup="add"/>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BuildingID" HeaderText="BuildingID" 
                SortExpression="BuildingID" Visible="False" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" Visible="False"  />
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblClassroomName" runat="server" Text="Classroom Name:"></asp:Label>
        <asp:TextBox ID="txtClassroomName" runat="server" ValidationGroup="add" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvClassroomName" runat="server" 
            ErrorMessage="Forgot to enter the name of the Classroom" ValidationGroup="add" 
            Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtClassroomName"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="ddlBuildingsEmpty" runat="server" DataSourceID="edsBuildings" 
                DataTextField="Name" DataValueField="ID">
        </asp:DropDownList>            
        <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="add" CommandName="EmptyInsert" UseSubmitBehavior="False"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    <asp:EntityDataSource ID="edsClassrooms" runat="server" 
        ConnectionString="name=EcoManagementEntities" 
        DefaultContainerName="EcoManagementEntities" EnableDelete="True" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Classrooms">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="edsBuildings" runat="server" 
                ConnectionString="name=EcoManagementEntities" 
                DefaultContainerName="EcoManagementEntities" EnableFlattening="False" 
                EntitySetName="Buildings" Select="it.[ID], it.[Name]">
            </asp:EntityDataSource>
</asp:Content>
