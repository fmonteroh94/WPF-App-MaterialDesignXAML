using ConexionBD;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.DAL
{
    public class Funcion_DAC
    {
        private int _idFuncion;
        private string _nombreFuncion;
        private int _idDepartamento;

        public Funcion_DAC()
        {
            Init();
        }

        public void Init()
        {
            this._idFuncion = 0;
            this._nombreFuncion = string.Empty;
            this._idDepartamento = 0;
        }

        public int IdFuncion { get => _idFuncion; set => _idFuncion = value; }
        public string NombreFuncion { get => _nombreFuncion; set => _nombreFuncion = value; }
        public int IdDepartamento { get => _idDepartamento; set => _idDepartamento = value; }

        public void Create(Funcion_DAC funcion)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblfuncion.sp_create_funcion";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxFuncion";
                parametro.Value = funcion.NombreFuncion;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxDepto";
                parametro.Value = funcion.IdDepartamento;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Read(int codigo)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblfuncion.sp_read_funcion";

                OracleParameter parametro = comando.CreateParameter();
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                parametro.ParameterName = "auxFuncion";
                parametro.Direction = ParameterDirection.Input;
                parametro.Value = codigo;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);
                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ReadAll(Departamento_DAC depto)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblfuncion.sp_readAll_funcion";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxDepto";
                parametro.Value = depto.IdDepartamento;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Funcion_DAC funcion)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblfuncion.sp_update_funcion";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "aux_codigo";
                parametro.Value = funcion.IdFuncion;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_nombre";
                parametro.Value = funcion.NombreFuncion;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Funcion_DAC funcion)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblfuncion.sp_delete_funcion";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = funcion.IdFuncion;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);
                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
