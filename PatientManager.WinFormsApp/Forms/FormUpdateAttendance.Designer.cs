namespace PatientManager.WinFormsApp.Forms
{
    partial class FormUpdateAttendance
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
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this._dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dateTimePicker.Location = new System.Drawing.Point(12, 24);
            this._dateTimePicker.Name = "_dateTimePicker";
            this._dateTimePicker.Size = new System.Drawing.Size(200, 23);
            this._dateTimePicker.TabIndex = 0;
            // 
            // _buttonSubmit
            // 
            this._buttonSubmit.Location = new System.Drawing.Point(218, 24);
            this._buttonSubmit.Name = "_buttonSubmit";
            this._buttonSubmit.Size = new System.Drawing.Size(134, 25);
            this._buttonSubmit.TabIndex = 1;
            this._buttonSubmit.Text = "Atualizar";
            this._buttonSubmit.UseVisualStyleBackColor = true;
            this._buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // FormUpdateAttendace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 66);
            this.Controls.Add(this._buttonSubmit);
            this.Controls.Add(this._dateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateAttendace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUpdateAttendace";
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker _dateTimePicker;
        private Button _buttonSubmit;
    }
}