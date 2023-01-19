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

namespace DynNCAD
{
    /// <summary>
    /// Класс для работы с таблицами NanoCAD
    /// </summary>
    public class AcadTable
    {
        public OdaX.AcadTable _i;
        internal AcadTable() { }
        /// <summary>
        /// Приведение объекта модели к таблице
        /// </summary>
        /// <param name="AcadEntity"></param>
        public AcadTable(AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadTable != null) this._i = AcadEntity._i as OdaX.AcadTable;
            else this._i = null;
        }
        /// <summary>
        /// Создание новой таблицы
        /// </summary>
        /// <param name="block">Пространство блока для создания</param>
        /// <param name="insetion_point">Точка вставки таблицы</param>
        /// <param name="rows_count">Число строк</param>
        /// <param name="columns_count">Число колонок</param>
        /// <param name="row_height">Высота строки</param>
        /// <param name="column_width">Ширина колонки</param>
        public AcadTable(AcadBlock block, dg.Point insetion_point, int rows_count = 4,
            int columns_count = 2, double row_height = 4.0, double column_width = 10.0)
        {
            this._i = block._i.AddTable(Tools.PointByDynPoint(insetion_point), rows_count, columns_count,
                row_height, column_width);
        }

        /// <summary>
        /// Получение значение ячейки таблицы
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <param name="column">Номер колонки</param>
        /// <returns></returns>
        public string GetText(int row, int column) => this._i.GetText(row, column);
        /// <summary>
        /// Установка значения ячейки
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <param name="column">Номер колонки</param>
        /// <param name="text">Текст для установки</param>
        public void SetText(int row, int column, string text) => this._i.SetText(row, column, text);
        /// <summary>
        /// Получение ширины колонки
        /// </summary>
        /// <param name="column">Номер колонки</param>
        /// <returns></returns>
        public double GetColumnWidth(int column) => this._i.GetColumnWidth(column);
        /// <summary>
        /// Получение наименования колонки
        /// </summary>
        /// <param name="column_index"></param>
        /// <returns></returns>
        public string GetColumnName(int column_index) => this._i.GetColumnName(column_index);
        /// <summary>
        /// Установка наименования колонки
        /// </summary>
        /// <param name="column_index"></param>
        /// <param name="name"></param>
        public void SetColumnName(int column_index, string name) => this._i.SetColumnName(column_index, name);
        /// <summary>
        /// Установка ширины колонки
        /// </summary>
        /// <param name="column">Номер колонки</param>
        /// <param name="width">Ширина</param>
        public void SetColumnWidth(int column, double width) => this._i.SetColumnWidth(column, width);
        /// <summary>
        /// Получение высоты строки
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <returns></returns>
        public double GetRowHeight(int row) => this._i.GetRowHeight(row);
        /// <summary>
        /// Установка высоты строки
        /// </summary>
        /// <param name="row"></param>
        /// <param name="height"></param>
        public void SetRowHeight(int row, double height) => this._i.SetRowHeight(row, height);
        /// <summary>
        /// Получение наименования стиля текста
        /// </summary>
        /// <param name="rowType">Часть таблицы (строки)</param>
        /// <returns></returns>
        public string GetTextStyle(AcRowType rowType) => this._i.GetTextStyle((AcRowType)rowType);
        /// <summary>
        /// Установка стиля текста для частей таблицы
        /// </summary>
        /// <param name="rowType"></param>
        /// <param name="style_name"></param>
        public void SetTextStyle(int rowType, string style_name) => this._i.SetTextStyle(rowType, style_name);

        /// <summary>
        /// Получение типа ячейки
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public int GetCellType(int row, int column) => (int)this._i.GetCellType(row, column);
        /// <summary>
        /// Установка типа ячейки
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="type"></param>
        public void SetCellType(int row, int column, AcCellType type ) => this._i.SetCellType(row, column, (AcCellType)type);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public AcCellAlignment GetCellAlignment(int row, int column) => this._i.GetCellAlignment(row, column);
        /// <summary>
        /// Установка типа выравнивания данных в ячейке
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="AcCellAlignment"></param>
        public void  SetCellAlignment(int row, int column, AcCellAlignment AcCellAlignment) 
            => this._i.SetCellAlignment(row, column, AcCellAlignment);
        /// <summary>
        /// Получение числа строк таблицы
        /// </summary>
        public int Rows_count => this._i.Rows;
        /// <summary>
        /// Получение числа колонок таблицы
        /// </summary>
        public int Columns_count => this._i.Columns;
        /// <summary>
        /// Установка количества строк таблицы
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int SetRows_count (int count) => this._i.Rows = count;
        /// <summary>
        /// Установка количества строк таблицы
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int SetColumns_count(int count) => this._i.Columns = count;
    }
}
