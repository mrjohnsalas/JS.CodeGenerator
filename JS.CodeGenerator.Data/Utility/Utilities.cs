using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JS.CodeGenerator.Data.Utility
{
    public static class Utilities
    {
        public static string ReadFile(string path)
        {
            string content;
            using (var sr = new StreamReader(path))
                content = sr.ReadToEnd();
            return content;
        }

        public static void WriteFile(string content, string path, string fileName)
        {
            var fullPath = $"{path}\\{fileName}";
            using (var sw = new StreamWriter(fullPath, false))
                sw.Write(content);
        }

        public static string GetPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string GetSapDataType(string type1, string type2)
        {
            if (string.IsNullOrEmpty(type1) || string.IsNullOrEmpty(type2))
                return "NVARCHAR";
            switch (type1+type2)
            {
                case "A ":
                    return "ALFANUMERICO - REGULAR";
                case "A?":
                    return "ALFANUMERICO - DIRECCION";
                case "A#":
                    return "ALFANUMERICO - TELEFONO";
                case "M ":
                    return "ALFANUMERICO - TEXTO";
                case "N ":
                    return "NUMERICO";
                case "D ":
                    return "FECHA Y HORA - FECHA";
                case "NT":
                    return "FECHA Y HORA - HORA";
                case "BR":
                    return "UNIDADES Y TOTALES - TARIFA";
                case "BS":
                    return "UNIDADES Y TOTALES - IMPORTE";
                case "BP":
                    return "UNIDADES Y TOTALES - PRECIO";
                case "BQ":
                    return "UNIDADES Y TOTALES - CANTIDAD";
                case "B%":
                    return "UNIDADES Y TOTALES - PORCENTAJE";
                case "BM":
                    return "UNIDADES Y TOTALES - MEDIDA";
                case "MB":
                    return "GENERAL - ENLACE";
                case "AI":
                    return "GENERAL - IMAGEN";
                default:
                    return "";
            }
        }
    }
}