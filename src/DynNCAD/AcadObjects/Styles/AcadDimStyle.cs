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

namespace DynNCAD.Project.Styles
{
    //[dr.IsVisibleInDynamoLibrary(false)]
    public class AcadDimStyle
    {
        internal OdaX.AcadDimStyle style;
        internal AcadDimStyle(object style)
        {
            this.style = style as OdaX.AcadDimStyle;
        }
        /// <summary>
        /// Получение активного размерного стиля документа
        /// </summary>
        public AcadDimStyle(NanoCAD.Document Document)
        {
            this.style = Document._i.ActiveDimStyle as OdaX.AcadDimStyle;
        }
        
        /// <summary>
        /// Получение всех размерных стилей документа
        /// </summary>
        /// <param name="Document"></param>
        /// <returns></returns>
        public static List<AcadDimStyle> DimStyles (NanoCAD.Document Document)
        {
            List<AcadDimStyle> objects = new List<AcadDimStyle>();
            IAcadDimStyles styles = Document._i.DimStyles;
            for (int i = 0; i < styles.Count; i++) { objects.Add(new AcadDimStyle(styles.Item(i))); }
            return objects;
        }
        /// <summary>
        /// Имя размерного стиля
        /// </summary>
        public string Name => this.style.Name;
    }
}
