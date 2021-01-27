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
    public class Area_DAC
    {
        private int _idArea;
        private string _nombreArea;
        private int _idEmpresa;

        public Area_DAC()
        {
            Init();
        }

        public void Init()
        {
            this._idArea = 0;
            this._nombreArea = string.Empty;
            this._idEmpresa = 0;
        }

        public int IdArea { get => _idArea; set => _idArea = value; }
        public string NombreArea { get => _nombreArea; set => _nombreArea = value; }
        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }

        public void Create(Area_DAC area)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblarea.sp_create_area";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxArea";
                parametro.Value = area.NombreArea;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmpresa";
                parametro.Value = area.IdEmpresa;
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
                comando.CommandText = "pkg_crud_tblarea.sp_read_area";

                OracleParameter parametro = comando.CreateParameter();
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                parametro.ParameterName = "auxArea";
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

        public DataTable ReadAll(Empresa_DAC empresa)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblarea.sp_readAll_area";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                
                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmpresa";
                parametro.Value = empresa.IdEmpresa;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Area_DAC area)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblarea.sp_update_area";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "aux_codigo";
                parametro.Value = area.IdArea;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_area";
                parametro.Value = area.NombreArea;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Area_DAC area)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblarea.sp_delete_area";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = area.IdArea;
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
