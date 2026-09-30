using System.Collections;
using System.ComponentModel;

class Sistema 
{
    // DECLARAMOS LAS VARIABLES GLOBALES Y LOS ARREGLOS 
    // PARA MODULO DE CLIENTES 
    const int CAPACIDAD_MAXIMA = 100;

    static string[] clientesDni = new string[CAPACIDAD_MAXIMA];
    static string[] clientesRuc = new string[CAPACIDAD_MAXIMA];
    static string[] clientesTelefono = new string[CAPACIDAD_MAXIMA];
    static string[] clientesNombre = new string[CAPACIDAD_MAXIMA];
    
    // Contador global en 0 y va subiendo con cada registro
    static int totalClientes = 0;

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
            Console.WriteLine("3- Modulo de Tramites y Pedidos");
            Console.WriteLine("4- Modulo de Reportes y Consultas");
            Console.WriteLine("5- Salir del Sistema");

            Console.Write("\nSeleccione una opcion (1-5): ");
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
              SubmenuPedidos();
                break;
             case "4":
              SubmenuReportes();
                break;
             case "5":
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
        System.Console.WriteLine("---REGISTRAR CLIENTE---");
        if (totalClientes >= CAPACIDAD_MAXIMA)
    {
        System.Console.WriteLine("No se pueden registrar más clientes (arreglo lleno).");
        Console.ReadKey();
        return;
    }
        string tipoDoc ="";
        while(tipoDoc != "1" && tipoDoc != "2")
        {
            System.Console.WriteLine("Que Documento desea regristar");
            System.Console.WriteLine("1. DNI (8 DIGITOS)");
            System.Console.WriteLine("2. RUC (11 DIGITOS)");
            System.Console.WriteLine("Seleccione una opcion (1 o 2):");
            tipoDoc= Console.ReadLine();
        }

        

        string Documento ="";
        bool docValido= false ;
        do
        {
            System.Console.WriteLine("ingrese el numero de Documento");
            Documento=Console.ReadLine();

            if(tipoDoc =="1")
            {
                docValido=Documento.Length== 8 && EsNumerico(Documento);
                if (!docValido) System.Console.WriteLine("DNI Invalido, debe tener 8 digitos");
            }
            else
            {
                 docValido=Documento.Length== 11 && EsNumerico(Documento);
                if (!docValido) System.Console.WriteLine("RUC Invalido, debe tener 11 digitos");
            }
        } while (!docValido); 
        
        
        string telefono;
        bool telefonoValido;
        do
        {
            System.Console.WriteLine("ingrese telefono (9 digitos)");
            telefono=Console.ReadLine();
            telefonoValido= telefono.Length==9 && EsNumerico(telefono);
            if (!telefonoValido) 
            System.Console.WriteLine("telefono invalido. debe tener 9 digitos");
        } while (!telefonoValido);
        

        
        // REGISTRAR NOMBRE 
        System.Console.WriteLine("Ingrese el nombre del cliente:");
        string nombre = Console.ReadLine();
        // Guardad segun si es dni o ruc
        if (tipoDoc=="1")
        {
            clientesDni[totalClientes]=Documento;
            clientesRuc[totalClientes]="-"; 
        }
        else
        {
            clientesRuc[totalClientes]=Documento;
            clientesDni[totalClientes]="-"; 
        }
        clientesTelefono[totalClientes]=telefono;
        clientesNombre[totalClientes]=nombre;
        totalClientes++;
        
        System.Console.WriteLine("Cliente resistrado correctamente");
        System.Console.WriteLine($"total de clientes:{totalClientes}");
        Console.ReadKey();

    }
    

    static void VerClientes()
    {
        System.Console.WriteLine("LISTAS DE CLIENTES REGISTRADOS---");

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
   
    static void SubmenuPedidos()
    {
        Console.Clear();
        Console.WriteLine("--- SUBMENU: TRAMITES Y PEDIDOS ---");
        Console.WriteLine("1. Registrar Solicitud / Cargo");
        Console.WriteLine("2. Ver Solicitudes Registradas");
        Console.WriteLine("3. Buscar Solicitud por Codigo");
        Console.WriteLine("4. Volver al Menu Principal");
        Console.Write("Seleccione una opcion: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1": RegistrarSolicitud(); break;
            case "2": VerSolicitudes(); break;
            case "3": BuscarSolicitudPorCodigo(); break;
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

   
    //MODULO 4 REPORTES Y ALGORITMOS 
  
    static void SubmenuReportes()
    {
        Console.Clear();
        Console.WriteLine("--- SUBMENU: REPORTES Y CONSULTAS ---");
        Console.WriteLine("1. Reporte de Productos con Stock Bajo");
        Console.WriteLine("2. Ordenar Productos por Nombre (Alfabeticamente)");
        Console.WriteLine("3. Resumen Estadistico del Sistema");
        Console.WriteLine("4. Volver al Menu Principal");
        Console.Write("Seleccione una opcion: ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "1": ReporteProductosStockBajo(); break;
            case "2": OrdenarProductosPorNombre(); break;
            case "3": ResumenEstadistico(); break;
        }
    }

    static void ReporteProductosStockBajo()
    {
        Console.WriteLine("\n[Funcion ReporteProductosStockBajo - En desarrollo]");
        Console.ReadKey();
    }

    static void OrdenarProductosPorNombre()
    {
        Console.WriteLine("\n[Funcion OrdenarProductosPorNombre - En desarrollo]");
        Console.ReadKey();
    }

    static void ResumenEstadistico()
    {
        Console.WriteLine("\n[Funcion ResumenEstadistico - En desarrollo]");
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
























































































































































































































































































































































