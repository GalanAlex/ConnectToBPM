using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConnectToBPM.DeleteQueryFolder;
using ConnectToBPM.Filters;
using Newtonsoft.Json;

namespace ConnectToBPM
{
    class Delete
    {
        public static bool DeleteEntry(CookieContainer AuthCookie, string csrfToken)
        {
            var addUri = "https://035710-sales-enterprise.terrasoft.ru/0/dataservice/json/reply/DeleteQuery";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(addUri);
            request.Headers.Add("BPMCSRF", csrfToken);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = AuthCookie;
            DeleteQuery del = new DeleteQuery();
            del.RootSchemaName = "Contact";
            del.OperationType = 3;
            Name fnm = new Name();
            Items fit = new Items();
            //Name ai = new Name();
            Filters.Filters fil = new Filters.Filters();
            LeftExpression le = new LeftExpression();
            RightExpression re = new RightExpression();
            Parameter pr1 = new Parameter();
            del.Filters = fil;
            fil.Items = fit;
            fit.Id = fnm;
            fil.FilterType = 6;
            fil.IsEnabled = true;
            fil.LogicalOperation = 0;
            fnm.IsEnabled = true;

            fnm.FilterType = 1;
            fnm.ComparisonType = 3;
            fnm.LeftExpression = le;
            le.ColumnPath = "Id";
            le.ExpressionType = 0;
            re.ExpressionType = 2;
            re.Parameter = pr1;
            pr1.DataValueType = 0;
            pr1.Value = "15eb3b8f-4d2d-4bc9-b42e-0b4ce36544e1";
            fnm.RightExpression = re;
            var json = JsonConvert.SerializeObject(del);
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
