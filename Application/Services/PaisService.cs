using System;
using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;

namespace GESTIONINVENTARIOTRY.Application.Services;

public class PaisService
{
    private readonly IPaisRepository _repo;

    public PaisService(IPaisRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}");
        }
    }

    public void CrearPais(string nombre)
    {
        _repo.Crear(new Pais { Nombre = nombre });
    }

    public void ActualizarCliente(int id, string nuevoNombre)
    {
        _repo.Actualizar(new Pais { Id = id, Nombre = nuevoNombre });
    }

    public void EliminarCliente(int id)
    {
        _repo.Eliminar(id);
    }
}
