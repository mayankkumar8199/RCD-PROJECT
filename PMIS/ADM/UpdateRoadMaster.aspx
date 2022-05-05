<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="UpdateRoadMaster.aspx.cs" Inherits="RCDPMISNEW_ADM_UpdateRoadMaster1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  


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

<style type="text/css">
.Space label {
margin-left: 12px;
}
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
<div class="container" style="padding-top: 12px;">
       

<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
              
<Triggers>  
<asp:PostBackTrigger ControlID="txtcavg" />  
</Triggers>  
<Triggers>  
<asp:PostBackTrigger ControlID="txtcfair" />  
</Triggers> 
<Triggers>  
<asp:PostBackTrigger ControlID="txtcgood" />  
</Triggers> 
<Triggers>  
<asp:PostBackTrigger ControlID="txtcbad" />  
</Triggers>

<Triggers>  
<asp:PostBackTrigger ControlID="txtcsinglelane" />  
</Triggers>  
<Triggers>  
<asp:PostBackTrigger ControlID="txtcinterlane" />  
</Triggers> 
<Triggers>  
<asp:PostBackTrigger ControlID="txtc2lane" />  
</Triggers> 
<Triggers>  
<asp:PostBackTrigger ControlID="txtcmorethan7" />  
</Triggers>
               
<ContentTemplate>--%>
     
      


<div class="panel-group">
<div class="panel panel-primary">
<div class="panel-heading" style="text-align: center; font-weight: 700; font-size: x-large">Road Statistics</div>
<div class="row">
                 
<p style="text-align:center;">
<%--<asp:Label ID="lblerr" runat="server" ></asp:Label>--%>
<%-- <asp:ImageButton ID="btnBack" runat="server" OnClick="btnBack_Click" Width="55px" ImageUrl="~/RCDPMISNEW/images/back_image.png" /></p>--%>
                     
</div>
<div class="panel-body">

<div class="row">
<%--   <h3 style="text-align:center;  color:cornflowerblue">Road Statistics</h3>--%>
<asp:Label ID="lblRoadName" runat="server" Text="" ForeColor="Maroon"></asp:Label>
<%--  <hr style="border:1px solid grey" />--%>
</div>
<asp:Panel ID="PanelDDL" runat="server" Width="1100px">
<div class="row">
<div class="col-md-1 col-xs-12">
<label>Wings :</label>
</div>
<div class="col-md-2 col-xs-12">
<%--<asp:TextBox ID="txtwing" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>--%>
<asp:DropDownList ID="DDLWings" runat="server" CssClass="form-control" Enabled="false">
</asp:DropDownList>
<span id="SpanWings" runat="server" style="color: Red">*</span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select Wings"
ControlToValidate="DDLWings" ValidationGroup="s" ForeColor="red" InitialValue="0"
Display="None"></asp:RequiredFieldValidator>
</div>


<div class="col-md-1 col-xs-12">
<label>Circle :</label>
</div>
<div class="col-md-3 col-xs-12">
<asp:TextBox ID="txtcircle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
<%-- <asp:DropDownList ID="DDLCircle" runat="server"   CssClass="form-control">
</asp:DropDownList>
<span id="SpanCircle" runat="server" style="color: Red">*</span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Circle"
ControlToValidate="DDLCircle" ValidationGroup="s" ForeColor="red" InitialValue="0"
Display="None"></asp:RequiredFieldValidator>--%>
</div>
<div class="col-md-2 col-xs-12">
<label>Division :</label>
</div>
<div class="col-md-3 col-xs-12" style="padding-bottom: 10px;">
<asp:TextBox ID="txtDivision" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
<%-- <asp:DropDownList ID="DDLDivision" runat="server" CssClass="form-control">
</asp:DropDownList>
<span id="SpanDivision" runat="server" style="color: Red">*</span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Division"
ControlToValidate="DDLDivision" ValidationGroup="s" ForeColor="red" InitialValue="0"
Display="None"></asp:RequiredFieldValidator>--%>
</div>



</div>
<div class="row">



