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

        public static string GetPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}