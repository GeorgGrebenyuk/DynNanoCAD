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
        public OdaX.AcadDatabase db;
        /// <summary>
        /// Получение базы данных чертежа
        /// </summary>
        /// <param name="NDocument"></param>
        public AcadDatabase (Document Document)
        {
            this.db = Document._i.Database;
        }
        /// <summary>
        /// Возвращает Block пространства модели чертежа
        /// </summary>
        public AcadBlock ModelSpace => new AcadBlock(this.db.ModelSpace);
        /// <summary>
        /// Получение Block пространства листа (активного?)
        /// </summary>
        public AcadBlock PaperSpace => new AcadBlock(this.db.PaperSpace);
        /// <summary>
        /// Получение Блоков (пространства) листов чертежа
        /// </summary>
        /// <returns></returns>
        public List<AcadBlock> Layouts_AsBlocks()
        {
            List<AcadBlock> blocks = new List<AcadBlock>();
            IAcadBlocks doc_blocks = this.db.Blocks;
            for (int i = 0; i < doc_blocks.Count; i++)
            {
                IAcadBlock bl = doc_blocks.Item(i);
                if (bl.Name.Contains("*Paper_Space"))
                {
                    blocks.Add(new AcadBlock(bl));
                }
            }
            return blocks;
        }

        /// <summary>
        /// Возвращает коллекцию блоков для данного чертежа за исключением пространства Модели и Листов
        /// </summary>
        /// <returns></returns>
        public List<AcadBlock> Blocks()
        {
            List<AcadBlock> blocks = new List<AcadBlock>();
            IAcadBlocks doc_blocks = this.db.Blocks;
            for (int i = 0; i < doc_blocks.Count; i++)
            {
                IAcadBlock bl = doc_blocks.Item(i);
                if (!bl.Name.Contains("*Model_Space") && !bl.Name.Contains("*Paper_Space"))
                {
                    blocks.Add(new AcadBlock(bl));
                }
            }
            return blocks;
        }
        /// <summary>
        /// Получение списка слоев чертежа
        /// </summary>
        /// <returns></returns>
        public List<AcadLayer> GetLayers()
        {
            List<AcadLayer> layers = new List<AcadLayer>();
            var layers_collection = this.db.Layers;
            for (int i = 0; i < layers_collection.Count; i ++)
            {
                layers.Add(new AcadLayer(layers_collection.Item(i)));
            }
            return layers;
        }
        /// <summary>
        /// Получение списка пользовательских систем координат чертежа
        /// </summary>
        /// <returns></returns>
        public List<AcadUCS> GetUCS()
        {
            List<AcadUCS> l = new List<AcadUCS>();
            var ucss = this.db.UserCoordinateSystems;
            for (int i = 0; i < ucss.Count; i ++)
            {
                l.Add(new AcadUCS(ucss.Item(i)));
            }
            return l;
        }
    }
}
