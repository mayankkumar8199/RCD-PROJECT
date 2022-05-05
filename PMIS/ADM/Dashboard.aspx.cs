using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

public partial class RCDPMISNEW_ADM_Default : System.Web.UI.Page
{

    //clsDataAccessRCDPMIS cls = new clsDataAccessRCDPMIS();
    clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string _DivId = Convert.ToString(Session["DivisionID"]);
        if (Session["Role"] == null)
        {
            Response.Redirect("~/PMIS/Login.aspx");
        }

        lblroadtime.Text= "Till*"+" "+ DateTime.Now.ToString("MMMM") +"  "+ DateTime.Now.Year.ToString();
        lblproject.Text= "Till*" + " " + DateTime.Now.ToString("MMMM") + "  " + DateTime.Now.Year.ToString();
        lblalotmnt.Text= "Till*" + " " + DateTime.Now.ToString("MMMM") + "  " + DateTime.Now.Year.ToString();
        lblexp.Text= "Till*" + " " + DateTime.Now.ToString("MMMM") + "  " + DateTime.Now.Year.ToString();



        if (!IsPostBack)
        {
            bindgridProj();
            BindWingsFin();
            chartbindallotment();
            chartbindExp();

            //if (Session["Role"].ToString() == "DIVADM")
            //{
            //    GetChartDatawithdivision();
            //}
            //else
            //{
            //    GetChartData1();
            //}

        }       
    }





    void bindgridProj()
    {
        SqlParameter QueryType = null;
        if (Convert.ToString(Session["Role"]) == "ADM")
        {
            QueryType = new SqlParameter("QueryType", 1);
        }
        else
        {

            QueryType = new SqlParameter("QueryType", 2);
        }

        SqlParameter wingId = new SqlParameter("@wing", Convert.ToString(Session["WingID"]));
        SqlParameter circleId = new SqlParameter("@circle", Convert.ToString(Session["CircleID"]));

        SqlParameter DivisionId = new SqlParameter("@DivisionId", Convert.ToString(Session["DivisionID"]));

        DataTable dt = cls.GetDataTableSp("Sp_Get_DashBoardDataNew", new SqlParameter[] { QueryType, wingId, circleId,DivisionId });
        int totproj = 0;
        int totroad = 0;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                totproj += Convert.ToInt32(dr["TotalProject"].ToString());
                totroad += Convert.ToInt32(dr["TotalRoad"].ToString());
            }
            totproject.InnerText = totproj.ToString();
            totalroad.InnerText = totroad.ToString();

        }
        string sqlchart = @"select    Wing.WingName, isNull(R.totalroad,0) as 'TotalRoad', isNull(P.Total,0) as 'TotalProject'  from Wing 
