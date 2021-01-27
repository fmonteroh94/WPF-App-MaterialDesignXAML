using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ConexionBD
{
    public class Conexion
    {
        private static readonly string cadena_conexion = "DATA SOURCE=localhost:1521/xepdb1;USER ID=alumno;PASSWORD=duoc";

        public static OracleCommand CrearComandoSP()
        {
            OracleConnection conexion = new OracleConnection();
            conexion.ConnectionString = cadena_conexion;
            OracleCommand comando = new OracleCommand();
            comando = conexion.CreateCommand();
            comando.CommandType = CommandType.StoredProcedure;

            return comando;
        }

        public static OracleCommand CrearComandoQuery()
        {
            OracleConnection conexion = new OracleConnection();
            conexion.ConnectionString = cadena_conexion;
            OracleCommand comando = new OracleCommand();
            comando = conexion.CreateCommand();
            comando.CommandType = CommandType.Text;

            return comando;
        }

        public static DataTable RetornarDatos(OracleCommand comando)
        {
            DataTable tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Close();
            }
            return tabla;
        }

        public static void EjecutarSql(OracleCommand comando)
        {
            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                comando.Connection.Close();
            }
        }

        public static void AbrirConexion() 
        {
            try
            {
                OracleConnection conexion = new OracleConnection();
                conexion.ConnectionString = cadena_conexion;
                conexion.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
