using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;



namespace DynNCAD
{
    /// <summary>
    /// Класс для работы с материалами, но без доступа к их формулировке
    /// </summary>
    public class AcadMaterial
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadMaterial _i;

        internal AcadMaterial(OdaX.AcadMaterial material)
        {
            this._i = material;
        }
        public AcadMaterial(AcadDatabase AcadDatabase, string Name)
        {
            this._i = AcadDatabase._i.Materials.Add(Name);
        }
        public string Description => this._i.Description;
        public void SetDescription(string Description) => this._i.Description = Description;
        public string Name => this._i.Name;
        public void SetName(string Name) => this._i.Name = Name;
    }
}
