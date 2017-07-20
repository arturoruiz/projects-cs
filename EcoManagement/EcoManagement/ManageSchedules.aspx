<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSchedules.aspx.cs" Inherits="EcoManagement.ManageSchedules" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="jquery.ui.timepicker.css?v=0.2.6" type="text/css" />
<!-- uncomment to test with legacy jquery -->
<!--
    <script type="text/javascript" src="jquery-1.2.6.js"></script>
    <script type="text/javascript" src="jquery.fix.for.1.2.6.js"></script>
    <script type="text/javascript" src="jquery.ui.1.6.all.js"></script>
-->
    <script type="text/javascript" src="include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="include/jquery.ui.position.min.js"></script>
    <script type="text/javascript" src="jquery.ui.timepicker.js?v=0.2.6"></script>
    <script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script>    <script type="text/javascript">
        var tps;
        var tpe;
        
        $(document).ready(function () {
            tps = '#<%=timepicker_start.ClientID %>';
            tpe = '#<%=timepicker_end.ClientID %>';
            $(tps).timepicker({
                showPeriod: true,
                 showLeadingZero: false,
                onHourShow: tpStartOnHourShowCallback,
                onMinuteShow: tpStartOnMinuteShowCallback
            });
            $(tpe).timepicker({
                showPeriod: true,
                showLeadingZero: false,
                onHourShow: tpEndOnHourShowCallback,
                onMinuteShow: tpEndOnMinuteShowCallback
            });
        });

        function tpStartOnHourShowCallback(hour) {
            var tpEndHour = $(tpe).timepicker('getHour');
            // Check if proposed hour is prior or equal to selected end time hour
            if (hour <= tpEndHour) { return true; }
            // if hour did not match, it can not be selected
            return false;
        }
        function tpStartOnMinuteShowCallback(hour, minute) {
            var tpEndHour = $(tpe).timepicker('getHour');
            var tpEndMinute = $(tpe).timepicker('getMinute');
            // Check if proposed hour is prior to selected end time hour
            if (hour < tpEndHour) { return true; }
            // Check if proposed hour is equal to selected end time hour and minutes is prior
            if ((hour == tpEndHour) && (minute < tpEndMinute)) { return true; }
            // if minute did not match, it can not be selected
            return false;
        }

        function tpEndOnHourShowCallback(hour) {
            var tpStartHour = $(tps).timepicker('getHour');
            // Check if proposed hour is after or equal to selected start time hour
            if (hour >= tpStartHour) { return true; }
            // if hour did not match, it can not be selected
            return false;
        }
        function tpEndOnMinuteShowCallback(hour, minute) {
            var tpStartHour = $(tps).timepicker('getHour');
            var tpStartMinute = $(tps).timepicker('getMinute');
            // Check if proposed hour is after selected start time hour
            if (hour > tpStartHour) { return true; }
            // Check if proposed hour is equal to selected start time hour and minutes is after
            if ((hour == tpStartHour) && (minute > tpStartMinute)) { return true; }
            // if minute did not match, it can not be selected
            return false;
        }
    </script>
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
    <asp:GridView ID="gvSchedules" runat="server" AllowPaging="True" 
        AllowSorting="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" 
        OnRowCommand="GridView1_OnRowCommand1" OnRowEditing="edit" 
        onrowdatabound="gvSchedules_RowDataBound" 
        onrowdeleting="gvSchedules_RowDeleting" 
         >
        <Columns> 
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbtnDelete" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you certain you want to delete this entry?');"></asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" Visible="False"/>
            <asp:TemplateField HeaderText="Reason" SortExpression="Reason">
                <ItemTemplate>
                    <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>                    
                </ItemTemplate>
                
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PowerOn" SortExpression="PowerOn">
                <ItemTemplate>
                    <asp:Label ID="lblPoweredOn" runat="server" Text='<%# Bind("PowerOn") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PowerDown" SortExpression="PowerDown">
                <ItemTemplate>
                    <asp:Label ID="lblPowerDown" runat="server" Text='<%# Bind("PowerDown") %>'></asp:Label>                    
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DayOfTheWeek" SortExpression="DayOfTheWeek">
                <ItemTemplate>
                    <asp:Label ID="lblDayOfTheWeek" runat="server" 
                        Text='<%# Bind("DayOfTheWeek") %>'></asp:Label>                        
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ClassroomID" SortExpression="ClassroomID">
                <ItemTemplate>
                    <asp:Label ID="lblClassroomID" runat="server" Text='<%# Bind("ClassroomID") %>'></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" Visible="False"  />
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
               <asp:Label ID="lblReason" runat="server" Text="Reason:"></asp:Label>
               <asp:TextBox ID="txtReason" runat="server" ValidationGroup="add" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReason" runat="server" 
                    ErrorMessage="Forgot to enter the Reason" ValidationGroup="add" 
                    Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="txtReason"></asp:RequiredFieldValidator>
                <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
                <asp:TextBox ID="timepicker_start" Value="8:00" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="To:"></asp:Label>
                <asp:TextBox ID="timepicker_end" value="10:00" runat="server"></asp:TextBox>           
                <asp:Label ID="Label3" runat="server" Text="On:"></asp:Label>    
                <asp:DropDownList ID="ddlDayOfTheWeek" runat="server">
                                <asp:ListItem>Monday</asp:ListItem>
                                <asp:ListItem>Tuesday</asp:ListItem>
                                <asp:ListItem>Wednesday</asp:ListItem>
                                <asp:ListItem>Thursday</asp:ListItem>
                                <asp:ListItem>Friday</asp:ListItem>
                                <asp:ListItem>Saturday</asp:ListItem>
                                <asp:ListItem>Sunday</asp:ListItem>
                            </asp:DropDownList>
                <div id="divClassroom" runat="server" visible="false">
                    <asp:Label ID="lbl" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lblClassRoomEdit" runat="server" Text="Classroom:"></asp:Label>
                    <asp:DropDownList ID="ddlClassroomEdit" runat="server" DataTextField="Name" 
                    DataValueField="ID">
                     </asp:DropDownList>
                </div>                    
            
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="add" 
                    CommandName="EmptyInsert" UseSubmitBehavior="False" onclick="btnSave_Click"/>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
        
            </div>
            </asp:Content>
