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
    /// Класс для работы с полилиниями (устаревший тип AcDbPolyline = AcadLWPolyline)
    /// </summary>
    public class AcLwPolyline
    {
        internal AcadLWPolyline lw_pline;

        //internal AcadLWPolyline lw_pline;
        /// <summary>
        /// Получение полилинии из объекта модели, если это тот тип
        /// </summary>
        /// <param name="AcadEntity"></param>
        public AcLwPolyline(AcadEntity AcadEntity)
        {
            if (AcadEntity.entity as AcadLWPolyline != null) this.lw_pline = AcadEntity.entity as AcadLWPolyline;
            else this.lw_pline = null;
        }
        /// <summary>
        /// Создание плоской полилинии из набора точек
        /// </summary>
        /// <param name="Block"></param>
        /// <param name="points"></param>
        public AcLwPolyline(Project.Block Block, List<dg.Point> points)
        {
            List<double> pnts = new List<double>();
            foreach (var p in points)
            {
                pnts.Add(p.X);
                pnts.Add(p.Y);
            }
            var pl = Block.block.AddLightWeightPolyline(string.Join(",", pnts));
            this.lw_pline = pl;
        }
        //properties
        /// <summary>
        /// Получение статуса замкнутости линии
        /// </summary>
        public bool Closed => this.lw_pline.Closed;

        /// <summary>
        /// Получение координат линии
        /// </summary>
        /// <returns></returns>
        public List<dg.Point> Coordinates()
        {
            IEnumerable<double> planar_points_row =  this.lw_pline.Coordinates;
            List<double> planar_points = planar_points_row.ToList();
            List<dg.Point> points = new List<dg.Point>();
            for (int i = 0; i < planar_points.Count() -1; i +=2)
            {
                points.Add(dg.Point.ByCoordinates(planar_points[i], planar_points[i + 1]));
            }
            return points;
        }
        //functions
        /// <summary>
        /// Установка замкнутости линии
        /// </summary>
        /// <param name="Closed"></param>
        public void SetClosed(bool Closed) => this.lw_pline.Closed = Closed;
    }
}
