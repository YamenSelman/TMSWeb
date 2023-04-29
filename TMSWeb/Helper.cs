using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TMSAPI.Models;

namespace TMSWeb
{
    public static class Helper
    {
        private static string BaseURL = "http://mayanahat23-001-site1.ftempurl.com/api/";
        //private static string BaseURL = "http://localhost:58608/api/";
        public static List<User> getAllUsers()
        {
            List<User> result = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync("users");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<User[]>();
                    readTask.Wait();

                    result =  readTask.Result.ToList(); 
                }
            }
            return result;
        }

        public static List<Customer> getAllCustomers()
        {
            List<Customer> result = new List<Customer>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync("customers");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Customer[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                }
            }
            return result;
        }

        public static List<HotelRoom> getAllRooms()
        {
            List<HotelRoom> result = new List<HotelRoom>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync("HotelRooms");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<HotelRoom[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                }
            }
            return result;
        }

        public static User NewUser(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<User>("users", user);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<User>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static void UpdateUser(User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PutAsJsonAsync<User>($"users/{user.ID}", user);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<User>();
                    readTask.Wait();
                }
            }
        }

        public static Customer NewCustomer(Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<Customer>("customers", customer);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<Customer>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static Hotel NewHotel(Hotel hotel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<Hotel>("hotels", hotel);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<Hotel>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static HotelRoom NewHotelRoom(HotelRoom room)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<HotelRoom>("hotelrooms", room);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<HotelRoom>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static List<Hotel> getAllHotels()
        {
            List<Hotel> result = new List<Hotel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync("hotels");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Hotel[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                }
            }
            return result;
        }

        internal static List<FlightCompany> getAllFlightCompanies()
        {
            List<FlightCompany> result = new List<FlightCompany>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync("FlightCompanies");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<FlightCompany[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                }
            }
            return result;
        }       
        internal static List<CarCompany> getAllCarCompanies()
        {
            List<CarCompany> result = new List<CarCompany>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync("CarCompanies");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<CarCompany[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                }
            }
            return result;
        }

        public static FlightCompany NewFlightCompany(FlightCompany company)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<FlightCompany>("flightcompanies", company);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<FlightCompany>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }        
        
        public static CarCompany NewCarCompany(CarCompany company)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<CarCompany>("CarCompanies", company);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<CarCompany>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static User getUser(int id)
        {
            User result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"users/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }
    }
}