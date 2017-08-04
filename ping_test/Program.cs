using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace ping_test
{
    class Program
    {
        static string[] targets = new string[] {
            "neoecu-avbtsn.local",
            "neoecu-avbtsn-2.local",
            "neoecu-avbtsn-3.local",
            "neoecu-avbtsn-4.local",
            "neoecu-avbtsn-5.local",
            "neoecu-avbtsn-6.local",
            "neoecu-avbtsn-7.local",
            "neoecu-avbtsn-8.local",
            "neoecu-avbtsn-9.local",
        };

        public static string[] addresses = { "microsoft.com", "yahoo.com", "google.com" };

        static bool send_ping(string hostname)
        {
            bool result = false;

            //Pingオブジェクトの作成
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            PingOptions options = new PingOptions(8, true); //ttl = 8 is enought for local network 
            byte[] bs = System.Text.Encoding.ASCII.GetBytes(new string('A', 32));
            int timeout = 10; // 10ms

            Console.WriteLine("ping to " + hostname);

            try
            {
                System.Net.NetworkInformation.PingReply reply = p.Send(hostname, timeout, bs, options);

                //結果を取得
                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    Console.WriteLine("Success");
                    //Console.WriteLine("Reply from {0}:bytes={1} time={2}ms TTL={3}",
                    //reply.Address, reply.Buffer.Length, reply.RoundtripTime, reply.Options.Ttl);
                    Console.WriteLine("Reply from {0}:bytes={1} time={2}ms ",
                    reply.Address, reply.Buffer.Length, reply.RoundtripTime);

                    result = true;
                }
                else
                {
                    Console.WriteLine("Fail");
                    //Console.WriteLine("Ping送信に失敗。({0})", reply.Status);
                    result = false;
                }

            }
            catch (PingException ex)
            {
                string returnMessage = string.Format("Connection Error: {0}", ex.InnerException.Message);
                Console.WriteLine(returnMessage);
                result = false;
            }

            p.Dispose();

            return result;
        }

        static async Task send_ping_async(string hostname)
        {
            var ret = Task<bool>.Run(() => send_ping(hostname));

            bool result = await ret;
            // pass or fail ?
            Console.WriteLine("completed to send ping to {0}, Result: {1} \n", hostname, result);
        }

        static void do_ping_async2()
        {
            send_ping_async("neoecu-avbtsn.local");
            send_ping_async("neoecu-avbtsn-2.local");
            send_ping_async("neoecu-avbtsn-3.local");
        }

        static void do_ping_async()
        {
            List<Task<PingReply>> pingTasks = new List<Task<PingReply>>();

            foreach (var address in addresses)
            {
                pingTasks.Add(PingAsync(address));
            }

            //Wait for all the tasks to complete
            Task.WaitAll(pingTasks.ToArray());

            //Now you can iterate over your list of pingTasks
            foreach (var pingTask in pingTasks)
            {
                //pingTask.Result is whatever type T was declared in PingAsync
                Console.WriteLine(pingTask.Result.RoundtripTime);
            }
            Console.ReadLine();
        }

        static Task<PingReply> PingAsync(string address)
        {
            var tcs = new TaskCompletionSource<PingReply>();

            Ping ping = new Ping();

            // event handler を追加
            ping.PingCompleted += (obj, sender) =>
                {
                    tcs.SetResult(sender.Reply);
                };

            ping.SendAsync(address, new object());
            return tcs.Task;
        }

        //Pingオブジェクト
        static System.Net.NetworkInformation.Ping mainPing = null;

        static private void Ping_PingCompleted(object sender,
            System.Net.NetworkInformation.PingCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("Pingがキャンセルされました。");
            }
            else if (e.Error != null)
            {
                Console.WriteLine("エラー:" + e.Error.Message);
            }
            else
            {
                //結果を取得
                if (e.Reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    Console.WriteLine("Reply from {0}:bytes={1} time={2}ms ",
                        e.Reply.Address, e.Reply.Buffer.Length,
                        e.Reply.RoundtripTime);
                        //e.Reply.RoundtripTime, e.Reply.Options.Ttl);
                }
                else
                {
                    Console.WriteLine("Ping送信に失敗。({0})", e.Reply.Status);
                }
            }
        }

        static void do_ping_async_sendasync()
        {

            //Pingオブジェクトの作成
            if (mainPing == null)
            {
                mainPing = new System.Net.NetworkInformation.Ping();
                //イベントハンドラを追加
                mainPing.PingCompleted += new System.Net.NetworkInformation.PingCompletedEventHandler( Ping_PingCompleted);
            }

            //Pingのオプションを設定
            //TTLを64、フラグメンテーションを無効にする
            System.Net.NetworkInformation.PingOptions opts = new System.Net.NetworkInformation.PingOptions(64, true);

            //Pingで送信する32バイトのデータを作成
            byte[] bs = System.Text.Encoding.ASCII.GetBytes(new string('A', 32));

            //Pingを送信する
            //タイムアウトを10秒
            mainPing.SendAsync("neoecu-avbtsn.local", 10000, bs, opts, null);

            // After calling SendAsync, you must wait for the e-mail transmission to complete 
            // before attempting to send another e-mail message using Send or SendAsync.
            //mainPing.SendAsync("neoecu-avbtsn-2.local", 10000, bs, opts, null);
            //mainPing.SendAsync("neoecu-avbtsn-3.local", 10000, bs, opts, null);

        }

        static void do_ping_sync()
        {

            //Pingオブジェクトの作成
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            PingOptions options = new PingOptions(8, true); //ttl = 8 is enought for local network 
            byte[] bs = System.Text.Encoding.ASCII.GetBytes(new string('A', 32));
            int timeout = 10; // 10ms

            foreach (string target in targets)
            {
                Console.WriteLine("ping to " + target);

                try
                {
                    System.Net.NetworkInformation.PingReply reply = p.Send(target, timeout, bs, options);

                    //結果を取得
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        Console.WriteLine("Success");
                        //Console.WriteLine("Reply from {0}:bytes={1} time={2}ms TTL={3}",
                        //reply.Address, reply.Buffer.Length, reply.RoundtripTime, reply.Options.Ttl);
                        Console.WriteLine("Reply from {0}:bytes={1} time={2}ms ",
                        reply.Address, reply.Buffer.Length, reply.RoundtripTime);
                    }
                    else
                    {
                        Console.WriteLine("Fail");
                        //Console.WriteLine("Ping送信に失敗。({0})", reply.Status);
                    }

                }
                catch (PingException ex)
                {
                    string returnMessage = string.Format("Connection Error: {0}", ex.InnerException.Message);
                    Console.WriteLine(returnMessage);
                    break;
                }

            }

            p.Dispose();

        }

        static void Main(string[] args)
        {
            //do_ping_sync();
            //do_ping_async_sendasync();
            //do_ping_async();
            do_ping_async2();
            Console.ReadLine();
        }
    }
}

