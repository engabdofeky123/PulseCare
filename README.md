# PulseCare 🩺
### Clinic Management System API

PulseCare is a clinic management system built with **ASP.NET Core Web API** and **Clean Architecture**. It aims to simplify clinic operations by managing doctors, patients, appointments, medical records, prescriptions, medical files, and invoices through a structured and secure RESTful API.

The project focuses on maintainability, separation of concerns, secure authentication, and scalable backend design.

> **Project Status:** In Development

## 🚀 Features

- **Authentication & Authorization**
  - User registration and login
  - JWT-based authentication
  - Refresh token management
  - Role-based access control

- **Doctor Management**
  - Create, retrieve, update, and manage doctors
  - Manage doctor availability and clinic schedules

- **Appointment Management**
  - Book appointments
  - View today's appointments and personal appointments
  - Reschedule and cancel appointments
  - Update appointment status

- **Patient Management**
  - Manage patient information
  - Maintain patient medical history

- **Medical Records & Prescriptions**
  - Create medical records linked to patients, doctors, and appointments
  - Manage prescriptions and medication details

- **Medical File Management**
  - Upload and manage patient medical files
  - Retrieve and download stored files

- **Clinic Services**
  - Manage clinic services and consultation prices

- **Billing & Payments**
  - Generate and retrieve invoices
  - Track payments and refunds

- **Reports**
  - Retrieve daily clinic summaries

- **AI Integration — Planned**
  - Assist doctors in structuring medical notes
  - Keep AI-generated content as a draft for doctor review
  - AI output will not automatically become a saved medical record

## 🏗️ Architecture

PulseCare follows the principles of **Clean Architecture** to separate business logic from infrastructure and presentation concerns.

```text
PulseCare/
├── API/
│   ├── Controllers/
│   ├── Middleware/
│   ├── Program.cs
│   └── appsettings.json
│
├── Application/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Features/
│
├── Domain/
│   ├── Entities/
│   └── Enums/
│
└── Infrastructure/
    ├── Data/
    ├── Identity/
    ├── Implementation/
    └── DependencyInjection.cs
```

*The structure above is illustrative and may be adjusted to match the actual solution.*

### Architectural Responsibilities

| Layer | Responsibility |
|---|---|
| **Domain** | Core entities, enums, and business rules |
| **Application** | Use cases, DTOs, interfaces, and application logic |
| **Infrastructure** | Database access, Entity Framework Core, Identity, and external services |
| **API** | HTTP endpoints, request handling, authentication configuration, and dependency composition |

The Application and Domain layers remain independent of Infrastructure implementation details. The API can reference Infrastructure at the composition root to register its services.

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core Web API
- **Language:** C#
- **Architecture:** Clean Architecture
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Core Identity and JWT Bearer Authentication
- **API Documentation:** Swagger / OpenAPI
- **Application Patterns:** Dependency Injection and separation of concerns
- **AI Integration:** Planned

Additional technologies such as MediatR, CQRS, FluentValidation, and automated testing should be listed as implemented only after they have been integrated into the project.

## 📋 API Endpoints

The following endpoints represent the planned API scope. Availability depends on the current implementation.

| Module | Endpoint | Method |
|---|---|---|
| Authentication | `/api/auth/register` | POST |
| Authentication | `/api/auth/login` | POST |
| Authentication | `/api/auth/refresh-token` | POST |
| Authentication | `/api/auth/revoke-token` | POST |
| Doctors | `/api/doctors` | GET |
| Doctors | `/api/doctors/{id}` | GET |
| Doctors | `/api/doctors` | POST |
| Doctors | `/api/doctors/{id}` | PUT |
| Doctors | `/api/doctors/{id}` | DELETE |
| Schedules | `/api/schedules` | GET |
| Schedules | `/api/schedules` | POST |
| Schedules | `/api/schedules/{id}` | PUT |
| Appointments | `/api/appointments/book` | POST |
| Appointments | `/api/appointments/today` | GET |
| Appointments | `/api/appointments/my-appointments` | GET |
| Patients | `/api/patients` | GET |
| Medical Records | `/api/records` | POST |
| Medical Files | `/api/medical-files/upload` | POST |
| Clinic Services | `/api/services` | GET |
| Invoices | `/api/invoices/{appointmentId}` | GET |
| Reports | `/api/reports/daily-summary` | GET |

The endpoint list will be expanded as the remaining modules are implemented.

## ⚙️ Getting Started

### Prerequisites

Make sure you have installed:

- .NET SDK compatible with the project target framework
- Microsoft SQL Server or SQL Server LocalDB
- Visual Studio or Visual Studio Code
- EF Core CLI tools, if using `dotnet ef`

### 1. Clone the Repository

```bash
git clone https://github.com/engabdofeky123/PulseCare
cd PulseCare
```

### 2. Configure the Database

Update the connection string in the API configuration or use .NET User Secrets for local development.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=PulseCare;trustservercertificate=true;integrated security=true;"
  }
}
```

### 3. Configure JWT Authentication

Configure the JWT issuer, audience, signing key, and token expiration settings using your project's expected configuration structure.

Keep signing keys and other sensitive values out of committed configuration files.

### 4. Apply Database Migrations

From the solution directory, run the following commands in the Package Manager Console, adjusting project names and the context name if needed:

```powershell
Add-Migration InitialCreate `
    -Project Infrastructure `
    -StartupProject API `
    -Context ApplicationDbContext `
```

Apply the migration:

```powershell
Update-Database `
    -Project Infrastructure `
    -StartupProject API `
    -Context ApplicationDbContext
```

If migrations already exist, use the existing migration history instead of creating a duplicate initial migration.

### 5. Run the API

Set the API project as the startup project and run it through Visual Studio, or execute:

```bash
dotnet run --project API
```

Open the Swagger URL printed in the application output to explore and test the available endpoints.

## 🔐 Security Considerations

- Protect endpoints using authentication and appropriate authorization policies.
- Validate request data before processing it.
- Store refresh tokens securely and validate expiration and revocation.
- Keep secrets and signing keys outside source control.
- Restrict access to medical records and uploaded files.
- Validate file type and size for medical uploads.
- Avoid exposing patient information in logs or API responses.
- Require a qualified doctor's review of AI-generated medical content.

## 🧪 Testing

Automated testing is part of the project's quality goals. The planned test coverage includes:

- Authentication and authorization
- Appointment booking and scheduling conflicts
- Patient and medical record operations
- Invoice calculations and payment workflows
- Invalid input and error handling
- Access restrictions for sensitive medical data

Only mark test categories as completed once corresponding automated tests have been implemented and executed.

## ⚠️ Disclaimer

PulseCare is a software development project intended for learning and demonstration. It is not a substitute for professional medical judgment. AI-generated content must be reviewed by a qualified healthcare professional before use.

## 👨‍💻 Author

**Abdelrahman Mohammed**

ASP.NET Core Backend Developer

- GitHub: [engabdofeky123](https://github.com/engabdofeky123)

---

*Building reliable backend systems with clean architecture, secure APIs, and maintainable code.*
