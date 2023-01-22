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

namespace DynNCAD.General
{
    public class AcadObject
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadObject _i;
        internal AcadObject() { }
        public AcadObject(dynamic entity)
        {
            if (entity as OdaX.AcadObject != null) this._i = entity as OdaX.AcadObject;
            else this._i = null;
        }
        public void Delete() => this._i.Delete();
        public void Erase() => this._i.Erase();

        public string Handle => this._i.Handle;
        public string ObjectName => this._i.ObjectName;
        public long ObjectID => this._i.ObjectID;
        public long OwnerID => this._i.OwnerID;
    }
}
