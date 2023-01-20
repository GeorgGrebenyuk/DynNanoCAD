using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;

namespace DynNCAD
{
    public class AcadGroup
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadGroup _i;
        internal AcadGroup(OdaX.AcadGroup AcadGroup)
        {
            this._i = AcadGroup;
        }
        public static List<AcadGroup> GetAllAcadGroups (AcadDatabase AcadDatabase)
        {
            List<AcadGroup> groups = new List<AcadGroup>();
            for (int i = 0; i < AcadDatabase._i.Groups.Count; i++)
            {
                groups.Add(new AcadGroup(AcadDatabase._i.Groups.Item(i)));
            }
            return groups;
        }
        public List<AcadEntity> GetEntities ()
        {
            List<AcadEntity> ents = new List<AcadEntity>();
            for (int i = 0; i < this._i.Count; i++)
            {
                ents.Add(new AcadEntity(this._i.Item(i)));
            }
            return ents;
        }
        public int Count => this._i.Count;
        public bool SetVisible (bool Visiable) => this._i.Visible = Visiable;
        public string Name => this._i.Name;
        public void SetName(string Name) => this._i.Name = Name;
    }
}
