using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    }
}
