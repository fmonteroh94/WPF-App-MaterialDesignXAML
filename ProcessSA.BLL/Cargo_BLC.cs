using ProcessSA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.BLL
{
    public class Cargo_BLC: Cargo_DAC
    {
        public void InsertarCargo(string _nombre)
        {
            Cargo_DAC cargo = new Cargo_DAC();
            cargo.NombreCargo = _nombre;
            cargo.Create(cargo);
        }

        public DataTable ListarCargos()
        {
            return new Cargo_DAC().ReadAll();
        }

        public DataTable ListarCargo(int _codigo)
        {
            return new Cargo_DAC().Read(_codigo);
        }

        public void ActualizarCargo(int _id, string _nombre)
        {
            Cargo_DAC cargo = new Cargo_DAC();
            cargo.IdCargo = _id;
            cargo.NombreCargo = _nombre;
            cargo.Update(cargo);
        }

        public void EliminarCargo(int _codigo)
        {
            Cargo_DAC cargo = new Cargo_DAC();
            cargo.IdCargo = _codigo;
            cargo.Delete(cargo);
        }
    }
}
