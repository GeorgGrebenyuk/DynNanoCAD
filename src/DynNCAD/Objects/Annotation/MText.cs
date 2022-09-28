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

namespace DynNCAD.Objects.Annotation
{
    /// <summary>
    /// Класс для работы с многострочным текстом (MText), интерфейс AcadMText
    /// </summary>
    public class MText
    {
        public AcadMText mtext;
        #region creation
        /// <summary>
        /// Получение текста из объекта модели
        /// </summary>
        /// <param name="model_object"></param>
        public MText(object model_object)
        {
            if (model_object as AcadMText != null) this.mtext = model_object as AcadMText;
            else this.mtext = null;
        }
        /// <summary>
        /// Создание объекта текста в данном блоке (пространстве модели или листов)
        /// </summary>
        /// <param name="block">Сущность блока</param>
        /// <param name="insetion_point">Точка вставки</param>
        /// <param name="text_width">Ширина поля для текста</param>
        /// <param name="text">Значение текста</param>
        public MText(DynNCAD.Project.Block block, dg.Point insetion_point, double text_width, string text)
        {
            this.mtext = block.block.AddMText(Tools.PointByDynPoint(insetion_point), text_width, text);
        }
        #endregion
        #region properties
        /// <summary>
        /// Получение текущего значения для выравнивания текста
        /// </summary>
        public int AcDrawingDirection => (int)mtext.DrawingDirection;

        /// <summary>
        /// Получение высоты текста
        /// </summary>
        public double Height => this.mtext.Height;
        /// <summary>
        /// Получение ширины поля текста
        /// </summary>
        public double Width => this.mtext.Width;

        /// <summary>
        /// Получение точки вставки текста
        /// </summary>
        public dg.Point InsertionPoint => Tools.ToDynamoPoint(this.mtext.InsertionPoint);
        /// <summary>
        /// Получение угла поворота текста
        /// </summary>
        public double Rotation => this.mtext.Rotation;

        /// <summary>
        /// Получение текущего стиля текста (имени)
        /// </summary>
        public string StyleName => this.mtext.StyleName;

        /// <summary>
        /// Получение значения текста (значения текста)
        /// </summary>
        public string TextString => this.mtext.TextString;

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
        public void SetWidth(double Width) => this.mtext.Width = Width;
        /// <summary>
        /// Установка нового выравнивания текста (см. ноду TextDrawingDirectionTypes)
        /// </summary>
        /// <param name="DrawingDirection"></param>
        public void SetDrawingDirection(int DrawingDirection) => this.mtext.DrawingDirection = (AcDrawingDirection)DrawingDirection;
        /// <summary>
        /// Установка значения высоты текста
        /// </summary>
        /// <param name="Height"></param>
        /// <returns></returns>
        public void SetHeight(double Height) => this.mtext.Height = Height;
        /// <summary>
        /// Установка значения угла поворота текста
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public void SetRotation(double angle) => this.mtext.Rotation = angle;
        /// <summary>
        /// Установка стиля текста для текста по его имени
        /// </summary>
        /// <param name="style_name">Имя стиля текста</param>
        /// <returns></returns>
        public void SetStyleName(string style_name) => this.mtext.StyleName = style_name;
        /// <summary>
        /// Установка значения текста
        /// </summary>
        /// <param name="text"></param>
        public void SetTextString(string text) => this.mtext.TextString = text;
        #endregion

    }
}
