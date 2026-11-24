using System;
using System.IO; // Agregamos la Librería para leer y escribir archivos CSV


class Sistema 
{
    //Arreglos para el inventario
    const int MAX_PRODUCTOS = 100;
    static string[] codigosProd = new string[MAX_PRODUCTOS];
    static string[] nombresProd = new string[MAX_PRODUCTOS];
    static int[] stocksProd = new int[MAX_PRODUCTOS];
    static double[] preciosProd = new double[MAX_PRODUCTOS];
    static int totalProductos = 0;
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



    // MODULO 1 CLIENTE 

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



    // MODULO 2: INVENTARIO 

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
        Console.Clear();
        Console.WriteLine("--------REGISTRAR PRODUCTO----------");
        if (totalProductos==MAX_PRODUCTOS)
        {   
            Console.WriteLine();
            Console.WriteLine($"El inventario está lleno, no se puede registrar más.");
            Console.ReadKey();
            return;
            
        }
        
        Console.Write($"Codigo del producto(5 dígitos):");
        string codigo = Console.ReadLine().Trim();

        //Revisamos que el código solo contenga 5 números
        
        bool soloNumeros = true;
        for (int i=0;i<codigo.Length;i++)
        {
            if (!char.IsDigit(codigo[i]))
            {
                 soloNumeros=false;
            }
        }
        if (codigo.Length!=5 || !soloNumeros)
        {
            Console.WriteLine($"El codigo debe tener exactamente 5 digitos y solo numeros.");
            Console.ReadKey();
            return;
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
         if (repetido)
        {
            Console.WriteLine($"Ya existe un producto con ese codigo.");
            Console.ReadKey();
            return;
        }
        //-- Nombre del producto

        Console.Write("Nombre del producto:");
        string nombre = LimpiarCampo(Console.ReadLine().Trim());
        
        //Verificamos que el nombre no puede estar vacìo
        
         if (nombre=="")
        {
            Console.WriteLine();
            Console.WriteLine($"El nombre no puede estar vacío");
            Console.ReadKey();
            return;
        }     
        nombre = nombre.Substring(0, 1).ToUpper() + nombre.Substring(1).ToLower();

        //--Stock : debe ser entero y un número positivo
        int stock;
        string stockText;
        bool stockValido;
        do
        {
          Console.Write("Stock inicial:");
          stockText = Console.ReadLine().Trim();
          stockValido = int.TryParse(stockText, out stock);
          if (stockText == "")
          {
            Console.WriteLine($"Escriba el stock del producto");
          }
          else if (!stockValido)
          {
            Console.WriteLine($"El stock debe ser un numero entero");
          }
          else if (stock < 0)
          {
            Console.WriteLine($"El stock no puede ser negativo");
          }
        } while (!stockValido || stock < 0);

        //--Precio : debe ser un úmero positivo y no acepta letras

        double precio;
        string preciotext;
        bool precioValido;
        do
        {
           Console.Write($"Precio unitario:");
           preciotext = Console.ReadLine().Trim();
           precioValido = double.TryParse(preciotext.Replace(',', '.'), System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out precio);

           if (preciotext == "")
           {
            
            Console.WriteLine($"Escriba el precio del producto");
           }

            else if (!precioValido)
            {
                Console.WriteLine($"El precio debe ser un numero valido");
            }
            else if (precio < 0)
            {
                Console.WriteLine($"El precio no puede ser negativo");
            }
        } while (!precioValido || precio < 0);
        
        codigosProd[totalProductos]=codigo;
        nombresProd[totalProductos]=nombre;
        stocksProd[totalProductos]=stock;
        preciosProd[totalProductos]=precio;
        totalProductos++;
        GuardarInventarioCSV();
        Console.WriteLine($"Producto registrado correctamente.");
    }
    
    // Se ve inventario ordenado alfabéticamente
    static void VerInventario()
    {
        Console.Clear();
        Console.WriteLine($"=========================================");
        Console.WriteLine($"   INVENTARIO COMPLETO - FERRETERIA      ");
        Console.WriteLine($"=========================================");
        if (totalProductos == 0)
        {
            Console.WriteLine();
            Console.WriteLine($"No hay productos registrados todavia.");
            Console.WriteLine();
            Console.WriteLine($"Presione cualquier tecla para volver...");
            Console.ReadKey();
            return;
        }

        
        for (int pasada = 0; pasada < totalProductos - 1; pasada++)
        {
            for (int i = 0; i < totalProductos - 1 - pasada; i++)
            {
                if (string.Compare(nombresProd[i].ToLower(), nombresProd[i + 1].ToLower()) > 0)
                {
                    string tempCodigo = codigosProd[i];
                    codigosProd[i] = codigosProd[i + 1];
                    codigosProd[i + 1] = tempCodigo;

                    string tempNombre = nombresProd[i];
                    nombresProd[i] = nombresProd[i + 1];
                    nombresProd[i + 1] = tempNombre;

                    int tempStock = stocksProd[i];
                    stocksProd[i] = stocksProd[i + 1];
                    stocksProd[i + 1] = tempStock;

                    double tempPrecio = preciosProd[i];
                    preciosProd[i] = preciosProd[i + 1];
                    preciosProd[i + 1] = tempPrecio;
                }
            }
        }
        for (int i = 0; i < totalProductos; i++)
        {
            Console.WriteLine($"Producto {i + 1}");
            Console.WriteLine($"Codigo: {codigosProd[i]}");
             Console.WriteLine($"Nombre: {nombresProd[i]}");
            Console.WriteLine($"Stock: {stocksProd[i]}");
            Console.WriteLine($"Precio: S/ {preciosProd[i]:F2}");
            Console.WriteLine($"-----------------------------------------");
        }

        Console.WriteLine($"Total de productos registrados: {totalProductos}");
        Console.WriteLine();
        Console.WriteLine($"Presione cualquier tecla para volver...");
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

     // Lee el archivo Inventario.csv y llena los arreglos.
    static void CargarInventarioCSV()
    {
        totalProductos=0;
        if (File.Exists(ARCHIVO_INVENTARIO))
        {
            try
            {
                using (var archivo = new StreamReader(ARCHIVO_INVENTARIO))
                {
                    string linea;
                    while ((linea = archivo.ReadLine()) != null)
                    {
                        string[] partes = linea.Split(SEPARADOR);
                        int stock;
                        double precio;

                        if (partes.Length == 4
                            && int.TryParse(partes[2], out stock)
                            && double.TryParse(partes[3], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out precio)
                            && totalProductos < MAX_PRODUCTOS)
                        {
                            codigosProd[totalProductos] = partes[0];
                            nombresProd[totalProductos] = partes[1];
                            stocksProd[totalProductos] = stock;
                            preciosProd[totalProductos] = precio;
                            totalProductos++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo leer " + ARCHIVO_INVENTARIO + ". Cierre el archivo si lo tiene abierto.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                totalProductos = 0;
            }
        }
    }
    
    // Escribe productos.csv con una línea por producto (sobreescribe el archivo)
    static void GuardarInventarioCSV()
    {
        
    }


   
    // MODULO 3 SOLICITUDES
   
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
























































































































































































































































































































































