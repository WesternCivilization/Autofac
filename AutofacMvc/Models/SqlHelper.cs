using AutofacMvc.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AutofacMvc.Models
{
    public class SqlHelper
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        string database = System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].Name;
        IDbConnection conn = null;
       
        public SqlHelper()
        {
            conn = GetConnection(); 
        }
        public IDbConnection GetConnection()
        {
            IDbConnection conn = null;
            if (database == "SqlServer")
            {
                conn = (IDbConnection)Assembly.Load("AutofacMvc").CreateInstance("SqlCommand");
            }
            return (IDbConnection)conn;
        }
        public IDbCommand GetCommand()
        {
            IDbCommand cmd=null;
            if (database == "SqlServer")
            {
                cmd= (IDbCommand)Assembly.Load("AutofacMvc").CreateInstance("SqlCommand");
            }
            return cmd;
        }

        public IDbConnection OpenConnnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State==ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }
        public int Insert(string sqlstr)
        {
            int count = 0;
            using (IDbCommand cmd = GetCommand())
            {
                cmd.Connection = conn;
                count=cmd.ExecuteNonQuery();
            }
            return count;
        }
    }
}