using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GpxProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var shell = new ShellHandler("\"C:\\Program Files\\Genymobile\\Genymotion\\genyshell.exe\"")
            {
                Modifier = "-c"
            };
            Console.Write(shell.SetLocation(9.97726, -84.85066));
            Thread.Sleep(2000);
            Console.Write(shell.SetLocation(9.97729, -84.85049));
            Console.ReadLine();
        }
    }
}
