
using Oracle.ManagedDataAccess.Client;
using System;

namespace DAL_2
{
    public class ConexionBD
    {
        private readonly string stringConnection;

        public ConexionBD()
        {
            var server = "localhost";
            var port = "1521";
            var serviceName = "XEPDB1";  // Ejemplo para Oracle XE
            var user = "Cristian";
            var password = "2508";

            stringConnection = $"User Id={user};Password={password};Data Source={server}:{port}/{serviceName};";
        }

        public OracleConnection AbrirConexion()
        {
            var conexion = new OracleConnection(stringConnection);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (OracleException ex)
            {
                throw new Exception($"Error de Oracle (Código {ex.ErrorCode}): {ex.Message}", ex);
            }
        }

        public void CerrarConexion(OracleConnection conexion)
        {
            if (conexion?.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}