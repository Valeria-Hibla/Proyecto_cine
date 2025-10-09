using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHorariosFuncionAplicacion
    {
        List<HorariosFuncion> ListarHorariosFuncion();
        HorariosFuncion? Guardar(HorariosFuncion? entidad);
        HorariosFuncion? Modificar(HorariosFuncion? entidad);
        HorariosFuncion? Borrar(HorariosFuncion? entidad);
    }
}