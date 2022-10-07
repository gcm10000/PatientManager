namespace PatientManager.WinFormsApp.Forms
{
    partial class FormConfigurePageSize
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
            this._buttonSave = new System.Windows.Forms.Button();
            this._comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(265, 12);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(122, 23);
            this._buttonSave.TabIndex = 1;
            this._buttonSave.Text = "Salvar";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // _comboBox
            // 
            this._comboBox.FormattingEnabled = true;
            this._comboBox.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100"});
            this._comboBox.Location = new System.Drawing.Point(12, 13);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(247, 23);
            this._comboBox.TabIndex = 2;
            this._comboBox.SelectedIndex = 0;
            this._comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // FormConfigurePageSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 46);
            this.Controls.Add(this._comboBox);
            this.Controls.Add(this._buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigurePageSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Número de Registro por Página";
            this.ResumeLayout(false);

        }

        #endregion

        private Button _buttonSave;
        private ComboBox _comboBox;
    }
}