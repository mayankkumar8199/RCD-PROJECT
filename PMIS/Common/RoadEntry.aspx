<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="RoadEntry.aspx.cs"  EnableEventValidation="false"  Inherits="RCDPMISNEW_ADM_RoadEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">

        /*The following function(java script) will restrict to assign only numeric value in the text box of phone / mobile number*/

        function validate(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            //            if (charCode > 31 && (charCode < 48 || charCode > 57))
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46) {
                alert("Enter numerals only in this field.");
                return false;
            }
            return true;


        }
    </script>

      <style type="text/css">
    
    .dropdown-icon {
  color: red;
}
                .table table tbody tr td a,


 
                .table table tbody tr td span {
                    position: relative;
                    float: left;
                    padding: 6px 12px;
                    margin-left: -1px;
                    line-height: 1.42857143;
                    color: #337ab7;
                    text-decoration: none;
                    background-color: #fff;
                    border: 1px solid #ddd;
                }

                .table table > tbody > tr > td > span {
                    z-index: 3;
                    color: #fff;
                    cursor: default;
                    background-color: #337ab7;
                    border-color: #337ab7;
                }

                .table table > tbody > tr > td:first-child > a,
                .table table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-top-left-radius: 4px;
                    border-bottom-left-radius: 4px;
                }

                .table table > tbody > tr > td:last-child > a,
                .table table > tbody > tr > td:last-child > span {
                    border-top-right-radius: 4px;
                    border-bottom-right-radius: 4px;
                }



 
                .table table > tbody > tr > td > a:hover,
                .table table > tbody > tr > td > span:hover,
                .table table > tbody > tr > td > a:focus,
                .table table > tbody > tr > td > span:focus {
                    z-index: 2;
                    color: #23527c;
                    background-color: #eee;
                    border-color: #ddd;
                }
            </style>
    <style type="text/css">
        fieldset {
            border: 1px solid #0f2c62;
            border-radius: 3px;
            padding: 10px;
            background-color: White;
        }

        legend {
            background-color: #014e9c;
            color: #fff;
            padding: 3px 6px;
            font-weight: 100;
            text-align: center;
        }

        .grid th {
            background-color: #3393ff;
            color: White;
            border-collapse: collapse;
            padding: 10px;
            border-color: Black;
        }

        .grid tr {
            background-color: White;
            color: Black;
            border-collapse: collapse;
            padding: 10px;
        }

        .grid td {
            text-align: center;
        }

        .grid th:first-child {
            background-color: #3393ff;
            -moz-border-radius-topleft: 14px;
            -webkit-border-top-left-radius: 14px;
            border-top-left-radius: 14px;
            border-collapse: collapse;
            cellpadding: 0px;
            cellspacing: 0px;
        }

        .grid th:last-child {
            background-color: #3393ff;
            -moz-border-radius-topright: 14px;
            -webkit-border-top-right-radius: 14px;
            border-top-right-radius: 14px;
        }

        .grid tr:hover {
            background-color: #EEE5CE;
        }

        .grid tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid tr:hover {
            background-color: #ddd;
        }
    </style>

    <style type="text/css">
        .FormatRadioButtonList label
{
  margin-right: 15px;
}
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%-- <br />--%>
    <div class="container" style=" overflow:scroll;padding-top:12px;">
  
  <div class="panel-group">
    <div class="panel panel-primary">
      <div class="panel-heading" style="text-align:center; font-weight:700; font-size:x-large">Road Statistics</div>
      <div class="panel-body">
          
           <div class="row" >
         <%--   <h3 style="text-align:center;  color:cornflowerblue">Road Statistics</h3>--%>
              <asp:Label ID="lblRoadName" runat="server" Text="" ForeColor="Maroon"></asp:Label>
          <%--  <hr style="border:1px solid grey" />--%>
        </div>
         <asp:Panel ID="PanelDDL" runat="server" Width="1100px">
             <div class="row">
                  <div class="col-md-2 col-xs-12">
                <label>Wings :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
              <asp:DropDownList ID="DDLWings" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLWings_SelectedIndexChanged"  CssClass="form-control">
                                    </asp:DropDownList>
                                    <span id="SpanWings" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select Wings"
                                        ControlToValidate="DDLWings" ValidationGroup="s" ForeColor="red" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
            </div>


                   <div class="col-md-2 col-xs-12">
                <label>Circle :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
              <asp:DropDownList ID="DDLCircle" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DDLCircle_SelectedIndexChanged"  CssClass="form-control">
                                    </asp:DropDownList>
                                    <span id="SpanCircle" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Circle"
                                        ControlToValidate="DDLCircle" ValidationGroup="s" ForeColor="red" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
            </div>
                    <div class="col-md-2 col-xs-12">
                <label>Division :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
              <asp:DropDownList ID="DDLDivision" runat="server"    CssClass="form-control">
                                    </asp:DropDownList>
                                      <span id="SpanDivision" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Division"
                                        ControlToValidate="DDLDivision" ValidationGroup="s" ForeColor="red" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
            </div>
                   <div class="col-md-2 col-xs-12 ">
                <label> Road Name :</label>
            </div> 
            <div class="col-md-10 col-xs-12">
              <asp:TextBox ID="txtRoadName" runat="server"  CssClass="form-control" AutoPostBack="true" OnTextChanged="txtRoadName_TextChanged"></asp:TextBox>
                                    <span id="Span1" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRoadName"
                                        Display="None" ErrorMessage="Please Enter Road Name" ForeColor="red" ValidationGroup="s"></asp:RequiredFieldValidator>
            </div>
                  <div class="col-md-2 col-xs-12">
                <label>Road Type:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
               <asp:DropDownList ID="DDLRoadType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLRoadType_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                    <span id="Span2" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DDLRoadType"
                                        Display="None" ErrorMessage="Please Select Road Type" ForeColor="red" InitialValue="0"
                                        ValidationGroup="s"></asp:RequiredFieldValidator>
            </div>
                  <div class="col-md-2 col-xs-12">
                 <span id="spanSubRoad" runat="server" visible="true">Sub-Road Type </span>
            </div> 
            <div class="col-md-2 col-xs-12">
               <asp:DropDownList ID="DDLSubRoad" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
            </div>

                  <div class="col-md-2 col-xs-12">
                <label> Total Length (in Km):</label>
            </div> 
            <div class="col-md-2 col-xs-12">
             <asp:TextBox ID="txtLength" runat="server"  CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox><span
                                        id="Span3" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Length"
                                        ControlToValidate="txtLength" ValidationGroup="s" ForeColor="red" Display="None"></asp:RequiredFieldValidator>
            </div>
             </div>

         <%--    <div class="row">
                 <div class="col-md-3 col-xs-12">
                     <label>Road Conversion(If Any):</label>
                 </div>
                 <div class="col-md-3 col-xs-12">
                      <asp:RadioButtonList ID="radioyesno"  CssClass="FormatRadioButtonList" runat="server" RepeatDirection="Horizontal"  AutoPostBack="true" OnSelectedIndexChanged="rdbtndebar_SelectedIndexChanged">
                          <asp:ListItem Value="2" Selected="True">No </asp:ListItem>         
                           <asp:ListItem Value="1">Yes &nbsp;&nbsp;</asp:ListItem>
                                    
                                </asp:RadioButtonList><br />
                 </div>
             </div>

             <div class="row">
                 <div class="col-md-3 col-xs-12">
                     <asp:Label ID="lblrcconversionremarks" runat="server" Text="Road Conversion Remarks:" Font-Bold="true" Visible="false"></asp:Label>
                 
                 </div>
                 <div class="col-md-9 col-xs-12">
                     <asp:TextBox ID="txtroadconvremarks" runat="server" CssClass="form-control" Visible="false"></asp:TextBox><br />
                 </div>
             </div>--%>





             </asp:Panel>

        <asp:Panel ID="PanelDDLSearch" runat="server" Visible="false">

        <div class="row">
            <div class="col-md-12 col-xs-12">
                <p style="float:right;"><asp:ImageButton ID="btnBack" runat="server"  OnClick="btnBack_Click" Width="55px"   ImageUrl="~/RCDPMISNEW/images/back_image.png"  /></p>
            </div><br />
            <div class="col-md-2 col-xs-12">
                <label>Wings :</label>
            </div>
            <div class="col-md-2 col-xs-12">
              <asp:DropDownList ID="DDLWings2" runat="server" AutoPostBack= "true" OnSelectedIndexChanged="DDLWings2_SelectedIndexChanged" CssClass="form-control">
                                    </asp:DropDownList>
                                    <span id="Span5" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Select Wings"
                                        ControlToValidate="DDLWings2" ValidationGroup="s" ForeColor="red" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
            </div>

             <div class="col-md-2 col-xs-12">
                <label>Circle  :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
              <asp:DropDownList ID="DDLCircle2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLCircle2_SelectedIndexChanged"  CssClass="form-control">
                                    </asp:DropDownList>
                                    <span id="Span6" runat="server" style="color: Red">*</span>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Select Circle"
                                        ControlToValidate="DDLCircle2" ValidationGroup="s" ForeColor="red" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
            </div>

              <div class="col-md-2 col-xs-12">
                <label> Division   :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
              <asp:DropDownList ID="DDLDivision2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLDivision2_SelectedIndexChanged"  CssClass="form-control">
                                    </asp:DropDownList>
                                    <span id="Span7" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Select Division"
                                        ControlToValidate="DDLDivision2" ValidationGroup="s" ForeColor="red" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
            </div>
            
              <div class="col-md-2 col-xs-12">
                <label> Road Type   :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
              <asp:DropDownList ID="DDLRoadType2" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DDLRoadType2_SelectedIndexChanged"  CssClass="form-control">
                                    </asp:DropDownList>
                                     <span id="Span8" runat="server" style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Select Road Type"
                                        ControlToValidate="DDLRoadType2" ValidationGroup="s" ForeColor="red" InitialValue="0"
                                        Display="None"></asp:RequiredFieldValidator>
               
            </div>
            <div class="col-md-2 col-xs-12">
                  <asp:Button ID="btnView" runat="server" Text="View" Width="80px"  OnClick="btnView_Click" CssClass="btn btn-info" />
                                  
            </div>

        </div>
             </asp:Panel>

         <asp:Panel ID="Panel1" runat="server" GroupingText="Condition of the Road (in Km) "
                        Width="1150px" >
             <div class="row">
                  <div class="col-md-4 col-xs-12">
                <label> GOOD (Pots less than 2% of the total length) :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
               <asp:TextBox ID="txtGood" runat="server"  CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
            </div>
                  <div class="col-md-4 col-xs-12">
                <label>  FAIR (Pots less than 5% of the total length) :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
              <asp:TextBox ID="txtFair" runat="server"  CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
            </div>
                 </div>
             <br />
              <div class="row">
                 <div class="col-md-4 col-xs-12">
                <label>  AVERAGE (Pots between 5% to 15% of the total length):</label>
            </div> 
            <div class="col-sm-2">
               <asp:TextBox ID="txtAverage" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
            </div>
                  <div class="col-md-4 col-xs-12">
                <label>   BAD (Pots more than 15% of the total length):</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                 <asp:TextBox ID="txtBad" runat="server"  CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
            </div>

             </div>

             </asp:Panel>

         <asp:Panel ID="Panel3" runat="server" Width="1100px" Visible="false" GroupingText="National Highways Detail">
             <div class="row">
                  <div class="col-md-2 col-xs-12">
                <label> N.H. No.:</label>
            </div> 
            <div class="col-md-1 col-xs-12">
               <asp:TextBox ID="txtnhno" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
                  <div class="col-md-3 col-xs-12">
                <label>  Starting Point in the Division :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtstartpoint" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
                   <div class="col-md-2 col-xs-12">
                <label>   Terminating Point in the Division :</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtendpoint" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
                 </div>

             <div class="row">
                  <div class="col-md-3 col-xs-12">
                <label>Important Place in the road (with chainage):</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtimportentplace" runat="server"  CssClass="form-control" TextMode="MultiLine"
                                                    Style="resize: none"></asp:TextBox>
            </div>
                  <div class="col-md-2 col-xs-12">
                <label>  Missing Length in Km:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txtmissinglength" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
            </div>
                   <div class="col-md-1 col-xs-12">
                <label>    Remarks:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
               <asp:TextBox ID="txtRemarks" runat="server"  CssClass="form-control" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
            </div>
                 </div>
             </asp:Panel>

         <asp:Panel ID="Panel2" runat="server" GroupingText="Lane Width (m)" Width="1150px">
             <div class="row">
                  <div class="col-md-3 col-xs-12">
                <label> Single Lane 3.75m width Length (Km):</label>
            </div> 
            <div class="col-md-2 col-xs-12">
               <asp:TextBox ID="txtSingleLane" runat="server"  CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
            </div>
                  <div class="col-md-4 col-xs-12">
                <label>   Internediate lane 5.50 m width Length (Km)</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                   <asp:TextBox ID="txtIntermediate" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
            </div>
                   </div>
             <br />
             <div class="row">
                   <div class="col-md-3 col-xs-12">
                <label> 2 lane 7.00m width Length (Km):</label>
            </div> 
            <div class="col-md-2 col-xs-12">
               <asp:TextBox ID="txttwolane" runat="server"  CssClass="form-control"  ></asp:TextBox>
            </div>
                   <div class="col-md-4 col-xs-12">
                <label>More than 7.00m width Length (Km):</label>
            </div> 
            <div class="col-md-2 col-xs-12">
               <asp:TextBox ID="txtmorethanwidthseven" runat="server"  CssClass="form-control"  ></asp:TextBox>
            </div>


                 </div>
             <br />
           

             </asp:Panel>



          <asp:Panel ID="Panel4" runat="server" GroupingText="Reason For Bad & Fair Condition of Road" Width="1150px">
             <div class="row">
                  <div class="col-md-2 col-xs-12">
                <label> Reason:</label>
            </div> 
            <div class="col-md-3 col-xs-12">
                <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlreason_SelectedIndexChanged">
                  <%--  <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Stretch Under Construction</asp:ListItem>
                    <asp:ListItem>Stretch Under DLP</asp:ListItem>
                    <asp:ListItem>Under Maintenance of Contractor</asp:ListItem>
                    <asp:ListItem>Maintenance by Ordinary Repair</asp:ListItem>
                    <asp:ListItem>Length Not Assigned to Anybody</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>--%>
                </asp:DropDownList><br />
               <%--<asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>--%>
            </div>
                  <div class="col-md-2 col-xs-12">
               <%-- <label>   Other Remarks:</label>--%>
                       <asp:Label ID="lblotherremarks" runat="server" Text="Other Reason:" Visible="false" Font-Bold="true"></asp:Label>
            </div> 
            <div class="col-md-4 col-xs-12">
                   <asp:TextBox ID="txtotherremarks" runat="server" CssClass="form-control"  Visible="false" ></asp:TextBox>
            </div>
                   </div>
         
            

             </asp:Panel>


          <asp:Panel ID="Panel5" runat="server" GroupingText="Issue of attention with HQ/Chief Office" Width="1150px">
             <div class="row">
                  <div class="col-md-3 col-xs-12">
                <label> Description of issue:</label>
            </div> 
            <div class="col-md-8 col-xs-12">
               
               <asp:TextBox ID="txtdescription" runat="server"  CssClass="form-control" ></asp:TextBox><br />
            </div>
                 
                   </div>




             
         
            

             </asp:Panel>
          <br />

             <div class="row">
                 <div class="col-md-5 col-xs-12"></div>
                 <div class="col-md-4 col-xs-12">
                      <asp:Button ID="btnSave" runat="server" Text="Save" BackColor="green" Font-Bold="true" ForeColor="White" Width="80px" OnClick="btnSave_Click"  ValidationGroup="s" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" BackColor="#F8C471" Font-Bold="true" ForeColor="White" Width="80px"  OnClick="btnUpdate_Click"
                        ValidationGroup="s" Visible="false" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" BackColor="red" Font-Bold="true" ForeColor="White" Width="80px" OnClick="btnReset_Click"  />
                   <%-- <asp:Button ID="btnSearch" runat="server" Width="100px" OnClick="btnSearch_Click" BackColor="#F8C471" Font-Bold="true" ForeColor="White" Text="View & Edit"  />--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" Font-Bold="True" ForeColor="Maroon" ValidationGroup="s" />
                 </div>
             </div><br />




        <div class="row">
             <p style="text-align:right; "><asp:Button ID="btnExpToExcel" runat="server" Width="110px" BackColor="Green" ForeColor="White" Text="Export To Excel" OnClick="btnExpToExcel_Click" Visible="false" /></p>
            <asp:Panel ID="PanelGV" runat="server" Width="1150px" Visible="false" ScrollBars="Horizontal">
                        <table width="1150px">
                           
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="GVRoadStatistics" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-BackColor="Yellow"
                                        EmptyDataText="Record Not Found !" AutoGenerateColumns="false" OnRowCreated="GVRoadStatistics_RowCreated"
                                         OnSelectedIndexChanged="GVRoadStatistics_SelectedIndexChanged" DataKeyNames="RoadId"
                                        HeaderStyle-BackColor="#BDEDFF" Width="1150px" AllowPaging="True"  OnPageIndexChanging="GVRoadStatistics_PageIndexChanging"
                                        PageSize="10">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnEdit" CommandName="Select" runat="server" Font-Underline="false">Select</asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="25px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="center" Font-Size="Small" Width="25px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sl. No." HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="10px" />
                                                <HeaderStyle HorizontalAlign="left" Width="10px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location" HeaderStyle-BackColor="Blue">
                                                <ItemTemplate>
                                                    <strong>Wings :</strong> <%#Eval("WingName")%><br />
                                                    <strong>Circle: </strong><%#Eval("CircleName")%><strong>Division: </strong><%#Eval("DivisionName")%>
                                                </ItemTemplate>
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="210px" Font-Bold="true" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="left" Width="210px" Font-Size="Small" />
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="WingName" HeaderText="Wings" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="50px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CircleName" HeaderText="Circle" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="50px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DivisionName" HeaderText="Division" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="50px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="50px" />
                                            </asp:BoundField>--%>
                                            <%--<asp:BoundField DataField="RoadName" HeaderText="Road Name" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="50px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RoadType" HeaderText="Road Type" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SubroadType" HeaderText="Sub-Road Type" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="50px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="50px" />
                                            </asp:BoundField>--%>
                                            <%--<asp:TemplateField HeaderText="Road">
                                                <ItemTemplate>
                                                    <strong>Name :</strong> '<%#Eval("RoadName")%><br />
                                                    <strong>Type :</strong> '<%#Eval("RoadType")%><br />
                                                    <strong>Sub-Road: </strong>'<%#Eval("SubroadType")%>
                                                </ItemTemplate>
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="150px" Font-Bold="true" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="150px" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Road" HeaderStyle-BackColor="Blue">
                                                <ItemTemplate>
                                                    <strong>Name :</strong> <%#Eval("RoadName")%><br />
                                                    <strong><%#Eval("RoadType")%></strong><%--<strong>Sub-Road: </strong>'<%#Eval("SubroadType")%>--%>
                                                </ItemTemplate>
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="150px" Font-Bold="true" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="150px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Length" HeaderText="Total Length (in Km)" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <%--<asp:BoundField DataField="headName" HeaderText="Head" HeaderStyle-Font-Bold="true">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="Good" HeaderText="Good" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fair" HeaderText="Fair" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Average" HeaderText="Average" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Bad" HeaderText="Bad" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SingleLane" HeaderText="Single Lane" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Intermediate" HeaderText="Intermediate Lane" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="30px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="30px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="twolane" HeaderText="2 lane" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="50px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="morethanwidthseven" HeaderText="More than 7.00m width"
                                                HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="40px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="40px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nhno" HeaderText="N.H. No." HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="10px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="10px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="startpoint" HeaderText="Start Point" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="10px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="10px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="endpoint" HeaderText="End Point" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="10px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="10px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="importentplace" HeaderText="Important Place in the road (with chainage)"
                                                HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="150px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="missinglength" HeaderText="Missing Length in Km" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="15px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="15px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Blue">
                                                <HeaderStyle Font-Names="Arial Unicode MS" Width="200px" Font-Bold="true" />
                                                <ItemStyle HorizontalAlign="left" Font-Size="Small" Width="200px" />
                                            </asp:BoundField>
                                            <%--<asp:TemplateField HeaderText="Wings, <br /> Circle, <br /> Division">
                                        <ItemTemplate>
                                        <strong>Wings :</strong>
                                        '<%#Eval("WingName")%><br />
                                        <strong>Circle: </strong>
                                        '<%#Eval("CircleName")%>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Names="Arial Unicode MS" Width="100px" Font-Bold="true" />
                                        <ItemStyle HorizontalAlign="center" Font-Size="Small" Width="100px" />
                                        </asp:TemplateField>
                                            --%>
                                        </Columns>
                                         <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                         <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Blue" Font-Bold="True"  ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                          <%-- <RowStyle BackColor="White" />--%>
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
        </div>
        



      </div>
    </div>
      </div>
        </div>







  
</asp:Content>

