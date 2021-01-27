using ProcessSA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.BLL
{
    public class Funcion_BLC
    {
        public void InsertarFuncion(string _nom, int _depto)
        {
            Funcion_DAC funcion = new Funcion_DAC();
            funcion.NombreFuncion = _nom;
            funcion.IdDepartamento = _depto;
            funcion.Create(funcion);
        }

        public DataTable ListarFunciones(int _depto)
        {
            Departamento_DAC depto = new Departamento_DAC();
            depto.IdDepartamento = _depto;
            return new Funcion_DAC().ReadAll(depto);
        }

        public DataTable ListarFuncion(int _codigo)
        {
            return new Funcion_DAC().Read(_codigo);
        }

        public void ActualizarFuncion(int _id, string _nom)
        {
            Funcion_DAC funcion = new Funcion_DAC();
            funcion.IdFuncion = _id;
            funcion.NombreFuncion = _nom;
            funcion.Update(funcion);
        }

        public void EliminarFuncion(int _codigo)
        {
            Funcion_DAC funcion = new Funcion_DAC();
            funcion.IdFuncion = _codigo;
            funcion.Delete(funcion);
        }
    }
}
