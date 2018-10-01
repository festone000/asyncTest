using System;
using System.Threading;
using System.Threading.Tasks;

namespace asyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Task with Thread Start!");

            //for (var i = 0; i <= 5; i++)
            //{
            //    Thread t = new Thread(DoTaskFunction);
            //    t.Start();
            //}

            //Console.WriteLine("Task with Thread End!");

            //for (var i = 0; i <= 5; i++)
            //{
            //    Task.Run(() => { DoTaskFunction(); });
            //}
            //Console.WriteLine("Task with task end");

            //DoTaskWithAsync();
            Test2();

        }

        public static void DoTaskFunction()
        {
            Console.WriteLine($" ThreadId {Thread.CurrentThread.ManagedThreadId}, \t  IsBackGround {Thread.CurrentThread.IsBackground}");
        }

        #region 常规Task
        public static async void DoTaskWithAsync()
        {
            Console.WriteLine("Await Taskfunction Start");
            await Task.Run(() => { DoTaskFunction2(); });
        }


        public static void  DoTaskFunction2()
        {
            for (var i = 0; i <= 5; i++)
            {
                Console.WriteLine("task {0}", i);
                //ThreadPool.QueueUserWorkItem((Object obj)=> {
                //    Console.WriteLine(i);
                //});
            }
        }

        #endregion
        //-------------

        #region 泛型Task，跟Task返回值有关
        public static async void Test2()
        {
            Console.WriteLine("========");
            var a = await Task<string>.Run<string>(() => {
                var aaa = Test222();
                Console.WriteLine(aaa);
                return aaa;
            });
            Console.WriteLine("~~~~" + a);
        }

        public static string Test222()
        {
            Random random = new Random();
            var v = random.Next(1000, 10000);
            return v.ToString();
        }


        #endregion
        
    }
}
