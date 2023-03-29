// ########################################################################################
// #  Ejercicio 1A
// ########################################################################################
// """  Escribe una función para calcular el consumo medio de combustible de un vehículo.

// Entrada de datos:
//     -Kilometros recorridos
//     -Listros de combustible consumidos
// Salida de datos:
//     -litros consumidos por kilometro
// """
// #########################################################################################
// #Con funcion
// """def consumo(Km, Litros):
//     return Litros/Km"""




//Toma de datos

using _01_A;
using System.ComponentModel.Design;

int volver = 1;
while (volver == 1)
{
    while (volver == 1)
    {
        try
        {
            var coche = new Coche();
            Console.WriteLine("Bienvenido");
            Console.Write("Introduzca la cantidad de Litros: ");
            coche.Litros = float.Parse(Console.ReadLine());
            //Console.WriteLine(coche.Litros);
            Console.Write("Introduzca la cantidad de Km: ");
            coche.Km = float.Parse(Console.ReadLine());
            if(coche.Km==0)
                throw new DivideByZeroException();
            //Console.WriteLine(coche.Km);
            //Console.WriteLine(coche.Km.GetType());
            Console.WriteLine($"El coche consume: {coche.Consumo():N2} Litros por KM");
            volver = 0;

        }

        catch (System.FormatException)
        {
            Console.WriteLine("Datos incorrectos no se puede convertir");

        }
        catch (System.DivideByZeroException) 
        {
            Console.WriteLine("Division por 0 no permitida");
            Console.ReadKey();
        }
    }

    int volver2 = 1;
    while (volver2 == 1) 
    {
        try
        {
            Console.WriteLine("Pulse 0 para Salir, Cualquier otro numero volver a intentar : ");
            volver = int.Parse(Console.ReadLine());
            if (volver!= 0) 
            { 
                volver = 1;
                volver2 = 0;
            }
            else
            {
                volver2 = 0;
            }


        }
        catch (System.Exception)
        {
            Console.WriteLine("No se introdujo un numero");
            volver2 = 1;

        }    
    }
}