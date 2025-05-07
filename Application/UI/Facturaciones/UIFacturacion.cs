using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using GESTIONINVENTARIOTRY.Application.Services;
using GESTIONINVENTARIOTRY.Domain.Factory;

namespace GESTIONINVENTARIOTRY.Application.UI.Clientes
{
    public class UIFacturacion
    {
        
        private readonly IDbFactory _factory;
        //var servicio = new ClienteService(factory.CrearClienteRepository());

        public UIFacturacion(IDbFactory factory)
        {
            _factory = factory;

        }
    }


}