using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_sample
{

    public class Example
    {

        static async void calc_async()
        {
            var t = Task<int>.Run(() =>
            {
                // Just loop.
                int max = 1000000;
                int ctr = 0;
                for (ctr = 0; ctr <= max; ctr++)
                {
                    if (ctr == max / 2 && DateTime.Now.Hour <= 12)
                    {
                        ctr++;
                        break;
                    }
                }
                return ctr;
            });

            Console.WriteLine("Finished {0:N0} iterations.", await t);

        }

        static void task_sample1()
        {
            int count = 1;

            Task task = Task.Factory.StartNew(() => {
                Console.WriteLine(count.ToString() + "！");
                count++;
                Thread.Sleep(1000);
                Console.WriteLine(count.ToString() + "！");
                count++;
                Thread.Sleep(1000);
                Console.WriteLine(count.ToString() + "！");
                count++;
                Thread.Sleep(1000);
                Console.WriteLine("だ～～～～～～～～～～～～～～～～～～～～～～～～～～～～");
                Thread.Sleep(1000);
            });

            task.Wait();
        }

        static void task_sample2()
        {
            var t = Task<int>.Factory.StartNew(() =>
            {
                // Just loop.
                int max = 1000000;
                int ctr = 0;
                for (ctr = 0; ctr <= max; ctr++)
                {
                    if (ctr == max / 2 && DateTime.Now.Hour <= 12)
                    {
                        ctr++;
                        break;
                    }
                }
                return ctr;
            });
        }


        public static void Main()
        {
            task_sample1();
            //task_sample2();
            //calc_async();

            Console.WriteLine("Hello from Main \n");
            Console.ReadLine();
        }
    }
}
