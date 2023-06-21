namespace Truco
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            pictureBox1 = new PictureBox();
            button2 = new Button();
            btnPartidas = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-132, -22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(482, 181);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(110, 202);
            button2.Name = "button2";
            button2.Size = new Size(116, 23);
            button2.TabIndex = 2;
            button2.Text = "Ver Jugadores";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnPartidas
            // 
            btnPartidas.Location = new Point(110, 244);
            btnPartidas.Name = "btnPartidas";
            btnPartidas.Size = new Size(116, 23);
            btnPartidas.TabIndex = 3;
            btnPartidas.Text = "Ver Partidas";
            btnPartidas.UseVisualStyleBackColor = true;
            btnPartidas.Click += btnPartidas_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(347, 296);
            Controls.Add(btnPartidas);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Name = "FrmMenu";
            Text = "FrmMenu";
            Load += FrmMenu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Button button2;
        private Button btnPartidas;
    }
}