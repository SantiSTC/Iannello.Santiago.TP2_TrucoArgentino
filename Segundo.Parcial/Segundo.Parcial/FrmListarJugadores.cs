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
    public partial class FrmListarJugadores : Form
    {
        private List<Jugador> lista;
        private delegate void Delegado();

        public FrmListarJugadores(List<Jugador> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void FrmListarJugadores_Load(object sender, EventArgs e)
        {
            Task.Run(() => { CrearGrid(); });
        }

        public void CrearGrid()
        {
            if (this.InvokeRequired)
            {
                Delegado callback = new Delegado(this.CrearGrid);
                this.BeginInvoke(callback);
            }
            else
            {
                dgvLista.Rows.Clear();

                for (int i = 0; i < new Jugador().GetType().GetProperties().Length; i++)
                {
                    string propiedad = new Jugador().GetType().GetProperties()[i].Name;
                    if (propiedad == "Contrasenia" || propiedad == "Turno" || propiedad == "Cartas" || propiedad == "TrucoCantado")
                    {
                        continue;
                    }
                    else
                    {
                        dgvLista.Columns.Add(propiedad, propiedad);
                    }
                }

                ActualizarGrid();
            }
        }

        public void ActualizarGrid()
        {
            dgvLista.Rows.Clear();

            foreach (Jugador item in this.lista)
            {
                string[] fila = new string[dgvLista.Columns.Count];

                for (int i = 0; i < dgvLista.Columns.Count; i++)
                {
                    string propiedad = (item.GetType().GetProperty(dgvLista.Columns[i].Name).GetValue(item)).ToString();

                    if (propiedad == "Contrasenia" || propiedad == "Turno" || propiedad == "Cartas" || propiedad == "TrucoCantado")
                    {
                        continue;
                    }
                    else
                    {
                        fila[i] = propiedad;
                    }
                }

                dgvLista.Rows.Add(fila);
            }
        }


    }
}
