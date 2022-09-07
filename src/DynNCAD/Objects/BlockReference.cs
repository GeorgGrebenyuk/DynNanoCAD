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

namespace DynNCAD.Objects
{
    /// <summary>
    /// Класс для работы с вхождениями блоков
    /// </summary>
    public class BlockReference
    {
        internal OdaX.AcadBlockReference block_ref;
        /// <summary>
        /// Получение блока из com-интерфейса
        /// </summary>
        /// <param name="BlockReference_object"></param>
        private BlockReference (object BlockReference_object)
        {
            this.block_ref = BlockReference_object as OdaX.AcadBlockReference;
        }
        //properties
        /// <summary>
        /// Проверка, есть ли атрибуты у блока
        /// </summary>
        public bool HasAttributes => this.block_ref.HasAttributes;
        /// <summary>
        /// Получение точки вставки блока
        /// </summary>
        public object InsertionPoint => this.block_ref.InsertionPoint;
        /// <summary>
        /// Проверка, является ли блок динамическим
        /// </summary>
        public bool IsDynamicBlock => this.block_ref.IsDynamicBlock;
        /// <summary>
        /// Получение слоя блока
        /// </summary>
        public string Layer => this.block_ref.Layer;
        /// <summary>
        /// Получение имени блока
        /// </summary>
        public string Name => this.block_ref.Name;
        /// <summary>
        /// Получение угла поворота блока
        /// </summary>
        public double Rotation => this.block_ref.Rotation;
        /// <summary>
        /// Задание угла поворота блока
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public double SetRotation (double angle) => this.block_ref.Rotation = angle;
        /// <summary>
        /// Получение масштаба по оси X блока
        /// </summary>
        public double XScaleFactor => this.block_ref.XScaleFactor;
        /// <summary>
        /// Задание масштаба по оси X блока
        /// </summary>
        /// <param name="ScaleFactor"></param>
        /// <returns></returns>
        public double SetXScaleFactor (double ScaleFactor) => this.block_ref.XScaleFactor = ScaleFactor;
        /// <summary>
        /// Получение масштаба по оси Y блока
        /// </summary>
        public double YScaleFactor => this.block_ref.YScaleFactor;
        /// <summary>
        /// Задание масштаба по оси Y блока
        /// </summary>
        /// <param name="ScaleFactor"></param>
        /// <returns></returns>
        public double SetYScaleFactor(double ScaleFactor) => this.block_ref.YScaleFactor = ScaleFactor;
        /// <summary>
        /// Получение масштаба по оси Z блока
        /// </summary>
        public double ZScaleFactor => this.block_ref.ZScaleFactor;
        /// <summary>
        /// Задание масштаба по оси Z блока
        /// </summary>
        /// <param name="ScaleFactor"></param>
        /// <returns></returns>
        public double SetZScaleFactor(double ScaleFactor) => this.block_ref.ZScaleFactor = ScaleFactor;
        //functions
        public void Explode() => this.block_ref.Explode();
        public void Delete() => this.block_ref.Delete();
        public object GetAttributes() => this.block_ref.GetAttributes();

    }
}
