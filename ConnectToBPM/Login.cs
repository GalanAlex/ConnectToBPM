using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConnectToBPM
{
    class Login
    {
        
        public static bool TryLogin(string userName, string userPassword, CookieContainer AuthCookie,string authServiceUri, CookieCollection cookieCollection)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(authServiceUri);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = AuthCookie;
            using (var requestStream = request.GetRequestStream())
            {
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(@"{
                    ""UserName"":""" + userName + @""",
                    ""UserPassword"":""" + userPassword + @"""
                    }");
                }
            }

            RespStatus status = null;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string respText = reader.ReadToEnd();
                    status = JsonConvert.DeserializeObject<RespStatus>(respText);
                }
            }

            if (status.Code == 0)
            {
                Console.WriteLine("Successful!");
                Program.cookieCollection = request.CookieContainer.GetCookies(new Uri(authServiceUri));
                Program.csrfToken = Program.cookieCollection["BPMCSRF"].Value;
                return true;
            }
            else
            {
                Console.WriteLine(status.Message);
                return false;
            }
        }
    }
}
