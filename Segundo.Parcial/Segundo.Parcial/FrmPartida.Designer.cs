namespace Truco
{
    partial class FrmPartida
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
            j1_1 = new PictureBox();
            j1_2 = new PictureBox();
            j1_3 = new PictureBox();
            j2_3 = new PictureBox();
            j2_2 = new PictureBox();
            j2_1 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)j1_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)j1_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)j1_3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)j2_3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)j2_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)j2_1).BeginInit();
            SuspendLayout();
            // 
            // j1_1
            // 
            j1_1.BackgroundImageLayout = ImageLayout.Zoom;
            j1_1.Location = new Point(19, 320);
            j1_1.Name = "j1_1";
            j1_1.Size = new Size(100, 127);
            j1_1.TabIndex = 0;
            j1_1.TabStop = false;
            j1_1.Click += j1_1_Click;
            // 
            // j1_2
            // 
            j1_2.BackgroundImageLayout = ImageLayout.Zoom;
            j1_2.Location = new Point(166, 320);
            j1_2.Name = "j1_2";
            j1_2.Size = new Size(100, 127);
            j1_2.TabIndex = 1;
            j1_2.TabStop = false;
            j1_2.Click += j1_2_Click;
            // 
            // j1_3
            // 
            j1_3.BackgroundImageLayout = ImageLayout.Zoom;
            j1_3.Location = new Point(316, 320);
            j1_3.Name = "j1_3";
            j1_3.Size = new Size(100, 127);
            j1_3.TabIndex = 2;
            j1_3.TabStop = false;
            j1_3.Click += j1_3_Click;
            // 
            // j2_3
            // 
            j2_3.BackgroundImageLayout = ImageLayout.Zoom;
            j2_3.Location = new Point(316, 61);
            j2_3.Name = "j2_3";
            j2_3.Size = new Size(100, 127);
            j2_3.TabIndex = 5;
            j2_3.TabStop = false;
            j2_3.Click += j2_3_Click;
            // 
            // j2_2
            // 
            j2_2.BackgroundImageLayout = ImageLayout.Zoom;
            j2_2.Location = new Point(166, 61);
            j2_2.Name = "j2_2";
            j2_2.Size = new Size(100, 127);
            j2_2.TabIndex = 4;
            j2_2.TabStop = false;
            j2_2.Click += j2_2_Click;
            // 
            // j2_1
            // 
            j2_1.BackgroundImageLayout = ImageLayout.Zoom;
            j2_1.Location = new Point(19, 61);
            j2_1.Name = "j2_1";
            j2_1.Size = new Size(100, 127);
            j2_1.TabIndex = 3;
            j2_1.TabStop = false;
            j2_1.Click += j2_1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(19, 507);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 20);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(378, 507);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // FrmPartida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 563);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(j2_3);
            Controls.Add(j2_2);
            Controls.Add(j2_1);
            Controls.Add(j1_3);
            Controls.Add(j1_2);
            Controls.Add(j1_1);
            Name = "FrmPartida";
            Text = "FrmPartida";
            Load += FrmPartida_Load;
            ((System.ComponentModel.ISupportInitialize)j1_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)j1_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)j1_3).EndInit();
            ((System.ComponentModel.ISupportInitialize)j2_3).EndInit();
            ((System.ComponentModel.ISupportInitialize)j2_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)j2_1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox j1_1;
        private PictureBox j1_2;
        private PictureBox j1_3;
        private PictureBox j2_3;
        private PictureBox j2_2;
        private PictureBox j2_1;
        private Button button1;
        private Label label1;
        private Label label2;
    }
}