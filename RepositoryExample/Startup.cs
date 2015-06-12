using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RepositoryExample.Startup))]

namespace RepositoryExample
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            Configuration(app);
        }   
    }
}