<div class="col-md-2 col-xs-12 ">
<label>Road Name :</label>
</div>
<div class="col-md-10 col-xs-12">
<asp:TextBox ID="txtRoadName" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtRoadName_TextChanged"></asp:TextBox>
<span id="Span1" runat="server" style="color: Red">*</span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRoadName"
Display="None" ErrorMessage="Please Enter Road Name" ForeColor="red" ValidationGroup="s"></asp:RequiredFieldValidator>
</div>
<div class="col-md-2 col-xs-12">
<label>Road Type:</label>
</div>
<div class="col-md-2 col-xs-12">
<%--  <asp:TextBox ID="txt_RoadType" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>--%>
<asp:DropDownList ID="DDLRoadType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLRoadType_SelectedIndexChanged"  >
</asp:DropDownList>
<span id="Span2" runat="server" style="color: Red">*</span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DDLRoadType"
Display="None" ErrorMessage="Please Select Road Type" ForeColor="red" InitialValue="0"
ValidationGroup="s"></asp:RequiredFieldValidator>
</div>
<div class="col-md-2 col-xs-12">
<span id="spanSubRoad" runat="server" visible="true">Sub-Road Type  </span>
</div>
<div class="col-md-2 col-xs-12">
<%--  <asp:TextBox ID="txt_subroadtype" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>--%>
<asp:DropDownList ID="DDLSubRoad" runat="server" CssClass="form-control" AutoPostBack="true">
</asp:DropDownList>
</div>
<div class="col-md-2 col-xs-12">
<label>Total Length (in Km):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtLength" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox><span
id="Span3" runat="server" style="color: Red">*</span>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Length"
ControlToValidate="txtLength" ValidationGroup="s" ForeColor="red" Display="None"></asp:RequiredFieldValidator>
</div>
</div>



<div class="row">
<div class="col-md-3 col-xs-12">
<label>Road Conversion(If Any):</label>
</div>
<div class="col-md-3 col-xs-12">
<asp:RadioButtonList ID="radioyesno" CssClass="FormatRadioButtonList" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="radioyesno_SelectedIndexChanged">
<asp:ListItem Value="2" >No </asp:ListItem>
<asp:ListItem Value="1">Yes &nbsp;&nbsp;</asp:ListItem>
                                   
</asp:RadioButtonList><br />
</div>
<%-- <div class="col-md-2 col-xs-12">
                                
<asp:Label ID="lblconversiontype" runat="server" Text="Conversion Type:" Font-Bold="true" Visible="false"></asp:Label>
                              
</div>--%>
<%--<div class="col-md-4 col-xs-12">
<asp:RadioButtonList ID="radioroadconversion" CssClass="FormatRadioButtonList" runat="server" RepeatDirection="Horizontal" Visible="false"
AutoPostBack="true" OnSelectedIndexChanged="radioroadconversion_SelectedIndexChanged" >
<asp:ListItem Value="1" >Partial Conversion </asp:ListItem>
<asp:ListItem Value="2">Full Conversion &nbsp;&nbsp;</asp:ListItem> 
                                                                      
</asp:RadioButtonList><br />
</div>--%>
</div>
<div class="row">
<div class="col-md-2 col-xs-12">
                                
<asp:Label ID="lblconversiontype" runat="server" Text="Conversion Type:" Font-Bold="true" Visible="false"></asp:Label>
                              
</div>
<div class="col-md-4 col-xs-12">
<asp:RadioButtonList ID="radioroadconversion" CssClass="FormatRadioButtonList" runat="server" RepeatDirection="Horizontal" Visible="false"
AutoPostBack="true" OnSelectedIndexChanged="radioroadconversion_SelectedIndexChanged" >
<asp:ListItem Value="1" >Partial Conversion </asp:ListItem>
<asp:ListItem Value="2">Full Conversion &nbsp;&nbsp;</asp:ListItem> 
                                                                      
</asp:RadioButtonList><br />
</div>
</div>

</asp:Panel>


<asp:Panel ID="pnlbtn" runat="server" Visible="false">
<div class="row">
<p style="float: right;">
<asp:Button ID="btn_new_road_concersion" runat="server" Visible="true" Text="Add New Road Conversion" CssClass="btn btn-info" OnClick="btn_new_road_concersion_Click" /></p>
</div>
</asp:Panel>

