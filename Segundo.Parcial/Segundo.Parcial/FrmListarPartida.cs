using Entidades;
using MiNET.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Truco
{
    public partial class FrmListarPartida : Form, ICrud
    {
        private delegate void DelegadoGrid();
        private delegate void DelegadoPartida(Partida p);

        public FrmListarPartida()
        {
            InitializeComponent();
        }

        private void FrmListarPartida_Load(object sender, EventArgs e)
        {
            Task.Run(() => { this.CrearGrid(); });
        }

        public void CrearGrid()
        {
            if (this.InvokeRequired)
            {
                DelegadoGrid callback = new DelegadoGrid(this.CrearGrid);
                this.BeginInvoke(callback);
            }
            else
            {
                dgvLista.Rows.Clear();

                for (int i = 0; i < new Partida().GetType().GetProperties().Length; i++)
                {
                    string propiedad = new Partida().GetType().GetProperties()[i].Name;

                    if (propiedad == "ValoresEnvido" || propiedad == "ValoresTruco")
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

            foreach (Partida item in new Partida().ObtenerDatos("partidas"))
            {
                if (item.Jugador1 == FrmLogin.UsuarioLogueado)
                {
                    string[] fila = new string[dgvLista.Columns.Count];

                    for (int i = 0; i < dgvLista.Columns.Count; i++)
                    {
                        string propiedad = (item.GetType().GetProperty(dgvLista.Columns[i].Name).GetValue(item)).ToString();

                        if (propiedad == "ValoresEnvido" || propiedad == "ValoresTruco")
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCrearPartida fm = new FrmCrearPartida(new Jugador().ObtenerDatos("usuarios"));
            this.Hide();
            if (fm.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvLista.SelectedRows[0];
            DataGridViewCell celda = fila.Cells["ID"];
            int id = int.Parse(celda.Value.ToString());

            Partida p = new Partida().ObtenerDatos("partidas", id);

            if (p.EnCurso)
            {
                this.AbrirPartida(p);
            }
            else 
            {
                MessageBox.Show("La partida seleccionada ya finalizó.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirPartida(Partida p) 
        {
            if (this.InvokeRequired)
            {
                DelegadoPartida callback = new DelegadoPartida(AbrirPartida);
                this.BeginInvoke(callback);
            }
            else 
            {
                FrmPartida fm = new FrmPartida(p);
                fm.FormClosed += this.CapturarCierrePartida;
                fm.Show();
            }
        }

        private void CapturarCierrePartida(object sender, EventArgs e) 
        {
            this.ActualizarGrid();
        }
    }
}
