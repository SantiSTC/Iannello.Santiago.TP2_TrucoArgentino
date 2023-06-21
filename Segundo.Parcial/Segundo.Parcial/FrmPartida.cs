using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Truco
{
    public partial class FrmPartida : Form
    {
        private bool flag;
        private Jugador auxEnvido;
        private Jugador? mano;
        private Partida partida;
        private Carta? c1;
        private Carta? c2;
        private int manosGanadasJ1;
        private int manosGanadasJ2;
        private ETruco? estadoTruco;
        private ETantos? estadoEnvido;
        private int cartasSobreLaMesa;
        private bool fueParda;
        int manosJugadas;

        private event EventHandler? FinDeMano;
        private event EventHandler? BotonPresionado;
        private event EventHandler? FinDeRonda;

        public FrmPartida(Partida partida)
        {
            InitializeComponent();
            this.partida = partida;
            manosJugadas = 0;
        }

        private void FrmPartida_Load(object sender, EventArgs e)
        {
            this.label1.Text = this.partida.Jugador2.Nombre;
            this.label2.Text = this.partida.Jugador1.Nombre;
            this.ptsJ1.Text = this.partida.PtsJugador1.ToString();
            this.ptsJ2.Text = this.partida.PtsJugador2.ToString();
            this.fueParda = false;

            this.partida.IniciarPartida(Application.StartupPath + @"\Cartas_Serializadas\cartas.json");
            this.IniciarRonda();
            this.AsignarPrimerTurno();

            this.flag = false;

            this.FinDeMano += this.GanadorDeMano;
            this.BotonPresionado += this.HabilitarBotones;
            this.FinDeRonda += this.FinalizarRonda;
            this.partida.Jugador1.CartaTirada += Capturar_Jugador_CartaTirada;
            this.partida.Jugador2.CartaTirada += Capturar_Jugador_CartaTirada;
        }

        private void j2_1_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador2.Turno && !this.estadoEnvido.HasValue)
            {
                this.j2_1.Enabled = false;
                this.j2_1.Size = new Size(75, 100);
                this.c2 = this.partida.Jugador2.Cartas[0];
                this.cartasSobreLaMesa++;

                this.partida.Jugador2.TirarCarta(this.c2);

                this.FinDeMano?.Invoke(sender, e);
                this.BotonPresionado?.Invoke(sender, e);
            }
        }

        private void j2_2_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador2.Turno && !this.estadoEnvido.HasValue)
            {
                this.j2_2.Enabled = false;
                this.j2_2.Size = new Size(75, 100);
                this.c2 = this.partida.Jugador2.Cartas[1];
                this.cartasSobreLaMesa++;

                this.partida.Jugador2.TirarCarta(this.c2);

                this.FinDeMano?.Invoke(sender, e);
                this.BotonPresionado?.Invoke(sender, e);
            }
        }
        private void j2_3_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador2.Turno && !this.estadoEnvido.HasValue)
            {
                this.j2_3.Enabled = false;
                this.j2_3.Size = new Size(75, 100);
                this.c2 = this.partida.Jugador2.Cartas[2];
                this.cartasSobreLaMesa++;

                this.partida.Jugador2.TirarCarta(this.c2);

                this.FinDeMano?.Invoke(sender, e);
                this.BotonPresionado?.Invoke(sender, e);
            }
        }
        private void j1_1_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador1.Turno && !this.estadoEnvido.HasValue)
            {
                this.j1_1.Enabled = false;
                this.j1_1.Size = new Size(75, 100);
                this.c1 = this.partida.Jugador1.Cartas[0];
                this.cartasSobreLaMesa++;

                this.partida.Jugador1.TirarCarta(this.c1);

                this.FinDeMano?.Invoke(sender, e);
                this.BotonPresionado?.Invoke(sender, e);
            }
        }

        private void j1_2_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador1.Turno && !this.estadoEnvido.HasValue)
            {
                this.j1_2.Enabled = false;
                this.j1_2.Size = new Size(75, 100);
                this.c1 = this.partida.Jugador1.Cartas[1];
                this.cartasSobreLaMesa++;

                this.partida.Jugador1.TirarCarta(this.c1);

                this.FinDeMano?.Invoke(sender, e);
                this.BotonPresionado?.Invoke(sender, e);
            }
        }

        private void j1_3_Click(object sender, EventArgs e)
        {
            if (this.partida.Jugador1.Turno && !this.estadoEnvido.HasValue)
            {
                this.j1_3.Enabled = false;
                this.j1_3.Size = new Size(75, 100);
                this.c1 = this.partida.Jugador1.Cartas[2];
                this.cartasSobreLaMesa++;

                this.partida.Jugador1.TirarCarta(this.c1);

                this.FinDeMano?.Invoke(sender, e);
                this.BotonPresionado?.Invoke(sender, e);
            }
        }

        private void Capturar_Jugador_CartaTirada(object sender, Carta e)
        {
            Jugador? j = (Jugador)sender;

            if (this.partida.Jugador1 == j)
            {
                this.partida.Jugador1.Turno = false;
                this.partida.Jugador2.Turno = true;

                this.lblTurnoJ2.Text = "Tu turno!";
                this.lblTurnoJ1.Visible = false;
                this.lblTurnoJ2.Visible = true;
            }
            else
            {
                this.partida.Jugador1.Turno = true;
                this.partida.Jugador2.Turno = false;

                this.lblTurnoJ1.Text = "Tu turno!";
                this.lblTurnoJ2.Visible = false;
                this.lblTurnoJ1.Visible = true;
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
                        this.manosGanadasJ1++;
                        this.partida.Jugador1.Turno = true;
                        this.partida.Jugador2.Turno = false;
                        this.lblTurnoJ1.Text = "Tu turno!";
                        this.lblTurnoJ2.Visible = false;
                        this.lblTurnoJ1.Visible = true;
                    }
                    else
                    {
                        if (aux.Numero == this.c2.Numero)
                        {
                            this.manosGanadasJ2++;
                            this.partida.Jugador1.Turno = false;
                            this.partida.Jugador2.Turno = true;
                            this.lblTurnoJ2.Text = "Tu turno!";
                            this.lblTurnoJ1.Visible = false;
                            this.lblTurnoJ2.Visible = true;
                        }
                    }
                }
                else
                {
                    this.fueParda = true;

                    if (this.partida.Jugador1 == this.mano)
                    {
                        this.partida.Jugador1.Turno = true;
                        this.partida.Jugador2.Turno = false;

                        this.lblTurnoJ1.Text = "Tu turno!";
                        this.lblTurnoJ2.Visible = false;
                        this.lblTurnoJ1.Visible = true;
                    }
                    else
                    {
                        this.partida.Jugador1.Turno = false;
                        this.partida.Jugador2.Turno = true;

                        this.lblTurnoJ2.Text = "Tu turno!";
                        this.lblTurnoJ1.Visible = false;
                        this.lblTurnoJ2.Visible = true;
                    }
                }

                this.c1 = null;
                this.c2 = null;
            }

            if (this.cartasSobreLaMesa == 6)
            {
                this.FinDeRonda?.Invoke(sender, e);
            }
            else
            {
                if ((this.manosGanadasJ1 == 2 || this.manosGanadasJ2 == 2) || (fueParda && (this.manosGanadasJ1 == 1 || this.manosGanadasJ2 == 1)))
                {
                    this.FinDeRonda?.Invoke(sender, e);
                }
            }

            this.ptsJ1.Text = this.partida.PtsJugador1.ToString();
            this.ptsJ2.Text = this.partida.PtsJugador2.ToString();
        }

        private void AsignarPuntosTruco()
        {
            if (this.manosGanadasJ1 > this.manosGanadasJ2)
            {
                if (!this.estadoTruco.HasValue)
                {
                    this.partida.PtsJugador1 += 1;
                }
                else
                {
                    this.partida.PtsJugador1 += this.partida.ValoresTruco[this.estadoTruco].Item2;
                }
            }
            else
            {
                if (!this.estadoTruco.HasValue)
                {
                    this.partida.PtsJugador2 += 1;
                }
                else
                {
                    this.partida.PtsJugador2 += this.partida.ValoresTruco[this.estadoTruco].Item2;
                }
            }

            this.ptsJ1.Text = this.partida.PtsJugador1.ToString();
            this.ptsJ2.Text = this.partida.PtsJugador2.ToString();
        }
        private void FinalizarRonda(object sender, EventArgs e)
        {
            this.AsignarPuntosTruco();

            MessageBox.Show("Ganador de ronda: \n" + this.ObtenerGanadorDeRonda().ToString(), "Ronda Terminada", MessageBoxButtons.OK);

            this.partida.Jugador1.Cartas.Clear();
            this.partida.Jugador2.Cartas.Clear();
            this.c1 = null;
            this.c2 = null;
            this.estadoTruco = null;
            this.estadoEnvido = null;
            this.j2_1.Size = new Size(100, 127);
            this.j2_2.Size = new Size(100, 127);
            this.j2_3.Size = new Size(100, 127);
            this.j1_1.Size = new Size(100, 127);
            this.j1_2.Size = new Size(100, 127);
            this.j1_3.Size = new Size(100, 127);
            this.btnTruco.Text = "Truco";
            this.btnEnvido.Enabled = true;
            this.btnRealEnvido.Enabled = true;
            this.btnFalta.Enabled = true;
            this.btnTruco.Enabled = true;
            this.j1_1.Enabled = true;
            this.j1_2.Enabled = true;
            this.j1_3.Enabled = true;
            this.j2_1.Enabled = true;
            this.j2_2.Enabled = true;
            this.j2_3.Enabled = true;
            this.fueParda = false;
            this.manosJugadas++;

            if(this.manosJugadas < 5)
            {
                this.IniciarRonda();
            }
            else
            {
                if(this.partida.PtsJugador1 > this.partida.PtsJugador2)
                {
                    FrmGanador fm = new FrmGanador(this.partida.Jugador1, this.partida.PtsJugador1);
                    fm.ShowDialog();
                }
                else
                {
                    FrmGanador fm = new FrmGanador(this.partida.Jugador2, this.partida.PtsJugador2);
                    fm.ShowDialog();
                }
               
                this.Close();
            }
        }

        private void HabilitarBotones(object sender, EventArgs e)
        {
            string cadena;

            if (!this.estadoTruco.HasValue)
            {
                this.btnTruco.Enabled = true;
            }
            else
            {
                if (this.partida.Jugador1.TrucoCantado == this.estadoTruco)
                {
                    if (this.partida.Jugador1.Turno)
                    {
                        this.btnTruco.Enabled = false;
                    }
                    else
                    {
                        this.btnTruco.Enabled = true;
                    }
                }
                else
                {
                    if (this.partida.Jugador2.Turno)
                    {
                        this.btnTruco.Enabled = false;
                    }
                    else
                    {
                        this.btnTruco.Enabled = true;
                    }
                }
            }

            if (!flag)
            {
                auxEnvido = this.mano;
                flag = true;
            }
            else
            {
                if (auxEnvido == this.partida.Jugador1)
                {
                    auxEnvido = this.partida.Jugador2;
                }
                else
                {
                    auxEnvido = this.partida.Jugador1;
                }
            }

            if (this.cartasSobreLaMesa < 2)
            {
                if (this.estadoEnvido.HasValue)
                {
                    switch (this.estadoEnvido.ToString())
                    {
                        case "Envido":
                            this.btnTruco.Enabled = false;
                            break;
                        case "Envido_Envido":
                            this.btnEnvido.Enabled = false;
                            this.btnTruco.Enabled = false;
                            break;
                        case "RealEnvido":
                        case "Envido_RealEnvido":
                        case "Envido_Envido_RealEnvido":
                            this.btnEnvido.Enabled = false;
                            this.btnRealEnvido.Enabled = false;
                            this.btnTruco.Enabled = false;
                            break;
                        case "FaltaEnvido":
                        case "Envido_FaltaEnvido":
                        case "RealEnvido_FaltaEnvido":
                        case "Envido_Envido_FaltaEnvido":
                        case "Envido_RealEnvido_FaltaEnvido":
                        case "Envido_Envido_RealEnvido_FaltaEnvido":
                            this.btnEnvido.Enabled = false;
                            this.btnRealEnvido.Enabled = false;
                            this.btnFalta.Enabled = false;
                            this.btnTruco.Enabled = false;
                            break;
                    }

                    if (this.partida.Jugador1.Turno)
                    {
                        cadena = $"{this.auxEnvido.Nombre} cantó {this.estadoEnvido.ToString()}";
                    }
                    else
                    {
                        cadena = $"{this.auxEnvido.Nombre} cantó {this.estadoEnvido.ToString()}";
                    }

                    MessageBox.Show(cadena);

                    this.estadoTruco = null;
                }
            }
            else
            {
                this.btnEnvido.Enabled = false;
                this.btnRealEnvido.Enabled = false;
                this.btnFalta.Enabled = false;
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

            if (!this.partida.Jugador1.Turno)
            {
                this.mano = this.partida.Jugador2;
                this.lblTurnoJ2.Text = "Tu turno!";
                this.lblTurnoJ1.Visible = false;
                this.lblTurnoJ2.Visible = true;
            }
            else
            {
                this.mano = this.partida.Jugador1;
                this.lblTurnoJ1.Text = "Tu turno!";
                this.lblTurnoJ2.Visible = false;
                this.lblTurnoJ1.Visible = true;
            }
        }

        private void AsignarMano()
        {
            if (this.partida.Jugador1 == this.mano)
            {
                this.mano = this.partida.Jugador2;
                this.partida.Jugador1.Turno = false;
                this.partida.Jugador2.Turno = true;

                this.lblTurnoJ2.Text = "Tu turno!";
                this.lblTurnoJ1.Visible = false;
                this.lblTurnoJ2.Visible = true;

            }
            else
            {
                this.mano = this.partida.Jugador1;
                this.partida.Jugador2.Turno = false;
                this.partida.Jugador1.Turno = true;

                this.lblTurnoJ1.Text = "Tu turno!";
                this.lblTurnoJ2.Visible = false;
                this.lblTurnoJ1.Visible = true;
            }
        }

        private void IniciarRonda()
        {
            this.cartasSobreLaMesa = 0;
            this.manosGanadasJ1 = 0;
            this.manosGanadasJ2 = 0;

            this.partida.RepartirCartas();
            this.AsignarImagenesDeCartas();
            this.AsignarMano();
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            DialogResult quiere;

            if (!this.estadoTruco.HasValue)
            {
                quiere = MessageBox.Show($"El oponente ha cantado Truco.\n\n                ¿Querés?", "¡Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                quiere = MessageBox.Show($"El oponente ha cantado {this.estadoTruco + 1}.\n\n             ¿Querés?", "¡Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            bool quiso = false;

            if (!this.estadoTruco.HasValue && quiere == DialogResult.Yes)
            {
                this.estadoTruco = ETruco.Truco;
                this.btnTruco.Text = "Retruco";
                quiso = true;

                if (this.partida.Jugador1.Turno)
                {
                    this.partida.Jugador1.TrucoCantado = this.estadoTruco;
                }
                else
                {
                    this.partida.Jugador2.TrucoCantado = this.estadoTruco;
                }

                this.btnEnvido.Enabled = false;
                this.btnRealEnvido.Enabled = false;
                this.btnFalta.Enabled = false;
            }
            else
            {
                if (this.estadoTruco == ETruco.Truco && quiere == DialogResult.Yes)
                {
                    this.estadoTruco = ETruco.Retruco;
                    this.btnTruco.Text = "Vale Cuatro";
                    quiso = true;

                    if (this.partida.Jugador1.Turno)
                    {
                        this.partida.Jugador1.TrucoCantado = this.estadoTruco;
                    }
                    else
                    {
                        this.partida.Jugador2.TrucoCantado = this.estadoTruco;
                    }
                }
                else
                {
                    if (this.estadoTruco == ETruco.Retruco && quiere == DialogResult.Yes)
                    {
                        this.estadoTruco = ETruco.ValeCuatro;
                        this.btnTruco.Enabled = false;
                        quiso = true;

                        if (this.partida.Jugador1.Turno)
                        {
                            this.partida.Jugador1.TrucoCantado = this.estadoTruco;
                        }
                        else
                        {
                            this.partida.Jugador2.TrucoCantado = this.estadoTruco;
                        }
                    }
                }
            }

            if (!quiso)
            {
                if (this.partida.Jugador1.Turno)
                {
                    this.manosGanadasJ1 = 2;
                }
                else
                {
                    this.manosGanadasJ2 = 2;
                }

                this.FinDeRonda?.Invoke(sender, e);
            }

            this.BotonPresionado?.Invoke(sender, e);
        }

        private void btnFalta_Click(object sender, EventArgs e)
        {
            if (!this.estadoEnvido.HasValue)
            {
                this.estadoEnvido = ETantos.FaltaEnvido;
            }
            else
            {
                switch (this.estadoEnvido.ToString())
                {
                    case "Envido":
                        this.estadoEnvido = ETantos.Envido_FaltaEnvido;
                        break;
                    case "RealEnvido":
                        this.estadoEnvido = ETantos.RealEnvido_FaltaEnvido;
                        break;
                    case "Envido_Envido":
                        this.estadoEnvido = ETantos.Envido_Envido_FaltaEnvido;
                        break;
                    case "Envido_RealEnvido":
                        this.estadoEnvido = ETantos.Envido_RealEnvido_FaltaEnvido;
                        break;
                    case "Envido_Envido_RealEnvido":
                        this.estadoEnvido = ETantos.Envido_Envido_RealEnvido_FaltaEnvido;
                        break;
                }
            }

            this.BotonPresionado?.Invoke(sender, e);
        }

        private void btnRealEnvido_Click(object sender, EventArgs e)
        {
            if (!this.estadoEnvido.HasValue)
            {
                this.estadoEnvido = ETantos.RealEnvido;
            }
            else
            {
                if (this.estadoEnvido == ETantos.Envido)
                {
                    this.estadoEnvido = ETantos.Envido_RealEnvido;
                }
                else
                {
                    if (this.estadoEnvido == ETantos.Envido_Envido)
                    {
                        this.estadoEnvido = ETantos.Envido_Envido_RealEnvido;
                    }
                }
            }

            this.BotonPresionado?.Invoke(sender, e);
        }

        private void btnEnvido_Click(object sender, EventArgs e)
        {
            if (!this.estadoEnvido.HasValue)
            {
                this.estadoEnvido = ETantos.Envido;
            }
            else
            {
                if (this.estadoEnvido == ETantos.Envido)
                {
                    this.estadoEnvido = ETantos.Envido_Envido;
                }
            }

            this.BotonPresionado?.Invoke(sender, e);
        }

        private void btnQuiero_Click(object sender, EventArgs e)
        {
            if (this.estadoEnvido.HasValue)
            {
                Dictionary<Jugador, int> aux = new Ronda(this.partida).ObtenerGanadorEnvido();
                Jugador j = aux.Keys.First();

                if (this.partida.Jugador1 == j)
                {
                    if (this.estadoEnvido.ToString().Contains("FaltaEnvido"))
                    {
                        this.partida.PtsJugador1 += this.partida.ValoresEnvido[this.estadoEnvido].Item2 - this.partida.PtsJugador2;
                    }
                    else
                    {
                        this.partida.PtsJugador1 += this.partida.ValoresEnvido[this.estadoEnvido].Item2;
                    }
                }
                else
                {
                    if (this.estadoEnvido.ToString().Contains("FaltaEnvido"))
                    {
                        this.partida.PtsJugador2 += this.partida.ValoresEnvido[this.estadoEnvido].Item2 - this.partida.PtsJugador1;
                    }
                    else
                    {
                        this.partida.PtsJugador2 += this.partida.ValoresEnvido[this.estadoEnvido].Item2;
                    }
                }

                this.ptsJ1.Text = this.partida.PtsJugador1.ToString();
                this.ptsJ2.Text = this.partida.PtsJugador2.ToString();

                this.estadoEnvido = null;
                this.btnTruco.Enabled = true;
                this.btnEnvido.Enabled = false;
                this.btnRealEnvido.Enabled = false;
                this.btnFalta.Enabled = false;
            }
        }

        private void btnNoQuiero_Click(object sender, EventArgs e)
        {
            if (this.estadoEnvido.HasValue)
            {
                if (this.partida.Jugador1 == auxEnvido)
                {
                    this.partida.PtsJugador1 += this.partida.ValoresEnvido[this.estadoEnvido].Item1;
                }
                else
                {
                    this.partida.PtsJugador2 += this.partida.ValoresEnvido[this.estadoEnvido].Item1;
                }

                this.estadoEnvido = null;
                this.btnTruco.Enabled = true;
            }

            this.ptsJ1.Text = this.partida.PtsJugador1.ToString();
            this.ptsJ2.Text = this.partida.PtsJugador2.ToString();
        }

        private Jugador ObtenerGanadorDeRonda()
        {
            if (this.manosGanadasJ1 == 2)
            {
                return this.partida.Jugador1;
            }
            else
            {
                if (this.manosGanadasJ2 == 2)
                {
                    return this.partida.Jugador2;
                }
            }

            return new Jugador();
        }

        private void FrmPartida_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Partida().ModificarDatos(this.partida);
        }
    }


}
