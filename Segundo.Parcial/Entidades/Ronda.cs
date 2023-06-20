using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ronda
    {
        private Partida partida;

        public Ronda() { }

        public Ronda(Partida p) 
        {
            this.partida = p;
        }

        public void IniciarMano() 
        {
            this.partida.RepartirCartas();
        }

        public int CalcularEnvido(Jugador j)
        {
            int pts;

            if (j.Cartas[0] == j.Cartas[1] && j.Cartas[1] == j.Cartas[2])
            {
                if (j.Cartas[0] < j.Cartas[1] && j.Cartas[0] < j.Cartas[2])
                {
                    pts = j.Cartas[1].ValorEnvido + j.Cartas[2].ValorEnvido + 20;
                }
                else
                {
                    if (j.Cartas[1] < j.Cartas[0] && j.Cartas[1] < j.Cartas[2])
                    {
                        pts = j.Cartas[0].ValorEnvido + j.Cartas[2].ValorEnvido + 20;
                    }
                    else
                    {
                        pts = j.Cartas[1].ValorEnvido + j.Cartas[0].ValorEnvido + 20;
                    }
                }
            }
            else
            {
                if (j.Cartas[0] == j.Cartas[1]) 
                {
                    pts = j.Cartas[1].ValorEnvido + j.Cartas[0].ValorEnvido + 20;
                }
                else
                {
                    if(j.Cartas[0] == j.Cartas[2])
                    {
                        pts = j.Cartas[0].ValorEnvido + j.Cartas[2].ValorEnvido + 20;
                    }
                    else
                    {
                        if (j.Cartas[1] == j.Cartas[2]) 
                        {
                            pts = j.Cartas[1].ValorEnvido + j.Cartas[2].ValorEnvido + 20;
                        }
                        else 
                        {
                            if (j.Cartas[0] > j.Cartas[1] && j.Cartas[0] < j.Cartas[2])
                            {
                                pts = j.Cartas[0].ValorEnvido;
                            }
                            else
                            {
                                if (j.Cartas[1] > j.Cartas[0] && j.Cartas[1] > j.Cartas[2])
                                {
                                    pts = j.Cartas[1].ValorEnvido;
                                }
                                else
                                {
                                    pts = j.Cartas[2].ValorEnvido;
                                }
                            }
                        }
                    }
                }
            }

            return pts;
        }

        public Dictionary<Jugador, int> ObtenerGanadorEnvido()
        {
            int ptsJ1 = this.CalcularEnvido(this.partida.Jugador1);
            int ptsJ2 = this.CalcularEnvido(this.partida.Jugador2);
            Jugador aux;
            Dictionary<Jugador, int> diccionario = new Dictionary<Jugador, int>();

            if (ptsJ1 > ptsJ2)
            {
                aux = this.partida.Jugador1;
                diccionario.Add(aux, ptsJ1);
            }
            else 
            {
                aux = this.partida.Jugador2;
                diccionario.Add(aux, ptsJ2);
            }
            
            return diccionario;
        }

        public Carta ObtenerGanadorMano(Carta c1, Carta c2)
        {
            Carta aux = null;

            if(c1.ValorTruco > c2.ValorTruco)
            {
                aux = c1;
            }
            else
            {
                if (c1.ValorTruco < c2.ValorTruco)
                {
                    aux = c2;
                }
            }

            return aux;
        }

    }
}
