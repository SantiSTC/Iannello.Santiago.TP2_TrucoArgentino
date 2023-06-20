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
    public partial class FrmCrearPartida : Form
    {
        private delegate void Delegado();
        private List<Jugador> lista;

        public FrmCrearPartida(List<Jugador> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void FrmCrearPartida_Load(object sender, EventArgs e)
        {
            Task.Run(() => { this.CargarListarJugadores(); });
        }

        private void CargarListarJugadores()
        {
            Delegado callback;

            if (this.InvokeRequired)
            {
                callback = new Delegado(CargarListarJugadores);
                this.BeginInvoke(callback);
            }
            else
            {
                foreach (Jugador item in this.lista)
                {
                    if (item != FrmLogin.UsuarioLogueado)
                    {
                        this.cmbJugadores.Items.Add(item);
                    }
                    else 
                    {
                        FrmLogin.UsuarioLogueado = item;
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            this.cmbJugadores.SelectedIndex = random.Next(cmbJugadores.Items.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Partida p = new Partida(FrmLogin.UsuarioLogueado, (Jugador)this.cmbJugadores.SelectedItem);

            if (new Partida().AgregarDatos(p))
            {
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
