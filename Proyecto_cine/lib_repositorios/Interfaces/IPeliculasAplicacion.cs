using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IPeliculasAplicacion
    {
        void Configurar(string cadenaConexion);
        List<Peliculas> Listar();
        List<Peliculas> PorGenero(Peliculas? entidad);
        Peliculas? Guardar(Peliculas? entidad);
        Peliculas? Modificar(Peliculas? entidad);
        Peliculas? Borrar(Peliculas? entidad);
    }
}
