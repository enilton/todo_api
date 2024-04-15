using Enilton.Thunders.Business.Helper;
using Enilton.Thunders.Persistence;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var persistenceType = ConfigurationHelper.Configuration.GetSection("PersitenceType").Value;

        var persistenceClassType = Type.GetType($"Enilton.Thunders.Repository.{persistenceType}.DbContext, Enilton.Thunders.Repository.{persistenceType}");

        IDBContext dBContext = (IDBContext)Activator.CreateInstance(persistenceClassType);

        _ = builder.Services.AddSingleton(dBContext);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}