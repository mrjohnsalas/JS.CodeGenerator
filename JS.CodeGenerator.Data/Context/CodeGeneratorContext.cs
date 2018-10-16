using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JS.CodeGenerator.Common;

namespace JS.CodeGenerator.Data.Context
{
    public class CodeGeneratorContext : DbContext
    {
        public CodeGeneratorContext() : base("name=CodeGeneratorContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual void Commit() => SaveChanges();

        //public DbSet<ColumnTable> ColumnTables { get; set; }

        //public DbSet<Table> Tables { get; set; }
    }
}
