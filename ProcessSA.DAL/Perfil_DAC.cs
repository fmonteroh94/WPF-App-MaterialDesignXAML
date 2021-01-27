using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ConexionBD;
using System.Data;

namespace ProcessSA.DAL
{
    public class Perfil_DAC
    {
        private int _idPerfil;
        private string _tipoPerfil;

        public Perfil_DAC()
        {
            Init();
        }

        public void Init()
        {
            this._idPerfil = 0;
            this._tipoPerfil = string.Empty;
        }

        public int IdPerfil { get => _idPerfil; set => _idPerfil = value; }
        public string TipoPerfil { get => _tipoPerfil; set => _tipoPerfil = value; }

        public void Create(Perfil_DAC perfil)
        {
            //bool validador = false;

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblperfil.sp_create_perfil";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxPerfil";
                parametro.Value = perfil.TipoPerfil;
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
                comando.CommandText = "pkg_crud_tblperfil.sp_read_perfil";

                OracleParameter parametro = comando.CreateParameter();
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                parametro.ParameterName = "auxPerfil";
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
                comando.CommandText = "pkg_crud_tblperfil.sp_readAll_perfil";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Perfil_DAC perfil)
        {
            //bool validador = false;

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblperfil.sp_update_perfil";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "aux_codigo";
                parametro.Value = perfil.IdPerfil;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);
                
                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_tipo";
                parametro.Value = perfil.TipoPerfil;
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

        public void Delete(Perfil_DAC perfil)
        {
            //bool validador = false;

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblperfil.sp_delete_perfil";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = perfil.IdPerfil;
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
