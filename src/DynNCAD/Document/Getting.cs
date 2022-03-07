using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DynNCAD.Init;

namespace DynNCAD.Document
{
    public class Getting
    {
        private Getting() { }
        public static int CurrentDoc()
        {
            inc_app = System.Runtime.InteropServices.Marshal.GetActiveObject("nanoCAD.Application") as nanoCAD.Application;
            try
            {
                inc_doc = inc_app.ActiveDocument;
            }
            catch (Exception ex1)
            {
                try
                {
                    inc_doc = inc_app.Documents.Add(null);
                }
                catch (Exception ex2)
                {

                }
            }
            return 1;
        }
        public static int OpenDoc(string path_to_drawing)
        {
            inc_app = System.Runtime.InteropServices.Marshal.GetActiveObject("nanoCAD.Application") as nanoCAD.Application;
            try
            {
                inc_doc = inc_app.Documents.Open(path_to_drawing, false);
            }
            catch (Exception ex)
            {

            }
            return 1;
        }
    }
}
