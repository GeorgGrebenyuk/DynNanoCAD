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
    /// Класс для работы с однострочным текстом (Text), интерфейс AcadText
    /// </summary>
    public class Text : AcadEntity
    {
        public AcadText text;
        #region creation
        /// <summary>
        /// Получение текста из объекта модели
        /// </summary>
        /// <param name="AcadEntity">объект чертежа</param>
        public Text(Objects.AcadEntity AcadEntity)
        {
            if (AcadEntity.entity as AcadText != null) this.text = AcadEntity.entity as AcadText;
            else this.text = null;
        }
        /// <summary>
        /// Создание объекта текста в данном блоке (пространстве модели или листов)
        /// </summary>
        /// <param name="block">Сущность блока</param>
        /// <param name="insetion_point">Точка вставки</param>
        /// <param name="text_height">Высота текста</param>
        /// <param name="text">Значение текста</param>
        public Text(DynNCAD.Project.Block block, dg.Point insetion_point, double text_height, string text)
        {
            this.text = block.block.AddText(text, Tools.PointByDynPoint(insetion_point), text_height);
        }
        #endregion
        #region properties
        /// <summary>
        /// Получение текущего значения для выравнивания текста
        /// </summary>
        public int Alignment => (int)text.Alignment;

        /// <summary>
        /// Получение высоты текста
        /// </summary>
        public double Height => this.text.Height;

        /// <summary>
        /// Получение точки вставки текста
        /// </summary>
        public dg.Point InsertionPoint => Tools.ToDynamoPoint(this.text.InsertionPoint);
        /// <summary>
        /// Получение угла поворота текста
        /// </summary>
        public double Rotation => this.text.Rotation;

        /// <summary>
        /// Получение значения масштабного фактора
        /// </summary>
        public double ScaleFactor => this.text.ScaleFactor;

        /// <summary>
        /// Получение текущего стиля текста (имени)
        /// </summary>
        public string StyleName => this.text.StyleName;

        /// <summary>
        /// Получение значения текста (значения текста)
        /// </summary>
        public string TextString => this.text.TextString;

        #endregion
        #region static_containers
        /// <summary>
        /// Варианты выравнивания текста
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Вписать", "Вниз по центру" , "Вниз влево" , "Вниз вправо" , "По центру",
        "По ширине", "Влево", "Середина","Середина по центру","Середина влево", "Середина вправо","Вправо",
        "Вверх по центру","Вверх влево", "Вверх вправо" })]
        public static Dictionary<string, int> TextAlignmentTypes ()
        {
            return new Dictionary<string, int>()
            {
                {"Вписать", 3 }, {"Вниз по центру", 13 },{"Вниз влево", 12 },{"Вниз вправо", 14 },{"По центру", 1 },
                {"По ширине", 5 },{"Влево", 0 },{"Середина", 4 },{"Середина по центру", 10 },{"Середина влево", 9 },
                {"Середина вправо", 11 },{"Вправо", 2 },{"Вверх по центру", 7 },{"Вверх влево", 6 },{"Вверх вправо", 8 }
            };
        }
        #endregion
        #region functions
        /// <summary>
        /// Установка нового выравнивания текста (см. ноду TextAlignmentTypes)
        /// </summary>
        /// <param name="Alignment"></param>
        public void SetAlignment(int Alignment) => this.text.Alignment = (AcAlignment)Alignment;
        /// <summary>
        /// Установка значения высоты текста
        /// </summary>
        /// <param name="Height"></param>
        /// <returns></returns>
        public void SetHeight(double Height) => this.text.Height = Height;
        /// <summary>
        /// Установка значения угла поворота текста
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public void SetRotation(double angle) => this.text.Rotation = angle;
        /// <summary>
        /// Установка значения масштбаного фактора
        /// </summary>
        /// <param name="ScaleFactor"></param>
        public void SetScaleFactor(double ScaleFactor) => this.text.ScaleFactor = ScaleFactor;
        /// <summary>
        /// Установка стиля текста для текста по его имени
        /// </summary>
        /// <param name="style_name">Имя стиля текста</param>
        /// <returns></returns>
        public void SetStyleName(string style_name) => this.text.StyleName = style_name;
        /// <summary>
        /// Установка значения текста
        /// </summary>
        /// <param name="text"></param>
        public void SetTextString(string text) => this.text.TextString = text;
        #endregion

    }
}
