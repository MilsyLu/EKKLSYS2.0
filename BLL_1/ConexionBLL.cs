

using DAL_2;
using System;
using Oracle.ManagedDataAccess.Client;

namespace BLL
{
    public class ConexionBLL
    {
        public string ProbarConexion()
        {
            var conexionBD = new ConexionBD();
            OracleConnection conexion = null;

            try
            {
                conexion = conexionBD.AbrirConexion();
                return "✅ Conexión exitosa a Oracle. Estado: " + conexion.State;
            }
            catch (Exception ex)
            {
                return "❌ Error al conectar: " + ex.Message;
            }
            finally
            {
                conexionBD.CerrarConexion(conexion);
            }
        }
    }
}