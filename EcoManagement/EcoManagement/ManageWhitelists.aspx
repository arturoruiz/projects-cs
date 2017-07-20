<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageWhitelists.aspx.cs" Inherits="EcoManagement.ManageWhitelists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="js/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="js/jquery.ui.core.js" type="text/javascript"></script>
    <link href="include/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="include/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

	$(function() {
	    var dates = $("#<%=from.ClientID %>, #<%=to.ClientID %>").datepicker({
			defaultDate: "+1w",
			changeMonth: true,
			numberOfMonths: 3,
			onSelect: function( selectedDate ) {
			    var option = this.id == "<%=from.ClientID %>" ? "minDate" : "maxDate",
					instance = $( this ).data( "datepicker" ),
					date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings );
				dates.not( this ).datepicker( "option", option, date );
			}
		});
	});
	

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="btnInsert" runat="server" Text="Insert" onclick="Button1_Click" />
    <asp:GridView ID="gvWhitelists" runat="server" AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" 
        OnRowCommand="GridView1_OnRowCommand1" OnRowEditing="edit" 
        onrowdatabound="gvWhitelists_RowDataBound" 
        onrowdeleting="gvWhitelists_RowDeleting" 
         >
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" Visible="False" />
            <asp:TemplateField HeaderText="Reason" SortExpression="Reason">
                <ItemTemplate>
                    <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start" SortExpression="Start">
                <ItemTemplate>
                    <asp:Label ID="lblStart" runat="server" Text='<%# Bind("Start") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="End" SortExpression="End">
                <ItemTemplate>
                    <asp:Label ID="lblEnd" runat="server" Text='<%# Bind("End") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CreatedBy" SortExpression="CreatedBy">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" Visible="False" />
        </Columns>
        <EmptyDataTemplate>
            <asp:Label ID="lblEmpty" runat="server" Text="Add a new Schedule by clicking the Insert Button"></asp:Label>           
         </EmptyDataTemplate>
    </asp:GridView>
    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    <asp:EntityDataSource ID="edsBuildings" runat="server" 
                ConnectionString="name=EcoManagementEntities" 
                DefaultContainerName="EcoManagementEntities" EnableFlattening="False" 
                EntitySetName="Buildings" Select="it.[ID], it.[Name]">
            </asp:EntityDataSource>
            <div id="divForm" runat="server" visible="false">
               <asp:Label ID="Label4" runat="server" Text="Building:"></asp:Label>
               <asp:DropDownList ID="ddlBuilding" runat="server" AutoPostBack="True" 
                DataSourceID="edsBuildings" DataTextField="Name" DataValueField="ID" 
                onselectedindexchanged="ddlBuilding_SelectedIndexChanged" 
                ondatabound="ddlBuilding_DataBound">
            </asp:DropDownList>
            <asp:Label ID="Label5" runat="server" Text="Classroom:"></asp:Label>
            <asp:DropDownList ID="ddlClassroom" runat="server" DataTextField="Name" 
                DataValueField="ID" ondatabound="ddlClassroom_DataBound" 
                onselectedindexchanged="ddlClassroom_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
            <asp:Label ID="lblClassRoomEdit" runat="server" Text="Workstation:"></asp:Label>
                    <asp:DropDownList ID="ddlWorkstation" runat="server" DataTextField="Name" 
                    DataValueField="ID" ></asp:DropDownList>
               <br />
               <asp:Label ID="lblReason" runat="server" Text="Reason:"></asp:Label>
               <asp:TextBox ID="txtReason" runat="server" ValidationGroup="add" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReason" runat="server" 
                    ErrorMessage="Forgot to enter the Reason" ValidationGroup="add" 
                    Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtReason"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
                <asp:TextBox ID="from" Value="8:00" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="To:"></asp:Label>
                <asp:TextBox ID="to" value="10:00" runat="server"></asp:TextBox>           
                <asp:Label ID="Label3" runat="server" Text="On:"></asp:Label>    
                
                <div id="divWhitelist" runat="server" visible="false">
                    <asp:Label ID="lbl" runat="server" Text="" Visible="false"></asp:Label>
                    
                     
                </div>                    
            
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="add" 
                    CommandName="EmptyInsert" UseSubmitBehavior="False" onclick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
        
            </div>
            

</asp:Content>
