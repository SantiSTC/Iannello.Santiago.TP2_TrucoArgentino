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
    public partial class FrmRegistrarse : FrmLogin
    {
        public FrmRegistrarse()
        {
            InitializeComponent();
        }

        private void FrmRegistrarse_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Registrarse";
            this.button1.Text = "Registrarse";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new Jugador().AgregarDatos(new Jugador(this.txtNombre.Text, txtContrasenia.Text)))
            {
                MessageBox.Show("Se ha registrado correctamente al usuario.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                MessageBox.Show("Ha ocurrido un error al registrar al usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
