using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace InformeEmpleados
{
    public class EmpleadoRepositorio
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public EmpleadoRepositorio(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        public List<Dictionary<string, object>> ObtenerDatos()
        {
            var datos = new List<Dictionary<string, object>>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Obtener los nombres de las columnas
                string pragmaQuery = $"PRAGMA table_info({_tableName})";
                var columnNames = new List<string>();
                using (var command = new SQLiteCommand(pragmaQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnNames.Add(reader["name"].ToString());
                        }
                    }
                }

                // Construir la consulta SELECT
                string query = $"SELECT {string.Join(", ", columnNames)} FROM {_tableName}";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            foreach (var columnName in columnNames)
                            {
                                row[columnName] = reader[columnName];
                            }
                            datos.Add(row);
                        }
                    }
                }
            }
            return datos;
        }
    }
}
