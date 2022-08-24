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

namespace DynNCAD.Styles
{
    //[dr.IsVisibleInDynamoLibrary(false)]
    public class DimStyle
    {
        internal OdaX.AcadDimStyle style;
        internal DimStyle(object style)
        {
            this.style = style as OdaX.AcadDimStyle;
        }
        /// <summary>
        /// Получение активного размерного стиля документа
        /// </summary>
        public DimStyle(Project.NDocument doc)
        {
            this.style = doc.nc_doc.ActiveDimStyle as OdaX.AcadDimStyle;
        }
        /// <summary>
        /// Получает размерный стиль по его имени, в противном случае возвращает NULL
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="name">Наименование размерного стиля</param>
        public DimStyle(Project.NDocument doc, string name)
        {
            DimStyle style = null;
            foreach (var st in DimStyles(doc))
            {
                if (st.style.Name == name) { style = st; break; }
            }
        }

        /// <summary>
        /// Получение всех размерных стилей документа
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<DimStyle> DimStyles (Project.NDocument doc)
        {
            List<DimStyle> objects = new List<DimStyle>();
            IAcadDimStyles styles = doc.nc_doc.DimStyles;
            for (int i = 0; i < styles.Count; i++) { objects.Add(new DimStyle(styles.Item(i))); }
            return objects;
        }
        /// <summary>
        /// Имя размерного стиля
        /// </summary>
        public string Name => this.style.Name;
    }
}
