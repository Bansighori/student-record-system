# student-record-system

This project is a web-based “Student Record System” built using ASP.NET (Core/MVC) that allows faculty to register and log in, and manage student records (add, view, delete).
The system includes authentication for faculty, a responsive UI for managing students, and stores data in a SQL database.
It is designed for educational institute-use to streamline record keeping, login, registration, and student-data workflows.

Key features:
Faculty login and registration with username/password.
A dashboard for faculty to view/manage student data.
Secure access so only registered faculty can log in.
Clean UI and responsive design (using the provided auth.css for login/register pages).
Proper folder structure: Controllers, Views, Models, wwwroot (for static files).
Build and run in Visual Studio Code.

Run the Project:
Install the .NET SDK
Install a code editor such as Visual Studio Code + C# extension.
Clone the repository to your local machine:
   git clone https://github.com/Bansighori/student-record-system.git
   cd student-record-system

Ensure a SQL Server or localdb instance is running.

Update the connection string in appsettings.json (or appsettings.Development.json) to reflect your database server credentials.

Run database migrations or ensure the database schema is created. Example:
   dotnet ef database update

ensure you have installed the CLI tools:
   dotnet tool install --global dotnet-ef

Restore dependencies:
   dotnet restore

Build the project:
   dotnet build

Run the project:
   dotnet run
   
This will start a local web server (e.g., https://localhost:5001).
Open a browser and navigate to that URL.

In the browser, you should see the login page. From there you can register a new faculty user or log in.

After logging in, you should be able to access the student-management pages (add, delete, view students).
