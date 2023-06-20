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
        private string contrasenia;
        private string nombre;
        private int partidasJugadas;
        private int partidasGanadas;
        List<Carta> cartas;
        ETruco? trucoCantado;
        private bool turno;

        public int ID { get { return this.id; } }
        public string Contrasenia { get { return this.contrasenia; } }
        public string Nombre { get {  return this.nombre; } set {  this.nombre = value; } }
        public int PartidasJugadas { get { return this.partidasJugadas; } set { this.partidasJugadas = value; } }
        public int PartidasGanadas { get { return this.partidasGanadas; } set { this.partidasGanadas = value; } }
        public List<Carta> Cartas { get { return this.cartas; } set { this.cartas = value; } }
        public ETruco? TrucoCantado { get { return this.trucoCantado; } set { this.trucoCantado = value; } }
        public bool Turno { get { return this.turno; } set { this.turno = value; } }

        public event EventHandler<Carta> CartaTirada;

        public Jugador() { }

        public Jugador(string nombre, string contrasenia) 
        {
            this.nombre = nombre;
            this.contrasenia = contrasenia;
            this.partidasJugadas = 0;
            this.PartidasGanadas = 0;
            cartas = new List<Carta>();
            this.CartaTirada += Jugador_CartaTirada;
        }

        public Jugador(string contrasenia ,string nombre, int partidasJugadas, int partidasGanadas) 
        {
            this.contrasenia = contrasenia;
            this.nombre = nombre;
            this.partidasJugadas = partidasJugadas;
            this.partidasGanadas = partidasGanadas;
            cartas = new List<Carta>();
            this.CartaTirada += Jugador_CartaTirada;
        }

        public Jugador(int id, string contrasenia, string nombre, int partidasJugadas, int partidasGanadas) : this(contrasenia, nombre, partidasJugadas, partidasGanadas)
        {
            this.id = id;
        }

        protected override List<Jugador> CrearLista() 
        {
            List<Jugador> aux = new List<Jugador>();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                string contrasenia = lector["contrasenia"].ToString();
                string nombre = lector["nombre"].ToString();
                int partidasJugadas = (int)lector["partidasJugadas"];
                int partidasGanadas = (int)lector["partidasGanadas"];

                aux.Add(new Jugador(id, contrasenia, nombre, partidasJugadas, partidasGanadas));
            }

            return aux;
        }

        protected override void InicializarParametros_db(Jugador user) 
        {
            this.comando.Parameters.AddWithValue("@contrasenia", user.contrasenia);
            this.comando.Parameters.AddWithValue("@nombre", user.nombre);
            this.comando.Parameters.AddWithValue("@partidasJugadas", user.partidasJugadas);
            this.comando.Parameters.AddWithValue("@partidasGanadas", user.partidasGanadas);

            string comando = $"INSERT INTO usuarios (contrasenia ,nombre, partidasJugadas, partidasGanadas) VALUES(@contrasenia ,@nombre, @partidasJugadas, @partidasGanadas)";

            this.comando.CommandText = comando;
        }

        protected override void ModificarParametros_db(Jugador user) 
        {
            this.comando.Parameters.AddWithValue("@contrasenia", user.contrasenia);
            this.comando.Parameters.AddWithValue("@nombre", user.nombre);
            this.comando.Parameters.AddWithValue("@partidasJugadas", user.partidasJugadas);
            this.comando.Parameters.AddWithValue("@partidasGanadas", user.partidasGanadas);

            string comando = $"UPDATE usuarios SET contrasenia = @contrasenia ,nombre = @nombre, partidasJugadas = @partidasJugadas, partidasGanadas = @partidasGanadas WHERE id = {user.id}";
        
            this.comando.CommandText = comando;
        }

        protected override Jugador CrearObjeto()
        {
            Jugador aux = new Jugador();

            while (lector.Read())
            {
                int id = (int)lector["id"];
                string contrasenia = lector["contrasenia"].ToString();
                string nombre = lector["nombre"].ToString();
                int partidasJugadas = (int)lector["partidasJugadas"];
                int partidasGanadas = (int)lector["partidasGanadas"];

                aux = new Jugador(id, contrasenia, nombre, partidasJugadas, partidasGanadas);
            }

            return aux;
        }

        public void TirarCarta(Carta c) 
        {
            this.CartaTirada?.Invoke(this, c);
        }

        private void Jugador_CartaTirada(object? sender, Carta e)
        {
            
        }

        public override string ToString()
        {
            return $"ID: {this.id} - {this.nombre}";
        }

        public static bool operator ==(Jugador j1, Jugador j2) 
        {
            if (j1 is null || j2 is null) 
            {
                return false;
            }

            return j1.nombre == j2.nombre && j1.contrasenia == j2.contrasenia;
        }

        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Jugador)
            {
                retorno = (Jugador)obj == this;
            }

            return retorno;
        }
    }
}
