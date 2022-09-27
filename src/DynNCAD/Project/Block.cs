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

namespace DynNCAD.Project
{
    /// <summary>
    /// Класс для работы с блоками (не путать с Вхождениями блоков (Block Reference)!)
    /// </summary>
    public partial class Block
    {
        internal OdaX.AcadBlock block;

        internal Block (object block)
        {
            this.block = block as OdaX.AcadBlock;
        }

        /// <summary>
        /// Получает имя блока
        /// </summary>
        public string Name => this.block.Name;

        //functions
        public void Add3DFace(dg.Point p1, dg.Point p2, dg.Point p3, dg.Point p4)
        {
            var object_3d_face = this.block.Add3DFace(
                Tools.PointByDynPoint(p1),
                Tools.PointByDynPoint(p2),
                Tools.PointByDynPoint(p3),
                Tools.PointByDynPoint(p4));
        }

    }
}
