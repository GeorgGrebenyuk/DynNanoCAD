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
    /// Класс для работы с базой данных объектов чертежа
    /// </summary>
    public class AcadDatabase
    {
        internal OdaX.AcadDatabase db;
        /// <summary>
        /// Получение базы данных чертежа
        /// </summary>
        /// <param name="NDocument"></param>
        public AcadDatabase (NanoCAD.Document Document)
        {
            this.db = Document._i.Database;
        }
        #region properties
        /// <summary>
        /// Возвращает Block пространства модели чертежа
        /// </summary>
        public AcadObjects.AcadBlock ModelSpace => new AcadObjects.AcadBlock(this.db.ModelSpace);
        /// <summary>
        /// Получение Block пространства листа (активного?)
        /// </summary>
        public AcadObjects.AcadBlock PaperSpace => new AcadObjects.AcadBlock(this.db.PaperSpace);
        /// <summary>
        /// Получение Блоков (пространства) листов чертежа
        /// </summary>
        /// <returns></returns>
        public List<AcadObjects.AcadBlock> Layouts_AsBlocks()
        {
            List<AcadObjects.AcadBlock> blocks = new List<AcadObjects.AcadBlock>();
            IAcadBlocks doc_blocks = this.db.Blocks;
            for (int i = 0; i < doc_blocks.Count; i++)
            {
                IAcadBlock bl = doc_blocks.Item(i);
                if (bl.Name.Contains("*Paper_Space"))
                {
                    blocks.Add(new AcadObjects.AcadBlock(bl));
                }
            }
            return blocks;
        }

        /// <summary>
        /// Возвращает коллекцию блоков для данного чертежа за исключением пространства Модели и Листов
        /// </summary>
        /// <returns></returns>
        public List<AcadObjects.AcadBlock> Blocks()
        {
            List<AcadObjects.AcadBlock> blocks = new List<AcadObjects.AcadBlock>();
            IAcadBlocks doc_blocks = this.db.Blocks;
            for (int i = 0; i < doc_blocks.Count; i++)
            {
                IAcadBlock bl = doc_blocks.Item(i);
                if (!bl.Name.Contains("*Model_Space") && !bl.Name.Contains("*Paper_Space"))
                {
                    blocks.Add(new AcadObjects.AcadBlock(bl));
                }
            }
            return blocks;
        }
        /// <summary>
        /// Получение списка слоев чертежа
        /// </summary>
        /// <returns></returns>
        public List<AcadObjects.AcadLayer> GetLayers()
        {
            List<AcadObjects.AcadLayer> layers = new List<AcadObjects.AcadLayer>();
            var layers_collection = this.db.Layers;
            for (int i = 0; i < layers_collection.Count; i ++)
            {
                layers.Add(new AcadObjects.AcadLayer(layers_collection.Item(i)));
            }
            return layers;
        }
        /// <summary>
        /// Получение списка пользовательских систем координат чертежа
        /// </summary>
        /// <returns></returns>
        public List<AcadObjects.AcadUCS> GetUCS()
        {
            List<AcadObjects.AcadUCS> l = new List<AcadObjects.AcadUCS>();
            var ucss = this.db.UserCoordinateSystems;
            for (int i = 0; i < ucss.Count; i ++)
            {
                l.Add(new AcadObjects.AcadUCS(ucss.Item(i)));
            }
            return l;
        }
        #endregion
    }
}
