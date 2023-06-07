using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : ConexionSQL<Usuario>
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

        public Usuario() { }

        public Usuario(string nombre) 
        {
            this.id = _ultimoID++;
            this.nombre = nombre;
            this.partidasJugadas = 0;
            this.PartidasGanadas = 0;
            cartas = new List<Carta>();
        }

        public Usuario(string nombre, int partidasJugadas, int partidasGanadas) 
        {
            this.nombre = nombre;
            this.partidasJugadas = partidasJugadas;
            this.partidasGanadas = partidasGanadas;
        }

        public Usuario(int id, string nombre, int partidasJugadas, int partidasGanadas)
        {
            this.id = id;
            this.nombre = nombre;
            this.partidasJugadas = partidasJugadas;
            this.partidasGanadas = partidasGanadas;
        }

        public override List<Usuario> CrearLista() 
        {
            List<Usuario> aux = new List<Usuario>();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                string nombre = lector["nombre"].ToString();
                int partidasJugadas = (int)lector["partidasJugadas"];
                int partidasGanadas = (int)lector["partidasGanadas"];

                aux.Add(new Usuario(id, nombre, partidasJugadas, partidasGanadas));
            }

            return aux;
        }

        public override void InicializarParametros_db(Usuario user) 
        {
            this.comando.Parameters.AddWithValue("@nombre", user.nombre);
            this.comando.Parameters.AddWithValue("@partidasJugadas", user.partidasJugadas);
            this.comando.Parameters.AddWithValue("@partidasGanadas", user.partidasGanadas);

            string comando = $"INSERT INTO usuarios (nombre, partidasJugadas, partidasGanadas) VALUES(@nombre, @partidasJugadas, @partidasGanadas)";

            this.comando.CommandText = comando;
        }

        public override void ModificarParametros_db(Usuario user) 
        {
            this.comando.Parameters.AddWithValue("@nombre", user.nombre);
            this.comando.Parameters.AddWithValue("@partidasJugadas", user.partidasJugadas);
            this.comando.Parameters.AddWithValue("@partidasGanadas", user.partidasGanadas);

            string comando = $"UPDATE usuarios SET nombre = @nombre, partidasJugadas = @partidasJugadas, partidasGanadas = @partidasGanadas WHERE id = {user.id}";
        
            this.comando.CommandText = comando;
        }

        public override string ToString()
        {
            return $"ID: {this.id}, Nombre: {this.nombre}, Jugadas: {this.partidasJugadas}, Ganadas: {this.PartidasGanadas}.\n";
        }

    }
}
