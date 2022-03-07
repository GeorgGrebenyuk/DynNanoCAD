using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;
using static nanoCAD.Init;
using OdaX;

namespace nanoCAD.DynLayer
{
    public class Methods
    {
        public static List<object> GetLayers (int aux, object com_layer_collection)
        {
            IAcadLayers coll = inc_doc.Layers;
            List<object> layers_collection = new List<object>();
            for (int i1 =0; i1 < coll.Count; i1++)
            {
                AcadLayer lay = coll.Item(i1);
                layers_collection.Add(lay);
            }
            return layers_collection;
        }
        public static int NewLayerByName (int aux, string new_layer_name)
        {
            IAcadLayers coll = inc_doc.Layers;
            coll.Add(new_layer_name);
            return 1;
        }
        public static object GetLayerByName(int aux, string layer_name)
        {
            IAcadLayers coll = inc_doc.Layers;
            for (int i1 = 0; i1 < coll.Count; i1++)
            {
                AcadLayer lay = coll.Item(i1);
                if (lay.Name == layer_name) return lay;
            }
            return null;
        }
        [MultiReturn(new[] { "Description", "Freeze", "Handle", "LayerOn",
        "Linetype", "Lineweight", "Lock", "Material","Name", "ObjectID", "PlotStyleName", "Plottable",
        "TrueColor", "Used"})]
        public static Dictionary<string,object> GetLayerInfo (int aux, object com_layer)
        {
            AcadLayer lay = com_layer as AcadLayer;
            return new Dictionary<string, object>()
            {
                {"Description",lay.Description },
                {"Freeze",lay.Freeze },
                {"Handle",lay.Handle },
                {"LayerOn",lay.LayerOn },
                {"Linetype",lay.Linetype },
                {"Lineweight",lay.Lineweight },
                {"Lock",lay.Lock },
                {"Material",lay.Material },
                {"Name",lay.Name },
                {"ObjectID",lay.ObjectID },
                {"PlotStyleName",lay.PlotStyleName },
                {"Plottable",lay.Plottable },
                {"TrueColor",lay.TrueColor },
                {"Used",lay.Used },
            };
        }
        public static int EditLayer(int aux, object com_layer, string layer_description = null, bool layer_freeze = false, bool layer_LayerOn = true,
            string layer_LineType = null, object com_AcLineWeight = null, bool layer_lock = false, string layer_material = null,
            string layer_name = null, string layer_PlotStyleName = null, object com_AcadAcCmColor = null)
        {
            AcadLayer l = com_layer as AcadLayer;
            l.Freeze = layer_freeze;
            l.LayerOn = layer_LayerOn;
            l.Lock = layer_lock;
            if (layer_description != null) l.Description = layer_description;
            if (layer_LineType != null) l.Linetype = layer_LineType;
            if (layer_material != null) l.Material = layer_material;
            if (layer_name != null) l.Name = layer_name;
            if (layer_PlotStyleName != null) l.PlotStyleName = layer_PlotStyleName;
            if (com_AcadAcCmColor != null) l.color = (AcColor)com_AcadAcCmColor;
            if (com_AcLineWeight != null) l.Lineweight = (ACAD_LWEIGHT)com_AcLineWeight;

            return 1;
        }


    }
}
