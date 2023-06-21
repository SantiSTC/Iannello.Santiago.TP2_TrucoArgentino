using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public abstract class ConexionSQL<T>
    {
        private static string? cadena_conexion;
        private SqlConnection? conexion;
        protected SqlCommand? comando;
        protected SqlDataReader? lector;

        protected abstract List<T> CrearLista();
        protected abstract T CrearObjeto();
        protected abstract void InicializarParametros_db(T item);
        protected abstract void ModificarParametros_db(T item);

        static ConexionSQL() 
        {
            ConexionSQL<T>.cadena_conexion = @"Server=LAB6PC30;User ID=sa;Password=alumno;Database=db_truco;Trusted_Connection=True;";
            //ConexionSQL<T>.cadena_conexion = @"Server=localhost;Database=db_truco;Trusted_Connection=True;";
        }

        public ConexionSQL() 
        {
            this.conexion = new SqlConnection(ConexionSQL<T>.cadena_conexion);
        }

        public bool ProbarConexion()
        {
            bool retorno = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

        public List<T> ObtenerDatos(string nombreTabla) 
        {
            List<T> lista = new List<T>();

            try
            {
                if(this.ProbarConexion()) 
                {
                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = $"SELECT * FROM {nombreTabla}";
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    lista = this.CrearLista();

                    this.lector.Close();

                }
            }
            catch
            {
                lista = new List<T>();
            }
            finally 
            {
                if (this.conexion.State == ConnectionState.Open) 
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        public T ObtenerDatos(string nombreTabla, int id) 
        {
            T? item = default(T);

            try
            {
                if (this.ProbarConexion())
                {
                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;

                    this.comando.Parameters.AddWithValue("@id", id);

                    this.comando.CommandText = $"SELECT * FROM {nombreTabla} WHERE id = @id";
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    item = this.CrearObjeto();

                    this.lector.Close();

                }
            }
            catch
            {
                return item; 
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return item;
        }

        public bool AgregarDatos(T item) 
        {
            bool retorno = true;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;

                InicializarParametros_db(item);

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    retorno = false;
                }
            }
            catch
            {
                retorno = false;
            }
            finally 
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

        public bool ModificarDatos(T item) 
        {
            bool retorno = true;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;

                ModificarParametros_db(item);

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    retorno = false;
                }
            }
            catch 
            {
                retorno = false;
            }
            finally 
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

        public bool EliminarDatos(int id, string nombreTabla) 
        {
            bool retorno = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@id", id);

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"DELETE FROM {nombreTabla} WHERE id = @id";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    retorno = false;
                }
            }
            catch
            {
                retorno = false;
            }
            finally 
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return retorno;
        }

    }
}



