using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;

using nanoCAD;
using OdaX;

namespace DynNCAD
{
    /// <summary>
    /// Класс для работы со свойствами документа
    /// </summary>
    public class AcadSummaryInfo
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public OdaX.AcadSummaryInfo _i;
        internal AcadSummaryInfo(OdaX.AcadSummaryInfo AcadSummaryInfo)
        {
            this._i = AcadSummaryInfo;
        }
        public string Author => this._i.Author;
        public void SetAuthor(string Author) => this._i.Author = Author;
        public string Comments => this._i.Comments;
        public void SetComments(string Comments) => this._i.Comments = Comments;
        public string HyperlinkBase => this._i.HyperlinkBase;
        public void SetHyperlinkBase(string HyperlinkBase) => this._i.HyperlinkBase = HyperlinkBase;
        public string Keywords => this._i.Keywords;
        public void SetKeywords(string Keywords) => this._i.Keywords = Keywords;
        public string LastSavedBy => this._i.LastSavedBy;
        public void SetLastSavedBy(string LastSavedBy) => this._i.LastSavedBy = LastSavedBy;
        public string RevisionNumber => this._i.RevisionNumber;
        public void SetRevisionNumber(string RevisionNumber) => this._i.RevisionNumber = RevisionNumber;
        public string Subject => this._i.Subject;
        public void SetSubject(string Subject) => this._i.Subject = Subject;
        public string Title => this._i.Title;
        public void SetTitle(string Title) => this._i.Title = Title;
    }
}
