using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProjetoPortaria.AcessoConfig.Infraestrutura;
using ProjetoPortaria.Areas.Seguranca.Data;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPortaria.Areas.Seguranca.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login details, string returnUrl)
        {
            //LoginViewModel = Login
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.Find("", details.Senha);
                user = UserManager.FindByEmail(details.Email);
                
                if (user == null)
                {
                    ModelState.AddModelError("", "Email ou senha inválido(s).");
                }
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    if (returnUrl == null)
                    {
                        returnUrl = "/Index";
                    }
                    return RedirectToAction(returnUrl);
                }
            }
            return View(details);
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
    }
}