using System;
using GESTIONINVENTARIOTRY.Domain.Factory;
using GESTIONINVENTARIOTRY.Domain.Ports;
using GESTIONINVENTARIOTRY.Infrastructure.Repositories;

namespace GESTIONINVENTARIOTRY.Infrastructure.Mysql;

public class MySqlDbFactory : IDbFactory
{
    private readonly string _connectionString;

    public MySqlDbFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IPaisRepository CrearPaisRepository()
    {
        return new lmpPaisRepository(_connectionString);
    }

    public IFacturacionRepository CrearFacturacionRepository()
    {
        return new lmpFacturacionRepository(_connectionString);
    }

    public IRegionRepository CrearRegionRepository()
    {
        return new lmpRegionRepository(_connectionString);
    }

    public ICiudadRepository CrearCiudadRepository()
    {
        return new lmpCiudadRepository(_connectionString);
    }
}
