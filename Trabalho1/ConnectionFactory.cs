using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace Trabalho1
{
    class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=Jose@Dynacoop353.onmicrosoft.com;" +
                "Password=Zerodrigo321@;" +
                "Url=https://orgcdb8412b.crm2.dynamics.com/;" +
                "AppId=94897358-5037-4256-a471-a0429d3d7ff9;" +
                "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

            return crmServiceClient.OrganizationWebProxyClient;
        }
    }
}
