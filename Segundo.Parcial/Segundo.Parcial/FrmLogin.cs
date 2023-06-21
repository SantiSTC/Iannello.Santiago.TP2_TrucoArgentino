using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truco
{
    public partial class FrmLogin : Form
    {
        private List<Jugador> usuarios;
        private static Jugador usuarioLogueado;

        public static Jugador UsuarioLogueado { get { return FrmLogin.usuarioLogueado; } set { FrmLogin.usuarioLogueado = value; } }
        public FrmLogin()
        {
            InitializeComponent();
            this.usuarios = new List<Jugador>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador(this.txtNombre.Text, this.txtContrasenia.Text);
            bool usuarioExiste = false;

            foreach (Jugador j in this.usuarios)
            {
                if (j == jugador)
                {
                    FrmLogin.usuarioLogueado = jugador;
                    usuarioExiste = true;
                    break;
                }
            }

            if (usuarioExiste)
            {
                FrmMenu fm = new FrmMenu(jugador);
                this.Hide();
                fm.StartPosition = FormStartPosition.CenterScreen;
                fm.ShowDialog();

                if (fm.DialogResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraña incorrectos. Verifique.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.usuarios = new Jugador().ObtenerDatos("usuarios");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistrarse fm = new FrmRegistrarse();
            this.Hide();
            if (fm.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
                this.usuarios = new Jugador().ObtenerDatos("usuarios");
            }
        }
    }
}
