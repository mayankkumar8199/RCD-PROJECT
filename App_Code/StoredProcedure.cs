/*
 * This  class is used to call  stored procedure with any number of
 * parameters
 * This can also be used to maintain list of stored procedures which will execute in a sequence
*/

namespace DataAccessLayer
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Data.SqlClient;
    using System.Collections.Generic;
	/// <summary>
	/// this is used to declare and set the Param data
	/// </summary>
	
    public static class SqlParameters
    {
        // or have strongly typed overloads
        public static List<SqlParameter> Add(this List<SqlParameter> list, string paramName,object value,ParameterDirection paramDirect)
        {
            var p = new SqlParameter( paramName, Map(value.GetType()));
            p.Value = value;
            p.Direction = paramDirect;
            list.Add(p);
            return list;
        }

        private static DbType Map(Type type)
        {
            DbType dbtype = DbType.Object;
            if (type == typeof(System.String))
            {
                dbtype = DbType.String;
            }
            if (type == typeof(System.Byte))
            {
                dbtype = DbType.Byte;
            }
            if (type == typeof(System.Boolean))
            {
                dbtype = DbType.Boolean;
            }
            if (type == typeof(System.Int32))
            {
                dbtype = DbType.Int32;
            }
            return dbtype;
        }
    }

    public class SetParameter
    {
        List<SqlParameter> list = new List<SqlParameter>();

        // single parameter
        public SetParameter User(String  value)
        {
            list.Add("Username", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Pass(String value)
        {
            list.Add("UPassword", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter oPass(String value)
        {
            list.Add("OPassword", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter OutResponse(Int32 value)
        {
            list.Add("OutRes", value, System.Data.ParameterDirection.Output);
            return this;
        }
        public SetParameter UId(Byte value)
        {
            list.Add("Lid", value, System.Data.ParameterDirection.Output);
            return this;
        }
        public SetParameter UIdInp(Byte value)
        {
            list.Add("Lid", value, System.Data.ParameterDirection.Input);
            return this;
        }


        public SetParameter FstName(String fn)
        {
            list.Add("FName", fn, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter LstName(String ln)
        {
            list.Add("LName", ln, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Mobile(Decimal cn)
        {
            list.Add("Mob", cn, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Email(String email)
        {
            list.Add("Emailadd", email, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Gend(String g)
        {
            list.Add("Gen", g, System.Data.ParameterDirection.Input);
            return this;
        }

        

        public SetParameter EmpId(Byte value)
        {
            list.Add("lid", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Email(Boolean value)
        {
            list.Add("s_email", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Website(Boolean value)
        {
            list.Add("s_website", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter VSUpload(Boolean value)
        {
            list.Add("s_vs", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Adhikar(Boolean value)
        {
            list.Add("s_adhi", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter VPN(Boolean value)
        {
            list.Add("s_vpn", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter OtrIssue(String value)
        {
            list.Add("othr", value, System.Data.ParameterDirection.Input);
            return this;
        }
        public SetParameter Sum(Byte value)
        {
            list.Add("tot", value, System.Data.ParameterDirection.Input);
            return this;
        }
        // a couple of parameters together at once...
        public SetParameter AddParamToprcStoreRepData(Byte pb, Boolean pb1, Boolean pb2, Boolean pb3, Boolean pb4, Boolean pb5, String ps, Byte psum)
        {
            return EmpId(pb).Email(pb1).Website(pb2).VSUpload(pb3).Adhikar(pb4).VPN(pb5).OtrIssue(ps).Sum(psum); // re-use methods
        }

        public SetParameter AddParamToprcLoginv(String u, String p, Int32 or)
        {
            return User(u).Pass(p).OutResponse(or); 
        }
        public SetParameter AddParamToprcLogid(String u, String p, Byte l)
        {
            return User(u).Pass(p).UId(l);
        }
        public SetParameter AddParamToprcUpdPass(Byte uid, String u, String p )
        {
            return UIdInp(uid).oPass(u).Pass(p);
        }
        public SetParameter AddParamToprcResetPass(String u, String p)
        {
            return User(u).Pass(p);
        }
        public SetParameter AddParamToprcUpdUserDetails(Byte uid, String a, String b, Decimal c, String d, String e)
        {
            return EmpId(uid).FstName(a).LstName(b).Mobile(c).Email(d).Gend(e);
        }
        

        public SqlParameter[] ToArray()
        {
            return list.ToArray();
        }
    }
    
    public class StoredProcedure
	{
		private string sProcName;
		private ArrayList sParams=new ArrayList();
		/// <summary>
		/// set the parameters
		/// </summary>
		/// <param name="pName"></param>
		/// <param name="pDataType"></param>
		/// <param name="pValue"></param>
		/// <returns></returns>
		/// 
		
		
			
		public string ProcName
		{
			get 
			{ 
				return sProcName; 
			}
			set 
			{
				sProcName = value; 
			}
		}       
	
	}
	/// <summary>
	/// This class used to mailtain the collection of stored procedures
	/// </summary>
	
		   
    







     

}
