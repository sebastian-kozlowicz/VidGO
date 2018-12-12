using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Video_Rental_Shop.Startup))]
namespace Video_Rental_Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
