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
                writer.WriteLine("Informe");
                writer.WriteLine("--------------------");

                if (datos.Count > 0)
                {
                    // Escribir encabezados
                    foreach (var key in datos[0].Keys)
                    {
                        writer.Write($"{key}\t");
                    }
                    writer.WriteLine();

                    // Escribir datos
                    foreach (var row in datos)
                    {
                        foreach (var value in row.Values)
                        {
                            writer.Write($"{value}\t");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
