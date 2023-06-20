using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Truco
{
    public partial class FrmMenu : Form
    {
        Jugador jugador1;
        private delegate void Delegado();////

        public FrmMenu(Jugador jugador)
        {
            InitializeComponent();
            this.jugador1 = jugador;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnPartidas_Click(object sender, EventArgs e)
        {
            Task.Run(() => { this.MostrarFrmListarPartida(); });
        }

        private void MostrarFrmListarPartida()//////////////
        {
            Delegado callback;

            if (this.InvokeRequired)
            {
                callback = new Delegado(MostrarFrmListarPartida);
                this.BeginInvoke(callback);
            }
            else
            {
                this.Hide();
                FrmListarPartida fm = new FrmListarPartida();
                fm.StartPosition = FormStartPosition.CenterScreen;
                fm.ShowDialog();
                if (fm.DialogResult == DialogResult.Cancel)
                {
                    this.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() => { this.MostrarFrmListarJugadores(); });
        }

        private void MostrarFrmListarJugadores()
        {
            Delegado callback;

            if (this.InvokeRequired)
            {
                callback = new Delegado(MostrarFrmListarJugadores);
                this.BeginInvoke(callback);
            }
            else
            {
                this.Hide();
                FrmListarJugadores fm = new FrmListarJugadores(new Jugador().ObtenerDatos("usuarios"));
                fm.StartPosition = FormStartPosition.CenterScreen;
                fm.ShowDialog();
                if (fm.DialogResult == DialogResult.Cancel)
                {
                    this.Show();
                }
            }
        }
    }
}
