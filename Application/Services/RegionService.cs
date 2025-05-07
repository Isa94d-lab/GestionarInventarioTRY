using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;

namespace GESTIONINVENTARIOTRY.Application.Services
{
    public class RegionService
    {
        private readonly IRegionRepository _repo;

        public RegionService(IRegionRepository repo)
        {
            _repo = repo;
        }

        public void MostrarTodos(int paisId)
        {
            var lista = _repo.ObtenerTodos();
            foreach (var region in lista)
            {
                Console.WriteLine($"ID: {region.Id}, Nombre: {region.Nombre}, Pais ID: {region.PaisId}");
            }
        }

        public void CrearRegion(string nombre, int paisId)
        {
            _repo.Crear(new Region { Nombre = nombre, PaisId = paisId });
        }

        public void ActualizarRegion(int id, string nuevoNombre, int paisId)
        {
            _repo.Actualizar(new Region { Id = id, Nombre = nuevoNombre, PaisId = paisId });
        }

        public void EliminarRegion(int id)
        {
            _repo.Eliminar(id);
        }
    }
}
