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

namespace DynNCAD.App
{
    public class AcadExternalReference
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.IAcadExternalReference _i;

        internal AcadExternalReference(General.AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadExternalReference != null) this._i = AcadEntity._i as OdaX.AcadExternalReference;
            else this._i = null;

        }
        //public AcadExternalReference(General.AcadBlock AcadBlock, string Path, string Name, dg.Point InsertionPoint,
        //    double Xscale = 1.0, double Yscale = 1.0, double Zscale = 1.0, double Rotation = 0.0,
        //    bool Overlay = false, string Password = null)
        //{
        //    if (Password == null)
        //    {
        //        this._i = AcadBlock._i.AttachExternalReference(Path, Name, Tools.PointByDynPoint(InsertionPoint), Xscale,
        //            Yscale, Zscale, Rotation, Overlay);
        //    }
        //    else this._i = AcadBlock._i.AttachExternalReference(Path, Name, Tools.PointByDynPoint(InsertionPoint), Xscale,
        //            Yscale, Zscale, Rotation, Overlay, Password);
        //}
        //props
        public string Path => this._i.Path;
        //public void SetPath (string Path) => this._i.Path = Path;
    }
}
