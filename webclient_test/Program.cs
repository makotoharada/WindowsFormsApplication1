using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace webclient_test
{
    class Program
    {
        public static string ReadFromUrl(Uri url)
        {
            using (WebClient webClient = new WebClient())
            {
                using (Stream stream = webClient.OpenRead(url))
                {
                    TextReader tr = new StreamReader(stream, Encoding.UTF8, true);
                    //TextReader tr = new StreamReader(stream);
                    string body = tr.ReadToEnd();
                    return body;
                }
            }
        }

        public static void Download()
        {
            Uri url = new Uri("https://github.com/Microsoft/dotnet/blob/master/README.md");
            string body = ReadFromUrl(url);
            Console.WriteLine(body);
        }

        public static async Task<string> ReadFromUrlAsync(Uri url)
        {
            using (WebClient webClient = new WebClient())
            {
                using (Stream stream = await webClient.OpenReadTaskAsync(url))
                {
                    TextReader tr = new StreamReader(stream, Encoding.UTF8, true);
                    string body = await tr.ReadToEndAsync();
                    return body;
                }
            }
        }

        public static async void DownloadAsync()
        {
            Uri url = new Uri("https://github.com/Microsoft/dotnet/blob/master/README.md");
            string body = await ReadFromUrlAsync(url);
            Console.WriteLine(body);
        }



        static void Main(string[] args)
        {
            //Download();
            DownloadAsync();
            Console.ReadLine();

        }
    }
}
