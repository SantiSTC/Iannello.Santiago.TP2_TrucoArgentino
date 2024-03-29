﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carta
    {
        private EPalos palo;
        private int numero;
        private int valorTruco;
        private int valorEnvido;

        public EPalos Palo { get { return this.palo; } set { this.palo = value; } }
        public int Numero { get { return this.numero; } set { this.numero = value; } }
        public int ValorTruco { get {  return this.valorTruco; } set { this.valorTruco = value; } }
        public int ValorEnvido { get {  return this.valorEnvido; } set { this.valorEnvido = value; } }

        public Carta() { }

        public Carta(EPalos palo, int numero, int valorTruco, int valorEnvido)
        {
            Palo = palo;
            Numero = numero;
            ValorTruco = valorTruco;
            ValorEnvido = valorEnvido;
        }

        public static bool operator >(Carta a, Carta b) 
        {
            return a.valorEnvido > b.valorEnvido;
        }

        public static bool operator <(Carta a, Carta b)
        {
            return a.valorEnvido < b.valorEnvido;
        }

        public static bool operator ==(Carta a, Carta b) 
        {
            return a.palo == b.palo;
        }

        public static bool operator !=(Carta a, Carta b) 
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"Palo: {this.palo} - Numero: {this.numero}\n";
        }
    }
}
