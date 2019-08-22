using System;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace VirtualWhiteBoard3.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static void ConfigureKeyVault(this IConfigurationBuilder config)
        {
            bool.TryParse(Environment.GetEnvironmentVariable(
                "ASPNETCORE_HOSTINGSTARTUP__KEYVAULT__CONFIGURATIONENABLED"),
                out bool isKeyVaultEnabled);

            // If false, use Secret Manager to retrieve secrets.
            if (isKeyVaultEnabled)
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();
                var keyVaultClient = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(
                        azureServiceTokenProvider.KeyVaultTokenCallback));

                string keyVaultEndpoint = Environment.GetEnvironmentVariable(
                    "ASPNETCORE_HOSTINGSTARTUP__KEYVAULT__CONFIGURATIONVAULT");

                config.AddAzureKeyVault(
                    keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
            }
        }
    }
}
