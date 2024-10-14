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

