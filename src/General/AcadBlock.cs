#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;
#endregion

namespace DynNCAD.General
{
    /// <summary>
    /// Класс для работы с блоками (не путать с Вхождениями блоков (Block Reference)!)
    /// </summary>
    public class AcadBlock
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadBlock _i;

        internal AcadBlock(object block)
        {
            this._i = block as OdaX.AcadBlock;
        }

        /// <summary>
        /// Получает имя блока
        /// </summary>
        public string Name => this._i.Name;
        /// <summary>
        /// Получение объектов блока (пространства)
        /// </summary>
        /// <returns></returns>
        public List<AcadEntity> GetObjects()
        {
            List<AcadEntity> objects = new List<AcadEntity>();
            for (int i = 0; i < this._i.Count; i++)
            {
                objects.Add(new AcadEntity(this._i.Item(i)));
            }
            return objects;
        }
    }
}
