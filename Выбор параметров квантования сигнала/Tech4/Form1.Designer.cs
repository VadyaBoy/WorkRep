namespace Tech4
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
            this.buCalc = new System.Windows.Forms.Button();
            this.buSave = new System.Windows.Forms.Button();
            this.panImg1 = new System.Windows.Forms.Panel();
            this.panImg2 = new System.Windows.Forms.Panel();
            this.cmbLvl = new System.Windows.Forms.ComboBox();
            this.tbFs = new System.Windows.Forms.TextBox();
            this.tbTop = new System.Windows.Forms.TextBox();
            this.tbBottom = new System.Windows.Forms.TextBox();
            this.laMSE = new System.Windows.Forms.Label();
            this.laSSIM = new System.Windows.Forms.Label();
            this.laPSNR = new System.Windows.Forms.Label();
            this.buCalc2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buCalc
            // 
            this.buCalc.Location = new System.Drawing.Point(13, 13);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(83, 31);
            this.buCalc.TabIndex = 0;
            this.buCalc.Text = "Рассчет";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.BuCalc_Click);
            // 
            // buSave
            // 
            this.buSave.Enabled = false;
            this.buSave.Location = new System.Drawing.Point(13, 50);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(83, 31);
            this.buSave.TabIndex = 1;
            this.buSave.Text = "Сохранить";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.BuSave_Click);
            // 
            // panImg1
            // 
            this.panImg1.Location = new System.Drawing.Point(282, 12);
            this.panImg1.Name = "panImg1";
            this.panImg1.Size = new System.Drawing.Size(200, 191);
            this.panImg1.TabIndex = 2;
            // 
            // panImg2
            // 
            this.panImg2.Location = new System.Drawing.Point(588, 13);
            this.panImg2.Name = "panImg2";
            this.panImg2.Size = new System.Drawing.Size(200, 191);
            this.panImg2.TabIndex = 3;
            // 
            // cmbLvl
            // 
            this.cmbLvl.FormattingEnabled = true;
            this.cmbLvl.Items.AddRange(new object[] {
            "2",
            "8",
            "32",
            "64",
            "128",
            "256"});
            this.cmbLvl.Location = new System.Drawing.Point(13, 88);
            this.cmbLvl.Name = "cmbLvl";
            this.cmbLvl.Size = new System.Drawing.Size(121, 21);
            this.cmbLvl.TabIndex = 4;
            // 
            // tbFs
            // 
            this.tbFs.Location = new System.Drawing.Point(12, 207);
            this.tbFs.Name = "tbFs";
            this.tbFs.Size = new System.Drawing.Size(100, 20);
            this.tbFs.TabIndex = 6;
            this.tbFs.Text = "600";
            // 
            // tbTop
            // 
            this.tbTop.Location = new System.Drawing.Point(118, 115);
            this.tbTop.Name = "tbTop";
            this.tbTop.Size = new System.Drawing.Size(100, 20);
            this.tbTop.TabIndex = 7;
            this.tbTop.Text = "1";
            // 
            // tbBottom
            // 
            this.tbBottom.Location = new System.Drawing.Point(12, 115);
            this.tbBottom.Name = "tbBottom";
            this.tbBottom.Size = new System.Drawing.Size(100, 20);
            this.tbBottom.TabIndex = 8;
            this.tbBottom.Text = "0";
            // 
            // laMSE
            // 
            this.laMSE.AutoSize = true;
            this.laMSE.Location = new System.Drawing.Point(282, 269);
            this.laMSE.Name = "laMSE";
            this.laMSE.Size = new System.Drawing.Size(33, 13);
            this.laMSE.TabIndex = 9;
            this.laMSE.Text = "MSE:";
            // 
            // laSSIM
            // 
            this.laSSIM.AutoSize = true;
            this.laSSIM.Location = new System.Drawing.Point(282, 295);
            this.laSSIM.Name = "laSSIM";
            this.laSSIM.Size = new System.Drawing.Size(36, 13);
            this.laSSIM.TabIndex = 10;
            this.laSSIM.Text = "SSIM:";
            // 
            // laPSNR
            // 
            this.laPSNR.AutoSize = true;
            this.laPSNR.Location = new System.Drawing.Point(282, 282);
            this.laPSNR.Name = "laPSNR";
            this.laPSNR.Size = new System.Drawing.Size(40, 13);
            this.laPSNR.TabIndex = 11;
            this.laPSNR.Text = "PSNR:";
            // 
            // buCalc2
            // 
            this.buCalc2.Enabled = false;
            this.buCalc2.Location = new System.Drawing.Point(103, 13);
            this.buCalc2.Name = "buCalc2";
            this.buCalc2.Size = new System.Drawing.Size(86, 43);
            this.buCalc2.TabIndex = 12;
            this.buCalc2.Text = "Нелиненые уровни";
            this.buCalc2.UseVisualStyleBackColor = true;
            this.buCalc2.Click += new System.EventHandler(this.BuCalc2_Click);
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buCalc2);
            this.Controls.Add(this.laPSNR);
            this.Controls.Add(this.laSSIM);
            this.Controls.Add(this.laMSE);
            this.Controls.Add(this.tbBottom);
            this.Controls.Add(this.tbTop);
            this.Controls.Add(this.tbFs);
            this.Controls.Add(this.cmbLvl);
            this.Controls.Add(this.panImg2);
            this.Controls.Add(this.panImg1);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.buCalc);
            this.Name = "fm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.Panel panImg1;
        private System.Windows.Forms.Panel panImg2;
        private System.Windows.Forms.ComboBox cmbLvl;
        private System.Windows.Forms.TextBox tbFs;
        private System.Windows.Forms.TextBox tbTop;
        private System.Windows.Forms.TextBox tbBottom;
        private System.Windows.Forms.Label laMSE;
        private System.Windows.Forms.Label laSSIM;
        private System.Windows.Forms.Label laPSNR;
        private System.Windows.Forms.Button buCalc2;
    }
}

