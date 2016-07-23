using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpxProcessor
{
    public class ShellHandler
    {
        private string _shellPath;
        private Process _cmd;
        private bool _running;

        private const string LatCmd = "\"gps setlatitude \"";
        private const string LonCmd = "\"gps setlongitude \"";


        public string Modifier { get; set; }

        public ShellHandler(string path)
        {
            _shellPath = path;
            _running = false;
            _init();
        }

        private void _init()
        {
            _cmd = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
            _cmd.Start();
            _running = true;
        }

        private string ExecuteCommand(string command)
        {
            if(!_running)
                throw new Exception("The shell is not running");
            _cmd.StandardInput.WriteLine(string.Join(" ", _shellPath, Modifier, command));
            _cmd.StandardInput.Flush();
            _cmd.StandardInput.Close();
            return _cmd.StandardOutput.ReadToEnd();
        }

        public string SetLatitude(int latitude)
        {
            return ExecuteCommand(LatCmd + latitude);
        }

        public string SetLongitude(int longitude)
        {
            return ExecuteCommand(LonCmd + longitude);
        }
    }
}
