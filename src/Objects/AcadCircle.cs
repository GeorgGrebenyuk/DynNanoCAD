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

namespace DynNCAD.Objects
{
    /// <summary>
    /// Класс для работы с окружностями
    /// </summary>
    public class AcadCircle
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadCircle _i;

        public AcadCircle(General.AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadCircle != null) this._i = AcadEntity._i as OdaX.AcadCircle;
            else this._i = null;
            
        }

        public AcadCircle(General.AcadBlock Block, dg.Point center, double radius)
        {
            this._i = Block._i.AddCircle(Tools.PointByDynPoint(center), radius);
        }
        public object Center => this._i.Center;
        public double Radius => this._i.Radius;
        public void SetRadius(double Radius) => this._i.Radius = Radius;
        public double Area => this._i.Area;
        public double Circumference => this._i.Circumference;
    }
}
