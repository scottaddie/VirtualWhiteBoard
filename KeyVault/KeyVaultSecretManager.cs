using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace VirtualWhiteBoard.KeyVault
{
    public class KeyVaultSecretManager : DefaultKeyVaultSecretManager
    {
        public override string GetKey(SecretBundle secret)
        {
            // A Key Vault key name can't contain a colon.
            // Replace double-dashes with colons.
            return secret.SecretIdentifier.Name.Replace("--", ":");
        }

        public override bool Load(SecretItem secret)
        {
            return base.Load(secret);
        }
    }
}
