# SQLite Database Report Generator
---
This C# console application allows you to dynamically generate reports from SQLite databases. Simply specify the database, table, and report file name, and the application will create a report file in the reports folder within the project directory.

## Features
#### Dynamic Report Generation: 
Generate reports from any SQLite database stored in the db folder of the project.
#### Customizable Output: 
Specify the database, table, and report file name at runtime.
#### Flexible and Portable: 
Designed to work with SQLite databases, ensuring portability and ease of use.

## Usage
#### Prerequisites
.NET Core SDK installed on your machine. An SQLite database with the appropriate structure stored in the db folder of the project.


## Steps to Run

1. **Setup**
   - Place your SQLite database file (`*.db`) on your local desktop in a folder named `GenerateReport/db`.

2. **Run the Program**
   - Open a terminal or command prompt.
   - Navigate to the project directory.
   - Modify the following parts of the code in `Program.cs` to point to your local desktop:
     
     ```csharp
     // Modify the connection string to point to your local desktop
     string connectionString = $"Data Source=C:\\Users\\<YourUserName>\\Desktop\\GenerateReport\\GenerateReport\\db\\{dbName};Version=3;";

     // Modify the report folder path to point to your local desktop
     string reportFolderPath = "C:\\Users\\<YourUserName>\\Desktop\\GenerateReport\\GenerateReport\\reports";
     ```

     Replace `<YourUserName>` with your actual user name on the desktop.

3. **Follow the Prompts**
   - Upon running the program, follow the prompts to enter:
     - **Database Name**: Name of the SQLite database file (including `.db` extension) located on your desktop.
     - **Table Name**: Name of the table from which data will be retrieved.
     - **Report File Name**: Desired name for the generated report file (including file extension, e.g., `EmployeeReport.txt`).

4. **Generate the Report**
   - The application will retrieve data from the specified table in the SQLite database and generate a report file in the `reports` folder on your desktop.

5. **View the Report**
   - Once the report is generated, you can find it in the `reports` folder on your desktop.


## Demo 
https://www.loom.com/share/7e0409753b484d2d9809f3a045f7666f?sid=ce4ad87f-c339-4730-8ca3-61942ddceb6d

---
