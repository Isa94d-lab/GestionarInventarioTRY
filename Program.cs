using GESTIONINVENTARIOTRY.Application.Services;
using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Factory;
using GESTIONINVENTARIOTRY.Infrastructure.Mysql;

internal class Program
{
    private static void Main(string[] args)
    {
        string connStr = "server=localhost;database=sgi_campus;user=root;password=5comentariosxdd.;";
        IDbFactory factory = new MySqlDbFactory(connStr);

        var paisService = new PaisService(factory.CrearPaisRepository());
        var facturacionService = new FacturacionService(factory.CrearFacturacionRepository());

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
                    MenuPaises(paisService);
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

    private static void MenuPaises(PaisService servicio)
    {
        while (true)
        {
            Console.WriteLine("\n--- GESTION DE PAISES ---");
            Console.WriteLine("1. Mostrar todos");
            Console.WriteLine("2. Crear nuevo");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opcion: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    servicio.MostrarTodos();
                    break;
                case "2":
                    Console.Write("Nombre del pais: ");
                    string nombre = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(nombre))
                        servicio.CrearPais(nombre);
                    break;
                case "3":
                    Console.Write("ID a actualizar: ");
                    int idA = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    string nuevoNombre = Console.ReadLine()!;
                    servicio.ActualizarPais(idA, nuevoNombre);
                    break;
                case "4":
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicio.EliminarPais(idE);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opcion invalida.");
                    break;
            }
        }
    }

    private static void MenuFacturacion(FacturacionService servicio)
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
                    servicio.MostrarTodas();
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
                    servicio.CrearFacturacion(fecha, inicio, fin, actual);
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
                    servicio.ActualizarFacturacion(idU, nuevaFecha, nuevoInicio, nuevoFin, nuevoActual);
                    break;
                case "4":
                    Console.Write("ID a eliminar: ");
                    int idD = int.Parse(Console.ReadLine()!);
                    servicio.EliminarFacturacion(idD);
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
