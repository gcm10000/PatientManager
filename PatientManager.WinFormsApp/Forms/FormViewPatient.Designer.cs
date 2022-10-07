namespace PatientManager.WinFormsApp.Forms
{
    partial class FormViewPatient
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._labelName = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._labelCPF = new System.Windows.Forms.Label();
            this._labelRG = new System.Windows.Forms.Label();
            this._textBoxRG = new System.Windows.Forms.TextBox();
            this._labelMedicalRecordNumber = new System.Windows.Forms.Label();
            this._textBoxMedicalRecordNumber = new System.Windows.Forms.TextBox();
            this._labelHealthInsurance = new System.Windows.Forms.Label();
            this._textBoxHealthInsurance = new System.Windows.Forms.TextBox();
            this._panelMain = new System.Windows.Forms.Panel();
            this._textBoxCPF = new System.Windows.Forms.MaskedTextBox();
            this._buttonSubmitPresent = new System.Windows.Forms.Button();
            this._buttonUpdateData = new System.Windows.Forms.Button();
            this._textBoxUpdatedDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxCreatedDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._buttonViewPresents = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this._panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this._pictureBox);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(298, 512);
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
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(318, 37);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(96, 15);
            this._labelName.TabIndex = 1;
            this._labelName.Text = "Nome Completo";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(318, 55);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.ReadOnly = true;
            this._textBoxName.Size = new System.Drawing.Size(405, 23);
            this._textBoxName.TabIndex = 2;
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
            // _labelRG
            // 
            this._labelRG.AutoSize = true;
            this._labelRG.Location = new System.Drawing.Point(318, 150);
            this._labelRG.Name = "_labelRG";
            this._labelRG.Size = new System.Drawing.Size(22, 15);
            this._labelRG.TabIndex = 5;
            this._labelRG.Text = "RG";
            // 
            // _textBoxRG
            // 
            this._textBoxRG.Location = new System.Drawing.Point(318, 168);
            this._textBoxRG.Name = "_textBoxRG";
            this._textBoxRG.ReadOnly = true;
            this._textBoxRG.Size = new System.Drawing.Size(405, 23);
            this._textBoxRG.TabIndex = 6;
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
            // _textBoxMedicalRecordNumber
            // 
            this._textBoxMedicalRecordNumber.Location = new System.Drawing.Point(318, 226);
            this._textBoxMedicalRecordNumber.Name = "_textBoxMedicalRecordNumber";
            this._textBoxMedicalRecordNumber.ReadOnly = true;
            this._textBoxMedicalRecordNumber.Size = new System.Drawing.Size(405, 23);
            this._textBoxMedicalRecordNumber.TabIndex = 8;
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
            // _textBoxHealthInsurance
            // 
            this._textBoxHealthInsurance.Location = new System.Drawing.Point(318, 281);
            this._textBoxHealthInsurance.Name = "_textBoxHealthInsurance";
            this._textBoxHealthInsurance.ReadOnly = true;
            this._textBoxHealthInsurance.Size = new System.Drawing.Size(405, 23);
            this._textBoxHealthInsurance.TabIndex = 10;
            // 
            // _panelMain
            // 
            this._panelMain.Controls.Add(this._textBoxCPF);
            this._panelMain.Controls.Add(this._buttonSubmitPresent);
            this._panelMain.Controls.Add(this._buttonUpdateData);
            this._panelMain.Controls.Add(this._textBoxUpdatedDate);
            this._panelMain.Controls.Add(this.label1);
            this._panelMain.Controls.Add(this._textBoxCreatedDate);
            this._panelMain.Controls.Add(this.label2);
            this._panelMain.Controls.Add(this._buttonViewPresents);
            this._panelMain.Controls.Add(this._textBoxHealthInsurance);
            this._panelMain.Controls.Add(this._labelHealthInsurance);
            this._panelMain.Controls.Add(this._textBoxMedicalRecordNumber);
            this._panelMain.Controls.Add(this._labelMedicalRecordNumber);
            this._panelMain.Controls.Add(this._textBoxRG);
            this._panelMain.Controls.Add(this._labelRG);
            this._panelMain.Controls.Add(this._labelCPF);
            this._panelMain.Controls.Add(this._textBoxName);
            this._panelMain.Controls.Add(this._labelName);
            this._panelMain.Controls.Add(this.panelLeft);
            this._panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelMain.Location = new System.Drawing.Point(0, 0);
            this._panelMain.Name = "_panelMain";
            this._panelMain.Size = new System.Drawing.Size(808, 512);
            this._panelMain.TabIndex = 1;
            // 
            // _textBoxCPF
            // 
            this._textBoxCPF.Location = new System.Drawing.Point(318, 111);
            this._textBoxCPF.Mask = "000\\.000\\.000-00";
            this._textBoxCPF.Name = "_textBoxCPF";
            this._textBoxCPF.ReadOnly = true;
            this._textBoxCPF.Size = new System.Drawing.Size(405, 23);
            this._textBoxCPF.TabIndex = 3;
            // 
            // _buttonSubmitPresent
            // 
            this._buttonSubmitPresent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._buttonSubmitPresent.Location = new System.Drawing.Point(592, 448);
            this._buttonSubmitPresent.Name = "_buttonSubmitPresent";
            this._buttonSubmitPresent.Size = new System.Drawing.Size(131, 35);
            this._buttonSubmitPresent.TabIndex = 18;
            this._buttonSubmitPresent.Text = "Marcar Presença";
            this._buttonSubmitPresent.UseVisualStyleBackColor = true;
            this._buttonSubmitPresent.Click += new System.EventHandler(this.ButtonSubmitPresent_Click);
            // 
            // _buttonUpdateData
            // 
            this._buttonUpdateData.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._buttonUpdateData.Location = new System.Drawing.Point(318, 448);
            this._buttonUpdateData.Name = "_buttonUpdateData";
            this._buttonUpdateData.Size = new System.Drawing.Size(131, 35);
            this._buttonUpdateData.TabIndex = 16;
            this._buttonUpdateData.Text = "Atualizar Dados";
            this._buttonUpdateData.UseVisualStyleBackColor = true;
            this._buttonUpdateData.Click += new System.EventHandler(this.ButtonUpdateData_Click);
            // 
            // _textBoxUpdatedDate
            // 
            this._textBoxUpdatedDate.Location = new System.Drawing.Point(318, 394);
            this._textBoxUpdatedDate.Name = "_textBoxUpdatedDate";
            this._textBoxUpdatedDate.ReadOnly = true;
            this._textBoxUpdatedDate.Size = new System.Drawing.Size(405, 23);
            this._textBoxUpdatedDate.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Data de Última Atualização";
            // 
            // _textBoxCreatedDate
            // 
            this._textBoxCreatedDate.Location = new System.Drawing.Point(318, 339);
            this._textBoxCreatedDate.Name = "_textBoxCreatedDate";
            this._textBoxCreatedDate.ReadOnly = true;
            this._textBoxCreatedDate.Size = new System.Drawing.Size(405, 23);
            this._textBoxCreatedDate.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Data de Criação";
            // 
            // _buttonViewPresents
            // 
            this._buttonViewPresents.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._buttonViewPresents.Location = new System.Drawing.Point(455, 448);
            this._buttonViewPresents.Name = "_buttonViewPresents";
            this._buttonViewPresents.Size = new System.Drawing.Size(131, 35);
            this._buttonViewPresents.TabIndex = 17;
            this._buttonViewPresents.Text = "Visualizar Presenças";
            this._buttonViewPresents.UseVisualStyleBackColor = true;
            this._buttonViewPresents.Click += new System.EventHandler(this.ButtonViewPresents_Click);
            // 
            // FormViewPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 512);
            this.Controls.Add(this._panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormViewPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Paciente";
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this._panelMain.ResumeLayout(false);
            this._panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelLeft;
        private PictureBox _pictureBox;
        private Label _labelName;
        private TextBox _textBoxName;
        private Label _labelCPF;
        private Label _labelRG;
        private TextBox _textBoxRG;
        private Label _labelMedicalRecordNumber;
        private TextBox _textBoxMedicalRecordNumber;
        private Label _labelHealthInsurance;
        private TextBox _textBoxHealthInsurance;
        private Panel _panelMain;
        private Button _buttonUpdateData;
        private TextBox _textBoxUpdatedDate;
        private Label label1;
        private TextBox _textBoxCreatedDate;
        private Label label2;
        private Button _buttonViewPresents;
        private Button _buttonSubmitPresent;
        private MaskedTextBox _textBoxCPF;
    }
}