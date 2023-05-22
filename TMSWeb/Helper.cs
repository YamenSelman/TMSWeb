﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.SessionState;
using TMSAPI.Models;

namespace TMSWeb
{
    public static class Helper
    {
        //private static string BaseURL = "http://mayanahat23-001-site1.ftempurl.com/api/";
        private static string BaseURL = "http://localhost:61860/api/";
        public static List<string> Cities = new List<string> { "Damascus", "Aleppo", "Homs", "Hama", "Swaida", "Lattakia", "Tartous", "Daraa", "Derazzor", "Hasaka", "Qamshly", "Idleb", "Raqqa", "Beirut", "Baghdad", "Amman", "Istanbul", "Abudabi", "Cairo", "Alkhartoum", "Tunis", "Algeria", "Rabat", "Rome", "Paris", "Washington", "Berlin", "Londno", "Tokyo", "Shangahai", "Moscow" };

        public static string Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
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

                    result = readTask.Result.ToList();
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

        public static List<FlightCompany> getAllFlightCompanies()
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
        public static List<CarCompany> getAllCarCompanies()
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

        public static HotelRoom getRoom(int id)
        {
            HotelRoom result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"hotelrooms/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<HotelRoom>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }

        public static Hotel getHotel(int id)
        {
            Hotel result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"hotels/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Hotel>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }
        
        public static CarCompany getCarCompany(int id)
        {
            CarCompany result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"carcompanies/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<CarCompany>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }
        public static FlightCompany getFlightCompany(int id)
        {
            FlightCompany result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"flightcompanies/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<FlightCompany>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }

        public static List<HotelRoom> getHotelRooms(int id)
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
                    return result.Where(r => r.HotelId.Equals(id)).ToList();
                }
            }
            return result;
        }

        public static List<Airport> getAllAirports()
        {
            List<Airport> result = new List<Airport>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync("Airports");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Airport[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                }
            }
            return result;
        }

        public static Airport NewAirport(Airport airport)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<Airport>("Airports", airport);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<Airport>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        internal static object getHotelRoom(int id)
        {
            throw new NotImplementedException();
        }


        public static List<HotelRoom> getAvailableRooms(int hid, DateTime sdate, DateTime edate, int beds)
        {
            List<HotelRoom> result = new List<HotelRoom>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"hotelrooms/getavailable/{hid}/{sdate.ToString("MM-dd-yyyy")}/{edate.ToString("MM-dd-yyyy")}/{beds}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<HotelRoom[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                    return result;
                }
            }
            return result;
        }

        public static Customer getCurrentCustomer(int uid)
        {
            Customer result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"customers/byuser/{uid}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Customer>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }

        public static TMSAPI.Models.HotelReservation AddHotelReservation(TMSAPI.Models.HotelReservation hr)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<TMSAPI.Models.HotelReservation>("hotelreservations", hr);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<TMSAPI.Models.HotelReservation>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static void Alert(HttpSessionState Session, string message)
        {
            Session["alert"] = message;
        }
        public static void Alert(HttpSessionState Session, HttpResponse Response)
        {
            if (Session["alert"] != null)
            {
                Response.Write($"<script>alert('{Session["alert"]}');</script>");
                Session["alert"] = null;
            }
        }

        public static List<Car> getAvailableCars(int cid, DateTime sdate, DateTime edate)
        {
            List<Car> result = new List<Car>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"cars/getavailable/{cid}/{sdate.ToString("MM-dd-yyyy")}/{edate.ToString("MM-dd-yyyy")}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Car[]>();
                    readTask.Wait();

                    result = readTask.Result.ToList();
                    return result;
                }
            }
            return result;
        }

        public static Car getCar(int id)
        {
            Car result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"cars/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Car>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }

        public static TMSAPI.Models.CarReservation AddCarReservation(TMSAPI.Models.CarReservation cr)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<TMSAPI.Models.CarReservation>("carreservations", cr);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<TMSAPI.Models.CarReservation>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static List<KeyValuePair<string,int>> getManagedBy(int uid)
        {
            List<KeyValuePair<string, int>> result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"users/getmanagedby/{uid}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<List<KeyValuePair<string, int>>>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }


        public static List<Flight> getFlightsByCompany(int cid)
        {
            List<Flight> result = new List<Flight>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"flights/getFlightsByCompany/{cid}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<List<Flight>> ();
                    readTask.Wait();

                    if(readTask.Result != null)
                    {
                        result = readTask.Result;
                    }
                }
            }
            return result;
        }

        public static Flight NewFlight(Flight flight)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP POST
                var task = client.PostAsJsonAsync<Flight>("flights", flight);
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {
                    var readTask = rs.Content.ReadAsAsync<Flight>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return null;
        }

        public static Airport getAirport(int id)
        {
            Airport result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.GetAsync($"airports/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Airport>();
                    readTask.Wait();

                    result = readTask.Result;
                }
            }
            return result;
        }

        internal static Boolean deleteAirport(int id)
        {
            bool result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                //HTTP GET
                var task = client.DeleteAsync($"airports/{id}");
                task.Wait();

                var rs = task.Result;
                if (rs.IsSuccessStatusCode)
                {

                    var readTask = rs.Content.ReadAsAsync<Airport>();
                    readTask.Wait();

                    result = true;
                }
            }
            return result;
        }
    }
}