namespace PatientManager.WinFormsApp.Forms
{
    partial class FormConfigureCamera
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
            this._comboBox = new System.Windows.Forms.ComboBox();
            this._buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _comboBox
            // 
            this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox.FormattingEnabled = true;
            this._comboBox.Location = new System.Drawing.Point(12, 24);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(260, 23);
            this._comboBox.TabIndex = 0;
            // 
            // _buttonSubmit
            // 
            this._buttonSubmit.Location = new System.Drawing.Point(278, 24);
            this._buttonSubmit.Name = "_buttonSubmit";
            this._buttonSubmit.Size = new System.Drawing.Size(132, 23);
            this._buttonSubmit.TabIndex = 1;
            this._buttonSubmit.Text = "Salvar";
            this._buttonSubmit.UseVisualStyleBackColor = true;
            this._buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // FormConfigureCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 66);
            this.Controls.Add(this._buttonSubmit);
            this.Controls.Add(this._comboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigureCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Câmera";
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox _comboBox;
        private Button _buttonSubmit;
    }
}