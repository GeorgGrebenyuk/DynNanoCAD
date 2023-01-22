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

namespace DynNCAD.General
{
    /// <summary>
    /// Класс для работы с объектами NanoCAD (общий класс для всех сущностей объектов модели)
    /// </summary>
    public class AcadEntity
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadEntity _i;
        public AcadEntity(dynamic sub_class)
        {
            if (sub_class as OdaX.AcadEntity != null) this._i = sub_class as OdaX.AcadEntity;
            else this._i = null;
        }
        internal AcadEntity() { }
        internal AcadEntity(OdaX.AcadEntity entity)
        {
            this._i = entity;
        }
        /// <summary>
        /// Получение слоя объекта
        /// </summary>
        public string Layer => this._i.Layer;
        /// <summary>
        /// Получение типа линии
        /// </summary>
        public string Linetype => this._i.Linetype;
        /// <summary>
        /// Получение масштаба линий
        /// </summary>
        public double LinetypeScale => this._i.LinetypeScale;
        /// <summary>
        /// Получение видимости объекта
        /// </summary>
        public bool Visible => this._i.Visible;
        /// <summary>
        /// Получение наименования стиля печати
        /// </summary>
        public string PlotStyleName => this._i.PlotStyleName;
        /// <summary>
        /// Получение значения веса линий
        /// </summary>
        public int Lineweight => (int)this._i.Lineweight;
        /// <summary>
        /// Получение наименования материала, связанного с объектом
        /// </summary>
        public string Material => this._i.Material;
        /// <summary>
        /// Получение наименования сущности
        /// </summary>
        public string EntityName => this._i.EntityName;
        /// <summary>
        /// Получение типа цвета объекта
        /// </summary>
        public object Color => this._i.color;

        /// <summary>
        /// Назначение слоя объекту
        /// </summary>
        /// <param name="Layer"></param>
        public void SetLayer(string Layer) => this._i.Layer = Layer;
        /// <summary>
        /// Установка типа линии
        /// </summary>
        /// <param name="Linetype"></param>
        public void SetLinetype(string Linetype) => this._i.Linetype = Linetype;
        /// <summary>
        /// Установка масштаба линий
        /// </summary>
        /// <param name="LinetypeScale"></param>
        public void SetLinetypeScale(double LinetypeScale) => this._i.LinetypeScale = LinetypeScale;
        /// <summary>
        /// Установка видимости объектов
        /// </summary>
        /// <param name="Visible"></param>
        public void SetVisible(bool Visible) => this._i.Visible = Visible;
        /// <summary>
        /// Установка стиля печати
        /// </summary>
        /// <param name="PlotStyleName"></param>
        public void SetPlotStyleName(string PlotStyleName) => this._i.PlotStyleName = PlotStyleName;
        /// <summary>
        /// Установка значеняи веса линий
        /// </summary>
        /// <param name="Lineweight"></param>
        public void SetLineweight(object Lineweight) => this._i.Lineweight = (ACAD_LWEIGHT)Lineweight;
        /// <summary>
        /// Присвоение объекту материала по его строковому имени
        /// </summary>
        /// <param name="Material_name"></param>
        public void SetMaterial(string Material_name) => this._i.Material = Material_name;
        /// <summary>
        /// Установка значеняи цвета объекта
        /// </summary>
        /// <param name="ACAD_COLOR"></param>
        public void SetColor(int ACAD_COLOR) => this._i.color = (ACAD_COLOR)ACAD_COLOR;
        /// <summary>
        /// Перемещение объекта из точки в точку
        /// </summary>
        /// <param name="FromPoint"></param>
        /// <param name="ToPoint"></param>
        public void Move(dg.Point FromPoint, dg.Point ToPoint)
        {
            this._i.Move(Tools.PointByDynPoint(FromPoint), Tools.PointByDynPoint(ToPoint));
        }
        /// <summary>
        /// Поворот объекта на угол относительно точки
        /// </summary>
        /// <param name="BasePoint"></param>
        /// <param name="RotationAngle"></param>
        public void Rotate(dg.Point BasePoint, double RotationAngle)
        {
            this._i.Rotate(Tools.PointByDynPoint(BasePoint), RotationAngle);
        }
        /// <summary>
        /// Отзеркаливание объекта
        /// </summary>
        /// <param name="Point1"></param>
        /// <param name="Point2"></param>
        public void Mirror(dg.Point Point1, dg.Point Point2)
        {
            this._i.Mirror(Tools.PointByDynPoint(Point1), Tools.PointByDynPoint(Point2));
        }
        /// <summary>
        /// Установка масштаба
        /// </summary>
        /// <param name="BasePoint"></param>
        /// <param name="ScaleFactor"></param>
        public void ScaleEntity(dg.Point BasePoint, double ScaleFactor)
        {

            this._i.ScaleEntity(Tools.PointByDynPoint(BasePoint), ScaleFactor);
        }
        /// <summary>
        /// Получение габарита объекта
        /// </summary>
        /// <returns></returns>
        public List<object> GetBoundingBox()
        {
            object MinPoint;
            object MaxPoint;
            this._i.GetBoundingBox(out MinPoint, out MaxPoint);
            //return dg.BoundingBox.ByGeometry(new dg.Point(Tools.ToDynamoPoint()))
            return new List<object> { MinPoint, MaxPoint };
        }
    }
}
