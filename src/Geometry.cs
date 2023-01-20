#region include_namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;

using nanoCAD;
using OdaX;
#endregion

namespace DynNCAD.Geometry
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point(double x, double y, double z)
        {
            this.X = x; this.Y = y; this.Z = z;
        }
    }
    public class Line
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Line(Point start_point, Point end_point)
        {
            this.StartPoint = start_point;
            this.EndPoint = end_point;
        }
    }
    public class LineString
    {
        public Point[] Points { get; set; }
        public LineString(Point[] points)
        {
            this.Points = points;
        }
    }
}
