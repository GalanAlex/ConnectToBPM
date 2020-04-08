using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text.Json;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace ConnectToBPM
{
    class Program
    {
        public static CookieContainer AuthCookie = new CookieContainer();

        static void Main(string[] args)
        {
            Console.WriteLine("Successful authentication?: {0}", Login.TryLogin("Alexey", "123", AuthCookie));

            Console.WriteLine("Which case do you want to use?");

            var cs = Console.ReadLine();
            if (cs.Equals("Add"))
            {

            }

        }
    }
}
