namespace labForoCompare
{
    partial class MainForm
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
            this.imPanel1 = new System.Windows.Forms.Panel();
            this.buPict1 = new System.Windows.Forms.Button();
            this.buPict2 = new System.Windows.Forms.Button();
            this.imPanel2 = new System.Windows.Forms.Panel();
            this.buCompare = new System.Windows.Forms.Button();
            this.laMSE = new System.Windows.Forms.Label();
            this.laPSNR = new System.Windows.Forms.Label();
            this.laSSIM = new System.Windows.Forms.Label();
            this.buAllClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imPanel1
            // 
            this.imPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imPanel1.Location = new System.Drawing.Point(12, 12);
            this.imPanel1.Name = "imPanel1";
            this.imPanel1.Size = new System.Drawing.Size(200, 183);
            this.imPanel1.TabIndex = 0;
            // 
            // buPict1
            // 
            this.buPict1.Location = new System.Drawing.Point(12, 201);
            this.buPict1.Name = "buPict1";
            this.buPict1.Size = new System.Drawing.Size(200, 23);
            this.buPict1.TabIndex = 1;
            this.buPict1.Text = "Выбрать картинку №1";
            this.buPict1.UseVisualStyleBackColor = true;
            this.buPict1.Click += new System.EventHandler(this.buPict1_Click);
            // 
            // buPict2
            // 
            this.buPict2.Location = new System.Drawing.Point(378, 201);
            this.buPict2.Name = "buPict2";
            this.buPict2.Size = new System.Drawing.Size(200, 23);
            this.buPict2.TabIndex = 3;
            this.buPict2.Text = "Выбрать картинку №2";
            this.buPict2.UseVisualStyleBackColor = true;
            this.buPict2.Click += new System.EventHandler(this.buPict2_Click);
            // 
            // imPanel2
            // 
            this.imPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imPanel2.Location = new System.Drawing.Point(378, 12);
            this.imPanel2.Name = "imPanel2";
            this.imPanel2.Size = new System.Drawing.Size(200, 183);
            this.imPanel2.TabIndex = 2;
            // 
            // buCompare
            // 
            this.buCompare.Location = new System.Drawing.Point(218, 201);
            this.buCompare.Name = "buCompare";
            this.buCompare.Size = new System.Drawing.Size(154, 23);
            this.buCompare.TabIndex = 4;
            this.buCompare.Text = "Сравнить";
            this.buCompare.UseVisualStyleBackColor = true;
            this.buCompare.Click += new System.EventHandler(this.buCompare_Click);
            // 
            // laMSE
            // 
            this.laMSE.AutoSize = true;
            this.laMSE.Location = new System.Drawing.Point(9, 233);
            this.laMSE.Name = "laMSE";
            this.laMSE.Size = new System.Drawing.Size(38, 13);
            this.laMSE.TabIndex = 5;
            this.laMSE.Text = "laMSE";
            // 
            // laPSNR
            // 
            this.laPSNR.AutoSize = true;
            this.laPSNR.Location = new System.Drawing.Point(9, 256);
            this.laPSNR.Name = "laPSNR";
            this.laPSNR.Size = new System.Drawing.Size(45, 13);
            this.laPSNR.TabIndex = 6;
            this.laPSNR.Text = "laPSNR";
            // 
            // laSSIM
            // 
            this.laSSIM.AutoSize = true;
            this.laSSIM.Location = new System.Drawing.Point(9, 280);
            this.laSSIM.Name = "laSSIM";
            this.laSSIM.Size = new System.Drawing.Size(35, 13);
            this.laSSIM.TabIndex = 7;
            this.laSSIM.Text = "label3";
            // 
            // buAllClear
            // 
            this.buAllClear.Location = new System.Drawing.Point(218, 230);
            this.buAllClear.Name = "buAllClear";
            this.buAllClear.Size = new System.Drawing.Size(154, 23);
            this.buAllClear.TabIndex = 8;
            this.buAllClear.Text = "Очистить";
            this.buAllClear.UseVisualStyleBackColor = true;
            this.buAllClear.Click += new System.EventHandler(this.buAllClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 307);
            this.Controls.Add(this.buAllClear);
            this.Controls.Add(this.laSSIM);
            this.Controls.Add(this.laPSNR);
            this.Controls.Add(this.laMSE);
            this.Controls.Add(this.buCompare);
            this.Controls.Add(this.buPict2);
            this.Controls.Add(this.imPanel2);
            this.Controls.Add(this.buPict1);
            this.Controls.Add(this.imPanel1);
            this.MaximumSize = new System.Drawing.Size(603, 346);
            this.MinimumSize = new System.Drawing.Size(603, 346);
            this.Name = "MainForm";
            this.Text = "PhotoCompare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel imPanel1;
        private System.Windows.Forms.Button buPict1;
        private System.Windows.Forms.Button buPict2;
        private System.Windows.Forms.Panel imPanel2;
        private System.Windows.Forms.Button buCompare;
        private System.Windows.Forms.Label laMSE;
        private System.Windows.Forms.Label laPSNR;
        private System.Windows.Forms.Label laSSIM;
        private System.Windows.Forms.Button buAllClear;
    }
}

