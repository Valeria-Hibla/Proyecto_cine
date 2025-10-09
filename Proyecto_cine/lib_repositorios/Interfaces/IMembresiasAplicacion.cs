using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IMembresiasAplicacion
    {
        List<Membresias> ListarMembresias();
        Membresias? Guardar(Membresias? entidad);
        Membresias? Modificar(Membresias? entidad);
        Membresias? Borrar(Membresias? entidad);
    }
}
