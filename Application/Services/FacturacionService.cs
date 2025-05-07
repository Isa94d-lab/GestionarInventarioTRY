using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;

namespace GESTIONINVENTARIOTRY.Application.Services;

public class FacturacionService
{
    private readonly IGenericRepository<Facturacion> _repo;

    public FacturacionService(IGenericRepository<Facturacion> repo)
    {
        _repo = repo;
    }

    public void MostrarTodas()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var f in lista)
        {
            Console.WriteLine($"ID: {f.Id}, Fecha Resolución: {f.FechaResolucion:yyyy-MM-dd}, Inicio: {f.NumInicio}, Fin: {f.NumFin}, Actual: {f.FactActual}");
        }
    }

    public void CrearFacturacion(DateTime fechaResolucion, int numInicio, int numFinal, int facturaActual)
    {
        _repo.Crear(new Facturacion
        {
            FechaResolucion = fechaResolucion,
            NumInicio = numInicio,
            NumFin = numFinal,
            FactActual = facturaActual
        });
    }

    public void ActualizarFacturacion(int id, DateTime fechaResolucion, int numInicio, int numFinal, int facturaActual)
    {
        _repo.Actualizar(new Facturacion
        {
            Id = id,
            FechaResolucion = fechaResolucion,
            NumInicio = numInicio,
            NumFin = numFinal,
            FactActual = facturaActual
        });
    }

    public void EliminarFacturacion(int id)
    {
        _repo.Eliminar(id);
    }
}
