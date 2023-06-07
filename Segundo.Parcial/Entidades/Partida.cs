using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Partida : ConexionSQL<Partida>
    {
        int id;
        private Usuario jugador1;
        private Usuario jugador2;
        int ptsJugador1;
        int ptsJugador2;
        private bool enCurso;
        List<Carta> mazo;

        public int ID { get { return this.id; } }
        public Usuario Jugador1 { get { return this.jugador1; } set { this.jugador1 = value; } }
        public Usuario Jugador2 { get { return this.jugador2; } set { this.jugador2 = value; } }
        public bool EnCurso { get { return this.enCurso; } set { this.enCurso = value; } }

        public Partida(Usuario j1, Usuario j2)
        {
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.enCurso = false;
        }
        public Partida(int id, Usuario j1, Usuario j2, bool enCurso)
        {
            this.id = id;
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.enCurso = enCurso;
        }

        public override List<Partida> CrearLista()
        {
            List<Partida> aux = new List<Partida>();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                Usuario jugador1 = (Usuario)lector["jugador1"];
                Usuario jugador2 = (Usuario)lector["jugador2"];
                bool enCurso = (bool)lector["enCurso"];

                aux.Add(new Partida(id, jugador1, jugador2, enCurso));
            }

            return aux;
        }

        public override void InicializarParametros_db(Partida partida)
        {
            this.comando.Parameters.AddWithValue("@jugador1", partida.jugador1);
            this.comando.Parameters.AddWithValue("@jugador2", partida.jugador2);
            this.comando.Parameters.AddWithValue("@enCurso", partida.enCurso);
            
            string comando = "INSERT INTO partidas (jugador1, jugador2, enCurso) VALUES(@jugador1, @jugador2, @enCurso)";

            this.comando.CommandText = comando;
        }

        public override void ModificarParametros_db(Partida partida) 
        {
            this.comando.Parameters.AddWithValue("@jugador1", partida.jugador1);
            this.comando.Parameters.AddWithValue("@jugador2", partida.jugador2);
            this.comando.Parameters.AddWithValue("@enCurso", partida.enCurso);

            string comando = $"UPDATE partidas SET jugador1 = @jugador1, jugador2 = @jugador2, enCurso = @enCurso WHERE id = {partida.id}";

            this.comando.CommandText = comando;
        }

        public void IniciarPartida(string path) 
        {
            this.enCurso = true;
            this.jugador1.PartidasJugadas += 1;
            this.jugador2.PartidasJugadas += 1;
            this.mazo = Deserializacion.Deserializar(path);
        }

        public void RepartirCartas() 
        {
            Random random = new Random();
            Carta aux;

            for(int i = 0; i < 3; i++) 
            {
                int index = random.Next(0, 41);
                aux = this.mazo[index];

                while (jugador1.Cartas.Contains(aux)) 
                {
                    index = random.Next(0, 41);
                    aux = this.mazo[index];
                }

                jugador1.Cartas.Add(aux);
            }
            for (int i = 0; i < 3; i++) 
            {
                int index = random.Next(0, 41);
                aux = this.mazo[index];

                while (jugador1.Cartas.Contains(aux) && jugador2.Cartas.Contains(aux))
                {
                    index = random.Next(0, 41);
                    aux = this.mazo[index];
                }

                jugador2.Cartas.Add(aux);
            }


        }



    }
}
