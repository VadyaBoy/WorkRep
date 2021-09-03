namespace LabObr2
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
            this.buCalc = new System.Windows.Forms.Button();
            this.panCalc = new System.Windows.Forms.Panel();
            this.buSave = new System.Windows.Forms.Button();
            this.numBorder = new System.Windows.Forms.NumericUpDown();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.laPSNR = new System.Windows.Forms.Label();
            this.panPSNR = new System.Windows.Forms.Panel();
            this.buPSNR = new System.Windows.Forms.Button();
            this.cmbLin = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBorder)).BeginInit();
            this.SuspendLayout();
            // 
            // buDownload
            // 
            this.buDownload.Location = new System.Drawing.Point(13, 13);
            this.buDownload.Name = "buDownload";
            this.buDownload.Size = new System.Drawing.Size(113, 38);
            this.buDownload.TabIndex = 0;
            this.buDownload.Text = "Загрузить";
            this.buDownload.UseVisualStyleBackColor = true;
            this.buDownload.Click += new System.EventHandler(this.buDownload_Click);
            // 
            // panImg
            // 
            this.panImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImg.Location = new System.Drawing.Point(133, 13);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(200, 167);
            this.panImg.TabIndex = 1;
            // 
            // buCalc
            // 
            this.buCalc.Enabled = false;
            this.buCalc.Location = new System.Drawing.Point(339, 13);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(113, 38);
            this.buCalc.TabIndex = 2;
            this.buCalc.Text = "Расчитать";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.buCalc_Click);
            // 
            // panCalc
            // 
            this.panCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panCalc.Location = new System.Drawing.Point(458, 13);
            this.panCalc.Name = "panCalc";
            this.panCalc.Size = new System.Drawing.Size(330, 311);
            this.panCalc.TabIndex = 2;
            // 
            // buSave
            // 
            this.buSave.Enabled = false;
            this.buSave.Location = new System.Drawing.Point(563, 330);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(113, 38);
            this.buSave.TabIndex = 3;
            this.buSave.Text = "Сохранить";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.buSave_Click);
            // 
            // numBorder
            // 
            this.numBorder.Enabled = false;
            this.numBorder.Location = new System.Drawing.Point(339, 98);
            this.numBorder.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numBorder.Name = "numBorder";
            this.numBorder.Size = new System.Drawing.Size(120, 20);
            this.numBorder.TabIndex = 7;
            this.numBorder.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Медианный фильтр",
            "Повышение резкости",
            "Гауссов фильтр",
            "Линейный фильтр"});
            this.cmbType.Location = new System.Drawing.Point(340, 58);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(112, 21);
            this.cmbType.TabIndex = 8;
            // 
            // laPSNR
            // 
            this.laPSNR.AutoSize = true;
            this.laPSNR.Location = new System.Drawing.Point(130, 356);
            this.laPSNR.Name = "laPSNR";
            this.laPSNR.Size = new System.Drawing.Size(40, 13);
            this.laPSNR.TabIndex = 9;
            this.laPSNR.Text = "PSNR:";
            // 
            // panPSNR
            // 
            this.panPSNR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panPSNR.Location = new System.Drawing.Point(133, 186);
            this.panPSNR.Name = "panPSNR";
            this.panPSNR.Size = new System.Drawing.Size(200, 167);
            this.panPSNR.TabIndex = 2;
            // 
            // buPSNR
            // 
            this.buPSNR.Location = new System.Drawing.Point(12, 186);
            this.buPSNR.Name = "buPSNR";
            this.buPSNR.Size = new System.Drawing.Size(113, 38);
            this.buPSNR.TabIndex = 10;
            this.buPSNR.Text = "Загрузить";
            this.buPSNR.UseVisualStyleBackColor = true;
            this.buPSNR.Click += new System.EventHandler(this.buPSNR_Click);
            // 
            // cmbLin
            // 
            this.cmbLin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLin.Enabled = false;
            this.cmbLin.FormattingEnabled = true;
            this.cmbLin.Items.AddRange(new object[] {
            "3",
            "5"});
            this.cmbLin.Location = new System.Drawing.Point(340, 125);
            this.cmbLin.Name = "cmbLin";
            this.cmbLin.Size = new System.Drawing.Size(112, 21);
            this.cmbLin.TabIndex = 11;
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbLin);
            this.Controls.Add(this.buPSNR);
            this.Controls.Add(this.panPSNR);
            this.Controls.Add(this.laPSNR);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.numBorder);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.panCalc);
            this.Controls.Add(this.buCalc);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "LabObr2";
            ((System.ComponentModel.ISupportInitialize)(this.numBorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Panel panCalc;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.NumericUpDown numBorder;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label laPSNR;
        private System.Windows.Forms.Panel panPSNR;
        private System.Windows.Forms.Button buPSNR;
        private System.Windows.Forms.ComboBox cmbLin;
    }
}

