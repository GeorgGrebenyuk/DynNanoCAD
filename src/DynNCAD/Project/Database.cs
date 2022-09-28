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
    /// Класс для работы с базой данных объектов чертежа
    /// </summary>
    public class Database
    {
        internal AcadDatabase db;
        /// <summary>
        /// Получение базы данных чертежа
        /// </summary>
        /// <param name="NDocument"></param>
        public Database (NDocument NDocument)
        {
            this.db = NDocument.nc_doc.Database;
        }
        #region properties
        /// <summary>
        /// Возвращает Block пространства модели чертежа
        /// </summary>
        public Project.Block ModelSpace => new Project.Block(this.db.ModelSpace);
        /// <summary>
        /// Получение Block пространства листа (активного?)
        /// </summary>
        public Project.Block PaperSpace => new Project.Block(this.db.PaperSpace);
        /// <summary>
        /// Получение Блоков (пространства) листов чертежа
        /// </summary>
        /// <returns></returns>
        public List<Project.Block> Layouts_AsBlocks()
        {
            List<Project.Block> blocks = new List<Project.Block>();
            IAcadBlocks doc_blocks = this.db.Blocks;
            for (int i = 0; i < doc_blocks.Count; i++)
            {
                IAcadBlock bl = doc_blocks.Item(i);
                if (bl.Name.Contains("*Paper_Space"))
                {
                    blocks.Add(new Project.Block(bl));
                }
            }
            return blocks;
        }
        /// Возвращает коллекцию блоков для данного чертежа за исключением пространства Модели и Листов
        /// </summary>
        /// <param name="NDocument">Текущий документ модели</param>
        /// <returns></returns>
        public List<Project.Block> Blocks()
        {
            List<Project.Block> blocks = new List<Project.Block>();
            IAcadBlocks doc_blocks = this.db.Blocks;
            for (int i = 0; i < doc_blocks.Count; i++)
            {
                IAcadBlock bl = doc_blocks.Item(i);
                if (!bl.Name.Contains("*Model_Space") && !bl.Name.Contains("*Paper_Space"))
                {
                    blocks.Add(new Project.Block(bl));
                }
            }
            return blocks;
        }
        /// <summary>
        /// Получение списка слоев чертежа
        /// </summary>
        /// <returns></returns>
        public List<Layer> GetLayers()
        {
            List<Layer> layers = new List<Layer>();
            var layers_collection = this.db.Layers;
            for (int i = 0; i < layers_collection.Count; i ++)
            {
                layers.Add(new Layer(layers_collection.Item(i)));
            }
            return layers;
        }
        /// <summary>
        /// Получение списка пользовательских систем координат чертежа
        /// </summary>
        /// <returns></returns>
        public List<Project.UCS> GetUCS()
        {
            List<Project.UCS> l = new List<UCS>();
            var ucss = this.db.UserCoordinateSystems;
            for (int i = 0; i < ucss.Count; i ++)
            {
                l.Add(new UCS(ucss.Item(i)));
            }
            return l;
        }
        #endregion
    }
}
