using url_shortener.api.Interfaces;
using url_shortener.api.Models.Settings;
using url_shortener.api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
         .AllowAnyMethod();

    });
});

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDbSettings>();
builder.Services.AddSingleton<MongoDbService>();

builder.Services.AddTransient<IShortLinkGenerator, ShortLinkGeneratorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigin"); // Ensure this is placed before UseEndpoints
app.UseAuthorization();

app.MapControllers();

app.Run();