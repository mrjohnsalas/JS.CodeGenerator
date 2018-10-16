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
        [Key]
        public int Id { get; set; }

        public string ColumnName { get; set; }

        public string Description { get; set; }

        public string NotNull { get; set; }

        public int Size { get; set; }

        public string TableName { get; set; }

        public string ColumnNameFull => $"@{ColumnName}";

        public bool IsNull => NotNull.Equals("N");

        public Table Table { get; set; }
    }
}
