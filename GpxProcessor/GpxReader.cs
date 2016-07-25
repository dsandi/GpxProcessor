using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GpxProcessor
{
    public class GpxReader
    {
        private readonly string _path;
        private XDocument _xDocumentfile;
        private XNamespace _gpx;

        public GpxReader(string path)
        {
            _path = path;
            _init();
        }

        private void _init()
        {
            _xDocumentfile = XDocument.Load(_path);
            _gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
        }

        public IEnumerable<WayPoint> LoadWayPoints()
        {
            return (from waypoint in _xDocumentfile.Descendants(_gpx + "wpt")
                let timeElement = waypoint.Element(_gpx + "time")
                where timeElement != null
                select new
                {
                    Latitude = waypoint.Attribute("lat").Value, Longitude = waypoint.Attribute("lon").Value, Time = timeElement.Value
                }).Select(wpt => new WayPoint
                {
                    Lat = wpt.Latitude, Long = wpt.Longitude, Time = wpt.Time
                }).ToList();
        }
    }

    public class WayPoint
    {
        public string Lat { get; set; }
        public string Long { set; get; }
        public string Time { get; set; }
    }
}