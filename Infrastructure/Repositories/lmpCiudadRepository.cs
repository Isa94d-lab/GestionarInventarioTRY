using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;
using GESTIONINVENTARIOTRY.Infrastructure.Mysql;
using MySql.Data.MySqlClient;

namespace GESTIONINVENTARIOTRY.Infrastructure.Repositories
{
    public class lmpCiudadRepository : IGenericRepository<Ciudad>, ICiudadRepository
    {
        private readonly ConexionSingleton _conexion;

        public lmpCiudadRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        // Obtener todas las Ciudades
        public List<Ciudad> ObtenerTodos()
        {
            var ciudades = new List<Ciudad>();
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT id, nombre, region_id FROM ciudad";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ciudades.Add(new Ciudad
                {
                    Id = reader.GetInt32("id"),
                    Nombre = reader.GetString("nombre"),
                    RegionId = reader.GetInt32("region_id")
                });
            }

            return ciudades;
        }

        // Crear Ciudad
        public void Crear(Ciudad ciudad)
        {
            var connection = _conexion.ObtenerConexion();
            string query = @"INSERT INTO ciudad (nombre, region_id) 
                             VALUES (@nombre, @regionId)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre);
            cmd.Parameters.AddWithValue("@regionId", ciudad.RegionId);
            cmd.ExecuteNonQuery();
        }

        // Actualizar Ciudad
        public void Actualizar(Ciudad ciudad)
        {
            var connection = _conexion.ObtenerConexion();
            string query = @"UPDATE ciudad 
                             SET nombre = @nombre, 
                                 region_id = @regionId 
                             WHERE id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre);
            cmd.Parameters.AddWithValue("@regionId", ciudad.RegionId);
            cmd.Parameters.AddWithValue("@id", ciudad.Id);
            cmd.ExecuteNonQuery();
        }

        // Eliminar Ciudad
        public void Eliminar(int id)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "DELETE FROM ciudad WHERE id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        // Obtener ciudades por región
        public List<Ciudad> ObtenerTodasPorRegion(int regionId)
        {
            var ciudades = new List<Ciudad>();
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT id, nombre, region_id FROM ciudad WHERE region_id = @regionId";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@regionId", regionId);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ciudades.Add(new Ciudad
                {
                    Id = reader.GetInt32("id"),
                    Nombre = reader.GetString("nombre"),
                    RegionId = reader.GetInt32("region_id")
                });
            }

            return ciudades;
        }
    }
}
