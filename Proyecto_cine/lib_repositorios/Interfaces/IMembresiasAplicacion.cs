using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IMembresiasAplicacion
    {
        void Configurar(string cadenaConexion);
        List<Membresias> Listar();
        List<Membresias> PorNombre(Membresias? entidad);
        Membresias? Guardar(Membresias? entidad);
        Membresias? Modificar(Membresias? entidad);
        Membresias? Borrar(Membresias? entidad);
    }
}
