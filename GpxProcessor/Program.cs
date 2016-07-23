using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var output = shell.SetLatitude(87);
            Console.Write(output);
            Console.ReadLine();
        }
    }
}
