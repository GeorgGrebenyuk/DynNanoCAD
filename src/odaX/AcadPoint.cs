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

namespace DynNCAD
{
    /// <summary>
    /// Класс для работы с точками NanoCAD
    /// </summary>
    public class AcadPoint
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadPoint _i;
        /// <summary>
        /// Получение точки как объекта чертежа
        /// </summary>
        /// <param name="AcadEntity"></param>
        public AcadPoint (AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadPoint != null) this._i = AcadEntity._i as OdaX.AcadPoint;
            else this._i = null;
        }
        /// <summary>
        /// Создание точки в указанной позиции
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="insertion_point"></param>
        public AcadPoint (AcadBlock Block, dg.Point insertion_point)
        {
            this._i = Block._i.AddPoint(Tools.PointByDynPoint(insertion_point));
        }
        /// <summary>
        /// Получение координаты точки
        /// </summary>
        public dg.Point Coordinates => new dg.Point(this._i.Coordinates[0], this._i.Coordinates[1], this._i.Coordinates[2]);

    }
}
