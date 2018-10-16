using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.CodeGenerator.Data
{
    public class RepositoryGenerator
    {
        public string SqlTableName { get; set; }

        public string ClassName { get; set; }

        public int SpMax { get; set; }

        public string ClassNameRepository => $"{ClassName}{Common.NamePrefixes.RepositoryClassNamePrefix}";

        public RepositoryGenerator(string sqlTableName, string className, int spMax)
        {
            this.SqlTableName = sqlTableName;
            this.ClassName = className;
            this.SpMax = spMax;
        }

        public string GenerateCode()
        {
            var code = new StringBuilder();

            //ADD USINGS
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using SAPB1.JS.Data.Infrastructure;");
            code.AppendLine("using SAPB1.JS.Data.Utility;");
            code.AppendLine("using SAPB1.JS.Model.Models;");

            code.Append(Common.NamePrefixes.NewLine);

            //ADD HEADER CLASS
            code.AppendLine("namespace SAPB1.JS.Data.Repositories");
            code.AppendLine("{");
            code.AppendLine($"{Common.NamePrefixes.Tab}public class {ClassNameRepository}");
            code.AppendLine(Common.NamePrefixes.Tab + "{");

            //ADD BODY CLASS

            //----ADD GET ID
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}private static int GetNewId()");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "{");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}var qb = new QueryBuilder(\"EXEC [dbo].[GP_WEB_APP_{(SpMax + 1):000}]\");");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}var qry = qb.BuildQuery();");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}return SapDbHelper.GetValue<int>(qry, \"Id\");");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "}");

            //----ADD GET
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public static {ClassName} Get{ClassName}ById(int id)");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "{");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}var qb = new QueryBuilder(\"EXEC [dbo].[GP_WEB_APP_{(SpMax + 2):000}] ?\");");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}qb.SetParameter(0, id);");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}var qry = qb.BuildQuery();");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}return SapDbHelper.GetObject<{ClassName}>(qry);");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "}");

            //----ADD GET ALL
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public static IEnumerable<{ClassName}> Get{ClassName}s()");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "{");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}var qb = new QueryBuilder(\"EXEC [dbo].[GP_WEB_APP_{(SpMax + 3):000}]\");");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}var qry = qb.BuildQuery();");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}return SapDbHelper.GetObjects<{ClassName}>(qry);");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "}");

            //----ADD INSERT
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public static void {ClassName}Insert({ClassName} {Common.NamePrefixes.PrincipalParameterNamePrefix})");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "{");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}obj.StatusType = StatusType.Activo;");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}SapDbHelper.UTableObject(\"{SqlTableName}\", SapDbHelper.ActionTable.Insert, GetNewId().ToString(), {Common.NamePrefixes.PrincipalParameterNamePrefix});");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "}");

            //----ADD UPDATE
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public static void {ClassName}Update({ClassName} {Common.NamePrefixes.PrincipalParameterNamePrefix})");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "{");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}SapDbHelper.UTableObject(\"{SqlTableName}\", SapDbHelper.ActionTable.Update, obj.Id.ToString(), {Common.NamePrefixes.PrincipalParameterNamePrefix});");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "}");

            //----ADD DELETE
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public static void {ClassName}DeleteById(int id)");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "{");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}var {Common.NamePrefixes.PrincipalParameterNamePrefix} = Get{ClassName}ById(id);");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}{Common.NamePrefixes.PrincipalParameterNamePrefix}.StatusType = StatusType.Inactivo;");
            code.AppendLine($"{Common.NamePrefixes.ThreeTab}SapDbHelper.UTableObject(\"{SqlTableName}\", SapDbHelper.ActionTable.Update, {Common.NamePrefixes.PrincipalParameterNamePrefix}.Id.ToString(), {Common.NamePrefixes.PrincipalParameterNamePrefix});");
            code.AppendLine(Common.NamePrefixes.DoubleTab + "}");

            //--ADD END CLASS
            code.AppendLine(Common.NamePrefixes.Tab + "}");
            code.AppendLine("}");

            return code.ToString();
        }
    }
}