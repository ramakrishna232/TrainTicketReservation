using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
namespace TrainTicketReservation.Controllers
{
    [Authorize]
    public class AvailabilityController : Controller
    {
        string Connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        
        // GET: Availability
        
        public ActionResult Available()
        {
            
            return View();
        }
        public ActionResult ACTier3()
        {
             
            return View();
        }
        [HttpPost]
        public ActionResult ACTier3(FormCollection formCollection)
        {
            string Berth;
            int result;
            ViewBag.Name = formCollection["Name"].ToString();
            ViewBag.Age = formCollection["Age"].ToString();
            ViewBag.Gender = formCollection["gender"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand userCommand = new SqlCommand("select * from usertab", sqlConnection);
            SqlDataReader userReader = userCommand.ExecuteReader();
            userReader.Read();
            string userName = userReader.GetValue(0).ToString();
            userReader.Close();
           SqlCommand TicketsCommand = new SqlCommand("select ACTier_3 from Trains", sqlConnection);
            SqlDataReader dataReader = TicketsCommand.ExecuteReader();
            dataReader.Read();
            int Available = (int)dataReader.GetValue(0);
            dataReader.Close();
            if (Available < 217 && Available >= 145)
            {
                result = 217 - Available;
                
                
                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/B1-" + result + "','3A','"+userName+"','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','3A','CN/RF/B1-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 145 && Available >= 73)
            {
                result = 145 - Available;
                
                
                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/B2-" + result + "','3A','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','3A','CN/RF/B2-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 73 && Available >= 1)
            {
                result = 73 - Available;
                Berth = "CN/RF/B3-'" + result + "'";
                
                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/B3-" + result + "','3A','" + userName+ "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','3A','CN/RF/B3-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else
            {
                Berth = "Not Allocated";
            }
            
            
            SqlCommand Remaining = new SqlCommand("select count(Name) from PassengersData", sqlConnection);
            int NoOfPassengers = (int)Remaining.ExecuteScalar();
            int AVBL_Seats = Available - NoOfPassengers;
            SqlCommand UpdateCommand = new SqlCommand("select * from PassengerInfo", sqlConnection);
            SqlDataReader UpdateReader = UpdateCommand.ExecuteReader();
            UpdateReader.Read();
            SqlCommand SeatsCommand = new SqlCommand("update Trains set ACTier_3='" + AVBL_Seats + "' where Source='" + UpdateReader.GetValue(0) + "'and Destination='" + UpdateReader.GetValue(1) + "'", sqlConnection);
            UpdateReader.Close();
            SeatsCommand.ExecuteNonQuery();
            return View();
        }
        public ActionResult ACTier2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ACTier2(FormCollection formCollection)
        {
            int result;
            string Berth;
            ViewBag.Name = formCollection["Name"].ToString();
            ViewBag.Age = formCollection["Age"].ToString();
            ViewBag.Gender = formCollection["gender"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand userCommand = new SqlCommand("select * from usertab", sqlConnection);
            SqlDataReader userReader = userCommand.ExecuteReader();
            userReader.Read();
            string userName = userReader.GetValue(0).ToString();
            userReader.Close();
            SqlCommand TicketsCommand = new SqlCommand("select ACTier_2 from Trains", sqlConnection);
            SqlDataReader dataReader = TicketsCommand.ExecuteReader();
            dataReader.Read();
            int Available = (int)dataReader.GetValue(0);
            dataReader.Close();
            
            if (Available < 145 && Available >= 73)
            {
                result = 145 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/A1-" + result + "','2A','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','2A','CN/RF/A1-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 73 && Available >= 1)
            {
                result = 73 - Available;
                Berth = "CN/RF/B3-'" + result + "'";

                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/A2-" + result + "','2A','" + userName+ "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','2A','CN/RF/A2-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else
            {
                Berth = "Not Allocated";
            }

            
            SqlCommand Remaining = new SqlCommand("select count(Name) from PassengersData", sqlConnection);
            int NoOfPassengers = (int)Remaining.ExecuteScalar();
            int AVBL_Seats = Available - NoOfPassengers;
            SqlCommand UpdateCommand = new SqlCommand("select * from PassengerInfo", sqlConnection);
            SqlDataReader UpdateReader = UpdateCommand.ExecuteReader();
            UpdateReader.Read();
            
            SqlCommand SeatsCommand = new SqlCommand("update Trains set ACTier_2='" + AVBL_Seats + "' where Source='" + UpdateReader.GetValue(0) + "'and Destination='" + UpdateReader.GetValue(1) + "'", sqlConnection);
            UpdateReader.Close();
            SeatsCommand.ExecuteNonQuery();

            return View();
        }
        public ActionResult ACTier1()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ACTier1(FormCollection formCollection)
        {
            int result;
            string Berth;
            ViewBag.Name = formCollection["Name"].ToString();
            ViewBag.Age = formCollection["Age"].ToString();
            ViewBag.Gender = formCollection["gender"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand userCommand = new SqlCommand("select * from usertab", sqlConnection);
            SqlDataReader userReader = userCommand.ExecuteReader();
            userReader.Read();
            string userName = userReader.GetValue(0).ToString();
            userReader.Close();
            SqlCommand TicketsCommand = new SqlCommand("select ACTier_1 from Trains", sqlConnection);
            SqlDataReader dataReader = TicketsCommand.ExecuteReader();
            dataReader.Read();
            int Available = (int)dataReader.GetValue(0);
            dataReader.Close();

            
            if (Available < 73 && Available >= 1)
            {
                result = 73 - Available;
                Berth = "CN/RF/B3-'" + result + "'";

                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/HA1-" + result + "','HA1','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','HA1','CN/RF/HA1-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();

            }
            else
            {
                Berth = "Not Allocated";
            }

            
            SqlCommand Remaining = new SqlCommand("select count(Name) from PassengersData", sqlConnection);
            int NoOfPassengers = (int)Remaining.ExecuteScalar();
            int AVBL_Seats = Available - NoOfPassengers;
            SqlCommand UpdateCommand = new SqlCommand("select * from PassengerInfo", sqlConnection);
            SqlDataReader UpdateReader = UpdateCommand.ExecuteReader();
            UpdateReader.Read();
            SqlCommand SeatsCommand = new SqlCommand("update Trains set ACTier_1='" + AVBL_Seats + "' where Source='" + UpdateReader.GetValue(0) + "'and Destination='" + UpdateReader.GetValue(1) + "'", sqlConnection);
            UpdateReader.Close();
            SeatsCommand.ExecuteNonQuery();
            return View();
        }
        public ActionResult SLAvailable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SLAvailable(FormCollection formCollection)
        {
            int result;
            string Berth;
            ViewBag.Name = formCollection["Name"].ToString();
            ViewBag.Age = formCollection["Age"].ToString();
            ViewBag.Gender = formCollection["gender"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand userCommand = new SqlCommand("select * from usertab", sqlConnection);
            SqlDataReader userReader = userCommand.ExecuteReader();
            userReader.Read();
            string userName = userReader.GetValue(0).ToString();
            userReader.Close();
            SqlCommand TicketsCommand = new SqlCommand("select SLAvailable from Trains", sqlConnection);
            SqlDataReader dataReader = TicketsCommand.ExecuteReader();
            dataReader.Read();
            int Available = (int)dataReader.GetValue(0);
            dataReader.Close();
            if (Available < 577 && Available >= 505)
            {
                result = 577 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S1-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S1-'" + result + ")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 505 && Available >= 433)
            {
                result = 505 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S2-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S2-'" + result + ")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 433 && Available >= 361)
            {
                result = 433 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S3-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S3-'" + result + ")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 361 && Available >= 289)
            {
                result = 361 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S4-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S4-'" + result + ")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 289 && Available >= 217)
            {
                result = 289 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S5-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S5-'" + result + ")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available <217  && Available >= 144)
            {
                result = 217 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S6-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S6-'" + result + ")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 145 && Available >= 73)
            {
                result = 145 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S7-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S7-'" + result + ")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else if (Available < 73 && Available >= 1)
            {
                result = 73 - Available;
                Berth = "CN/RF/B3-'" + result + "'";

                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/S8-" + result + "','SL','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SL','CN/RF/S8-'"+result+")", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            else
            {
                Berth = "Not Allocated";
            }

            
            SqlCommand Remaining = new SqlCommand("select count(Name) from PassengersData", sqlConnection);
            int NoOfPassengers = (int)Remaining.ExecuteScalar();
            int AVBL_Seats = Available - NoOfPassengers;
            SqlCommand UpdateCommand = new SqlCommand("select * from PassengerInfo", sqlConnection);
            SqlDataReader UpdateReader = UpdateCommand.ExecuteReader();
            UpdateReader.Read();
            SqlCommand SeatsCommand = new SqlCommand("update Trains set SLAvailable='" + AVBL_Seats + "' where Source='" + UpdateReader.GetValue(0) + "'and Destination='" + UpdateReader.GetValue(1) + "'", sqlConnection);
            UpdateReader.Close();
            SeatsCommand.ExecuteNonQuery();

            return View();
        }
        public ActionResult SSAvailable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SSAvailable(FormCollection formCollection)
        {
            int result;
            string Berth;
            ViewBag.Name = formCollection["Name"].ToString();
            ViewBag.Age = formCollection["Age"].ToString();
            ViewBag.Gender = formCollection["gender"].ToString();
            SqlConnection sqlConnection = new SqlConnection(Connection);
            sqlConnection.Open();
            SqlCommand userCommand = new SqlCommand("select * from usertab", sqlConnection);
            SqlDataReader userReader = userCommand.ExecuteReader();
            userReader.Read();
            string userName = userReader.GetValue(0).ToString();
            userReader.Close();
            SqlCommand TicketsCommand = new SqlCommand("select SSAvailable from Trains", sqlConnection);
            SqlDataReader dataReader = TicketsCommand.ExecuteReader();
            dataReader.Read();
            int Available = (int)dataReader.GetValue(0);
            dataReader.Close();
            if (Available < 145 && Available >= 73)
            {
                result = 145 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/D1-" + result + "','SS','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SS','CN/RF/D1-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }
            if (Available < 73 && Available >= 1)
            {
                result = 145 - Available;


                SqlCommand sqlCommand = new SqlCommand("insert into passengers values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','CN/RF/D2-" + result + "','SS','" + userName + "','" + DateTime.Now.Date + "')", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                SqlCommand passengerCommand = new SqlCommand("insert into PassengersData values('" + ViewBag.Name + "','" + ViewBag.Age + "','" + ViewBag.Gender + "','SS','CN/RF/D2-" + result + "')", sqlConnection);
                passengerCommand.ExecuteNonQuery();
            }

            
            SqlCommand Remaining = new SqlCommand("select count(Name) from PassengersData",sqlConnection);
            int NoOfPassengers=(int)Remaining.ExecuteScalar();
            int AVBL_Seats = Available - NoOfPassengers;
            SqlCommand UpdateCommand = new SqlCommand("select * from PassengerInfo", sqlConnection);
            SqlDataReader UpdateReader = UpdateCommand.ExecuteReader();
            UpdateReader.Read();
            SqlCommand SeatsCommand = new SqlCommand("update Trains set SSAvailable='"+AVBL_Seats+"' where Source='"+UpdateReader.GetValue(0)+"'and Destination='"+UpdateReader.GetValue(1)+"'",sqlConnection);
            UpdateReader.Close();
            SeatsCommand.ExecuteNonQuery();
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult Tickets()
        {
            return View();
        }
    }
}