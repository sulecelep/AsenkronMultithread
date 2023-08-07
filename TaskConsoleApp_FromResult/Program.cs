using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
namespace TaskConsoleApp_FromResult
{
    public class Content
    {
        public string Site { get; set; }
        public int Len { get; set; }
    }

    public class Status
    {
        public int threadId { get; set; }
        public DateTime date { get; set; }
    }

    internal class Program
    {
        public static string CacheData { get; set; }
        static async Task Main(string[] args)
        {
            CacheData = await GetDataAsync();
            Console.WriteLine(CacheData);
        }

        public static Task<string> GetDataAsync()
        {

            Task.Run<string>(() => { return "generic Run string dönmesini istedik, sadece örnek"; });


            if(String.IsNullOrEmpty(CacheData))
            {
                return File.ReadAllTextAsync("dosya.txt");

            }
            else
            {
                //return Task.FromResult(CacheData); //türünü belirtmek istemeye de biliriz
                return Task.FromResult<string>(CacheData); //tip güvenli olsun yani string dönmesini istiyorsak
            }
        }
    }
}
