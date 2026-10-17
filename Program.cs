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
        if (totalClientes==0)
        {
            System.Console.WriteLine("Aun no hay clientes registrados");
            return;
        }
        System.Console.WriteLine("{0,-4} {1,-10} {2,-13} {3,-11} {4}", "N.", "DNI", "RUC", "Telefono", "Nombre");
        System.Console.WriteLine(new string('-',60));
        for (int i=0;i<totalClientes;i++)
        {
            System.Console.WriteLine("{0,-4} {1,-10} {2,-13} {3,-11} {4}",
            i + 1, clientesDni[i], clientesRuc[i], clientesTelefono[i], clientesNombre[i]);
        }
        System.Console.WriteLine($"Total de clientes{totalClientes}");
        Console.ReadKey();
    }

    static void BuscarClientes()
    {
        System.Console.WriteLine("--- BUSCAR CLIENTE POR DOCUMENTO ---");
       
        if (totalClientes == 0)
        {
            System.Console.WriteLine("Aun no hay clientes registrados.");
            Console.ReadKey();
            return;
        }

        System.Console.WriteLine("Ingrese DNI (8 digitos) o RUC (11 digitos): ");
        string documento = Console.ReadLine();
        
        if (!EsNumerico(documento) || (documento.Length != 8 && documento.Length != 11))
        {
         System.Console.WriteLine("Documento invalido. Debe ser un DNI de 8 digitos o un RUC de 11.");
         return;   
        }

        string[] arregloDondeBuscar = documento.Length == 8 ? clientesDni : clientesRuc;
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
            System.Console.WriteLine("No se encontro ningun cliente con ese documento");
        }
        else
        {
            System.Console.WriteLine("Cliente encontrado:");
            System.Console.WriteLine("DNI:      " + clientesDni[posicion]);
            System.Console.WriteLine("RUC:      " + clientesRuc[posicion]);
            System.Console.WriteLine("Telefono: " + clientesTelefono[posicion]);
            System.Console.WriteLine("Nombre:   " + clientesNombre[posicion]);
        }        
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





