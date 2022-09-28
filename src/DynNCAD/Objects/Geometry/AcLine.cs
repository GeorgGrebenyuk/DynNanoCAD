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

namespace DynNCAD.Objects.Geometry
{
    /// <summary>
    /// Класс для работы с отрезками
    /// </summary>
    public class AcLine
    {
        internal OdaX.AcadLine line;
        /// <summary>
        /// Получение отрезка из объекта модели AcadEntity
        /// </summary>
        /// <param name="AcadEntity"></param>
        public AcLine (AcadEntity AcadEntity)
        {
            if (AcadEntity.entity as AcadLine != null) this.line = AcadEntity.entity as AcadLine;
            else this.line = null;
        }
        /// <summary>
        /// Создание отрезка по начальной и конечной точке
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="StartPoint">Начальная точка</param>
        /// <param name="EndPoint">Конечная точка</param>
        public AcLine (Project.Block Block, dg.Point StartPoint, dg.Point EndPoint)
        {
            this.line = Block.block.AddLine(Tools.PointByDynPoint(StartPoint), Tools.PointByDynPoint(EndPoint));
        }
        //properties
        /// <summary>
        /// Получение угла на который повернут отрезок
        /// </summary>
        public double Angle => this.line.Angle;
        /// <summary>
        /// Получение длины отрезка
        /// </summary>
        public double Length => this.line.Length;
        /// <summary>
        /// Получение толщины отрезка
        /// </summary>
        public double Thickness => this.line.Thickness;
        /// <summary>
        /// Получение начальной точки отрезка
        /// </summary>
        public dg.Point StartPoint => Tools.ToDynamoPoint(this.line.StartPoint);
        /// <summary>
        /// Получение конечной точки отрезка
        /// </summary>
        public dg.Point EndPoint => Tools.ToDynamoPoint(this.line.EndPoint);
    }
}
