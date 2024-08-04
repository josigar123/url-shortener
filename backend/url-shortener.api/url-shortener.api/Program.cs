using MongoDB.Driver;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

InitializeMongoClient(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
return;

void InitializeMongoClient(WebApplicationBuilder builder)
{
    var mongoDbSection = builder.Configuration.GetSection("MongoDB");
    var username = mongoDbSection["Username"];
    var password = mongoDbSection["Password"];

    var connectionUri = $"mongodb+srv://{username}:{password}@cluster68311.m06jkmr.mongodb.net/?retryWrites=true&w=majority&appName={username}";
    var settings = MongoClientSettings.FromConnectionString(connectionUri);

    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    
    var client = new MongoClient(settings);
    
    try {
        var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
        Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
    } catch (Exception ex) {
        Console.WriteLine(ex);
    }

    builder.Services.AddSingleton(client);
}