left outer join (select    COUNT(Projectno) as Total ,WingID from ProjectMaster group by WingID)as P on P.WingID=Wing.WingID
left outer join (select    COUNT (roadid) as totalroad,WingID from RoadMaster group by WingID) as R on R.WingID=Wing.WingID
where Wing.WingID in (1,7,2)
 order by Wing.WingName";
        DataTable dtchart = cls.GetDataTable(sqlchart);
        Chart1.DataSource = dtchart;

        string sqlchart2 = @"select     Wing.WingName, isNull(P.Total,0) as 'TotalProject',isNull(R.totalroad,0) as 'TotalRoad'  from Wing left outer join
                                 (select    COUNT(Projectno) as Total ,WingID from ProjectMaster group by WingID)as P on P.WingID=Wing.WingID left outer join
                                 (select    COUNT (roadid) as totalroad,WingID from RoadMaster group by WingID) as R on R.WingID=Wing.WingID  where Wing.WingID in (1,7,2) order by Wing.WingName";
        DataTable dtchart2 = cls.GetDataTable(sqlchart2);
        Chart2.DataSource = dtchart2;
        // Chart3.DataSource = dtchart;


        //string sqlchart3 = @"Select W.WingName, ISNULL(A.AllotedAmount,0) as AllotedAmount ,ISNULL(E.ExpAmount,0) as ExpAmount
                             
        //               from    Wing as W left outer join
        //                       (select    SUM(AllotmentAmount) as AllotedAmount,Allotment.WingID
        //               from               Allotment group by Allotment.WingID) as A on A.WingID=W.WingID  left outer  join              
        //                       (Select    sum(ExpAmount) as ExpAmount,ProjectMaster.WingID from Expenditure inner join 
        //                                  ProjectMaster on ProjectMaster.Projectno=Expenditure.Projectno   
        //                                  group by ProjectMaster.WingID)  as E on E.WingID=W.WingID";
        //DataTable dtchart3 = cls.GetDataTable(sqlchart3);
        //Chart3.DataSource = dtchart3;
    }


    //    void bindgridProj()
    //    {
    //        //string sql = @"select    Wing.WingID, Wing.WingName, isNull(R.totalroad,0) as 'TotalRoad', isNull(P.Total,0) as 'TotalProject'  from Wing left outer join
    //        //                         (select    COUNT(Projectno) as Total ,WingID from ProjectMaster group by WingID)as P on P.WingID=Wing.WingID left outer join
    //        //                         (select    COUNT (roadid) as totalroad,WingID from RoadMaster group by WingID) as R on R.WingID=Wing.WingID order by Wing.WingName";


    //        string sql = @"select count(distinct r.RoadId) as TotalRoad,count(Pm.projectno) as TotalProject from RoadMaster r 
    //inner join Wing w on w.WingID=r.WingID
    //inner join Circles c on c.CircleID=r.CircleID
    //inner join Divisions d on d.DivisionID= r.DivisionID
    //left join ProjectMaster Pm on Pm.RoadId=r.RoadId
    //where r.WingID='"+Session["WingID"].ToString()+ "' and r.CircleID='" + Session["CircleID"].ToString() + "' and r.DivisionID='" + Session["DivisionID"].ToString() + "'";

    //        DataTable dt = cls.GetDataTable(sql);
    //        int totproj = 0;
    //        int totroad = 0;
    //        if (dt.Rows.Count > 0)
    //        {
    //            foreach (DataRow dr in dt.Rows)
    //            {
    //                totproj += Convert.ToInt32(dr["TotalProject"].ToString());
    //                totroad += Convert.ToInt32(dr["TotalRoad"].ToString());
    //            }
    //            totproject.InnerText = totproj.ToString();
    //            totalroad.InnerText = totroad.ToString();

    //        }
    //        string sqlchart = @"select     Wing.WingName, isNull(R.totalroad,0) as 'TotalRoad', isNull(P.Total,0) as 'TotalProject'  from Wing left outer join
    //                                 (select    COUNT(Projectno) as Total ,WingID from ProjectMaster group by WingID)as P on P.WingID=Wing.WingID left outer join
    //                                 (select    COUNT (roadid) as totalroad,WingID from RoadMaster group by WingID) as R on R.WingID=Wing.WingID order by Wing.WingName";
    //        DataTable dtchart = cls.GetDataTable(sqlchart);
    //        Chart1.DataSource = dtchart;
    //        string sqlchart2 = @"select     Wing.WingName, isNull(P.Total,0) as 'TotalProject',isNull(R.totalroad,0) as 'TotalRoad'  from Wing left outer join
    //                                 (select    COUNT(Projectno) as Total ,WingID from ProjectMaster group by WingID)as P on P.WingID=Wing.WingID left outer join
    //                                 (select    COUNT (roadid) as totalroad,WingID from RoadMaster group by WingID) as R on R.WingID=Wing.WingID order by Wing.WingName";
    //        DataTable dtchart2 = cls.GetDataTable(sqlchart2);
    //        Chart2.DataSource = dtchart2;
    //        // Chart3.DataSource = dtchart;
    //    }


    private void chartbindallotment()
    {
        SqlParameter QueryType = null;
        if (Convert.ToString(Session["Role"]) == "ADM")
        {
            QueryType = new SqlParameter("QueryType", 1);
        }
        else
        {

            QueryType = new SqlParameter("QueryType", 2);
        }

        SqlParameter wingId = new SqlParameter("@wing", Convert.ToString(Session["WingID"]));
        SqlParameter circleId = new SqlParameter("@circle", Convert.ToString(Session["CircleID"]));

        SqlParameter DivisionId = new SqlParameter("@DivisionId", Convert.ToString(Session["DivisionID"]));

        DataTable dt = cls.GetDataTableSp("Sp_Get_DashBoardAllotment", new SqlParameter[] { QueryType, wingId, circleId, DivisionId });
        if(dt.Rows.Count > 0)
        {
            Chart3.DataSource = dt;
            //lbl_error.Visible = false;
        }
        else
        {
            Chart3.DataSource = null;
          //  lbl_error.Visible = true;
          //  lbl_error.Text = "No Data Found In Allotment....";
           
            
        }

      

       // DataTable dtchart3 = cls.GetDataTable(dt);
        //Chart3.DataSource = dt;
    }

    private void chartbindExp()
    {
        //string sqlchart4 = @"Select W.WingName, ISNULL(E.ExpAmount,0) as ExpAmount

        //               from    Wing as W left outer join
        //                       (select    SUM(AllotmentAmount) as AllotedAmount,Allotment.WingID
        //               from               Allotment group by Allotment.WingID) as A on A.WingID=W.WingID  left outer  join              
        //                       (Select    sum(ExpAmount) as ExpAmount,ProjectMaster.WingID from Expenditure inner join 
        //                                  ProjectMaster on ProjectMaster.Projectno=Expenditure.Projectno   
        //                                  group by ProjectMaster.WingID)  as E on E.WingID=W.WingID	";
        //DataTable dtchart4 = cls.GetDataTable(sqlchart4);
        SqlParameter QueryType = null;
        if (Convert.ToString(Session["Role"]) == "ADM")
        {
            QueryType = new SqlParameter("QueryType", 1);
        }
        else
        {

            QueryType = new SqlParameter("QueryType", 2);
        }

        SqlParameter wingId = new SqlParameter("@wing", Convert.ToString(Session["WingID"]));
        SqlParameter circleId = new SqlParameter("@circle", Convert.ToString(Session["CircleID"]));

        SqlParameter DivisionId = new SqlParameter("@DivisionId", Convert.ToString(Session["DivisionID"]));

        DataTable dt = cls.GetDataTableSp("Sp_Get_DashBoardExpendeture", new SqlParameter[] { QueryType, wingId, circleId, DivisionId });
        Chart4.DataSource = dt;
    }



    void BindWingsFin()// allotment
    {

        string sql = string.Empty;
        if (Session["Role"].ToString() == "ADM") {

            sql = @"Select  W.WingID,W.WingName, CONVERT(DECIMAL(10,2), ISNULL(NULLIF(A.AllotedAmount, ''), '0')) as AllotedAmount ,CONVERT(DECIMAL(10,2), ISNULL(NULLIF(E.ExpAmount, ''), '0')) as ExpAmount,
CASE WHEN ISNULL(A.AllotedAmount, 0) = 0 THEN 0 ELSE (ISNULL(E.ExpAmount, 0) * 100 / ISNULL(A.AllotedAmount, 0)) END AS PercExp
from    Wing as W left outer join
(select    SUM(AAamount) as AllotedAmount,WingID
from               ProjectMaster as p group by WingID) as A on A.WingID=W.WingID  left outer  join              
(Select    sum(Expenditureamount) as ExpAmount,WingID from FinancialProgress 
 group by WingID)  as E on E.WingID=W.WingID where W.WingID in(1,2,7)";
        }

        else if ((Session["Role"].ToString() == "DIVADM")) {
            sql = @" Select  W.DivisionID,W.DivisionName,CONVERT(DECIMAL(10,2), ISNULL(NULLIF(A.AllotedAmount, ''), '0')) as AllotedAmount ,CONVERT(DECIMAL(10,2), ISNULL(NULLIF(E.ExpAmount, ''), '0')) as ExpAmount,
                               CASE WHEN ISNULL(A.AllotedAmount, 0) = 0 THEN 0 ELSE(ISNULL(E.ExpAmount, 0) * 100 / ISNULL(A.AllotedAmount, 0)) END AS PercExp
                      from    Divisions as W left outer join
                              (select    SUM(AAamount) as AllotedAmount,DivisionId
from               ProjectMaster as p group by DivisionId) as A on A.DivisionId = W.DivisionID  left outer  join
                  (Select    sum(Expenditureamount) as ExpAmount,DivisionID from FinancialProgress 
 group by DivisionID) as E on E.DivisionId = W.DivisionID where e.DivisionId = @DivisionId";

        }
       
        DataTable dt = cls.GetDataTable(sql,new SqlParameter[] { new SqlParameter ("@DivisionId", Session["DivisionID"].ToString() ) });
       double allot = 0;
        double expamt = 0;
        double expper = 0;
        if(dt.Rows.Count>0)
        {
            foreach(DataRow dr in dt.Rows)
            {
                allot = allot+ Convert.ToDouble(dr["AllotedAmount"].ToString());
                expamt = expamt+ Convert.ToDouble(dr["ExpAmount"].ToString());
                expper = expper+ Convert.ToDouble(dr["PercExp"].ToString());
            }

        }
        allotment.InnerText = allot.ToString();
        Expenditure.InnerText = expamt.ToString();
        //percentageexpance.InnerText = expper.ToString();        
    }

    [WebMethod]
    public static List<object> GetChartData()
    {
        string sql = @"select Wing.WingName, isNull(P.Total,0) as 'TotalProject'  from Wing left outer join
                                 (select    COUNT(Projectno) as Total ,WingID from ProjectMaster group by WingID)as P on P.WingID=Wing.WingID left outer join
                                 (select    COUNT (roadid) as totalroad,WingID from RoadMaster group by WingID) as R on R.WingID=Wing.WingID where Wing.WingID in (1,7,2) order by Wing.WingName";
        string constr = ConfigurationManager.ConnectionStrings["RCDPMISNewConnectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
        {
            "WingName", "TotalProject"
        });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["WingName"], sdr["TotalProject"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    [WebMethod]
    public static List<object> GetChartData1()
    {
       

        string sql = @"select ProductName,DataItem From(select 
 sum(case when len(replace(ISNULL(rm.Average,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Average,'0.000'),'NULL','0.000') as decimal(18,3)) end) as  Average,  
sum(case when len(replace(ISNULL(rm.Bad,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Bad,'0.000'),'NULL','0.000') as decimal(18,3)) end) as Bad,  
sum(case when len(replace(ISNULL(rm.Fair,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Fair,'0.000'),'NULL','0.000') as decimal(18,3)) end )as Fair,  
sum(case when len(replace(ISNULL(rm.Good,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Good,'0.000'),'NULL','0.000')as decimal(18,3)) end )as Good 
From RoadMaster rm where Isdelete='Y') as A
UNPIVOT(
DataItem FOR ProductName IN (Good,Fair,Average,Bad))
as B ";


        string constr = ConfigurationManager.ConnectionStrings["RCDPMISNewConnectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
        {
            "ProductName","DataItem"
        });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["ProductName"], sdr["DataItem"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }
//    [WebMethod]
//    public static List<object> GetChartDatawithdivision()
//    {
//        clsDataAccessRCDPMISNEW cls = new clsDataAccessRCDPMISNEW();
//        string _divisionid = string.Empty;

//        _divisionid = HttpContext.Current.Session["DivisionID"].ToString();

//        string sql = @"select ProductName,DataItem From(select 
// sum(case when len(replace(ISNULL(rm.Average,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Average,'0.000'),'NULL','0.000') as decimal(18,3)) end) as  Average,  
//sum(case when len(replace(ISNULL(rm.Bad,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Bad,'0.000'),'NULL','0.000') as decimal(18,3)) end) as Bad,  
//sum(case when len(replace(ISNULL(rm.Fair,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Fair,'0.000'),'NULL','0.000') as decimal(18,3)) end )as Fair,  
//sum(case when len(replace(ISNULL(rm.Good,'0.000'),'NULL','0.000'))=0 then '0.000' else cast(replace(ISNULL(rm.Good,'0.000'),'NULL','0.000')as decimal(18,3)) end )as Good 
//From RoadMaster rm where Isdelete='Y' (rm.DivisionID=@DivisionID) ) as A UNPIVOT(DataItem FOR ProductName IN (Good,Fair,Average,Bad))as B ";


//        string constr = ConfigurationManager.ConnectionStrings["RCDPMISNewConnectionString"].ConnectionString;
//        List<object> chartData = new List<object>();
//        chartData.Add(new object[]
//        {
//            "ProductName","DataItem"
//        });

//        DataTable dt = cls.GetDataTable(sql,new SqlParameter[] { new SqlParameter("@DivisionID", _divisionid) });

//        if(dt.Rows.Count>0)
//        {
//            foreach (DataRow row in dt.Rows)
//            {
                
               
//            }
//        }

//            //using (SqlConnection con = new SqlConnection(constr))
//            //{
//            //    using (SqlCommand cmd = new SqlCommand(sql))
//            //    {
//            //        cmd.CommandType = CommandType.Text;
//            //        cmd.Connection = con;
//            //        con.Open();
//            //        using (SqlDataReader sdr = cmd.ExecuteReader())
//            //        {
//            //            while (sdr.Read())
//            //            {
//            //                chartData.Add(new object[]
//            //            {
//            //                sdr["ProductName"], sdr["DataItem"]
//            //            });
//            //            }
//            //        }
//            //        con.Close();
//            //        return chartData;
//            //    }
//            //}
//        }


}



