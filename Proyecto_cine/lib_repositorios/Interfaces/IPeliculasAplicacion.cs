using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IPeliculasAplicacion
    {
        List<Peliculas> Listar();
        Peliculas? Guardar(Peliculas? entidad);
        Peliculas? Modificar(Peliculas? entidad);
        Peliculas? Borrar(Peliculas? entidad);
    }
}
