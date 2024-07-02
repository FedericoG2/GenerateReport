using System;
using System.Collections.Generic;
using System.IO;

namespace InformeEmpleados
{
    public class InformeGenerador
    {
        public void GenerarInforme(List<Dictionary<string, object>> datos, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("========================================");
                writer.WriteLine("                Informe                 ");
                writer.WriteLine("========================================");

                if (datos.Count > 0)
                {
                    // Escribir encabezados
                    writer.WriteLine(new string('-', 110));
                    foreach (var key in datos[0].Keys)
                    {
                        writer.Write($"{key,-20}"); // Alinear las columnas con un ancho fijo mayor
                    }
                    writer.WriteLine();
                    writer.WriteLine(new string('-', 110));

                    // Escribir datos
                    foreach (var row in datos)
                    {
                        foreach (var value in row.Values)
                        {
                            writer.Write($"{value,-20}"); // Alinear las columnas con un ancho fijo mayor
                        }
                        writer.WriteLine();
                    }
                    writer.WriteLine(new string('-', 110));
                }
                else
                {
                    writer.WriteLine("No hay datos disponibles para mostrar.");
                }

                writer.WriteLine("========================================");
                writer.WriteLine($"Generado el: {DateTime.Now}");
            }
        }
    }
}
