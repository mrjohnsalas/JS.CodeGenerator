using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.CodeGenerator.Data
{
    public class ServiceGenerator
    {
        public string ClassName { get; set; }

        public string ClassNameService => $"{ClassName}Service";

        public string ClassNameInterface => $"I{ClassName}Service";

        public ServiceGenerator(string className)
        {
            this.ClassName = className;
        }

        public string GenerateCodeInterface()
        {
            var code = new StringBuilder();

            //ADD USINGS
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using System.ServiceModel;");
            code.AppendLine("using SAPB1.JS.Model.Models;");

            code.Append(Common.NamePrefixes.NewLine);

            //ADD HEADER CLASS
            code.AppendLine("namespace SAPB1.JS.Service");
            code.AppendLine("{");
            code.AppendLine($"{Common.NamePrefixes.Tab}// NOTE: You can use the \"Rename\" command on the \"Refactor\" menu to change the interface name \"{ClassNameInterface}\" in both code and config file together.");
            code.AppendLine($"{Common.NamePrefixes.Tab}[ServiceContract]");
            code.AppendLine($"{Common.NamePrefixes.Tab}public interface {ClassNameInterface}");
            code.AppendLine(Common.NamePrefixes.Tab + "{");

            //ADD BODY CLASS
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}[OperationContract]");
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}IEnumerable<{ClassName}> Get{ClassName}s();");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}[OperationContract]");
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}{ClassName} Get{ClassName}ById(int id);");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}[OperationContract]");
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}void {ClassName}Insert({ClassName} {Common.NamePrefixes.PrincipalParameterNamePrefix});");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}[OperationContract]");
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}void {ClassName}Update({ClassName} {Common.NamePrefixes.PrincipalParameterNamePrefix});");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}[OperationContract]");
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}void {ClassName}DeleteById(int id);");

            //--ADD END CLASS
            code.AppendLine(Common.NamePrefixes.Tab + "}");
            code.AppendLine("}");

            return code.ToString();
        }

        public string GenerateCodeService()
        {
            var code = new StringBuilder();

            //ADD USINGS
            code.AppendLine("using System.Collections.Generic;");
            code.AppendLine("using SAPB1.JS.Data.Repositories;");
            code.AppendLine("using SAPB1.JS.Model.Models;");

            code.Append(Common.NamePrefixes.NewLine);

            //ADD HEADER CLASS
            code.AppendLine("namespace SAPB1.JS.Service");
            code.AppendLine("{");
            code.AppendLine($"{Common.NamePrefixes.Tab}// NOTE: You can use the \"Rename\" command on the \"Refactor\" menu to change the class name \"{ClassNameService}\" in code, svc and config file together.");
            code.AppendLine($"{Common.NamePrefixes.Tab}// NOTE: In order to launch WCF Test Client for testing this service, please select {ClassNameService}.svc or {ClassNameService}.svc.cs at the Solution Explorer and start debugging.");
            code.AppendLine($"{Common.NamePrefixes.Tab}public class {ClassNameService} : {ClassNameInterface}");
            code.AppendLine(Common.NamePrefixes.Tab + "{");

            //ADD BODY CLASS
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public {ClassName} Get{ClassName}ById(int id) => {ClassName}Repository.Get{ClassName}ById(id);");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public IEnumerable<{ClassName}> Get{ClassName}s() => {ClassName}Repository.Get{ClassName}s();");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public void {ClassName}Insert({ClassName} {Common.NamePrefixes.PrincipalParameterNamePrefix}) => {ClassName}Repository.{ClassName}Insert({Common.NamePrefixes.PrincipalParameterNamePrefix});");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public void {ClassName}Update({ClassName} {Common.NamePrefixes.PrincipalParameterNamePrefix}) => {ClassName}Repository.{ClassName}Update({Common.NamePrefixes.PrincipalParameterNamePrefix});");
            code.Append(Common.NamePrefixes.NewLine);
            code.AppendLine($"{Common.NamePrefixes.DoubleTab}public void {ClassName}DeleteById(int id) => {ClassName}Repository.{ClassName}DeleteById(id);");

            //--ADD END CLASS
            code.AppendLine(Common.NamePrefixes.Tab + "}");
            code.AppendLine("}");

            return code.ToString();
        }

        public string GenerateCode()
        {
            var code = new StringBuilder();

            code.Append(GenerateCodeInterface());
            code.Append(GenerateCodeService());

            return code.ToString();
        }
    }
}
