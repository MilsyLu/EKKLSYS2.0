using System.Collections.Generic;

namespace BLL
{
    public interface IService<T>
    {
        List<T> Consultar();
        string Guardar(T entity);
        string Modificar(T entity);
        string Eliminar(int id);
        T BuscarId(int id);
    }
}