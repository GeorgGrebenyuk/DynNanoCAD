#region
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

namespace DynNCAD.Project
{
    /// <summary>
    /// Класс для работы с системами координат чертежа
    /// </summary>
    public class UCS
    {
        internal OdaX.AcadUCS ucs;
        internal UCS(OdaX.AcadUCS ucs)
        {
            this.ucs = ucs;
        }
        public UCS (Database Database, dg.CoordinateSystem CoordinateSystem)
        {

        }
        public UCS (Database Database, dg.Point Origin, dg.Point XAxisPoint, dg.Point YAxisPoint, string name)
        {

        }
        public string Origin => this.ucs.Origin;
        public string XVector => this.ucs.XVector;
        public string YVector => this.ucs.YVector;
    }
}
