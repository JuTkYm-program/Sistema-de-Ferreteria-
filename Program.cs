using System;
using System.IO; // Agregamos la Librería para leer y escribir archivos CSV

class Sistema
{
    
 // =====================================================================
 // VARIABLES GLOBALES PARA ARCHIVOS CSV (USO OBLIGATORIO PARA TODOS)
 // - No cambien los nombres de los archivos aquí.
 // - Usen la constante 'SEPARADOR' (',') en sus funciones de guardar/leer.
 // - IMPORTANTE: Antes de guardar textos largos (nombres, detalles), 
 //   pásenlos por la función LimpiarCampo(texto) para que el CSV no se rompa.
 // =====================================================================

    const char SEPARADOR = ',';
    const string ARCHIVO_CLIENTES = "clientes.csv";
    const string ARCHIVO_INVENTARIO = "productos.csv";
    const string ARCHIVO_SOLICITUDES = "solicitudes.csv";

    static string LimpiarCampo(string texto)
    {
        return texto.Replace(SEPARADOR, ' ');
    }


    static void Main(string[] args)
    {
        // 1- CARGA INICIAL DE DATOS.
        // Aquí se llama a las funciones que leen los CSV al abrir el programa.
        CargarClientesCSV();
        CargarInventarioCSV();
        CargarSolicitudesCSV();

        bool Salir = false;

        while (!Salir)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("   SISTEMA DE GESTION - FERRETERIA       ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1- Modulo de Gestion de Clientes");
            Console.WriteLine("2- Modulo de Gestion de Inventario");
            Console.WriteLine("3- Modulo de Solicitudes");
            Console.WriteLine("4- Salir del Sistema");

            Console.Write("\nSeleccione una opcion (1-4): ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    SubmenuClientes();
                    break;
                case "2":
                    SubmenuInventario();
                    break;
                case "3":
                    SubmenuSolicitudes();
                    break;
                case "4":
            
                    Salir = true;
                    Console.WriteLine("Saliendo del Sistema. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opcion invalida. Presione cualquier tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    // =====================================================================
    // MODULO 1: CLIENTES
    // =====================================================================

    static void SubmenuClientes()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- SUBMENU: GESTION DE CLIENTES ---");
            Console.WriteLine("1. Registrar Cliente");
            Console.WriteLine("2. Ver Lista de Clientes");
            Console.WriteLine("3. Buscar Cliente por Documento");
            Console.WriteLine("4. Volver al Menu Principal");
            Console.Write("Seleccione una opcion: ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "1": RegistrarCliente(); break;
                case "2": VerClientes(); break;
                case "3": BuscarClientes(); break;
                case "4":
                    GuardarClientesCSV(); // guarda al salir del módulo
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Presione una tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void RegistrarCliente()
    {
        Console.WriteLine("\n[Funcion RegistrarCliente - En desarrollo]");
        Console.ReadKey();
    }

    static void VerClientes()
    {
        Console.WriteLine("\n[Funcion VerClientes - En desarrollo]");
        Console.ReadKey();
    }

    static void BuscarClientes()
    {
        Console.WriteLine("\n[Funcion BuscarClientes - En desarrollo]");
        Console.ReadKey();
    }

    // CSV de CLIENTES 
    // Cargar: si File.Exists(ARCHIVO_CLIENTES), leer con File.ReadAllLines y llenar los arreglos.
    // Guardar: escribir una línea por cliente con File.WriteAllLines.
    static void CargarClientesCSV()
    {
    }

    static void GuardarClientesCSV()
    {
    }


    // =====================================================================
    // MODULO 2: INVENTARIO
    // =====================================================================

    static void SubmenuInventario()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- SUBMENU: GESTION DE INVENTARIO ---");
            Console.WriteLine("1. Registrar Producto");
            Console.WriteLine("2. Ver Inventario Completo");
            Console.WriteLine("3. Buscar Producto por Codigo");
            Console.WriteLine("4. Modificar Stock");
            Console.WriteLine("5. Volver al Menu Principal");
            Console.Write("Seleccione una opcion: ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "1": RegistrarProducto(); break;
                case "2": VerInventario(); break;
                case "3": BuscarProductoPorCodigo(); break;
                case "4": ModificarStockProducto(); break;
                case "5":
                    GuardarInventarioCSV(); // guarda al salir del módulo
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Presione una tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void RegistrarProducto()
    {
        Console.WriteLine("\n[Funcion RegistrarProducto - En desarrollo]");
        Console.ReadKey();
    }

    static void VerInventario()
    {
        Console.WriteLine("\n[Funcion VerInventario - En desarrollo]");
        Console.ReadKey();
    }

   // Devuelve la posicion del producto, o -1 si no existe
static int BuscarIndicePorCodigo(string codigo)
{
    for (int i = 0; i < totalProductos; i++)
    {
        if (codigosProd[i].Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            return i;
        }
    }
    return -1;
}

static void BuscarProductoPorCodigo()
{
    Console.Clear();
    Console.WriteLine("--- BUSCAR PRODUCTO POR CODIGO ---");
    Console.Write("Ingrese el codigo: ");
    string codigo = Console.ReadLine() ?? "";

    int indice = BuscarIndicePorCodigo(codigo);

    if (indice == -1)
    {
        Console.WriteLine("\nNo se encontro ningun producto con ese codigo.");
    }
    else
    {
        Console.WriteLine("\nProducto encontrado:");
        Console.WriteLine($"Codigo: {codigosProd[indice]}");
        Console.WriteLine($"Nombre: {nombresProd[indice]}");
        Console.WriteLine($"Stock:  {stocksProd[indice]}");
        Console.WriteLine($"Precio: {preciosProd[indice]}");
    }

    Console.WriteLine("\nPresione cualquier tecla...");
    Console.ReadKey();
}

static void ModificarStockProducto()
{
    Console.Clear();
    Console.WriteLine("--- MODIFICAR STOCK ---");
    Console.Write("Ingrese el codigo del producto: ");
    string codigo = Console.ReadLine() ?? "";

    int indice = BuscarIndicePorCodigo(codigo);

    if (indice == -1)
    {
        Console.WriteLine("\nNo se encontro ningun producto con ese codigo.");
    }
    else
    {
        Console.WriteLine($"\n{nombresProd[indice]} - Stock actual: {stocksProd[indice]}");
        Console.Write("Ingrese el nuevo stock: ");

        if (int.TryParse(Console.ReadLine(), out int nuevoStock) && nuevoStock >= 0)
        {
            stocksProd[indice] = nuevoStock;
            Console.WriteLine("Stock actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Valor invalido. El stock no se modifico.");
        }
    }

    Console.WriteLine("\nPresione cualquier tecla...");
    Console.ReadKey();
}

    // CSV de INVENTARIO 
    static void CargarInventarioCSV()
    {
    }

    static void GuardarInventarioCSV()
    {
    }


    // =====================================================================
    // MODULO 3: SOLICITUDES
    // =====================================================================

    static void SubmenuSolicitudes()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- SUBMENU: SOLICITUDES ---");
            Console.WriteLine("1. Registrar Solicitud");
            Console.WriteLine("2. Ver Solicitudes Registradas");
            Console.WriteLine("3. Buscar Solicitud por Codigo");
            Console.WriteLine("4. Resumen de Solicitudes");
            Console.WriteLine("5. Volver al Menu Principal");
            Console.Write("Seleccione una opcion: ");
            string op = Console.ReadLine();

            switch (op)
            {
                case "1": RegistrarSolicitud(); break;
                case "2": VerSolicitudes(); break;
                case "3": BuscarSolicitudPorCodigo(); break;
                case "4": ResumenSolicitudes(); break;
                case "5":
                    GuardarSolicitudesCSV(); // guarda al salir del módulo
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Presione una tecla...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void RegistrarSolicitud()
    {
        Console.WriteLine("\n[Funcion RegistrarSolicitud - En desarrollo]");
        Console.ReadKey();
    }

    static void VerSolicitudes()
    {
        Console.WriteLine("\n[Funcion VerSolicitudes - En desarrollo]");
        Console.ReadKey();
    }

    static void BuscarSolicitudPorCodigo()
    {
        Console.WriteLine("\n[Funcion BuscarSolicitudPorCodigo - En desarrollo]");
        Console.ReadKey();
    }

    static void ResumenSolicitudes()
    {
        Console.WriteLine("\n[Funcion ResumenSolicitudes - En desarrollo]");
        Console.ReadKey();
    }

    // CSV de SOLICITUDES 
    static void CargarSolicitudesCSV()
    {
    }

    static void GuardarSolicitudesCSV()
    {
    }
}