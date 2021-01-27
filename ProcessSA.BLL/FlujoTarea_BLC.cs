using ProcessSA.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSA.BLL
{
    public class FlujoTarea_BLC: FlujoTarea_DAC
    {
        public void InsertarFlujo(string _nombre, DateTime _fecha)
        {
            FlujoTarea_DAC flujo = new FlujoTarea_DAC();
            flujo.NombreFlujo = _nombre;
            flujo.InicioFlujo = _fecha;
            flujo.Create(flujo);
        }

        public DataTable ListarFlujos()
        {
            return new FlujoTarea_DAC().ReadAll();
        }

        public DataTable ListarFlujo(int _codigo)
        {
            return new FlujoTarea_DAC().Read(_codigo);
        }

        public void ActualizarFlujo(int _id, string _nombre, DateTime _fecha)
        {
            FlujoTarea_DAC flujo = new FlujoTarea_DAC();
            flujo.IdFlujoTarea = _id;
            flujo.NombreFlujo = _nombre;
            flujo.InicioFlujo = _fecha;
            flujo.Update(flujo);
        }

        public void EliminarFlujo(int _codigo)
        {
            FlujoTarea_DAC flujo = new FlujoTarea_DAC();
            flujo.IdFlujoTarea = _codigo;
            flujo.Delete(flujo);
        }
    }
}
