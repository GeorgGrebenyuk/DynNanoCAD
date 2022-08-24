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
        public NDocument (Application ncad_app)
        {
            this.nc_doc = ncad_app.ncad_app.ActiveDocument;
        }
        /// <summary>
        /// Передает внутреннюю команду из скрипта в документ для выполнения
        /// </summary>
        /// <param name="command"></param>
        public void SendCommand (string command) => this.nc_doc.SendCommand(command);
        /// <summary>
        /// Устанавливает активный размерный стиль документа
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public object SetActiveDimStyle (Styles.DimStyle style) => this.nc_doc.ActiveDimStyle = style.style;

        /// Возвращает коллекцию блоков для данного чертежа за исключением пространства Модели и Листов
        /// </summary>
        /// <param name="NDocument">Текущий документ модели</param>
        /// <returns></returns>
        public static List<Objects.Block> Blocks(Project.NDocument NDocument)
        {
            List<Objects.Block> blocks = new List<Objects.Block>();
            IAcadBlocks doc_blocks = NDocument.nc_doc.Blocks;
            for (int i = 0; i < doc_blocks.Count; i++) { blocks.Add(new Objects.Block(doc_blocks.Item(i))); }
            return blocks;
        }
        /// <summary>
        /// Получение полного пути к документу
        /// </summary>
        public string FullName => this.nc_doc.FullName;
        /// <summary>
        /// Возвращает Block пространства модели чертежа
        /// </summary>
        public Objects.Block ModelSpace => new Objects.Block( this.nc_doc.ModelSpace);

    }
}
