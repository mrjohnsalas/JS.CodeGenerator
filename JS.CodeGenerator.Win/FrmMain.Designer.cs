namespace JS.CodeGenerator.Win
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSqlTableName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.dgdData = new System.Windows.Forms.DataGridView();
            this.btnLoadSchemma = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnFolderSearch = new System.Windows.Forms.Button();
            this.clSqlColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSqlDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSapDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSqlSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSqlPrecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPropertyType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clIsNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clSqlColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSqlTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSapDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL Table Name:";
            // 
            // txtSqlTableName
            // 
            this.txtSqlTableName.Location = new System.Drawing.Point(110, 39);
            this.txtSqlTableName.Name = "txtSqlTableName";
            this.txtSqlTableName.Size = new System.Drawing.Size(180, 20);
            this.txtSqlTableName.TabIndex = 1;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(110, 15);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(180, 20);
            this.txtClassName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class Name:";
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateCode.Location = new System.Drawing.Point(1269, 35);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(91, 23);
            this.btnGenerateCode.TabIndex = 4;
            this.btnGenerateCode.Text = "Generate Code";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // dgdData
            // 
            this.dgdData.AllowUserToOrderColumns = true;
            this.dgdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSqlColumnName,
            this.clSqlDataType,
            this.clSapDataType,
            this.clSqlSize,
            this.clSqlPrecision,
            this.clPropertyName,
            this.clPropertyType,
            this.clIsNull,
            this.clSqlColumnId,
            this.clSqlTableName,
            this.clSapDescription});
            this.dgdData.Location = new System.Drawing.Point(12, 64);
            this.dgdData.Name = "dgdData";
            this.dgdData.Size = new System.Drawing.Size(1348, 374);
            this.dgdData.TabIndex = 5;
            // 
            // btnLoadSchemma
            // 
            this.btnLoadSchemma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSchemma.Location = new System.Drawing.Point(1172, 35);
            this.btnLoadSchemma.Name = "btnLoadSchemma";
            this.btnLoadSchemma.Size = new System.Drawing.Size(91, 23);
            this.btnLoadSchemma.TabIndex = 6;
            this.btnLoadSchemma.Text = "Load Schemma";
            this.btnLoadSchemma.UseVisualStyleBackColor = true;
            this.btnLoadSchemma.Click += new System.EventHandler(this.btnLoadSchemma_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output Files:";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(393, 15);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.ReadOnly = true;
            this.txtOutputFolder.Size = new System.Drawing.Size(505, 20);
            this.txtOutputFolder.TabIndex = 8;
            // 
            // btnFolderSearch
            // 
            this.btnFolderSearch.Location = new System.Drawing.Point(362, 14);
            this.btnFolderSearch.Name = "btnFolderSearch";
            this.btnFolderSearch.Size = new System.Drawing.Size(31, 22);
            this.btnFolderSearch.TabIndex = 9;
            this.btnFolderSearch.Text = "\\\\";
            this.btnFolderSearch.UseVisualStyleBackColor = true;
            this.btnFolderSearch.Click += new System.EventHandler(this.btnFolderSearch_Click);
            // 
            // clSqlColumnName
            // 
            this.clSqlColumnName.HeaderText = "SqlColumnName";
            this.clSqlColumnName.Name = "clSqlColumnName";
            // 
            // clSqlDataType
            // 
            this.clSqlDataType.HeaderText = "SqlDataType";
            this.clSqlDataType.Name = "clSqlDataType";
            this.clSqlDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSqlDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clSqlDataType.Width = 150;
            // 
            // clSapDataType
            // 
            this.clSapDataType.HeaderText = "SapDataType";
            this.clSapDataType.Name = "clSapDataType";
            this.clSapDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSapDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clSapDataType.Width = 150;
            // 
            // clSqlSize
            // 
            this.clSqlSize.HeaderText = "SqlSize";
            this.clSqlSize.Name = "clSqlSize";
            // 
            // clSqlPrecision
            // 
            this.clSqlPrecision.HeaderText = "SqlPrecision";
            this.clSqlPrecision.Name = "clSqlPrecision";
            // 
            // clPropertyName
            // 
            this.clPropertyName.HeaderText = "PropertyName";
            this.clPropertyName.Name = "clPropertyName";
            // 
            // clPropertyType
            // 
            this.clPropertyType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clPropertyType.HeaderText = "PropertyType";
            this.clPropertyType.Items.AddRange(new object[] {
            "bool",
            "byte",
            "char",
            "DateTime",
            "decimal",
            "double",
            "float",
            "int",
            "long",
            "object",
            "sbyte",
            "short",
            "string",
            "uint",
            "ulong",
            "ushort"});
            this.clPropertyType.Name = "clPropertyType";
            this.clPropertyType.Width = 150;
            // 
            // clIsNull
            // 
            this.clIsNull.HeaderText = "IsNull";
            this.clIsNull.Name = "clIsNull";
            // 
            // clSqlColumnId
            // 
            this.clSqlColumnId.HeaderText = "SqlColumnId";
            this.clSqlColumnId.Name = "clSqlColumnId";
            // 
            // clSqlTableName
            // 
            this.clSqlTableName.HeaderText = "SqlTableName";
            this.clSqlTableName.Name = "clSqlTableName";
            // 
            // clSapDescription
            // 
            this.clSapDescription.HeaderText = "SapDescription";
            this.clSapDescription.Name = "clSapDescription";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 450);
            this.Controls.Add(this.btnFolderSearch);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadSchemma);
            this.Controls.Add(this.dgdData);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSqlTableName);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSqlTableName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.DataGridView dgdData;
        private System.Windows.Forms.Button btnLoadSchemma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnFolderSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSqlColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSqlDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSapDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSqlSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSqlPrecision;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPropertyName;
        private System.Windows.Forms.DataGridViewComboBoxColumn clPropertyType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSqlColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSqlTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSapDescription;
    }
}