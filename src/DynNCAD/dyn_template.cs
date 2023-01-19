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
    [dr.IsVisibleInDynamoLibrary(false)]
    public class dyn_template
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadEntity _i;
        public dyn_template (dynamic entity)
        {
            this._i = entity._i;
        }
    }
}
