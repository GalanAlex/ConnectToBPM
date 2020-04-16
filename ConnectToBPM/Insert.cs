using ConnectToBPM.InsertQueryFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConnectToBPM
{
    class Insert
    {
        public static bool AddContact(CookieContainer AuthCookie,string csrfToken)
        {/*
            var addUri = "https://035710-sales-enterprise.terrasoft.ru/0/dataservice/json/reply/InsertQuery";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(addUri);
            request.Headers.Add("BPMCSRF", csrfToken);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = AuthCookie;
            InsertQuery ins = new InsertQuery();
            ColumnValues col = new ColumnValues();
            Items it = new Items();
            Name nm = new Name();
            Name ai = new Name();
            Parameter pr = new Parameter();
            Parameter pr1 = new Parameter();
            ins.RootSchemaName = "Contact";
            ins.OperationType = 1;
            ins.ColumnValues = col;
            col.Items = it;
            it.Account = ai;
            it.Name = nm;//c1bf124c-f36b-1410-d68d-001d60e938c6
            nm.ExpressionType = 2;
            nm.Parameter = pr;
            pr.DataValueType = 1;
            pr.Value = "Al3234";
            ai.ExpressionType = 2;
            ai.Parameter = pr1;
            pr1.DataValueType = 10;
            pr1.Value = "c1bf124c-f36b-1410-d68d-001d60e938c6";
            string json = JsonConvert.SerializeObject(ins);
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
                        Console.WriteLine("Successful!");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            */
            return true;
        }
    }
}
