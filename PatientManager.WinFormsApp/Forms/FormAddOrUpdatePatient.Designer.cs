namespace PatientManager.WinFormsApp.Forms
{
    partial class FormAddOrUpdatePatient
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
            this._panelMain = new System.Windows.Forms.Panel();
            this._buttonChangeMode = new System.Windows.Forms.Button();
            this._textBoxRG = new System.Windows.Forms.MaskedTextBox();
            this._textBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this._buttonEmptyPhoto = new System.Windows.Forms.Button();
            this._buttonBrowserPhoto = new System.Windows.Forms.Button();
            this._textBoxPhoto = new System.Windows.Forms.TextBox();
            this._labelPhoto = new System.Windows.Forms.Label();
            this._buttonSave = new System.Windows.Forms.Button();
            this._textBoxHealthInsurance = new System.Windows.Forms.TextBox();
            this._labelHealthInsurance = new System.Windows.Forms.Label();
            this._textBoxMedicalRecordNumber = new System.Windows.Forms.TextBox();
            this._labelMedicalRecordNumber = new System.Windows.Forms.Label();
            this._labelRG = new System.Windows.Forms.Label();
            this._labelCPF = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._labelName = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._panelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelMain
            // 
            this._panelMain.Controls.Add(this._buttonChangeMode);
            this._panelMain.Controls.Add(this._textBoxRG);
            this._panelMain.Controls.Add(this._textBoxCPF);
            this._panelMain.Controls.Add(this._buttonEmptyPhoto);
            this._panelMain.Controls.Add(this._buttonBrowserPhoto);
            this._panelMain.Controls.Add(this._textBoxPhoto);
            this._panelMain.Controls.Add(this._labelPhoto);
            this._panelMain.Controls.Add(this._buttonSave);
            this._panelMain.Controls.Add(this._textBoxHealthInsurance);
            this._panelMain.Controls.Add(this._labelHealthInsurance);
            this._panelMain.Controls.Add(this._textBoxMedicalRecordNumber);
            this._panelMain.Controls.Add(this._labelMedicalRecordNumber);
            this._panelMain.Controls.Add(this._labelRG);
            this._panelMain.Controls.Add(this._labelCPF);
            this._panelMain.Controls.Add(this._textBoxName);
            this._panelMain.Controls.Add(this._labelName);
            this._panelMain.Controls.Add(this.panelLeft);
            this._panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelMain.Location = new System.Drawing.Point(0, 0);
            this._panelMain.Name = "_panelMain";
            this._panelMain.Size = new System.Drawing.Size(765, 450);
            this._panelMain.TabIndex = 0;
            // 
            // _buttonChangeMode
            // 
            this._buttonChangeMode.Location = new System.Drawing.Point(631, 338);
            this._buttonChangeMode.Name = "_buttonChangeMode";
            this._buttonChangeMode.Size = new System.Drawing.Size(92, 23);
            this._buttonChangeMode.TabIndex = 14;
            this._buttonChangeMode.Text = "Modo Câmera";
            this._buttonChangeMode.UseVisualStyleBackColor = true;
            this._buttonChangeMode.Click += new System.EventHandler(this.ButtonChangeImageMode_Click);
            // 
            // _textBoxRG
            // 
            this._textBoxRG.Location = new System.Drawing.Point(318, 168);
            this._textBoxRG.Name = "_textBoxRG";
            this._textBoxRG.Size = new System.Drawing.Size(404, 23);
            this._textBoxRG.TabIndex = 6;
            // 
            // _textBoxCPF
            // 
            this._textBoxCPF.Location = new System.Drawing.Point(317, 111);
            this._textBoxCPF.Mask = "000\\.000\\.000-00";
            this._textBoxCPF.Name = "_textBoxCPF";
            this._textBoxCPF.Size = new System.Drawing.Size(405, 23);
            this._textBoxCPF.TabIndex = 5;
            this._textBoxCPF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBoxCPF_MouseDown);
            // 
            // _buttonEmptyPhoto
            // 
            this._buttonEmptyPhoto.Enabled = false;
            this._buttonEmptyPhoto.Location = new System.Drawing.Point(560, 338);
            this._buttonEmptyPhoto.Name = "_buttonEmptyPhoto";
            this._buttonEmptyPhoto.Size = new System.Drawing.Size(65, 23);
            this._buttonEmptyPhoto.TabIndex = 12;
            this._buttonEmptyPhoto.Text = "Limpar";
            this._buttonEmptyPhoto.UseVisualStyleBackColor = true;
            this._buttonEmptyPhoto.Click += new System.EventHandler(this.ButtonEmptyPhoto_Click);
            // 
            // _buttonBrowserPhoto
            // 
            this._buttonBrowserPhoto.Location = new System.Drawing.Point(489, 337);
            this._buttonBrowserPhoto.Name = "_buttonBrowserPhoto";
            this._buttonBrowserPhoto.Size = new System.Drawing.Size(65, 23);
            this._buttonBrowserPhoto.TabIndex = 11;
            this._buttonBrowserPhoto.Text = "Procurar";
            this._buttonBrowserPhoto.UseVisualStyleBackColor = true;
            this._buttonBrowserPhoto.Click += new System.EventHandler(this.ButtonBrowserPhoto_Click);
            // 
            // _textBoxPhoto
            // 
            this._textBoxPhoto.Enabled = false;
            this._textBoxPhoto.Location = new System.Drawing.Point(318, 338);
            this._textBoxPhoto.Name = "_textBoxPhoto";
            this._textBoxPhoto.Size = new System.Drawing.Size(165, 23);
            this._textBoxPhoto.TabIndex = 13;
            // 
            // _labelPhoto
            // 
            this._labelPhoto.AutoSize = true;
            this._labelPhoto.Location = new System.Drawing.Point(318, 320);
            this._labelPhoto.Name = "_labelPhoto";
            this._labelPhoto.Size = new System.Drawing.Size(51, 15);
            this._labelPhoto.TabIndex = 12;
            this._labelPhoto.Text = "Imagem";
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(318, 403);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(405, 35);
            this._buttonSave.TabIndex = 13;
            this._buttonSave.Text = "Salvar";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // _textBoxHealthInsurance
            // 
            this._textBoxHealthInsurance.Location = new System.Drawing.Point(318, 281);
            this._textBoxHealthInsurance.Name = "_textBoxHealthInsurance";
            this._textBoxHealthInsurance.Size = new System.Drawing.Size(405, 23);
            this._textBoxHealthInsurance.TabIndex = 10;
            // 
            // _labelHealthInsurance
            // 
            this._labelHealthInsurance.AutoSize = true;
            this._labelHealthInsurance.Location = new System.Drawing.Point(318, 263);
            this._labelHealthInsurance.Name = "_labelHealthInsurance";
            this._labelHealthInsurance.Size = new System.Drawing.Size(58, 15);
            this._labelHealthInsurance.TabIndex = 9;
            this._labelHealthInsurance.Text = "Convênio";
            // 
            // _textBoxMedicalRecordNumber
            // 
            this._textBoxMedicalRecordNumber.Location = new System.Drawing.Point(318, 226);
            this._textBoxMedicalRecordNumber.Name = "_textBoxMedicalRecordNumber";
            this._textBoxMedicalRecordNumber.Size = new System.Drawing.Size(405, 23);
            this._textBoxMedicalRecordNumber.TabIndex = 8;
            // 
            // _labelMedicalRecordNumber
            // 
            this._labelMedicalRecordNumber.AutoSize = true;
            this._labelMedicalRecordNumber.Location = new System.Drawing.Point(318, 208);
            this._labelMedicalRecordNumber.Name = "_labelMedicalRecordNumber";
            this._labelMedicalRecordNumber.Size = new System.Drawing.Size(127, 15);
            this._labelMedicalRecordNumber.TabIndex = 7;
            this._labelMedicalRecordNumber.Text = "Número do Prontuário";
            // 
            // _labelRG
            // 
            this._labelRG.AutoSize = true;
            this._labelRG.Location = new System.Drawing.Point(318, 150);
            this._labelRG.Name = "_labelRG";
            this._labelRG.Size = new System.Drawing.Size(22, 15);
            this._labelRG.TabIndex = 5;
            this._labelRG.Text = "RG";
            // 
            // _labelCPF
            // 
            this._labelCPF.AutoSize = true;
            this._labelCPF.Location = new System.Drawing.Point(318, 93);
            this._labelCPF.Name = "_labelCPF";
            this._labelCPF.Size = new System.Drawing.Size(28, 15);
            this._labelCPF.TabIndex = 3;
            this._labelCPF.Text = "CPF";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(318, 55);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(405, 23);
            this._textBoxName.TabIndex = 2;
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(318, 37);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(96, 15);
            this._labelName.TabIndex = 1;
            this._labelName.Text = "Nome Completo";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this._pictureBox);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(298, 450);
            this.panelLeft.TabIndex = 0;
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(3, 3);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(292, 235);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "Image Files(*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;.bmp;";
            this._openFileDialog.Title = "Procurar Imagens";
            // 
            // FormAddOrUpdatePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this._panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAddOrUpdatePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Paciente";
            this.Load += new System.EventHandler(this.FormAddOrUpdatePatient_Load);
            this._panelMain.ResumeLayout(false);
            this._panelMain.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel _panelMain;
        private Label _labelRG;
        private Label _labelCPF;
        private TextBox _textBoxName;
        private Label _labelName;
        private Panel panelLeft;
        private PictureBox _pictureBox;
        private Button _buttonBrowserPhoto;
        private TextBox _textBoxPhoto;
        private Label _labelPhoto;
        private Button _buttonSave;
        private TextBox _textBoxHealthInsurance;
        private Label _labelHealthInsurance;
        private TextBox _textBoxMedicalRecordNumber;
        private Label _labelMedicalRecordNumber;
        private OpenFileDialog _openFileDialog;
        private Button _buttonEmptyPhoto;
        private MaskedTextBox _textBoxCPF;
        private MaskedTextBox _textBoxRG;
        private Button _buttonChangeMode;
    }
}