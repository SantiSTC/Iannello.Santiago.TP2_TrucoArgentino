﻿namespace Truco
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            txtNombre = new TextBox();
            txtContrasenia = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(59, 143);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = " Ingrese el nombre de usuario";
            txtNombre.Size = new Size(314, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(59, 191);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PlaceholderText = " Ingrese la contraseña";
            txtContrasenia.Size = new Size(314, 23);
            txtContrasenia.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-93, -13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(327, 102);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(130, 77);
            label1.Name = "label1";
            label1.Size = new Size(180, 36);
            label1.TabIndex = 3;
            label1.Text = "Iniciar Sesión";
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGreen;
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(59, 251);
            button1.Name = "button1";
            button1.Size = new Size(314, 33);
            button1.TabIndex = 4;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(428, 336);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(txtContrasenia);
            Controls.Add(txtNombre);
            Name = "FrmLogin";
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtContrasenia;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
    }
}