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
    /// Класс для работы с nanoCAD.Document
    /// Экземпляр документа. Осуществляет управление документом: открытие, сохранение, 
    /// экспорт, импорт, изменение свойств документа, доступ к объектам чертежа.
    /// </summary>
    public class NDocument
    {
        internal nanoCAD.Document nc_doc;
        /// <summary>
        /// Получает активный документ (проект)
        /// </summary>
        /// <param name="ncad_app"></param>

        public NDocument(Application ncad_app)
        {
            this.nc_doc = ncad_app.ncad_app.ActiveDocument;
        }
        internal NDocument(nanoCAD.Document doc)
        {
            nc_doc = doc;
        }
        /// <summary>
        /// Передает внутреннюю команду из скрипта в документ для выполнения
        /// </summary>
        /// <param name="command"></param>
        public void SendCommand(string command) => this.nc_doc.SendCommand(command);
        /// <summary>
        /// Устанавливает активный размерный стиль документа
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public object SetActiveDimStyle(Styles.DimStyle style) => this.nc_doc.ActiveDimStyle = style.style;

        /// Возвращает коллекцию блоков для данного чертежа за исключением пространства Модели и Листов
        /// </summary>
        /// <param name="NDocument">Текущий документ модели</param>
        /// <returns></returns>
        public List<Project.Block> Blocks()
        {
            List<Project.Block> blocks = new List<Project.Block>();
            IAcadBlocks doc_blocks = nc_doc.Blocks;
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
        /// Получение полного пути к документу
        /// </summary>
        public string FullName => this.nc_doc.FullName;
        /// <summary>
        /// Возвращает Block пространства модели чертежа
        /// </summary>
        public Project.Block ModelSpace => new Project.Block(this.nc_doc.ModelSpace);
        /// <summary>
        /// Получение Блоков (пространства) листов чертежа
        /// </summary>
        /// <returns></returns>
        public List<Project.Block> Layouts_AsBlocks()
        {
            List<Project.Block> blocks = new List<Project.Block>();
            IAcadBlocks doc_blocks = nc_doc.Blocks;
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
        /// <summary>
        /// Получение слоев чертежа
        /// </summary>
        /// <returns></returns>
        public List<Layer> Layers()
        {
            List<Layer> ls = new List<Layer>();
            AcadLayers ls_collection = this.nc_doc.Layers;
            for (int i =0; i < ls_collection.Count; i++)
            {
                ls.Add(new Layer(ls_collection.Item(i)));
            }
            return ls;
        }


    }
}
