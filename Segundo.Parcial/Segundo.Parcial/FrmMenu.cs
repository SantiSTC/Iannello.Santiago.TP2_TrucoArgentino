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
        private List<Sala> salasDeJuego;
        public FrmMenu()
        {
            InitializeComponent();

            salasDeJuego = new List<Sala>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario u1 = new Usuario();
            string cadena = "";

            foreach (Usuario u in u1.ObtenerDatos("usuarios")) 
            {
                cadena += u.ToString();
            }

            MessageBox.Show($"{cadena}");

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



        }
    }
}
