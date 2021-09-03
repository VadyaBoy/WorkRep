namespace TechLab3
{
    partial class fm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buDownload = new System.Windows.Forms.Button();
            this.panImg = new System.Windows.Forms.Panel();
            this.cmbLvl = new System.Windows.Forms.ComboBox();
            this.laPSNR = new System.Windows.Forms.Label();
            this.laSSIM = new System.Windows.Forms.Label();
            this.laMSE = new System.Windows.Forms.Label();
            this.buQuant = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panResult = new System.Windows.Forms.Panel();
            this.buSave = new System.Windows.Forms.Button();
            this.buDizering = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.tbMSE = new System.Windows.Forms.TextBox();
            this.tbPSNR = new System.Windows.Forms.TextBox();
            this.tbSSIM = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buDownload
            // 
            this.buDownload.Location = new System.Drawing.Point(13, 13);
            this.buDownload.Name = "buDownload";
            this.buDownload.Size = new System.Drawing.Size(75, 23);
            this.buDownload.TabIndex = 0;
            this.buDownload.Text = "Загрузить";
            this.buDownload.UseVisualStyleBackColor = true;
            this.buDownload.Click += new System.EventHandler(this.buDownload_Click);
            // 
            // panImg
            // 
            this.panImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImg.Location = new System.Drawing.Point(95, 13);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(200, 181);
            this.panImg.TabIndex = 1;
            // 
            // cmbLvl
            // 
            this.cmbLvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLvl.Enabled = false;
            this.cmbLvl.FormattingEnabled = true;
            this.cmbLvl.Items.AddRange(new object[] {
            "2",
            "4",
            "16",
            "64",
            "128"});
            this.cmbLvl.Location = new System.Drawing.Point(302, 57);
            this.cmbLvl.Name = "cmbLvl";
            this.cmbLvl.Size = new System.Drawing.Size(121, 21);
            this.cmbLvl.TabIndex = 2;
            // 
            // laPSNR
            // 
            this.laPSNR.AutoSize = true;
            this.laPSNR.Location = new System.Drawing.Point(255, 242);
            this.laPSNR.Name = "laPSNR";
            this.laPSNR.Size = new System.Drawing.Size(40, 13);
            this.laPSNR.TabIndex = 14;
            this.laPSNR.Text = "PSNR:";
            // 
            // laSSIM
            // 
            this.laSSIM.AutoSize = true;
            this.laSSIM.Location = new System.Drawing.Point(259, 268);
            this.laSSIM.Name = "laSSIM";
            this.laSSIM.Size = new System.Drawing.Size(36, 13);
            this.laSSIM.TabIndex = 13;
            this.laSSIM.Text = "SSIM:";
            // 
            // laMSE
            // 
            this.laMSE.AutoSize = true;
            this.laMSE.Location = new System.Drawing.Point(262, 216);
            this.laMSE.Name = "laMSE";
            this.laMSE.Size = new System.Drawing.Size(33, 13);
            this.laMSE.TabIndex = 12;
            this.laMSE.Text = "MSE:";
            // 
            // buQuant
            // 
            this.buQuant.Enabled = false;
            this.buQuant.Location = new System.Drawing.Point(301, 12);
            this.buQuant.Name = "buQuant";
            this.buQuant.Size = new System.Drawing.Size(111, 23);
            this.buQuant.TabIndex = 15;
            this.buQuant.Text = "Квантование";
            this.buQuant.UseVisualStyleBackColor = true;
            this.buQuant.Click += new System.EventHandler(this.buQuant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Уровни";
            // 
            // panResult
            // 
            this.panResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panResult.Location = new System.Drawing.Point(429, 13);
            this.panResult.Name = "panResult";
            this.panResult.Size = new System.Drawing.Size(359, 323);
            this.panResult.TabIndex = 2;
            // 
            // buSave
            // 
            this.buSave.Enabled = false;
            this.buSave.Location = new System.Drawing.Point(429, 342);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(111, 23);
            this.buSave.TabIndex = 17;
            this.buSave.Text = "Сохранение";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.buSave_Click);
            // 
            // buDizering
            // 
            this.buDizering.Enabled = false;
            this.buDizering.Location = new System.Drawing.Point(301, 105);
            this.buDizering.Name = "buDizering";
            this.buDizering.Size = new System.Drawing.Size(111, 23);
            this.buDizering.TabIndex = 18;
            this.buDizering.Text = "Дизеринг";
            this.buDizering.UseVisualStyleBackColor = true;
            this.buDizering.Click += new System.EventHandler(this.buDizering_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Тип";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Случайный",
            "Упорядоченный"});
            this.cmbType.Location = new System.Drawing.Point(302, 150);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 19;
            // 
            // tbMSE
            // 
            this.tbMSE.Location = new System.Drawing.Point(301, 216);
            this.tbMSE.Name = "tbMSE";
            this.tbMSE.ReadOnly = true;
            this.tbMSE.Size = new System.Drawing.Size(100, 20);
            this.tbMSE.TabIndex = 21;
            // 
            // tbPSNR
            // 
            this.tbPSNR.Location = new System.Drawing.Point(301, 242);
            this.tbPSNR.Name = "tbPSNR";
            this.tbPSNR.ReadOnly = true;
            this.tbPSNR.Size = new System.Drawing.Size(100, 20);
            this.tbPSNR.TabIndex = 22;
            // 
            // tbSSIM
            // 
            this.tbSSIM.Location = new System.Drawing.Point(301, 268);
            this.tbSSIM.Name = "tbSSIM";
            this.tbSSIM.ReadOnly = true;
            this.tbSSIM.Size = new System.Drawing.Size(100, 20);
            this.tbSSIM.TabIndex = 23;
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbSSIM);
            this.Controls.Add(this.tbPSNR);
            this.Controls.Add(this.tbMSE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.buDizering);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.panResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buQuant);
            this.Controls.Add(this.laPSNR);
            this.Controls.Add(this.laSSIM);
            this.Controls.Add(this.laMSE);
            this.Controls.Add(this.cmbLvl);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "TechLab3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.ComboBox cmbLvl;
        private System.Windows.Forms.Label laPSNR;
        private System.Windows.Forms.Label laSSIM;
        private System.Windows.Forms.Label laMSE;
        private System.Windows.Forms.Button buQuant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panResult;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.Button buDizering;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox tbMSE;
        private System.Windows.Forms.TextBox tbPSNR;
        private System.Windows.Forms.TextBox tbSSIM;
    }
}

