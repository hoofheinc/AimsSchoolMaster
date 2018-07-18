using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AimsSchoolMaster.Startup))]
namespace AimsSchoolMaster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
