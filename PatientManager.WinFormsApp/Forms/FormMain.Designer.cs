namespace PatientManager.WinFormsApp.Forms
{
    partial class FormMain
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
            this._textBoxSearch = new System.Windows.Forms.TextBox();
            this._buttonSearch = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarParaCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarParaXLSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarNúmeroDeRegistroPorPáginaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarCâmeraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._panelFooter = new System.Windows.Forms.Panel();
            this._labelPagination = new System.Windows.Forms.Label();
            this._buttonNext = new System.Windows.Forms.Button();
            this._buttonPrevious = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._dataGridViewResults = new System.Windows.Forms.DataGridView();
            this._saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this._saveFileDialogXLSX = new System.Windows.Forms.SaveFileDialog();
            this.panelSearch.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this._panelFooter.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // _textBoxSearch
            // 
            this._textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxSearch.Location = new System.Drawing.Point(3, 3);
            this._textBoxSearch.Name = "_textBoxSearch";
            this._textBoxSearch.Size = new System.Drawing.Size(631, 23);
            this._textBoxSearch.TabIndex = 0;
            this._textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);
            // 
            // _buttonSearch
            // 
            this._buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._buttonSearch.Location = new System.Drawing.Point(648, 3);
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Size = new System.Drawing.Size(125, 24);
            this._buttonSearch.TabIndex = 1;
            this._buttonSearch.Text = "Consultar";
            this._buttonSearch.UseVisualStyleBackColor = true;
            this._buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this._textBoxSearch);
            this.panelSearch.Controls.Add(this._buttonSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 24);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(800, 49);
            this.panelSearch.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarPacienteToolStripMenuItem,
            this.exportarToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // adicionarPacienteToolStripMenuItem
            // 
            this.adicionarPacienteToolStripMenuItem.Name = "adicionarPacienteToolStripMenuItem";
            this.adicionarPacienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.adicionarPacienteToolStripMenuItem.Text = "Adicionar Paciente";
            this.adicionarPacienteToolStripMenuItem.Click += new System.EventHandler(this.AdicionarPacienteToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarParaCSVToolStripMenuItem,
            this.exportarParaXLSXToolStripMenuItem});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportarToolStripMenuItem.Text = "Exportar Pacientes...";
            // 
            // exportarParaCSVToolStripMenuItem
            // 
            this.exportarParaCSVToolStripMenuItem.Name = "exportarParaCSVToolStripMenuItem";
            this.exportarParaCSVToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.exportarParaCSVToolStripMenuItem.Text = "Exportar Pacientes para CSV";
            this.exportarParaCSVToolStripMenuItem.Click += new System.EventHandler(this.ExportarParaCSVToolStripMenuItem_Click);
            // 
            // exportarParaXLSXToolStripMenuItem
            // 
            this.exportarParaXLSXToolStripMenuItem.Name = "exportarParaXLSXToolStripMenuItem";
            this.exportarParaXLSXToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.exportarParaXLSXToolStripMenuItem.Text = "Exportar Pacientes para XLSX";
            this.exportarParaXLSXToolStripMenuItem.Click += new System.EventHandler(this.ExportarParaXLSXToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarNúmeroDeRegistroPorPáginaToolStripMenuItem,
            this.configurarCâmeraToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // configurarNúmeroDeRegistroPorPáginaToolStripMenuItem
            // 
            this.configurarNúmeroDeRegistroPorPáginaToolStripMenuItem.Name = "configurarNúmeroDeRegistroPorPáginaToolStripMenuItem";
            this.configurarNúmeroDeRegistroPorPáginaToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.configurarNúmeroDeRegistroPorPáginaToolStripMenuItem.Text = "Configurar número de registro por página";
            this.configurarNúmeroDeRegistroPorPáginaToolStripMenuItem.Click += new System.EventHandler(this.ConfigurarNúmeroDeRegistroPorPáginaToolStripMenuItem_Click);
            // 
            // configurarCâmeraToolStripMenuItem
            // 
            this.configurarCâmeraToolStripMenuItem.Name = "configurarCâmeraToolStripMenuItem";
            this.configurarCâmeraToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.configurarCâmeraToolStripMenuItem.Text = "Configurar Câmera";
            this.configurarCâmeraToolStripMenuItem.Click += new System.EventHandler(this.ConfigurarCâmeraToolStripMenuItem_Click);
            // 
            // _panelFooter
            // 
            this._panelFooter.Controls.Add(this._labelPagination);
            this._panelFooter.Controls.Add(this._buttonNext);
            this._panelFooter.Controls.Add(this._buttonPrevious);
            this._panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panelFooter.Location = new System.Drawing.Point(0, 414);
            this._panelFooter.Name = "_panelFooter";
            this._panelFooter.Size = new System.Drawing.Size(800, 36);
            this._panelFooter.TabIndex = 5;
            // 
            // _labelPagination
            // 
            this._labelPagination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._labelPagination.AutoSize = true;
            this._labelPagination.Location = new System.Drawing.Point(12, 12);
            this._labelPagination.Name = "_labelPagination";
            this._labelPagination.Size = new System.Drawing.Size(0, 15);
            this._labelPagination.TabIndex = 2;
            // 
            // _buttonNext
            // 
            this._buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonNext.Enabled = false;
            this._buttonNext.Location = new System.Drawing.Point(722, 10);
            this._buttonNext.Name = "_buttonNext";
            this._buttonNext.Size = new System.Drawing.Size(75, 23);
            this._buttonNext.TabIndex = 1;
            this._buttonNext.Text = "Próximo";
            this._buttonNext.UseVisualStyleBackColor = true;
            this._buttonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // _buttonPrevious
            // 
            this._buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonPrevious.Enabled = false;
            this._buttonPrevious.Location = new System.Drawing.Point(641, 10);
            this._buttonPrevious.Name = "_buttonPrevious";
            this._buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this._buttonPrevious.TabIndex = 0;
            this._buttonPrevious.Text = "Anterior";
            this._buttonPrevious.UseVisualStyleBackColor = true;
            this._buttonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._dataGridViewResults);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 341);
            this.panel2.TabIndex = 6;
            // 
            // _dataGridViewResults
            // 
            this._dataGridViewResults.AllowUserToAddRows = false;
            this._dataGridViewResults.AllowUserToDeleteRows = false;
            this._dataGridViewResults.AllowUserToResizeColumns = false;
            this._dataGridViewResults.AllowUserToResizeRows = false;
            this._dataGridViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridViewResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this._dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewResults.GridColor = System.Drawing.SystemColors.Control;
            this._dataGridViewResults.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewResults.MultiSelect = false;
            this._dataGridViewResults.Name = "_dataGridViewResults";
            this._dataGridViewResults.ReadOnly = true;
            this._dataGridViewResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._dataGridViewResults.RowHeadersVisible = false;
            this._dataGridViewResults.RowTemplate.Height = 25;
            this._dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewResults.Size = new System.Drawing.Size(800, 341);
            this._dataGridViewResults.TabIndex = 3;
            this._dataGridViewResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewResults_CellDoubleClick);
            this._dataGridViewResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewResults_CellMouseDown);
            // 
            // _saveFileDialogCSV
            // 
            this._saveFileDialogCSV.Filter = "csv files (*.csv)|*.csv";
            // 
            // _saveFileDialogXLSX
            // 
            this._saveFileDialogXLSX.Filter = "xlsx files (*.xlsx)|*.xlsx";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this._panelFooter);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador de Pacientes";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._panelFooter.ResumeLayout(false);
            this._panelFooter.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox _textBoxSearch;
        private Button _buttonSearch;
        private Panel panelSearch;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem opçõesToolStripMenuItem;
        private ToolStripMenuItem adicionarPacienteToolStripMenuItem;
        private Panel _panelFooter;
        private Button _buttonNext;
        private Button _buttonPrevious;
        private Panel panel2;
        private DataGridView _dataGridViewResults;
        private Label _labelPagination;
        private ToolStripMenuItem configuraçõesToolStripMenuItem;
        private ToolStripMenuItem configurarNúmeroDeRegistroPorPáginaToolStripMenuItem;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private ToolStripMenuItem exportarParaCSVToolStripMenuItem;
        private ToolStripMenuItem exportarParaXLSXToolStripMenuItem;
        private SaveFileDialog _saveFileDialogCSV;
        private SaveFileDialog _saveFileDialogXLSX;
        private ToolStripMenuItem configurarCâmeraToolStripMenuItem;
    }
}