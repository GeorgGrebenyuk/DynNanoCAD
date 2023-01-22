#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dr = Autodesk.DesignScript.Runtime;
using dg = DynNCAD.Geometry;

using nanoCAD;
using OdaX;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32;
#endregion
namespace DynNCAD.App
{
    /// <summary>
    /// Класс для работы с nanoCAD.Application
    /// </summary>
    public class Application
    {
        
        [dr.IsVisibleInDynamoLibrary(false)]
        public nanoCAD.Application _i;
        /// <summary>
        /// Получение первого запущенного приложения NanoCAD
        /// </summary>
        public Application(string progID = "nanoCAD.Application")
        {
            var check_app = Marshal.GetActiveObject(progID) as nanoCAD.Application;
            if (check_app != null) this._i = check_app;
        }
        public Application()
        {
            var check_app = Marshal.GetActiveObject("nanoCADx64.Application.22.0") as nanoCAD.Application;
            if (check_app != null) this._i = check_app;
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
        #region getting_processes_ROT
        //https://stackoverflow.com/questions/7736280/marshal-getactiveobject-throws-mk-e-unavailable-exception-in-c-sharp
        /// <summary>
        /// Получает идентификаторы всех запущенных процессов в системе через COM
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCOMProcesses()
        {
            StringBuilder SB = new StringBuilder();
            List<string> processes = new List<string>();
            foreach (var moniker in EnumRunningObjects())
            {
                List<string> t1 = GetMonikerString(moniker).Split('\t').ToList();
                processes = processes.Concat(t1).ToList();
            }
            return processes;
        }
        private const int S_OK = 0x00000000;

        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(uint reserved, out IRunningObjectTable pprot);

        [DllImport("ole32.dll")]
        private static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);

        private static void OleCheck(string message, int result)
        {
            if (result != S_OK)
                throw new COMException(message, result);
        }

        private static System.Collections.Generic.IEnumerable<IMoniker> EnumRunningObjects()
        {
            IRunningObjectTable objTbl;
            OleCheck("GetRunningObjectTable failed", GetRunningObjectTable(0, out objTbl));
            IEnumMoniker enumMoniker;
            IMoniker[] monikers = new IMoniker[1];
            objTbl.EnumRunning(out enumMoniker);
            enumMoniker.Reset();
            while (enumMoniker.Next(1, monikers, IntPtr.Zero) == S_OK)
            {
                yield return monikers[0];
            }
        }

        private static bool TryGetCLSIDFromDisplayName(string displayName, out string clsid)
        {
            var bBracket = displayName.IndexOf("{");
            var eBracket = displayName.IndexOf("}");
            if ((bBracket > 0) && (eBracket > 0) && (eBracket > bBracket))
            {
                clsid = displayName.Substring(bBracket, eBracket - bBracket + 1);
                return true;
            }
            else
            {
                clsid = string.Empty;
                return false;
            }
        }

        private static string ReadSubKeyValue(string keyName, RegistryKey key)
        {
            var subKey = key.OpenSubKey(keyName);
            if (subKey != null)
            {
                using (subKey)
                {
                    var value = subKey.GetValue("");
                    return value == null ? string.Empty : value.ToString();
                }
            }
            return string.Empty;
        }

        private static string GetMonikerString(IMoniker moniker)
        {
            IBindCtx ctx;
            OleCheck("CreateBindCtx failed", CreateBindCtx(0, out ctx));
            var sb = new StringBuilder();
            string displayName;
            moniker.GetDisplayName(ctx, null, out displayName);
            sb.Append(displayName);
            sb.Append('\t');
            string clsid;
            if (TryGetCLSIDFromDisplayName(displayName, out clsid))
            {
                var regClass = Registry.ClassesRoot.OpenSubKey("\\CLSID\\" + clsid);
                if (regClass != null)
                {
                    using (regClass)
                    {
                        sb.Append(regClass.GetValue(""));
                        sb.Append('\t');
                        sb.Append(ReadSubKeyValue("ProgID", regClass));
                        sb.Append('\t');
                        sb.Append(ReadSubKeyValue("LocalServer32", regClass));
                    }
                }
            }
            return sb.ToString();
        }
        #endregion

    }

}
