using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ISalasAplicacion
    {
        List<Salas> ListarSalas();
        Salas? Guardar(Salas? entidad);
        Salas? Modificar(Salas? entidad);
        Salas? Borrar(Salas? entidad);
    }
}