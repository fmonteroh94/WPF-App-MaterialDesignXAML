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
    public class Empresa_DAC
    {
        private int _idEmpresa;
        private int _rut;
        private char _dvRut;
        private string _nombre;
        private string _razonSocial;
        private string _direccion;
        private string _email;

        public Empresa_DAC()
        {
            Init();
        }

        public void Init()
        {
            this._idEmpresa = 0;
            this._rut = 0;
            this._dvRut = ' ';
            this._nombre = string.Empty;
            this._razonSocial = string.Empty;
            this._direccion = string.Empty;
            this._email = string.Empty;
        }

        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }
        public int Rut { get => _rut; set => _rut = value; }
        public char DvRut { get => _dvRut; set => _dvRut = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string RazonSocial { get => _razonSocial; set => _razonSocial = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Email { get => _email; set => _email = value; }

        public void Create(Empresa_DAC empresa)
        {

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblempresa.sp_create_empresa";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxRut";
                parametro.Value = empresa.Rut;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxDvRut";
                parametro.Value = empresa.DvRut;
                parametro.OracleDbType = OracleDbType.Char;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxNombre";
                parametro.Value = empresa.Nombre;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxRazonSocial";
                parametro.Value = empresa.RazonSocial;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxDireccion";
                parametro.Value = empresa.Direccion;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmail";
                parametro.Value = empresa.Email;
                parametro.OracleDbType = OracleDbType.Varchar2;
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
                comando.CommandText = "pkg_crud_tblempresa.sp_read_empresa";

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
                comando.CommandText = "pkg_crud_tblempresa.sp_readAll_empresa";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Empresa_DAC empresa)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblempresa.sp_update_empresa";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "aux_codigo";
                parametro.Value = empresa.IdEmpresa;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_rut";
                parametro.Value = empresa.Rut;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxDvRut";
                parametro.Value = empresa.DvRut;
                parametro.OracleDbType = OracleDbType.Char;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxNombre";
                parametro.Value = empresa.Nombre;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxRazonSocial";
                parametro.Value = empresa.RazonSocial;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxDireccion";
                parametro.Value = empresa.Direccion;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmail";
                parametro.Value = empresa.Email;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(Empresa_DAC empresa)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblempresa.sp_delete_empresa";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = empresa.IdEmpresa;
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
