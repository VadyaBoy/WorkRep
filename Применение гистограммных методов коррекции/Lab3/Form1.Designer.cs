namespace Lab3
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
            this.buImg = new System.Windows.Forms.Button();
            this.panImg = new System.Windows.Forms.Panel();
            this.buCalc = new System.Windows.Forms.Button();
            this.panImgGray = new System.Windows.Forms.Panel();
            this.numBottom = new System.Windows.Forms.NumericUpDown();
            this.numTop = new System.Windows.Forms.NumericUpDown();
            this.panImgNorm = new System.Windows.Forms.Panel();
            this.panImgEq = new System.Windows.Forms.Panel();
            this.panImgLg = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
            this.SuspendLayout();
            // 
            // buImg
            // 
            this.buImg.Location = new System.Drawing.Point(32, 24);
            this.buImg.Name = "buImg";
            this.buImg.Size = new System.Drawing.Size(98, 49);
            this.buImg.TabIndex = 0;
            this.buImg.Text = "Загрузить изображение";
            this.buImg.UseVisualStyleBackColor = true;
            this.buImg.Click += new System.EventHandler(this.BuImg_Click);
            // 
            // panImg
            // 
            this.panImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImg.Location = new System.Drawing.Point(12, 171);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(118, 125);
            this.panImg.TabIndex = 1;
            // 
            // buCalc
            // 
            this.buCalc.Enabled = false;
            this.buCalc.Location = new System.Drawing.Point(32, 97);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(115, 50);
            this.buCalc.TabIndex = 2;
            this.buCalc.Text = "Рассчитать";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.BuCalc_Click);
            // 
            // panImgGray
            // 
            this.panImgGray.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImgGray.Location = new System.Drawing.Point(168, 171);
            this.panImgGray.Name = "panImgGray";
            this.panImgGray.Size = new System.Drawing.Size(127, 125);
            this.panImgGray.TabIndex = 2;
            // 
            // numBottom
            // 
            this.numBottom.Location = new System.Drawing.Point(271, 52);
            this.numBottom.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBottom.Name = "numBottom";
            this.numBottom.Size = new System.Drawing.Size(120, 20);
            this.numBottom.TabIndex = 3;
            // 
            // numTop
            // 
            this.numTop.Location = new System.Drawing.Point(397, 53);
            this.numTop.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTop.Name = "numTop";
            this.numTop.Size = new System.Drawing.Size(120, 20);
            this.numTop.TabIndex = 4;
            this.numTop.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // panImgNorm
            // 
            this.panImgNorm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImgNorm.Location = new System.Drawing.Point(332, 171);
            this.panImgNorm.Name = "panImgNorm";
            this.panImgNorm.Size = new System.Drawing.Size(131, 125);
            this.panImgNorm.TabIndex = 3;
            // 
            // panImgEq
            // 
            this.panImgEq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImgEq.Location = new System.Drawing.Point(480, 171);
            this.panImgEq.Name = "panImgEq";
            this.panImgEq.Size = new System.Drawing.Size(131, 125);
            this.panImgEq.TabIndex = 4;
            // 
            // panImgLg
            // 
            this.panImgLg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImgLg.Location = new System.Drawing.Point(633, 171);
            this.panImgLg.Name = "panImgLg";
            this.panImgLg.Size = new System.Drawing.Size(131, 125);
            this.panImgLg.TabIndex = 5;
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panImgLg);
            this.Controls.Add(this.panImgEq);
            this.Controls.Add(this.panImgNorm);
            this.Controls.Add(this.numTop);
            this.Controls.Add(this.numBottom);
            this.Controls.Add(this.panImgGray);
            this.Controls.Add(this.buCalc);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buImg);
            this.Name = "fm";
            this.Text = "Lab3";
            ((System.ComponentModel.ISupportInitialize)(this.numBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buImg;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Panel panImgGray;
        private System.Windows.Forms.NumericUpDown numBottom;
        private System.Windows.Forms.NumericUpDown numTop;
        private System.Windows.Forms.Panel panImgNorm;
        private System.Windows.Forms.Panel panImgEq;
        private System.Windows.Forms.Panel panImgLg;
    }
}

