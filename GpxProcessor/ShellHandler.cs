using System.Diagnostics;

namespace GpxProcessor
{
    public class ShellHandler
    {
        private readonly string _shellPath;
        private Process _cmd;

        private const string LatCmd = "\"gps setlatitude \"";
        private const string LonCmd = "\"gps setlongitude \"";


        public string Modifier { get; set; }

        public ShellHandler(string path)
        {
            _shellPath = path;
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
        }


        private string ExecuteCommand(string command)
        {
            _cmd.Start();
            _cmd.StandardInput.WriteLine(string.Join(" ", _shellPath, Modifier, command));
            _cmd.StandardInput.Flush();
            _cmd.StandardInput.Close();
            return _cmd.StandardOutput.ReadToEnd();
        }

        public string SetLatitude(double latitude)
        {
            return ExecuteCommand(LatCmd + latitude);
        }

        public string SetLongitude(double longitude)
        {
            return ExecuteCommand(LonCmd + longitude);
        }

        public string SetLocation(double latitude, double longitude)
        {
            return  ExecuteCommand(LatCmd + latitude) + ExecuteCommand(LonCmd + longitude);
        }
    }
}
