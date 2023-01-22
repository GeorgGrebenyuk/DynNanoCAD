//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;

namespace DynNCAD.App
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

        [dr.MultiReturn(new[] { "Acad:Text", "Внешняя ссылка" })]
        public static Dictionary<string, string> Features()
        {
            return new Dictionary<string, string>()
            {
                {"Acad:Text", "Acad:Text" },
                {"Внешняя ссылка", "Acad:XRef" },
            };
        }
        /// <summary>
        /// Создание внешней ссылки
        /// </summary>
        /// <param name="AcadDatabase"></param>
        /// <param name="Feature"></param>
        /// <param name="FullFileName"></param>
        /// <param name="AffectsGraphics"></param>
        /// <param name="noIncrement"></param>
        public AcadFileDependency (General.AcadDatabase AcadDatabase, 
            string Feature, string FullFileName, bool AffectsGraphics = false, bool noIncrement = false)
        {
            int new_index = AcadDatabase._i.FileDependencies.
                CreateEntry(Feature, FullFileName, AffectsGraphics, noIncrement);
            var count_files = AcadDatabase._i.FileDependencies.Count;
            this._i = AcadDatabase._i.FileDependencies.Item(new_index);
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
