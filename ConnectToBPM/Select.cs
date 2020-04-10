using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConnectToBPM.SelectQueryFolder;
using Newtonsoft.Json;

namespace ConnectToBPM
{
    class Select
    {
        public static void SelectView(CookieContainer AuthCookie, string csrfToken)
        {
            var addUri = "https://035710-sales-enterprise.terrasoft.ru/0/dataservice/json/reply/SelectQuery";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(addUri);
            request.Headers.Add("BPMCSRF", csrfToken);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = AuthCookie;
            SelectQuery sel = new SelectQuery();
            Columns col = new Columns();
            Items it = new Items();
            //Name nm = new Name();

            sel.OperationType = 0;
            sel.RootSchemaName = "Contact";
            sel.Columns = col;
            col.Items = it;
            it.AllColumns = true;
            string json = JsonConvert.SerializeObject(sel);
            using (var requestStream = request.GetRequestStream())
            {
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(json);
                }
            }
            RespStatus status = null;
            Console.WriteLine(json);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string respText = reader.ReadToEnd();
                        status = JsonConvert.DeserializeObject<RespStatus>(respText);
                        Console.WriteLine(respText);
                        Console.WriteLine("Successful!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
