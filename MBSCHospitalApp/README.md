# MBSC Hospital Reservation System

This is a simple ASP.NET Core 8 MVC application for managing hospital reservations.

## How to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/AbdullahTammar/MBSC-Hospital-Reservation-System-.git
   cd MBSC-Hospital-Reservation-System-/MBSCHospitalApp
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Apply migrations and create the database:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Open in browser:
   ```
   http://localhost:5276
   ```

## Default Users

- **Admin User** → redirected to Admin Dashboard
- **Patient User 1** → can reserve appointments
- **Patient User 2** → can reserve appointments
