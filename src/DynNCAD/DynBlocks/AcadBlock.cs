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
    public class AcadBlock
    {
        [MultiReturn(new[] { "Handle", "Name", "ObjectID", "Origin", "Units"})]
        public static Dictionary<string, object> GetInfo (int aux, object com_block)
        {
            OdaX.AcadBlock block = com_block as OdaX.AcadBlock;
            return new Dictionary<string, object>()
            {
                {"Handle",block.Handle },
                {"Name",block.Name },
                {"ObjectID",block.ObjectID },
                {"Origin",block.Origin },
                {"Units",block.Units }
            };
        }
    }
}
