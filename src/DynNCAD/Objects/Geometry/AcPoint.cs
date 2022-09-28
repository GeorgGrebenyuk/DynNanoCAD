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
    /// Класс для работы с точками NanoCAD
    /// </summary>
    public class AcPoint
    {
        internal AcadPoint point;
        /// <summary>
        /// Получение точки как объекта чертежа
        /// </summary>
        /// <param name="AcadEntity"></param>
        public AcPoint (AcadEntity AcadEntity)
        {
            if (AcadEntity.entity as AcadPoint != null) this.point = AcadEntity.entity as AcadPoint;
            else this.point = null;
        }
        /// <summary>
        /// Создание точки в указанной позиции
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="insertion_point"></param>
        public AcPoint (Project.Block Block, dg.Point insertion_point)
        {
            this.point = Block.block.AddPoint(Tools.PointByDynPoint(insertion_point));
        }
        /// <summary>
        /// Получение координаты точки
        /// </summary>
        public dg.Point Coordinates => Tools.ToDynamoPoint(this.point.Coordinates);

    }
}
