using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JS.CodeGenerator.Common;

namespace JS.CodeGenerator.Data
{
    public class GetAndSetGenerator<T>
    {
        public string SqlTableName { get; set; }

        public string ClassName { get; set; }

        public string VarName { get; set; }

        public List<ColumnTable> Columns { get; set; }

        public GetAndSetGenerator(string sqlTableName, string className, string varName, List<ColumnTable> columns)
        {
            this.SqlTableName = sqlTableName;
            this.ClassName = className;
            this.VarName = varName;
            this.Columns = columns;
        }

        public string GetValue(ColumnTable column)
        {
            var defaultCode = $"rs.Fields.Item(\"{column.SqlColumnName}\").Value";
            var defaultCodeFull = $"{column.PropertyType}.Parse({defaultCode}.ToString())";

            var code = string.Empty;

            if(column.PropertyType.Equals("string"))
                code = $"{defaultCode}.ToString() ?? string.Empty";
            else
                code = column.IsNull ? $"{defaultCode} == null ? null : {defaultCodeFull}" : $"{defaultCodeFull}";

            return code;
        }

        public string SetValue(ColumnTable column)
        {
            var defaultCode = $"{VarName}.{column.PropertyName}";

            var code = string.Empty;

            if (column.PropertyType.Equals("string"))
                code = $"{defaultCode} ?? string.Empty";
            else if (column.PropertyType.Equals("decimal"))
                code = column.IsNull ? $"{defaultCode}.HasValue ? (double){defaultCode} : null" : $"(double){defaultCode}";
            else if (column.PropertyType.Equals("DateTime"))
                code = column.IsNull ? $"{defaultCode}.HasValue ? {defaultCode}.Value.ToString(\"yyyy-MM-dd\") : null" : $"{defaultCode}.ToString(\"yyyy-MM-dd\")";
            else
                code = $"{defaultCode} ?? string.Empty";

            return code;
        }

        public string GeneratorCodeGet()
        {
            var code = new StringBuilder();

            //ADD HEADER CLASS
            code.AppendLine($"if (type == typeof({ClassName}))");
            code.AppendLine("{");
            code.AppendLine($"{Common.NamePrefixes.Tab}return (T)Convert.ChangeType(new {ClassName}");
            code.AppendLine(Common.NamePrefixes.Tab + "{");

            //--ADD BODY CLASS
            foreach (var column in Columns)
                code.AppendLine($"{Common.NamePrefixes.DoubleTab}{column.PropertyName} = {GetValue(column)},");

            //--ADD END CLASS
            code.AppendLine(Common.NamePrefixes.Tab + "}, typeof(T));");
            code.AppendLine("}");

            return code.ToString();
        }

        public string GeneratorCodeSet()
        {
            var code = new StringBuilder();

            //ADD HEADER CLASS
            code.AppendLine($"if (type == typeof({ClassName}))");
            code.AppendLine("{");
            code.AppendLine($"{Common.NamePrefixes.Tab}var {VarName} = obj as {ClassName};");
            code.AppendLine($"{Common.NamePrefixes.Tab}if ({VarName} == null) return;");

            //--ADD BODY CLASS
            foreach (var column in Columns)
                code.AppendLine($"{Common.NamePrefixes.Tab}ut.UserFields.Fields.Item(\"{column.SqlColumnName}\").Value = {SetValue(column)};");

            //--ADD END CLASS
            code.AppendLine("}");

            return code.ToString();
        }

        public string GenerateCode()
        {
            var code = new StringBuilder();

            code.Append(GeneratorCodeGet());
            code.Append(GeneratorCodeSet());

            return code.ToString();
        }
    }
}
