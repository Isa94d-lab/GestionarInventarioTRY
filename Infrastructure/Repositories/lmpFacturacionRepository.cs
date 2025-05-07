using System;
using System.Collections.Generic;
using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Ports;
using GESTIONINVENTARIOTRY.Infrastructure.Mysql;
using MySql.Data.MySqlClient;

namespace GESTIONINVENTARIOTRY.Infrastructure.Repositories;

public class lmpFacturacionRepository : IGenericRepository<Facturacion>, IFacturacionRepository
{
    private readonly ConexionSingleton _conexion;

    public lmpFacturacionRepository(string connectionString)
    {
        _conexion = ConexionSingleton.Instancia(connectionString);
    }

    public List<Facturacion> ObtenerTodos()
    {
        var facturaciones = new List<Facturacion>();
        var connection = _conexion.ObtenerConexion();

        string query = "SELECT id, fechaResolucion, numInicio, numFinal, factura_actual FROM facturacion";
        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            facturaciones.Add(new Facturacion
            {
                Id = reader.GetInt32("id"),
                FechaResolucion = reader.GetDateTime("fechaResolucion"),
                NumInicio = reader.GetInt32("numInicio"),
                NumFin = reader.GetInt32("numFinal"),
                FactActual = reader.GetInt32("factura_actual")
            });
        }

        return facturaciones;
    }

    public void Crear(Facturacion facturacion)
    {
        var connection = _conexion.ObtenerConexion();
        string query = @"INSERT INTO facturacion 
                        (fechaResolucion, numInicio, numFinal, factura_actual) 
                        VALUES (@fechaResolucion, @numInicio, @numFinal, @factura_actual)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@fechaResolucion", facturacion.FechaResolucion);
        cmd.Parameters.AddWithValue("@numInicio", facturacion.NumInicio);
        cmd.Parameters.AddWithValue("@numFinal", facturacion.NumFin);
        cmd.Parameters.AddWithValue("@factura_actual", facturacion.FactActual);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Facturacion facturacion)
    {
        var connection = _conexion.ObtenerConexion();
        string query = @"UPDATE facturacion 
                         SET fechaResolucion = @fechaResolucion, 
                             numInicio = @numInicio, 
                             numFinal = @numFinal, 
                             factura_actual = @factura_actual 
                         WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@fechaResolucion", facturacion.FechaResolucion);
        cmd.Parameters.AddWithValue("@numInicio", facturacion.NumInicio);
        cmd.Parameters.AddWithValue("@numFinal", facturacion.NumFin);
        cmd.Parameters.AddWithValue("@factura_actual", facturacion.FactActual);
        cmd.Parameters.AddWithValue("@id", facturacion.Id);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM facturacion WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}
