#region include_namespaces
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

namespace DynNCAD.AcadObjects.AcadEntities
{
    /// <summary>
    /// Класс для работы с однострочным текстом (Text), интерфейс AcadText
    /// </summary>
    public class AcadText : AcadEntity
    {
        public OdaX.AcadText _i;
        #region constructors
        /// <summary>
        /// Создание объекта текста в данном блоке (пространстве модели или листов)
        /// </summary>
        /// <param name="block">Сущность блока</param>
        /// <param name="insetion_point">Точка вставки</param>
        /// <param name="text_height">Высота текста</param>
        /// <param name="text">Значение текста</param>
        public AcadText(AcadObjects.AcadBlock block, dg.Point insetion_point, double text_height, string text)
        {
            this._i = block._i.AddText(text, Tools.PointByDynPoint(insetion_point), text_height);
        }
        /// <summary>
        /// Получение текста из объекта модели
        /// </summary>
        /// <param name="AcadEntity">объект чертежа</param>
        public AcadText(AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadText != null) this._i = AcadEntity._i as OdaX.AcadText;
            else this._i = null;
        }
        #endregion


        #region functions
        /// <summary>
        /// Установка нового выравнивания текста (см. ноду TextAlignmentTypes)
        /// </summary>
        /// <param name="Alignment"></param>
        public void SetAlignment(int Alignment) => this._i.Alignment = (AcAlignment)Alignment;
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
        /// Установка значения масштбаного фактора
        /// </summary>
        /// <param name="ScaleFactor"></param>
        public void SetScaleFactor(double ScaleFactor) => this._i.ScaleFactor = ScaleFactor;
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

        #region properties
        /// <summary>
        /// Получение текущего значения для выравнивания текста
        /// </summary>
        public int Alignment => (int)_i.Alignment;

        /// <summary>
        /// Получение высоты текста
        /// </summary>
        public double Height => this._i.Height;

        /// <summary>
        /// Получение точки вставки текста
        /// </summary>
        public dg.Point InsertionPoint => Tools.ToDynamoPoint(this._i.InsertionPoint);
        /// <summary>
        /// Получение угла поворота текста
        /// </summary>
        public double Rotation => this._i.Rotation;

        /// <summary>
        /// Получение значения масштабного фактора
        /// </summary>
        public double ScaleFactor => this._i.ScaleFactor;

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
        /// Варианты выравнивания текста
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Вписать", "Вниз по центру" ,
            "По ширине", "Влево", "Середина","Середина по центру",
            "Середина влево", "Середина вправо","Вправо",
            "Вверх по центру","Вверх влево", "Вверх вправо" })]
        public static Dictionary<string, int> TextAlignmentTypes ()
        {
            return new Dictionary<string, int>()
            {
                {"Вписать", 3 }, {"Вниз по центру", 13 },
                {"Вниз влево", 12 },{"Вниз вправо", 14 },
                {"По центру", 1 },{"По ширине", 5 },{"Влево", 0 },
                {"Середина", 4 },{"Середина по центру", 10 },
                {"Середина влево", 9 },{"Середина вправо", 11 },{"Вправо", 2 },
                {"Вверх по центру", 7 },{"Вверх влево", 6 },{"Вверх вправо", 8 }
            };
        }
        #endregion
        

    }
}
