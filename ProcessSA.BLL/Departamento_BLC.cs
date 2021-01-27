using ProcessSA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.BLL
{
    public class Departamento_BLC : Departamento_DAC
    {
        public void InsertarDepartamento(string _nom, int _area)
        {
            Departamento_DAC depto = new Departamento_DAC();
            depto.NombreDepartamento = _nom;
            depto.IdArea = _area;
            depto.Create(depto);
        }

        public DataTable ListarDepartamentos(int _area)
        {
            Area_DAC area = new Area_DAC();
            area.IdArea = _area;
            return new Departamento_DAC().ReadAll(area);
        }

        public DataTable ListarDepartamento(int _codigo)
        {
            return new Departamento_DAC().Read(_codigo);
        }

        public void ActualizarDepartamento(int _id, string _nom)
        {
            Departamento_DAC depto = new Departamento_DAC();
            depto.IdDepartamento = _id;
            depto.NombreDepartamento = _nom;
            depto.Update(depto);
        }

        public void EliminarDepartamento(int _codigo)
        {
            Departamento_DAC depto = new Departamento_DAC();
            depto.IdDepartamento = _codigo;
            depto.Delete(depto);
        }
    }
}
