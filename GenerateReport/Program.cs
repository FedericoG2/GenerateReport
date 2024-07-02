using GenerateReport; // Importa el namespace que contiene las clases necesarias para generar el informe
using System;
using System.Collections.Generic;
using System.IO;

namespace InformeEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configura el color del texto en la consola a verde
            Console.ForegroundColor = ConsoleColor.Green;

            // Muestra un mensaje en la consola para indicar que se generará un informe
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║               Generate a Report                ║");
            Console.WriteLine("║    Save it in the 'db' folder within the project ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");

            // Restaura el color del texto en la consola a su valor predeterminado
            Console.ResetColor();
            Console.WriteLine();

            // Pide al usuario que introduzca el nombre de la base de datos (incluyendo la extensión .db)
            Console.WriteLine("Enter the database name (including the .db extension):");
            string dbName = Console.ReadLine();

            // Pide al usuario que introduzca el nombre de la tabla de la cual se extraerán los datos
            Console.WriteLine("Enter the table name:");
            string tableName = Console.ReadLine();

            // Pide al usuario que introduzca el nombre del archivo de informe (incluyendo la extensión, p. ej., EmployeeReport.txt)
            Console.WriteLine("Enter the report file name (including the extension, e.g., EmployeeReport.txt):");
            string reportFileName = Console.ReadLine();

            // Construye la cadena de conexión a la base de datos SQLite
            string connectionString = $"Data Source=C:\\Users\\fgfed\\Desktop\\GenerateReport\\GenerateReport\\db\\{dbName};Version=3;";

            // Define la ruta de la carpeta donde se guardará el informe
            string reportFolderPath = "C:\\Users\\fgfed\\Desktop\\GenerateReport\\GenerateReport\\reports";

            // Combina la ruta de la carpeta del informe con el nombre del archivo de informe para obtener la ruta completa del archivo
            string filePath = Path.Combine(reportFolderPath, reportFileName);

            // Crea la carpeta de informes si no existe
            if (!Directory.Exists(reportFolderPath))
            {
                Directory.CreateDirectory(reportFolderPath);
            }

            // Crea una instancia de la clase EmpleadoRepositorio, que se encarga de obtener los datos de la base de datos
            var repositorio = new EmpleadoRepositorio(connectionString, tableName);

            // Crea una instancia de la clase InformeGenerador, que se encarga de generar el informe
            var generadorInforme = new InformeGenerador();

            // Obtiene los datos de la base de datos a través del repositorio
            List<Dictionary<string, object>> datos = repositorio.ObtenerDatos();

            // Genera el informe con los datos obtenidos y lo guarda en la ruta especificada
            generadorInforme.GenerarInforme(datos, filePath);

            // Muestra un mensaje en la consola indicando que el informe ha sido generado y muestra la ruta donde se guardó
            Console.WriteLine($"Report generated at {filePath}");
        }
    }
}
