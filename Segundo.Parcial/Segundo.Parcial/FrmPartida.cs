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
        private Jugador? mano;
        private Partida partida;
        private Carta? c1;
        private Carta? c2;
        private ETruco? estadoTruco;
        private ETantos? estadoEnvido;
        private int cartasSobreLaMesa;

        private event EventHandler? FinDeMano;
        private event EventHandler? CartaTirada;

        public FrmPartida(Partida partida)
        {
            InitializeComponent();
            this.partida = partida;
        }

        private void FrmPartida_Load(object sender, EventArgs e)
        {
            this.label1.Text = this.partida.Jugador2.Nombre;
            this.label2.Text = this.partida.Jugador1.Nombre;
            this.cartasSobreLaMesa = 0;

            this.partida.IniciarPartida(Application.StartupPath + @"\Cartas_Serializadas\cartas.json");
            this.partida.RepartirCartas();
            this.AsignarImagenesDeCartas();
            this.AsignarPrimerTurno();

            this.FinDeMano += this.GanadorDeMano;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ronda r = new Ronda(this.partida);

            //Dictionary<Jugador, int> aux = r.ObtenerGanadorEnvido();

            string cadena = "";
            (int, int) valores;

            foreach (KeyValuePair<ETantos, (int, int)> item in this.partida.ValoresEnvido)
            {
                valores = this.partida.ValoresEnvido[item.Key];

                cadena += item.Key.ToString() + "\nQuiero: " + valores.Item2.ToString() + "\nNo Quiero: " + valores.Item1.ToString() + "\n";
            }

            cadena += "=====================\n======================\n";

            foreach (KeyValuePair<ETruco, (int, int)> item in this.partida.ValoresTruco)
            {
                valores = this.partida.ValoresTruco[item.Key];
                cadena += item.Key.ToString() + "\nQuiero: " + valores.Item2.ToString() + "\nNo Quiero: " + valores.Item1.ToString() + "\n";
            }

            MessageBox.Show(cadena);
        }

        private void j2_1_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador2.Turno)
            {
                this.j2_1.Enabled = false;
                this.j2_1.Size = new Size(75, 100);
                this.c2 = this.partida.Jugador2.Cartas[0];
                this.partida.Jugador1.Turno = true;
                this.partida.Jugador2.Turno = false;
                this.cartasSobreLaMesa++;

                this.FinDeMano?.Invoke(sender, e);
            }
        }

        private void j2_2_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador2.Turno)
            {
                this.j2_2.Enabled = false;
                this.j2_2.Size = new Size(75, 100);
                this.c2 = this.partida.Jugador2.Cartas[1];
                this.partida.Jugador1.Turno = true;
                this.partida.Jugador2.Turno = false;
                this.cartasSobreLaMesa++;

                this.FinDeMano?.Invoke(sender, e);
            }
        }
        private void j2_3_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador2.Turno)
            {
                this.j2_3.Enabled = false;
                this.j2_3.Size = new Size(75, 100);
                this.c2 = this.partida.Jugador2.Cartas[2];
                this.partida.Jugador1.Turno = true;
                this.partida.Jugador2.Turno = false;
                this.cartasSobreLaMesa++;

                this.FinDeMano?.Invoke(sender, e);
            }
        }
        private void j1_1_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador1.Turno)
            {
                this.j1_1.Enabled = false;
                this.j1_1.Size = new Size(75, 100);
                this.c1 = this.partida.Jugador1.Cartas[0];
                this.partida.Jugador1.Turno = false;
                this.partida.Jugador2.Turno = true;
                this.cartasSobreLaMesa++;

                this.FinDeMano?.Invoke(sender, e);
            }
        }

        private void j1_2_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador1.Turno)
            {
                this.j1_2.Enabled = false;
                this.j1_2.Size = new Size(75, 100);
                this.c1 = this.partida.Jugador1.Cartas[1];
                this.partida.Jugador1.Turno = false;
                this.partida.Jugador2.Turno = true;
                this.cartasSobreLaMesa++;

                this.FinDeMano?.Invoke(sender, e);
            }
        }

        private void j1_3_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador1.Turno)
            {
                this.j1_3.Enabled = false;
                this.j1_3.Size = new Size(75, 100);
                this.c1 = this.partida.Jugador1.Cartas[2];
                this.partida.Jugador1.Turno = false;
                this.partida.Jugador2.Turno = true;
                this.cartasSobreLaMesa++;

                this.FinDeMano?.Invoke(sender, e);
            }
        }

        private void GanadorDeMano(object sender, EventArgs e)
        {
            Carta aux = new Carta();

            if (this.c1 is not null && this.c2 is not null)
            {
                aux = new Ronda(this.partida).ObtenerGanadorMano(this.c1, this.c2);

                if (aux is not null)
                {
                    if (aux == this.c1 && aux.Numero == this.c1.Numero)
                    {
                        this.partida.Jugador1.Turno = true;
                        this.partida.Jugador2.Turno = false;
                    }
                    else
                    {
                        if (aux.Numero == this.c2.Numero)
                        {
                            this.partida.Jugador1.Turno = false;
                            this.partida.Jugador2.Turno = true;
                        }
                    }
                }
                else
                {
                    if (this.partida.Jugador1 == this.mano)
                    {
                        this.partida.Jugador1.Turno = true;
                        this.partida.Jugador2.Turno = false;
                    }
                    else
                    {
                        this.partida.Jugador1.Turno = false;
                        this.partida.Jugador2.Turno = true;
                    }
                }

                this.c1 = null;
                this.c2 = null;
            }
        }

        private void HabilitarBotones(object sender, EventArgs e) 
        {
            if (this.cartasSobreLaMesa <= 1 && !this.estadoEnvido.HasValue && !this.estadoTruco.HasValue) 
            {
                this.btnEnvido.Enabled = true;
                this.btnRealEnvido.Enabled = true;
                this.btnFalta.Enabled = true;
                this.btnTruco.Enabled = true;
                
            }
        }

        private void AsignarImagenesDeCartas() 
        {
            List<Bitmap> imagenes = new List<Bitmap>();

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
        }

        private void AsignarPrimerTurno() 
        {
            Random random = new Random();

            this.partida.Jugador1.Turno = random.Next(2) == 0;
            this.partida.Jugador2.Turno = !this.partida.Jugador1.Turno;

            if (this.partida.Jugador1.Turno)
            {
                this.mano = this.partida.Jugador1;
            }
            else
            {
                this.mano = this.partida.Jugador2;
            }
        }
    }
}
