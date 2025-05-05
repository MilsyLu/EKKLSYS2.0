using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<T>
    {
        string Guardar(T entity);
        List<T> Consultar();
        string Modificar(T entity);
        string Eliminar(int id);
        T Mappear(string datos);
    }
}