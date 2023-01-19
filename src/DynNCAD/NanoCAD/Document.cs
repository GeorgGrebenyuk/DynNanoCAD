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
    /// Класс для работы с nanoCAD.Document
    /// Экземпляр документа. Осуществляет управление документом: открытие, сохранение, 
    /// экспорт, импорт, изменение свойств документа, доступ к объектам чертежа.
    /// </summary>
    public class Document
    {
        public nanoCAD.Document _i;
        /// <summary>
        /// Получает активный документ (проект)
        /// </summary>
        /// <param name="Application"></param>

        public Document(Application Application)
        {
            this._i = Application._i.ActiveDocument;
        }
        internal Document(nanoCAD.Document doc)
        {
            _i = doc;
        }
        /// <summary>
        /// Передает внутреннюю команду из скрипта в документ для выполнения
        /// </summary>
        /// <param name="command"></param>
        public void SendCommand(string command) => this._i.SendCommand(command);
        /// <summary>
        /// Получение полного пути к документу
        /// </summary>
        public string FullName => this._i.FullName;
    }
}
