using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Renci.SshNet;

namespace rensi_sshnet
{
    class Program
    {
        static void Main(string[] args)
        {

            PasswordAuthenticationMethod authMethod = new PasswordAuthenticationMethod("root", "root");
            ConnectionInfo connectionInfo = new ConnectionInfo("192.168.3.9", "root", authMethod);

            SshClient ssh = new SshClient(connectionInfo);
            ssh.Connect();

            //SshCommand cmd = ssh.CreateCommand("ls -l");
            SshCommand cmd = ssh.CreateCommand("ls /home/media/videos");
            cmd.Execute();

            //StreamReader stdout = new StreamReader(cmd.OutputStream);
            StreamReader stderr = new StreamReader(cmd.ExtendedOutputStream);

            Console.WriteLine(cmd.Result);
            //Console.WriteLine("stdout: " + stdout.ReadToEnd());
            Console.WriteLine(stderr.ReadToEnd());

            ssh.Disconnect();

            //while (true) ;

        }
    }
}
