using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Programando.CSharp.Ejercicios.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConsultasBasicas();
            Ejercicios();
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


            // Encontrar el primer producto que salga con un Id especifico
            var producto = DataLists.ListaProductos
                .Where(r => r.Id == 4)
                .FirstOrDefault();

            // Paginacion en PC
            var lista = DataLists.ListaProductos
               .OrderBy(r => r.Descripcion)
               .Skip(5)//ignora los primeros 5
               .Take(5)//Coge solo 5
               .Select(r => r);

            Console.WriteLine("");
            foreach (var item in r6b) Console.WriteLine($"{item.Precio}");



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

            Console.Clear();
        }




        static void Ejercicios()
        {
            // Listado de clientes mayores de 50

            var cincuentañeros = DataLists.ListaClientes
                .Where(r => r.FechaNac.Year < DateTime.Now.AddYears(-50).Year)
                .Select(r => r.Nombre);

            Console.WriteLine("Los clientes mayores de 50 son: ");
            foreach (var item in cincuentañeros) Console.WriteLine($"{item}");

            Console.WriteLine("");

            // Listado de productos que comiencen por la letra c ordenar por precio

            var cproduct = from r in DataLists.ListaProductos
                           where r.Descripcion.ToLower()[0] == 'c'
                           //where .Descripcion.ToLower().StartWith("c")
                           select r.Descripcion;

            Console.WriteLine("Los pedidos q comienzan por c son: ");
            foreach (var item in cproduct) Console.WriteLine($"{item}");

            Console.WriteLine("");


            // Preguntar por el id de un pedido y listar el contenido

            Console.Write("Digame el pedido: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Los datos de su pedido son:");
            var pedidos = DataLists.ListaPedidos
               .Where(r => r.Id == id)
               .Select(r => r);
            var productos = DataLists.ListaProductos
                .Where(r => r.Id == id)
                .Select(r => r);
            var lineas = DataLists.ListaLineasPedido
                .Where(r => r.IdPedido == id)
                .Select(r => r);



            foreach (var item in pedidos) Console.WriteLine($"Id_Cliente: {item.IdCliente}");
            foreach (var item in pedidos) Console.WriteLine($"Fecha: {item.FechaPedido}");
            foreach (var item in productos) Console.WriteLine($"Description: {item.Descripcion}");
            foreach (var item in lineas) Console.WriteLine($"Id Linea de pedido: {item.Id}");
            foreach (var item in lineas) Console.WriteLine($"Id de producto: {item.IdProducto}");
            foreach (var item in lineas) Console.WriteLine($"Cantidad: {item.Cantidad}");
            foreach (var item in productos) Console.WriteLine($"Precio: {item.Precio}");

            Console.WriteLine("");



            // Mostrar el total value de ese pedido,cantxprecio
            Console.Write("Número de Pedido: ");
            int idPedido = Convert.ToInt32(Console.ReadLine());

            var total = DataLists.ListaLineasPedido
                .Where(r => r.IdPedido == idPedido)
                .Sum(r => r.Cantidad * DataLists.ListaProductos
                                            .Where(s => s.Id == r.IdProducto)
                                            .Select(s => s.Precio)
                                            .FirstOrDefault());

            Console.WriteLine($"Importe Total: {total.ToString("N2")}");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("");


            // Listado de pedidos que contengan Lapicero 
            var id_prod = from r in DataLists.ListaProductos
                          where r.Descripcion == "Lapicero"
                          select r.Id;


            var id_linea2 = from r in DataLists.ListaLineasPedido
                            where r.IdProducto == id_prod.First()
                            select r.Id;

            Console.WriteLine("Las lineas de pedido q contienen Lapicero son:");
            foreach (var item in id_linea2) Console.WriteLine($"Linea: {item}");

            Console.WriteLine("");


            // Contamos cantidad de pedidos que contengan Cuaderno Grande
            var id_prod2 = from r in DataLists.ListaProductos
                           where r.Descripcion == "Cuaderno grande"
                           select r.Id;


            var cantidades = from r in DataLists.ListaLineasPedido
                             where r.IdProducto == id_prod2.First()
                             select r.Cantidad;


            Console.WriteLine($"Hay {cantidades.Count()} lineas de pedido q tienen Cuaderno Grande");
            Console.WriteLine("La cantidad total pedida de Cuaderno Grande es:");

            int total2 = 0;
            for (int i = 0; i < cantidades.Count(); i++)
            {
                //Console.WriteLine(cantidades.ToList()[i]);
                total2 += (cantidades.ToList()[i]);

            }

            Console.WriteLine(total2);

            Console.WriteLine("");


            // Unidades vendidas de Cuaderno pequeño
            var id_cp = from r in DataLists.ListaProductos
                        where r.Descripcion.ToLower() == "cuaderno pequeño"
                        select r.Id;

            var cantidades_cp = from r in DataLists.ListaLineasPedido
                                where r.IdProducto == id_cp.First()
                                select r.Cantidad;
            var suma = 0;
            foreach (var item in cantidades_cp) { suma += item; }
            Console.WriteLine($"La cantidad total vendida de Cuaderno pequeño es: {suma}");


            // El pedido que mas unidades contiene hecho con for y listas
            var bigger = 0;
            var bigger_id = 0;

            // Recorro todos los pedidos, consulto las cantidades y en el foreach sumo las del mismo idproduct
            for (int i = 1; i < 13; i++)
            {
                var cantidades_totales = DataLists.ListaLineasPedido
                                 .Where(r => r.IdProducto == i)
                                 .Select(r => r.Cantidad);
                var cant_sumada = 0;
                foreach (var item2 in cantidades_totales) 
                {
                    cant_sumada += item2;
                     
                }
                Console.WriteLine($"La cantidad de IdProducto {i} es: {cant_sumada}");
                if(cant_sumada > bigger) 
                {
                    bigger = cant_sumada;
                    bigger_id = i;
                }
                
            }
            Console.WriteLine($"El IdProducto de mayor cantidad es : {bigger_id}");
            
            // Listados de pedidos ordenados por fecha
        }
    }

}