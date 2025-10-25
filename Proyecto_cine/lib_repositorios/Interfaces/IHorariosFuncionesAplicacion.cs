using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHorariosFuncionesAplicacion
    {
        List<HorariosFunciones> Listar();
        HorariosFunciones? Guardar(HorariosFunciones? entidad);
        HorariosFunciones? Modificar(HorariosFunciones? entidad);
        HorariosFunciones? Borrar(HorariosFunciones? entidad);
    }
}