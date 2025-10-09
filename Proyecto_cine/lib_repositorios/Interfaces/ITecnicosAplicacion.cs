using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ITecnicosAplicacion
    {
        void Configurar(string StringConexion);
        List<Tecnicos> ListarTecnicos();
        Tecnicos? Guardar(Tecnicos? entidad);
        Tecnicos? Modificar(Tecnicos? entidad);
        Tecnicos? Borrar(Tecnicos? entidad);
    }
}