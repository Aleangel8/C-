using System;
using Universidad;
using System.Collections;
using System.Collections.Generic;




//namespace Formacion.CSharp.Demos; Se puede poner asi si es un solo namespace
namespace Programando.CSharp.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            //SentenciasControl();
            //SentenciasControl2();
        }


        static void SentenciasControl()
        {
            Reserva[] reservas_list = new Reserva[5];
            //Modo 1 de crear reserva. Accede porque las variables son publicas
            var reserva = new Reserva();
            reserva.id = "1066HC";
            reserva.cliente = "Ana García";
            reserva.fumador = true;



            //Modo 2 de crear reserva.Pasa los parametros entre llaves
            var reserva2 = new Reserva()
            {
                id = "1066HC",
                cliente = "Ana García",
                fumador = true
            };
            //Modo 3 de crear reserva.Preguntando y rellenando los datos
            var reserva3 = new Reserva();

            Console.Write("ID Reserva: ");
            reserva3.id = Console.ReadLine();

            Console.Write("Nombre de Cliente: ");
            reserva3.cliente = Console.ReadLine();

            // 100: Individual 200: Doble 300: Junior Suite 400: Suite
            Console.Write("Tipo de habitación: ");
            //int.TryParse(Console.ReadLine(),out reserva3.tipo); //Mejor
            //reserva3.tipo = int.Parse(Console.ReadLine());
            string valor = Console.ReadLine();
            switch (valor)
            {
                case "100":
                    reserva3.tipo = 100;
                    break;
                case "200":
                    reserva3.tipo = 200;
                    break;
                case "300":
                    reserva3.tipo = 300;
                    break;
                case "400":
                    reserva3.tipo = 400;
                    break;
                default:
                    reserva3.tipo = -1;
                    break;
            }



            Console.Write("Es fumador? si o no: ");
            var valor2 = Console.ReadLine();
            switch (valor2.ToUpper())
            {
                case "SI":
                    reserva.fumador = true;
                    break;
                case "NO":
                    reserva.fumador = false;
                    break;
                default:
                    Console.WriteLine("Por default eres no fumador");
                    reserva.fumador = false;
                    break;
            }
            Console.WriteLine($"La reserva es de :{reserva.fumador}");
            //Mostrar ID Reserva y nombre
            //Mostrar utilizando IF/ELSE tipo de habitacion en texto
            //Mostrar utilizando SWITCH si es fumador
        }

        static void SentenciasControl2()
        {
            int[] nums;
            int[] nums2 = new int[5];
            int[] nums3 = new int[5] { 1, 8, 74, 1, -10 };//sintaxis en deshuso
            int[] nums4 = new int[] { 1, 8, 74, 1, -10 };

            int[] numeros = { 10, 95, -2, 32, 118, 72, -52 };
            string[] frutas = { "naranja", "limon", "pomelo", "líma" };

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
            }

            foreach (var fruta in frutas)
            {
                Console.WriteLine($"{fruta}");
            }
        }


        public static void ArrayList()
        {
            //Instanciar
            ArrayList array = new ArrayList();

            // Limpiar y eliminar los elementos
            array.Clear();

            // Añadir elementos
            array.Add(1);
            array.Add("Borja");
            array.Add(new { Nombre = "Borja", Apellidos = "Cabeza" });
            array.Add(new Alumno());

            // Añadir elementos en una posicion
            array.Insert(4, "blanco");

            // Añadir todos los elementos de otra colección
            var colores = new string[] { "azul", "rojo", "verde", "amarillo" };
            array.AddRange(colores);

            // Numero de elementos del ArrayList
            Console.WriteLine(array.Count);

            //Eliminar elementos
            array.Remove("azul");
            array.RemoveAt(4);
            array.RemoveRange(2, 2);

            // Como saber si el elemento esta contenido
            Console.WriteLine($"Contiene el item rojo: {array.Contains("rojo")}");

            // Ordena los elementos
            array.Sort();

            // Invertir el orden
            array.Reverse();

            // Convertir en un array de objetos-> object[] array = new array[10]
            var nuevoArray = array.ToArray();

            // Recorrer la colección
            foreach (var item in array)
            {
                Console.WriteLine($"Item: {item.GetType().ToString()}");
            }

            for (var i = 0; i < array.Count; i++)
            {
                Console.WriteLine($"{i}# {array[i]}");
            }


        }

        public static void Hashtable()//Hashtable son los diccionarios, hash es clave
        {
            //Instanciar
            var ht = new Hashtable();

            // Eliminar todos los elementos
            ht.Clear();

            // Añadir elementos
            ht.Add(1200, "Borja Cabeza");
            ht.Add("AnnaTR", "Ana Trujillop");
            ht.Add(412, new Alumno());

            // Numero de elementos
            Console.WriteLine($"Numero de elementos: {ht.Count}");

            // Eliminar un elemento
            ht.Remove(1200);

            // Recorrer el HashTable
            foreach (var clave in ht.Keys)
                Console.WriteLine($"{clave}: {ht[clave]}");

        }

        public static void List()
        {

            // Instanciar
            List<string> list = new List<string>();

            List<string> list1 = new();
            var list2 = new List<string>();

            // Eliminar los elementos

            list.Clear();



            // Añadir elementos

            list.Add("azul");

            list.Add("verde");

            list.Add("rosa");

            list.Add("amarillo");



            // Añadir elementos en una posición

            list.Insert(4, "blanco");



            // Añadir todos los elementos de otra colección

            var colores = new string[] { "marron", "naranja", "negro", "violeta" };

            list.AddRange(colores);



            // Número de elementos del List

            Console.WriteLine($"Número de elementos: {list.Count}");



            // Eliminar elementos

            list.Remove("azul");

            list.RemoveAt(4);

            list.RemoveRange(2, 2);



            // Saber si un elemento esta contenido

            Console.WriteLine($"Contiene el item rojo: {list.Contains("rojo")}");



            // Orderna los elementos

            list.Sort();



            // Invertir el orden

            list.Reverse();



            // Convertir en un array de object -> object[] array = new array[10]

            var nuevoArray = list.ToArray();



            // Recorrer el List

            foreach (var item in list)

                Console.WriteLine($"{list.IndexOf(item)}# Item: {item}");



            for (var i = 0; i < list.Count; i++)

                Console.WriteLine($"{i}# {list[i]}");
        }

        public static void Dictionary()
        {
            // Instanciar
            Dictionary<int, string> dic = new Dictionary<int, string>();

            Dictionary<int, string> dic1 = new();
            var dic2 = new Dictionary<int, string>();

            // Eliminar todos los elementos
            dic.Clear();

            // Añadir elementos
            dic.Add(1200, "Borja Cabeza");
            dic.Add(1300, "Ana Trujillo");
            dic.Add(1412, "José Guzman");

            // Modificar un valor
            dic[1300] = "Antonio Trujillo";

            // Número de elementos
            Console.WriteLine($"Número de elementos: {dic.Count}");

            // Eliminar un elemento
            dic.Remove(1200);

            // Recorrer el diccionario
            foreach (var clave in dic.Keys)
                Console.WriteLine($"{clave}: {dic[clave]}");
        }

    }
}



