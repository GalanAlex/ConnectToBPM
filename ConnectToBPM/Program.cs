using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text.Json;
using Newtonsoft.Json;

namespace ConnectToBPM
{
    class Program
    {
        private const string _uri = "http://localhost:90/";
        private const string _authServiceUri = _uri + @"/ServiceModel/AuthService.svc/Login";
        public static bool check = false;
        public static CookieContainer AuthCookie = new CookieContainer();
        public static CookieCollection cookieCollection = null;//AuthCookie.GetCookies(new Uri(_authServiceUri));
        public static string csrfToken = null;//cookieCollection["BPMCSRF"].Value;
        static void Main(string[] args)
        {
            Console.WriteLine("Successful authentication?: {0}", Login.TryLogin("Supervisor", "Supervisor", AuthCookie, _authServiceUri, cookieCollection));
            
            Console.WriteLine("Which case do you want to use?");

            var cs = Console.ReadLine();
            if (cs.Equals("Add"))
            {
                Insert.AddContact(AuthCookie, csrfToken);

            }
            else if (cs.Equals("Select"))
            {
                Select.SelectView(AuthCookie, csrfToken);
            }else if (cs.Equals("Update"))
            {
                Update.UpdateElement(AuthCookie, csrfToken);
            }
            else if (cs.Equals("Delete"))
            {
                Delete.DeleteEntry(AuthCookie, csrfToken);
            }
            else if (cs.Equals("AddFile"))
            {
                AddFile.GetFileInfo(AuthCookie, csrfToken);
            }

        }
    }
}
