<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageWorkstations.aspx.cs" Inherits="EcoManagement.ManageWorkstations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:DropDownList ID="ddlBuilding" runat="server" AutoPostBack="True" 
        DataSourceID="edsBuildings" DataTextField="Name" DataValueField="ID" 
        onselectedindexchanged="ddlBuilding_SelectedIndexChanged" 
        ondatabound="ddlBuilding_DataBound">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlClassroom" runat="server" DataTextField="Name" 
        DataValueField="ID" ondatabound="ddlClassroom_DataBound" 
        onselectedindexchanged="ddlClassroom_SelectedIndexChanged" 
        AutoPostBack="True">
    </asp:DropDownList>
    <asp:Button ID="btnInsert" runat="server" Text="Insert" onclick="Button1_Click" />
    <asp:GridView ID="gvWorkstations" runat="server" AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" 
        OnRowCommand="GridView1_OnRowCommand1" OnRowEditing="edit" 
        onrowupdating="gvWorkstations_RowUpdating" 
        onrowcancelingedit="gvWorkstations_RowCancelingEdit" 
        onrowdatabound="gvWorkstations_RowDataBound" onrowdeleting="gvWorkstations_RowDeleting" 
         >
        <Columns> 
        <asp:CommandField ShowEditButton="true" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Delete" 
                        
                        OnClientClick="return confirm('Are you certain you want to delete this workstation?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" Visible="False"/>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>                    
                    <asp:TextBox ID="txtWorkstationName" runat="server" Text='<%# Bind("Name") %>' ValidationGroup="add" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvClassroomName" runat="server" ErrorMessage="Forgot to enter the name of the Workstation" ValidationGroup="add" Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtWorkstationName" />
                    </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtWorkstationName" runat="server" ValidationGroup="add" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvClassroomName" runat="server" ErrorMessage="Forgot to enter the name of the Workstation" ValidationGroup="add" Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtWorkstationName" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MAC_Address" SortExpression="MAC_Address">
                <EditItemTemplate>                    
                    <asp:TextBox ID="txtMACAddress" runat="server" Text='<%# Bind("MAC_Address") %>' ValidationGroup="add" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMAC" runat="server" ErrorMessage="Forgot to enter the MacAddress" ValidationGroup="add" Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtMACAddress" />
                    <asp:RegularExpressionValidator ID="revMAC" runat="server" ErrorMessage="Provide a valid MAC Address" 
                    ValidationExpression="^[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}$" ControlToValidate="txtMACAddress" Font-Bold="True" ForeColor="Red" ValidationGroup="add" >
                    </asp:RegularExpressionValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("MAC_Address") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtMACAddress" runat="server" ValidationGroup="add" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMAC" runat="server" ErrorMessage="Forgot to enter the MacAddress" ValidationGroup="add" Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtMACAddress" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Provide a valid MAC Address" 
                    ValidationExpression="^[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}$" ControlToValidate="txtMACAddress" Font-Bold="True" ForeColor="Red" ValidationGroup="add" >
                    </asp:RegularExpressionValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ClassroomID" HeaderText="ClassroomID" 
                SortExpression="ClassroomID" Visible="False" />
            <asp:BoundField DataField="Admin" HeaderText="Admin" SortExpression="Admin" 
                Visible="False" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" Visible="False"  />
            <asp:BoundField DataField="WhitelistID" HeaderText="WhitelistID" 
                SortExpression="WhitelistID" Visible="False" />
            <asp:TemplateField HeaderText="OSID" SortExpression="OSID">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlOS" runat="server" DataSourceID="edsOS" 
                    DataTextField="OSName" DataValueField="ID">
                    </asp:DropDownList>    
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("OSID") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlOS" runat="server" DataSourceID="edsOS" 
                    DataTextField="OSName" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:Button ID="btnInsert" runat="Server" Text="Insert" CommandName="Insert" UseSubmitBehavior="False" ValidationGroup="add"/>    
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblWorkstationName" runat="server" Text="Workstation Name:"></asp:Label>
        <asp:TextBox ID="txtWorkstationName" runat="server" ValidationGroup="add" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvClassroomName" runat="server" 
            ErrorMessage="Forgot to enter the name of the Workstation" ValidationGroup="add" 
            Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtWorkstationName"></asp:RequiredFieldValidator>
        <asp:Label ID="lblMACAddress" runat="server" Text="MAC Address:"></asp:Label>
        <asp:TextBox ID="txtMAC" runat="server" ValidationGroup="add" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Provide a valid MAC Address" 
            ValidationExpression="^[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}-[0-9A-F]{2}$" ControlToValidate="txtMAC" Font-Bold="True" ForeColor="Red" ValidationGroup="add">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvMacADD" runat="server" 
            ErrorMessage="Provide a MacAddress" ValidationGroup="add" 
            Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtMAC"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="ddlOS" runat="server" DataSourceID="edsOS" 
                DataTextField="OSName" DataValueField="ID">
        </asp:DropDownList>            
            
        <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="add" CommandName="EmptyInsert" UseSubmitBehavior="False"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=EcoManagementEntities" 
        DefaultContainerName="EcoManagementEntities" EnableDelete="True" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Workstations">
    </asp:EntityDataSource>
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
            <asp:EntityDataSource ID="edsOS" runat="server" 
                ConnectionString="name=EcoManagementEntities" 
                DefaultContainerName="EcoManagementEntities" EnableDelete="True" 
                EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
                EntitySetName="OperatingSystems">
            </asp:EntityDataSource>
</asp:Content>
