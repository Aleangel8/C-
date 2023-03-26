using System;
using Universidad;




//namespace Formacion.CSharp.Demos; Se puede poner asi si es un solo namespace
namespace Programando.CSharp.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            SentenciasControl();
            //SentenciasControl2();
        }


         static void SentenciasControl()
        {

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
                    reserva3.tipo=100;
                    break;
                case "200":
                    reserva3.tipo=200;
                    break;
                case "300":
                    reserva3.tipo=300;
                    break;
                case "400":
                    reserva3.tipo=400;
                    break;
                default:
                    reserva3.tipo=-1;
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
       
    }
}



