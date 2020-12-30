using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quan_ly_thiet_bi.Startup))]
namespace Quan_ly_thiet_bi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
