using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;
using static nanoCAD.Init;
using OdaX;

namespace nanoCAD.DynBlocks
{
    public class General
    {
        private General() { }
        public static List <object> GetAllBlocks (int aux)
        {
            IAcadBlocks coll = inc_doc.Blocks;
            List<object> blocks = new List<object>();
            for (int i1 = 0; i1 < coll.Count; i1++)
            {
                blocks.Add(coll.Item(i1));  
            }
            return blocks;
        }
    }
}
