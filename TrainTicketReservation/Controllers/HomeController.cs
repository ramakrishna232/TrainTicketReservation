using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
namespace TrainTicketReservation.Controllers
{
    public class HomeController : Controller
    {
        string Connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            TempData["Source"] = formCollection["Source"].ToString();
            TempData["Destination"] = formCollection["Destination"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into PassengerInfo values('"+TempData["Source"]+"','"+TempData["Destination"]+"')",sqlConnection);
            
            sqlCommand.ExecuteNonQuery();
            return Redirect("Availability/Available");
        }
        public ActionResult About()
        {
            return View();
        }
        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}