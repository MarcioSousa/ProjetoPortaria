using Microsoft.AspNet.Identity.EntityFramework;
using ProjetoPortaria.Areas.Seguranca.Data;
using System.Data.Entity;

namespace ProjetoPortaria.AcessoConfig.DAL
{
    public class IdentityDbContextAplicacao : IdentityDbContext<Usuario>
    {
        public IdentityDbContextAplicacao() : base("IdentityDb") { }
        static IdentityDbContextAplicacao()
        {
            Database.SetInitializer<IdentityDbContextAplicacao>(new IdentityDbInit());
        }

        public static IdentityDbContextAplicacao Create()
        {
            return new IdentityDbContextAplicacao();
        }

        public System.Data.Entity.DbSet<ProjetoPortaria.Areas.Seguranca.Data.UsuarioViewModel> UsuarioViewModels { get; set; }

        //public System.Data.Entity.DbSet<SistemaLogin.Areas.Seguranca.Data.Papel> IdentityRoles { get; set; }

        //public System.Data.Entity.DbSet<SistemaLogin.Areas.Seguranca.Data.UsuarioViewModel> UsuarioViewModels { get; set; }

        //public System.Data.Entity.DbSet<SistemaLogin.Areas.Seguranca.Data.Usuario> Usuarios { get; set; }

        //public System.Data.Entity.DbSet<SistemaLogin.Areas.Seguranca.Data.Papel> IdentityRoles { get; set; }

    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextAplicacao> { }

}