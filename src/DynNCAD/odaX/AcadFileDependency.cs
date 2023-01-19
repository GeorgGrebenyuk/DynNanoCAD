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
    /// Класс для работы с внешними зависимостями чертежа
    /// </summary>
    public class AcadFileDependency
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadFileDependency _i;
        internal AcadFileDependency(OdaX.AcadFileDependency AcadFileDependency)
        {
            this._i = AcadFileDependency;
        }
        public List<AcadFileDependency> GetAllAcadFileDependencies(AcadDatabase AcadDatabase)
        {
            List<AcadFileDependency> deps = new List<AcadFileDependency>();
            for (int i = 0; i < AcadDatabase._i.FileDependencies.Count; i++)
            {
                deps.Add(new AcadFileDependency(AcadDatabase._i.FileDependencies.Item(i)));
            }
            return deps;
        }
        public string FullFileName => this._i.FullFileName;
        public string FileName => this._i.FileName;
        public string FoundPath => this._i.FoundPath;
        public string FingerprintGuid => this._i.FingerprintGuid;
        public string VersionGuid => this._i.VersionGuid;
        public string Feature => this._i.Feature;
        public bool IsModified => this._i.IsModified;
        public bool AffectsGraphics => this._i.AffectsGraphics;
        public int Index => this._i.Index;
        public int TimeStamp => this._i.TimeStamp;
        public int FileSize => this._i.FileSize;
        public int ReferenceCount => this._i.ReferenceCount;
    }
}
