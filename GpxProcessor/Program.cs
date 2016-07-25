using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GpxProcessor
{
    class Program
    {
        static void Main()
        {
            var shell = new ShellHandler("\"C:\\Program Files\\Genymobile\\Genymotion\\genyshell.exe\"")
            {
                Modifier = "-c"
            };

            var reader = new GpxReader(@"D:\Dev\GpxProcessor\GpxProcessor\Content\sample.gpx");


            IList<WayPoint> wayPoints = reader.LoadWayPoints().ToList();
            var startTime = DateTime.ParseExact(wayPoints.First().Time, "yyyy-MM-dd'T'hh:mm:ss%K", System.Globalization.CultureInfo.InvariantCulture);
            foreach (var wpt in wayPoints)
            {
                var timeSpan = DateTime.ParseExact(wpt.Time, "yyyy-MM-dd'T'hh:mm:ss%K", System.Globalization.CultureInfo.InvariantCulture) - startTime;
                var sleepTime = (int)timeSpan.TotalMilliseconds;
                Console.Write(shell.SetLocation(Convert.ToDouble(wpt.Lat), Convert.ToDouble(wpt.Long)));
                Thread.Sleep(sleepTime);
            }
            Console.ReadLine();
        }
    }
}
