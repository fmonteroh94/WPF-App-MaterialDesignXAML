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
    public class Usuario_DAC
    {
        private int _idUsuario;
        private string _nombres;
        private string _appaterno;
        private string _apmaterno;
        private string _usuario;
        private string _pass;
        private string _correo;
        private int _estado;
        private DateTime _fechaRegistro;
        private DateTime _ultimaConexion;
        private int _idPerfil;
        private int _idCargo;
        private int _idEmpresa;

        public Usuario_DAC()
        {
            Init();
        }

        public void Init()
        {
            this._idUsuario = 0;
            this._nombres = string.Empty;
            this._appaterno = string.Empty;
            this._apmaterno = string.Empty;
            this._usuario = string.Empty;
            this._pass = string.Empty;
            this._correo = string.Empty;
            this._estado = 1;
            this._fechaRegistro = DateTime.Now;
            this._ultimaConexion = DateTime.Now;
            this._idPerfil = 0;
            this._idCargo = 0;
            this._idEmpresa = 0;
        }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Appaterno { get => _appaterno; set => _appaterno = value; }
        public string Apmaterno { get => _apmaterno; set => _apmaterno = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public int Estado { get => _estado; set => _estado = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
        public DateTime UltimaConexion { get => _ultimaConexion; set => _ultimaConexion = value; }
        public int IdPerfil { get => _idPerfil; set => _idPerfil = value; }
        public int IdCargo { get => _idCargo; set => _idCargo = value; }
        public int IdEmpresa { get => _idEmpresa; set => _idEmpresa = value; }

        public void Create(Usuario_DAC usuario)
        {

            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblusuario.sp_create_usuario";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxNombres";
                parametro.Value = usuario.Nombres;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxPaterno";
                parametro.Value = usuario.Appaterno;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxMaterno";
                parametro.Value = usuario.Apmaterno;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxUsername";
                parametro.Value = usuario.Usuario;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxPass";
                parametro.Value = usuario.Pass;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmail";
                parametro.Value = usuario.Correo;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxRegistro";
                parametro.Value = usuario.FechaRegistro;
                parametro.OracleDbType = OracleDbType.Date;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxConexion";
                parametro.Value = usuario.UltimaConexion;
                parametro.OracleDbType = OracleDbType.Date;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxPerfil";
                parametro.Value = usuario.IdPerfil;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxCargo";
                parametro.Value = usuario.IdCargo;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmpresa";
                parametro.Value = usuario.IdEmpresa;
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
                comando.CommandText = "pkg_crud_tblusuario.sp_read_usuario";

                OracleParameter parametro = comando.CreateParameter();
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                parametro.ParameterName = "auxUsuario";
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
                comando.CommandText = "pkg_crud_tblusuario.sp_readAll_usuario2";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Usuario_DAC usuario)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblusuario.sp_update_usuario";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "auxCodigo";
                parametro.Value = usuario.IdUsuario;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxNombres";
                parametro.Value = usuario.Nombres;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxPaterno";
                parametro.Value = usuario.Appaterno;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxMaterno";
                parametro.Value = usuario.Apmaterno;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxUsername";
                parametro.Value = usuario.Usuario;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxPass";
                parametro.Value = usuario.Pass;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmail";
                parametro.Value = usuario.Correo;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxPerfil";
                parametro.Value = usuario.IdPerfil;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxCargo";
                parametro.Value = usuario.IdCargo;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxEmpresa";
                parametro.Value = usuario.IdEmpresa;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(Usuario_DAC usuario)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblusuario.sp_delete_usuario";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = usuario.IdUsuario;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);
                Conexion.EjecutarSql(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ValidarLogin(string _usr, string _pass) 
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "sp_validarlogin";

                OracleParameter parametro1 = comando.CreateParameter();
                
                parametro1.ParameterName = "auxUsuario";
                parametro1.Direction = ParameterDirection.Input;
                parametro1.Value = _usr;
                parametro1.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro1);

                OracleParameter parametro2 = comando.CreateParameter();
                parametro2.ParameterName = "auxPass";
                parametro2.Direction = ParameterDirection.Input;
                parametro2.Value = _pass;
                parametro2.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro2);
                comando.Parameters.Add("auxperfil", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                Conexion.EjecutarSql(comando);
                int perfil = int.Parse(comando.Parameters["auxperfil"].Value.ToString());
                return perfil;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CantidadUsuariosPerfil() 
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoQuery();
                comando.CommandText = "SELECT COUNT(u.idusuario) Cantidad, p.tipo Perfil FROM usuario u JOIN perfil p ON u.idperfil = p.idperfil WHERE u.estado = 1 GROUP BY u.idperfil, p.tipo";
                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
