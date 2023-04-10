using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using Microsoft.Data.SqlClient;
using System;
using Microsoft.VisualStudio.TextTemplating;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Programando.CSharp.Ejercicios.ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que residen en USA
            /////////////////////////////////////////////////////////////////////////////////

            consulta_1();


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Proveedores (Suppliers) de Berlin
            /////////////////////////////////////////////////////////////////////////////////

            consulta_2();


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Empleados con identificadores 3, 5 y 8
            /////////////////////////////////////////////////////////////////////////////////

            consulta_3();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero
            /////////////////////////////////////////////////////////////////////////////////

            consulta_4();



            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero de los proveedores con identificadores 1, 3 y 5
            /////////////////////////////////////////////////////////////////////////////////////////////////

            consulta_5();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con precio mayor de 20 y menor 90
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE UnitPrice > 20 AND UnitPrice < 90



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos entre 01/01/1997 y 15/07/1997
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE OrderDate >= '1997/01/01' AND OrderDate <= '1997/09/15'



            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos registrados por los empleados con identificador 1, 3, 4 y 8 en 1997
            /////////////////////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1997 AND EmployeeID IN (1, 3, 4, 8)



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de abril de 1996
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1996 AND MONTH(OrderDate) = 4



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos del realizado los dia uno de cada mes del año 1998
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1998 AND MONTH(OrderDate) = 1



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que no tiene fax
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE Fax = NULL



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más baratos
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más caros con stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice DESC



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Cliente de UK y nombre de empresa que comienza por B
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE CompanyName LIKE 'B%' AND Country = 'Uk'



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos de identificador de categoria 3 y 5
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products WHERE CategoryID IN (3, 5)



            /////////////////////////////////////////////////////////////////////////////////
            // Importe total del stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT SUM(UnitInStock * UnitPrice) FROM Products



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de los clientes de Argentina
            /////////////////////////////////////////////////////////////////////////////////            

            // SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina'
            // SELECT * FROM dbo.Orders WHERE CustomerID IN ('CACTU', 'OCEAN', 'RANCH')


            // SELECT * FROM dbo.Orders WHERE CustomerID IN (SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina')

        }
        static void consulta_1()
        {
            //******************************************* Abro coneccion
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

            // Creamos el objeto conexión
            var connection = new SqlConnection()
            {
                ConnectionString = connectioString.ToString()
            };



            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"Estado: {connection.State.ToString()}\n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Customers WHERE Country = 'USA'"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Clientes de USA: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["CompanyName"]);
                }
            }

            reader.Close();
            command.Dispose();
            //******************************************* Cierro coneccion
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
            //******************************************* Cierro coneccion
        }
        static void consulta_2()
        {
            //******************************************* Abro coneccion
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

            // Creamos el objeto conexión
            var connection = new SqlConnection()
            {
                ConnectionString = connectioString.ToString()
            };



            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"Estado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Suppliers WHERE City = 'Berlin'"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Proveedores de Berlin: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["CompanyName"]);
                }
            }

            reader.Close();
            command.Dispose();
            //******************************************* Cierro coneccion
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
            //******************************************* Cierro coneccion

        }
        static void consulta_3()
        {
            //******************************************* Abro coneccion
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

            // Creamos el objeto conexión
            var connection = new SqlConnection()
            {
                ConnectionString = connectioString.ToString()
            };



            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"Estado: {connection.State.ToString()}\n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT* FROM dbo.Employees WHERE EmployeeID IN(3, 5, 8)"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Empleados Con EmployeeID en 3,5,8: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["FirstName"]);
                }
            }

            reader.Close();
            command.Dispose();
            //******************************************* Cierro coneccion
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
            //******************************************* Cierro coneccion

        }
        static void consulta_4()
        {
            //******************************************* Abro coneccion
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

            // Creamos el objeto conexión
            var connection = new SqlConnection()
            {
                ConnectionString = connectioString.ToString()
            };



            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"\nEstado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Products WHERE UnitsInStock > 0"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Productos con Stock mayor que 0: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["ProductName"]);
                }
            }

            reader.Close();
            command.Dispose();
            //******************************************* Cierro coneccion
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
            //******************************************* Cierro coneccion

        }
        public static void consulta_5()
        {
            //******************************************* Abro coneccion
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

            // Creamos el objeto conexión
            var connection = new SqlConnection()
            {
                ConnectionString = connectioString.ToString()
            };


            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"\nEstado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Products WHERE SupplierID IN (1, 3, 5) AND UnitsInStock > 0"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Productos con Stock mayor que 0 de SupplierID 1,3 y 5: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["ProductName"]);
                }
            }
            reader.Close();
            command.Dispose();
            //******************************************* Cierro coneccion
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
            //******************************************* Cierro coneccion
        }
    }
}