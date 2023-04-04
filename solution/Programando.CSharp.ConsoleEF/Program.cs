using Programando.CSharp.ConsoleEF.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using Microsoft.Data.SqlClient;
using System;
using Microsoft.VisualStudio.TextTemplating;

namespace Programando.CSharp.ConsoleEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //ConsultaConADONET();
            TrabajandoConEF();
        }

        static void ConsultaConADONET()
        {
            var connectioString = new System.Data.SqlClient.SqlConnectionStringBuilder()
            {
                DataSource = "eoi-api.eastus.cloudapp.azure.com",
                InitialCatalog = "Northwind",
                UserID = "eoiuser",
                Password = "Pa$$w0rd",
                IntegratedSecurity = false,
                ConnectTimeout = 60,
                TrustServerCertificate = false,
                Encrypt = false
            };
            
            Console.WriteLine($"Cadena de conexión: {connectioString.ToString()}");

            // Creamos el objeto conexión
            var connection = new SqlConnection()
            {
                ConnectionString = connectioString.ToString()
            };



            // Abrimos conexión a la base de datos
            Console.WriteLine($"Estado: {connection.State.ToString()}");
            connection.Open();
            Console.WriteLine($"Estado: {connection.State.ToString()}");



            // Ejecutar un comando SELECT * FROM dbo.Customers
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Customers"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                while(reader.Read()) 
                {
                    Console.WriteLine($"{reader["CustomerID"]}#  {reader.GetValue(1)}");
                }
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            connection.Dispose();

        }

        static void TrabajandoConEF()
        {
            // Instanciamos la clase del contexto
            var context = new ModelNorthwind();

            // DELETE, elimina un cliente

            //var customer = context.Customers
            //    .Where(r => r.CustomerID == "DEMO8")
            //    .FirstOrDefault();

            //context.Remove( customer );
            //context.SaveChanges();

            //Console.WriteLine("Cliente Modificado");
            //Console.ReadKey();

            // UPDATE, modificar un cliente

            var customer = context.Customers
                .Where(r=> r.CustomerID == "DEMO1")
                .FirstOrDefault();

            customer.CompanyName = "Helados Maria";
            customer.ContactName = "Maria Mar";
            context.SaveChanges();

            Console.WriteLine("Cliente Modificado");
            Console.ReadKey();


            // INSERT, insertar un nuevo cliente
            var cliente = new Customer()
            {
                CustomerID = "DEMO8",
                CompanyName = "Empresa Uno SL",
                ContactName = "Borja Cabeza",
                ContactTitle = "Propietario",
                Address = "Calle Uno, S/N",
                Region = "",
                City = "Madrid",
                PostalCode = "28014",
                Country = "Spain",
                Phone = "919109090",
                Fax = "919109090"
            };

            context.Customers.Add( cliente );
            context.SaveChanges();

            Console.ReadKey();


            // SELECT * FROM dbo.Customers
            var clientes = context.Customers
                .ToList();

            var clientes2 = from r in context.Customers
                            select r;

            //clientes[0].CompanyName = "";
            //clientes[7].Country = "";

            foreach (var item in clientes)
                Console.WriteLine($"{item.CustomerID}# {item.CompanyName}");


            
        }


    }
}