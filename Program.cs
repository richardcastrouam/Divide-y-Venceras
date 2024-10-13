using System;

public class MergeSort
{
    public static void Main()
    {
        int[] arreglo = { 38, 27, 43, 3, 9, 82, 10 };
        Console.WriteLine("Arreglo original:");
        ImprimirArreglo(arreglo);

        Ordenar(arreglo, 0, arreglo.Length - 1);

        Console.WriteLine("\nArreglo ordenado:");
        ImprimirArreglo(arreglo);
    }

    public static void Ordenar(int[] arreglo, int inicio, int fin)
    {
        if (inicio < fin)
        {
            int medio = (inicio + fin) / 2;

            // Dividir el problema en dos mitades
            Ordenar(arreglo, inicio, medio);
            Ordenar(arreglo, medio + 1, fin);

            // Combinar las dos mitades
            Merge(arreglo, inicio, medio, fin);
        }
    }

    public static void Merge(int[] arreglo, int inicio, int medio, int fin)
    {
        int[] temp = new int[fin - inicio + 1];
        int i = inicio, j = medio + 1, k = 0;

        // Mezclar las dos mitades en un arreglo temporal
        while (i <= medio && j <= fin)
        {
            if (arreglo[i] <= arreglo[j])
            {
                temp[k++] = arreglo[i++];
            }
            else
            {
                temp[k++] = arreglo[j++];
            }
        }

        // Copiar los elementos restantes de la primera mitad
        while (i <= medio)
        {
            temp[k++] = arreglo[i++];
        }

        // Copiar los elementos restantes de la segunda mitad
        while (j <= fin)
        {
            temp[k++] = arreglo[j++];
        }

        // Copiar el arreglo temporal al arreglo original
        for (k = 0; k < temp.Length; k++)
        {
            arreglo[inicio + k] = temp[k];
        }
    }

    public static void ImprimirArreglo(int[] arreglo)
    {
        foreach (int num in arreglo)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
