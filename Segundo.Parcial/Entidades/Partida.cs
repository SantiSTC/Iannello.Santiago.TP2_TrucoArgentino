using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Partida : ConexionSQL<Partida>
    {
        private int id;
        private Jugador jugador1;
        private Jugador jugador2;
        private int ptsJugador1;
        private int ptsJugador2;
        private bool enCurso;
        private List<Carta> mazo;
        private Dictionary<ETantos, (int, int)> valoresEnvido;

        public int ID { get { return this.id; } }
        public Jugador Jugador1 { get { return this.jugador1; } set { this.jugador1 = value; } }
        public Jugador Jugador2 { get { return this.jugador2; } set { this.jugador2 = value; } }
        public bool EnCurso { get { return this.enCurso; } set { this.enCurso = value; } }
        public int PtsJugador1 { get { return this.ptsJugador1; } set { this.ptsJugador1 = value; } }
        public int PtsJugador2 { get { return this.ptsJugador2; } set { this.ptsJugador2 = value; } }
        public Dictionary<ETantos, (int, int)> ValoresEnvido { get { return this.valoresEnvido; } set { this.valoresEnvido = value; } }

        public Partida() 
        {
            this.jugador1 = new Jugador();
            this.jugador2 = new Jugador();
            this.enCurso = false;
            valoresEnvido = new Dictionary<ETantos, (int, int)>();
        }

        public Partida(Jugador j1, Jugador j2)
        {
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.enCurso = false;
            valoresEnvido = new Dictionary<ETantos, (int, int)>();
        }

        public Partida(int id, Jugador j1, Jugador j2, int ptsJugador1, int ptsJugador2, bool enCurso)
        {
            this.id = id;
            this.jugador1 = j1;
            this.jugador2 = j2;
            this.ptsJugador1 = ptsJugador1;
            this.ptsJugador2 = ptsJugador2;
            this.enCurso = enCurso;
            valoresEnvido = new Dictionary<ETantos, (int, int)>();
        }

        protected override List<Partida> CrearLista()
        {
            List<Partida> aux = new List<Partida>();
            Jugador manejador = new Jugador();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                Jugador jugador1 = manejador.ObtenerDatos("usuarios", (int)lector["idJugador1"]);
                Jugador jugador2 = manejador.ObtenerDatos("usuarios", (int)lector["idJugador2"]);
                int ptsJugador1 = (int)lector["ptsJugador1"];
                int ptsJugador2 = (int)lector["ptsJugador2"];
                bool enCurso = (bool)lector["enCurso"];

                aux.Add(new Partida(id, jugador1, jugador2, ptsJugador1, ptsJugador2, enCurso));
            }

            return aux;
        }

        protected override void InicializarParametros_db(Partida partida)
        {
            this.comando.Parameters.AddWithValue("@jugador1", partida.jugador1);
            this.comando.Parameters.AddWithValue("@jugador2", partida.jugador2);
            this.comando.Parameters.AddWithValue("@enCurso", partida.enCurso);
            
            string comando = "INSERT INTO partidas (jugador1, jugador2, enCurso) VALUES(@jugador1, @jugador2, @enCurso)";

            this.comando.CommandText = comando;
        }

        protected override void ModificarParametros_db(Partida partida) 
        {
            this.comando.Parameters.AddWithValue("@jugador1", partida.jugador1);
            this.comando.Parameters.AddWithValue("@jugador2", partida.jugador2);
            this.comando.Parameters.AddWithValue("@enCurso", partida.enCurso);

            string comando = $"UPDATE partidas SET jugador1 = @jugador1, jugador2 = @jugador2, enCurso = @enCurso WHERE id = {partida.id}";

            this.comando.CommandText = comando;
        }

        protected override Partida CrearObjeto() 
        {
            Partida aux = new Partida();
            Jugador manejador = new Jugador();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                Jugador jugador1 = manejador.ObtenerDatos("usuarios", (int)lector["idJugador1"]);
                Jugador jugador2 = manejador.ObtenerDatos("usuarios", (int)lector["idJugador2"]);
                int ptsJugador1 = (int)lector["ptsJugador1"];
                int ptsJugador2 = (int)lector["ptsJugador2"];
                bool enCurso = (bool)lector["enCurso"];

                aux = new Partida(id, jugador1, jugador2, ptsJugador1, ptsJugador2, enCurso);
            }

            return aux;
        }

        public void IniciarPartida(string path) 
        {
            this.enCurso = true;
            this.jugador1.PartidasJugadas += 1;
            this.jugador2.PartidasJugadas += 1;
            this.mazo = Deserializacion.Deserializar(path);
            this.valoresEnvido = Partida.AsignarValoresEnvido();
        }

        public void RepartirCartas() 
        {
            Random random = new Random();
            Carta aux;

            for(int i = 0; i < 3; i++) 
            {
                int index = random.Next(0, 40);
                aux = this.mazo[index];

                while (jugador1.Cartas.Contains(aux)) 
                {
                    index = random.Next(0, 40);
                    aux = this.mazo[index];
                }

                jugador1.Cartas.Add(aux);
            }
            for (int i = 0; i < 3; i++) 
            {
                int index = random.Next(0, 40);
                aux = this.mazo[index];

                while (jugador1.Cartas.Contains(aux) || jugador2.Cartas.Contains(aux))
                {
                    index = random.Next(0, 40);
                    aux = this.mazo[index];
                }

                jugador2.Cartas.Add(aux);
            }
        }

        public override string ToString()
        {
            return $"{this.id} - {this.enCurso} \n{this.jugador1} - {this.ptsJugador1}\n{this.jugador2} - {this.ptsJugador2}";
        }


        private static Dictionary<ETantos, (int, int)> AsignarValoresEnvido() 
        {
            Dictionary<ETantos, (int, int)> aux = new Dictionary<ETantos, (int, int)>();

            foreach (ETantos tanto in Enum.GetValues(typeof(ETantos))) 
            {
                switch (tanto.ToString()) 
                {
                    case "Envido":
                        aux.Add(tanto, (1, 2));
                        break;
                    case "RealEnvido":
                        aux.Add(tanto, (1, 3));
                        break;
                    case "FaltaEnvido":
                        aux.Add(tanto, (1, 30));
                        break;
                    case "Envido_Envido":
                        aux.Add(tanto, (2, 4));
                        break;
                    case "Envido_RealEnvido":
                        aux.Add(tanto, (2, 5));
                        break;
                    case "Envido_FaltaEnvido":
                        aux.Add(tanto, (2, 30));
                        break;
                    case "RealEnvido_FaltaEnvido":
                        aux.Add(tanto, (3, 30));
                        break;
                    case "Envido_Envido_RealEnvido":
                        aux.Add(tanto, (4, 7));
                        break;
                    case "Envido_RealEnvido_FaltaEnvido":
                        aux.Add(tanto, (5, 30));
                        break;
                    case "Envido_Envido_RealEnvido_FaltaEnvido":
                        aux.Add(tanto, (7, 30));
                        break;
                }
            }

            return aux;
        }
    }
}
