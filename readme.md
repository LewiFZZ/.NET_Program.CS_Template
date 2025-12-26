# ASP.NET Core 10 API Template

This project is a **ready-to-use base template** for ASP.NET Core Web API applications.  
It includes a clean and well-documented structure for `Program.cs`, focusing on real-world minimal hosting with proper middleware order and optional features like CORS, JWT, and Swagger.

---

## 🚀 Features

- Official **.NET 10 middleware order**
- Global **Exception Handler**
- **CORS** policy ready to edit
- Optional **JWT Authentication**
- Optional **Swagger** setup (commented)
- Clear placeholders and comments for adding services and configurations
- Focused on **clean startup** for personal or small-scale projects

---

## 📁 Structure Overview

No unnecessary folders or files are included; you can extend this as your base template for any API project.

---

## 🧩 How to Use

1. Create a new Web API project:
´dotnet new webapi -n MyApi --use-program-main´

2. Replace the content of `Program.cs` with the provided template.

3. (Optional) Uncomment and configure:
- **Swagger** for API documentation
- **JWT Authentication** if you use secure endpoints
- **Custom Middlewares** after comment placeholders

4. Add your own services (DbContext, Repositories, etc.) in the indicated section of `Program.cs`.

---

## ⚙️ Middleware Execution Order

This project follows Microsoft’s recommended middleware order:

1. `UseExceptionHandler()` – Global error handler  
2. `UseHttpsRedirection()` – Enforces HTTPS  
3. `UseStaticFiles()` – Serves static content  
4. `UseRouting()` – Enables endpoint routing  
5. `UseCors()` – Applies CORS policy  
6. `UseAuthentication()` – Authenticates requests (optional)  
7. `UseAuthorization()` – Authorizes requests (optional)  
8. `UseSwagger()` – (optional, for development only)  
9. `MapControllers()` – Maps controller endpoints

---

## 🧠 Notes

- Exception handler returns a simple JSON `{ "message": "Internal server error" }` by default.
- CORS policy is already set to accept requests from `localhost:3000` and `localhost:3001` (edit as needed).
- Keep the secret key in environment variables for production if you enable JWT authentication.

---

## 🛠️ Example Commands

Run the app:
´dotnet run´

Build the app:
´dotnet build´

Add new package:
´dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer´

---

## 🧾 License

This template is open for personal and educational use.  
You can freely modify and reuse it for your own projects.
