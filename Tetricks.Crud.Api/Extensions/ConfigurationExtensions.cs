namespace Tetricks.Crud.Api.Extensions;

public static class ConfigurationExtensions
{
    private const string ChaveUrlAuthorityDoKeycloak = "Keycloak:Authority";
    private const string ClientSecretDoKeycloak = "Keycloak:ClientSecret";
    private const string ChaveRealm = "Keycloak:Realm";
    private const string ChaveAudiencia = "Keycloak:Audience";
    private const string ChaveClientId = "Keycloak:ClientId";

    public static string ObterUrlAutorityDoKeycloak(this IConfiguration configuration) =>
        ObterVariavelObrigatoria(configuration, ChaveUrlAuthorityDoKeycloak);

    public static string? ObterClientSecretDoKeycloak(this IConfiguration configuration) =>
        ObterVariavelObrigatoria(configuration, ClientSecretDoKeycloak);

    public static string? ObterAudienciaDoKeycloak(this IConfiguration configuration) =>
        ObterVariavelObrigatoria(configuration, ChaveAudiencia);

    public static string? ObterClientIdDoKeycloak(this IConfiguration configuration) =>
        ObterVariavelObrigatoria(configuration, ChaveClientId);

    private static string ObterVariavelObrigatoria(IConfiguration configuration, string chave)
    {
        var valor = configuration.GetValue(chave, string.Empty);
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException(chave);

        return valor;
    }
}
