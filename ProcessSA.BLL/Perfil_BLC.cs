using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessSA.DAL;

namespace ProcessSA.BLL
{
    public class Perfil_BLC : Perfil_DAC
    {
        public void InsertarPerfil(string _tipo)
        {
            Perfil_DAC perfil = new Perfil_DAC();
            perfil.TipoPerfil = _tipo;
            perfil.Create(perfil);
        }

        public DataTable ListarPerfiles()
        {
            return new Perfil_DAC().ReadAll();
        }

        public DataTable ListarPerfil(int _codigo)
        {
            return new Perfil_DAC().Read(_codigo);
        }

        public void ActualizarPerfil(int _id, string _tipo)
        {
            Perfil_DAC perfil = new Perfil_DAC();
            perfil.IdPerfil = _id;
            perfil.TipoPerfil = _tipo;
            perfil.Update(perfil);
        }

        public void EliminarPerfil(int _codigo)
        {
            Perfil_DAC perfil = new Perfil_DAC();
            perfil.IdPerfil = _codigo;
            perfil.Delete(perfil);
        }
    }
}
