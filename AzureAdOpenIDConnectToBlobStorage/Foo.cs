using Microsoft.AspNetCore.Authorization;

namespace AzureAdOpenIDConnectToBlobStorage
{
    internal class Foo : IAuthorizationRequirement
    {
        private int v;

        public Foo(int v)
        {
            this.v = v;
        }
    }
}