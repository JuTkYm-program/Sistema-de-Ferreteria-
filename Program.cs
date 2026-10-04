using System.Collections;

class Sistema 
{
    //Arreglos para el inventario
    const int MAX_PRODUCTOS = 100;
    static string[] codigosProd = new string[MAX_PRODUCTOS];
    static string[] nombresProd = new string[MAX_PRODUCTOS];
    static int[] stocksProd = new int[MAX_PRODUCTOS];
    static double[] preciosProd = new double[MAX_PRODUCTOS];
    static int totalProductos = 0;
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
        Console.Clear();
        Console.WriteLine("--------REGISTRAR PRODUCTO----------");
        if (totalProductos==MAX_PRODUCTOS)
        {
            Console.WriteLine("\nEl inventario está lleno, no se puede registrar más.");
        }
        else
        {
            Console.Write("Codigo del producto(5 dígitos):");
            string codigo =Console.ReadLine();

            //Revisamos que el código solo contenga números
            bool soloNumeros = true;
            for (int i=0;i<codigo.Length;i++)
            {
                if (!char.IsDigit(codigo[i]))
                {
                    soloNumeros=false;
                }
            }
            //Revisamos que el codigo del producto no se repita  
            bool repetido = false;
            for (int i=0;i<totalProductos;i++)
            {
                if (codigosProd[i]==codigo)
                {
                    repetido=true;
                }
            }
            if (codigo.Length!=5 || !soloNumeros)
            {
                Console.WriteLine("\nEl codigo debe tener exactamente 5 digitos y solo numeros.");
            }
            else if (repetido)
            {
                Console.WriteLine("\nYa existe un producto con ese codigo.");
        
            }
            else
            {
                Console.Write("Nombre del producto:");
                string nombre=Console.ReadLine();
                //Verificamos que el nombre solo tenga letras
                 bool soloLetras=true;
                 bool hayLetra=false;
                 for (int j=0;j<nombre.Length;j++)
                {
                    if (char.IsLetter(nombre[j]))
                    {
                        hayLetra=true;
                    }
                    else if (nombre[j] != ' ')
                    {
                        soloLetras=false;
                    }
                }
                if (!hayLetra||!soloLetras)
                {
                    Console.WriteLine("\nEl nombre debe tener solo letras y no puede estar vacío");
                }
                else
                {
                    Console.Write("Stock inicial:");
                    string stockText=Console.ReadLine();
                    Console.Write("Precio unitario:");
                    string preciotext=Console.ReadLine();

                    if (stockText=="" || preciotext == "")
                    {
                        Console.WriteLine("\nEscriba el precio y el stock del producto");
                    }
                    else
                    {
                        int stock=int.Parse(stockText);
                        double precio=double.Parse(preciotext);

                        if (stock<0|| precio<0)
                        {
                            Console.WriteLine("\nEl stock y el precio no pueden ser negativos");
                        }
                        else
                        {
                            codigosProd[totalProductos]=codigo;
                            nombresProd[totalProductos]=nombre;
                            stocksProd[totalProductos]=stock;
                            preciosProd[totalProductos]=precio;
                            totalProductos++;
                            Console.WriteLine("\nProducto registrado correctamente.");
                        }

                    }
                }
            }

        }
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
 
// AGREGA esta funcion nueva debajo de BuscarSolicitudPorCodigo():

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

   
   


    
}
























































































































































































































































































































































