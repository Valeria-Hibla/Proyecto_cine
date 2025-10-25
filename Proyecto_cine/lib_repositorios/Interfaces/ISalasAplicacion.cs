using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ISalasAplicacion
    {
        List<Salas> Listar();
        Salas? Guardar(Salas? entidad);
        Salas? Modificar(Salas? entidad);
        Salas? Borrar(Salas? entidad);
    }
}