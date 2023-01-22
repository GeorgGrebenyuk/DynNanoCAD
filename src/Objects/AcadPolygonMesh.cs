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

namespace DynNCAD.Objects
{
    public class AcadPolygonMesh
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadPolygonMesh _i;

        public AcadPolygonMesh(General.AcadEntity AcadEntity)
        {
            if (AcadEntity._i as OdaX.AcadPolygonMesh != null) this._i = AcadEntity._i as OdaX.AcadPolygonMesh;
            else this._i = null;
        }
        public AcadPolygonMesh(General.AcadBlock Block, int X_Cells_count, int Y_Cells_count, double[] Points3D)
        {
            this._i = Block._i.Add3DMesh(X_Cells_count, Y_Cells_count, Points3D);
        }
        //props
        public object Coordinates => this._i.Coordinates;
        public bool MClose => this._i.MClose;
        public bool NClose => this._i.NClose;
        public int MDensity => this._i.MDensity;
        public int NDensity => this._i.NDensity;
        public int MVertexCount => this._i.MVertexCount;
        public int NVertexCount => this._i.NVertexCount;
        public string MeshType => this._i.Type.ToString();
        public void SetMeshType(AcPolymeshType AcPolymeshType) => this._i.Type = AcPolymeshType;

    }
}
