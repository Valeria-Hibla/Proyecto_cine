using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ITecnicosAplicacion
    {
        List<Tecnicos> Listar();
        Tecnicos? Guardar(Tecnicos? entidad);
        Tecnicos? Modificar(Tecnicos? entidad);
        Tecnicos? Borrar(Tecnicos? entidad);
    }
}