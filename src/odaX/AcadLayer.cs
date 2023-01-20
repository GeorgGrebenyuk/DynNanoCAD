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
    /// Класс для работы со слоями
    /// </summary>
    public class AcadLayer
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadLayer _i;
        internal AcadLayer (OdaX.AcadLayer layer)
        {
            this._i = layer;
        }
        /// <summary>
        /// Создание нового слоя по имени
        /// </summary>
        /// <param name="Database"></param>
        /// <param name="Name"></param>
        public AcadLayer (AcadDatabase Database, string Name)
        {
            this._i = Database._i.Layers.Add(Name);
        }
        /// <summary>
        /// Получение описания слоя
        /// </summary>
        public string Description => _i.Description;
        /// <summary>
        /// Установка описания слоя
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        public AcadLayer SetDescription (string Description)
        {
            this._i.Description = Description;
            return this;
        }
        /// <summary>
        /// Проверка, является ли слой замороженным
        /// </summary>
        public bool Freeze => _i.Freeze;
        /// <summary>
        /// Установка статуса замороженности слоя
        /// </summary>
        /// <param name="Freeze"></param>
        /// <returns></returns>
        public AcadLayer SetFreeze(bool Freeze)
        {
            this._i.Freeze = Freeze;
            return this;
        }
        /// <summary>
        /// Получение типа линий слоя (как строку)
        /// </summary>
        public string Linetype => _i.Linetype;
        /// <summary>
        /// Получение веса линиий слоя (как числа). Для расшифровки см. AcLineWeight в документации OdaX
        /// </summary>
        public ACAD_LWEIGHT Lineweight => _i.Lineweight;
        /// <summary>
        /// Проверка, является ли слой заблокированным
        /// </summary>
        public bool Lock => _i.Lock;
        /// <summary>
        /// Установка блокировки/разблокировки слоя
        /// </summary>
        /// <param name="Lock"></param>
        /// <returns></returns>
        public AcadLayer SetLock (bool Lock)
        {
            this._i.Lock = Lock;
            return this;
        }
        /// <summary>
        /// Получение наименования слоя
        /// </summary>
        public string Name => _i.Name;
        /// <summary>
        /// Установка имени слоя
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public AcadLayer SetName (string Name)
        {
            this._i.Name = Name;
            return this;
        }
        /// <summary>
        /// Проверка, является ли слой печатным
        /// </summary>
        public bool Plottable => _i.Plottable;
        /// <summary>
        /// Установка значения печатности для слоя
        /// </summary>
        /// <param name="Plottable"></param>
        /// <returns></returns>
        public AcadLayer SetPlottable (bool Plottable)
        {
            this._i.Plottable = Plottable;
            return this;
        }
        /// <summary>
        /// Получения стиля печати для слоя
        /// </summary>
        public string PlotStyleName => _i.PlotStyleName;


    }
}
