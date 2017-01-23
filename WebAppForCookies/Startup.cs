using Owin;

namespace WebAppForCookies
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                return next();
            });
        }
    }
}