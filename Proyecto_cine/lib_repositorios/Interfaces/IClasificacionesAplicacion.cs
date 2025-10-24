using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClasificacionesAplicacion
    {
        List<Clasificaciones> Listar();
        Clasificaciones? Guardar(Clasificaciones? entidad);
        Clasificaciones? Modificar(Clasificaciones? entidad);
        Clasificaciones? Borrar(Clasificaciones? entidad);
    }
}
