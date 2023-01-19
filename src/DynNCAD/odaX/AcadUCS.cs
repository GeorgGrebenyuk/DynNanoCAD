#region
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

namespace DynNCAD
{
    /// <summary>
    /// Класс для работы с системами координат чертежа
    /// </summary>
    public class AcadUCS
    {
        public OdaX.AcadUCS ucs;
        internal AcadUCS(OdaX.AcadUCS ucs)
        {
            this.ucs = ucs;
        }
        public AcadUCS (AcadDatabase Database, dg.Point Origin, dg.Point XAxisPoint, dg.Point YAxisPoint, string name)
        {

        }
        public string Origin => this.ucs.Origin;
        public string XVector => this.ucs.XVector;
        public string YVector => this.ucs.YVector;
    }
}
