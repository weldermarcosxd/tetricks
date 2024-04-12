namespace Tetricks.Crud.Api.Extensions;

public static class ConfigurationExtensions
{
    private const string ChaveUrlBaseDoKeycloak = "Keycloak:auth-server-url";
    private const string ChaveRealm = "Keycloak:realm";

    public static string? ObterUrlBaseDoKeycloak(this IConfiguration configuration) =>
        configuration.GetValue(ChaveUrlBaseDoKeycloak, string.Empty);

    public static string? ObterRealm(this IConfiguration configuration) =>
        configuration.GetValue(ChaveRealm, string.Empty);
}
