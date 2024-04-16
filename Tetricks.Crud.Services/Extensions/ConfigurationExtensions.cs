﻿using Microsoft.Extensions.Configuration;

namespace Tetricks.Crud.Services.Extensions;

public static class ConfigurationExtensions
{
    private const string BaseDomainKey = "BaseDomain";

    public static string? ObterDominioBase(this IConfiguration configuration) =>
        configuration.GetValue(BaseDomainKey, string.Empty);
}
