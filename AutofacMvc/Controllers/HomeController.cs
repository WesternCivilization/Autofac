using AutofacMvc.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutofacMvc.Controllers
{
    public class HomeController : Controller
    {
        ISqlConnection conn;
        public HomeController(ISqlConnection conn)
        {
            this.conn = conn;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public int Insert()
        {
            conn.Conn.Open();
            string sqlstr = "";
            SqlCommand cmd = new SqlCommand(sqlstr, (SqlConnection)conn.Conn);
            int count = cmd.ExecuteNonQuery();
            return count;
        }
    }
}