using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
namespace TaskConsoleApp_StartNew
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
        static async Task Main(string[] args)
        {
            var myTask = Task.Factory.StartNew((Obj)=>
            {
                Console.WriteLine("myTask çalıştı");

                var status = Obj as Status;
                status.threadId=Thread.CurrentThread.ManagedThreadId;
            }, new Status() { date=DateTime.Now} );

            await myTask;

            Status s=myTask.AsyncState as Status;
            Console.WriteLine(s.date);
            Console.WriteLine(s.threadId);
        }
        
    }
}
