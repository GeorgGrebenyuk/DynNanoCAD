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
    /// Класс для работы с эллипсами
    /// </summary>
    public class AcadEllipse
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadEllipse _i;

        public AcadEllipse(General.AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadEllipse != null) this._i = AcadEntity._i as OdaX.AcadEllipse;
            else this._i = null;
        }
        public AcadEllipse(General.AcadBlock Block, dg.Point center, dg.Vector3d MajorAxis, double RadiusRatio)
        {
            this._i = Block._i.AddEllipse(Tools.PointByDynPoint(center), Tools.ToDoubleArray(MajorAxis), RadiusRatio);
        }
        //props
        public dg.Point StartPoint => new dg.Point(this._i.StartPoint[0], this._i.StartPoint[1], this._i.StartPoint[2]);
        public dg.Point Center => new dg.Point(this._i.Center[0], this._i.Center[1], this._i.Center[2]);
        public dg.Point EndPoint => new dg.Point(this._i.EndPoint[0], this._i.EndPoint[1], this._i.EndPoint[2]);
        public double MajorRadius => this._i.MajorRadius;
        public double MinorRadius => this._i.MinorRadius;
        public double RadiusRatio => this._i.RadiusRatio;
        public double StartAngle => this._i.StartAngle;
        public double EndAngle => this._i.EndAngle;
        public double StartParameter => this._i.MajorRadius;
        public double EndParameter => this._i.MajorRadius;
        public double Area => this._i.Area;
        public dg.Vector3d MajorAxis => new dg.Vector3d(this._i.MajorAxis[0], this._i.MajorAxis[1], this._i.MajorAxis[2]);
        public dg.Vector3d MinorAxis => new dg.Vector3d(this._i.MinorAxis[0], this._i.MinorAxis[1], this._i.MinorAxis[2]);
    }
}
