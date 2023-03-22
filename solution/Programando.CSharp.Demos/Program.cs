using System;
using Universidad;


//namespace Formacion.CSharp.Demos; Se puede poner asi si es un solo namespace
namespace Programando.CSaharp.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Variable de tipo referencia el valor predeterminado es NULL
            //Variable de tipo valor el valor predeterminado es 0
            string texto;
            string otroTexto = "Hola Mundo !!!";
            int numero = 123;
            int otronumero = 433;
            decimal a, b, c;

            int? numero4 = null;

            Alumno alumno1 = new Alumno();
            alumno1.nombre = "Alejandro";
            var alumno2 = new Alumno();
            Object alumno3 = new Alumno();
            dynamic alumno4 = new Alumno();
            
            Console.WriteLine("Tipo de la variable 1: " + alumno1.GetType());
            Console.WriteLine("Nombre: {0}",alumno1.nombre);
        }
    }
}



namespace Universidad
{
    public class Alumno
    {
        public string nombre;

        public string apellidos;

        public int edad;
    }

}