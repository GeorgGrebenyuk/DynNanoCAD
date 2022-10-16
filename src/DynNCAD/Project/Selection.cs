﻿#region
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

namespace DynNCAD.Project
{
    /// <summary>
    /// Класс для выборки элементов модели (чертежа)
    /// </summary>
    public static class Selection
    {
        /// <summary>
        /// Получение объектов, выбранных в текущем чертеже с возможностью сортировки объектов по списку классов
        /// </summary>
        /// <param name="NDocument">Project.NDocument</param>
        /// <param name="classes_names">Список наименований классов объектов, которые надо отобрать</param>
        /// <returns></returns>
        public static List<Objects.AcadEntity> GetSelectedObjectsInDrawing (Project.NDocument NDocument, List<string> classes_names = null)
        {
            List<Objects.AcadEntity> objects = new List<Objects.AcadEntity>();
            SelectionSet all_selected_objects = NDocument.nc_doc.ActiveSelectionSet;
            for (int counter_objects = 0; counter_objects < all_selected_objects.Count; counter_objects++)
            {
                AcadEntity one_object = all_selected_objects[counter_objects];
                objects.Add(new Objects.AcadEntity(one_object));
            }
            if (classes_names != null)
            {
                objects = objects.Where(a => classes_names.Contains(a.ObjectName)).ToList();
            }
            //sels.Select(nanoCAD.AcSelect.acSelectionSetWindowPolygon);

            return objects;
        }
        /// <summary>
        /// Получение сущностей в блоке
        /// </summary>
        /// <returns></returns>
        public static List<Objects.AcadEntity> GetBlockEntities(Project.Block Block)
        {
            List<Objects.AcadEntity> objs = new List<Objects.AcadEntity>();
            for (int i = 0; i < Block.block.Count; i++)
            {
                objs.Add(new Objects.AcadEntity(Block.block.Item(i)));
            }
            return objs;
        }
        /// <summary>
        /// Получение строковых наименований классов объектов чертежа
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn(new[] { "Текст", "МТекст" , "Отрезок", "Полилиния", "3D-полилиния", "Круговой размер", "Фигура",
        "Дуга","Окружность", "Вхождение блока", "Угловой размер", "Эллипс","Штриховка", "Диаметральный размер","Область",
        "Сплайн"})]
        public static Dictionary<string, string> AutoCADObjectsClasses()
        {
            return new Dictionary<string, string>()
            {
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
                {"Вхождение блока", "AcDbBlockReference" }
            };
        }
    }
}