var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Novo OpenAPI

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // FAZ o endpoint existir onde o Swagger UI espera
    app.MapOpenApi("/swagger/v1/swagger.json");

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Recreio Barcode API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
