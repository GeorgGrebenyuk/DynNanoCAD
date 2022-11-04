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

namespace DynNCAD.AcadObjects
{
    /// <summary>
    /// Класс для работы со слоями
    /// </summary>
    public class AcadLayer : AcadObject
    {
        public OdaX.AcadLayer nc_layer;
        internal AcadLayer (OdaX.AcadLayer layer)
        {
            this.nc_layer = layer;
        }
        /// <summary>
        /// Создание нового слоя по имени
        /// </summary>
        /// <param name="Database"></param>
        /// <param name="Name"></param>
        public AcadLayer (AcadDatabase Database, string Name)
        {
            this.nc_layer = Database.db.Layers.Add(Name);
        }
        /// <summary>
        /// Получение описания слоя
        /// </summary>
        public string Description => nc_layer.Description;
        /// <summary>
        /// Установка описания слоя
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        public AcadLayer SetDescription (string Description)
        {
            this.nc_layer.Description = Description;
            return this;
        }
        /// <summary>
        /// Проверка, является ли слой замороженным
        /// </summary>
        public bool Freeze => nc_layer.Freeze;
        /// <summary>
        /// Установка статуса замороженности слоя
        /// </summary>
        /// <param name="Freeze"></param>
        /// <returns></returns>
        public AcadLayer SetFreeze(bool Freeze)
        {
            this.nc_layer.Freeze = Freeze;
            return this;
        }
        /// <summary>
        /// Получение типа линий слоя (как строку)
        /// </summary>
        public string Linetype => nc_layer.Linetype;
        /// <summary>
        /// Получение веса линиий слоя (как числа). Для расшифровки см. AcLineWeight в документации OdaX
        /// </summary>
        public int Lineweight => (int)nc_layer.Lineweight;
        /// <summary>
        /// Проверка, является ли слой заблокированным
        /// </summary>
        public bool Lock => nc_layer.Lock;
        /// <summary>
        /// Установка блокировки/разблокировки слоя
        /// </summary>
        /// <param name="Lock"></param>
        /// <returns></returns>
        public AcadLayer SetLock (bool Lock)
        {
            this.nc_layer.Lock = Lock;
            return this;
        }
        /// <summary>
        /// Получение наименования слоя
        /// </summary>
        public string Name => nc_layer.Name;
        /// <summary>
        /// Установка имени слоя
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public AcadLayer SetName (string Name)
        {
            this.nc_layer.Name = Name;
            return this;
        }
        /// <summary>
        /// Проверка, является ли слой печатным
        /// </summary>
        public bool Plottable => nc_layer.Plottable;
        /// <summary>
        /// Установка значения печатности для слоя
        /// </summary>
        /// <param name="Plottable"></param>
        /// <returns></returns>
        public AcadLayer SetPlottable (bool Plottable)
        {
            this.nc_layer.Plottable = Plottable;
            return this;
        }
        /// <summary>
        /// Получения стиля печати для слоя
        /// </summary>
        public string PlotStyleName => nc_layer.PlotStyleName;


    }
}
