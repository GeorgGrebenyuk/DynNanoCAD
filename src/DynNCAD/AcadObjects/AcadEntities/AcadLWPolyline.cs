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

namespace DynNCAD.AcadObjects.AcadEntities
{
    /// <summary>
    /// Класс для работы с полилиниями (устаревший тип AcDbPolyline = AcadLWPolyline)
    /// </summary>
    public class AcadLWPolyline : AcadEntity
    {
        internal OdaX.AcadLWPolyline _i;

        //internal AcadLWPolyline lw_pline;
        /// <summary>
        /// Получение полилинии из объекта модели, если это тот тип
        /// </summary>
        /// <param name="AcadEntity"></param>
        public AcadLWPolyline(AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadLWPolyline != null) this._i = AcadEntity._i as OdaX.AcadLWPolyline;
            else this._i = null;
        }
        /// <summary>
        /// Создание плоской полилинии из набора точек
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="points"></param>
        public AcadLWPolyline(AcadObjects.AcadBlock Block, List<dg.Point> points)
        {
            List<double> pnts = new List<double>();
            foreach (var p in points)
            {
                pnts.Add(p.X);
                pnts.Add(p.Y);
            }
            var pl = Block._i.AddLightWeightPolyline(string.Join(",", pnts));
            this._i = pl;
        }
        //properties
        /// <summary>
        /// Получение статуса замкнутости линии
        /// </summary>
        public bool Closed => this._i.Closed;

        /// <summary>
        /// Получение координат линии
        /// </summary>
        /// <returns></returns>
        public List<dg.Point> Coordinates()
        {
            IEnumerable<double> planar_points_row = this._i.Coordinates;
            List<double> planar_points = planar_points_row.ToList();
            List<dg.Point> points = new List<dg.Point>();
            for (int i = 0; i < planar_points.Count() - 1; i += 2)
            {
                points.Add(new dg.Point(planar_points[i], planar_points[i + 1], 0d));
            }
            return points;
        }
        //functions
        /// <summary>
        /// Установка замкнутости линии
        /// </summary>
        /// <param name="Closed"></param>
        public void SetClosed(bool Closed) => this._i.Closed = Closed;
    }
}
