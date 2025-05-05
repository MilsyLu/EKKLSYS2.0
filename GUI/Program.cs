using System;
using System.Windows.Forms;
using ENTITY;

namespace GUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear directorio de datos si no existe
            Archivos.CrearDirectorioSiNoExiste();

            Application.Run(new FrmLogin());
        }
    }
}