namespace ObrLab1
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
            this.components = new System.ComponentModel.Container();
            this.buDownload = new System.Windows.Forms.Button();
            this.panImg = new System.Windows.Forms.Panel();
            this.buCalc = new System.Windows.Forms.Button();
            this.panCalc = new System.Windows.Forms.Panel();
            this.buSave = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.tbPow = new System.Windows.Forms.TextBox();
            this.zedGraphGray = new ZedGraph.ZedGraphControl();
            this.zedGraphCalc = new ZedGraph.ZedGraphControl();
            this.numBottom = new System.Windows.Forms.NumericUpDown();
            this.numTop = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.laK = new System.Windows.Forms.Label();
            this.laK1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
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
            this.panImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panImg.Location = new System.Drawing.Point(95, 13);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(159, 161);
            this.panImg.TabIndex = 1;
            // 
            // buCalc
            // 
            this.buCalc.Enabled = false;
            this.buCalc.Location = new System.Drawing.Point(260, 12);
            this.buCalc.Name = "buCalc";
            this.buCalc.Size = new System.Drawing.Size(75, 23);
            this.buCalc.TabIndex = 2;
            this.buCalc.Text = "Рассчитать";
            this.buCalc.UseVisualStyleBackColor = true;
            this.buCalc.Click += new System.EventHandler(this.buCalc_Click);
            // 
            // panCalc
            // 
            this.panCalc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panCalc.Location = new System.Drawing.Point(388, 13);
            this.panCalc.Name = "panCalc";
            this.panCalc.Size = new System.Drawing.Size(167, 161);
            this.panCalc.TabIndex = 2;
            // 
            // buSave
            // 
            this.buSave.Enabled = false;
            this.buSave.Location = new System.Drawing.Point(561, 13);
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(75, 23);
            this.buSave.TabIndex = 3;
            this.buSave.Text = "Сохранить";
            this.buSave.UseVisualStyleBackColor = true;
            this.buSave.Click += new System.EventHandler(this.buSave_Click);
            // 
            // cmbType
            // 
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Логарифмическое",
            "Степенное",
            "Нормализация",
            "Эквализация"});
            this.cmbType.Location = new System.Drawing.Point(261, 42);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 4;
            // 
            // tbPow
            // 
            this.tbPow.Enabled = false;
            this.tbPow.Location = new System.Drawing.Point(261, 85);
            this.tbPow.Name = "tbPow";
            this.tbPow.Size = new System.Drawing.Size(100, 20);
            this.tbPow.TabIndex = 5;
            this.tbPow.Text = "1,5";
            // 
            // zedGraphGray
            // 
            this.zedGraphGray.Location = new System.Drawing.Point(3, 179);
            this.zedGraphGray.Name = "zedGraphGray";
            this.zedGraphGray.ScrollGrace = 0D;
            this.zedGraphGray.ScrollMaxX = 0D;
            this.zedGraphGray.ScrollMaxY = 0D;
            this.zedGraphGray.ScrollMaxY2 = 0D;
            this.zedGraphGray.ScrollMinX = 0D;
            this.zedGraphGray.ScrollMinY = 0D;
            this.zedGraphGray.ScrollMinY2 = 0D;
            this.zedGraphGray.Size = new System.Drawing.Size(379, 338);
            this.zedGraphGray.TabIndex = 6;
            this.zedGraphGray.Tag = "0";
            this.zedGraphGray.UseExtendedPrintDialog = true;
            // 
            // zedGraphCalc
            // 
            this.zedGraphCalc.Location = new System.Drawing.Point(388, 179);
            this.zedGraphCalc.Name = "zedGraphCalc";
            this.zedGraphCalc.ScrollGrace = 0D;
            this.zedGraphCalc.ScrollMaxX = 0D;
            this.zedGraphCalc.ScrollMaxY = 0D;
            this.zedGraphCalc.ScrollMaxY2 = 0D;
            this.zedGraphCalc.ScrollMinX = 0D;
            this.zedGraphCalc.ScrollMinY = 0D;
            this.zedGraphCalc.ScrollMinY2 = 0D;
            this.zedGraphCalc.Size = new System.Drawing.Size(400, 338);
            this.zedGraphCalc.TabIndex = 7;
            this.zedGraphCalc.Tag = "1";
            this.zedGraphCalc.UseExtendedPrintDialog = true;
            // 
            // numBottom
            // 
            this.numBottom.Enabled = false;
            this.numBottom.Location = new System.Drawing.Point(261, 127);
            this.numBottom.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.numBottom.Name = "numBottom";
            this.numBottom.Size = new System.Drawing.Size(120, 20);
            this.numBottom.TabIndex = 8;
            // 
            // numTop
            // 
            this.numTop.Enabled = false;
            this.numTop.Location = new System.Drawing.Point(260, 153);
            this.numTop.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTop.Name = "numTop";
            this.numTop.Size = new System.Drawing.Size(120, 20);
            this.numTop.TabIndex = 9;
            this.numTop.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Для нормализации:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Для степенного:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Контрастность:";
            // 
            // laK
            // 
            this.laK.AutoSize = true;
            this.laK.Location = new System.Drawing.Point(2, 55);
            this.laK.Name = "laK";
            this.laK.Size = new System.Drawing.Size(0, 13);
            this.laK.TabIndex = 13;
            // 
            // laK1
            // 
            this.laK1.AutoSize = true;
            this.laK1.Location = new System.Drawing.Point(560, 55);
            this.laK1.Name = "laK1";
            this.laK1.Size = new System.Drawing.Size(0, 13);
            this.laK1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Контрастность:";
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.laK1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.laK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTop);
            this.Controls.Add(this.numBottom);
            this.Controls.Add(this.zedGraphCalc);
            this.Controls.Add(this.zedGraphGray);
            this.Controls.Add(this.tbPow);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.buSave);
            this.Controls.Add(this.panCalc);
            this.Controls.Add(this.buCalc);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "ObrLab1";
            ((System.ComponentModel.ISupportInitialize)(this.numBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buCalc;
        private System.Windows.Forms.Panel panCalc;
        private System.Windows.Forms.Button buSave;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox tbPow;
        private ZedGraph.ZedGraphControl zedGraphGray;
        private ZedGraph.ZedGraphControl zedGraphCalc;
        private System.Windows.Forms.NumericUpDown numBottom;
        private System.Windows.Forms.NumericUpDown numTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label laK;
        private System.Windows.Forms.Label laK1;
        private System.Windows.Forms.Label label5;
    }
}