<asp:Label ID="lbl_initial" runat="server" style="color:maroon; font-weight:bold" Visible="false">Initial Total Road Length:-</asp:Label> <asp:Label ID="lbl_TotalLength" runat="server" Visible="false" ></asp:Label>

<asp:Panel ID="pnl_roadconversation" runat="server" GroupingText="Converted Road Details "
Width="100%" Visible="false">

                            
<div class="row">
<div class="col-md-2 col-xs-12">
<asp:Label ID="lblconvertedroadlength" runat="server" Text="Enter Converted Road Length:" Font-Bold="true"></asp:Label>
</div>
<div class="col-md-2 col-xs-10">
<asp:TextBox ID="txt_converted_road_length" runat="server" CssClass="form-control" AutoPostBack="true"   OnTextChanged="txt_converted_road_length_TextChanged1"></asp:TextBox><br />
</div>
<div class="col-md-2 col-xs-4">
<asp:Label ID="lblrcconversionremarks" runat="server" Text="Road Conversion Remarks:" Font-Bold="true"></asp:Label>

</div>
<div class="col-md-6 col-xs-4">
<asp:TextBox ID="txtroadconvremarks" runat="server" CssClass="form-control" Visible="true"></asp:TextBox><br />
</div>
</div>
</asp:Panel>


<asp:Panel ID="Panel1" runat="server" GroupingText="Condition of the Road (in Km) "
Width="100%" Visible="false">

<div class="row">
<div class="col-md-4 col-xs-12">
<label>GOOD (Pots less than 2% of the total length) :</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtGood" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>FAIR (Pots less than 5% of the total length) :</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtFair" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
</div>
</div>
<br />
<div class="row">
<div class="col-md-4 col-xs-12">
<label>AVERAGE (Pots between 5% to 15% of the total length):</label>
</div>
<div class="col-sm-2">
<asp:TextBox ID="txtAverage" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>BAD (Pots more than 15% of the total length):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtBad" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
</div>

</div>

</asp:Panel>



<asp:Panel ID="pnlconverted_condition_ofroad" runat="server" GroupingText="Converted Condition of the Road (in Km) "
Width="100%" Visible="false">
<%--   <p style="text-align:center; color:maroon; font-weight:700;"> <asp:Label ID="error" runat="server" Visible="false"></asp:Label></p>--%>
<div class="row">
<div class="col-md-4 col-xs-12">
<label>Converted GOOD (Pots less than 2% of the total length) :</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtcgood" runat="server" CssClass="form-control" onkeypress="return validate(event)" AutoPostBack="true" OnTextChanged="txtcgood_TextChanged"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>Converted FAIR (Pots less than 5% of the total length) :</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtcfair" runat="server" CssClass="form-control" onkeypress="return validate(event)" AutoPostBack="true" OnTextChanged="txtcfair_TextChanged"></asp:TextBox>
</div>
</div>
<br />
<div class="row">
<div class="col-md-4 col-xs-12">
<label>Converted AVERAGE (Pots between 5% to 15% of the total length):</label>
</div>
<div class="col-sm-2">
                               
<asp:TextBox ID="txtcavg" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtcavg_TextChanged" onkeypress="return validate(event)"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>Converted BAD (Pots more than 15% of the total length):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtcbad" runat="server" CssClass="form-control" onkeypress="return validate(event)" AutoPostBack="true" OnTextChanged="txtcbad_TextChanged"></asp:TextBox>
</div>

</div>

</asp:Panel>


<asp:Panel ID="Panel3" runat="server" Width="100%" Visible="false" GroupingText="National Highways Detail">
<div class="row">
<div class="col-md-2 col-xs-12">
<label>N.H. No.:</label>
</div>
<div class="col-md-1 col-xs-12">
<asp:TextBox ID="txtnhno" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="col-md-3 col-xs-12">
<label>Starting Point in the Division :</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtstartpoint" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="col-md-2 col-xs-12">
<label>Terminating Point in the Division :</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtendpoint" runat="server" CssClass="form-control"></asp:TextBox>
</div>
</div>

