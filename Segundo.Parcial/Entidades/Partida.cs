using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Partida
    {
        int id;
        private Usuario jugador1;
        private Usuario jugador2;
        private bool enCurso;

        public Partida(Usuario j1, Usuario j2) 
        {
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.enCurso = false;
        }

        public void IniciarPartida() 
        {
            this.enCurso = true;
            this.jugador1.PartidasJugadas += 1;
            this.jugador2.PartidasJugadas += 1;

        }

    }
}
