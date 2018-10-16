using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.CodeGenerator.Data.Utility
{
    public class QueryBuilder
    {
        public string Raw { get; }

        public string Built { get; private set; }

        public List<int> IndexParameters { get; private set; }

        public Dictionary<int, string> Parameters { get; private set; }

        public string BuildQuery()
        {
            for (var i = IndexParameters.Count - 1; i >= 0; i--)
            {
                var indStr = IndexParameters[i];
                if (!Parameters.ContainsKey(i))
                    throw new Exception("no se ha definido un valor para el parámetro " + i);
                var param = Parameters[i];
                Built = Built.Substring(0, indStr) + param + Built.Substring(indStr + 1);
            }
            return Built;
        }

        public void SetParameter<T>(int index, T value)
        {
            if (value == null)
                Parameters.Add(index, "NULL");
            else if (value is string)
                Parameters.Add(index, $"'{value}'");
            else if (value is DateTime)
                Parameters.Add(index, $"'{value:yyyy-MM-dd}'");
            else
                Parameters.Add(index, value.ToString());
        }

        public void InizializerValues()
        {
            IndexParameters = new List<int>();
            Parameters = new Dictionary<int, string>();
            Built = Raw;
            var fromIndex = 0;
            while (fromIndex < Raw.Length)
            {
                var index = Raw.IndexOf("?", fromIndex);
                if (index != -1)
                {
                    IndexParameters.Add(index);
                    fromIndex = index + 1;
                }
                else
                    fromIndex = Raw.Length;
            }
        }

        public QueryBuilder(string raw)
        {
            Raw = raw;
            InizializerValues();
        }

        public QueryBuilder(Stream stream)
        {
            var reader = new StreamReader(stream);
            while (!reader.EndOfStream)
                Raw = Raw + reader.ReadLine() + " ";
            Raw = Raw.Trim();
            InizializerValues();
        }
    }
}