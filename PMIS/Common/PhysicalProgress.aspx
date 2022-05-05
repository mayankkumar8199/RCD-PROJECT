<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="PhysicalProgress.aspx.cs" Inherits="RCDPMISNEW_Common_PhysicalProgress" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style type="text/css">
        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
         .w-100 {
         height:300px; 
         width:auto;
         }
         .modalPopup {
            margin-top:-50px;
            width:600px;
            background-color:#EAECEE;

         }
        .loading {
            font-family: Arial;
            font-size: 10pt;
            border: 5px solid #67CFF5;
            width: 200px;
            height: 100px;
            display: none;
            position: fixed;
            background-color: White;
            z-index: 999;
        }

        .grid-sltrow {
            background: #ddd;
            font-weight: bold;
        }

        .SubTotalRowStyle {
            border: solid 1px Black;
            background-color: #D8D8D8;
            font-weight: bold;
        }

        .GrandTotalRowStyle {
            border: solid 1px Gray;
            background-color: #000000;
            color: #ffffff;
            font-weight: bold;
        }

        .GroupHeaderStyle {
            border: solid 1px Black;
            background-color: #4682B4;
            color: #ffffff;
            font-weight: bold;
        }

        .serh-grid {
            width: 85%;
            border: 1px solid #6AB5FF;
            background: #fff;
            line-height: 14px;
            font-size: 11px;
            font-family: Verdana;
        }


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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid" style="padding-top: 10px;">
         <%-- <div class="row">
            <div class="col-md-2"></div>
            <asp:Button ID="btn_rtp" Text="Click Here For See All Previous Update Details" runat="server" CssClass="btn btn-link" Font-Bold="true" OnClick="btn_rtp_Click" />
        </div>--%>

      <asp:Panel id="pnlmain" runat="server" Visible="true">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align: center; font-weight: 700; color: blue;"><h4>Physical Progress Section</h4></div>
            <div class="panel-body">
            <table width="100%">
                <tr>
                                <td align="left" colspan="10">
                                    <strong>Project Name/ No. :</strong>&nbsp;&nbsp;
                                    <asp:Label ID="lblProject" runat="server" Text="" ForeColor="#800000"></asp:Label><asp:Label
                                        ID="iblProjNo" runat="server" Text="" ForeColor="#800000"></asp:Label>
                                </td>
                                <td align="right" colspan="10">
                                    <asp:Label ID="lblsancroad" runat="server" Text="" Visible="true"></asp:Label>
                                </td>
                            </tr>
            </table>

            </div>
            <div class="panel-body">
                <div class="row" style="width: auto;">
                    <div class="col-md-2 "></div>
                    <div class="col-md-8  col-xs-12 table-responsive">
                        <table class="table  table-full-width table-bordered">
                            <thead>
                            <tr style="background-color:#008ABC; color:white">
                                <th  style="text-align: center; font-weight: bold;">Road Component</th>
                                <th  style="text-align: center; font-weight: bold;">Target (in Km)
                                </th>
                                <th  style="text-align: center; font-weight: bold;">Cumulative (in Km) 
                                </th>
                                <th  style="text-align: center; font-weight: bold;">Previous Update(in Km) & Date
                                </th>
                               
                                <th    style="text-align: center; font-weight: bold;">Current Update (in Km)
                                </th>
                            </tr>
                                </thead>
                            <tbody>
                            <tr>
                                <td >E/W (in Km) 
                                </td>
                                  <td >
                                   <asp:Label ID="lbl_EW" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_EW" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_EW" runat="server"></asp:Label>&nbsp;&nbsp; 
                                    <asp:Label ID="lbl_ew_updatedate" runat="server"  Font-Bold="true"></asp:Label>                                 
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_EW_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_EW_Date_TextChanged" ></asp:TextBox>

                                </td>
                            </tr>




                            <tr>
                                <td >GSB (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_GSB" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_GSB" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_GSB" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_gsb_updatedate" runat="server" Font-Bold="true" ></asp:Label>  
                                </td>
                              
                                <td >
                                    <asp:TextBox ID="txt_GSB_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_GSB_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >WBM/WMM (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_WBM" runat="server"></asp:Label>
                                </td>
                                  <td >
                                    <asp:Label ID="txt_WBM" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_WBM" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_wbm_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                               
                                <td >
                                    <asp:TextBox ID="txt_WBM_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_WBM_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >BUSG (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_BUSG" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_BUSG" runat="server" ></asp:Label>
                                </td>
                                 <td >
                                    <asp:Label ID="txt_c_BUSG" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                      <asp:Label ID="lbl_busg_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_BUSG_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_BUSG_Date_TextChanged"  ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >BM (in Km) 
                                </td>
                                <td>
                                    <asp:Label ID="lbl_BM" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_BM" runat="server" ></asp:Label>
                                </td>
                                 <td >
                                    <asp:Label ID="txt_C_BM" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                      <asp:Label ID="lbl_bm_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                               
                                <td >
                                    <asp:TextBox ID="txt_BM_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_BM_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >DBM (in Km) 
                                </td>
                                  <td>
                                    <asp:Label ID="lbl_DBM" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_DBM" runat="server" ></asp:Label>
                                </td>
                                
                                  <td >
                                    <asp:Label ID="txt_c_DBM" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                       <asp:Label ID="lbl_dbm_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_DBM_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_DBM_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >PRIMER (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_PRIMER" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_PRIMER" runat="server" ></asp:Label>
                                </td>
                                 <td >
                                    <asp:Label ID="txt_c_PRIMER" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                      <asp:Label ID="lbl_primer_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                              
                                <td >
                                    <asp:TextBox ID="txt_PRIMER_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_PRIMER_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >TACK COAT (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_TEAK" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_TEAK" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_TEAK" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_take_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_TEAK_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_TEAK_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>


                            <tr>
                                <td >SDBC/BC/PMC (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_SDBC" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_SDBC" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_SDBC" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_sdbc_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                              
                                <td >
                                    <asp:TextBox ID="txt_SDBC_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_SDBC_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >PCC (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_PCC" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_PCC" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_PCC" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_pcc_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                            
                                <td >
                                    <asp:TextBox ID="txt_PCC_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_PCC_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >DLC (in Km) 
                                </td>
                                <td>
                                    <asp:Label ID="lbl_DLC" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_DLC" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_DLC" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_dlc_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                               
                                <td >
                                    <asp:TextBox ID="txt_DLC_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_DLC_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >PQC (in Km) 
                                </td>
                                  <td>
                                    <asp:Label ID="lbl_PQC" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_PQC" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_PQC" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_pqc_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_PQC_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_PQC_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >DRAIN (in Km) 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_DRAIN" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_DRAIN" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_DRAIN" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_drain_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                              
                                <td >
                                    <asp:TextBox ID="txt_DRAIN_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_DRAIN_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >MASTIC ASPHALT 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_MASTIC" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_MASTIC" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_MASTIC" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_mastic_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                              
                                <td >
                                    <asp:TextBox ID="txt_MASTIC_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_MASTIC_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >SHOULDER 
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_SHOULDER" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_SHOULDER" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_SHOULDER" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_shoulder_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                              
                                <td >
                                    <asp:TextBox ID="txt_SHOULDER_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_SHOULDER_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >CD Works
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_CDWork" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_CDWork" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_CDWORK" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_cdwork_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_CDWork_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_CDWork_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>
                                <tr>
                                <td >Bridge
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_Bridge" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_Bridge" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_Bridge" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_Bridge_updatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_Bridge_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_Bridge_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td >Protection Work
                                </td>
                                  <td>
                                    <asp:Label ID="lbl_Protection" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_Protection" runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_Protection" runat="server" ></asp:Label>&nbsp;&nbsp; 
                                     <asp:Label ID="lbl_protectionupdatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                             
                                <td >
                                    <asp:TextBox ID="txt_Protection_Date" runat="server" AutoPostBack="true" OnTextChanged="txt_Protection_Date_TextChanged" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >Bolder Pitch
                                </td>
                                 <td>
                                    <asp:Label ID="lbl_Bolder" runat="server"></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_Bolder"  runat="server" ></asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="txt_c_Bolder" runat="server" ></asp:Label> &nbsp;&nbsp; 
                                     <asp:Label ID="lbl_bolderupdatedate" runat="server" Font-Bold="true"></asp:Label>  
                                </td>
                              
                                <td >
                                    <asp:TextBox ID="txt_Bolder_Date"  runat="server" AutoPostBack="true" OnTextChanged="txt_Bolder_Date_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >Remark
                                </td>
                                <td colspan="4" >
                                    <asp:TextBox ID="txt_Comment" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                                <tr>
                                <td > Bridge Remark
                                </td>
                                <td colspan="4" >
                                    <asp:TextBox ID="txtbridge_Comment" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                                 <tr>
                                  <td >Road Component
                                </td>
                               <td colspan="4" ><asp:DropDownList ID="ddldescriptiontype1" runat="server" Width="350px">
                                <asp:ListItem Value="0">---Select Road Component--- </asp:ListItem>
                                 <asp:ListItem Value="1">E/W </asp:ListItem>
                                <asp:ListItem Value="1">GSB </asp:ListItem>
                                <asp:ListItem Value="2">WBM/WMM </asp:ListItem>
                                <asp:ListItem Value="3">BUSG</asp:ListItem>
                                <asp:ListItem Value="4">BM  </asp:ListItem>
                                <asp:ListItem Value="5">DBM </asp:ListItem>
                                <asp:ListItem Value="6">PRIMER </asp:ListItem>
                                <asp:ListItem Value="7">TEAK COAT </asp:ListItem>
                                <asp:ListItem Value="8">SDBC/BC/PMC </asp:ListItem>
                                <asp:ListItem Value="9">PCC </asp:ListItem>
                                <asp:ListItem Value="10">DLC </asp:ListItem>
                                <asp:ListItem Value="11">PQC</asp:ListItem>
                                <asp:ListItem Value="12">DRAIN </asp:ListItem>
                                <asp:ListItem Value="13">MASTIC ASPHALT </asp:ListItem>
                                <asp:ListItem Value="14">SHOULDER </asp:ListItem>
                                <asp:ListItem Value="15">CD Works  </asp:ListItem>
                                <asp:ListItem Value="16">Protection Work</asp:ListItem>
                                <asp:ListItem Value="17">Bolder Pitch </asp:ListItem>
                               
                                    </asp:DropDownList>
                                </td>

                                </tr>
                                <tr>
                                <td>
                                Upload Progress Image
                                </td>
                                <td colspan="2" >
                              <asp:FileUpload ID="flu1" runat="server" ToolTip="Upload Image1" CssClass="form-control" />
                                </td>
                                     <td colspan="2">
                                            <asp:Button ID="btnShow" runat="server" Text="View Image" Visible="false"/>
                                            <!-- ModalPopupExtender -->
                                            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
                                             CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup modal-lg col-lg-8" align="center" Style="display: none">
                                                 <div class="col-lg-12 form-group">
                                                   
                                                    <div class="col-md-2">
                                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-success" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 preview12 form-group">
                                                     <asp:Image ID="img1" runat="server" class="d-block w-100" />
                                                    <asp:Label ID="Label1" runat="server" ForeColor="black" Visible="false" ></asp:Label>
                                                    <label style="color:darkred;"> Description:-</label><asp:Label ID="lblimg1description" runat="server" ForeColor="black" ></asp:Label>
                                                </div>
                                               
                                            </asp:Panel>
                                            <!-- ModalPopupExtender -->
                                        <label>Description:-</label> <asp:TextBox ID="txtimg1desc" runat="server"  Width="59%" ></asp:TextBox>
                                     </td>
                                     

                            </tr>
                                 <tr>
                                <td ><asp:DropDownList ID="ddldescriptiontype2" runat="server" Visible="false">
                                <asp:ListItem Value="0">---Select Description 2--- </asp:ListItem>
                               
                               
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2" >
                                    <asp:FileUpload ID="flu2" runat="server" ToolTip="Upload Image2"  CssClass="form-control" />
                                </td>
                                     <td colspan="2">
                                              <asp:Button ID="btnShow1" runat="server" Text="View Image" Visible="false"/>
                                            <!-- ModalPopupExtender -->
                                            <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel2" TargetControlID="btnShow1"
                                             CancelControlID="Button2" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup modal-lg col-lg-8" align="center" Style="display: none">
                                                 <div class="col-lg-12 form-group">
                                                   
                                                    <div class="col-md-2">
                                                        <asp:Button ID="Button2" runat="server" Text="Close" CssClass="btn btn-success" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 preview12 form-group">
                                                     <asp:Image ID="img2" runat="server" class="d-block w-100" />
                                                    <label>Description:-</label><asp:Label ID="lblimg2description" runat="server" ></asp:Label>
                                                </div>
                                               
                                            </asp:Panel>
                                            <!-- ModalPopupExtender -->
                                          <label>Description:-</label> <asp:TextBox ID="txtimg2desc" runat="server"  Width="59%" ></asp:TextBox>
                                     </td>

                            </tr>
                                <%-- <tr>
                                <td >Upload Image3
                                </td>
                                <td colspan="2" >
                                   <asp:FileUpload ID="flu3" runat="server" CssClass="form-control" />
                                </td>
                                     <td colspan="2">
                                        <asp:Button ID="btnshow2" runat="server" Text="View Image"/>
                                            <!-- ModalPopupExtender -->
                                            <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panel3" TargetControlID="btnshow2"
                                             CancelControlID="Button3" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup modal-lg col-lg-8" align="center" Style="display: none">
                                                 <div class="col-lg-12 form-group">
                                                   
                                                    <div class="col-md-2">
                                                        <asp:Button ID="Button3" runat="server" Text="Close" CssClass="btn btn-success" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 preview12 form-group">
                                                     <asp:Image ID="img3" runat="server" class="d-block w-100" />
                                                    <label> Description:-</label><asp:Label ID="lblimg3description" runat="server" ></asp:Label>
                                                    
                                                </div>
                                               
                                            </asp:Panel>
                                            <!-- ModalPopupExtender -->
                                          <label>Description:-</label> <asp:TextBox ID="txtimg3desc" runat="server"  Width="59%"  ></asp:TextBox>
                                     </td>

                            </tr>
                                 <tr>
                                <td >Upload Image4
                                </td>
                                <td colspan="2" >
                                   <asp:FileUpload ID="flu4" runat="server" CssClass="form-control" />
                                </td>
                                     <td colspan="2">
                                          <asp:Button ID="btnshow3" runat="server" Text="View Image"/>
                                            <!-- ModalPopupExtender -->
                                            <cc1:ModalPopupExtender ID="mp4" runat="server" PopupControlID="Panel4" TargetControlID="btnshow3"
                                             CancelControlID="Button4" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup modal-lg col-lg-8" align="center" Style="display: none">
                                                 <div class="col-lg-12 form-group">
                                                   
                                                    <div class="col-md-2">
                                                        <asp:Button ID="Button4" runat="server" Text="Close" CssClass="btn btn-success" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 preview12 form-group">
                                                     <asp:Image ID="img4" runat="server" class="d-block w-100" />
                                                    <label>Description:-</label><asp:Label ID="lblimg4description" runat="server" ></asp:Label>
                                                </div>
                                               
                                            </asp:Panel>
                                            <!-- ModalPopupExtender -->
                                          <label>Description:-</label> <asp:TextBox ID="txtimg4desc" runat="server"  Width="59%" ></asp:TextBox>
                                     </td>

                            </tr>
                                 <tr>
                                <td >Upload Image5
                                </td>
                                <td colspan="2" >
                                   <asp:FileUpload ID="flu5" runat="server" CssClass="form-control" />
                                </td>
                                     <td colspan="2">
                                           <asp:Button ID="btnshow4" runat="server" Text="View Image"/>
                                            <!-- ModalPopupExtender -->
                                            <cc1:ModalPopupExtender ID="mp5" runat="server" PopupControlID="Panel5" TargetControlID="btnshow4"
                                             CancelControlID="Button5" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="Panel5" runat="server" CssClass="modalPopup modal-lg col-lg-8" align="center" Style="display: none">
                                                 <div class="col-lg-12 form-group">
                                                   
                                                    <div class="col-md-2">
                                                        <asp:Button ID="Button5" runat="server" Text="Close" CssClass="btn btn-success" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 preview12 form-group">
                                                     <asp:Image ID="img5" runat="server" class="d-block w-100" />
                                                    <label>Description:-</label><asp:Label ID="lblimg5description" runat="server" ></asp:Label>
                                                </div>
                                               
                                            </asp:Panel>
                                            <!-- ModalPopupExtender -->
                                          <label>Description:-</label> <asp:TextBox ID="txtimg5desc" runat="server"  Width="59%"  ></asp:TextBox>
                                     </td>

                            </tr>--%>

                            </tbody>
                        </table>
                    </div>

                </div>


               

                <div class="clearfix"></div>

                <div class="row" style="padding-top: 12px;">
                    <div class="col-md-2 "></div>
                    <div class="col-md-2 "></div>
                    <div class="col-md-1 "></div>
                    <div class="col-md-4 col-xs-12">
                        <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="btn btn-primary" Width="150px" OnClick="btn_save_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Width="150px"
                                        CssClass="btn btn-info" /><asp:Label ID="Label33" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                    </div>

                </div>




            </div>
        </div>
        </asp:Panel>
       

    </div>
</asp:Content>

