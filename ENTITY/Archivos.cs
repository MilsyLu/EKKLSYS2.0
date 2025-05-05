using System;
using System.IO;

namespace ENTITY
{
    public static class Archivos
    {
        public static readonly string RUTA_BASE = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos");
        public static readonly string ARC_USUARIO = Path.Combine(RUTA_BASE, "usuarios.txt");
        public static readonly string ARC_EVENTO = Path.Combine(RUTA_BASE, "eventos.txt");
        public static readonly string ARC_CURSO = Path.Combine(RUTA_BASE, "cursos.txt");
        public static readonly string ARC_ASISTENCIA = Path.Combine(RUTA_BASE, "asistencias.txt");
        public static readonly string ARC_INSCRIPCION = Path.Combine(RUTA_BASE, "inscripciones.txt");

        public static void CrearDirectorioSiNoExiste()
        {
            if (!Directory.Exists(RUTA_BASE))
            {
                Directory.CreateDirectory(RUTA_BASE);
            }
        }
    }
}