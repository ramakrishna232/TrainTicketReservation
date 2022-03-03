using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace TrainTicketReservation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        string Connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(FormCollection formCollection,string ReturnUrl)
        {

            ViewBag.Username = formCollection["UserName"].ToString();
            ViewBag.Password = formCollection["Password"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Customer where UserName='" + ViewBag.Username + "'and Password='" + ViewBag.Password + "'", sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.Read())
            {
                FormsAuthentication.SetAuthCookie(ViewBag.Username, false);
                return Redirect(ReturnUrl);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection formCollection)
        {
            ViewBag.Name = formCollection["Name"].ToString();
            ViewBag.Age = formCollection["Age"].ToString();
            ViewBag.MobNo = formCollection["MobNo"].ToString();
            ViewBag.Gender = formCollection["Gender"].ToString();
            ViewBag.Email = formCollection["Email"].ToString();
            ViewBag.UserName = formCollection["UserName"].ToString();
            ViewBag.Password = formCollection["Password"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into Customer values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.MobNo + "','" + ViewBag.Gender + "','" + ViewBag.Email + "','" + ViewBag.UserNAme + "','" + ViewBag.Password + "')", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            return Redirect("Login");
        }
    }
}