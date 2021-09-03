namespace Obr5
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
            this.panSpectr = new System.Windows.Forms.Panel();
            this.panRest = new System.Windows.Forms.Panel();
            this.panF = new System.Windows.Forms.Panel();
            this.buFilter = new System.Windows.Forms.Button();
            this.panFRest = new System.Windows.Forms.Panel();
            this.cmbF = new System.Windows.Forms.ComboBox();
            this.numBorder = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buSave1 = new System.Windows.Forms.Button();
            this.buSave2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBorder)).BeginInit();
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
            this.panImg.Location = new System.Drawing.Point(12, 42);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(200, 179);
            this.panImg.TabIndex = 1;
            // 
            // buCalc
            // 
            this.buCalc.Enabled = false;
            this.buCalc.Location = new System.Drawing.Point(218, 13);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(75, 23);
            this.buCalc.TabIndex = 2;
            this.buCalc.Text = "Рассчитать";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.BuCalc_Click);
            // 
            // panSpectr
            // 
            this.panSpectr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panSpectr.Location = new System.Drawing.Point(218, 42);
            this.panSpectr.Name = "panSpectr";
            this.panSpectr.Size = new System.Drawing.Size(200, 179);
            this.panSpectr.TabIndex = 2;
            // 
            // panRest
            // 
            this.panRest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panRest.Location = new System.Drawing.Point(218, 227);
            this.panRest.Name = "panRest";
            this.panRest.Size = new System.Drawing.Size(200, 179);
            this.panRest.TabIndex = 2;
            // 
            // panF
            // 
            this.panF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panF.Location = new System.Drawing.Point(424, 42);
            this.panF.Name = "panF";
            this.panF.Size = new System.Drawing.Size(200, 179);
            this.panF.TabIndex = 3;
            // 
            // buFilter
            // 
            this.buFilter.Enabled = false;
            this.buFilter.Location = new System.Drawing.Point(424, 13);
            this.buFilter.Name = "buFilter";
            this.buFilter.Size = new System.Drawing.Size(75, 23);
            this.buFilter.TabIndex = 4;
            this.buFilter.Text = "Фильтр";
            this.buFilter.UseVisualStyleBackColor = true;
            this.buFilter.Click += new System.EventHandler(this.BuFilter_Click);
            // 
            // panFRest
            // 
            this.panFRest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panFRest.Location = new System.Drawing.Point(424, 227);
            this.panFRest.Name = "panFRest";
            this.panFRest.Size = new System.Drawing.Size(200, 179);
            this.panFRest.TabIndex = 4;
            // 
            // cmbF
            // 
            this.cmbF.FormattingEnabled = true;
            this.cmbF.Items.AddRange(new object[] {
            "Идеальный низкочастотный",
            "Низкочастотный Гаусса",
            "Идельный высокочастотный",
            "Высокочастотный Гаусса"});
            this.cmbF.Location = new System.Drawing.Point(506, 13);
            this.cmbF.Name = "cmbF";
            this.cmbF.Size = new System.Drawing.Size(241, 21);
            this.cmbF.TabIndex = 5;
            // 
            // numBorder
            // 
            this.numBorder.Location = new System.Drawing.Point(627, 64);
            this.numBorder.Name = "numBorder";
            this.numBorder.Size = new System.Drawing.Size(120, 20);
            this.numBorder.TabIndex = 6;
            this.numBorder.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Срез:";
            // 
            // buSave1
            // 
            this.buSave1.Enabled = false;
            this.buSave1.Location = new System.Drawing.Point(218, 412);
            this.buSave1.Name = "buSave1";
            this.buSave1.Size = new System.Drawing.Size(200, 39);
            this.buSave1.TabIndex = 8;
            this.buSave1.Text = "Сохранить спектр и востановленное изображение";
            this.buSave1.UseVisualStyleBackColor = true;
            this.buSave1.Click += new System.EventHandler(this.BuSave1_Click);
            // 
            // buSave2
            // 
            this.buSave2.Enabled = false;
            this.buSave2.Location = new System.Drawing.Point(424, 412);
            this.buSave2.Name = "buSave2";
            this.buSave2.Size = new System.Drawing.Size(200, 39);
            this.buSave2.TabIndex = 9;
            this.buSave2.Text = "Сохранить фильтр спектра и изображения";
            this.buSave2.UseVisualStyleBackColor = true;
            this.buSave2.Click += new System.EventHandler(this.BuSave2_Click);
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 455);
            this.Controls.Add(this.buSave2);
            this.Controls.Add(this.buSave1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numBorder);
            this.Controls.Add(this.cmbF);
            this.Controls.Add(this.panFRest);
            this.Controls.Add(this.buFilter);
            this.Controls.Add(this.panF);
            this.Controls.Add(this.panRest);
            this.Controls.Add(this.panSpectr);
            this.Controls.Add(this.buCalc);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "Obr5";
            ((System.ComponentModel.ISupportInitialize)(this.numBorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Panel panSpectr;
        private System.Windows.Forms.Panel panRest;
        private System.Windows.Forms.Panel panF;
        private System.Windows.Forms.Button buFilter;
        private System.Windows.Forms.Panel panFRest;
        private System.Windows.Forms.ComboBox cmbF;
        private System.Windows.Forms.NumericUpDown numBorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buSave1;
        private System.Windows.Forms.Button buSave2;
    }
}

