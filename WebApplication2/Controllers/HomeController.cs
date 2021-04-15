using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()/*()*/
        {
            string connectionString = "Data Source=VOVA;Initial Catalog=DataAddress;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sqlExpression = "sp_GetData";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    List<Contact> contacts = new List<Contact>();

                    while (reader.Read())
                    {
                        if (contacts.Any(x => x.ContactId == reader.GetInt32(0)))
                        {
                            contacts.First(x => x.ContactId == reader.GetInt32(0)).Phones.Add(new Phone() { PhoneNumber = reader.GetString(3), isActive = reader.GetBoolean(4) });
                        }
                        else
                        {
                            var contact = new Contact() { ContactId = reader.GetInt32(0), Name = reader.GetString(1) };
                           contact.Phones.Add(new Phone() { PhoneNumber = reader.GetString(3), isActive = reader.GetBoolean(4) });
                            contacts.Add(contact);
                        }

                    }
                    ViewBag.contacts = contacts;
                }

                reader.Close();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}