using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JS.CodeGenerator.Common;
using JS.CodeGenerator.Data.Context;
using JS.CodeGenerator.Data.Utility;

namespace JS.CodeGenerator.Data
{
    public class StoreProcedureGenerator
    {
        public string SqlTableName { get; set; }

        public StoreProcedureGenerator(string sqlTableName)
        {
            this.SqlTableName = sqlTableName;
        }

        public int GetMaxStoreProcedure()
        {
            var max = 0;
            var path = Utilities.GetPath() + "\\SqlQueries\\GetCountStoreProcedureWithPrefix.sql";
            var qb = new QueryBuilder(Utilities.ReadFile(path));
            qb.SetParameter(0, $"{Common.NamePrefixes.SqlStoreProcedureNamePrefix}%");
            var qry = qb.BuildQuery();
            using (var db = new CodeGeneratorContext())
                max = db.Database.SqlQuery<int>(qry).FirstOrDefault();
            return max;
        }

        public List<ColumnTable> GetColumnsByTableName()
        {
            var path = Utilities.GetPath() + "\\SqlQueries\\GetColumnsByTableName.sql";
            var qb = new QueryBuilder(Utilities.ReadFile(path));
            qb.SetParameter(0, SqlTableName);
            var qry = qb.BuildQuery();

            var columns = new List<ColumnTable>();
            using (var db = new CodeGeneratorContext())
                columns = db.Database.SqlQuery<ColumnTable>(qry).ToList();

            return columns;
        }

        public string GetColumns()
        {
            var columns = "T0.Code, T0.Name, ";
            foreach (var column in GetColumnsByTableName())
                columns += $"T0.{column}, ";
            return columns.Substring(0, columns.Length - 2);
        }

        public string GenerateCodeByNewId(string spId)
        {
            var code = new StringBuilder();

            code.AppendLine($"CREATE PROCEDURE [dbo].[GP_WEB_APP_{spId}]");
            code.AppendLine("AS");
            code.AppendLine($"SELECT ISNULL(MAX(CONVERT(INT, T0.Code)), 0) + 1 AS Id FROM [@{SqlTableName}] T0");
            code.AppendLine("GO");

            return code.ToString();
        }

        public string GenerateCodeByGet(string spId)
        {
            var code = new StringBuilder();

            code.AppendLine($"CREATE PROCEDURE [dbo].[GP_WEB_APP_{spId}]");
            code.AppendLine($"{Common.NamePrefixes.Tab}@ID AS NVARCHAR(30)");
            code.AppendLine("AS");
            code.AppendLine($"SELECT {GetColumns()} FROM [@{SqlTableName}] T0 WHERE T0.Code = @ID");
            code.AppendLine("GO");

            return code.ToString();
        }

        public string GenerateCodeByGetAll(string spId)
        {
            var code = new StringBuilder();

            code.AppendLine($"CREATE PROCEDURE [dbo].[GP_WEB_APP_{spId}]");
            code.AppendLine("AS");
            code.AppendLine($"SELECT {GetColumns()} FROM [@{SqlTableName}] T0");
            code.AppendLine("GO");

            return code.ToString();
        }

        public string GenerateCode()
        {
            var spMax = GetMaxStoreProcedure();

            var code = new StringBuilder();

            code.Append(GenerateCodeByNewId((spMax + 1).ToString("000")));
            code.Append(GenerateCodeByGet((spMax + 2).ToString("000")));
            code.Append(GenerateCodeByGetAll((spMax + 3).ToString("000")));

            return code.ToString();
        }
    }
}