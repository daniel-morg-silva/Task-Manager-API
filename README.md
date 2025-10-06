# Task Manager API

A simple Task management API built with ASP.NET Core 9.0 Minimal APIs and Entity Framework Core.

## Features

- **Full CRUD Operations**: Create, read, update, and delete todos
- **RESTful Design**: Clean HTTP endpoints following REST conventions
- **In-Memory Database**: Easy setup with Entity Framework Core
- **Async/Await**: Non-blocking operations for better performance
- **Minimal APIs**: Lightweight endpoint definitions
- **Proper HTTP Status Codes**: 200, 201, 204, 404 responses

## ⭐ Tech Stack

- **Framework**: ASP.NET Core 9.0
- **ORM**: Entity Framework Core
- **Database**: In-Memory Database (Development)
- **Architecture**: Minimal APIs
- **Language**: C#


## 🔴 Getting Started

### Prerequisites

- .NET 9.0 SDK
- Your favourite code editor (VS Code, Visual Studio, Rider)

### Installation

1. Clone the repository
```bash
git clone https://github.com/daniel-morg-silva/Task-Manager-API.git
cd Task-Manager-API
```
2. Restore dependencies
```bash
dotnet restore
```
3. Run the application
```bash
dotnet run
```

## API Endpoints

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| GET | `/tasks` | Get all tasks | 200 |
| GET | `/tasks/completed` | Get all completed tasks | 200 |
| GET | `/tasks/{id}` | Get task by ID | 200, 404 |
| POST | `/tasks` | Create new task | 201 |
| PUT | `/tasks/{id}` | Update task | 200, 404 |
| DELETE | `/tasks/{id}` | Delete task | 204, 404 |

## Example Usage

### Create a Task
```http
POST /todos
Content-Type: application/json

{
  "title": "Learn ASP.NET Core",
  "description": "Study Minimal APIs",
  "isCompleted": false
}
```
### Get all Tasks
```http
GET /todos
```
### Update a Task
```http
PUT /todos/1
Content-Type: application/json

{
  "title": "Learn ASP.NET Core Updated",
  "description": "Study Minimal APIs and EF Core",
  "isCompleted": true
}
```

