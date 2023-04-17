using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using Microsoft.Data.SqlClient;
using System;
using Microsoft.VisualStudio.TextTemplating;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Programando.CSharp.Ejercicios.ConsoleApp2.Models;

namespace Programando.CSharp.Ejercicios.ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que residen en USA
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_1();


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Proveedores (Suppliers) de Berlin
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_2();


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Empleados con identificadores 3, 5 y 8
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_3();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_4();



            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero de los proveedores con identificadores 1, 3 y 5
            /////////////////////////////////////////////////////////////////////////////////////////////////

            //consulta_5();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con precio mayor de 20 y menor 90
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_6();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos entre 01/01/1997 y 15/07/1997
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_7(); 



            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos registrados por los empleados con identificador 1, 3, 4 y 8 en 1997
            /////////////////////////////////////////////////////////////////////////////////////////////////

            //consulta_8();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de abril de 1996
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_9();


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos del realizado los dia uno de cada mes del año 1998
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_10();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que no tiene fax
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_11();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más baratos
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_12();



            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más caros con stock
            /////////////////////////////////////////////////////////////////////////////////

            //consulta_13();



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
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
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
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
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
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
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
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
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
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
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

        public static void consulta_6()
        {
            //******************************************* Abro coneccion
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
            };


            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"\nEstado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Products WHERE UnitPrice > 20 AND UnitPrice < 90"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Productos con Stock entre 20 y 90 : ");
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

        public static void consulta_7()
        {
            //******************************************* Abro coneccion
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
            };


            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"\nEstado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Orders WHERE OrderDate >= '1997/01/01' AND OrderDate <= '1997/09/15'"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"PedidosID entre enero y septiembre de 1997: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["OrderID"]);
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

        public static void consulta_8()
        {
            //******************************************* Abro coneccion
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
            };


            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"\nEstado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Orders WHERE YEAR(OrderDate) = 1997 AND EmployeeID IN (1, 3, 4, 8)"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Pedidos registrados por los empleados con identificador 1, 3, 4 y 8 en 1997: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["OrderID"]);
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

        public static void consulta_9()
        {
            //******************************************* Abro coneccion
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
                ConnectionString = connectionString.ToString()
            };


            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"\nEstado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Orders WHERE YEAR(OrderDate) = 1996 AND MONTH(OrderDate) = 4"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Pedidos de abril de 1997: ");
                while (reader.Read())
                {
                    Console.WriteLine(reader["OrderID"]);
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

        public static void consulta_10()
        {
            //******************************************* Abro coneccion
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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
            var connection = new SqlConnection
            {
                ConnectionString = connectionString.ToString()
            };

            // Abrimos conexión a la base de datos
            connection.Open();
            Console.WriteLine($"\nEstado: {connection.State.ToString()} \n");

            //******************************************* Abro coneccion

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Orders WHERE YEAR(OrderDate) = 1998 AND MONTH(OrderDate) IN (1,2,3,4,5,6,7,8,9,10,11,12) AND DAY(OrderDate) = 1"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Pedidos dia 1 de cada mes de 1998: ");
                while (reader.Read())
                {
                    Console.WriteLine($"OrderDate: {reader["OrderDate"]}----->OrderID:{reader["OrderID"]}");
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

        public static void consulta_11()
        {
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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

            var connection = new SqlConnection
            {
                ConnectionString = connectionString.ToString()
            };

            connection.Open();

            Console.WriteLine($"Estado: {connection.State.ToString()} \n");

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Customers WHERE Fax = NULL"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine($"Clientes sin fax:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CompanyName"]}");
                }
            }
            reader.Close();
            reader.Dispose();
            command.Dispose();
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
        }

        public static void consulta_12()
        {
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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

            var connection = new SqlConnection { ConnectionString = connectionString.ToString() };

            connection.Open();
            Console.WriteLine($"Estado: {connection.State.ToString()}");

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT TOP 10 * FROM dbo.Products ORDER BY UnitPrice ASC"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else 
            {
                Console.WriteLine("Top 10 Productos más baratos: ");
                while(reader.Read())
                {
                    Console.WriteLine($"{reader["ProductName"]}->{reader["UnitPrice"]}$");
                }
            }
            reader.Close();
            reader.Dispose();
            command.Dispose();
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
        }

        public static void consulta_13()
        {
            var connectionString = new System.Data.SqlClient.SqlConnectionStringBuilder()
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

            var connection = new SqlConnection { ConnectionString = connectionString.ToString() };

            connection.Open();
            Console.WriteLine($"Estado: {connection.State.ToString()}");

            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT TOP 10 * FROM dbo.Products ORDER BY UnitPrice DESC"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                Console.WriteLine("Top 10 Productos más caros: ");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductName"]}->{reader["UnitPrice"]}$");
                }
            }
            reader.Close();
            reader.Dispose();
            command.Dispose();
            connection.Close();
            connection.Dispose();
            Console.WriteLine($"\nEstado: {connection.State.ToString()}\n");
        }

    }
}