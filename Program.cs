using System.Collections;

class Sistema 
{
    static void Main(string[] args)
    {
      bool Salir = false;
     
       while(!Salir)
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

            switch(opcion)
            {
             case "1":
              SubmenuClientes();
                
                break;
             case "2":
              SubmenuInventario();
                break;
             case "3":
              SubmenuTramites();
                break;
             case "4":
                Salir=true;
                System.Console.WriteLine("Saliendo del Sistema. Precione Cualquier Tecla...");
                Console.ReadKey();
                break;
             default:
               System.Console.WriteLine("Opcion invalida. Precione Cualquier Tecla...");
                Console.ReadKey();
                break;


            }

        }
    }


    // MODULO 1 CLIENTE 

    static void SubmenuClientes()
    {
            System.Console.WriteLine("--- SUBMENU: GESTION DE CLIENTES ---");
            System.Console.WriteLine("1. Registrar Cliente");
            System.Console.WriteLine("2. Ver Lista de Clientes");
            System.Console.WriteLine("3. Buscar Cliente por Documento");
            System.Console.WriteLine("4. Volver al Menu Principal");
            System.Console.WriteLine("Seleccione una opcion: ");
            string op=Console.ReadLine();

            switch(op)
        {
            case "1": RegistrarCliente(); break;
            case "2": VerClientes(); break;
            case "3": BuscarClientes(); break;
        }
    }

    static void RegistrarCliente()
    {
        System.Console.WriteLine();
        Console.ReadKey();
    }

    static void VerClientes()
    {
        System.Console.WriteLine();
        Console.ReadKey();
    }

    static void BuscarClientes()
    {
        System.Console.WriteLine("");
        Console.ReadKey();
    }

// MODULO 2: INVENTARIO 

static void SubmenuInventario()
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

   
    // MODULO 3 TRAMITES y PEDIDOS 
   
     static void SubmenuTramites()
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
        case "5": volver = true; break;
        default:
            Console.WriteLine("Opcion invalidad,Presione cualquier tecla");
            Console.Readkey();
            break;
       }
    }
}
// AGREGA esta funcion nueva debajo de BuscarSolicitudPorCodigo():
static void RegistrarSolicitud()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRAR NUEVA SOLICITUD ---");

        if (totalSolicitudes >= 100)
        {
            Console.WriteLine("Error: Se ha alcanzado el límite máximo de solicitudes.");
            Console.ReadKey();
            return;
        }

        string codigoIngresado = "";
        // Bucle para validar código no vacío y evitar duplicados
        while (true)
        {
            Console.Write("Ingrese codigo de solicitud: ");
            codigoIngresado = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(codigoIngresado))
            {
                Console.WriteLine("Error: El código no puede estar vacío. Intente de nuevo.");
                continue;
            }

            bool existe = false;
            for (int i = 0; i < totalSolicitudes; i++)
            {
                if (codigos[i].Equals(codigoIngresado, StringComparison.OrdinalIgnoreCase))
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                Console.WriteLine("Error: Ya existe una solicitud con ese código. Ingrese uno diferente.");
            }
            else
            {
                break;
            }
        }

        string documentoIngresado = "";
        while (true)
        {
            Console.Write("Ingrese documento del cliente: ");
            documentoIngresado = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(documentoIngresado)) break;
            Console.WriteLine("Error: El documento no puede estar vacío.");
        }

        string detalleIngresado = "";
        while (true)
        {
            Console.Write("Ingrese descripcion del producto/pedido: ");
            detalleIngresado = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(detalleIngresado)) break;
            Console.WriteLine("Error: La descripción no puede estar vacía.");
        }

        int cantidadIngresada = 0;
        while (true)
        {
            Console.Write("Ingrese cantidad: ");
            if (int.TryParse(Console.ReadLine(), out cantidadIngresada) && cantidadIngresada > 0)
            {
                break;
            }
            Console.WriteLine("Error: Ingrese un número entero válido mayor a 0.");
        }

        // Guardar en las posiciones del arreglo global
        codigos[totalSolicitudes] = codigoIngresado;
        documentos[totalSolicitudes] = documentoIngresado;
        detalles[totalSolicitudes] = detalleIngresado;
        cantidades[totalSolicitudes] = cantidadIngresada;
        estados[totalSolicitudes] = "Pendiente";

        totalSolicitudes++; // Aumentar contador

        Console.WriteLine("\n¡Solicitud registrada con éxito!");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void VerSolicitudes()
    {
        Console.Clear();
        Console.WriteLine("LISTA DE SOLICITUDES ");

        if (listaSolicitudes.Count == 0)
        {
            Console.WriteLine("No hay solicitudes registradas todavía.");
        }
        else
        {
            int contador = 1;
            foreach (var sol in listaSolicitudes)
            {
                Console.WriteLine($"[{contador}]");
                Console.WriteLine($"  Codigo:   {sol.Codigo}");
                Console.WriteLine($"  Cliente:  {sol.DocumentoCliente}");
                Console.WriteLine($"  Detalle:  {sol.Detalle}");
                Console.WriteLine($"  Cantidad: {sol.Cantidad}");
                Console.WriteLine($"  Estado:   {sol.Estado}");
                contador++;
            }
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
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


}
























































































































































































































































































































































