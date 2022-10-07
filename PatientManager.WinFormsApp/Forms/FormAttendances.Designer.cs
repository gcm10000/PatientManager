namespace PatientManager.WinFormsApp.Forms
{
    partial class FormAttendances
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
            this.components = new System.ComponentModel.Container();
            this._panelFooter = new System.Windows.Forms.Panel();
            this._labelPagination = new System.Windows.Forms.Label();
            this._buttonNext = new System.Windows.Forms.Button();
            this._buttonPrevious = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._dataGridViewResults = new System.Windows.Forms.DataGridView();
            this._contextMenuStripDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.atualizarPresençaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerPresençaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarPresençasParaCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarPresençasParaXLSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveFileDialogXLSX = new System.Windows.Forms.SaveFileDialog();
            this._saveFileDialogCSV = new System.Windows.Forms.SaveFileDialog();
            this._panelFooter.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResults)).BeginInit();
            this._contextMenuStripDataGrid.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this._panelFooter.TabIndex = 9;
            // 
            // _labelPagination
            // 
            this._labelPagination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._labelPagination.AutoSize = true;
            this._labelPagination.Location = new System.Drawing.Point(12, 10);
            this._labelPagination.Name = "_labelPagination";
            this._labelPagination.Size = new System.Drawing.Size(0, 15);
            this._labelPagination.TabIndex = 4;
            // 
            // _buttonNext
            // 
            this._buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonNext.Enabled = false;
            this._buttonNext.Location = new System.Drawing.Point(722, 10);
            this._buttonNext.Name = "_buttonNext";
            this._buttonNext.Size = new System.Drawing.Size(75, 23);
            this._buttonNext.TabIndex = 4;
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
            this._buttonPrevious.TabIndex = 3;
            this._buttonPrevious.Text = "Anterior";
            this._buttonPrevious.UseVisualStyleBackColor = true;
            this._buttonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._dataGridViewResults);
            this.panel2.Controls.Add(this._menuStrip);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 450);
            this.panel2.TabIndex = 10;
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
            this._dataGridViewResults.ContextMenuStrip = this._contextMenuStripDataGrid;
            this._dataGridViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewResults.GridColor = System.Drawing.SystemColors.Control;
            this._dataGridViewResults.Location = new System.Drawing.Point(0, 24);
            this._dataGridViewResults.MultiSelect = false;
            this._dataGridViewResults.Name = "_dataGridViewResults";
            this._dataGridViewResults.ReadOnly = true;
            this._dataGridViewResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._dataGridViewResults.RowHeadersVisible = false;
            this._dataGridViewResults.RowTemplate.Height = 25;
            this._dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewResults.Size = new System.Drawing.Size(800, 426);
            this._dataGridViewResults.TabIndex = 3;
            this._dataGridViewResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridViewResults_MouseDown);
            // 
            // _contextMenuStripDataGrid
            // 
            this._contextMenuStripDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizarPresençaToolStripMenuItem,
            this.removerPresençaToolStripMenuItem});
            this._contextMenuStripDataGrid.Name = "_contextMenuStripDataGrid";
            this._contextMenuStripDataGrid.Size = new System.Drawing.Size(172, 48);
            // 
            // atualizarPresençaToolStripMenuItem
            // 
            this.atualizarPresençaToolStripMenuItem.Name = "atualizarPresençaToolStripMenuItem";
            this.atualizarPresençaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.atualizarPresençaToolStripMenuItem.Text = "Atualizar Presença";
            this.atualizarPresençaToolStripMenuItem.Click += new System.EventHandler(this.AtualizarPresençaToolStripMenuItem_Click);
            // 
            // removerPresençaToolStripMenuItem
            // 
            this.removerPresençaToolStripMenuItem.Name = "removerPresençaToolStripMenuItem";
            this.removerPresençaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.removerPresençaToolStripMenuItem.Text = "Remover Presença";
            this.removerPresençaToolStripMenuItem.Click += new System.EventHandler(this.RemoverPresençaToolStripMenuItem_Click);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(800, 24);
            this._menuStrip.TabIndex = 4;
            this._menuStrip.Text = "menuStrip1";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem});
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarPresençasParaCSVToolStripMenuItem,
            this.exportarPresençasParaXLSXToolStripMenuItem});
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportarToolStripMenuItem.Text = "Exportar Presenças...";
            // 
            // exportarPresençasParaCSVToolStripMenuItem
            // 
            this.exportarPresençasParaCSVToolStripMenuItem.Name = "exportarPresençasParaCSVToolStripMenuItem";
            this.exportarPresençasParaCSVToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.exportarPresençasParaCSVToolStripMenuItem.Text = "Exportar Presenças para CSV";
            this.exportarPresençasParaCSVToolStripMenuItem.Click += new System.EventHandler(this.ExportarPresençasParaCSVToolStripMenuItem_Click);
            // 
            // exportarPresençasParaXLSXToolStripMenuItem
            // 
            this.exportarPresençasParaXLSXToolStripMenuItem.Name = "exportarPresençasParaXLSXToolStripMenuItem";
            this.exportarPresençasParaXLSXToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.exportarPresençasParaXLSXToolStripMenuItem.Text = "Exportar Presenças para XLSX";
            this.exportarPresençasParaXLSXToolStripMenuItem.Click += new System.EventHandler(this.ExportarPresençasParaXLSXToolStripMenuItem_Click);
            // 
            // _saveFileDialogXLSX
            // 
            this._saveFileDialogXLSX.Filter = "xlsx files (*.xlsx)|*.xlsx";
            // 
            // _saveFileDialogCSV
            // 
            this._saveFileDialogCSV.Filter = "csv files (*.csv)|*.csv";
            // 
            // FormAttendances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._panelFooter);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "FormAttendances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Presenças";
            this._panelFooter.ResumeLayout(false);
            this._panelFooter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewResults)).EndInit();
            this._contextMenuStripDataGrid.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel _panelFooter;
        private Panel panel2;
        private DataGridView _dataGridViewResults;
        private Button _buttonNext;
        private Button _buttonPrevious;
        private Label _labelPagination;
        private ContextMenuStrip _contextMenuStripDataGrid;
        private ToolStripMenuItem atualizarPresençaToolStripMenuItem;
        private ToolStripMenuItem removerPresençaToolStripMenuItem;
        private MenuStrip _menuStrip;
        private ToolStripMenuItem opçõesToolStripMenuItem;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private ToolStripMenuItem exportarPresençasParaCSVToolStripMenuItem;
        private ToolStripMenuItem exportarPresençasParaXLSXToolStripMenuItem;
        private SaveFileDialog _saveFileDialogXLSX;
        private SaveFileDialog _saveFileDialogCSV;
    }
}