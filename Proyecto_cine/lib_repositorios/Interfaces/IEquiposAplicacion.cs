using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEquiposAplicacion
    {
        void Configurar(string StringConexion);
        List<Equipos> Listar();
        List<Equipos> PorMarca(Equipos? entidad);
        Equipos? Guardar(Equipos? entidad);
        Equipos? Modificar(Equipos? entidad);
        Equipos? Borrar(Equipos? entidad);
    }
}