namespace TechLab1
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
            this.buRotate = new System.Windows.Forms.Button();
            this.numAngle = new System.Windows.Forms.NumericUpDown();
            this.panRot = new System.Windows.Forms.Panel();
            this.buMTF = new System.Windows.Forms.Button();
            this.panMTF = new System.Windows.Forms.Panel();
            this.zedGraphMTF = new ZedGraph.ZedGraphControl();
            this.buOb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).BeginInit();
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
            this.panImg.Location = new System.Drawing.Point(13, 46);
            this.panImg.Name = "panImg";
            this.panImg.Size = new System.Drawing.Size(124, 117);
            this.panImg.TabIndex = 1;
            // 
            // buRotate
            // 
            this.buRotate.Enabled = false;
            this.buRotate.Location = new System.Drawing.Point(143, 13);
            this.buRotate.Name = "buRotate";
            this.buRotate.Size = new System.Drawing.Size(75, 23);
            this.buRotate.TabIndex = 2;
            this.buRotate.Text = "Поворот";
            this.buRotate.UseVisualStyleBackColor = true;
            this.buRotate.Click += new System.EventHandler(this.buRotate_Click);
            // 
            // numAngle
            // 
            this.numAngle.Enabled = false;
            this.numAngle.Location = new System.Drawing.Point(224, 13);
            this.numAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numAngle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAngle.Name = "numAngle";
            this.numAngle.Size = new System.Drawing.Size(120, 20);
            this.numAngle.TabIndex = 3;
            this.numAngle.Value = new decimal(new int[] {
            354,
            0,
            0,
            0});
            // 
            // panRot
            // 
            this.panRot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panRot.Location = new System.Drawing.Point(143, 46);
            this.panRot.Name = "panRot";
            this.panRot.Size = new System.Drawing.Size(124, 117);
            this.panRot.TabIndex = 2;
            // 
            // buMTF
            // 
            this.buMTF.Enabled = false;
            this.buMTF.Location = new System.Drawing.Point(350, 12);
            this.buMTF.Name = "buMTF";
            this.buMTF.Size = new System.Drawing.Size(121, 24);
            this.buMTF.TabIndex = 4;
            this.buMTF.Text = "График MTF";
            this.buMTF.UseVisualStyleBackColor = true;
            this.buMTF.Click += new System.EventHandler(this.buMTF_Click);
            // 
            // panMTF
            // 
            this.panMTF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panMTF.Location = new System.Drawing.Point(350, 46);
            this.panMTF.Name = "panMTF";
            this.panMTF.Size = new System.Drawing.Size(124, 117);
            this.panMTF.TabIndex = 2;
            // 
            // zedGraphMTF
            // 
            this.zedGraphMTF.Location = new System.Drawing.Point(13, 169);
            this.zedGraphMTF.Name = "zedGraphMTF";
            this.zedGraphMTF.ScrollGrace = 0D;
            this.zedGraphMTF.ScrollMaxX = 0D;
            this.zedGraphMTF.ScrollMaxY = 0D;
            this.zedGraphMTF.ScrollMaxY2 = 0D;
            this.zedGraphMTF.ScrollMinX = 0D;
            this.zedGraphMTF.ScrollMinY = 0D;
            this.zedGraphMTF.ScrollMinY2 = 0D;
            this.zedGraphMTF.Size = new System.Drawing.Size(775, 347);
            this.zedGraphMTF.TabIndex = 5;
            this.zedGraphMTF.UseExtendedPrintDialog = true;
            // 
            // buOb
            // 
            this.buOb.Location = new System.Drawing.Point(603, 12);
            this.buOb.Name = "buOb";
            this.buOb.Size = new System.Drawing.Size(75, 46);
            this.buOb.TabIndex = 6;
            this.buOb.Text = "Для объектива";
            this.buOb.UseVisualStyleBackColor = true;
            this.buOb.Click += new System.EventHandler(this.buOb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 52);
            this.label1.TabIndex = 7;
            this.label1.Text = "Опасная кнопка!!\r\nПредназначена для рассчета ФПМ объектива\r\nПредварительно рассчи" +
    "тайте изображение \"cam-lens\"\r\nзатем \"cam\"";
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buOb);
            this.Controls.Add(this.zedGraphMTF);
            this.Controls.Add(this.panMTF);
            this.Controls.Add(this.buMTF);
            this.Controls.Add(this.panRot);
            this.Controls.Add(this.numAngle);
            this.Controls.Add(this.buRotate);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "TechLab1";
            ((System.ComponentModel.ISupportInitialize)(this.numAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buRotate;
        private System.Windows.Forms.NumericUpDown numAngle;
        private System.Windows.Forms.Panel panRot;
        private System.Windows.Forms.Button buMTF;
        private System.Windows.Forms.Panel panMTF;
        private ZedGraph.ZedGraphControl zedGraphMTF;
        private System.Windows.Forms.Button buOb;
        private System.Windows.Forms.Label label1;
    }
}

