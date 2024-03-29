﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Entidades
{
    public static class Deserializacion
    {
        private static StreamReader? reader;

        public static List<Carta> Deserializar(string path) 
        {
            List<Carta>? lista = new List<Carta>();

            try 
            {
                using(reader = new StreamReader(path)) 
                {
                    string jsonString = File.ReadAllText(path);

                    lista = JsonConvert.DeserializeObject<List<Carta>>(jsonString);
                }
            }
            catch (Exception) 
            {
                lista = new List<Carta>();
            }

            return lista;
        }
    }
}
