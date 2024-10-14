using System;
using System.Collections.Generic;

public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, double precio, int cantidad)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
}

public class Inventario
{
    private List<Producto> productos = new List<Producto>();

    // Función para agregar un producto al inventario
    public void AgregarProducto(string nombre, double precio, int cantidad)
    {
        productos.Add(new Producto(nombre, precio, cantidad));
        Console.WriteLine($"Producto {nombre} agregado correctamente.");
    }

    // Función para actualizar la cantidad de stock de un producto existente
    public void ActualizarStock(string nombre, int nuevaCantidad)
    {
        Producto producto = productos.Find(p => p.Nombre == nombre);
        if (producto != null)
        {
            producto.Cantidad = nuevaCantidad;
            Console.WriteLine($"Stock de {nombre} actualizado a {nuevaCantidad} unidades.");
        }
        else
        {
            Console.WriteLine($"El producto {nombre} no se encuentra en el inventario.");
        }
    }

    // Función para calcular el valor total del inventario
    public double CalcularValorTotal()
    {
        double valorTotal = 0;
        foreach (Producto producto in productos)
        {
            valorTotal += producto.Precio * producto.Cantidad;
        }
        return valorTotal;
    }

    // Función para mostrar el inventario actual
    public void MostrarInventario()
    {
        Console.WriteLine("Inventario actual:");
        foreach (Producto producto in productos)
        {
            Console.WriteLine($"Producto: {producto.Nombre}, Precio: {producto.Precio}, Cantidad: {producto.Cantidad}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Inventario inventario = new Inventario();
        
        // Menú de opciones
        while (true)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Actualizar stock");
            Console.WriteLine("3. Calcular valor total del inventario");
            Console.WriteLine("4. Mostrar inventario");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el precio del producto: ");
                    double precio = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingrese la cantidad del producto: ");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    inventario.AgregarProducto(nombre, precio, cantidad);
                    break;

                case 2:
                    Console.Write("Ingrese el nombre del producto a actualizar: ");
                    nombre = Console.ReadLine();
                    Console.Write("Ingrese la nueva cantidad: ");
                    int nuevaCantidad = Convert.ToInt32(Console.ReadLine());
                    inventario.ActualizarStock(nombre, nuevaCantidad);
                    break;

                case 3:
                    double valorTotal = inventario.CalcularValorTotal();
                    Console.WriteLine($"El valor total del inventario es: {valorTotal}");
                    break;

                case 4:
                    inventario.MostrarInventario();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
