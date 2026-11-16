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

static string[] codigos = new string[100];
static string[] documentos = new string[100];
static string[] detalles = new string[100];
static int[] cantidades = new int[100];
static string[] estados = new string[100];
static int totalSolicitudes = 0;

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

    static void BuscarProductoPorCodigo()
    {
        Console.WriteLine("\n[Funcion BuscarProductoPorCodigo - En desarrollo]");
        Console.ReadKey();
    }

    static void ModificarStockProducto()
    {
        Console.WriteLine("\n[Funcion ModificarStockProducto - En desarrollo]");
        Console.ReadKey();
    }

    // CSV de INVENTARIO 
    static void CargarInventarioCSV()
    {
    }

    static void GuardarInventarioCSV()
    {
    }

    // MODULO 3: SOLICITUDES
    static void SubmenuSolicitudes()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("SUBMENU: SOLICITUDES");
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
        Console.Clear();
        Console.WriteLine("REGISTRAR NUEVA SOLICITUD");

        if (totalSolicitudes >= 100)
        {
            Console.WriteLine("Limite de solicitudes alcanzado.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.Write("Codigo de solicitud: ");
        string codigo = LimpiarCampo(Console.ReadLine());

        Console.Write("Documento o cliente: ");
        string documento = LimpiarCampo(Console.ReadLine());

        Console.Write("Detalle de la solicitud: ");
        string detalle = LimpiarCampo(Console.ReadLine());

        Console.Write("Cantidad: ");
        int cantidad;
        if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
        {
            cantidades[totalSolicitudes] = cantidad;
        }
        else
        {
            cantidades[totalSolicitudes] = 0;
        }

        codigos[totalSolicitudes] = codigo;
        documentos[totalSolicitudes] = documento;
        detalles[totalSolicitudes] = detalle;
        estados[totalSolicitudes] = "Pendiente";

        totalSolicitudes++;
        GuardarSolicitudesCSV();

        Console.WriteLine("Solicitud registrada y guardada correctamente.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void VerSolicitudes()
    {
        Console.Clear();
        Console.WriteLine("LISTA DE SOLICITUDES REGISTRADAS");

        if (totalSolicitudes == 0)
        {
            Console.WriteLine("No hay solicitudes registradas.");
        }
        else
        {
            for (int i = 0; i < totalSolicitudes; i++)
            {
                Console.WriteLine($"{i + 1}. Codigo: {codigos[i]} | Documento: {documentos[i]} | Detalle: {detalles[i]} | Cantidad: {cantidades[i]} | Estado: {estados[i]}");
            }
        }

        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadKey();
    }

    static void BuscarSolicitudPorCodigo()
    {
        Console.Clear();
        Console.WriteLine("BUSCAR SOLICITUD POR CODIGO");
        Console.Write("Ingrese el codigo a buscar: ");
        string codigoBuscado = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < totalSolicitudes; i++)
        {
            if (codigos[i].Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Codigo: {codigos[i]}");
                Console.WriteLine($"Documento: {documentos[i]}");
                Console.WriteLine($"Detalle: {detalles[i]}");
                Console.WriteLine($"Cantidad: {cantidades[i]}");
                Console.WriteLine($"Estado: {estados[i]}");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontro ninguna solicitud con ese codigo.");
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ResumenSolicitudes()
    {
        Console.Clear();
        Console.WriteLine("RESUMEN DE SOLICITUDES");
        Console.WriteLine($"Total de solicitudes registradas: {totalSolicitudes}");

        int sumaUnidades = 0;
        for (int i = 0; i < totalSolicitudes; i++)
        {
            sumaUnidades += cantidades[i];
        }

        Console.WriteLine($"Total de unidades solicitadas: {sumaUnidades}");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void CargarSolicitudesCSV()
    {
        if (!File.Exists(ARCHIVO_SOLICITUDES))
        {
            return;
        }

        totalSolicitudes = 0;
        string[] lineas = File.ReadAllLines(ARCHIVO_SOLICITUDES);

        for (int i = 0; i < lineas.Length && totalSolicitudes < 100; i++)
        {
            if (string.IsNullOrWhiteSpace(lineas[i]))
            {
                continue;
            }

            string[] partes = lineas[i].Split(SEPARADOR);
            if (partes.Length >= 5)
            {
                codigos[totalSolicitudes] = partes[0];
                documentos[totalSolicitudes] = partes[1];
                detalles[totalSolicitudes] = partes[2];
                int.TryParse(partes[3], out cantidades[totalSolicitudes]);
                estados[totalSolicitudes] = partes[4];
                totalSolicitudes++;
            }
        }
    }

    static void GuardarSolicitudesCSV()
    {
        using (StreamWriter sw = new StreamWriter(ARCHIVO_SOLICITUDES))
        {
            for (int i = 0; i < totalSolicitudes; i++)
            {
                string linea = $"{codigos[i]}{SEPARADOR}{documentos[i]}{SEPARADOR}{detalles[i]}{SEPARADOR}{cantidades[i]}{SEPARADOR}{estados[i]}";
                sw.WriteLine(linea);
            }
        }
    }

   
}