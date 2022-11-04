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
namespace DynNCAD.NanoCAD
{
    /// <summary>
    /// Класс для работы с nanoCAD.Application
    /// </summary>
    public class Application
    {
        internal nanoCAD.Application _i;
        /// <summary>
        /// Получение первого запущенного приложения NanoCAD
        /// </summary>
        public Application()
        {

            this._i = System.Runtime.InteropServices.
                Marshal.GetActiveObject("nanoCAD.Application") as nanoCAD.Application;
        }

        /// <summary>
        /// Отправляет текстовую команду в командную строку на выполнение.
        /// </summary>
        /// <param name="command"></param>
        public void SendCommand(string command) => this._i.SendCommand(command);
        /// <summary>
        /// Обновляет объекты на экране.
        /// </summary>
        public void Update()
        {
            this._i.Update();
        }
        /// <summary>
        /// Заголовок окна приложения
        /// </summary>
        public string Caption => this._i.Caption;
        /// <summary>
        /// Получение всех открытых документов
        /// </summary>
        /// <returns></returns>

        public List<Document> Documents()
        {
            InanoCADDocuments docs_row = this._i.Documents;
            List<Document> docs = new List<Document>();
            for(int i = 0; i < docs_row.Count; i++)
            {
                docs.Add(new Document(docs_row[i]));
            }
            return docs;

        }

    }
}
