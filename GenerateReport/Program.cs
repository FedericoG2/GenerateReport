using GenerateReport;
using System;
using System.Collections.Generic;
using System.IO;

namespace InformeEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║               Generate a Report                  ║");
            Console.WriteLine("║    Save it in the 'db' folder within the project ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();


            Console.WriteLine("Enter the database name (including the .db extension):");
            string dbName = Console.ReadLine();

            Console.WriteLine("Enter the table name:");
            string tableName = Console.ReadLine();

            Console.WriteLine("Enter the report file name (including the extension, e.g., EmployeeReport.txt):");
            string reportFileName = Console.ReadLine();

            string connectionString = $"Data Source=C:\\Users\\fgfed\\Desktop\\GenerateReport\\GenerateReport\\db\\{dbName};Version=3;";
            string reportFolderPath = "C:\\Users\\fgfed\\Desktop\\GenerateReport\\GenerateReport\\reports";
            string filePath = Path.Combine(reportFolderPath, reportFileName);

            // Create folder if it doesn't exist
            if (!Directory.Exists(reportFolderPath))
            {
                Directory.CreateDirectory(reportFolderPath);
            }

            var repositorio = new EmpleadoRepositorio(connectionString, tableName);
            var generadorInforme = new InformeGenerador();

            List<Dictionary<string, object>> datos = repositorio.ObtenerDatos();
            generadorInforme.GenerarInforme(datos, filePath);

            Console.WriteLine($"Report generated at {filePath}");
        }
    }
}
