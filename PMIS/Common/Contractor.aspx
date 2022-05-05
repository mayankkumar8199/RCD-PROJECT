<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="Contractor.aspx.cs" Inherits="RCDPMISNEW_Common_Contractro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar" Namespace="RJS.Web.WebControl"
    TagPrefix="rjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
        .uppercase
{
    text-transform: uppercase;
}
        .answerBottomYesNo input[type="radio"]{
    margin-right:5px;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid" style="padding-top:12px;">
        
       
 
  <div class="panel-group">
    <div class="panel panel-primary">
      <div class="panel-heading" style="text-align:center; font-weight:700; font-size:x-large">Contractor Details</div>
      <div class="panel-body">
          
        <div class="row">
              <%--<p style="padding-top:10px; float:right"><asp:Button ID="btn_add_contractor" runat="server" Text="Add New Contractor"   OnClick="btn_add_contractor_Click" CssClass="btn btn btn-info"  /></p>--%>
        
            <div class="col-md-12">
              
                <%-- <hr style="border:1px solid black" />--%>
                 </div>
             </div>
        
        <div class="row">
          <div class="col-md-10"> 
            <h4 style="text-align:center; font-weight:700; color:red ">Here you Can Search Records</h4>
          </div>
           <div class="col-md-2"> 
                   <p style="padding-top:10px; float:right;"><asp:ImageButton ID="btn_add_contractor" runat="server"   OnClick="btn_add_contractor_Click"  Width="50px"   ImageUrl="~/PMIS/images/Add_User.png" /></p>
                 </div>        
        </div>
         <div class="row" style="padding-top:10px;">
             <div class="col-md-2 col-xs-12">
                <label>Year of Registration</label>
            </div>
              <div class="col-md-2 col-xs-12">
          <asp:DropDownList ID="ddlsearchYear" runat="server" CssClass="form-control" >
                            </asp:DropDownList>
            </div>
               <div class="col-md-2 col-xs-12">
                <label>  Class of Contractor</label>
            </div>
              <div class="col-md-1 col-xs-12">
          <asp:DropDownList ID="ddlsearchClass" runat="server" CssClass="form-control">
                       <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="01">Class I</asp:ListItem>
                                <asp:ListItem Value="02">Class II</asp:ListItem>
                                <asp:ListItem Value="03">Class III</asp:ListItem>
                                <asp:ListItem Value="04">Class IV</asp:ListItem>      
          </asp:DropDownList>
           
            </div>
             <div class="col-md-2 col-xs-12">
                <label> Type of Contractor</label>
            </div>
              <div class="col-md-2 col-xs-12">
          <asp:DropDownList ID="ddlsearchType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="01">01-Individual</asp:ListItem>
                                <asp:ListItem Value="02">02-Firm</asp:ListItem>
                                <asp:ListItem Value="03">03-Company</asp:ListItem>
                                <asp:ListItem Value="04">04-Sole Proprietorship</asp:ListItem>
                                <asp:ListItem Value="05">05-UE</asp:ListItem>  
          </asp:DropDownList>
            </div>
              <div class="col-md-1 col-xs-12">
         <%--<asp:Button ID="btnShow" runat="server" Text="Show" BackColor="#ff9933"  Width="85px" ForeColor="White"  OnClick="btnShow_Click"  />--%>
                  <asp:ImageButton ID="btnShow" runat="server"   OnClick="btnShow_Click"  Width="75px"  ImageUrl="~/PMIS/images/Show.png" />
            </div>
        </div>
          
          <div class="row">
<div class="col-md-12">
    <div class="col-md-4">
    </div>
    <div class="col-md-4">
       <asp:Label ID="lblcontractor" runat="server"  Font-Bold="true"></asp:Label>
    </div>
    <div class="col-md-4"></div>
</div>
          </div>
           
                 <div class="row">
                      <div class="col-md-12">
             <fieldset>
                    <legend>
                        <h3>
                           

                        </h3>
                    </legend>
                </fieldset>
        </div>
          </div>
        <div class="row"  style="overflow-y:scroll">
      <div class="col-md-12 col-xs-12" >
                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="ContractorId,ContractorName" EmptyDataText="No Records Found" ForeColor="Black"
                        AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting"
                        PageSize="10"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1+"." %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ContractorID" HeaderStyle-BackColor="Blue" >
                                <ItemTemplate>
                                    <asp:Label ID="lblcontractorid" runat="server" Text='<%#Eval("ContractorID") %>'></asp:Label>
                                </ItemTemplate>
                                <%--  <EditItemTemplate>
                                    <asp:TextBox ID="txtcontractorid" runat="server" Text='<%#Eval("ContractorID") %>'></asp:TextBox>
                                </EditItemTemplate>--%></asp:TemplateField>
                            <asp:TemplateField HeaderText="Name of Firm / Contractor" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblContractorName" runat="server" Text='<%#Eval("ContractorName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtContractorName" runat="server" Text='<%#Eval("ContractorName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contractor Class" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblContractorClass" runat="server" Text='<%#Eval("ContractorClass") %>'></asp:Label>
                                </ItemTemplate>
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtContractorClass" runat="server" Text='<%#Eval("ContractorClass") %>'></asp:TextBox>
                                </EditItemTemplate>--%></asp:TemplateField>
                            <asp:TemplateField HeaderText="Type of Contractor<br>" HeaderStyle-BackColor="Blue">   <%--(01 for individual)<br>(02 for firm)<br>(03 for company)--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistrationType" runat="server" Text='<%#Eval("RegistrationType") %>'></asp:Label>
                                </ItemTemplate>
                                <%-- <EditItemTemplate>
                                    <asp:TextBox ID="txtRegistrationType" runat="server" Text='<%#Eval("RegistrationType") %>'></asp:TextBox>
                                </EditItemTemplate>--%></asp:TemplateField>
                            <asp:TemplateField HeaderText="Registration No." HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistrationNo" runat="server" Text='<%#Eval("RegistrationNo") %>'></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtRegistrationNo" runat="server" Text='<%#Eval("RegistrationNo") %>'></asp:TextBox>
                                </EditItemTemplate>--%></asp:TemplateField>
                            <asp:TemplateField HeaderText="Year of Registration" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistrationyear" runat="server" Text='<%#Eval("RegYear") %>'></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtRegistrationyear" runat="server" Text='<%#Eval("RegYear") %>'></asp:TextBox>
                                </EditItemTemplate>--%></asp:TemplateField>
                            <asp:TemplateField HeaderText="Letter No." HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblLetterno" runat="server" Text='<%#Eval("LetterNo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLetterno" runat="server" Text='<%#Eval("LetterNo") %>' Width="100px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Letter Date" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblLetterDate" runat="server" Text='<%#Eval("LetterDate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLetterDate" runat="server" Text='<%#Eval("LetterDate") %>' Width="70px"></asp:TextBox>
                                    <rjs:PopCalendar ID="PopCalendartxtLetterDate" runat="server" Control="txtLetterDate"
                                        Format="dd mmm yyyy" MessageAlignment="RightCalendarControl" From-Date="1950-01-01"
                                        AutoPostBack="True" />
                                    <rjs:PopCalendarMessageContainer ID="PopCalendarMessageContainertxtLetterDate" runat="server"
                                        Calendar="PopCalendar2" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Mobile" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="PAN" HeaderStyle-BackColor="Blue">
                                <ItemTemplate>
                                    <asp:Label ID="lblPan" runat="server" Text='<%#Eval("Pan") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--<asp:TextBox ID="txtPan" runat="server" Text='<%#Eval("Pan") %>'></asp:TextBox>--%>
                                </EditItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="Blue" HeaderStyle-Width="7%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_view" runat="server" CommandName="View" Font-Bold="true" Visible="false" ToolTip="Click Here To View" CommandArgument='<%#Eval("SrNo")%>'>
                                        <i class="fa fa-eye" aria-hidden="true"  style="color:cornflowerblue"></i>
                                    </asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lnk_update" runat="server" ToolTip="Click Here To Update"  CommandName="Modify" Font-Bold="true" CommandArgument='<%#Eval("SrNo")%>'>
                                          <i class="fa fa-pencil-square-o" aria-hidden="true" style="color:darkgreen"></i>
                                    </asp:LinkButton>&nbsp;&nbsp;
                                  <%--  <asp:LinkButton ID="lnk_delete" runat="server" ToolTip="Click Here To Delete" OnClientClick="javascript:return confirm('Are You Sure Want To Delete?');" CommandName="remove" Font-Bold="true" CommandArgument='<%#Eval("slno")%>'>
                                     <i class="dropdown-icon  fa fa-trash-alt" style="color:red"></i><span></span>
                                    </asp:LinkButton>--%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <%--  <asp:CommandField HeaderText="Update" ShowEditButton="True" />--%>
                            <%-- <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />--%>
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

      </div>
        </div>
        


      </div>
    </div>
      </div>
          
        </div>
       <%-- --------Modal Popup--------%>
 <%-- For Add Contractor--%>
<div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog" style="width:75%">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header" style="background-color:#D4E6F1; color:white">
                      
                        <p style="float:left; "><button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button></p>
                         <p style="float:right; font-weight:600; "><asp:LinkButton ID="btnback" Text="Back" runat="server" OnClick="btnback_Click"></asp:LinkButton></p>
                       <%-- <h4 class="modal-title" style="color:blue; font-weight:600;"><asp:Label ID="lblModalTitle" runat="server" Text=" Contractor Entry Form"></asp:Label></h4>--%>
                    </div>


                    <div class="modal-body">

                       <div class="row">
                           <h4 class="modal-title" style="color:blue; font-weight:600; text-align:center; "><asp:Label ID="lblModalTitle" runat="server" Text=" Contractor Entry Form"></asp:Label></h4>
                          <%-- <p style="float:right"><asp:LinkButton ID="btnback" Text="Back" runat="server"></asp:LinkButton></p>--%>
                           <hr style="border:1px solid grey" />
                       </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Contractor Name:</label>
                                <asp:TextBox ID="txtContractorName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Contractor Name"
                                    ControlToValidate="txtContractorName" SetFocusOnError="true" ValidationGroup="Save"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2">
                                <label>Class of Contractor:</label>
                                <asp:DropDownList ID="ddlcontractclass" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="01">Class I</asp:ListItem>
                                    <asp:ListItem Value="02">Class II</asp:ListItem>
                                    <asp:ListItem Value="03">Class III</asp:ListItem>
                                    <asp:ListItem Value="04">Class IV</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Contractor Class"
                                    ControlToValidate="ddlcontractclass" SetFocusOnError="true" InitialValue="0"
                                    ValidationGroup="Save" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2">
                                <label>Registration Type:</label>


                                <asp:DropDownList ID="ddlregtype" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="01">01-Individual</asp:ListItem>
                                    <asp:ListItem Value="02">02-Partnership Firm</asp:ListItem>
                                    <asp:ListItem Value="03">03-Company</asp:ListItem>
                                    <asp:ListItem Value="04">04-Sole Proprietorship</asp:ListItem>
                                    <asp:ListItem Value="05">05-UE</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Registration Type"
                                    ControlToValidate="ddlregtype" SetFocusOnError="true" InitialValue="0" ValidationGroup="Save"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <label>Registration No.</label>

                                <asp:TextBox ID="txtRegistration" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Registration Number"
                                    ControlToValidate="txtRegistration" SetFocusOnError="true" ValidationGroup="Save"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                           
                            <div class="col-md-2">
                                <label>Registration Year:</label>

                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Registration Year"
                                    ControlToValidate="ddlYear" SetFocusOnError="true" InitialValue="0" ValidationGroup="Save"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>

                            </div>

                            <div class="col-md-2">
                                <label>Letter No.:</label>

                                <asp:TextBox ID="txtletterno" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Letter Number"
                                    ControlToValidate="txtletterno" SetFocusOnError="true" ValidationGroup="Save"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <label>Letter Date:</label>
                                <asp:TextBox ID="txtletterdate" runat="server" TextMode="date" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <label>PAN:</label>

                                <asp:TextBox ID="txtpan" runat="server" MaxLength="12" CssClass="form-control uppercase"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <label>Debar(Y/N):</label>

                                <asp:RadioButtonList ID="rdbtndebar"  CssClass="answerBottomYesNo" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Yes &nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">No </asp:ListItem>
                                </asp:RadioButtonList>

                            </div>

                            <div class="col-md-2">
                                <label>Debar Date:</label>
                                <asp:TextBox ID="txtdebardate" TextMode="date" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>

                            <div class="col-md-2">
                                <label>BlackListed(Y/N):</label>

                                <asp:RadioButtonList ID="rdbtnblack" CssClass="answerBottomYesNo" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Yes &nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">No </asp:ListItem>
                                </asp:RadioButtonList>

                            </div>

                        </div>

                        <div class="row">
                               <div class="col-md-2">
                                <label>BlackListed Date:</label>
                                <asp:TextBox ID="txtBlackListeddate" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>

                            <div class="col-md-4">
                                <label>Remarks:</label>

                                <asp:TextBox ID="txtremarks"  runat="server" CssClass="form-control"  Style="resize: none"></asp:TextBox>

                            </div>

                            <div class="col-md-4">
                                <label>Address:</label>

                                <asp:TextBox ID="txtAddress" runat="server"  CssClass="form-control"  Style="resize: none"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="EnterFull Address"
                                    ControlToValidate="txtAddress" SetFocusOnError="true" ValidationGroup="Save"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2">
                                <label>Mobile:</label>

                                <asp:TextBox ID="txtmobileno" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                              <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Mobile Number"
                                    ControlToValidate="txtmobileno" SetFocusOnError="true" ValidationGroup="Save"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>--%>

                            </div>

                            <div class="col-md-4"></div>
                            <div class="col-md-6">
                                <asp:Button ID="btnsave" runat="server" Text="Save" Font-Bold="True"
                                    Width="75px" ValidationGroup="Save" CssClass="btn btn btn-info" OnClick="btnsave_Click" />&nbsp;&nbsp;
                   <asp:Button ID="btnreset" runat="server" Text="Reset" Font-Bold="True" CssClass="btn btn btn-danger" OnClick="btnreset_Click" Width="75px" />&nbsp;&nbsp;
                 <asp:Button ID="btnupdate" runat="server" Text="Update" Font-Bold="True"
                     Visible="false" OnClick="btnupdate_Click" CssClass="btn btn btn-warning" Width="75px" />
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Save"
                                    DisplayMode="List" Font-Bold="true" ShowMessageBox="true" ShowSummary="false" />
                            </div>
                            <div class="col-md-2"></div>




                        </div>

                    </div>



                    <div class="modal-footer">
                        <button class=" btn btn-danger" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </div>

     

       <%-- ------------end popup----------%>
 
</asp:Content>

