
using BLL;
using System;

class Program
{
    static void Main()
    {
        var conexionBLL = new ConexionBLL();
        Console.WriteLine(conexionBLL.ProbarConexion());
        Console.ReadKey();
    }
}
