<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="Allotmentt.aspx.cs" Inherits="PMIS_ADM_Allotmentt" %>

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
<div class="container" style=" overflow:scroll;padding-top:12px;">
  
  <div class="panel-group">
    <div class="panel panel-primary">
      <div class="panel-heading" style="text-align:center; font-weight:700; font-size:x-large">Allotment Entry Form</div>
      <div class="panel-body">
           
           <div class="row">

           <div class="col-md-2 col-xs-12">
                <label> Wings:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                  <asp:DropDownList ID="ddlwings" runat="server" CssClass="form-control" onselectedindexchanged="ddlwings_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
                  <div class="col-md-2 col-xs-12">
                <label> Circle:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                 <asp:DropDownList ID="ddlcircle" runat="server" CssClass="form-control" AutoPostBack="true">
                </asp:DropDownList>
              </div>
                  <div class="col-md-2 col-xs-12">
                <label> Division:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                   <asp:DropDownList ID="ddldivision" runat="server" CssClass="form-control" AutoPostBack="true">
                </asp:DropDownList>
            </div>
       </div>
                   <br />
                  
                   <div class="row">

           <div class="col-md-2 col-xs-12">
                <label> Head:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                <asp:DropDownList ID="ddlhead" runat="server" CssClass="form-control" AutoPostBack="true">
              </asp:DropDownList>
               </div>    
              
            
                  <div class="col-md-2 col-xs-12">
                <label> Sub-Head:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                <asp:DropDownList ID="ddlsub" runat="server" CssClass="form-control" AutoPostBack="true">
                </asp:DropDownList>
            </div>
                  <div class="col-md-2 col-xs-12">
                <label> Allotment Amount(in Rs.):</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                  <asp:TextBox ID="txtalltment" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
            </div>
            
                               </div>

                   <div class="row">

           <div class="col-md-2 col-xs-12">
                <label> Dated:</label>
            </div> 
            <div class="col-md-2 col-xs-12">
                <asp:TextBox ID="txtdate" runat="server"  CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
                  <div class="col-md-2 col-xs-12">
                 <asp:Button ID="btnSave" runat="server" Text="Save" BackColor="green" Font-Bold="true" ForeColor="White" Width="80px" OnClick="btnSave_Click"   ValidationGroup="s" />
            </div>
      </div>
        </div>
</div>
</div>
</asp:Content>

