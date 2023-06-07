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
    public partial class FrmPartida : Form
    {
        Partida partida;

        public FrmPartida(Partida partida)
        {
            InitializeComponent();
            this.partida = partida;
        }

        private void FrmPartida_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            List<Bitmap> imagenes = new List<Bitmap>();

            this.partida.IniciarPartida(Application.StartupPath + @"\Cartas_Serializadas\cartas.json");
            this.partida.RepartirCartas();

            foreach (Carta item in this.partida.Jugador1.Cartas)
            {
                imagenes.Add(new Bitmap(Application.StartupPath + @"\Cartas_Imagenes\" + item.Numero + " de " + item.Palo.ToString() + ".jpeg"));
            }

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        this.j1_1.BackgroundImage = imagenes[i];
                        break;
                    case 1:
                        this.j1_2.BackgroundImage = imagenes[i];
                        break;
                    case 2:
                        this.j1_3.BackgroundImage = imagenes[i];
                        break;
                }
            }

            imagenes.Clear();

            foreach (Carta item in this.partida.Jugador2.Cartas)
            {
                imagenes.Add(new Bitmap(Application.StartupPath + @"\Cartas_Imagenes\" + item.Numero + " de " + item.Palo.ToString() + ".jpeg"));
            }

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        this.j2_1.BackgroundImage = imagenes[i];
                        break;
                    case 1:
                        this.j2_2.BackgroundImage = imagenes[i];
                        break;
                    case 2:
                        this.j2_3.BackgroundImage = imagenes[i];
                        break;
                }
            }

            this.partida.Jugador1.Turno = random.Next(2) == 0;
            this.partida.Jugador2.Turno = !this.partida.Jugador1.Turno;
        }
    }
}
