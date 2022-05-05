<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="RCDPMISNEW_ADM_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                title: 'Total Project Details'
            };
            options.is3D = true;
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.PieChart($("#chart")[0]);                    
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

     <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            
            var options = {
                title: 'Road Status Details'
            };            
            options.is3D = true;
            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetChartData1",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                   
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.PieChart($("#chart5")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script> 


    <style type="text/css">
        .shadow {
            -webkit-box-shadow: 3px 3px 5px 6px #ccc; /* Safari 3-4, iOS 4.0.2 - 4.2, Android 2.3+ */
            -moz-box-shadow: 3px 3px 5px 6px #ccc; /* Firefox 3.5 - 3.6 */
            box-shadow: 3px 3px 5px 6px #ccc; /* Opera 10.5, IE 9, Firefox 4+, Chrome 6+, iOS 5 */
        }
    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section>
      <div class="container-fluid" style="padding-top:16px;">
          <div class="row">
              <div class="col-lg-12">
                  <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12 ">
                            <div class="card card-stats card-Border-danger ">
                                <div class="card-header card-header-danger card-header-icon">
                                    <div class="card-icon" style="background:#fff;background-color:#fff;color:#2755A5!important; border: 2px solid #c37575; border-radius: 8px;">
                                        <%-- <a href="#" data-toggle="modal" data-target="#HighwaysModel"><i class="fa fa-road" style="color:#2755A5!important;height:35px!important;width:35px;"></i></a>--%>
                                     <img src="../images/roadicon.png" style="width:40px; height:auto" class="img img-responsive" />
                                    </div>
                                    <p class="card-category">Total Roads</p>
                                    <h3 class="card-title"><span style="color: #ff0000">*</span><span id="totalroad" runat="server"></span>&nbsp;<small></small>
                                    </h3>
                                </div>
                                <div class="card-footer">
                                    <div class="stats" style="width: 100%">
                                        <div style="width: 30%">
                                            <a href="javascript:"></a>&nbsp;
                                        </div>
                                        <%--<div style="float: right; text-align: right; width: 70%">(Since August 2021)</div>--%>
                                        <div style="float: right; text-align: right; width: 70%"><asp:Label ID="lblroadtime" runat="server"></asp:Label></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                  <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                            <div class="card card-stats card-Border-info zoom-end">
                                <div class="card-header card-header-info card-header-icon">
                                    <div class="card-icon" style="background:#fff;background-color:#fff; border: 2px solid #6d9bcc; border-radius: 8px;">                                        
                                        <img src="../images/a1.jpg" style="width:40px; height:auto" class="img img-responsive" />                                      
                                    </div>
                                    <p class="card-category">Total Projects</p>
                                    <h3 class="card-title"><span style="color: #ff0000">*</span><span id="totproject" runat="server"></span><small> &nbsp;</small>
                                    </h3>

                                </div>
                                <div class="card-footer">
                                    <div class="stats" style="width: 100%">
                                        <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                            
                                            <a href="javascript:" ></a>
                                        </div>
                                       <%-- <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12" style="float: right; text-align: right;">(Since August 2021)</div>--%>
                                         <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12" style="float: right; text-align: right;"><asp:Label ID="lblproject" runat="server"></asp:Label></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                  <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                            <div class="card card-stats card-Border-success zoom-end">
                                <div class="card-header card-header-success card-header-icon">
                                    <div class="card-icon" style="background:#fff;background-color:#fff; border: 2px solid #88c375; border-radius: 8px;">
                                        <img src="../images/p2.png" style="width:40px; height:auto"  class="img img-responsive" /> 
                                    </div>
                                    <p class="card-category">Total Allotment</p>
                                    <h3 class="card-title"><span style="color: #ff0000">₹</span><span id="allotment" runat="server"></span> &nbsp;<small>Lakh</small></h3>
                                </div>
                                <div class="card-footer">
                                    <div class="stats" style="width: 100%" >
                                         <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                        <a href="javascript:" ></a>
                                    </div>
                                     <%-- <div style="float: right; text-align: right; width: 70%">(Since July-2021)</div>--%>
                                         <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12" style="float: right; text-align: right;"><asp:Label ID="lblalotmnt" runat="server"></asp:Label></div>
                                   <%-- <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12" style="float: right; text-align: right;">(Since August 2021)</div>--%>
                                      </div>
                                </div>
                            </div>
                        </div>
                  <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                            <div class="card card-stats card-Border-warning zoom">
                                <div class="card-header card-header-warning card-header-icon">
                                    <div class="card-icon" style="background:#fff;background-color:#fff; border: 2px solid #c58c5b; border-radius: 8px;">
                                        <%--<img src="../images/roadicon.png" style="height:25px; width:auto" class="img img-responsive" />--%>
                                      <img src="../images/p3.png" style="width:40px; height:auto" class="img img-responsive" /> 
                                    </div>
                                    <p class="card-category">Total Expenditure</p>
                                    <h3 class="card-title"><span style="color: #ff0000">₹</span><span style="color: #ff0000"></span><span id="Expenditure" runat="server"></span>&nbsp;<small>Lakh</small></h3>
                                </div>
                                <div class="card-footer">
                                    <div class="stats" style="width: 100%">
                                        <div style="width: 30%">
                                            <a href="javascript:"></a>
                                        </div>
                                       <%-- <div style="float: right; text-align: right; width: 70%">(Since August 2021)</div>--%>
                                         <div style="float: right; text-align: right; width: 70%"><asp:Label ID="lblexp" runat="server"></asp:Label></div>
                                    </div>
                                </div>
                            </div>
                        </div>                  
              </div> <div class="clearfix"></div>
              <div class="col-lg-12">
                  <%--<div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                            <div class="card card-stats card-Border-warning zoom-end">
                                <div class="card-header card-header-warning card-header-icon">
                                    <div class="card-icon" style="background:#fff;background-color:#fff; border: 2px solid #88c375; border-radius: 8px;">
                                        
                                        <img src="Image/TOP/vahan.png" class="img img-responsive">
                                    </div>
                                    <p class="card-category">% of Expenditure</p>
                                    <h3 class="card-title"><span id="Span1" runat="server"></span><span id="percentageexpance" runat="server"></span> &nbsp;<small></small></h3>
                                </div>
                                <div class="card-footer">
                                    <div class="stats" style="width: 100%">
                                        <a href="javascript:" ></a>
                                    </div>
                                    <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12" style="float: right; text-align: right;">(Since Dec-2020)</div>
                                </div>
                            </div>
                        </div>--%>
              </div>
              </div>
              <div class="clearfix"></div>


          <div class="row">
             <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">                    
                         <asp:Chart ID="Chart2" runat="server" CssClass="shadow" Height="350px" Width="300px">
                          <Series>
                              <asp:Series Name="Series1" XValueMember="0" YValueMembers="2" Color="Pink" >
                              </asp:Series>
                          </Series>
                          <ChartAreas>
                              <asp:ChartArea Name="ChartArea1" BackColor="" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true" Area3DStyle-PointDepth="10">
                                  <AxisX Title="Wing Name">
                        </AxisX>
                        <AxisY Title="Total Road">
                        </AxisY>
                                  <Area3DStyle />
                              </asp:ChartArea>
                                   </ChartAreas>
                      </asp:Chart>                                            
                  </div>
                  <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                      <asp:Chart ID="Chart1" runat="server" CssClass="shadow" Height="350px" Width="300px" ToolTip="Wing Name">
                          <Series>
                              <asp:Series Name="Series1" XValueMember="0" YValueMembers="2">
                              </asp:Series>
                          </Series>
                          <ChartAreas>
                              <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true">
                                  <AxisX Title="Wing Name">
                        </AxisX>
                        <AxisY Title="Total Project">
                        </AxisY>
                                  <Area3DStyle />
                              </asp:ChartArea>
                                   </ChartAreas>
                      </asp:Chart>
                     
                  </div>
                  
                
                 

                  <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                      <asp:Chart ID="Chart3" runat="server" CssClass="shadow" Height="350px" Width="300px" ToolTip="Allotment Vs Expenditure">
                          <Series>
                              <asp:Series Name="Series1" XValueMember="0" YValueMembers="1"  Color="red">
                              </asp:Series>
                          </Series>
                          <ChartAreas>
                              <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true" Area3DStyle-PointDepth="10">
                                  <AxisX Title=" Wing Name ">                                      
                        </AxisX>

                        <AxisY Title=" Allotment Amount">
                        </AxisY>
                                  <AxisY2 Title="testing"></AxisY2>
                                  <Area3DStyle />
                              </asp:ChartArea>
                                   </ChartAreas>
                          
                      </asp:Chart>
                  <%--   <asp:Label ID="lbl_error" runat="server" Visible="false"></asp:Label>--%>
                  </div>

                  <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                      <asp:Chart ID="Chart4" runat="server" CssClass="shadow" Height="350px" Width="300px" ToolTip="Allotment Vs Expenditure">
                          <Series>
                              <asp:Series Name="Series1" XValueMember="0" YValueMembers="1"  Color="green">
                              </asp:Series>
                          </Series>
                          <ChartAreas>
                              <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true" Area3DStyle-IsClustered="true" Area3DStyle-PointDepth="10">
                                  <AxisX Title="Wing Name ">                                      
                        </AxisX>
                        <AxisY Title=" Expenditure Amount">
                        </AxisY>
                                  <AxisY2 Title="testing"></AxisY2>
                                  <Area3DStyle />
                              </asp:ChartArea>
                                   </ChartAreas>
                      </asp:Chart>
                     
                  </div>
                  

          
               </div>
             
              <div class="row" style="padding-top:15px;">
                 
                <div class="col-lg-6 col-md-6  col-xs-12">                  
                         <div id="chart" class="shadow" >
                    </div>                 
              </div>
               

           <div class="col-lg-6 col-md-6  col-xs-12">                  
                         <div id="chart5" class="shadow" >
                    </div>                 
              </div>
          </div>
        
     
          </div>
          
  </section>
</asp:Content>
