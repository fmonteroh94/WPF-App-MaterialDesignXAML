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
    public class Cargo_DAC
    {
        private int _idCargo;
        private string _nombreCargo;

        public Cargo_DAC()
        {
            Init();
        }

        public void Init()
        {
            this._idCargo = 0;
            this._nombreCargo = string.Empty;
        }

        public int IdCargo { get => _idCargo; set => _idCargo = value; }
        public string NombreCargo { get => _nombreCargo; set => _nombreCargo = value; }

        public void Create(Cargo_DAC cargo)
        {
            //bool validador = false;

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblcargo.sp_create_cargo";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxCargo";
                parametro.Value = cargo.NombreCargo;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);
                Conexion.EjecutarSql(comando);
                //validador = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return validador;

        }

        public DataTable Read(int codigo)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblcargo.sp_read_cargo";

                OracleParameter parametro = comando.CreateParameter();
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                parametro.ParameterName = "auxCargo";
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

        public DataTable ReadAll()
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblcargo.sp_readAll_cargo";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Cargo_DAC cargo)
        {
            //bool validador = false;

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblcargo.sp_update_cargo";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "aux_codigo";
                parametro.Value = cargo.IdCargo;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_nombre";
                parametro.Value = cargo.NombreCargo;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);
                //validador = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return validador;
        }

        public void Delete(Cargo_DAC cargo)
        {
            //bool validador = false;

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblcargo.sp_delete_cargo";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = cargo.IdCargo;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);
                Conexion.EjecutarSql(comando);
                //validador = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return validador;
        }
    }
}
