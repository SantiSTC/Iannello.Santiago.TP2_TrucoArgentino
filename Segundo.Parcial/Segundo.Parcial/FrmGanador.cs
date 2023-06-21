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
    public partial class FrmGanador : Form
    {
        Jugador ganador;
        int puntos;
        public FrmGanador(Jugador j, int puntos)
        {
            InitializeComponent();
            this.ganador = j;
            this.puntos = puntos;
        }

        private void FrmGanador_Load(object sender, EventArgs e)
        {
            this.label2.Text = this.ganador.ToString();
            this.label3.Text = "Puntos: " + this.puntos; 
        }
    }
}
