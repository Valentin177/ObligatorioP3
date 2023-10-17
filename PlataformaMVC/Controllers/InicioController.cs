using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlataformaMVC.Models;

namespace PlataformaMVC.Controllers
{
    public class InicioController : Controller
    {
        public ILoginUsuario CULogin { get; set; }
        public IAltaUsuario CUAlta { get; set; }
        public string? usuarioLogueado { get; set; }

        public InicioController(ILoginUsuario cuLogin, IAltaUsuario alta)
        {
            CULogin = cuLogin;
            CUAlta = alta;
        }



        // GET: LoginController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return Redirect("/Inicio/Login");
            }
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usu)
        {
            try
            {
                CULogin.Login(usu.ElUsuario.alias, usu.ElUsuario.password);
                HttpContext.Session.SetString("Usuario", usu.ElUsuario.alias);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult RegistrarUsuario()
        {
            if(HttpContext.Session.GetString("Usuario") == null)
            {
               return Redirect("/Inicio/Login");
            }
            if(HttpContext.Session.GetString("Usuario") == "admin1")
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsuarioViewModel usu)
        {
            if(HttpContext.Session.GetString("Usuario") == "admin1")
            {
                if (usu.ElUsuario.password == usu.validacionPassword)
                {
                    try
                    {
                        usu.ElUsuario.Validar();
                        CUAlta.Alta(usu.ElUsuario);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "Las contrasenas no coinciden.";
                    return View();

                }
            }
            else
            {
                return RedirectToAction("Index");
            }                                         
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Inicio/Login");
        }

    }
}
