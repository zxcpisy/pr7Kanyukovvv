using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pr7Kan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("");
            HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(responce.StatusDescription);
            Stream dataStream = responce.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responceFromServer = reader.ReadToEnd();
            Console.WriteLine(responceFromServer);
            reader.Close();
            dataStream.Close();
            responce.Close();
            Console.Read();
         }
        public static void SingIn(string Login, string Password)
        {
            string url = "";
            Debug.WriteLine($"Выполняем запрос: {url}");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "";
            request.CookieContainer = new CookieContainer();
            string postData = $"login={Login}&password={Password}";
            byte[] Data = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = Data.Length;
            using(var stream = request.GetRequestStream())
            {
                stream.Write(Data,0,Data.Length);

            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Debug.WriteLine($"Статус выполнения: {response.StatusCode}");
            string responseFromServer = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(responseFromServer);
        }
    }
}
