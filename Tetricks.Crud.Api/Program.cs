using Tetricks.Crud.Api.Extensions;

namespace Tetricks.Crud.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AdicionarAutenticacaoEAutorizacao(configuration);
        services.AdicionarSwaggerComAutenticacao(configuration);

        var app = builder.Build();

        app.UsarSwagger();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
