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
        public FrmMenu()
        {
            InitializeComponent();

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Usuario u1 = new Usuario();
            string cadena = "";

            //foreach (Usuario u in u1.ObtenerDatos("usuarios")) 
            //{
            //    cadena += u.ToString();
            //}

            //MessageBox.Show($"{cadena}");

            //if (u1.AgregarDatos(new Usuario("Jorge", 100, 43)))
            //{
            //    cadena = "";

            //    foreach (Usuario u in u1.ObtenerDatos("usuarios"))
            //    {
            //        cadena += u.ToString();
            //    }

            //    MessageBox.Show($"{cadena}");
            //}

            //if (u1.EliminarDatos(2, "usuarios")) 
            //{
            //    cadena = "";

            //    foreach (Usuario u in u1.ObtenerDatos("usuarios"))
            //    {
            //        cadena += u.ToString();
            //    }

            //    MessageBox.Show($"{cadena}");
            //}
            //else 
            //{
            //    MessageBox.Show($"ERROR");
            //}

            //if (u1.ModificarDatos(new Usuario(1, "Mario", 100, 43)))
            //{
            //    cadena = "";

            //    foreach (Usuario u in u1.ObtenerDatos("usuarios"))
            //    {
            //        cadena += u.ToString();
            //    }

            //    MessageBox.Show($"{cadena}");
            //}

            //List<Carta> lista = new List<Carta>();

            //lista = Deserializacion.Deserializar(Application.StartupPath + @"\Cartas_Serializadas\cartas.json");

            //foreach(Carta c in lista) 
            //{
            //    cadena += c.ToString();
            //}

            Jugador j1 = new Jugador("Juan");
            Jugador j2 = new Jugador("Rafa");
            Partida p = new Partida(j1, j2);

            //p.IniciarPartida(Application.StartupPath + @"\Cartas_Serializadas\cartas.json");
            //p.RepartirCartas();

            //foreach (Carta item in p.Jugador1.Cartas)
            //{
            //    cadena += item.ToString();
            //}
            //cadena += "\n\n";
            //foreach (Carta item in p.Jugador2.Cartas)
            //{
            //    cadena += item.ToString();
            //}

            //MessageBox.Show($"{cadena}");

            FrmPartida fm = new FrmPartida(p);
            fm.Show();


        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
