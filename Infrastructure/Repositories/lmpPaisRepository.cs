using System;
using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;
using GESTIONINVENTARIOTRY.Infrastructure.Mysql;
using MySql.Data.MySqlClient;

namespace GESTIONINVENTARIOTRY.Infrastructure.Repositories;

public class lmpPaisRepository : IGenericRepository<Pais>, IPaisRepository
{
    private readonly ConexionSingleton _conexion;

    public lmpPaisRepository(string connectionString)
    {
        _conexion = ConexionSingleton.Instancia(connectionString);
    }

    public List<Pais> ObtenerTodos()
    {
        var paises = new List<Pais>();
        var connection = _conexion.ObtenerConexion();

        string query = "SELECT id, nombre FROM pais";
        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            paises.Add(new Pais
            {
                Id = reader.GetInt32("id"),
                Nombre = reader.GetString("nombre")
            });
        }

        return paises;
    }

    public void Crear(Pais pais)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO pais (nombre) VALUES (@nombre)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", pais.Nombre);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Pais pais)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE pais SET nombre = @nombre WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", pais.Nombre);
        cmd.Parameters.AddWithValue("@id", pais.Id);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM pais WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
