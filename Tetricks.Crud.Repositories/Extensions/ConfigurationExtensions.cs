using Microsoft.Extensions.Configuration;

namespace Tetricks.Crud.Repositories.Extensions;

public static class ConfigurationExtensions
{
    private const string DatabaseProviderKey = "DatabaseProvider";
    private const string ConnectionStringKey = "ConnectionString";

    public static string ObterDatabaseProvider(this IConfiguration configuration)
    {
        var providerString = ObterVariavelObrigatoria(configuration, DatabaseProviderKey);
        var providerValido = Enum.TryParse<DatabaseProvider>(providerString, true, out _);

        if (!providerValido)
            throw new ArgumentException(DatabaseProviderKey);

        return providerString;
    }

    public static string ObterConnectionString(this IConfiguration configuration) =>
        ObterVariavelObrigatoria(configuration, $"{ObterDatabaseProvider(configuration)}:{ConnectionStringKey}");

    private static string ObterVariavelObrigatoria(IConfiguration configuration, string chave)
    {
        var valor = configuration.GetValue(chave, string.Empty);
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException(chave);

        return valor;
    }
}
