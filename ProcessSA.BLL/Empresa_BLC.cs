using ProcessSA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.BLL
{
    public class Empresa_BLC
    {
        public void InsertarEmpresa(int _rut, char _dv, string _nom, string _rzn, string _dir, string _eml)
        {
            Empresa_DAC empresa = new Empresa_DAC();
            empresa.Rut = _rut;
            empresa.DvRut = _dv;
            empresa.Nombre = _nom;
            empresa.RazonSocial = _rzn;
            empresa.Direccion = _dir;
            empresa.Email = _eml;
            empresa.Create(empresa);
        }

        public DataTable ListarEmpresas()
        {
            return new Empresa_DAC().ReadAll();
        }

        public DataTable ListarEmpresa(int _codigo)
        {
            return new Empresa_DAC().Read(_codigo);
        }

        public void ActualizarEmpresa(int _id, int _rut, char _dv, string _nom, string _rzn, string _dir, string _eml)
        {
            Empresa_DAC empresa = new Empresa_DAC();
            empresa.IdEmpresa = _id;
            empresa.Rut = _rut;
            empresa.DvRut = _dv;
            empresa.Nombre = _nom;
            empresa.RazonSocial = _rzn;
            empresa.Direccion = _dir;
            empresa.Email = _eml;
            empresa.Update(empresa);
        }

        public void EliminarEmpresa(int _codigo)
        {
            Empresa_DAC empresa = new Empresa_DAC();
            empresa.IdEmpresa = _codigo;
            empresa.Delete(empresa);
        }
    }
}
