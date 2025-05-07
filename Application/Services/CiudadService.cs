using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;

namespace GESTIONINVENTARIOTRY.Application.Services;

public class CiudadService
{
    private readonly IGenericRepository<Ciudad> _repo;

    public CiudadService(IGenericRepository<Ciudad> repo)
    {
        _repo = repo;
    }

    public void MostrarTodas(int regionId)
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id} | Nombre: {c.Nombre} | Región ID: {c.RegionId}");
        }
    }

    public void CrearCiudad(string nombre, int regionId)
    {
        _repo.Crear(new Ciudad
        {
            Nombre = nombre,
            RegionId = regionId
        });
    }

    public void ActualizarCiudad(int id, string nuevoNombre, int regionId)
    {
        _repo.Actualizar(new Ciudad
        {
            Id = id,
            Nombre = nuevoNombre,
            RegionId = regionId
        });
    }

    public void EliminarCiudad(int id)
    {
        _repo.Eliminar(id);
    }
}
