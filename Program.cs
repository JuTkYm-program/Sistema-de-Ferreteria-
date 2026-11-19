using System;
using System.IO; // File y Path: leer y escribir archivos (aquí, el CSV de clientes)

class Sistema
{
    // VARIABLES GLOBALES 
  
    // --- Arreglos de Clientes ---
    const int CAPACIDAD_MAXIMA = 100;
    static string[] clientesDni = new string[CAPACIDAD_MAXIMA];
    static string[] clientesRuc = new string[CAPACIDAD_MAXIMA];
    static string[] clientesTelefono = new string[CAPACIDAD_MAXIMA];
    static string[] clientesNombre = new string[CAPACIDAD_MAXIMA];
    // Contador: cuántos clientes hay guardados y cuál es la próxima posición libre
    static int totalClientes = 0;

    // =====================================================================
    // CONSTANTES COMPARTIDAS POR LOS 3 MODULOS (CSV)
    // =====================================================================
    const char SEPARADOR = ',';
    const string ARCHIVO_CLIENTES = "clientes.csv";

    static string LimpiarCampo(string texto)
    {
        return texto.Replace(SEPARADOR, ' ');
    }


    static void Main(string[] args)
    {
        // 1- CARGA INICIAL DE CSV DEL MODULO
        CargarClientesCSV();


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

 // ---MODULO 1: CLIENTES---

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
                    GuardarClientesCSV(); // Los datos ya se guardaron al salir del módulo 
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
        Console.Clear();
        Console.WriteLine("--- REGISTRAR CLIENTE ---");

        // Si el arreglo ya está lleno, no se puede registrar más
        if (totalClientes >= CAPACIDAD_MAXIMA)
        {
            Console.WriteLine("No se pueden registrar mas clientes (arreglo lleno).");
            Console.WriteLine("Presione una tecla para volver...");
            Console.ReadKey();
            return;
        }

        // Tipo de documento
        string tipoDoc = "";
        while (tipoDoc != "1" && tipoDoc != "2")
        {
            Console.WriteLine("Que documento desea registrar");
            Console.WriteLine("1. DNI (8 digitos)");
            Console.WriteLine("2. RUC (11 digitos)");
            Console.Write("Seleccione una opcion (1 o 2): ");
            tipoDoc = Console.ReadLine();
        }

        // Número de documento
        string documento = "";
        bool docValido = false;
        do
        {
            Console.Write("Ingrese el numero de documento: ");
            documento = Console.ReadLine();

            if (tipoDoc == "1")
            {
                docValido = documento.Length == 8 && EsNumerico(documento);
                if (!docValido) Console.WriteLine("DNI invalido, debe tener 8 digitos.");
            }
            else
            {
                docValido = documento.Length == 11 && EsNumerico(documento);
                if (!docValido) Console.WriteLine("RUC invalido, debe tener 11 digitos.");
            }
        } while (!docValido);

        // Evitar duplicados
        for (int i = 0; i < totalClientes; i++)
        {
            string existente = tipoDoc == "1" ? clientesDni[i] : clientesRuc[i];
            if (existente == documento)
            {
                Console.WriteLine("\nYa existe un cliente registrado con ese documento.");
                Console.WriteLine("Presione una tecla para volver...");
                Console.ReadKey();
                return;
            }
        }

        // Teléfono
        string telefono;
        bool telefonoValido;
        do
        {
            Console.Write("Ingrese telefono (9 digitos): ");
            telefono = Console.ReadLine();
            telefonoValido = telefono.Length == 9 && EsNumerico(telefono);
            if (!telefonoValido)
                Console.WriteLine("Telefono invalido, debe tener 9 digitos.");
        } while (!telefonoValido);

        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        // Guardar en los arreglos
        if (tipoDoc == "1")
        {
            clientesDni[totalClientes] = documento;
            clientesRuc[totalClientes] = "-";
        }
        else
        {
            clientesRuc[totalClientes] = documento;
            clientesDni[totalClientes] = "-";
        }
        clientesTelefono[totalClientes] = telefono;
        clientesNombre[totalClientes] = nombre;
        totalClientes++;

        Console.WriteLine("\nCliente registrado correctamente.");
        Console.WriteLine($"Total de clientes: {totalClientes}");
        Console.WriteLine("Presione una tecla para volver...");
        Console.ReadKey();
    }

