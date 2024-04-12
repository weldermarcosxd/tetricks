namespace Tetricks.Crud.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void UsarSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API de tarefas v1");
            options.OAuthClientId("tetricks-client-id");
        });
    }
}
