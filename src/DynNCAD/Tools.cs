﻿#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;

using nanoCAD;
using OdaX;
#endregion

namespace DynNCAD
{
    internal class Tools
    {
        public static string PointByDynPoint (dg.Point p)
        {
            return $"{p.X},{p.Y},{p.Z}";
        }
    }
}
