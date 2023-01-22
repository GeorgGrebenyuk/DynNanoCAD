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

namespace DynNCAD.Objects
{
    /// <summary>
    /// Класс для работы с однострочным текстом (Text), интерфейс AcadText
    /// </summary>
    public class AcadText
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadText _i;

        /// <summary>
        /// Создание объекта текста в данном блоке (пространстве модели или листов)
        /// </summary>
        /// <param name="block">Сущность блока</param>
        /// <param name="insetion_point">Точка вставки</param>
        /// <param name="text_height">Высота текста</param>
        /// <param name="text">Значение текста</param>
        public AcadText(General.AcadBlock block, dg.Point insetion_point, double text_height, string text)
        {
            this._i = block._i.AddText(text, Tools.PointByDynPoint(insetion_point), text_height);
        }
        /// <summary>
        /// Получение текста из объекта модели
        /// </summary>
        /// <param name="AcadEntity">объект чертежа</param>
        public AcadText(General.AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadText != null) this._i = AcadEntity._i as OdaX.AcadText;
            else this._i = null;
        }

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

    }
}
