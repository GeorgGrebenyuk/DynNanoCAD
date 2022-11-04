#region include_namespaces
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

namespace DynNCAD
{
    public class AcadObject
    {
        public OdaX.AcadObject _i;
        #region constructors
        internal AcadObject() { }
        public AcadObject(dynamic entity)
        {
            this._i = entity._i;
        }
        #endregion
        #region functions
        public void Delete() => this._i.Delete();
        public void Erase() => this._i.Erase();
        #endregion


        #region properties
        public string Handle => this._i.Handle;
        public string ObjectName => this._i.ObjectName;
        public long ObjectID => this._i.ObjectID;
        public long OwnerID => this._i.OwnerID;

        #endregion
    }
}
