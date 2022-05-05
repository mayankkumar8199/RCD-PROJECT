using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Select
/// </summary>
public class clsDataAccessRCDPMISNEW
{
    SqlConnection con = new SqlConnection();
    public clsDataAccessRCDPMISNEW()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RCDPMISNewConnectionString"].ConnectionString;

    }

    public DataTable GetDataTable(string query)
    {
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            //con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            SqlDataAdapter adap1 = new SqlDataAdapter();
            cmd.Connection = con;
            adap1.SelectCommand = cmd;
            adap1.Fill(dt);
           return dt;
        }
        catch (Exception ex)
        {
            //return ex.Message.ToString();
            return dt;
        }

        finally
        {
            con.Close();
        }

    }

    public DataTable GetDataTableSp(string procname, SqlParameter[] param)
    {

        DataTable dt = new DataTable();
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = procname;
            if (param != null)
            {
                foreach (SqlParameter prm in param)
                {
                    cmd.Parameters.Add(prm);
                }
            }
            SqlDataAdapter adap1 = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandTimeout = 0;
            adap1.SelectCommand = cmd;
            adap1.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {

            return dt;
        }

        finally
        {
            con.Close();
        }

    }
    public DataTable GetDataTable(string query, SqlParameter[] param)
    {
        DataTable dt = new DataTable();
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            foreach (SqlParameter prm in param)
            {
                cmd.Parameters.Add(prm);
            }
            SqlDataAdapter adap1 = new SqlDataAdapter();
            cmd.Connection = con;
            adap1.SelectCommand = cmd;
            adap1.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            //return ex.Message.ToString();
            return dt;
        }

        finally
        {
            con.Close();
        }

    }

    public int ExecuteSql(string Query)
    {


        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();

            string strCommand = Query;
            cmd.CommandText = strCommand;
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            return 0;

        }

        finally
        {
            con.Close();
        }

    }



    public int ExecuteSql(string Query, SqlParameter[] param)
    {

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = Query;
            foreach (SqlParameter prm in param)
            {
                cmd.Parameters.Add(prm);
            }
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);

            return 0;
        }

        finally
        {
            con.Close();
        }
    }

    public int ExecuteSql(string Query, SqlParameter[] param, Label lblMsg)
    {

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = Query;
            foreach (SqlParameter prm in param)
            {
                cmd.Parameters.Add(prm);
            }
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            //HttpContext.Current.Response.Write(ex.Message);
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
            return 0;
        }

        finally
        {
            con.Close();
        }
    }

    public string ExecuteScalar(string strSql)
    {
        SqlCommand cmd = new SqlCommand();
        try
        {

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Connection = con;
            cmd.Connection.Open();
            return cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            cmd.Connection.Close();
            return "";
        }
        finally
        {
            cmd.Connection.Close();

        }
    }

    

    public object ExecuteScalar(string Query, SqlParameter[] param)
    {
        SqlCommand cmd = new SqlCommand();
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.Connection.Open();
            if (param != null)
            {
                foreach (SqlParameter prm in param)
                {
                    cmd.Parameters.Add(prm);
                }
            }
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            object objRet = cmd.ExecuteScalar();
            if (cmd.Connection.State == ConnectionState.Open)
                cmd.Connection.Close();

            return objRet;


        }
        catch (Exception ex)
        {
            if (cmd.Connection.State == ConnectionState.Open)
                cmd.Connection.Close();
            return null;
        }
        finally
        {
            if (cmd.Connection.State == ConnectionState.Open)
                cmd.Connection.Close();


        }
    }

    public string SaveDataSimple(string TableName, string[] ColNames, string[] ColValues)
    {
        string SQL;
        string SQL1, SQL2;

        try
        {
            con.Open();
            //SqlConnection con = new SqlConnection();
            //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SQL1 = "";
            SQL2 = "";
            for (int i = 0; i < ColNames.Length; i++)
            {
                if (SQL1.ToString() == "")
                {
                    SQL1 = ColNames[i].ToString();
                    SQL2 = "@" + ColNames[i].ToString();

                }
                else
                {
                    SQL1 = SQL1 + ", " + ColNames[i].ToString();
                    SQL2 = SQL2 + ", " + "@" + ColNames[i].ToString();
                }
                // add parameter value
                cmd.Parameters.AddWithValue("@" + ColNames[i], ColValues[i]); // (@param name, value)
            }
            string strCommand = "Insert into " + TableName + " ( " + SQL1 + " ) " + " VALUES ( " + SQL2 + " )";
            cmd.CommandText = strCommand;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            return "1";
        }
        catch (Exception ex)
        {
            return "0";

        }

        finally
        {
            con.Close();
        }

    }


}
