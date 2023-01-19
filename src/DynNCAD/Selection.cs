#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;

#endregion

namespace DynNCAD
{
    /// <summary>
    /// Класс для выборки элементов модели (чертежа)
    /// </summary>
    public static class Selection
    {
        /// <summary>
        /// Получение объектов, выбранных в текущем чертеже с возможностью сортировки объектов по списку классов
        /// </summary>
        /// <param name="Document">Project.NDocument</param>
        /// <param name="classes_names">Список наименований классов объектов, которые надо отобрать</param>
        /// <returns></returns>
        public static List<AcadEntity> GetSelectedObjectsInDrawing (Document Document, List<string> classes_names = null)
        {
            List<AcadEntity> objects = new List<AcadEntity>();
            nanoCAD.SelectionSet all_selected_objects = Document._i.ActiveSelectionSet;
            for (int counter_objects = 0; counter_objects < all_selected_objects.Count; counter_objects++)
            {
                OdaX.AcadEntity one_object = all_selected_objects[counter_objects];
                objects.Add(new AcadEntity(one_object));
            }
            if (classes_names != null)
            {
                objects = objects.Where(a => classes_names.Contains(a._i.EntityName)).ToList();
            }
            //sels.Select(nanoCAD.AcSelect.acSelectionSetWindowPolygon);

            return objects;
        }
        /// <summary>
        /// Получение строковых наименований классов объектов чертежа
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Точка", "Текст", "МТекст" , "Отрезок", "Полилиния", "3D-полилиния", "Круговой размер", "Фигура",
        "Дуга","Окружность", "Вхождение блока", "Угловой размер", "Эллипс","Штриховка", "Диаметральный размер","Область",
        "Сплайн"})]
        public static Dictionary<string, string> AutoCADObjectsClasses()
        {
            return new Dictionary<string, string>()
            {
                {"Точка", "AcDbPoint" },
                {"Текст", "AcDbText" },
                {"МТекст", "AcDbMText" },
                {"Отрезок", " AcDbLine" },
                {"Полилиния", "AcDbPolyline" },
                {"3D-полилиния", "AcDbPolyline3d" },
                {"Дуга", "AcDbArc" },
                {"Окружность", "AcDbCircle" },
                {"Эллипс", "AcDbEllipse" },
                {"Сплайн", "AcDbSpline" },
                {"Штриховка", "AcDbHatch" },
                {"Угловой размер", "AcDb2LineAngularDimension" },
                {"Диаметральный размер", "AcDbDiametricDimension" },
                {"Круговой размер", "AcDbRotatedDimension" },
                {"Область", "AcDbRegion" },
                {"Фигура", "AcDbSolid" },
                {"Вхождение блока", "AcDbBlockReference" },

            };
        }
    }
}
