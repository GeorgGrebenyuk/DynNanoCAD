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
namespace DynNCAD.Project
{
    /// <summary>
    /// Класс для работы с nanoCAD.Application
    /// </summary>
    public class Application
    {
        internal nanoCAD.Application ncad_app;
        /// <summary>
        /// Получение первого запущенного приложения NanoCAD
        /// </summary>
        public Application()
        {
            this.ncad_app = System.Runtime.InteropServices.Marshal.GetActiveObject("nanoCAD.Application") as nanoCAD.Application;
        }
        /// <summary>
        /// Отправляет текстовую команду в командную строку на выполнение.
        /// </summary>
        /// <param name="command"></param>
        public void SendCommand(string command) => this.ncad_app.SendCommand(command);
        /// <summary>
        /// Обновляет объекты на экране.
        /// </summary>
        public void Update()
        {
            this.ncad_app.Update();
        }
        /// <summary>
        /// Заголовок окна приложения
        /// </summary>
        public string Caption => this.ncad_app.Caption;
        /// <summary>
        /// Получение всех открытых документов
        /// </summary>
        /// <returns></returns>

        public List<NDocument> Documents()
        {
            InanoCADDocuments docs_row = this.ncad_app.Documents;
            List<NDocument> docs = new List<NDocument>();
            for(int i = 0; i < docs_row.Count; i++)
            {
                docs.Add(new NDocument(docs_row[i]));
            }
            return docs;

        }

    }
}
