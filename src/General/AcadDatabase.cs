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

namespace DynNCAD.General
{
    /// <summary>
    /// Класс для работы с базой данных объектов чертежа
    /// </summary>
    public class AcadDatabase
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadDatabase _i;
        /// <summary>
        /// Получение базы данных чертежа
        /// </summary>
        /// <param name="NDocument"></param>
        public AcadDatabase (DynNCAD.App.Document Document)
        {
            this._i= Document._i.Database;
        }
        /// <summary>
        /// Возвращает Block пространства модели чертежа
        /// </summary>
        public AcadBlock ModelSpace => new AcadBlock(this._i.ModelSpace);
        /// <summary>
        /// Получение Block пространства листа (активного?)
        /// </summary>
        public AcadBlock PaperSpace => new AcadBlock(this._i.PaperSpace);
        /// <summary>
        /// Получение Блоков (пространства) листов чертежа
        /// </summary>
        /// <returns></returns>
        public List<AcadBlock> Layouts_AsBlocks()
        {
            List<AcadBlock> blocks = new List<AcadBlock>();
            IAcadBlocks doc_blocks = this._i.Blocks;
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
            IAcadBlocks doc_blocks = this._i.Blocks;
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
            var layers_collection = this._i.Layers;
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
            var ucss = this._i.UserCoordinateSystems;
            for (int i = 0; i < ucss.Count; i ++)
            {
                l.Add(new AcadUCS(ucss.Item(i)));
            }
            return l;
        }
        public List<DynNCAD.App.AcadFileDependency> FileDependencies()
        {
            List<DynNCAD.App.AcadFileDependency> deps = new List<DynNCAD.App.AcadFileDependency>();
            for (int i = 1; i <= this._i.FileDependencies.Count; i++)
            {
                DynNCAD.App.AcadFileDependency dep = new DynNCAD.App.AcadFileDependency(this._i.FileDependencies.Item(i));
                deps.Add(dep);
            }
            return deps;
        }
        public DynNCAD.App.AcadSummaryInfo SummaryInfo => new DynNCAD.App.AcadSummaryInfo(this._i.SummaryInfo);
        public List<AcadMaterial> Materials()
        {
            List<AcadMaterial> mats = new List<AcadMaterial>();
            for (int i = 0; i < this._i.Materials.Count; i++)
            {
                mats.Add(new AcadMaterial(this._i.Materials.Item(i)));
            }
            return mats;
        }
        public List<AcadGroup> GetAllAcadGroups()
        {
            List<AcadGroup> groups = new List<AcadGroup>();
            for (int i = 0; i < this._i.Groups.Count; i++)
            {
                groups.Add(new AcadGroup(this._i.Groups.Item(i)));
            }
            return groups;
        }

    }
}
