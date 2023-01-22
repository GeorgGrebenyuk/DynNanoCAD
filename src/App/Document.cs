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

namespace DynNCAD.App
{
    /// <summary>
    /// Класс для работы с nanoCAD.Document
    /// Экземпляр документа. Осуществляет управление документом: открытие, сохранение, 
    /// экспорт, импорт, изменение свойств документа, доступ к объектам чертежа.
    /// </summary>
    public class Document
    {
        [dr.IsVisibleInDynamoLibrary(false)]
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
        public object Import (string FileName, dg.Point InsertionPoint, double ScaleFactor)
        {
            return this._i.Import(FileName, Tools.PointByDynPoint(InsertionPoint), ScaleFactor);
        }
        public void AuditInfo(bool FixErr) => this._i.AuditInfo(FixErr);
        public void Save() => this._i.Save();
        public void PurgeAll() => this._i.PurgeAll();
        public object GetVariable(string Name) => this._i.GetVariable(Name);
        public void SetVariable(string Name, object Value) => this._i.SetVariable(Name, Value);
        public void Regen(nanoCAD.AcRegenType WhichViewports) => this._i.Regen(WhichViewports);


    }
}
