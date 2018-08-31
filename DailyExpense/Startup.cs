using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DailyExpense.Startup))]
namespace DailyExpense
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
