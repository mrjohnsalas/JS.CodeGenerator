using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.CodeGenerator.Common
{
    public class Table
    {
        [Key]
        public string TableName { get; set; }

        public ICollection<ColumnTable> Columns { get; set; }
    }
}