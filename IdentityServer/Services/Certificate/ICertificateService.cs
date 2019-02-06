using System.Security.Cryptography.X509Certificates;

namespace IdentityServer.Services.Certificate
{
    public interface ICertificateService
    {
        X509Certificate2 GetCertificateFromKeyVault(string vaultCertificateName);
    }
}