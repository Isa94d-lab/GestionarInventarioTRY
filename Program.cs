using GESTIONINVENTARIOTRY.Application.Services;
using GESTIONINVENTARIOTRY.Application.UI.Clientes;
using GESTIONINVENTARIOTRY.Domain.Entities;
using GESTIONINVENTARIOTRY.Domain.Factory;
using GESTIONINVENTARIOTRY.Infrastructure.Mysql;

internal class Program
{
    private static void Main(string[] args)
    {
        string connStr = "server=localhost;database=sgi_campus;user=campus2023;password=campus2023;";
        IDbFactory factory = new MySqlDbFactory(connStr);
        var servicio = new PaisService(factory.CrearPaisRepository());
        var servicioPais = new PaisService(factory.CrearPaisRepository());
                while (true)
        {
            Console.WriteLine("\n--- MENÚ CLIENTES ---");
            Console.WriteLine("1. Mostrar todos");
            Console.WriteLine("2. Crear nuevo");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    servicio.MostrarTodos();
                    UIPais Uc = new UIPais(factory);
                    
                    break;
                case "2":
                    Pais pais = new Pais();
                    Console.Write("Nombre del pais: ");
                    pais.Nombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(pais.Nombre))
                    {
                        servicioPais.CrearPais(pais.Nombre);
                    }
                    else
                    {
                        Console.WriteLine("El valor ingresado es NULO");
                    }
                    break;
                case "3":
                    Console.Write("ID a actualizar: ");
                    int idA = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo nombre: ");
                    servicio.ActualizarCliente(idA, Console.ReadLine()!);
                    break;
                case "4":
                    Console.Write("ID a eliminar: ");
                    int idE = int.Parse(Console.ReadLine()!);
                    servicio.EliminarCliente(idE);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("❌ Opcion inválida.");
                    break;
            }
        }
    }
}