    static void VerClientes()
    {
        Console.Clear();
        Console.WriteLine("--- LISTA DE CLIENTES REGISTRADOS ---");

        if (totalClientes == 0)
        {
            Console.WriteLine("Aun no hay clientes registrados.");
            Console.WriteLine("Presione una tecla para volver...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("{0,-4} {1,-10} {2,-13} {3,-11} {4}", "N.", "DNI", "RUC", "Telefono", "Nombre");
        Console.WriteLine(new string('-', 60));
        for (int i = 0; i < totalClientes; i++)
        {
            Console.WriteLine("{0,-4} {1,-10} {2,-13} {3,-11} {4}",
                i + 1, clientesDni[i], clientesRuc[i], clientesTelefono[i], clientesNombre[i]);
        }
        Console.WriteLine($"\nTotal de clientes: {totalClientes}");
        Console.WriteLine("Presione una tecla para volver...");
        Console.ReadKey();
    }

    static void BuscarClientes()
    {
        Console.Clear();
        Console.WriteLine("--- BUSCAR CLIENTE POR DOCUMENTO ---");

        if (totalClientes == 0)
        {
            Console.WriteLine("Aun no hay clientes registrados.");
            Console.WriteLine("Presione una tecla para volver...");
            Console.ReadKey();
            return;
        }

        Console.Write("Ingrese DNI (8 digitos) o RUC (11 digitos): ");
        string documento = Console.ReadLine();

        if (!EsNumerico(documento) || (documento.Length != 8 && documento.Length != 11))
        {
            Console.WriteLine("Documento invalido. Debe ser un DNI de 8 digitos o un RUC de 11.");
            Console.WriteLine("Presione una tecla para volver...");
            Console.ReadKey();
            return;
        }

        
        string[] arregloDondeBuscar = documento.Length == 8 ? clientesDni : clientesRuc;

        // Búsqueda secuencial
        int posicion = -1;
        for (int i = 0; i < totalClientes; i++)
        {
            if (arregloDondeBuscar[i] == documento)
            {
                posicion = i;
                break;
            }
        }

        if (posicion == -1)
        {
            Console.WriteLine("No se encontro ningun cliente con ese documento.");
        }
        else
        {
            Console.WriteLine("\nCliente encontrado:");
            Console.WriteLine("DNI:      " + clientesDni[posicion]);
            Console.WriteLine("RUC:      " + clientesRuc[posicion]);
            Console.WriteLine("Telefono: " + clientesTelefono[posicion]);
            Console.WriteLine("Nombre:   " + clientesNombre[posicion]);
        }
        Console.WriteLine("\nPresione una tecla para volver...");
        Console.ReadKey();
    }


    // CSV de CLIENTES

    // Lee el archivo clientes.csv y llena los arreglos.
    static void CargarClientesCSV()
    {
        if (!File.Exists(ARCHIVO_CLIENTES)) return;

        try
        {
            string[] lineas = File.ReadAllLines(ARCHIVO_CLIENTES);
            totalClientes = 0;

            for (int i = 0; i < lineas.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lineas[i])) continue;      
                if (totalClientes >= CAPACIDAD_MAXIMA) break;            
                
                string[] partes = lineas[i].Split(SEPARADOR, 4);
                if (partes.Length != 4) continue;                       

                clientesDni[totalClientes] = partes[0];
                clientesRuc[totalClientes] = partes[1];
                clientesTelefono[totalClientes] = partes[2];
                clientesNombre[totalClientes] = partes[3];
                totalClientes++;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("No se pudo leer " + ARCHIVO_CLIENTES + ". Se inicia sin clientes.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            totalClientes = 0;
        }
    }

    
    static void GuardarClientesCSV()
    {
        try
        {
            string[] lineas = new string[totalClientes];
            for (int i = 0; i < totalClientes; i++)
            {
                lineas[i] = clientesDni[i] + SEPARADOR
                          + clientesRuc[i] + SEPARADOR
                          + clientesTelefono[i] + SEPARADOR
                          + LimpiarCampo(clientesNombre[i]);
            }
            File.WriteAllLines(ARCHIVO_CLIENTES, lineas);
            Console.WriteLine("Clientes guardados en: " + Path.GetFullPath(ARCHIVO_CLIENTES));
        }
        catch (Exception)
        {
            // esto es Por ejemplo, si el archivo está abierto en Excel
            Console.WriteLine("No se pudo guardar " + ARCHIVO_CLIENTES + ". Cierre el archivo si lo tiene abierto.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }


 // ---MODULO 1: INVENTARIO---

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



 // ---MODULO 1: Solicitudes---

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

        static bool EsNumerico(string texto)
    {
        for (int i = 0; i < texto.Length; i++)
        {
            if (!char.IsDigit(texto[i])) return false;
        }
        return true;
    }
}