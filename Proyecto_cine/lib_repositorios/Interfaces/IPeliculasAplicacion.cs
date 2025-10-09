using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IPeliculasAplicacion
    {
        List<Peliculas> ListarPeliculas();
        Peliculas? Guardar(Peliculas? entidad);
        Peliculas? Modificar(Peliculas? entidad);
        Peliculas? Borrar(Peliculas? entidad);
    }
}
