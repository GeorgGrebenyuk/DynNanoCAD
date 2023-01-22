using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;

namespace DynNCAD.General
{
    public class AcadGroup
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadGroup _i;
        public AcadGroup(AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadGroup != null) this._i = AcadEntity._i as OdaX.AcadGroup;
            else this._i = null;
        }
        internal AcadGroup(OdaX.AcadGroup AcadGroup)
        {
            this._i = AcadGroup;
        }

        public List<AcadEntity> GetEntities()
        {
            List<AcadEntity> ents = new List<AcadEntity>();
            for (int i = 0; i < this._i.Count; i++)
            {
                ents.Add(new AcadEntity(this._i.Item(i)));
            }
            return ents;
        }
        //public int Count => this._i.Count;
        //public void SetVisible(bool VisiableStatus) => this._i.Visible = VisiableStatus;
        public string Name => this._i.Name;
        public void SetName(string Name) => this._i.Name = Name;
    }
}
