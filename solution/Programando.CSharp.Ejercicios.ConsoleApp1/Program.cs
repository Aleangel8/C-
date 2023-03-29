using System;

namespace Programando.CSharp.Ejercicios.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsultasBasicas();
        }

        static void ConsultasBasicas()
        {
            //T-SQL:SELECT * FROM dbo.ListaProductos

            // Métodos de LINQ
            var r1a = DataLists.ListaProductos
                .Select(r => r);//lambda function

            // Expresion de LINQ
            var r1b = from r in DataLists.ListaProductos
                      select r;

            foreach (Producto item in r1a) Console.WriteLine($"{item.Id} {item.Descripcion}");



            //T-SQL:SELECT Nombre FROM dbo.ListaClientes


            // Métodos de LINQ

            var r2a = DataLists.ListaClientes

                .Select(r => r.Nombre);

            // Expresión LINQ

            var r2b = from r in DataLists.ListaClientes

                      select r.Nombre;


            //T-SQL:SELECT Id, Nombre FROM dbo.ListaClientes

            // Métodos de LINQ
            var r3a = DataLists.ListaClientes

                .Select(r => new { r.Id, r.Nombre });

            // Expresión LINQ
            var r3b = from r in DataLists.ListaClientes

                      select r.Id;

            //T-SQL:SELECT Id As Code, Nombre As Nombrecompleto FROM dbo.ListaClientes
            var r3c = DataLists.ListaClientes

                 .Select(r => new { Code = r.Id, NombreCompleto = r.Nombre });


            foreach (var item in r3a) Console.WriteLine($"{item.Id}");// Id
            foreach (var item in r3a) Console.WriteLine($"{item.Nombre}");// Nombre
            foreach (var item in r3c) Console.WriteLine($"{item.Code}");//Con Alias



            //T-SQL: SELECT Descripcion FROM dbo.ListaOridyctis WHERE precio < 0.90

            // Métodos de LINQ
            var r4a = DataLists.ListaProductos
                .Where(r => r.Precio < 0.90)
                .Select(r => r.Descripcion);//lambda function

            // Expresion de LINQ
            var r4b = from r in DataLists.ListaProductos
                      where r.Precio < 0.90
                      select r;


            foreach (var item in r4a) Console.WriteLine($"{item}");

            

            //T-SQL: SELECT Descripcion FROM dbo.ListaOridyctis WHERE precio < 0.90 ORDERBY Description
            // Métodos de LINQ
            var r5a = DataLists.ListaProductos
                .Where(r => r.Precio < 0.90)
                .OrderByDescending(r => r.Descripcion) 
                .Select(r => r.Descripcion);//lambda function

            // Expresion de LINQ
            var r5b = from r in DataLists.ListaProductos
                      where r.Precio < 0.90
                      orderby r.Descripcion ascending 
                      select r.Descripcion;

            Console.WriteLine("");
            foreach (var item in r5b) Console.WriteLine($"{item}");

            

            //Otros Ejemplos

            // Contains -> Contiene; StarsWith -> Comienza; EndsWith -> Finaliza

            // Métodos de LINQ
            var r6a = DataLists.ListaProductos
                .Where(r => r.Descripcion.ToLower().Contains("boli"))
                .Select(r => r);//lambda function

            // Expresion de LINQ
            var r6b = from r in DataLists.ListaProductos
                      where r.Descripcion.ToLower().Contains("boli")
                      select r;


            Console.WriteLine("");
            foreach (var item in r6b) Console.WriteLine($"{item.Precio}");

            Console.Clear();

            // Count -> Cuenta los elmentos
            // Distinct -> Valor distinto
            // Max -> valor máximo;
            // Min -> valor minimo
            // Sum -> suma de valores;
            // Average -> media de los valores
            // Aggregate -> Aplicar formula o métod de Agregación


            var r7a = DataLists.ListaProductos
                .Where(r => r.Precio < 0.90)
                .Count();


            var r7b = DataLists.ListaProductos
                .Count(r => r.Precio < 0.90);


            var r7c = (from r in DataLists.ListaProductos
                       where r.Precio < 0.90
                       select r.Descripcion).Count();


        }
    }
}