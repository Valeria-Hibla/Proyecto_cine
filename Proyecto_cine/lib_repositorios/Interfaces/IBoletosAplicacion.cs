﻿using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IBoletosAplicacion
    {
        List<Boletos> Listar();
        Boletos? Guardar(Boletos? entidad);
        Boletos? Modificar(Boletos? entidad);
        Boletos? Borrar(Boletos? entidad);
    }
}
