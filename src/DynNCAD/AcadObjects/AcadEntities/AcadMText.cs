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

namespace DynNCAD.AcadObjects.AcadEntities
{
    /// <summary>
    /// Класс для работы с многострочным текстом (MText), интерфейс AcadMText
    /// </summary>
    public class AcadMText : AcadEntity
    {
        public OdaX.AcadMText _i;
        #region creation
        /// <summary>
        /// Получение текста из объекта модели
        /// </summary>
        /// <param name="model_object"></param>
        public AcadMText(object model_object)
        {
            if (model_object as OdaX.AcadMText != null) this._i = model_object as OdaX.AcadMText;
            else this._i = null;
        }
        /// <summary>
        /// Создание объекта текста в данном блоке (пространстве модели или листов)
        /// </summary>
        /// <param name="block">Сущность блока</param>
        /// <param name="insetion_point">Точка вставки</param>
        /// <param name="text_width">Ширина поля для текста</param>
        /// <param name="text">Значение текста</param>
        public AcadMText(AcadObjects.AcadBlock block, dg.Point insetion_point, double text_width, string text)
        {
            this._i = block.block.AddMText(Tools.PointByDynPoint(insetion_point), text_width, text);
        }
        #endregion
        #region properties
        /// <summary>
        /// Получение текущего значения для выравнивания текста
        /// </summary>
        public int AcDrawingDirection => (int)_i.DrawingDirection;

        /// <summary>
        /// Получение высоты текста
        /// </summary>
        public double Height => this._i.Height;
        /// <summary>
        /// Получение ширины поля текста
        /// </summary>
        public double Width => this._i.Width;

        /// <summary>
        /// Получение точки вставки текста
        /// </summary>
        public dg.Point InsertionPoint => Tools.ToDynamoPoint(this._i.InsertionPoint);
        /// <summary>
        /// Получение угла поворота текста
        /// </summary>
        public double Rotation => this._i.Rotation;

        /// <summary>
        /// Получение текущего стиля текста (имени)
        /// </summary>
        public string StyleName => this._i.StyleName;

        /// <summary>
        /// Получение значения текста (значения текста)
        /// </summary>
        public string TextString => this._i.TextString;

        #endregion
        #region static_containers
        /// <summary>
        /// Варианты ориентации текста
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Слева направо", "Справа налево" , "Сверху вниз" , "Снизу вверх" , "По стилю"})]
        public static Dictionary<string, int> TextDrawingDirectionTypes()
        {
            return new Dictionary<string, int>()
            {
                {"Слева направо", 1 }, {"Справа налево", 2 },{"Сверху вниз", 3 },{"Снизу вверх", 4 },{"По стилю", 5 }
            };
        }
        #endregion
        #region functions
        /// <summary>
        /// Установка значения ширины для текста
        /// </summary>
        /// <param name="Width"></param>
        public void SetWidth(double Width) => this._i.Width = Width;
        /// <summary>
        /// Установка нового выравнивания текста (см. ноду TextDrawingDirectionTypes)
        /// </summary>
        /// <param name="DrawingDirection"></param>
        public void SetDrawingDirection(int DrawingDirection) => this._i.DrawingDirection = (AcDrawingDirection)DrawingDirection;
        /// <summary>
        /// Установка значения высоты текста
        /// </summary>
        /// <param name="Height"></param>
        /// <returns></returns>
        public void SetHeight(double Height) => this._i.Height = Height;
        /// <summary>
        /// Установка значения угла поворота текста
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public void SetRotation(double angle) => this._i.Rotation = angle;
        /// <summary>
        /// Установка стиля текста для текста по его имени
        /// </summary>
        /// <param name="style_name">Имя стиля текста</param>
        /// <returns></returns>
        public void SetStyleName(string style_name) => this._i.StyleName = style_name;
        /// <summary>
        /// Установка значения текста
        /// </summary>
        /// <param name="text"></param>
        public void SetTextString(string text) => this._i.TextString = text;
        #endregion

    }
}
