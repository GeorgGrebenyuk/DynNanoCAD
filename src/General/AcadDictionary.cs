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


namespace DynNCAD.General
{
    /// <summary>
    /// Класс для работы с внутренними словарями AcadDictionary (XData) 
    /// </summary>
    public class AcadDictionary
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadDictionary _i;

        internal AcadDictionary(OdaX.AcadDictionary AcadDictionary)
        {
            this._i = AcadDictionary;
        }
        public string Name => this._i.Name;

        public List<AcadObject> Objects()
        {
            List<AcadObject> els = new List<AcadObject>();
            for (int i = 0; i < this._i.Count; i++)
            {
                els.Add(new AcadObject(this._i.Item(i)));
            }
            return els;
        }

    }
}
