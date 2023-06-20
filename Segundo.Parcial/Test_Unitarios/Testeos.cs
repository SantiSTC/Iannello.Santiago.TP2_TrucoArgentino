using Entidades;

namespace Test_Unitarios
{
    [TestClass]
    public class Testeos
    {
        [TestMethod]
        public void VerificarDeserializar()
        {
            List<Carta> lista = new List<Carta>();

            lista = Deserializacion.Deserializar("@\"\\Cartas:Serializadas\\cartas.json\";"); 

            Assert.IsFalse(lista.Count > 0);
        }

        [TestMethod]
        public void VerificarTraerUnDato() 
        {
            Jugador manejador = new Jugador();
            Jugador j = new Jugador();

            j = manejador.ObtenerDatos("usuarios", 1);

            Assert.IsTrue(j is not null);
        }

        [TestMethod]
        public void VerificarTraerLista()
        {
            Jugador manejador = new Jugador();
            List<Jugador> lista = new List<Jugador>();

            lista = manejador.ObtenerDatos("usuarios");

            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void VerificarTraerUnDato_Falla()
        {
            Jugador manejador = new Jugador();
            Jugador j = null;
            Jugador j2 = new Jugador();

            j = manejador.ObtenerDatos("usuarios", -1);

            Assert.IsTrue(j == j2);
        }

        [TestMethod]
        public void VerificarTraerLista_Falla()
        {
            Jugador manejador = new Jugador();
            List<Jugador> lista = new List<Jugador>();

            lista = manejador.ObtenerDatos("usuario");

            Assert.IsFalse(lista.Count > 0);
        }

        [TestMethod]
        public void VerificarCrearJugador() 
        {
            int id = 101;
            string contrasenia = "aaa111bbb";
            string nombre = "Pablo";
            int partidasJugadas = 1000;
            int partidasGanadas = 1000;

            Jugador j = new Jugador(id, contrasenia, nombre, partidasJugadas, partidasGanadas);

            Assert.IsTrue(j.ID == id && j.Contrasenia == contrasenia && j.Nombre == nombre && j.PartidasJugadas == partidasJugadas && j.PartidasGanadas == partidasGanadas);
        }

        [TestMethod]
        public void VerificarCrearPartida()
        {
            int id = 101;
            Jugador j1 = new Jugador("Jose", "123");
            Jugador j2 = new Jugador("Marta", "456");
            int ptsJugador1 = 29;
            int ptsJugador2 = 1;
            bool enCurso = true;

            Partida p = new Partida(id, j1, j2, ptsJugador1, ptsJugador2, enCurso);

            Assert.IsTrue(p.ID == id && p.Jugador1 == j1 && p.Jugador2 == j2 && p.PtsJugador1 == ptsJugador1 && p.PtsJugador2 == ptsJugador2 && p.EnCurso == enCurso);
        }

        [TestMethod]
        public void VerificarGanadorDeMano() 
        {
            Carta c1 = new Carta(EPalos.Espada, 1, 14, 1);
            Carta c2 = new Carta(EPalos.Basto, 1, 13, 1);

            Carta ganador = new Ronda().ObtenerGanadorMano(c1, c2);

            Assert.IsTrue(ganador == c1);
        }

        [TestMethod]
        public void VerificarGanadorDeEnvido()
        {
            Jugador j1 = new Jugador("Pedro", "sete");
            Jugador j2 = new Jugador("Laura", "vela");

            Carta c1 = new Carta(EPalos.Espada, 1, 0, 1);
            Carta c2 = new Carta(EPalos.Basto, 1, 0, 1);
            Carta c3 = new Carta(EPalos.Espada, 2, 0, 2);
            Carta c4 = new Carta(EPalos.Oro, 12, 0, 0);
            Carta c5 = new Carta(EPalos.Copa, 5, 0, 5);
            Carta c6 = new Carta(EPalos.Copa, 10, 0, 0);

            List<Carta> lista1 = new List<Carta>() {c1, c2, c3};
            List<Carta> lista2 = new List<Carta>() {c4, c5, c6};

            j1.Cartas = lista1;
            j2.Cartas = lista2;

            Dictionary<Jugador, int> dicc = new Ronda(new Partida(j1, j2)).ObtenerGanadorEnvido();

            Assert.IsTrue(dicc.Keys.First() == j2);
        }
    }
}