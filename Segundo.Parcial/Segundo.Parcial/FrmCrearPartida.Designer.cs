﻿namespace Truco
{
    partial class FrmCrearPartida
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
            cmbJugadores = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // cmbJugadores
            // 
            cmbJugadores.FormattingEnabled = true;
            cmbJugadores.Location = new Point(136, 58);
            cmbJugadores.Name = "cmbJugadores";
            cmbJugadores.Size = new Size(294, 23);
            cmbJugadores.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 2;
            label1.Text = "Elija un contrincante:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(174, 9);
            label2.Name = "label2";
            label2.Size = new Size(92, 19);
            label2.TabIndex = 4;
            label2.Text = "Crear partida";
            // 
            // button1
            // 
            button1.Location = new Point(87, 160);
            button1.Name = "button1";
            button1.Size = new Size(126, 23);
            button1.TabIndex = 5;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(235, 160);
            button2.Name = "button2";
            button2.Size = new Size(126, 23);
            button2.TabIndex = 6;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(136, 91);
            button3.Name = "button3";
            button3.Size = new Size(294, 23);
            button3.TabIndex = 7;
            button3.Text = "Aleatorio";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FrmCrearPartida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 210);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbJugadores);
            Name = "FrmCrearPartida";
            Text = "FrmCrearPartida";
            Load += FrmCrearPartida_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbJugadores;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}