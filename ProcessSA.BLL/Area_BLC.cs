using ProcessSA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.BLL
{
    public class Area_BLC: Area_DAC
    {
        public void InsertarArea(string _nom, int _emp)
        {
            Area_DAC area = new Area_DAC();
            area.NombreArea = _nom;
            area.IdEmpresa = _emp;
            area.Create(area);
        }

        public DataTable ListarAreas(int _codigo)
        {
            Empresa_DAC empresa = new Empresa_DAC();
            empresa.IdEmpresa = _codigo;
            return new Area_DAC().ReadAll(empresa);
        }

        public DataTable ListarArea(int _codigo)
        {
            return new Area_DAC().Read(_codigo);
        }

        public void ActualizarArea(int _id, string _nom)
        {
            Area_DAC area = new Area_DAC();
            area.IdArea = _id;
            area.NombreArea = _nom;
            area.Update(area);
        }

        public void EliminarArea(int _codigo)
        {
            Area_DAC area = new Area_DAC();
            area.IdArea = _codigo;
            area.Delete(area);
        }
    }
}
