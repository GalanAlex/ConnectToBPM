using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
namespace ConnectToBPM
{
    class Add
    {
        public static bool AddContact(CookieContainer AuthCookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_authServiceUri);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = AuthCookie;
            return true;
        }
    }
}
