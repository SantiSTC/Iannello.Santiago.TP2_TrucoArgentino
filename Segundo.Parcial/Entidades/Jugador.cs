using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : ConexionSQL<Jugador>
    {
        private int id;
        private static int _ultimoID = 0;
        private string nombre;
        private int partidasJugadas;
        private int partidasGanadas;
        List<Carta> cartas;
        private bool turno;

        public int ID { get { return this.id; } }
        public string Nombre { get {  return this.nombre; } set {  this.nombre = value; } }
        public int PartidasJugadas { get { return this.partidasJugadas; } set { this.partidasJugadas = value; } }
        public int PartidasGanadas { get { return this.partidasGanadas; } set { this.partidasGanadas = value; } }
        public List<Carta> Cartas { get { return this.cartas; } set { this.cartas = value; } }
        public bool Turno { get { return this.turno; } set { this.turno = value; } }

        public Jugador() { }

        public Jugador(string nombre) 
        {
            this.id = _ultimoID++;
            this.nombre = nombre;
            this.partidasJugadas = 0;
            this.PartidasGanadas = 0;
            cartas = new List<Carta>();
        }

        public Jugador(string nombre, int partidasJugadas, int partidasGanadas) 
        {
            this.nombre = nombre;
            this.partidasJugadas = partidasJugadas;
            this.partidasGanadas = partidasGanadas;
        }

        public Jugador(int id, string nombre, int partidasJugadas, int partidasGanadas)
        {
            this.id = id;
            this.nombre = nombre;
            this.partidasJugadas = partidasJugadas;
            this.partidasGanadas = partidasGanadas;
        }

        protected override List<Jugador> CrearLista() 
        {
            List<Jugador> aux = new List<Jugador>();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                string nombre = lector["nombre"].ToString();
                int partidasJugadas = (int)lector["partidasJugadas"];
                int partidasGanadas = (int)lector["partidasGanadas"];

                aux.Add(new Jugador(id, nombre, partidasJugadas, partidasGanadas));
            }

            return aux;
        }

        protected override void InicializarParametros_db(Jugador user) 
        {
            this.comando.Parameters.AddWithValue("@nombre", user.nombre);
            this.comando.Parameters.AddWithValue("@partidasJugadas", user.partidasJugadas);
            this.comando.Parameters.AddWithValue("@partidasGanadas", user.partidasGanadas);

            string comando = $"INSERT INTO usuarios (nombre, partidasJugadas, partidasGanadas) VALUES(@nombre, @partidasJugadas, @partidasGanadas)";

            this.comando.CommandText = comando;
        }

        protected override void ModificarParametros_db(Jugador user) 
        {
            this.comando.Parameters.AddWithValue("@nombre", user.nombre);
            this.comando.Parameters.AddWithValue("@partidasJugadas", user.partidasJugadas);
            this.comando.Parameters.AddWithValue("@partidasGanadas", user.partidasGanadas);

            string comando = $"UPDATE usuarios SET nombre = @nombre, partidasJugadas = @partidasJugadas, partidasGanadas = @partidasGanadas WHERE id = {user.id}";
        
            this.comando.CommandText = comando;
        }

        protected override Jugador CrearObjeto()
        {
            Jugador aux = new Jugador();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                string nombre = lector["nombre"].ToString();
                int partidasJugadas = (int)lector["partidasJugadas"];
                int partidasGanadas = (int)lector["partidasGanadas"];

                aux = new Jugador(id, nombre, partidasJugadas, partidasGanadas);
            }

            return aux;
        }

        public override string ToString()
        {
            return $"ID: {this.id}, Nombre: {this.nombre}, Jugadas: {this.partidasJugadas}, Ganadas: {this.PartidasGanadas}.\n";
        }

    }
}
