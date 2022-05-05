using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class IMapMobile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        GoogleMapForASPNet1.GoogleMapObject.APIKey = ConfigurationSettings.AppSettings["GAPIKey"];

        GoogleMapForASPNet1.GoogleMapObject.Width = "100%";
        GoogleMapForASPNet1.GoogleMapObject.Height = "800px";
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = 9;
        GoogleMapForASPNet1.GoogleMapObject.MapType = GoogleMapType.HYBRID_MAP;
        // GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("c", 25.601902, 85.111084);
        /*   GooglePolygon gp = new GooglePolygon();
         double wid = 0.01;
         gp.Points.Add(new GooglePoint("1", 25.601902 - wid, 85.111084 - wid));
         gp.Points.Add(new GooglePoint("2", 25.601902 - wid, 85.111084 + wid));
         gp.Points.Add(new GooglePoint("4", 25.601902 + wid, 85.111084 + wid));
         gp.Points.Add(new GooglePoint("3", 25.601902 + wid, 85.111084 - wid));
         gp.Points.Add(new GooglePoint("5", 25.601902 - wid, 85.111084 - wid));
         gp.FillOpacity = 0;
         gp.StrokeWeight = 4;

         GoogleMapForASPNet1.GoogleMapObject.Polygons.Add(gp);
         */
        GoogleMapForASPNet1.GoogleMapObject.Points.Clear();
        GoogleMapForASPNet1.GoogleMapObject.Width = "100%";

        //DataTable dt = new clsDataAccessRCDPMIS().GetDataTable(@"SELECT slno, Latitude, longitude, Remarks, EntryBy, EntryDate, UploadDate, Photo1 FROM  UploadData WHERE  slno = '" + Request.QueryString["slno"].ToString() + "' ");

        //            DataTable dt = new clsDataAccessRCDPMIS().GetDataTable(@"SELECT     UploadData.slno, UploadData.Latitude, UploadData.Longitude, UploadData.Remarks, UploadData.EntryBy, UploadData.Entrydate, UploadData.UploadDate, 
        //                               UploadData.Photo1, ProjectMaster.ProjectName, UploadData.ProjectNo, RaodMaster.RoadName
        //                               FROM         UploadData INNER JOIN
        //                                            ProjectMaster ON UploadData.ProjectNo = ProjectMaster.Projectno INNER JOIN
        //                                            RaodMaster ON ProjectMaster.RoadId = RaodMaster.RoadId WHERE  UploadData.slno = '" + Request.QueryString["slno"].ToString() + "' ");
        DataTable dt = new clsDataAccessRCDPMIS().GetDataTable(@"SELECT     UP.Id, UP.slno, UP.ProjectNo, UP.PhotoTypeId, UP.Photo1, UP.Photo2, UP.Latitude, 
                                                                            UP.Longitude, UP.entrydate, P.ProjectName, R.RoadName, UD.Remarks
                                                                 FROM       UploadPhoto as UP INNER JOIN
                                                                            ProjectMaster as P ON UP.ProjectNo = P.Projectno INNER JOIN
                                                                            RaodMaster as R ON P.RoadId = R.RoadId INNER JOIN
                                                                            UploadData as UD ON UP.slno = UD.slno AND UP.ProjectNo = UD.ProjectNo 
                                                                 WHERE      UP.Id = '" + Request.QueryString["slno"].ToString() + "' ");
        if (dt.Rows.Count > 0)
        {

            DataRow dr = dt.Rows[0];

            if (dr["Latitude"] != DBNull.Value & dr["Longitude"] != DBNull.Value & dr["Latitude"].ToString() != "0.0" & dr["Longitude"].ToString() != "0.0" & dr["slno"] != DBNull.Value)
            {
                //GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("c", Double.Parse(dr["Latitude"].ToString()), Double.Parse(dr["Longitude"].ToString()));
                string desc = "<div style=\"overflow:scroll;height:300px;text-align:left;\">";
                double latitude = 0.0, longitude = 0.0;
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (dr1["Latitude"] != DBNull.Value && dr1["Longitude"] != DBNull.Value && dr1["slno"].ToString().Equals(Request.QueryString["slno"].ToString()))
                    {
                        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("c", Double.Parse(dr["Latitude"].ToString()), Double.Parse(dr["Longitude"].ToString()));
                        latitude = Double.Parse(dr1["Latitude"].ToString());
                        longitude = Double.Parse(dr1["Longitude"].ToString());
                    }

                    desc += "<table><tr><td rowspan=2><table><tr><td>Road Name : " + dr1["RoadName"].ToString() + "</td></tr><tr><td>Project No.: " + dr["ProjectNo"].ToString() + "</td></tr><tr><td>Project Name: " + dr["ProjectName"].ToString() + "</td></tr><tr> <tr><td>Remarks: " + dr["Remarks"].ToString() + "</td></tr></table></td><td><img height='200px' width='200px' src='ImageHandler.aspx?slno=" + dr["Id"].ToString() + "&P=1'/></td><td><img height='200px' width='200px' src='ImageHandler.aspx?slno=" + dr["Id"].ToString() + "&P=2'/></td></tr></table>";
                    //    desc += "<tr><td><img height='200px' width='200px' src='ImageHandler.aspx?slno=" + dr1["slno"].ToString() + "&P=3'/></td><td><img height='200px' width='200px' src='ImageHandler.aspx?slno=" + dr1["slno"].ToString() + "&P=4'/></td></tr></table>";
                }
                desc += "</div>";
                //GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("c", latitude, longitude);
                GoogleMapForASPNet1.GoogleMapObject.Points.Add(new GooglePoint("1", Convert.ToDouble(dr["Latitude"]), Convert.ToDouble(dr["Longitude"]), "", desc, dr["Id"].ToString(), false));

            }

        }

    }



    private void WinOpen(String msg)
    {
        Label lbl = new Label();
        lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.open('" + msg + "','name','type=letf=210,top=80,width=500,resizable=yes,height=550,toolbar=0,addressbar =0, scrollbars=yes')</script>";

        Page.Controls.Add(lbl);

    }



}
