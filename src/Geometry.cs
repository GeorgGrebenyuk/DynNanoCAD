#region include_namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;
using dg2 = Autodesk.DesignScript.Geometry;

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
        //public dg2.Point AsDynamoGeometry()
        //{
        //    return dg2.Point.ByCoordinates(X, Y, Z);
        //}
    }
    public class Vector3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector3d(double x, double y, double z)
        {
            this.X = x; this.Y = y; this.Z = z;
        }
        //public dg2.Vector AsDynamoGeometry()
        //{
        //    return dg2.Vector.ByCoordinates(X, Y, Z);
        //}
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
        //public dg2.Line AsDynamoGeometry()
        //{
        //    return dg2.Line.ByStartPointEndPoint(StartPoint.AsDynamoGeometry(), EndPoint.AsDynamoGeometry());
        //}
    }
    public class LineString
    {
        public Point[] Points { get; set; }
        public LineString(Point[] points)
        {
            this.Points = points;
        }
        //public dg2.PolyCurve AsDynamoGeometry()
        //{
        //    return dg2.PolyCurve.ByPoints(Points.Select(a=>a.AsDynamoGeometry()));
        //}
    }
}
