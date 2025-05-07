using System;
using GESTIONINVENTARIOTRY.Domain.Ports;

namespace GESTIONINVENTARIOTRY.Domain.Factory;

public interface IDbFactory
{
    IPaisRepository CrearPaisRepository();

    IFacturacionRepository CrearFacturacionRepository();

    IRegionRepository CrearRegionRepository();
    
    ICiudadRepository CrearCiudadRepository();
}
