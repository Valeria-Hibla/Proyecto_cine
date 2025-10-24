﻿using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEquiposAplicacion
    {
        List<Equipos> Listar();
        Equipos? Guardar(Equipos? entidad);
        Equipos? Modificar(Equipos? entidad);
        Equipos? Borrar(Equipos? entidad);
    }
}