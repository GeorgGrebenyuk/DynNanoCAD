using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;
using static nanoCAD.Init;

namespace nanoCAD.DynDocument
{
    public class Property
    {
        private Property() { }
        public static object ActiveLayer()
        {
            return inc_doc.ActiveLayer;
        }
        [MultiReturn(new[] { "ActiveLayer", "FullName", "Name", "Blocks",
        "Layers", "Layouts", "Linetypes", "DimStyles"})]
        public static Dictionary <string,object> Get(int aux)
        {
            return new Dictionary<string, object>()
            {
                {"ActiveLayer",inc_doc.ActiveLayer },
                {"FullName",inc_doc.FullName },
                {"Name",inc_doc.Name },
                {"Blocks",inc_doc.Blocks }, //Layers
                {"Layers",inc_doc.Layers },
                {"Layouts",inc_doc.Layouts },
                {"Linetypes",inc_doc.Linetypes },
                {"DimStyles",inc_doc.DimStyles },

            };
        }
        public object ModelSpace(int aux)
        {
            return inc_doc.ModelSpace;
        }
        public static object Layers (int aux)
        {
            return inc_doc.Layers;
        }

    }
}
