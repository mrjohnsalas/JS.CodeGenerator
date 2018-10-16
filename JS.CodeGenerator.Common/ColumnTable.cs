using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.CodeGenerator.Common
{
    public class ColumnTable
    {
        public int Id { get; set; }

        public string SqlTableName { get; set; }

        public string SqlColumnName { get; set; }

        public string SapDescription { get; set; }

        public string SqlDataType { get; set; }

        public string SapDataType { get; set; }

        public string SapDataType2 { get; set; }

        public int SqlSize { get; set; }

        public int SqlPrecision { get; set; }

        public int NullValue { get; set; }

        public bool IsNull => NullValue.Equals(1);

        public string SqlTableNameS => SqlTableName.Replace("@", "");

        public string PropertyName { get; set; }

        public string PropertyType { get; set; }
    }
}
