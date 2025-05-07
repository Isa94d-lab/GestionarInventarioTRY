using GESTIONINVENTARIOTRY.Application.Services;
using GESTIONINVENTARIOTRY.Domain.Factory;
using GESTIONINVENTARIOTRY.Infrastructure.Mysql;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string connStr = "server=localhost;database=sgi_campus;user=root;password=5comentariosxdd.;";
        IDbFactory factory = new MySqlDbFactory(connStr);

        var paisService = new PaisService(factory.CrearPaisRepository());
        var facturacionService = new FacturacionService(factory.CrearFacturacionRepository());
        var regionService = new RegionService(factory.CrearRegionRepository());
        var ciudadService = new CiudadService(factory.CrearCiudadRepository()); // ✅ Nuevo

        while (true)
        {
            Console.WriteLine("--- MENU PRINCIPAL ---");
            Console.WriteLine("1. Gestion de Paises");
            Console.WriteLine("2. Gestion de Facturacion");
            Console.WriteLine("0. Salir");
            Console.Write("Opcion: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuPaises(paisService, regionService, ciudadService);
                    break;
                case "2":
                    MenuFacturacion(facturacionService);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opcion invalida.");
                    break;
            }
        }
    }

    private static void MenuPaises(PaisService paisService, RegionService regionService, CiudadService ciudadService)
    {
        while (true)
        {
            Console.WriteLine("\n--- GESTION DE PAISES ---");
            Console.WriteLine("1. Mostrar todos");
            Console.WriteLine("2. Crear nuevo");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Gestionar Regiones");
            Console.WriteLine("0. Volver");
            Console.Write("Opcion: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    paisService.MostrarTodos();
                    break;
                case "2":
                    Console.Write("Nombre del pais: ");
                    string nombre = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(nombre))
                        paisService.CrearPais(nombre);
                    break;
                case "3":
                    Console.Write("ID a actualizar: ");
                    int idA = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    string nuevoNombre = Console.ReadLine()!;
                    paisService.ActualizarPais(idA, nuevoNombre);
                    break;
                case "4":
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    paisService.EliminarPais(idE);
                    break;
                case "5":
                    Console.Write("Ingrese el ID del pais para gestionar regiones: ");
                    int paisId = int.Parse(Console.ReadLine()!);
                    MenuRegiones(regionService, ciudadService, paisId);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opcion invalida.");
                    break;
            }
        }
    }

    private static void MenuRegiones(RegionService regionService, CiudadService ciudadService, int paisId)
    {
        while (true)
        {
            Console.WriteLine("\n--- GESTION DE REGIONES ---");
            Console.WriteLine("1. Mostrar todas");
            Console.WriteLine("2. Crear nueva");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Gestionar Ciudades"); // ✅ Nueva opción
            Console.WriteLine("0. Volver");
            Console.Write("Opcion: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    regionService.MostrarTodos(paisId);
                    break;
                case "2":
                    Console.Write("Nombre de la region: ");
                    string nombreRegion = Console.ReadLine()!;
                    regionService.CrearRegion(nombreRegion, paisId);
                    break;
                case "3":
                    Console.Write("ID de la region a actualizar: ");
                    int idRegion = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    string nuevoNombreRegion = Console.ReadLine()!;
                    regionService.ActualizarRegion(idRegion, nuevoNombreRegion, paisId);
                    break;
                case "4":
                    Console.Write("ID de la region a eliminar: ");
                    int idEliminarRegion = int.Parse(Console.ReadLine()!);
                    regionService.EliminarRegion(idEliminarRegion);
                    break;
                case "5":
                    Console.Write("Ingrese el ID de la region para gestionar ciudades: ");
                    int regionId = int.Parse(Console.ReadLine()!);
                    MenuCiudades(ciudadService, regionId);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opcion invalida.");
                    break;
            }
        }
    }

    private static void MenuCiudades(CiudadService ciudadService, int regionId)
    {
        while (true)
        {
            Console.WriteLine("\n--- GESTION DE CIUDADES ---");
            Console.WriteLine("1. Mostrar todas");
            Console.WriteLine("2. Crear nueva");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opcion: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ciudadService.MostrarTodas(regionId);
                    break;
                case "2":
                    Console.Write("Nombre de la ciudad: ");
                    string nombreCiudad = Console.ReadLine()!;
                    ciudadService.CrearCiudad(nombreCiudad, regionId);
                    break;
                case "3":
                    Console.Write("ID de la ciudad a actualizar: ");
                    int idCiudad = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    string nuevoNombreCiudad = Console.ReadLine()!;
                    ciudadService.ActualizarCiudad(idCiudad, nuevoNombreCiudad, regionId);
                    break;
                case "4":
                    Console.Write("ID de la ciudad a eliminar: ");
                    int idEliminarCiudad = int.Parse(Console.ReadLine()!);
                    ciudadService.EliminarCiudad(idEliminarCiudad);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opcion invalida.");
                    break;
            }
        }
    }

    private static void MenuFacturacion(FacturacionService facturacionService)
    {
        while (true)
        {
            Console.WriteLine("\n--- GESTION DE FACTURACION ---");
            Console.WriteLine("1. Mostrar todas");
            Console.WriteLine("2. Crear nueva");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opcion: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    facturacionService.MostrarTodas();
                    break;
                case "2":
                    Console.Write("Fecha resolucion (YYYY-MM-DD): ");
                    DateTime fecha = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Numero inicio: ");
                    int inicio = int.Parse(Console.ReadLine()!);
                    Console.Write("Numero final: ");
                    int fin = int.Parse(Console.ReadLine()!);
                    Console.Write("Factura actual: ");
                    int actual = int.Parse(Console.ReadLine()!);
                    facturacionService.CrearFacturacion(fecha, inicio, fin, actual);
                    break;
                case "3":
                    Console.Write("ID a actualizar: ");
                    int idU = int.Parse(Console.ReadLine()!);
                    Console.Write("Fecha resolucion (YYYY-MM-DD): ");
                    DateTime nuevaFecha = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Numero inicio: ");
                    int nuevoInicio = int.Parse(Console.ReadLine()!);
                    Console.Write("Numero final: ");
                    int nuevoFin = int.Parse(Console.ReadLine()!);
                    Console.Write("Factura actual: ");
                    int nuevoActual = int.Parse(Console.ReadLine()!);
                    facturacionService.ActualizarFacturacion(idU, nuevaFecha, nuevoInicio, nuevoFin, nuevoActual);
                    break;
                case "4":
                    Console.Write("ID a eliminar: ");
                    int idD = int.Parse(Console.ReadLine()!);
                    facturacionService.EliminarFacturacion(idD);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opcion invalida.");
                    break;
            }
        }
    }
}
