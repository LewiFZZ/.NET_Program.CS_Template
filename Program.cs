// ===============================================================
// THIS I A PROGRAM.CS FILE TEMPLATE TO HAVE A GOOD STARTING POINT
// ===============================================================

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ============================================
// SERVICES
// ============================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger commented - uncomment for development
// builder.Services.AddSwaggerGen();

// Custom services
// builder.Services.AddDbContext<ApplicationDbContext>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IProductService, ProductService>();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3001")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// JWT Authentication commented
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secure-secret-key-min-32-characters-long")),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });

// Authorization commented
// builder.Services.AddAuthorization();

var app = builder.Build();

// ============================================
// MIDDLEWARE - OFFICIAL ORDER
// ============================================

// 1. GLOBAL EXCEPTION HANDLER - Add more error messages as needed
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var error = new { message = "Internal server error" };
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(error));
        });
    });
}
else
{
    app.UseDeveloperExceptionPage();
}

// 2. BASIC SECURITY
app.UseHttpsRedirection();

// 3. STATIC FILES
app.UseStaticFiles();

// 4. ROUTING
app.UseRouting();

// 5. CORS
app.UseCors("CorsPolicy");

// 6. JWT AUTHENTICATION (commented)
// app.UseAuthentication();

// 7. AUTHORIZATION (commented)
// app.UseAuthorization();

// 8. SWAGGER (commented)
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// Custom middlewares
// app.UseMiddleware<MyCustomMiddleware>();

// 9. ENDPOINTS
app.MapControllers();

app.Run();
