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

namespace DynNCAD.Objects
{
    /// <summary>
    /// Класс для работы с объектами NanoCAD (общий класс для всех объектов модели)
    /// </summary>
    public class AcadEntity
    {
        public OdaX.AcadEntity entity;
        internal AcadEntity(OdaX.AcadEntity entity)
        {
            this.entity = entity;
        }
        /// <summary>
        /// Из текста
        /// </summary>
        /// <param name="Text"></param>
        public AcadEntity (Annotation.Text Text)
        {
            this.entity = (OdaX.AcadEntity)Text.text;
        }
        /// <summary>
        /// Из МТекста
        /// </summary>
        /// <param name="MText"></param>
        public AcadEntity(Annotation.MText MText)
        {
            this.entity = (OdaX.AcadEntity)MText.mtext;
        }
        #region properies
        /// <summary>
        /// Получение внутреннго объектного идентификатора
        /// </summary>
        public string Handle => this.entity.Handle;
        /// <summary>
        /// Получение класса TeighaX объекта 
        /// </summary>
        public string ObjectName => this.entity.ObjectName;
        /// <summary>
        /// Получение внутреннего текущего объектного идентификатора
        /// </summary>
        public long ObjectID => this.entity.ObjectID;

        /// <summary>
        /// Получение слоя объекта
        /// </summary>
        public string Layer => this.entity.Layer;
        /// <summary>
        /// Получение типа линии
        /// </summary>
        public string Linetype => this.entity.Linetype;
        /// <summary>
        /// Получение масштаба линий
        /// </summary>
        public double LinetypeScale => this.entity.LinetypeScale;
        /// <summary>
        /// Получение видимости объекта
        /// </summary>
        public bool Visible => this.entity.Visible;
        /// <summary>
        /// Получение наименования стиля печати
        /// </summary>
        public string PlotStyleName => this.entity.PlotStyleName;
        /// <summary>
        /// Получение значения веса линий
        /// </summary>
        public int Lineweight => (int)this.entity.Lineweight;
        /// <summary>
        /// Получение наименования материала, связанного с объектом
        /// </summary>
        public string Material => this.entity.Material;
        /// <summary>
        /// Получение наименования сущности
        /// </summary>
        public string EntityName => this.entity.EntityName;
        /// <summary>
        /// Получение типа цвета объекта
        /// </summary>
        public object Color => this.entity.color;
        /// <summary>
        /// Получение интерфейса OdaX.AcadEntity для данного класса 
        /// (как аргумента для конструктора других классов на базе объекта модели)
        /// </summary>
        [dr.IsVisibleInDynamoLibrary(false)]
        public object AsCOM_object => this.entity;
        #endregion
        #region functions_as_SET
        /// <summary>
        /// Назначение слоя объекту
        /// </summary>
        /// <param name="Layer"></param>
        public void SetLayer(string Layer) => this.entity.Layer = Layer;
        /// <summary>
        /// Установка типа линии
        /// </summary>
        /// <param name="Linetype"></param>
        public void SetLinetype(string Linetype) => this.entity.Linetype = Linetype;
        /// <summary>
        /// Установка масштаба линий
        /// </summary>
        /// <param name="LinetypeScale"></param>
        public void SetLinetypeScale(double LinetypeScale) => this.entity.LinetypeScale = LinetypeScale;
        /// <summary>
        /// Установка видимости объектов
        /// </summary>
        /// <param name="Visible"></param>
        public void SetVisible(bool Visible) => this.entity.Visible = Visible;
        /// <summary>
        /// Установка стиля печати
        /// </summary>
        /// <param name="PlotStyleName"></param>
        public void SetPlotStyleName(string PlotStyleName) => this.entity.PlotStyleName = PlotStyleName;
        /// <summary>
        /// Установка значеняи веса линий
        /// </summary>
        /// <param name="Lineweight"></param>
        public void SetLineweight(object Lineweight) => this.entity.Lineweight = (ACAD_LWEIGHT)Lineweight;
        /// <summary>
        /// Присвоение объекту материала по его строковому имени
        /// </summary>
        /// <param name="Material_name"></param>
        public void SetMaterial(string Material_name) => this.entity.Material = Material_name;
        /// <summary>
        /// Установка значеняи цвета объекта
        /// </summary>
        /// <param name="ACAD_COLOR"></param>
        public void SetColor(int ACAD_COLOR) => this.entity.color = (ACAD_COLOR)ACAD_COLOR;
        #endregion
        #region functions
        /// <summary>
        /// Удаление сущности
        /// </summary>
        public void Delete() => this.entity.Delete();
        /// <summary>
        /// Удаление сущности
        /// </summary>
        public void Erase() => this.entity.Erase();
        /// <summary>
        /// Перемещение объекта из точки в точку
        /// </summary>
        /// <param name="FromPoint"></param>
        /// <param name="ToPoint"></param>
        public void Move (dg.Point FromPoint, dg.Point ToPoint)
        {
            this.entity.Move(Tools.PointByDynPoint(FromPoint), Tools.PointByDynPoint(ToPoint));
        }
        /// <summary>
        /// Поворот объекта на угол относительно точки
        /// </summary>
        /// <param name="BasePoint"></param>
        /// <param name="RotationAngle"></param>
        public void Rotate (dg.Point BasePoint, double RotationAngle)
        {
            this.entity.Rotate(Tools.PointByDynPoint(BasePoint), RotationAngle);
        }
        /// <summary>
        /// Отзеркаливание объекта
        /// </summary>
        /// <param name="Point1"></param>
        /// <param name="Point2"></param>
        public void Mirror (dg.Point Point1, dg.Point Point2)
        {
            this.entity.Mirror(Tools.PointByDynPoint(Point1), Tools.PointByDynPoint(Point2));
        }
        /// <summary>
        /// Установка масштаба
        /// </summary>
        /// <param name="BasePoint"></param>
        /// <param name="ScaleFactor"></param>
        public void ScaleEntity (dg.Point BasePoint, double ScaleFactor)
        {
            
            this.entity.ScaleEntity(Tools.PointByDynPoint(BasePoint), ScaleFactor);
        }
        /// <summary>
        /// Получение габарита объекта
        /// </summary>
        /// <returns></returns>
        public List<object> GetBoundingBox()
        {
            object MinPoint;
            object MaxPoint;
            this.entity.GetBoundingBox(out MinPoint, out MaxPoint);
            //return dg.BoundingBox.ByGeometry(new dg.Point(Tools.ToDynamoPoint()))
            return new List<object> { MinPoint, MaxPoint };
        }
        #endregion
    }
}
