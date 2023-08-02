using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp_WhenAll
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

            var contents = Task.WhenAll(taskList.ToArray());

            Console.WriteLine("WhenAll metodundan sonra başka işlemler yaptım");
            var data = await contents;


            data.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Site} boyut: {x.Len}");
            });

            //var contents = await Task.WhenAll(taskList.ToArray());
            //contents.ToList().ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Site} boyut: {x.Len}");
            //});
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