<div class="row">
<div class="col-md-3 col-xs-12">
<label>Important Place in the road (with chainage):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtimportentplace" runat="server" CssClass="form-control" TextMode="MultiLine"
Style="resize: none"></asp:TextBox>
</div>
<div class="col-md-2 col-xs-12">
<label>Missing Length in Km:</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtmissinglength" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
</div>
<div class="col-md-1 col-xs-12">
<label>Remarks:</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
</div>
</div>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server" GroupingText="Lane Width (m)" Width="100%">
<div class="row">
<div class="col-md-3 col-xs-12">
<label>Single Lane 3.75m width Length (Km):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtSingleLane" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>Intermediate lane 5.50 m width Length (Km)</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtIntermediate" runat="server" CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>
</div>
</div>
<br />
<div class="row">
<div class="col-md-3 col-xs-12">
<label>2 lane 7.00m width Length (Km):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txttwolane" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>More than 7.00m width Length (Km):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtmorethanwidthseven" runat="server" CssClass="form-control"></asp:TextBox>
</div>


</div>
<br />


</asp:Panel>


<asp:Panel ID="pnl_converted_LanWidth" runat="server" GroupingText="Converted Lane Width (m)" Width="100%" Visible="false">
<div class="row">
<div class="col-md-3 col-xs-12">
<label>Converted Single Lane 3.75m width Length (Km):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtcsinglelane" runat="server" CssClass="form-control" onkeypress="return validate(event)" AutoPostBack="true" OnTextChanged="txtcsinglelane_TextChanged"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>Converted Intermediate lane 5.50 m width Length (Km)</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtcinterlane" runat="server" CssClass="form-control" onkeypress="return validate(event)" AutoPostBack="true" OnTextChanged="txtcinterlane_TextChanged"></asp:TextBox>
</div>
</div>
<br />
<div class="row">
<div class="col-md-3 col-xs-12">
<label>Converted 2 lane 7.00m width Length (Km):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtc2lane" runat="server" CssClass="form-control" OnTextChanged="txtc2lane_TextChanged" AutoPostBack="true"></asp:TextBox>
</div>
<div class="col-md-4 col-xs-12">
<label>Converted More than 7.00m width Length (Km):</label>
</div>
<div class="col-md-2 col-xs-12">
<asp:TextBox ID="txtcmorethan7" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtcmorethan7_TextChanged"></asp:TextBox>
</div>


</div>
<br />


</asp:Panel>



<asp:Panel ID="Panel4" runat="server" GroupingText="Reason For Bad & Fair Condition of Road" Width="100%" Visible="false">
<div class="row">
<div class="col-md-3 col-xs-12">
<label>Reason:</label>
</div>
<div class="col-md-3 col-xs-12">
<asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlreason_SelectedIndexChanged">
<%-- <asp:ListItem>--Select--</asp:ListItem>
<asp:ListItem>Stretch Under Construction</asp:ListItem>
<asp:ListItem>Stretch Under DLP</asp:ListItem>
<asp:ListItem>Under Maintenance of Contractor</asp:ListItem>
<asp:ListItem>Maintenance by Ordinary Repair</asp:ListItem>
<asp:ListItem>Length Not Assigned to Anybody</asp:ListItem>
<asp:ListItem>Other</asp:ListItem>--%>
</asp:DropDownList>
<%--<asp:TextBox ID="TextBox1" runat="server"  CssClass="form-control" onkeypress="return validate(event)"></asp:TextBox>--%>
</div>
<div class="col-md-2 col-xs-12">
<asp:Label ID="lblotherremarks" Text="Other Remarks:" runat="server" Visible="false" Font-Bold="true"></asp:Label>
</div>
<div class="col-md-4 col-xs-12">
<asp:TextBox ID="txtotherremarks" runat="server" CssClass="form-control" Visible="false"></asp:TextBox><br />
</div>
</div>



</asp:Panel>


<asp:Panel ID="Panel5" runat="server" GroupingText="Issue of attention with HQ/Chief Office" Width="100%" Visible="false">
<div class="row">
<div class="col-md-3 col-xs-12">
<label>Description of issue:</label>
</div>
<div class="col-md-8 col-xs-12">

