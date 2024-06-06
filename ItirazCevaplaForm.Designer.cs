namespace VeriTabaniProje
{
    partial class ItirazCevaplaForm
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
            panel1 = new Panel();
            button1 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 321);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(85, 85);
            button1.Name = "button1";
            button1.Size = new Size(192, 58);
            button1.TabIndex = 0;
            button1.Text = "ONAYLA!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button3.Location = new Point(85, 170);
            button3.Name = "button3";
            button3.Size = new Size(192, 58);
            button3.TabIndex = 2;
            button3.Text = "REDDET!";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ItirazCevaplaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(385, 345);
            Controls.Add(panel1);
            Name = "ItirazCevaplaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ItirazCevaplaForm";
            Load += ItirazCevaplaForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button3;
        private Button button1;
    }
}