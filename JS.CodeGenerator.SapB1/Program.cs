using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JS.CodeGenerator.Common;
using JS.CodeGenerator.Data;
using JS.CodeGenerator.Data.Utility;

namespace JS.CodeGenerator.SapB1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tableName = "GP_NIVTIN";
            var className = "NivelTinta";

            //GENERATE SQL
            var spGen = new StoreProcedureGenerator(tableName);
            var spMax = spGen.GetMaxStoreProcedure();

            var repositorySp = spGen.GenerateCode();
            Console.Write(repositorySp);
            Console.WriteLine("Code SQL generated!!!");

            Console.WriteLine("");
            Console.WriteLine("");

            //GENERATE REPOSITORY
            var rpGen = new RepositoryGenerator(tableName, className, spMax);
            var repositoryCode = rpGen.GenerateCode();
            Console.Write(repositoryCode);
            Console.WriteLine("Code Repository generated!!!");

            Console.WriteLine("");
            Console.WriteLine("");

            //GENERATE SERVICE
            var svGen = new ServiceGenerator(className);
            var serviceCode = svGen.GenerateCode();
            Console.Write(serviceCode);
            Console.WriteLine("Code Service generated!!!");

            Console.WriteLine("");
            Console.WriteLine("");

            //GET PROPERTIES
            foreach (var prop in typeof(ColumnTable).GetProperties())
            {
                Console.WriteLine("{0}={1}", prop.Name, prop.PropertyType);
            }

            Console.ReadLine();
        }
    }
}