<asp:TextBox ID="txtdescription" runat="server" CssClass="form-control"></asp:TextBox><br />
</div>

</div>

</asp:Panel>
                

<asp:Panel ID="pnl_fileupload" runat="server" Visible="false" GroupingText="Approval Letter Upload Here "
Width="100%">
<div class="row">
                                
<div class="col-md-4 col-xs-12">
<label>Attach Road Conversion Approval Letter:</label>
</div>
<div class="col-md-4 col-xs-12">
<asp:FileUpload ID="file_upload" runat="server"  />                                 
<%--<asp:Button ID="btnupload" runat="server" Text="Upload File" CssClass="btn btn-link" OnClick="btnupload_Click" />--%>
</div>
<%--<div class="col-md-8 col-xs-12">
<a href="viewuploaddocument.aspx" target="_blank"><asp:Label ID="lblfileuploadpath" runat="server"></asp:Label> </a>  
</div>--%>
                                
</div>
<br />
<div class="row">
<div class="col-md-2 col-xs-12">
<asp:label ID="lblviewfile" runat="server" Text="Click Link To View File" Visible="false" Font-Bold="true"></asp:label>
</div>
<div class="col-md-10 col-xs-12">
                                   
<a href="viewuploaddocument.aspx" target="_blank"><asp:Label ID="lblfileuploadpath" runat="server"></asp:Label> </a>  
<%--<asp:HyperLink ID="lblfileuploadpath" runat="server"  Text="View Document"></asp:HyperLink>--%>
</div>
</div>


<br />

</asp:Panel>

<%-- <br />--%>
</div>
<asp:Panel ID="pnl6" runat="server">
<div class="row">
<div class="col-md-5 col-xs-12"></div>
<div class="col-md-4 col-xs-12">
<%--  <asp:Button ID="btnSave" runat="server" Text="Save" BackColor="green" Font-Bold="true" ForeColor="White" Width="80px" OnClick="btnSave_Click"  ValidationGroup="s" />--%>
<asp:Button ID="btnUpdate" runat="server" Text="Update" UseSubmitBehavior="true" Font-Bold="true" CssClass="btn-info" Width="80px" OnClick="btnUpdate_Click"
ValidationGroup="s" Visible="true" />
<asp:Button ID="btnCancle" runat="server" Text="Close" UseSubmitBehavior="true" Font-Bold="true" CssClass="btn-danger" Width="80px"  OnClick="btnCancle_Click"
ValidationGroup="s" Visible="true" />

