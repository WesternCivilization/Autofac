using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutofacMvc.Domain;
using System.Data;
using System.Data.SqlClient;

namespace AutofacMvc.Data
{
    public class SqlServerConnection:ISqlConnection
    {
        public IDbConnection Conn { get; set; }
        public SqlServerConnection()
        {
            this.Conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Constr"].ConnectionString);
        }       
    }
}