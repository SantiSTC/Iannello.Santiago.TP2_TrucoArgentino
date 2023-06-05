using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sala : ConexionSQL<Sala>
    {
        int id;
        private Partida partida;

        public Sala(Usuario j1, Usuario j2) 
        {
            this.partida = new Partida(j1, j2);
        }

        public Sala(int id, Partida partida)
        {
            this.id = id;
            this.partida = partida;
        }

        public override List<Sala> CrearLista() 
        {
            List<Sala> aux = new List<Sala>();

            while (lector.Read()) 
            {
                int id = (int)lector["id"];
                Partida partida = (Partida)lector["partida"];

                aux.Add(new Sala(id, partida));
            }

            return aux;
        }

        public override void InicializarParametros_db(Sala sala) 
        {
            this.comando.Parameters.AddWithValue("partida", sala.partida);

            string comando = "INSERT INTO salas (partida) VALUES (@partida)";

            this.comando.CommandText = comando;
        }

        public override void ModificarParametros_db(Sala sala) 
        {
            this.comando.Parameters.AddWithValue("partida", sala.partida);

            string comando = $"UPDATE salas SET partida = @partida WHERE id = {sala.id}";

            this.comando.CommandText = comando;
        }

        public void IniciarPartida() 
        {
            this.partida.IniciarPartida();
        }

    }
}
