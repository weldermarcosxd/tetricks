namespace Tetricks.Crud.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void UsarSwagger(this WebApplication app, IConfiguration configuration)
    {
        var secret = configuration.ObterClientSecretDoKeycloak();
        var clientId = configuration.ObterClientIdDoKeycloak();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API de tarefas v1");
            options.OAuthClientId(clientId);
            options.EnablePersistAuthorization();

            if (!string.IsNullOrWhiteSpace(secret))
            {
                options.OAuthClientSecret(secret);
                options.OAuthUsePkce();
            }
        });
    }
}
