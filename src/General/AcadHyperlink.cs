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
    /// Класс для работы с элементами свойств типа Гиперссылка для объектов модели
    /// </summary>
    [dr.IsVisibleInDynamoLibrary(false)]
    public class AcadHyperlink
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadHyperlink _i;
        internal AcadHyperlink(OdaX.AcadHyperlink AcadHyperlink)
        {
            this._i = AcadHyperlink;
        }
        public AcadHyperlink(General.AcadEntity AcadEntity)
        {
            //this._i = AcadEntity.Hyperlinks;
        }
        public string URL => this._i.URL;
        public string URLDescription => this._i.URLDescription;
        public string URLNamedLocation => this._i.URLNamedLocation;
        //public string SetURL(string URL) => this._i.URL = URL;
        //public string SetURLDescription(string URLDescription) => this._i.URLDescription = URLDescription;
        //public string SetURLNamedLocation(string URLNamedLocation) => this._i.URLNamedLocation = URLNamedLocation;

    }
}
