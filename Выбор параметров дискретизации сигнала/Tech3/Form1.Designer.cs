namespace Tech3
{
    partial class Form1
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
            this.tbFs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbFs = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panImg = new System.Windows.Forms.Panel();
            this.buCalc = new System.Windows.Forms.Button();
            this.buSave = new System.Windows.Forms.Button();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFs
            // 
            this.tbFs.Location = new System.Drawing.Point(12, 12);
            this.tbFs.Name = "tbFs";
            this.tbFs.Size = new System.Drawing.Size(100, 20);
            this.tbFs.TabIndex = 0;
            this.tbFs.Text = "512";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходная частота";
            // 
            // chbFs
            // 
            this.chbFs.AutoSize = true;
            this.chbFs.Location = new System.Drawing.Point(13, 67);
            this.chbFs.Name = "chbFs";
            this.chbFs.Size = new System.Drawing.Size(130, 17);
            this.chbFs.TabIndex = 3;
            this.chbFs.Text = "Сдвиг на 1/2 период";
            this.chbFs.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Размер изображения (частота дискретизации)";
            // 
            // panImg
            // 
            this.panImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panImg.Location = new System.Drawing.Point(376, 12);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(412, 426);
            this.panImg.TabIndex = 5;
            // 
            // buCalc
            // 
            this.buCalc.Location = new System.Drawing.Point(13, 114);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(99, 42);
            this.buCalc.TabIndex = 6;
            this.buCalc.Text = "Рассчитать";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.BuCalc_Click);
            // 
            // buSave
            // 
            this.buSave.Location = new System.Drawing.Point(12, 162);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(99, 42);
            this.buSave.TabIndex = 7;
            this.buSave.Text = "Сохранить";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.BuSave_Click);
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(12, 88);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(100, 20);
            this.tbSize.TabIndex = 8;
            this.tbSize.Text = "512";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.buCalc);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbFs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbFs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.TextBox tbSize;
    }
}

