using System;
using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;
using GESTIONINVENTARIOTRY.Infrastructure.Mysql;
using MySql.Data.MySqlClient;

namespace GESTIONINVENTARIOTRY.Infrastructure.Repositories
{
    public class LmpRegionRepository : IRegionRepository
    {
        private readonly ConexionSingleton _conexion;

        public LmpRegionRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Region> ObtenerTodos()
        {
            var regiones = new List<Region>();
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT id, nombre, pais_id FROM region";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                regiones.Add(new Region
                {
                    Id = reader.GetInt32("id"),
                    Nombre = reader.GetString("nombre"),
                    PaisId = reader.GetInt32("pais_id") // Usando PaisId
                });
            }

            return regiones;
        }

        public void Crear(Region region)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO region (nombre, pais_id) VALUES (@nombre, @pais_id)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", region.Nombre);
            cmd.Parameters.AddWithValue("@pais_id", region.PaisId); // Usando PaisId
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Region region)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "UPDATE region SET nombre = @nombre, pais_id = @pais_id WHERE id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", region.Nombre);
            cmd.Parameters.AddWithValue("@pais_id", region.PaisId); // Usando PaisId
            cmd.Parameters.AddWithValue("@id", region.Id);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "DELETE FROM region WHERE id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
