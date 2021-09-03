namespace LabTech4
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
            this.buCalc = new System.Windows.Forms.Button();
            this.panImg = new System.Windows.Forms.Panel();
            this.tbR = new System.Windows.Forms.TextBox();
            this.tbG = new System.Windows.Forms.TextBox();
            this.tbB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            // buCalc
            // 
            this.buCalc.Enabled = false;
            this.buCalc.Location = new System.Drawing.Point(13, 150);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(75, 23);
            this.buCalc.TabIndex = 1;
            this.buCalc.Text = "Расчитать";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.buCalc_Click);
            // 
            // panImg
            // 
            this.panImg.Location = new System.Drawing.Point(158, 13);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(200, 160);
            this.panImg.TabIndex = 2;
            // 
            // tbR
            // 
            this.tbR.Location = new System.Drawing.Point(158, 193);
            this.tbR.Name = "tbR";
            this.tbR.ReadOnly = true;
            this.tbR.Size = new System.Drawing.Size(100, 20);
            this.tbR.TabIndex = 3;
            // 
            // tbG
            // 
            this.tbG.Location = new System.Drawing.Point(158, 219);
            this.tbG.Name = "tbG";
            this.tbG.ReadOnly = true;
            this.tbG.Size = new System.Drawing.Size(100, 20);
            this.tbG.TabIndex = 4;
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(158, 245);
            this.tbB.Name = "tbB";
            this.tbB.ReadOnly = true;
            this.tbB.Size = new System.Drawing.Size(100, 20);
            this.tbB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "B";
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.tbG);
            this.Controls.Add(this.tbR);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buCalc);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "Среднее значение каналов цветов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.TextBox tbR;
        private System.Windows.Forms.TextBox tbG;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

