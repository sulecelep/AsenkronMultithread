using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace TaskConsoleApp_WhenAny
{
    public class Content
    {
        public string Site { get; set; }
        public int Len { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Main thread:" + Thread.CurrentThread.ManagedThreadId);
            List<string> urlsList = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.n11.com",
                "https://www.haberturk.com"
            };


            List<Task<Content>> taskList = new List<Task<Content>>();



            urlsList.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            var FirstData=await Task.WhenAny(taskList);

            Console.WriteLine($"{FirstData.Result.Site} - {FirstData.Result.Len}");
        }
        public async static Task<Content> GetContentAsync(string url)
        {
            Content c = new Content();
            var data = await new HttpClient().GetStringAsync(url);
            c.Site = url;
            c.Len = data.Length;
            Console.WriteLine("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);
            return c;
        }
    }
}
