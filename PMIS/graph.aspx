<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/SiteMaster.master" AutoEventWireup="true" CodeFile="graph.aspx.cs" Inherits="PMIS_graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class=" col-lg-6 col-md-6 col-sm-6 col-xs-12" style="padding: 0 2.5px!important;">
                                <div class="boxmarging">
                                    <div class="heading red">
                                        <h2><i class="fa fa-road"></i>&nbsp;&nbsp;Highway Construction Progress (Km. in CFY)</h2>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div id="ChartHighways_BottomRight_New" class="chartdiv"></div>
                                </div>
                            </div>
</asp:Content>

