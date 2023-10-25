using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ProjetoPortaria.AcessoConfig.DAL;
using ProjetoPortaria.AcessoConfig.Infraestrutura;
using ProjetoPortaria.Areas.Seguranca.Data;

namespace ProjetoPortaria
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IdentityDbContextAplicacao>(IdentityDbContextAplicacao.Create);
            app.CreatePerOwinContext<GerenciadorUsuario>(GerenciadorUsuario.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Seguranca/Account/Login"),
            });
            app.CreatePerOwinContext<GerenciadorPapel>(GerenciadorPapel.Create);
        }
    }
}