<%--<asp:Button ID="btnReset" runat="server" Text="Reset" BackColor="red" Font-Bold="true" ForeColor="White" Width="80px"  OnClick="btnReset_Click"  />--%>
<%-- <asp:Button ID="btnSearch" runat="server" Width="100px" OnClick="btnSearch_Click" BackColor="#F8C471" Font-Bold="true" ForeColor="White" Text="View & Edit"  />--%>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
ShowSummary="False" Font-Bold="True" ForeColor="Maroon" ValidationGroup="s" />
</div>
</div>
</asp:Panel>
<br />

            

            <asp:Panel ID="pnlconvertedroad" runat="server" Visible="false">
            <div class="container-fluid">
                       
            <div class="row">
            <div class="table-responsive">
            <asp:Panel ID="pnl" runat="server" ScrollBars="Auto">      
            <p style="text-align:center; font-weight:700; color:maroon;"> <asp:Label ID="lblerror" runat="server" Text="" ></asp:Label>     </p>
                                                
            <asp:GridView ID="grdEistingRecordConvert" CssClass="table table-striped table-bordered table text-center" 
            runat="server"
            Width="100%"   AutoGenerateColumns="false"  DataKeyNames="RoadConversionId"  OnRowCommand="grdEistingRecordConvert_RowCommand"                                    
            ShowHeaderWhenEmpty="True" EmptyDataText="" EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-ForeColor="#990000" >
                                        
            <Columns>

                                            
            <asp:TemplateField HeaderText="Sl.No." HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            <ItemStyle />
            <HeaderStyle Font-Bold="false" Width="1%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CID" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" HeaderStyle-Width="1%">
            <ItemTemplate>                                                   
            <asp:LinkButton ID="lnk_roadid" runat="server"
            Text='<%# Eval("RoadConversionId") %>' CommandName="CID" CommandArgument='<%# Eval("RoadConversionId") %>'></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="left" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Road Conversion Remarks" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txtroadremarks" runat="server"
            Text='<%# Eval("RoadConversionRemarks") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="12%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Conversion Type" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txtDivision" runat="server"
            Text='<%# Eval("ConvertedName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="12%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total Length" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txttlength" runat="server"
            Text='<%# Eval("Totallength") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Conv. Good" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black">
            <ItemTemplate>
            <asp:Label ID="txtcgood" runat="server"
            Text='<%# Eval("ConvertedGood") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Conv. Bad" HeaderStyle-BackColor="#008abc"  HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="black"  ItemStyle-BorderColor="Black">
            <ItemTemplate>
            <asp:Label ID="txtcbad" runat="server"
            Text='<%# Eval("ConvertedBad") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Conv. Fair" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txtcfail" runat="server"
            Text='<%# Eval("ConvertedFair") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Conv. Average" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txtcavg" runat="server"
            Text='<%# Eval("ConvertedAverage") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Conv. Single" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txtcsingle" runat="server"
            Text='<%# Eval("ConvertedSingle") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Conv. Intermediate" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txtcinter" runat="server"
            Text='<%# Eval("ConvertedIntermediate") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Conv. 2Lane" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <asp:Label ID="txtc2ln" runat="server"
            Text='<%# Eval("ConvertedTwoLane") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Conv. More Than 7" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White"  HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black">
            <ItemTemplate>
            <asp:Label ID="txtcmorethan7" runat="server"
            Text='<%# Eval("ConvertedMoreThanSeven") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Document" HeaderStyle-BackColor="#008abc" HeaderStyle-ForeColor="White" HeaderStyle-BorderColor="black" ItemStyle-BorderColor="Black" >
            <ItemTemplate>
            <%--<asp:HyperLink ID="roadletter" runat="server" Target="_blank" NavigateUrl='<%# "~/RCDPMISNEW/Approval_latter/"+ Eval("RoadConversionLetter") %>' Text="Document" ></asp:HyperLink>--%>
            <asp:HyperLink ID="roadletter" runat="server" Target="_blank" NavigateUrl='<%# "~/PMIS/Approval_latter/"+ Eval("RoadConversionLetter") %>'  ><%# Eval("RoadConversionLetter") %></asp:HyperLink>
            <%-- <asp:Label ID="txtcircle" runat="server"
            Text='<%# Eval("RoadConversionLetter") %>'></asp:Label>--%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Font-Bold="true" Font-Size="small" Width="2%" />
            </asp:TemplateField>
                                            
                                            
            </Columns>
                                        

            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="white" Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
                                     
            <SelectedRowStyle BackColor="#000099"  ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
                                      
            </asp:GridView>

            </asp:Panel>
                              
            </div>
            </div>
            </div>
            </asp:Panel>

<asp:Panel ID="pnldocument" runat="server" Visible="false" >
<div class="row">
                       
<div class="col-md-10">
<div class="col-md-4 col-xs-12">
<label>Attach Conversion Approval Letter:</label>
</div>
<div class="col-md-3 col-xs-12">
<asp:FileUpload ID="FileUpload1" runat="server"  />                                 
                               
</div>
<div class="col-md-4 col-xs-12">
                                                              
<asp:Button ID="btnuploadletter" runat="server" Text="Upload File" CssClass="btn btn bg-blue-sky" OnClick="btnuploadletter_Click" />
<asp:Button ID="btn_cancle" runat="server" Text="Cancel" CssClass="btn btn bg-danger" OnClick="btn_cancle_Click" />
</div>
</div>
</div><br />

</asp:Panel>
                


</div>

</div>
       
<%-- </ContentTemplate>
      
</asp:UpdatePanel>--%>


<div class="container">
</div>


</div>
</asp:Content>

