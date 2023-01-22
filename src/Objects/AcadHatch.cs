//#region
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using dr = Autodesk.DesignScript.Runtime;
//using dg = DynNCAD.Geometry;

//using nanoCAD;
//using OdaX;
//#endregion

//namespace DynNCAD.Objects
//{
//    /// <summary>
//    /// Класс для работы со штриховками
//    /// </summary>
//    public class AcadHatch
//    {
//        [dr.IsVisibleInDynamoLibrary(false)]
//        public OdaX.IAcadHatch _i;

//        public AcadHatch(General.AcadEntity AcadEntity)
//        {
//            if (AcadEntity._i as OdaX.IAcadHatch != null) this._i = AcadEntity._i as OdaX.IAcadHatch;
//            else this._i = null;

//        }

//        //public AcadHatch(General.AcadBlock Block, int PatternType, string PatternName,
//        //    bool Associativity, object HatchObjectType = null)
//        //{
//        //    if (HatchObjectType == null) this._i = Block._i.AddHatch(PatternType, PatternName, Associativity);
//        //    else
//        //    {
//        //        this._i = Block._i.AddHatch(PatternType, PatternName, Associativity, HatchObjectType);
//        //    }
//        //}
//        public AcadHatch(General.AcadBlock Block, int PatternType, string PatternName, bool Associativity)
//        {
//            this._i = Block._i.AddHatch(PatternType, PatternName, Associativity);
//        }

//        //props
//        //public string PatternType => this._i.PatternType.ToString();
//        //public string PatternName => this._i.PatternName;
//        //public double PatternAngle => this._i.PatternAngle;
//        //public double PatternScale => this._i.PatternScale;
//        //public double PatternSpace => this._i.PatternSpace;
//        //public string ISOPenWidth => this._i.ISOPenWidth.ToString();
//        //public bool PatternDouble => this._i.PatternDouble;
//        //public double Elevation => this._i.Elevation;
//        //public bool AssociativeHatch => this._i.AssociativeHatch;
//        //public string HatchStyle => this._i.HatchStyle.ToString();
//        //public string GradientColor1 => this._i.GradientColor1.ToString();
//        //public string GradientColor2 => this._i.GradientColor2.ToString();
//        //public double GradientAngle => this._i.GradientAngle;
//        //public bool GradientCentered => this._i.GradientCentered;
//        //public string GradientName => this._i.GradientName;
//        //public string HatchObjectType => this._i.HatchObjectType.ToString();
//        //public double Area => this._i.Area;
//    }
//}
