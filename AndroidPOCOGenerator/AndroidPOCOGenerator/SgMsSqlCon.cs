using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AndroidPOCOGenerator
{
    public sealed class SgMsSqlCon
    {
        private static readonly SgMsSqlCon instance = new SgMsSqlCon();
        static SgMsSqlCon() { }
        private SgMsSqlCon() { }

        public static SgMsSqlCon Instance { get { return instance; } }

        public SqlConnection Con { get; set; }

        public static bool Connect(string server,string user, string pass, bool integrated, string catalog)
        {
            
            try
            {
                bool res = false;
                if (SgMsSqlCon.instance.Con == null)
                {
                    SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
                    scb.UserID = user;
                    scb.Password = pass;
                    scb.IntegratedSecurity = integrated;
                    scb.DataSource = server;
                    scb.InitialCatalog = catalog;

                    SgMsSqlCon.instance.Con = new SqlConnection();
                    SgMsSqlCon.instance.Con.ConnectionString = scb.ConnectionString;
                    SgMsSqlCon.instance.Con.Open();
                    res = true;
                }
                else
                {
                    if (SgMsSqlCon.instance.Con.State != ConnectionState.Open)
                    {
                        SqlConnectionStringBuilder scb = new SqlConnectionStringBuilder();
                        scb.UserID = user;
                        scb.Password = pass;
                        scb.IntegratedSecurity = integrated;
                        SgMsSqlCon.instance.Con.ConnectionString = scb.ConnectionString;
                        scb.InitialCatalog = catalog;
                        SgMsSqlCon.instance.Con.Open();
                        res = true;
                    }
                    else
                    {
                        res = true;
                    }
                }

                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetData(string select)
        {
            try
            {
                if (!string.IsNullOrEmpty(select))
                {
                    
                    DataTable dt = new DataTable();
                    SqlDataAdapter MsAdapter = new SqlDataAdapter();
                    MsAdapter.SelectCommand = new SqlCommand(select, SgMsSqlCon.Instance.Con);
                    MsAdapter.Fill(dt);
                    return dt;
                }
                else
                {
                    throw new ApplicationException("Must specify select command");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
