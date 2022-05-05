<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/WebsiteMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="RCDPMISNEW_Default" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="container-fluidd">
        <div class="row">
            <div class="col-md-12 slider-section">

                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">

                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                        <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                         <li data-target="#carousel-example-generic" data-slide-to="4"></li>
                         <li data-target="#carousel-example-generic" data-slide-to="5"></li>

                    </ol>

                     <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">

                         <div class="item active ">
                            <img src="RCDcss/Images/B1.jpg" alt="..." />
                            <div class="carousel-caption caption-text">
                                <%-- <p style="background-color: #000; padding: 10px 0; opacity: 0.7; font-size: 28px; margin-top: -20px;">Engineering College, Purnea</p>--%>
                            </div>
                        </div>
                        <div class="item ">
                            <img src="RCDcss/Images/B2.jpg" alt="..." style="height:450px;" />
                            <div class="carousel-caption caption-text">
                                <%-- <p style="background-color: #000; padding: 10px 0; opacity: 0.7; font-size: 28px; margin-top: -20px;">Engineering College, Purnea</p>--%>
                            </div>
                        </div>
                        <div class="item ">
                            <img src="RCDcss/Images/B13.jpg" alt="..." style="height:450px;" />
                            <div class="carousel-caption caption-text">
                                <%-- <p style="background-color: #000; padding: 10px 0; opacity: 0.7; font-size: 28px; margin-top: -20px;">Engineering College, Purnea</p>--%>
                            </div>
                        </div>
                         <div class="item ">
                            <img src="RCDcss/Images/banner1.jpg" alt="..." />
                            <div class="carousel-caption caption-text">
                                <%-- <p style="background-color: #000; padding: 10px 0; opacity: 0.7; font-size: 28px; margin-top: -20px;">Sabhyata Dwar, Patna</p>--%>
                            </div>
                        </div>
                        <div class="item ">
                            <img src="RCDcss/Images/banner2.png" alt="..." />
                            <div class="carousel-caption caption-text">
                                <%-- <p style="background-color: #000; padding: 10px 0; opacity: 0.7; font-size: 28px; margin-top: -20px;">Bihar Museum, Patna</p>--%>
                            </div>
                        </div>
                        <div class="item ">
                            <img src="RCDcss/Images/banner3.jpg" alt="..." />
                            <div class="carousel-caption caption-text">
                                <%-- <p style="background-color: #000; padding: 10px 0; opacity: 0.7; font-size: 28px; margin-top: -20px;">Bapu Sabhagar Gyan Bhawan, Patna</p>--%>
                            </div>
                        </div>

                    <%--    <div class="item ">
                            <img src="RCDcss/Images/banner1.jpg" alt="..." style="height:450px;"/>
                            <div class="carousel-caption">
                            </div>
                        </div>--%>




                    </div>

                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>


                </div>

            </div>
            <%--Login Panel --%>
        
        </div>
    </div>






    <section class="homepage-blog ptb ptb-xs ptb-sm-60">
        <div class="container-fluid">

            <div class="head_block text-center">
                <h2 style="padding-top:10px;">About us</h2>
            </div>
            <div class="row blog-wrap-home">
                <div class="col-sm-12 col-md-12 pr-0 pr-xs-15 tb-cell">
                    <div class="blog-listing-inner blog-listing-left mb-xs-30  " style="min-height: 244px">
                        <%-- <div class="col-md-2">
                            <img src="images/OBJECTIVE.jpg" class="img-responsive" style="margin-top: 30px;" />
                        </div>--%>

                        <div class="col-md-12">
                            <div class="blog-content-info">
                                <h4>RCD</h4>
                                <span class="sub-heading">Road Construction Department</span>
                                <p>
                                    Road Construction Department as a premier works department of Government of Bihar conducts planning, designing, construction, improvement, strengthening and maintenance of roads and bridges,including flyovers, ROBs and elevated corridors.<br />
                                   <%-- <br />

                                    Road Construction Department as a premier works department of Government of Bihar conducts planning, designing, construction, improvement, strengthening and maintenance of roads and bridges,including flyovers, ROBs and elevated corridors.<br />
                                    <br />
                                    Road Construction Department as a premier works department of Government of Bihar conducts planning, designing, construction, improvement, strengthening and maintenance of roads and bridges,including flyovers, ROBs and elevated corridors.--%>
                                </p>
                                <p>

                                    <br />
                                    <%-- <input type="submit" name="ctl00$ContentPlaceHolder1$btnReqForPorposal" value="REQUEST FOR PROPOSAL..." id="ContentPlaceHolder1_btnReqForPorposal" class="btn btn-info btn-perspective" style="border: groove" />--%>
                                </p>
                                <h4 style="padding-top: 5px;">RCD Vision</h4>
                                <span class="sub-heading">Road Construction Department Vision</span>
                                <p>
                                    The vision of Road Construction Department is-
