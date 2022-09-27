#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = Autodesk.DesignScript.Geometry;

using nanoCAD;
using OdaX;
#endregion

namespace DynNCAD.Objects
{
    /// <summary>
    /// Класс для работы с объектами NanoCAD (общий класс для всех объектов модели)
    /// </summary>
    public class AcadEntity
    {
        public OdaX.AcadEntity entity;
        internal AcadEntity(OdaX.AcadEntity entity)
        {
            this.entity = entity;
        }
        #region properies
        /// <summary>
        /// Получение класса TeighaX объекта 
        /// </summary>
        public string ObjectName => this.entity.ObjectName;
        /// <summary>
        /// Получение наименования сущности
        /// </summary>
        public string EntityName => this.entity.EntityName;
        /// <summary>
        /// Получение внутреннего текущего объектного идентификатора
        /// </summary>
        public long ObjectID => this.entity.ObjectID;
        /// <summary>
        /// Получение внутреннго объектного идентификатора
        /// </summary>
        public string Handle => this.entity.Handle;
        /// <summary>
        /// Получение интерфейса OdaX.AcadEntity для данного класса 
        /// (как аргумента для конструктора других классов на базе объекта модели)
        /// </summary>
        public object AsCOM_object => this.entity;
        #endregion
    }
}
