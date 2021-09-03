namespace Obr4
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
            this.panImg1 = new System.Windows.Forms.Panel();
            this.buFunc = new System.Windows.Forms.Button();
            this.buSave = new System.Windows.Forms.Button();
            this.panImg2 = new System.Windows.Forms.Panel();
            this.panImg3 = new System.Windows.Forms.Panel();
            this.panImg4 = new System.Windows.Forms.Panel();
            this.panImg2_1 = new System.Windows.Forms.Panel();
            this.panImg2_2 = new System.Windows.Forms.Panel();
            this.panImg5 = new System.Windows.Forms.Panel();
            this.panImg5_1 = new System.Windows.Forms.Panel();
            this.panImg5_2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panImg1
            // 
            this.panImg1.Location = new System.Drawing.Point(126, 13);
            this.panImg1.Name = "panImg1";
            this.panImg1.Size = new System.Drawing.Size(143, 144);
            this.panImg1.TabIndex = 0;
            // 
            // buFunc
            // 
            this.buFunc.Location = new System.Drawing.Point(13, 13);
            this.buFunc.Name = "buFunc";
            this.buFunc.Size = new System.Drawing.Size(107, 80);
            this.buFunc.TabIndex = 1;
            this.buFunc.Text = "Формирование изображения";
            this.buFunc.UseVisualStyleBackColor = true;
            this.buFunc.Click += new System.EventHandler(this.BuFunc_Click);
            // 
            // buSave
            // 
            this.buSave.Enabled = false;
            this.buSave.Location = new System.Drawing.Point(13, 99);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(107, 58);
            this.buSave.TabIndex = 2;
            this.buSave.Text = "Сохранить изображения";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.BuSave_Click);
            // 
            // panImg2
            // 
            this.panImg2.Location = new System.Drawing.Point(275, 13);
            this.panImg2.Name = "panImg2";
            this.panImg2.Size = new System.Drawing.Size(143, 144);
            this.panImg2.TabIndex = 1;
            // 
            // panImg3
            // 
            this.panImg3.Location = new System.Drawing.Point(126, 163);
            this.panImg3.Name = "panImg3";
            this.panImg3.Size = new System.Drawing.Size(200, 169);
            this.panImg3.TabIndex = 2;
            // 
            // panImg4
            // 
            this.panImg4.Location = new System.Drawing.Point(332, 163);
            this.panImg4.Name = "panImg4";
            this.panImg4.Size = new System.Drawing.Size(200, 169);
            this.panImg4.TabIndex = 3;
            // 
            // panImg2_1
            // 
            this.panImg2_1.Location = new System.Drawing.Point(424, 13);
            this.panImg2_1.Name = "panImg2_1";
            this.panImg2_1.Size = new System.Drawing.Size(143, 144);
            this.panImg2_1.TabIndex = 2;
            // 
            // panImg2_2
            // 
            this.panImg2_2.Location = new System.Drawing.Point(573, 12);
            this.panImg2_2.Name = "panImg2_2";
            this.panImg2_2.Size = new System.Drawing.Size(143, 144);
            this.panImg2_2.TabIndex = 2;
            // 
            // panImg5
            // 
            this.panImg5.Location = new System.Drawing.Point(126, 338);
            this.panImg5.Name = "panImg5";
            this.panImg5.Size = new System.Drawing.Size(200, 169);
            this.panImg5.TabIndex = 4;
            // 
            // panImg5_1
            // 
            this.panImg5_1.Location = new System.Drawing.Point(332, 338);
            this.panImg5_1.Name = "panImg5_1";
            this.panImg5_1.Size = new System.Drawing.Size(200, 169);
            this.panImg5_1.TabIndex = 5;
            // 
            // panImg5_2
            // 
            this.panImg5_2.Location = new System.Drawing.Point(538, 338);
            this.panImg5_2.Name = "panImg5_2";
            this.panImg5_2.Size = new System.Drawing.Size(200, 169);
            this.panImg5_2.TabIndex = 5;
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.panImg5_2);
            this.Controls.Add(this.panImg5_1);
            this.Controls.Add(this.panImg5);
            this.Controls.Add(this.panImg2_2);
            this.Controls.Add(this.panImg2_1);
            this.Controls.Add(this.panImg4);
            this.Controls.Add(this.panImg3);
            this.Controls.Add(this.panImg2);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.buFunc);
            this.Controls.Add(this.panImg1);
            this.Name = "fm";
            this.Text = "Obr4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panImg1;
        private System.Windows.Forms.Button buFunc;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.Panel panImg2;
        private System.Windows.Forms.Panel panImg3;
        private System.Windows.Forms.Panel panImg4;
        private System.Windows.Forms.Panel panImg2_1;
        private System.Windows.Forms.Panel panImg2_2;
        private System.Windows.Forms.Panel panImg5;
        private System.Windows.Forms.Panel panImg5_1;
        private System.Windows.Forms.Panel panImg5_2;
    }
}

