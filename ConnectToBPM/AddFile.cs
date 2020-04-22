using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ConnectToBPM.Filters;
using ConnectToBPM.InsertQueryFolder;
using Newtonsoft.Json;


namespace ConnectToBPM
{
    class AddFile
    {
        public static void GetFileInfo(CookieContainer AuthCookie, string csrfToken)
        {
            var addUri = "http://localhost:90/0/rest/SmrAddFile/AddFile";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(addUri);
            request.Headers.Add("BPMCSRF", csrfToken);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = AuthCookie;
            var path = @"C:\Users\alexey.galanin\123.txt";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInfo.Name);
                Console.WriteLine("Время создания: {0}", fileInfo.CreationTime);
                Console.WriteLine("Размер: {0}", fileInfo.Length);
                Console.WriteLine(fileInfo.Extension);
            }
            var nm = fileInfo.Name;
            FileStream fstream = File.OpenRead(path);
            string bs64 = "";
            byte[] ab = new byte[fstream.Length];
            fstream.Read(ab, 0, ab.Length);
            bs64 = Convert.ToBase64String(ab);
            FileJson fj = new FileJson
            {
                Array = bs64,
                Id = "c4ed336c-3e9b-40fe-8b82-5632476472b4",
                Name = nm
            };
            var json = JsonConvert.SerializeObject(fj);
            using (var requestStream = request.GetRequestStream())
            {
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(json);
                }
            }
            //RespStatus status = null;
            Console.WriteLine(json);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string respText = reader.ReadToEnd();
                        //status = JsonConvert.DeserializeObject<RespStatus>(respText);
                        Console.WriteLine(respText);

                        //Console.WriteLine("Successful!");
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //Console.WriteLine(json);

        }
    }

    public class FileJson
    {
        public object Name { get; set; }
        public object Array { get; set; }
        public object Id { get; set; }
    }
}

/*
            //Filters.Filters fil = new Filters.Filters();
            //Filters.Items fit = new Filters.Items();
            //LeftExpression le = new LeftExpression();
            //RightExpression re = new RightExpression();
            InsertQuery ins = new InsertQuery();
            ColumnValues col = new ColumnValues();
            InsertQueryFolder.Items it = new InsertQueryFolder.Items();
            InsertQueryFolder.Name data = new InsertQueryFolder.Name();
            InsertQueryFolder.Parameter pr = new InsertQueryFolder.Parameter();
            Filters.Parameter pr1 = new Filters.Parameter();
            Filters.Name fnm = new Filters.Name();
            //ins.Filters = fil;
            ins.RootSchemaName = "ContactFile";
            ins.OperationType = 1;
            ins.ColumnValues = col;
            col.Items = it;
            it.Data = data;//c1bf124c-f36b-1410-d68d-001d60e938c6
            data.ExpressionType = 2;
            data.Parameter = pr;
            pr.DataValueType = 13;
            pr.Value = ab;
            //fil.Items = fit;
            //fit.Id = fnm;
            //fil.FilterType = 6;
            //fil.IsEnabled = true;
            //fil.LogicalOperation = 0;
            //fnm.IsEnabled = true;

            //fnm.FilterType = 1;
            //fnm.ComparisonType = 3;
            //fnm.LeftExpression = le;
            //le.ColumnPath = "ContactFile.Contact";
            //le.ExpressionType = 0;
            //re.ExpressionType = 2;
            //re.Parameter = pr1;
            //pr1.DataValueType = 0;
            //pr1.Value = "d73f2e3a-f46b-1410-5290-001d60c7ee8c";
            //fnm.RightExpression = re;
            */
