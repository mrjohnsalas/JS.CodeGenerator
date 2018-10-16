using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JS.CodeGenerator.Data
{
    public class GetAndSetGenerator<T>
    {
        public string SqlTableName { get; set; }

        public string ClassName { get; set; }

        public GetAndSetGenerator(string sqlTableName, string className)
        {
            this.SqlTableName = sqlTableName;
            this.ClassName = className;
        }

        public string GeneratorCodeGet()
        {
            var code = new StringBuilder();

            //ADD HEADER CLASS
            code.AppendLine($"if (type == typeof({ClassName}))");
            code.AppendLine("{");
            code.AppendLine($"{Common.NamePrefixes.Tab}return (T)Convert.ChangeType(new {ClassName}");
            code.AppendLine(Common.NamePrefixes.Tab + "{");

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.PropertyType.ToString().Contains("System."))
                {
                    code.AppendLine(Common.NamePrefixes.DoubleTab + $"{prop.Name} = {GetConvert(prop, "rs.Fields.Item(\"Code\").Value.ToString()")}");
                }
            }

            //--ADD END CLASS
            code.AppendLine(Common.NamePrefixes.Tab + "}, typeof(T));");
            code.AppendLine("}");

            return code.ToString();
        }

        public string GetConvert(PropertyInfo property, string value)
        {
            switch (property.PropertyType.ToString())
            {
                case "System.Int32":
                    return $"int.Parse({value})";
                case "System.String":
                    return $"{value} ?? string.Empty";
                default:
                    return string.Empty;
            }
        }





        private void Convert()
        {
            //if (type == typeof(Address))
            //{
            //    return (T)Convert.ChangeType(new Address
            //    {
            //        Id = rs.Fields.Item("Address").Value.ToString(),
            //        Street = rs.Fields.Item("Street").Value.ToString(),
            //        Country = rs.Fields.Item("Country").Value.ToString(),
            //        City = rs.Fields.Item("City").Value.ToString(),
            //        County = rs.Fields.Item("County").Value.ToString(),
            //        EsLimaValue = (int)rs.Fields.Item("ES_LIMA").Value
            //    }, typeof(T));
            //}
            //if (type == typeof(WebAppSetting))
            //{
            //    return (T)Convert.ChangeType(new WebAppSetting
            //    {
            //        TransferenciaFinMes = (bool)rs.Fields.Item("U_CL_TRAFDM").Value,
            //        FechaTransferencia = rs.Fields.Item("U_CL_FECTRA").Value == null ? null : DateTime.Parse(rs.Fields.Item("U_CL_FECTRA").Value.ToString()),
            //    }, typeof(T));
            //}
            //if (type == typeof(Driver))
            //{
            //    return (T)Convert.ChangeType(new Driver
            //    {
            //        Id = int.Parse(rs.Fields.Item("Code").Value.ToString()),
            //        FirstName = rs.Fields.Item("U_CL_NOMBRE").Value.ToString() ?? string.Empty,
            //        LastName = rs.Fields.Item("U_CL_APELLI").Value.ToString() ?? string.Empty,
            //        Licencia = rs.Fields.Item("U_BPP_CHLI").Value.ToString() ?? string.Empty,
            //        Phone = rs.Fields.Item("U_CL_CELULA").Value.ToString() ?? string.Empty,
            //        Email = rs.Fields.Item("U_CL_EMAIL").Value.ToString() ?? string.Empty,
            //        BusinessPartnerId = rs.Fields.Item("U_CL_CODPRO").Value.ToString() ?? string.Empty
            //    }, typeof(T));
            //}
            //if (type == typeof(Vehicle))
            //{
            //    return (T)Convert.ChangeType(new Vehicle
            //    {
            //        Id = int.Parse(rs.Fields.Item("Code").Value.ToString()),
            //        Year = int.Parse(rs.Fields.Item("U_BPP_VEAN").Value.ToString()),
            //        Color = rs.Fields.Item("U_BPP_VECO").Value.ToString() ?? string.Empty,
            //        Marca = rs.Fields.Item("U_BPP_VEMA").Value.ToString() ?? string.Empty,
            //        Modelo = rs.Fields.Item("U_BPP_VEMO").Value.ToString() ?? string.Empty,
            //        TipoPlaca = rs.Fields.Item("U_VS_TIPO_P").Value.ToString() ?? string.Empty,
            //        Placa = rs.Fields.Item("U_BPP_VEPL").Value.ToString() ?? string.Empty,
            //        PesoMaximo = (decimal)rs.Fields.Item("U_BPP_VEPM").Value,
            //        SerieMotor = rs.Fields.Item("U_BPP_VESE").Value.ToString() ?? string.Empty,
            //        VencimientoSoat = rs.Fields.Item("U_VS_VTO_SOAT").Value == null ? null : DateTime.Parse(rs.Fields.Item("U_VS_VTO_SOAT").Value.ToString()),
            //        Status = rs.Fields.Item("U_VS_FROZEN").Value.ToString() ?? string.Empty,
            //        ConstanciaInscripcion = rs.Fields.Item("U_CL_CNTINS").Value.ToString() ?? string.Empty,
            //        CertificadoInscripcion = rs.Fields.Item("U_TC_CERT_INSC").Value.ToString() ?? string.Empty,
            //        Configuracion = rs.Fields.Item("U_TC_CONF_VEHI").Value.ToString() ?? string.Empty,
            //        SerieChasis = rs.Fields.Item("U_SM_SERIE_MOTOR").Value.ToString() ?? string.Empty,
            //        SerieOpcional = rs.Fields.Item("U_SERIE4").Value.ToString() ?? string.Empty,
            //        BusinessPartnerId = rs.Fields.Item("U_CL_CODPRO").Value.ToString() ?? string.Empty
            //    }, typeof(T));
            //}

            //if (type == typeof(Flete))
            //{
            //    return (T)Convert.ChangeType(new Flete
            //    {
            //        Id = int.Parse(rs.Fields.Item("Code").Value.ToString()),
            //        BusinessPartnerId = rs.Fields.Item("U_CL_CODPRO").Value.ToString(),
            //        DriverId = int.Parse(rs.Fields.Item("U_CL_CODDRI").Value.ToString()),
            //        VehicleId = int.Parse(rs.Fields.Item("U_CL_CODVEH").Value.ToString()),
            //        SerieFactura = rs.Fields.Item("U_CL_SERFAC").Value.ToString(),
            //        NroFactura = rs.Fields.Item("U_CL_NROFAC").Value.ToString(),
            //        TotalFactura = (decimal)rs.Fields.Item("U_CL_TOTFAC").Value,
            //        CostoPorDia = (decimal)rs.Fields.Item("U_CL_COSDIA").Value,
            //        Remark = rs.Fields.Item("U_CL_REMARK").Value.ToString() ?? string.Empty,
            //        FechaCreacion = DateTime.Parse(rs.Fields.Item("U_CL_FECCRE").Value.ToString()),
            //        FechaSistema = DateTime.Parse(rs.Fields.Item("U_CL_FECSYS").Value.ToString()),
            //        FechaModificacion = rs.Fields.Item("U_CL_FECUPD").Value == null ? null : DateTime.Parse(rs.Fields.Item("U_CL_FECUPD").Value.ToString()),
            //        UserId = rs.Fields.Item("U_CL_USERID").Value.ToString(),
            //        StatusId = (int)rs.Fields.Item("U_CL_STATUS").Value
            //    }, typeof(T));
            //}

            //if (type == typeof(FleteDetalle))
            //{
            //    return (T)Convert.ChangeType(new FleteDetalle
            //    {
            //        Id = int.Parse(rs.Fields.Item("Code").Value.ToString()),
            //        FleteId = int.Parse(rs.Fields.Item("U_CL_CODFLE").Value.ToString()),
            //        FechaTraslado = DateTime.Parse(rs.Fields.Item("U_CL_FECTRA").Value.ToString()),
            //        NroViaje = (int)rs.Fields.Item("U_CL_NROVIA").Value,
            //        CostoPeaje = (decimal)rs.Fields.Item("U_CL_COSPEA").Value,
            //        CostoCochera = (decimal)rs.Fields.Item("U_CL_COSCOC").Value,
            //        CostoHoraExtra = (decimal)rs.Fields.Item("U_CL_COSHEX").Value,
            //        StatusTrasladoId = (int)rs.Fields.Item("U_CL_STSTRA").Value,
            //        Remark = rs.Fields.Item("U_CL_REMARK").Value.ToString() ?? string.Empty,
            //        FechaCreacion = DateTime.Parse(rs.Fields.Item("U_CL_FECCRE").Value.ToString()),
            //        FechaSistema = DateTime.Parse(rs.Fields.Item("U_CL_FECSYS").Value.ToString()),
            //        FechaModificacion = rs.Fields.Item("U_CL_FECUPD").Value == null ? null : DateTime.Parse(rs.Fields.Item("U_CL_FECUPD").Value.ToString()),
            //        UserId = rs.Fields.Item("U_CL_USERID").Value.ToString(),
            //        StatusId = (int)rs.Fields.Item("U_CL_STATUS").Value,
            //        GuiaId = int.Parse(rs.Fields.Item("U_CL_CODGUI").Value.ToString())
            //    }, typeof(T));
            //}
        }
    }
}
