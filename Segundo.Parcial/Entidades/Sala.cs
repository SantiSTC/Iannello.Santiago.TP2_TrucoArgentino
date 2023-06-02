using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sala
    {
        int id;
        private Partida partida;

        public Sala(Usuario j1, Usuario j2) 
        {
            this.partida = new Partida(j1, j2);
        }

        public void IniciarPartida() 
        {
            this.partida.IniciarPartida();
        }

    }
}
