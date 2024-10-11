using System;
using System.Collections.Generic;

class Inventario
{
    struct Producto
    {
        public string Codigo;
        public string Nombre;
        public int Cantidad;
        public decimal Precio;

        public Producto(string codigo, string nombre, int cantidad, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }
    }

    static List<Producto> inventario = new List<Producto>();

    static void MostrarMenu()
    {
        Console.WriteLine("\nMenú de opciones:");
        Console.WriteLine("1. Agregar producto");
        Console.WriteLine("2. Eliminar producto");
        Console.WriteLine("3. Modificar producto");
        Console.WriteLine("4. Consultar producto");
        Console.WriteLine("5. Mostrar todos los productos");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void AgregarProducto()
    {
        Console.Write("Ingrese el código del producto: ");
        string codigo = Console.ReadLine();
        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la cantidad del producto: ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el precio del producto: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        Producto nuevoProducto = new Producto(codigo, nombre, cantidad, precio);
        inventario.Add(nuevoProducto);
        Console.WriteLine("Producto agregado con éxito.");
    }

    static void EliminarProducto()
    {
        Console.Write("Ingrese el código del producto a eliminar: ");
        string codigo = Console.ReadLine();

        bool productoEncontrado = false;
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].Codigo == codigo)
            {
                inventario.RemoveAt(i);
                productoEncontrado = true;
                Console.WriteLine("Producto eliminado con éxito.");
                break;
            }
        }

        if (!productoEncontrado)
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ModificarProducto()
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        string codigo = Console.ReadLine();

        bool productoEncontrado = false;
        for (int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].Codigo == codigo)
            {
                Console.Write("Ingrese el nuevo nombre del producto: ");
                string nuevoNombre = Console.ReadLine();
                Console.Write("Ingrese la nueva cantidad del producto: ");
                int nuevaCantidad = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el nuevo precio del producto: ");
                decimal nuevoPrecio = decimal.Parse(Console.ReadLine());

                inventario[i] = new Producto(codigo, nuevoNombre, nuevaCantidad, nuevoPrecio);
                productoEncontrado = true;
                Console.WriteLine("Producto modificado con éxito.");
                break;
            }
        }

        if (!productoEncontrado)
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ConsultarProducto()
    {
        Console.Write("Ingrese el código del producto a consultar: ");
        string codigo = Console.ReadLine();

        bool productoEncontrado = false;
        foreach (var producto in inventario)
        {
            if (producto.Codigo == codigo)
            {
                Console.WriteLine($"Código: {producto.Codigo}");
                Console.WriteLine($"Nombre: {producto.Nombre}");
                Console.WriteLine($"Cantidad: {producto.Cantidad}");
                Console.WriteLine($"Precio: {producto.Precio:C}");
                productoEncontrado = true;
                break;
            }
        }

        if (!productoEncontrado)
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void MostrarTodosLosProductos()
    {
        if (inventario.Count == 0)
        {
            Console.WriteLine("No hay productos en el inventario.");
        }
        else
        {
            Console.WriteLine("\nInventario de productos:");
            foreach (var producto in inventario)
            {
                Console.WriteLine($"Código: {producto.Codigo} | Nombre: {producto.Nombre} | Cantidad: {producto.Cantidad} | Precio: {producto.Precio:C}");
            }
        }
    }

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            MostrarMenu();
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    EliminarProducto();
                    break;
                case 3:
                    ModificarProducto();
                    break;
                case 4:
                    ConsultarProducto();
                    break;
                case 5:
                    MostrarTodosLosProductos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }

        } while (opcion != 6);
    }
}
