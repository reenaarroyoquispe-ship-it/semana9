using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


namespace Semana9

{

    internal class Program

    {
        static int max_emp = 50;

        static string[] nombres_empleado = new string[max_emp];

        static string[] apellido_empleado = new string[max_emp];

        static string[] correo_empleado = new string[max_emp];

        static int cont_empleado = 0;

        static string rutaarchivo = "empleado_datos.txt";

        static public void Titulo()

        {
            Console.WriteLine("===============");

            Console.WriteLine("++Sistema de Empleados Arreglos y Cadenas++");

            Console.WriteLine("===============");
        }

        static public void RegistroEmpleado()

        {
            if (cont_empleado >= max_emp)

            {
                Console.WriteLine("Capacidad maxima alcanzada");
                return;
            }


            Console.WriteLine("Ingrese el nombre del empleado:");

            string nombres = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nombres))

            {
                Console.WriteLine("Error: El nombre no puede estar vacío.");

                return;
            }

            string nombres_mayus = nombres.ToUpper();

            string[] partes = nombres_mayus.Split(' ');

            string primer_nombre;

            if (partes.Length > 0)

            {

                primer_nombre = partes[0];

            }

            else

                primer_nombre = "Usuario";


            Console.WriteLine("Ingrese el apellido del empleado:");

