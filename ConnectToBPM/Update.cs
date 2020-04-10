using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConnectToBPM.UpdateQueryFolder;
using ConnectToBPM.Filters;
using Newtonsoft.Json;

namespace ConnectToBPM
{
    class Update
    {
        public static bool UpdateElement(CookieContainer AuthCookie, string csrfToken)
        {
            var updUri = "https://035710-sales-enterprise.terrasoft.ru/0/dataservice/json/reply/UpdateQuery";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(updUri);
            request.Headers.Add("BPMCSRF", csrfToken);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = AuthCookie;
            UpdateQuery upd = new UpdateQuery();
            ColumnValues col = new ColumnValues();

            UpdateQueryFolder.Items it = new UpdateQueryFolder.Items();
            UpdateQueryFolder.Name nm = new UpdateQueryFolder.Name();
            Filters.Name fnm = new Filters.Name();
            Filters.Items fit = new Filters.Items();
            //Name ai = new Name();
            UpdateQueryFolder.Parameter pr = new UpdateQueryFolder.Parameter();
            Filters.Filters fil = new Filters.Filters();
            LeftExpression le = new LeftExpression();
            RightExpression re = new RightExpression();
            Filters.Parameter pr1 = new Filters.Parameter();
            upd.RootSchemaName = "Contact";
            upd.OperationType = 1;
            upd.IsForceUpdate = true;
            upd.ColumnValues = col;
            upd.Filters = fil;
            fil.Items = fit;
            fit.Id = fnm;
            fnm.IsEnabled = true;

            fnm.FilterType = 1;
            fnm.ComparisonType = 3;
            fnm.LeftExpression = le;
            le.ColumnPath = "Name";
            le.ExpressionType = 0;
            re.ExpressionType = 2;
            re.Parameter = pr1;
            pr1.DataValueType = 1;
            pr1.Value = "Alexey Galanin";
            fnm.RightExpression = re;
            col.Items = it;
            //it.Account = ai;
            it.Name = nm;//c1bf124c-f36b-1410-d68d-001d60e938c6
            nm.ExpressionType = 2;
            nm.Parameter = pr;
            pr.DataValueType = 1;
            pr.Value = "AAAAAA";
            //ai.ExpressionType = 2;
            //ai.Parameter = pr1;
            //pr1.DataValueType = 10;
            //pr1.Value = "c1bf124c-f36b-1410-d68d-001d60e938c6";
            string json = JsonConvert.SerializeObject(upd);
            //Console.WriteLine(json);
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
            return true;
        }
    }
}
