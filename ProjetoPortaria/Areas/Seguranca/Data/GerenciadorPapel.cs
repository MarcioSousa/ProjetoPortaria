using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ProjetoPortaria.AcessoConfig.DAL;
using System;

namespace ProjetoPortaria.Areas.Seguranca.Data
{
    public class GerenciadorPapel : RoleManager<Papel>, IDisposable
    {
        public GerenciadorPapel(RoleStore<Papel> store) : base(store) { }
        public static GerenciadorPapel Create(IdentityFactoryOptions<GerenciadorPapel> option, IOwinContext context)
        {
            return new GerenciadorPapel(new RoleStore<Papel>(context.Get<IdentityDbContextAplicacao>()));
        }
    }
}