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
        public static List<AcadObjects.AcadEntity> GetSelectedObjectsInDrawing (DynNCAD.NanoCAD.Document Document, List<string> classes_names = null)
        {
            List<AcadObjects.AcadEntity> objects = new List<AcadObjects.AcadEntity>();
            SelectionSet all_selected_objects = Document._i.ActiveSelectionSet;
            for (int counter_objects = 0; counter_objects < all_selected_objects.Count; counter_objects++)
            {
                AcadEntity one_object = all_selected_objects[counter_objects];
                objects.Add(new AcadObjects.AcadEntity(one_object));
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
