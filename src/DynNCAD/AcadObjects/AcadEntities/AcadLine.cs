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

namespace DynNCAD.AcadObjects.AcadEntities
{
    /// <summary>
    /// Класс для работы с отрезками
    /// </summary>
    public class AcadLine : AcadEntity
    {
        internal OdaX.AcadLine _i;
        /// <summary>
        /// Получение отрезка из объекта модели AcadEntity
        /// </summary>
        /// <param name="AcadEntity"></param>
        public AcadLine(AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadLine != null) this._i = AcadEntity._i as OdaX.AcadLine;
            else this._i = null;
        }
        /// <summary>
        /// Создание отрезка по начальной и конечной точке
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="StartPoint">Начальная точка</param>
        /// <param name="EndPoint">Конечная точка</param>
        public AcadLine(AcadObjects.AcadBlock Block, dg.Point StartPoint, dg.Point EndPoint)
        {
            this._i = Block._i.AddLine(Tools.PointByDynPoint(StartPoint), Tools.PointByDynPoint(EndPoint));
        }
        //properties
        /// <summary>
        /// Получение угла на который повернут отрезок
        /// </summary>
        public double Angle => this._i.Angle;
        /// <summary>
        /// Получение длины отрезка
        /// </summary>
        public double Length => this._i.Length;
        /// <summary>
        /// Получение толщины отрезка
        /// </summary>
        public double Thickness => this._i.Thickness;
        /// <summary>
        /// Получение начальной точки отрезка
        /// </summary>
        public dg.Point StartPoint => Tools.ToDynamoPoint(this._i.StartPoint);
        /// <summary>
        /// Получение конечной точки отрезка
        /// </summary>
        public dg.Point EndPoint => Tools.ToDynamoPoint(this._i.EndPoint);
    }
}
