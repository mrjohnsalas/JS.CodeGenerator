using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JS.CodeGenerator.Common;
using JS.CodeGenerator.Data;
using JS.CodeGenerator.Data.Utility;

namespace JS.CodeGenerator.Win
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnLoadSchemma_Click(object sender, EventArgs e)
        {   
            try
            {
                this.dgdData.Rows.Clear();

                var tableName = this.txtSqlTableName.Text.Trim();
                if (tableName.Length.Equals(0))
                    throw new Exception("Necesita especificar el nombre de la tabla.");

                Cursor.Current = Cursors.WaitCursor;

                var spGen = new StoreProcedureGenerator(tableName);
                var sqlColumns = spGen.GetColumnsByTableName();

                foreach (var column in sqlColumns)
                {
                    var row = (DataGridViewRow)this.dgdData.Rows[0].Clone();

                    row.Cells[0].Value = column.SqlColumnName;
                    row.Cells[1].Value = column.SqlDataType;
                    row.Cells[2].Value = Utilities.GetSapDataType(column.SapDataType, column.SapDataType2);
                    row.Cells[3].Value = column.SqlSize;
                    row.Cells[4].Value = column.SqlPrecision;
                    row.Cells[5].Value = "";
                    row.Cells[6].Value = "";
                    row.Cells[7].Value = column.IsNull;
                    row.Cells[8].Value = column.Id;
                    row.Cells[9].Value = column.SqlTableName;
                    row.Cells[10].Value = column.SapDescription;

                    this.dgdData.Rows.Add(row);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnFolderSearch_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    this.txtOutputFolder.Text = fbd.SelectedPath;
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            try
            {
                var tableName = this.txtSqlTableName.Text.Trim();
                if (tableName.Length.Equals(0))
                    throw new Exception("Necesita especificar el nombre de la tabla.");

                var className = this.txtClassName.Text.Trim();
                if (className.Length.Equals(0))
                    throw new Exception("Necesita especificar el nombre de la clase.");
                var varName = $"{className.Substring(0, 1).ToLower()}{className.Substring(1, className.Length - 1)}";

                var outputFolder = this.txtOutputFolder.Text.Trim();
                if (outputFolder.Length.Equals(0))
                    throw new Exception("Necesita especificar el folder destino.");

                var sqlFileName = $"{tableName}.sql";
                var repositoryFileName = $"{className}Repository.cs";
                var interfaceFileName = $"I{className}Service.cs";
                var serviceFileName = $"{className}Service.cs";
                var gsFileName = $"{className}GetAndSet.cs";

                Cursor.Current = Cursors.WaitCursor;

                //GENERATE SQL
                var spGen = new StoreProcedureGenerator(tableName);
                var sqlCode = spGen.GenerateCode();
                Utilities.WriteFile(sqlCode, outputFolder, sqlFileName);
                //--

                var spMax = spGen.GetMaxStoreProcedure();

                //GENERATE REPOSITORY
                var rpGen = new RepositoryGenerator(tableName, className, spMax);
                var repositoryCode = rpGen.GenerateCode();
                Utilities.WriteFile(repositoryCode, outputFolder, repositoryFileName);
                //--

                //GENERATE SERVICE
                var svGen = new ServiceGenerator(className);
                var interfaceCode = svGen.GenerateCodeInterface();
                var serviceCode = svGen.GenerateCodeService();
                Utilities.WriteFile(interfaceCode, outputFolder, interfaceFileName);
                Utilities.WriteFile(serviceCode, outputFolder, serviceFileName);
                //--

                //GENERATE GET AND SET
                var columns = new List<ColumnTable>();
                for (var i = 0; i < this.dgdData.Rows.Count - 1; i++)
                {
                    var row = this.dgdData.Rows[i];
                    //row.Cells[2].Value = Utilities.GetSapDataType(column.SapDataType, column.SapDataType2);
                    columns.Add(new ColumnTable
                    {
                        Id = (int) row.Cells[8].Value,
                        SqlTableName = row.Cells[9].Value?.ToString(),
                        SqlColumnName = row.Cells[0].Value?.ToString(),
                        SapDescription = row.Cells[10].Value?.ToString(),
                        SqlDataType = row.Cells[6].Value?.ToString(),
                        SapDataType = "",
                        SapDataType2 = "",
                        SqlSize = (int) row.Cells[3].Value,
                        SqlPrecision = (int) row.Cells[4].Value,
                        NullValue = (bool) row.Cells[7].Value ? 1 : 0,
                        PropertyName = row.Cells[5].Value?.ToString(),
                        PropertyType = row.Cells[6].Value?.ToString()
                    });
                }

                var gsGen = new GetAndSetGenerator<ColumnTable>(tableName, className, varName, columns);
                var gsCode = gsGen.GenerateCode();
                Utilities.WriteFile(gsCode, outputFolder, gsFileName);
                //--

                Cursor.Current = Cursors.Default;
                MessageBox.Show("Archivos generados", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}