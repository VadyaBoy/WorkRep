namespace Tech6
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
            this.buSave = new System.Windows.Forms.Button();
            this.laReadTime = new System.Windows.Forms.Label();
            this.laWriteTime = new System.Windows.Forms.Label();
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
            this.panImg.Location = new System.Drawing.Point(95, 13);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(200, 176);
            this.panImg.TabIndex = 1;
            // 
            // buSave
            // 
            this.buSave.Enabled = false;
            this.buSave.Location = new System.Drawing.Point(302, 13);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(75, 23);
            this.buSave.TabIndex = 2;
            this.buSave.Text = "Сохранить";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.buSave_Click);
            // 
            // laReadTime
            // 
            this.laReadTime.AutoSize = true;
            this.laReadTime.Location = new System.Drawing.Point(13, 43);
            this.laReadTime.Name = "laReadTime";
            this.laReadTime.Size = new System.Drawing.Size(64, 13);
            this.laReadTime.TabIndex = 3;
            this.laReadTime.Text = "laReadTime";
            // 
            // laWriteTime
            // 
            this.laWriteTime.AutoSize = true;
            this.laWriteTime.Location = new System.Drawing.Point(301, 43);
            this.laWriteTime.Name = "laWriteTime";
            this.laWriteTime.Size = new System.Drawing.Size(63, 13);
            this.laWriteTime.TabIndex = 4;
            this.laWriteTime.Text = "laWriteTime";
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.laWriteTime);
            this.Controls.Add(this.laReadTime);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "Tech6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.Label laReadTime;
        private System.Windows.Forms.Label laWriteTime;
    }
}

