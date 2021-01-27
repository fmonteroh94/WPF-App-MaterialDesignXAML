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
    public class FlujoTarea_DAC
    {
        private int idFlujoTarea;
        private string nombreFlujo;
        private DateTime inicioFlujo;

        public int IdFlujoTarea { get => idFlujoTarea; set => idFlujoTarea = value; }
        public string NombreFlujo { get => nombreFlujo; set => nombreFlujo = value; }
        public DateTime InicioFlujo { get => inicioFlujo; set => inicioFlujo = value; }

        public void Create(FlujoTarea_DAC flujo)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblflujotarea.sp_create_flujo";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "auxNombre";
                parametro.Value = flujo.nombreFlujo;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "auxFecha";
                parametro.Value = flujo.InicioFlujo;
                parametro.OracleDbType = OracleDbType.Date;
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
                comando.CommandText = "pkg_crud_tblflujotarea.sp_read_flujo";

                OracleParameter parametro = comando.CreateParameter();
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                parametro.ParameterName = "auxCodigo";
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
                comando.CommandText = "pkg_crud_tblflujotarea.sp_readAll_flujo";
                comando.Parameters.Add("c_datos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                return Conexion.RetornarDatos(comando);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(FlujoTarea_DAC flujo)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblflujotarea.sp_update_flujo";

                OracleParameter parametro = comando.CreateParameter();

                parametro.ParameterName = "aux_codigo";
                parametro.Value = flujo.idFlujoTarea;
                parametro.OracleDbType = OracleDbType.Decimal;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_nombre";
                parametro.Value = flujo.NombreFlujo;
                parametro.OracleDbType = OracleDbType.Varchar2;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_fecha";
                parametro.Value = flujo.InicioFlujo;
                parametro.OracleDbType = OracleDbType.Date;
                comando.Parameters.Add(parametro);

                Conexion.EjecutarSql(comando);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(FlujoTarea_DAC flujo)
        {
            try
            {
                OracleCommand comando = Conexion.CrearComandoSP();
                comando.CommandText = "pkg_crud_tblflujotarea.sp_delete_flujo";

                OracleParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "aux_codigo";
                parametro.Value = flujo.IdFlujoTarea;
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
