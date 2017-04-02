using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamPrototype.Startup))]
namespace ExamPrototype
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
