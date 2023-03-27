namespace Programando.CSharp.ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;
            var demo = new Demo();

            var persona = new Persona(){
                nombre = "Ana",
                edad =35
            };
            var persona2 = new Persona2(){
                nombre = "Ana",
                edad =35
            };

            var alumno= new Alumno();
            var alumno1= new Alumno("Pepe",18);

            alumno.Nombre="Borja";
            alumno.Apellidos="Gonzales";
            Console.Clear();
            Console.WriteLine(alumno.Nombre);
            Console.WriteLine(alumno.NombreCompleto);

            
            //Console.WriteLine($"Nombre antes: {persona2.nombre}");
            //Console.WriteLine($"Edad antes: {persona2.edad}");
            //demo.transforma(ref persona2);
            //Console.WriteLine($"Nombre despues: {persona2.nombre}");
            //Console.WriteLine($"Edad despues: {persona2.edad}");

            //Console.Clear();
            //Console.WriteLine($"Valor num1: {num1}");
            //Console.WriteLine($"Valor num2: {num2}");
            //demo.transforma(ref num1,out num2);
            //Console.WriteLine($"Valor num1: {num1}");
            //Console.WriteLine($"Valor num2: {num2}");

        }

    }

    public class Demo
    {
        public void transforma(ref int a,out int b)//al usar out hay q asignar un valor inicial
        {
            a = a * 10;
            b = 75;
            a = 789;
            Console.WriteLine($"Valor A: {a}");
            Console.WriteLine($"Valor B: {b}");
            
        }
        
        public void transforma(ref Persona2 P)
        {
            P.nombre="Julian";
            P.edad=27;
            
        }
        

    }

    // Las CLASS son objetos de tipo referencia
    public class Persona
    {
        public string nombre="";
        public int edad=0;
    }
    

    // Las STRUCT son objetos de tipo valor
    public struct Persona2
    {
        public string nombre="";
        public int edad;

        public Persona2()
        {

        }
    }

   


    public class Alumno
    {
        //Miembro: Variables
        private string nombre;

        private string apellidos;

        //private string curso;  //Sobra

        private int edad;

        public string Nombre
        {
            get
            {
                return nombre.Trim().ToLower();
            } 
            set
            {
                if(value.Length < 3) nombre = "";
                else nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return apellidos;
            } 
            //get =>apellidos;
            set
            {
                apellidos = value;
            }
            //set => apellidos=value;
        }

        public string Curso {get;set;}

         public int Edad

        {
            get { return edad; }

            set 
            { 
                if (value < 0 || value > 120) edad = 0;

                else edad = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return $"{this.nombre} {this.apellidos}";
            }
        }

        //Miembro: Metodo q no retorna nada

        public void MetodoUno() { }

        //Miembro: Metodo q  retorna int
        public int MetodoDos()
        {
            return 0;
        }

        //Miembro: Metodo q recibe parametros
        public int MetodoTres(int param1, string param2)
        {
            this.nombre = param2;
            this.edad = param1;
            return 0;
        }

        //Miembro: Metodo Suma
        public int Suma(int param1, int param2)
        {
            int resultado = param1 + param2;
            return resultado;
        }

        private void Inicializa(string nombre="", string apellidos="", int edad=0)
        {
           this.nombre = nombre;

            this.apellidos = apellidos;

            this.edad = edad; 
        }


        // Miembro: Metodo o Funcion Constructora
        // Es público, no tiene tipo y se llama igual que la clase
        // No se puede invocar, se ejecuta al crear el objeto
        public Alumno()
        {

        }
        public Alumno(string nombre, int edad)
        {
            Inicializa(nombre:nombre, edad:edad);
        }
        public Alumno(string nombre, string apellidos, int edad)
        {
            Inicializa(nombre:nombre,apellidos:apellidos,edad:edad);
        }

        // Miembro: Método destructor
        // No se puede invocar, se ejecuta automaticamente
        // No tiene parametros y destruye las variables
        ~Alumno()
        {
            System.Diagnostics.Debug.WriteLine("Destruccion del objeto Alumno.");
            this.nombre = null;
            this.apellidos = null;
        }

    }


}
