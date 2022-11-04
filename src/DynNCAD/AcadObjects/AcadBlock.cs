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

namespace DynNCAD.AcadObjects
{
    /// <summary>
    /// Класс для работы с блоками (не путать с Вхождениями блоков (Block Reference)!)
    /// </summary>
    public partial class AcadBlock : AcadObject
    {
        internal OdaX.AcadBlock block;

        internal AcadBlock (object block)
        {
            this.block = block as OdaX.AcadBlock;
        }

        /// <summary>
        /// Получает имя блока
        /// </summary>
        public string Name => this.block.Name;


    }
}
