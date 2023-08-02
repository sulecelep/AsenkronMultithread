using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    internal class Program
    {
        public static void calis (Task<string> data)
        {
            //100 satırlık kod
            Console.WriteLine("data uzunluk: " + data.Result.Length);
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //1.KISIM
            //var mytask= new HttpClient().GetStringAsync("https://www.google.com")
            //    .ContinueWith((data) =>   //data parametresi alan geriye bir şey dönemeyen metot lambda ile gösterimi
            //    {
            //        //google'ın datası geldikten sonra çalışacak Task<string> döndüğü için biz de böyle bir prop tanımlıcaz
            //        Console.WriteLine("data uzunluk: "+data.Result.Length);
            //    });
            //Console.WriteLine("Arada yapılacak işler");
            //var data = await mytask;


            //2.KISIM
            //var mytask = new HttpClient().GetStringAsync("https://www.google.com");
            //Console.WriteLine("Arada yapılacak işler");
            //var data = await mytask;
            //Console.WriteLine("data uzunluk: " + data.Length);  //Aynı şeyi await kullanarak ContinueWith olmadan da yaptık. 


            //3.KISIM
            var mytask = new HttpClient().GetStringAsync("https://www.google.com")
                .ContinueWith(calis);
                
            Console.WriteLine("Arada yapılacak işler");
            await mytask;
        }
    }
}
