namespace tech5
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
            this.panImgCalc = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAlg = new System.Windows.Forms.ComboBox();
            this.buSave = new System.Windows.Forms.Button();
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
            this.buDownload.Click += new System.EventHandler(this.BuDownload_Click);
            // 
            // panImg
            // 
            this.panImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImg.Location = new System.Drawing.Point(94, 12);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(237, 426);
            this.panImg.TabIndex = 1;
            // 
            // buCalc
            // 
            this.buCalc.Enabled = false;
            this.buCalc.Location = new System.Drawing.Point(337, 12);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(75, 23);
            this.buCalc.TabIndex = 2;
            this.buCalc.Text = "Рассчитать";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.BuCalc_Click);
            // 
            // panImgCalc
            // 
            this.panImgCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImgCalc.Location = new System.Drawing.Point(463, 12);
            this.panImgCalc.Name = "panImgCalc";
            this.panImgCalc.Size = new System.Drawing.Size(325, 426);
            this.panImgCalc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фильтр:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "RGGB",
            "BGGR",
            "GBRG",
            "GRBG"});
            this.cmbFilter.Location = new System.Drawing.Point(337, 59);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbFilter.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Алгоритм:";
            // 
            // cmbAlg
            // 
            this.cmbAlg.FormattingEnabled = true;
            this.cmbAlg.Items.AddRange(new object[] {
            "SuperPixel",
            "Bilinear Interpolation"});
            this.cmbAlg.Location = new System.Drawing.Point(337, 100);
            this.cmbAlg.Name = "cmbAlg";
            this.cmbAlg.Size = new System.Drawing.Size(121, 21);
            this.cmbAlg.TabIndex = 6;
            // 
            // buSave
            // 
            this.buSave.Location = new System.Drawing.Point(340, 128);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(75, 23);
            this.buSave.TabIndex = 7;
            this.buSave.Text = "Сохранить";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.BuSave_Click);
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.cmbAlg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panImgCalc);
            this.Controls.Add(this.buCalc);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "tech3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Panel panImgCalc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAlg;
        private System.Windows.Forms.Button buSave;
    }
}