            string apellido = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(apellido))

            {

                Console.WriteLine("Error: El apellido no puede estar vacío.");

                return;

            }
            string apellidos_Mayus = apellido.ToUpper();

            string[] partes_apellidos = apellidos_Mayus.Split(' ');

            if (partes_apellidos.Length > 0)

            {
                apellido = partes_apellidos[0];

            }

            else

                apellido = "Apellido";


            string correo = $"{primer_nombre.ToLower() + "." + apellido.ToLower()}@upn.edu.pe";

            nombres_empleado[cont_empleado] = nombres_mayus;

            apellido_empleado[cont_empleado] = apellidos_Mayus;

            correo_empleado[cont_empleado] = correo;


            cont_empleado++;


        }

        static public void buscar_emp()

        {

            Console.WriteLine("===============");

            Console.WriteLine("++Busqueda de Empleados++");

            Console.WriteLine("===============");


            if (cont_empleado == 0)

            {

                Console.WriteLine("No hay empleados registrados.");

                return;

            }

            Console.WriteLine("Ingrese el nombre del empleado a buscar:");


            string nombre_buscar = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(nombre_buscar))

                return;

            Console.WriteLine("Ingrese el apellido del empleado.");

            string apellido_buscar = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(apellido_buscar))

                return;

            bool encontrado = false;

            for (int i = 0; i < cont_empleado; i++)

            {

                if (nombres_empleado[i].Contains(nombre_buscar) && apellido_empleado[i].Contains(apellido_buscar))

                {

                    Console.WriteLine($"Nombre: {nombres_empleado[i]} | Apellido: {apellido_empleado[i]} | Correo: {correo_empleado[i]}"); ;

                    encontrado = true;


                }

            }
            if (!encontrado)

            {
                Console.WriteLine("Empleado no encontrado.");

            }


        }

        static public void ordenar_alfabeticamente()

        {
            if (cont_empleado <= 0)

            {

                Console.WriteLine("No hay empleados suficientes para ordenar.");

                return;

            }
            for (int i = 0; i < cont_empleado - 1; i++)

            {
                for (int j = 0; j < cont_empleado - i - 1; j++)

                {
                    if (string.Compare(nombres_empleado[j], nombres_empleado[j + 1]) > 0)

                    {
                        string temp_nombre = nombres_empleado[j];

                        string temp_apellido = apellido_empleado[j];

                        string temp_correo = correo_empleado[j];

                        nombres_empleado[j] = nombres_empleado[j + 1];

                        apellido_empleado[j] = apellido_empleado[j + 1];

                        correo_empleado[j] = correo_empleado[j + 1];

                        nombres_empleado[j + 1] = temp_nombre;

                        apellido_empleado[j + 1] = temp_apellido;

                        correo_empleado[j + 1] = temp_correo;

                    }

                }


            }

        }
        static public void mostrar_empleados()

        {
            Console.WriteLine("***************");

            Console.WriteLine("---- LISTA DE EMPLEADOS ----");

            Console.WriteLine("***************");

            if (cont_empleado == 0)

            {
                Console.WriteLine("No hay empleados registrados.");

                return;
            }

            Console.WriteLine("Nombres y Apellidos \t\tCorreo corporativo ");

            for (int i = 0; i < cont_empleado; i++)

            {

                Console.WriteLine($"{nombres_empleado[i]}\t{apellido_empleado[i]} \t\t{correo_empleado[i]}");

            }

        }
        static public void Guardar_datosarch()

        {
            Console.WriteLine("***************");

            Console.WriteLine("---- GUARDAR DATOS EN ARCHIVO ----");

            if (cont_empleado == 0)

            {

                Console.WriteLine("Error:No hay empleados registrados para guardar.");

                return;

            }
            using (StreamWriter escribir = new StreamWriter(rutaarchivo))

            {

                for (int i = 0; i < cont_empleado; i++)

                {

                    escribir.WriteLine($"{nombres_empleado[i]},{apellido_empleado[i]},{correo_empleado[i]}");

                }

            }

            Console.WriteLine(cont_empleado + " empleados guardados");
        }

        static public void Leer_datosarch()

        {
            Console.WriteLine("***************");

            Console.WriteLine("---- LEER DATOS DESDE EL ARCHIVO ----");

            if (!File.Exists(rutaarchivo))

            {

                Console.WriteLine("El archivo no existe.");

                return;

            }
            using (StreamReader lectura = new StreamReader(rutaarchivo))

            {
                string linea;

                while ((linea = lectura.ReadLine()) != null)

                {
                    string[] partes = linea.Split(',');

                    if (partes.Length == 3)

                    {

                        Console.WriteLine($"Nombre: {partes[0]}, Apellido: {partes[1]}, Correo: {partes[2]}");

                    }

                }

            }

        }

        static public void Cargar_datosarch()

        {
            Console.WriteLine("***************");

            Console.WriteLine("---- Cargar datos desde archivo ----");
            if (!File.Exists(rutaarchivo))

            {

                Console.WriteLine("El archivo no existe.");

                return;

            }
            string[] lineas = File.ReadAllLines(rutaarchivo);
            cont_empleado = 0;
            for (int i = 0; i < lineas.Length && i < max_emp; i++)

            {

                string[] partes = lineas[i].Split(',');
                if (partes.Length == 3)

                {
                    nombres_empleado[cont_empleado] = partes[0];

                    apellido_empleado[cont_empleado] = partes[1];

                    correo_empleado[cont_empleado] = partes[2];
                    cont_empleado++;

                }

            }


            Console.WriteLine($"{cont_empleado} empleados cargados correctamente.");

        }

        static void Main(string[] args)

        {
            int opc = 0;

            while (opc != 8)

            {

                Console.Clear();

                Console.WriteLine("[1] Registrar Empleado");

                Console.WriteLine("[2] Buscar Empleado");

                Console.WriteLine("[3] Ordenar Empleados Alfabéticamente");

                Console.WriteLine("[4] Mostrar Empleados");

                Console.WriteLine("[5] Guardar datos en archivo");

                Console.WriteLine("[6] Leer datos desde archivo");

                Console.WriteLine("[7] Cargar datos desde archivo");

                Console.WriteLine("[8] Salir");

                Console.Write("Ingrese una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opc))

                {

                    Console.WriteLine("Opción invalida. Intente nuevamente.");

                    Console.ReadKey();

                    continue;

                }
                switch (opc)

                {

                    case 1:

                        RegistroEmpleado();

                        break;

                    case 2:

                        buscar_emp();

                        break;

                    case 3:

                        ordenar_alfabeticamente();

                        break;

                    case 4:

                        mostrar_empleados();

                        break;

                    case 5:

                        Guardar_datosarch();

                        break;

                    case 6:

                        Leer_datosarch();

                        break;

                    case 7:

                        Cargar_datosarch();

                        break;

                    case 8:

                        Console.WriteLine("Saliendo del programa...");

                        break;

                    default:

                        Console.WriteLine("Opción inválida. Debe ingresar la opción entre 1 y 8");

                        break;

                }
                Console.ReadKey();
            }
        }
    }

}