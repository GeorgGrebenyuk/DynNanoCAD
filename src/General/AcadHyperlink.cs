//#region
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using dr = Autodesk.DesignScript.Runtime;
//using dg = DynNCAD.Geometry;

//using nanoCAD;
//using OdaX;
//#endregion

//namespace DynNCAD.General
//{
//    /// <summary>
//    /// Класс для работы с элементами свойств типа Гиперссылка для объектов модели
//    /// </summary>
//    public class AcadHyperlink
//    {
//        [dr.IsVisibleInDynamoLibrary(false)]
//        public OdaX.AcadHyperlink _i;
//        public AcadHyperlink(AcadHyperlinks AcadHyperlinks, string Name, string Descriprion, object NamedLocation)
//        {
//            this._i = AcadHyperlinks._i.Add(Name, Descriprion, NamedLocation);
//        }
//        internal AcadHyperlink(OdaX.AcadHyperlink AcadHyperlink)
//        {
//            this._i = AcadHyperlink;
//        }
//        public string URL => this._i.URL;
//        public string URLDescription => this._i.URLDescription;
//        public string URLNamedLocation => this._i.URLNamedLocation;
//        //public void SetURL(string URL) => this._i.URL = URL;
//        //public void SetURLDescription(string URLDescription) => this._i.URLDescription = URLDescription;
//        //public void SetURLNamedLocation(string URLNamedLocation) => this._i.URLNamedLocation = URLNamedLocation;

//    }
//    /// <summary>
//    /// Класс для работы с Менеджеом гиперссылок для объекта модели
//    /// </summary>
//    public class AcadHyperlinks
//    {
//        [dr.IsVisibleInDynamoLibrary(false)]
//        public OdaX.AcadHyperlinks _i;
//        internal AcadHyperlinks(General.AcadEntity AcadEntity)
//        {
//            this._i = AcadEntity._i.Hyperlinks;
//        }
//        public List<AcadHyperlink> GetLinks()
//        {
//            List<AcadHyperlink> els = new List<AcadHyperlink>();
//            for (int i = 0; i < this._i.Count; i++)
//            {
//                els.Add(new AcadHyperlink(this._i.Item(i)));
//            }
//            return els;
//        }
//    }
//}
