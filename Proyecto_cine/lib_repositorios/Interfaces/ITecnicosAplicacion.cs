using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ITecnicosAplicacion
    {
        void Configurar(string cadenaConexion);
        List<Tecnicos> Listar();
        List<Tecnicos> PorCedula(Tecnicos? entidad);
        Tecnicos? Guardar(Tecnicos? entidad);
        Tecnicos? Modificar(Tecnicos? entidad);
        Tecnicos? Borrar(Tecnicos? entidad);
    }
}