using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using DenunciasASP.Models;

[assembly: OwinStartupAttribute(typeof(DenunciasASP.Startup))]
namespace DenunciasASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
