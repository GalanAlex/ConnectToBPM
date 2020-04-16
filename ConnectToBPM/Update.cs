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
            upd.OperationType = 2;
            upd.IsForceUpdate = false;
            upd.ColumnValues = col;
            upd.Filters = fil;
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
            col.Items = it;
            //it.Account = ai;
            it.Name = nm;//c1bf124c-f36b-1410-d68d-001d60e938c6
            nm.ExpressionType = 2;
            nm.Parameter = pr;
            pr.DataValueType = 1;
            pr.Value = "A1AAAAA";
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
/*
{
	"RootSchemaName": "Contact",
	"OperationType": 2,
	"IsForceUpdate": true,
	"ColumnValues": {
		"Items": {
			"Name": {
				"ExpressionType": 2,
				"Parameter": {
					"DataValueType": 1,
					"Value": "AAAAAA"
				}
			}
		}
	},
	"Filters": {
		"Items": {
			"Id": {
				"FilterType": 1,
				"ComparisonType": 3,
				"LeftExpression": {
					"ExpressionType": 0,
					"ColumnPath": "Id"
				},
				"RightExpression": {
					"ExpressionType": 2,
					"Parameter": {
						"DataValueType": 0,
						"Value": "15eb3b8f-4d2d-4bc9-b42e-0b4ce36544e1"
					}
				},
				"IsEnabled": true
			}
		}
	}
}*/
