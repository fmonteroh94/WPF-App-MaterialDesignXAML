using ProcessSA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.BLL
{
    public class Usuario_BLC : Usuario_DAC
    {
        public void InsertarUsuario(string _nombres, string _paterno, string _materno, string _usr, string _pass,
                                   string _eml, DateTime _reg, DateTime _con, int _idPer, int _idCar, int _idEmp)
        {
            Usuario_DAC usuario = new Usuario_DAC();

            usuario.Nombres = _nombres;
            usuario.Appaterno = _paterno;
            usuario.Apmaterno = _materno;
            usuario.Usuario = _usr;
            usuario.Pass = _pass;
            usuario.Correo = _eml;
            usuario.FechaRegistro = _reg;
            usuario.UltimaConexion = _con;
            usuario.IdPerfil = _idPer;
            usuario.IdCargo = _idCar;
            usuario.IdEmpresa = _idEmp;
            usuario.Create(usuario);
        }

        public DataTable ListarUsuarios()
        {
            return new Usuario_DAC().ReadAll();
        }

        public DataTable ListarUsuario(int _codigo)
        {
            return new Usuario_DAC().Read(_codigo);
        }

        public void ActualizarUsuario (int _id, string _nombres, string _paterno, string _materno, string _usr, string _pass,
                                       string _eml, int _idPer, int _idCar, int _idEmp)
        {
            Usuario_DAC usuario = new Usuario_DAC();

            usuario.IdUsuario = _id;
            usuario.Nombres = _nombres;
            usuario.Appaterno = _paterno;
            usuario.Apmaterno = _materno;
            usuario.Usuario = _usr;
            usuario.Pass = _pass;
            usuario.Correo = _eml;
            usuario.IdPerfil = _idPer;
            usuario.IdCargo = _idCar;
            usuario.IdEmpresa = _idEmp;
            usuario.Update(usuario);
        }

        public void EliminarUsuario(int _codigo)
        {
            Usuario_DAC usuario = new Usuario_DAC();
            usuario.IdUsuario = _codigo;
            usuario.Delete(usuario);
        }

        public int ValidarUsuario(string _user, string _pass) 
        {
            return new Usuario_DAC().ValidarLogin(_user, _pass);
        }

        public DataTable ListarCantidadUsuariosPerfil()
        {
            return new Usuario_DAC().CantidadUsuariosPerfil();
        }
    }
 }
