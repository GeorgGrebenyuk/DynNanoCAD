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
    /// Класс для работы с вхождениями блоков
    /// </summary>
    public class AcadBlockReference
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadBlockReference _i;
        /// <summary>
        /// Получение блока из com-интерфейса
        /// </summary>
        /// <param name="BlockReference_object"></param>
        public AcadBlockReference(General.AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadBlockReference != null) this._i = AcadEntity._i as OdaX.AcadBlockReference;
            else this._i = null;
        }
        //public AcadBlockReference(General.AcadBlock AcadBlock, dg.Point InsertionPoint, string Name,
        //    double Xscale = 1.0, double Yscale = 1.0, double Zscale = 1.0, double Rotation = 0.0, object Password = null)
        //{
        //    if (Password == null)
        //    {
        //        this._i = AcadBlock._i.InsertBlock(Tools.PointByDynPoint(InsertionPoint),
        //            Name, Xscale, Yscale, Zscale, Rotation);
        //    }
        //    else this._i = AcadBlock._i.InsertBlock(Tools.PointByDynPoint(InsertionPoint),
        //        Name, Xscale, Yscale, Zscale, Rotation, Password);
        //}
        /// <summary>
        /// Приведение к Вхождению блока COM-интерфейса. Использовать совместно с нодом "InsertBlockReferenceToBlock"
        /// </summary>
        /// <param name="AcadBlockReference"></param>
        public AcadBlockReference (object AcadBlockReference)
        {
            if (AcadBlockReference as OdaX.AcadBlockReference != null) this._i = AcadBlockReference as OdaX.AcadBlockReference;
            else this._i = null;
        }

        //properties
        /// <summary>
        /// Проверка, есть ли атрибуты у блока
        /// </summary>
        public bool HasAttributes => this._i.HasAttributes;
        /// <summary>
        /// Получение точки вставки блока
        /// </summary>
        public object InsertionPoint => this._i.InsertionPoint;
        /// <summary>
        /// Проверка, является ли блок динамическим
        /// </summary>
        public bool IsDynamicBlock => this._i.IsDynamicBlock;
        /// <summary>
        /// Получение имени блока
        /// </summary>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение угла поворота блока
        /// </summary>
        public double Rotation => this._i.Rotation;
        /// <summary>
        /// Задание угла поворота блока
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public double SetRotation(double angle) => this._i.Rotation = angle;
        /// <summary>
        /// Получение масштаба по оси X блока
        /// </summary>
        public double XScaleFactor => this._i.XScaleFactor;
        /// <summary>
        /// Задание масштаба по оси X блока
        /// </summary>
        /// <param name="ScaleFactor"></param>
        /// <returns></returns>
        public double SetXScaleFactor(double ScaleFactor) => this._i.XScaleFactor = ScaleFactor;
        /// <summary>
        /// Получение масштаба по оси Y блока
        /// </summary>
        public double YScaleFactor => this._i.YScaleFactor;
        /// <summary>
        /// Задание масштаба по оси Y блока
        /// </summary>
        /// <param name="ScaleFactor"></param>
        /// <returns></returns>
        public double SetYScaleFactor(double ScaleFactor) => this._i.YScaleFactor = ScaleFactor;
        /// <summary>
        /// Получение масштаба по оси Z блока
        /// </summary>
        public double ZScaleFactor => this._i.ZScaleFactor;
        /// <summary>
        /// Задание масштаба по оси Z блока
        /// </summary>
        /// <param name="ScaleFactor"></param>
        /// <returns></returns>
        public double SetZScaleFactor(double ScaleFactor) => this._i.ZScaleFactor = ScaleFactor;
        //functions

    }
}