Linking State capital with 2/4-lane highways to all the districts so as to reach Patna within 5 hours from the farthest destination.<br />




                                    2-Laning (7.00m) of all single lane/intermediate lane State Highways.
Widening to Intermediate Lane (5.50m) of all single lane Major District Roads.
                                  
                                </p>

                            </div>
                        </div>
                    </div>

                </div>

            </div>



        </div>
    </section>



   <%-- <section class="detailwrap ptb ptb-xs ptb-sm-60">
        <div class="container-fluid">
            <!--<div class="head_block text-center">
                <h2>About us</h2>
            </div>-->
            <div class="row">
                <div class="col-md-4">
                    <div class="blog-section">

                        <div class="right-content" style="padding-top: 5px;">
                            <img src="Images/FrameWorkPMIS.png" style="width: 300px; height: 220px;" alt="" title="" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="blog-section">
                        <img src="Images/about_icon.png" class="img-left" alt="" title="" />
                        <div class="right-content">
                            <h3 class="title-blog">PMIS</h3>
                            <p>A complete project management of construction & maintenance works and information system with creative reporting at a glance in any stage.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="blog-section">
                        <img src="Images/object_icon.png" class="img-left" alt="" title="" />
                        <div class="right-content">
                            <h3 class="title-blog">Objects</h3>
                            <p>Objects to help track progress on all of the initiatives, it is providing a phase and gate framework to ensure that all of the process, audit, quality, etc.</p>
                        </div>
                    </div>
                </div>

            </div>



        </div>
    </section>--%>

    <div id="ForgetPassword_BSBCCL" class="modal fade">
        <div class="modal-dialog " style="height: 200px; margin-top: 100px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title">NEW / FORGET PASSWORD                                                    
                    </h4>
                </div>
                <div class="modal-body">

                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>UserName / ID</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$txtBSBCCLForgetUserID" type="text" id="ContentPlaceHolder1_txtBSBCCLForgetUserID" class="textboxFont form-control" autocomplete="off" />
                                <span id="ContentPlaceHolder1_RequiredFieldValidator12" style="display: none;"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>Mobile Number</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$txtBSBCCLForgetmobileno" type="text" maxlength="10" id="ContentPlaceHolder1_txtBSBCCLForgetmobileno" class="textboxFont form-control" pattern="[0-9]{10}" onkeypress="return onlyNumbers(event)" autocomplete="off" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-1 col-md-offset-6">
                                <label>OR</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>EmailID</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$txtBSBCCLForgetemailid" id="ContentPlaceHolder1_txtBSBCCLForgetemailid" class="textboxFont form-control" autocomplete="off" type="email" />
                                <span id="ContentPlaceHolder1_AtLeastOneContact" style="display: none;"></span>
                                <span id="ContentPlaceHolder1_RegularExpressionValidator2" style="display: none;"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>Captcha Code</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$TxtBSBCCLcaptcha" type="text" id="ContentPlaceHolder1_TxtBSBCCLcaptcha" class="textboxFont form-control" autocomplete="off" />
                                <span id="ContentPlaceHolder1_RequiredFieldValidator1" style="display: none;"></span>
                            </div>
                        </div>
                        <div id="ContentPlaceHolder1_UP1">

                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-4">
                                    <img id="ContentPlaceHolder1_imgCaptchaBSBCCL" class="col-md-12" src="GenerateCaptcha2ab7.jpg?637489869415684452" />
                                </div>
                                <div class="col-md-3">
                                    <input type="image" name="ctl00$ContentPlaceHolder1$imgRefreshBSBCLL" id="ContentPlaceHolder1_imgRefreshBSBCLL" src="images/refresh.png" src="#" style="width: 40px;" />
                                </div>
                            </div>

                        </div>

                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-4" style="margin-top: 25px">
                                <input type="submit" name="ctl00$ContentPlaceHolder1$btn_BSBCCLResetPassword" value="Submit" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl00$ContentPlaceHolder1$btn_BSBCCLResetPassword&quot;, &quot;&quot;, true, &quot;BSBCCLForgetP&quot;, &quot;&quot;, false, false))" id="ContentPlaceHolder1_btn_BSBCCLResetPassword" class="btn btn-2 btn-2b pull-right" />
                                <div id="ContentPlaceHolder1_ValidationSummary2" style="color: Red; display: none;">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <!------ forget Password modal----->
    <div id="ForgetPassword_BCD" class="modal fade">
        <div class="modal-dialog " style="height: 200px; margin-top: 100px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title">NEW / FORGET PASSWORD                                                    
                    </h4>
                </div>
                <div class="modal-body">

                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>UserName / ID</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$txtBCDForgetUserID" type="text" id="ContentPlaceHolder1_txtBCDForgetUserID" class="textboxFont form-control" autocomplete="off" />
                                <span id="ContentPlaceHolder1_RequiredFieldValidator1BCD2" style="display: none;"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>Mobile Number</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$txtBCDForgetmobileno" type="text" maxlength="10" id="ContentPlaceHolder1_txtBCDForgetmobileno" class="textboxFont form-control" pattern="[0-9]{10}" onkeypress="return onlyNumbers(event)" autocomplete="off" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-1 col-md-offset-6">
                                <label>OR</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>EmailID</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$txtBCDForgetemailid" id="ContentPlaceHolder1_txtBCDForgetemailid" class="textboxFont form-control" autocomplete="off" type="email" />
                                <span id="ContentPlaceHolder1_CustomValidator1" style="display: none;"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-1">
                                <label>Captcha Code</label>
                            </div>
                            <div class="col-md-6">
                                <input name="ctl00$ContentPlaceHolder1$TxtBCDcaptcha" type="text" id="ContentPlaceHolder1_TxtBCDcaptcha" class="textboxFont form-control" autocomplete="off" />
                                <span id="ContentPlaceHolder1_RequiredFieldValidatorBCD1" style="display: none;"></span>
                            </div>
                        </div>
                        <div id="ContentPlaceHolder1_UP1x">

                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-4">
                                    <img id="ContentPlaceHolder1_imgCaptchaBCD" class="col-md-12" src="GenerateCaptcha2ab7.jpg?637489869415684452" />
                                </div>
                                <div class="col-md-3">
                                    <input type="image" name="ctl00$ContentPlaceHolder1$imgRefreshBCD" id="ContentPlaceHolder1_imgRefreshBCD" src="images/refresh.png" src="#" style="width: 40px;" />
                                </div>
                            </div>

                        </div>

                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-4" style="margin-top: 25px">
                                <input type="submit" name="ctl00$ContentPlaceHolder1$btn_BCDResetPassword" value="Submit" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl00$ContentPlaceHolder1$btn_BCDResetPassword&quot;, &quot;&quot;, true, &quot;BCDForgetP&quot;, &quot;&quot;, false, false))" id="ContentPlaceHolder1_btn_BCDResetPassword" class="btn btn-2 btn-2b pull-right" />
                                <div id="ContentPlaceHolder1_ValidationSummaryBCD2" style="color: Red; display: none;">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <!----Sign Up Modal BCL---->
    <div id="Signup_BCL" class="modal fade">
        <div class="modal-dialog " style="height: 200px; margin-top: 100px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title">SIGNUP                                                    
                    </h4>
                </div>
                <div class="modal-body" style="padding-left: 32%; padding-top: 61px; padding-bottom: 70px; text-align: center">

                    <div style="float: left; text-align: center">
                        <a id="ContentPlaceHolder1_lnk_ContractorBCL" class="buttonY" href="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl00$ContentPlaceHolder1$lnk_ContractorBCL&quot;, &quot;&quot;, false, &quot;&quot;, &quot;/ContractorRegistration.aspx&quot;, false, true))">As Contractor</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

   


    <!----Sign Up Modal BCD---->
    <div id="Signup_BCD" class="modal fade">
        <div class="modal-dialog " style="height: 200px; margin-top: 100px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title">SIGNUP                                                    
                    </h4>
                </div>
                <div class="modal-body" style="padding-left: 14%; padding-top: 61px; padding-bottom: 70px;">
                    <div style="float: left;">
                        <a id="ContentPlaceHolder1_LinkButton1" class="button" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$LinkButton1&#39;,&#39;&#39;)">As Department</a>
                    </div>
                    <div style="float: left; padding-left: 10px;">
                        <a id="ContentPlaceHolder1_LinkButton2" class="buttonY" href="javascript:__doPostBack(&#39;ctl00$ContentPlaceHolder1$LinkButton2&#39;,&#39;&#39;)">As Contractor</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!----Instruction for employees BCD ------->

   <%-- <div id="instructions_BCD" class="modal fade">
        <div class="modal-dialog " style="height: 200px; margin-top: 100px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title">INSTRUCTIONS                                                 
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div style="text-align: left; color: black; line-height: 20px; text-align: justify;">
                            <p>Three types of users have access the application</p>


                            <p>1. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	BCD Employees</p>
                            <p>2. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	Circle</p>
                            <p>3. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	Departments</p>

                            <p>4. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	Contractor</p>
                            <p>To access, use PMIS Id and password. </p>
                            <br />
                            <p><a href="Searchemployee.html">Check ! Are you registered with PMIS ?</a> </p>

                            <p>If No, please contact to your IT department in 0612-2545491</p>


                            <p>Follow the process to get password :</p>

                            <p>Click on the New/Forgot Password link.</p>
                            <br />
                            <p>Enter the PMIS Id as provided from office.</p>
                            <br />
                            <p>Enter the Email Id or Mobile Number or both which is registered in PMIS.</p>
                            <br />
                            <p>Click on Reset Button.</p>
                            <br />
                            <p>Password will be sent to your Mobile number and Email Id.</p>
                            <br />

                            <p>For any other assistance, Please get in touch with the PMIS helpdesk:</p>

                            <p>bcdpmis@gmail.com</p>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <button id="btnLogin" type="button" class="btn btn-success form-control" style="display: none" data-toggle="modal" data-target="#LoginModal"></button>
    <%--<div id="LoginModal" class="modal fade">
        <div class="modal-dialog" style="width: 400px; height: 200px; margin-top: 200px">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: brown; color: whitesmoke">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="color: white">
                        ×</button>
                    <h4 class="modal-title">Login Panel :                                                    
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="col-lg-12">
                        <span id="ContentPlaceHolder1_lblInstruction">Note: Clients are requested to contact IT department of BSBCCL in : +91 9534600013 for User Id and Password.</span>
                    </div>
                    <br />



                    <div class="form-horizontal">
                        <div class="form-group" style="margin-top: 20px">
                            <div class="col-lg-12">
                                <input name="ctl00$ContentPlaceHolder1$txtUserName" type="text" id="ContentPlaceHolder1_txtUserName" class="textboxFont form-control" placeholder="Client User Name" />
                            </div>
                        </div>
                        <br />
                        <div class="form-group">
                            <div class="col-lg-12">
                                <input name="ctl00$ContentPlaceHolder1$txtPassword" type="password" id="ContentPlaceHolder1_txtPassword" class="textboxFont form-control" placeholder="Password" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-4 col-lg-offset-4" style="margin-top: 25px">
                                <input type="submit" name="ctl00$ContentPlaceHolder1$btnLoginVerify" value="Submit" id="ContentPlaceHolder1_btnLoginVerify" class="btn btn-danger" style="width: 100%;" />
                            </div>
                            <div class="form-group">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

</asp:Content>

