using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nanoCAD
{
    public class Init
    {
        private Init (){}
        public static nanoCAD.Application inc_app;
        public static nanoCAD.Document inc_doc;
        public static OdaX.IAcadDatabase inc_db;
        private static void InitApp()
        {
            inc_app = System.Runtime.InteropServices.Marshal.GetActiveObject("nanoCAD.Application") as nanoCAD.Application;
        }
        public static int CurrentDoc()
        {
            inc_app = System.Runtime.InteropServices.Marshal.GetActiveObject("nanoCAD.Application") as nanoCAD.Application;
            inc_doc = inc_app.ActiveDocument;
            inc_db = inc_doc.Database;

            return 1;
        }
        public static string AboutPackage()
        {
            return $@"Look package's site https://github.com/GeorgGrebenyuk/DynNanoCAD/tree/main/src/DynNCAD";
        }
        public static string GetDrawingName(int aux)
        {
            nanoCAD.Document doc2 = inc_doc as nanoCAD.Document;
            return doc2.FullName;
        }
    }
}
