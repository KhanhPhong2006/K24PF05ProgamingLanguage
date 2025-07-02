using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var TaskLoadWeb = GetWebContent("https://google.com.vn");
            string url = "https://google.com.vn";
            var uri = new Uri(url);
            uri.Segments.ToList().ForEach(segment =>
            {
                Console.WriteLine($"Segment: {segment}");
            });
        }

        static void VD01()
        {
            string url = "https://google.com.vn";
            var uri = new Uri(url);
            Console.WriteLine($"Scheme: {uri.Scheme}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Path: {uri.AbsolutePath}");
            Console.WriteLine($"Query: {uri.Query}");
            Console.WriteLine($"Fragment: {uri.Fragment}");

            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(uri.Host);
            if (reply != null && reply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Ping successful: {reply.RoundtripTime} ms");
            }
            else
            {
                Console.WriteLine("Ping failed.");
            }
        }
        static void VD02()
        {
            string url = "https://google.com.vn";
            var uri = new Uri(url);
            Console.WriteLine($"Scheme: {uri.Scheme}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Path: {uri.AbsolutePath}");
            Console.WriteLine($"Query: {uri.Query}");
            Console.WriteLine($"Fragment: {uri.Fragment}");
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(uri.Host);
            if (reply != null && reply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Ping successful: {reply.RoundtripTime} ms");
            }
            else
            {
                Console.WriteLine("Ping failed.");
            }
        }
        static string VD03()
        {
            string url = "https://google.com.vn";
            var uri = new Uri(url);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Scheme: {uri.Scheme}");
            sb.AppendLine($"Host: {uri.Host}");
            sb.AppendLine($"Port: {uri.Port}");
            sb.AppendLine($"Path: {uri.AbsolutePath}");
            sb.AppendLine($"Query: {uri.Query}");
            sb.AppendLine($"Fragment: {uri.Fragment}");
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(uri.Host);
            if (reply != null && reply.Status == IPStatus.Success)
            {
                sb.AppendLine($"Ping successful: {reply.RoundtripTime} ms");
            }
            else
            {
                sb.AppendLine("Ping failed.");
            }
            return sb.ToString();
        }
        public static async Task<string> GetWebContent(string url)
        {
            string hml = "";
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    hml = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Lỗi: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return hml; 
        }
    }
}
