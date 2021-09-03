namespace Obr6
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
            this.buPorog = new System.Windows.Forms.Button();
            this.numPorog = new System.Windows.Forms.NumericUpDown();
            this.tbPorog = new System.Windows.Forms.TextBox();
            this.panPorog = new System.Windows.Forms.Panel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buSavePorog = new System.Windows.Forms.Button();
            this.cmbParts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panCountur = new System.Windows.Forms.Panel();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.cmbTypeC = new System.Windows.Forms.ComboBox();
            this.buCountur = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buClaster = new System.Windows.Forms.Button();
            this.numClaster = new System.Windows.Forms.NumericUpDown();
            this.cmbTypeClaster = new System.Windows.Forms.ComboBox();
            this.picClaster = new System.Windows.Forms.PictureBox();
            this.buSaveClaster = new System.Windows.Forms.Button();
            this.buSaveCounter = new System.Windows.Forms.Button();
            this.laCounturProcent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPorog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClaster)).BeginInit();
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
            this.panImg.Size = new System.Drawing.Size(200, 197);
            this.panImg.TabIndex = 1;
            // 
            // buPorog
            // 
            this.buPorog.Enabled = false;
            this.buPorog.Location = new System.Drawing.Point(302, 13);
            this.buPorog.Name = "buPorog";
            this.buPorog.Size = new System.Drawing.Size(120, 35);
            this.buPorog.TabIndex = 2;
            this.buPorog.Text = "Пороговая обработка";
            this.buPorog.UseVisualStyleBackColor = true;
            this.buPorog.Click += new System.EventHandler(this.buPorog_Click);
            // 
            // numPorog
            // 
            this.numPorog.Enabled = false;
            this.numPorog.Location = new System.Drawing.Point(302, 107);
            this.numPorog.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numPorog.Name = "numPorog";
            this.numPorog.Size = new System.Drawing.Size(120, 20);
            this.numPorog.TabIndex = 3;
            this.numPorog.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // tbPorog
            // 
            this.tbPorog.Enabled = false;
            this.tbPorog.Location = new System.Drawing.Point(302, 146);
            this.tbPorog.Name = "tbPorog";
            this.tbPorog.Size = new System.Drawing.Size(100, 20);
            this.tbPorog.TabIndex = 4;
            this.tbPorog.Text = "5";
            // 
            // panPorog
            // 
            this.panPorog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panPorog.Location = new System.Drawing.Point(428, 12);
            this.panPorog.Name = "panPorog";
            this.panPorog.Size = new System.Drawing.Size(200, 197);
            this.panPorog.TabIndex = 2;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Enabled = false;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Простая",
            "Адаптивная"});
            this.cmbType.Location = new System.Drawing.Point(302, 67);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Тип обработки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Порог";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Дельта порога";
            // 
            // buSavePorog
            // 
            this.buSavePorog.Enabled = false;
            this.buSavePorog.Location = new System.Drawing.Point(634, 13);
            this.buSavePorog.Name = "buSavePorog";
            this.buSavePorog.Size = new System.Drawing.Size(75, 23);
            this.buSavePorog.TabIndex = 9;
            this.buSavePorog.Text = "Сохранить";
            this.buSavePorog.UseVisualStyleBackColor = true;
            this.buSavePorog.Click += new System.EventHandler(this.buSavePorog_Click);
            // 
            // cmbParts
            // 
            this.cmbParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParts.Enabled = false;
            this.cmbParts.FormattingEnabled = true;
            this.cmbParts.Items.AddRange(new object[] {
            "4",
            "16"});
            this.cmbParts.Location = new System.Drawing.Point(302, 185);
            this.cmbParts.Name = "cmbParts";
            this.cmbParts.Size = new System.Drawing.Size(121, 21);
            this.cmbParts.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Части изображения";
            // 
            // panCountur
            // 
            this.panCountur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panCountur.Location = new System.Drawing.Point(95, 216);
            this.panCountur.Name = "panCountur";
            this.panCountur.Size = new System.Drawing.Size(200, 197);
            this.panCountur.TabIndex = 2;
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.Enabled = false;
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "Горизонтальные",
            "Вертикальные"});
            this.cmbDirection.Location = new System.Drawing.Point(302, 324);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(121, 21);
            this.cmbDirection.TabIndex = 12;
            // 
            // cmbTypeC
            // 
            this.cmbTypeC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeC.Enabled = false;
            this.cmbTypeC.FormattingEnabled = true;
            this.cmbTypeC.Items.AddRange(new object[] {
            "Робертс",
            "Превитт",
            "Собел",
            "Лапласиан гауссиана"});
            this.cmbTypeC.Location = new System.Drawing.Point(302, 284);
            this.cmbTypeC.Name = "cmbTypeC";
            this.cmbTypeC.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeC.TabIndex = 13;
            // 
            // buCountur
            // 
            this.buCountur.Enabled = false;
            this.buCountur.Location = new System.Drawing.Point(302, 230);
            this.buCountur.Name = "buCountur";
            this.buCountur.Size = new System.Drawing.Size(120, 35);
            this.buCountur.TabIndex = 14;
            this.buCountur.Text = "Выделение контуров";
            this.buCountur.UseVisualStyleBackColor = true;
            this.buCountur.Click += new System.EventHandler(this.buCountur_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Направление";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Тип выделения";
            // 
            // buClaster
            // 
            this.buClaster.Enabled = false;
            this.buClaster.Location = new System.Drawing.Point(634, 216);
            this.buClaster.Name = "buClaster";
            this.buClaster.Size = new System.Drawing.Size(120, 35);
            this.buClaster.TabIndex = 17;
            this.buClaster.Text = "Кластеризация";
            this.buClaster.UseVisualStyleBackColor = true;
            this.buClaster.Click += new System.EventHandler(this.buClaster_Click);
            // 
            // numClaster
            // 
            this.numClaster.Enabled = false;
            this.numClaster.Location = new System.Drawing.Point(634, 257);
            this.numClaster.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numClaster.Name = "numClaster";
            this.numClaster.Size = new System.Drawing.Size(120, 20);
            this.numClaster.TabIndex = 18;
            this.numClaster.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmbTypeClaster
            // 
            this.cmbTypeClaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeClaster.Enabled = false;
            this.cmbTypeClaster.FormattingEnabled = true;
            this.cmbTypeClaster.Items.AddRange(new object[] {
            "Выращиваиние области",
            "Разделение и слияние",
            "Водораздел"});
            this.cmbTypeClaster.Location = new System.Drawing.Point(634, 283);
            this.cmbTypeClaster.Name = "cmbTypeClaster";
            this.cmbTypeClaster.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeClaster.TabIndex = 19;
            // 
            // picClaster
            // 
            this.picClaster.Location = new System.Drawing.Point(428, 215);
            this.picClaster.Name = "picClaster";
            this.picClaster.Size = new System.Drawing.Size(200, 198);
            this.picClaster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClaster.TabIndex = 20;
            this.picClaster.TabStop = false;
            // 
            // buSaveClaster
            // 
            this.buSaveClaster.Enabled = false;
            this.buSaveClaster.Location = new System.Drawing.Point(634, 310);
            this.buSaveClaster.Name = "buSaveClaster";
            this.buSaveClaster.Size = new System.Drawing.Size(75, 23);
            this.buSaveClaster.TabIndex = 21;
            this.buSaveClaster.Text = "Сохранить";
            this.buSaveClaster.UseVisualStyleBackColor = true;
            this.buSaveClaster.Click += new System.EventHandler(this.buSaveClaster_Click);
            // 
            // buSaveCounter
            // 
            this.buSaveCounter.Enabled = false;
            this.buSaveCounter.Location = new System.Drawing.Point(301, 351);
            this.buSaveCounter.Name = "buSaveCounter";
            this.buSaveCounter.Size = new System.Drawing.Size(120, 35);
            this.buSaveCounter.TabIndex = 22;
            this.buSaveCounter.Text = "Сохранение";
            this.buSaveCounter.UseVisualStyleBackColor = true;
            this.buSaveCounter.Click += new System.EventHandler(this.buSaveCounter_Click);
            // 
            // laCounturProcent
            // 
            this.laCounturProcent.AutoSize = true;
            this.laCounturProcent.Location = new System.Drawing.Point(304, 393);
            this.laCounturProcent.Name = "laCounturProcent";
            this.laCounturProcent.Size = new System.Drawing.Size(53, 13);
            this.laCounturProcent.TabIndex = 23;
            this.laCounturProcent.Text = "Процент:";
            // 
            // fm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.laCounturProcent);
            this.Controls.Add(this.buSaveCounter);
            this.Controls.Add(this.buSaveClaster);
            this.Controls.Add(this.picClaster);
            this.Controls.Add(this.cmbTypeClaster);
            this.Controls.Add(this.numClaster);
            this.Controls.Add(this.buClaster);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buCountur);
            this.Controls.Add(this.cmbTypeC);
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.panCountur);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbParts);
            this.Controls.Add(this.buSavePorog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.panPorog);
            this.Controls.Add(this.tbPorog);
            this.Controls.Add(this.numPorog);
            this.Controls.Add(this.buPorog);
            this.Controls.Add(this.panImg);
            this.Controls.Add(this.buDownload);
            this.Name = "fm";
            this.Text = "Obr6";
            ((System.ComponentModel.ISupportInitialize)(this.numPorog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buDownload;
        private System.Windows.Forms.Panel panImg;
        private System.Windows.Forms.Button buPorog;
        private System.Windows.Forms.NumericUpDown numPorog;
        private System.Windows.Forms.TextBox tbPorog;
        private System.Windows.Forms.Panel panPorog;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buSavePorog;
        private System.Windows.Forms.ComboBox cmbParts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panCountur;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.ComboBox cmbTypeC;
        private System.Windows.Forms.Button buCountur;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buClaster;
        private System.Windows.Forms.NumericUpDown numClaster;
        private System.Windows.Forms.ComboBox cmbTypeClaster;
        private System.Windows.Forms.PictureBox picClaster;
        private System.Windows.Forms.Button buSaveClaster;
        private System.Windows.Forms.Button buSaveCounter;
        private System.Windows.Forms.Label laCounturProcent;
    }
}

