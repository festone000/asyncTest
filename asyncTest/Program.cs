using System;
using System.Threading;
using System.Threading.Tasks;

namespace asyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task with Thread Start!");

            for (var i = 0; i <= 5; i++)
            {
                Thread t = new Thread(DoTaskFunction);
                t.Start();
            }

            Console.WriteLine("Task with Thread End!");

            for(var i = 0; i <= 5; i++)
            {
                Task.Run(()=> { DoTaskFunction(); });
            }
            Console.WriteLine("Task with task end");

        }

        public static void DoTaskFunction()
        {
            Console.WriteLine($" ThreadId {Thread.CurrentThread.ManagedThreadId}, \t  IsBackGround {Thread.CurrentThread.IsBackground}");
        }
    }
}
