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
    public class Departamento_DAC
    {
        private int _idDepartamento;
        private string _nombreDepartamento;
        private int _idArea;

        public Departamento_DAC()
        {
            Init();
        }

        public void Init()
        {
            this._idDepartamento = 0;
            this._nombreDepartamento = string.Empty;
            this._idArea = 0;
        }

        public int IdDepartamento { get => _idDepartamento; set => _idDepartamento = value; }
        public string NombreDepartamento { get => _nombreDepartamento; set => _nombreDepartamento = value; }
        public int IdArea { get => _idArea; set => _idArea = value; }

        public void Create(Departamento_DAC departamento)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tbldepartamento.sp_create_departamento";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxDepartamento";
                parametro.Value = departamento.NombreDepartamento;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxArea";
                parametro.Value = departamento.IdArea;
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
                comando.CommandText = "pkg_crud_tbldepartamento.sp_read_departamento";

                OracleParameter parametro = comando.CreateParameter();
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                parametro.ParameterName = "auxDepartamento";
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

        public DataTable ReadAll(Area_DAC area)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tbldepartamento.sp_readAll_departamento";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxArea";
                parametro.Value = area.IdArea;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Departamento_DAC departamento)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tbldepartamento.sp_update_departamento";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "aux_codigo";
                parametro.Value = departamento.IdDepartamento;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_nombre";
                parametro.Value = departamento.NombreDepartamento;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Departamento_DAC departamento)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tbldepartamento.sp_delete_departamento";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = departamento.IdDepartamento;
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
