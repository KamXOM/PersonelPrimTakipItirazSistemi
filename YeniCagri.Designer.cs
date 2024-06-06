namespace VeriTabaniProje
{
    partial class YeniCagri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MusteriAdTextBox = new TextBox();
            MusteriSoyadTextBox = new TextBox();
            dateTimePicker = new DateTimePicker();
            KaydetButton = new Button();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            comboBox2 = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // MusteriAdTextBox
            // 
            MusteriAdTextBox.Anchor = AnchorStyles.None;
            MusteriAdTextBox.Location = new Point(147, 78);
            MusteriAdTextBox.Name = "MusteriAdTextBox";
            MusteriAdTextBox.Size = new Size(125, 27);
            MusteriAdTextBox.TabIndex = 0;
            // 
            // MusteriSoyadTextBox
            // 
            MusteriSoyadTextBox.Anchor = AnchorStyles.None;
            MusteriSoyadTextBox.Location = new Point(147, 136);
            MusteriSoyadTextBox.Name = "MusteriSoyadTextBox";
            MusteriSoyadTextBox.Size = new Size(125, 27);
            MusteriSoyadTextBox.TabIndex = 1;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Anchor = AnchorStyles.None;
            dateTimePicker.Location = new Point(175, 100);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(250, 27);
            dateTimePicker.TabIndex = 2;
            // 
            // KaydetButton
            // 
            KaydetButton.Anchor = AnchorStyles.None;
            KaydetButton.Font = new Font("Corbel", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            KaydetButton.Location = new Point(62, 279);
            KaydetButton.Name = "KaydetButton";
            KaydetButton.Size = new Size(172, 71);
            KaydetButton.TabIndex = 3;
            KaydetButton.Text = "Kaydet";
            KaydetButton.UseVisualStyleBackColor = true;
            KaydetButton.Click += KaydetButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(47, 81);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 4;
            label1.Text = "Müşteri Ad:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(25, 139);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 5;
            label2.Text = "Müşteri Soyad:";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.None;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tamamlandı", "Takip Ediliyor", "Sorun Çözülemedi" });
            comboBox1.Location = new Point(292, 276);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(229, 279);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 7;
            label3.Text = "Durum:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.None;
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Location = new Point(175, 144);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.Value = new DateTime(2024, 5, 18, 5, 10, 37, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.None;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Location = new Point(175, 191);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 11;
            dateTimePicker2.Value = new DateTime(2024, 5, 18, 5, 10, 37, 0);
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(51, 149);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 12;
            label5.Text = "Başlama Saati:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(79, 196);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 13;
            label6.Text = "Bitiş Saati:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(46, 105);
            label7.Name = "label7";
            label7.Size = new Size(110, 20);
            label7.TabIndex = 14;
            label7.Text = "Görüşme Tarihi:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new Point(6, 279);
            label8.Name = "label8";
            label8.Size = new Size(43, 20);
            label8.TabIndex = 16;
            label8.Text = "Konu";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.None;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Arıza", "Talep", "Bilgi" });
            comboBox2.Location = new Point(55, 276);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 15;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(MusteriAdTextBox);
            groupBox1.Controls.Add(MusteriSoyadTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(302, 231);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Müşteri Bilgileri";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.None;
            groupBox2.Controls.Add(dateTimePicker);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(dateTimePicker2);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(311, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(462, 420);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Müşteri İşlemleri";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(KaydetButton);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 426);
            panel1.TabIndex = 19;
            // 
            // YeniCagri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "YeniCagri";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Çağrı Ekranı";
            Load += YeniCagri_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox MusteriAdTextBox;
        private TextBox MusteriSoyadTextBox;
        private DateTimePicker dateTimePicker;
        private Button KaydetButton;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox comboBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel1;
    }
}