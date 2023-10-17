using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaMVC.Models;

namespace PlataformaMVC.Controllers
{
    public class EcosistemaController : Controller
    {
        public IBuscarPaises CUBuscarPaises { get; set; }
        public IBuscarEstadosConservacion CUEstadosCons { get; set; }
        public IBuscarAmenazas CUBuscarAmenazas { get; set; }
        public ICrearEcosistema CUAltaEco { get; set; }  
        
        public IBuscarEstadoConservacion CUBuscarEstado { get; set; }
        public IBuscarPais CUBuscarPais { get; set; }
        public IListarEcosistemas CUListarEcosistemas { get; set; }
        public IBuscarEcosistemaPorId CUBuscarEco { get; set; }
        public IBorrarEcosistema CUBorrarEco { get; set; }



        public EcosistemaController(IBuscarPaises paises, IBuscarEstadosConservacion repEstados, IBuscarAmenazas repoAme,
                                    ICrearEcosistema repoEco, IBuscarEstadoConservacion cUBuscarEstado, IBuscarPais cUBuscarPais,
                                    IListarEcosistemas cUListarEcosistemas, IBorrarEcosistema borrarEco, IBuscarEcosistemaPorId buscarEco)
        {
            CUBuscarPaises = paises;
            CUEstadosCons = repEstados;
            CUBuscarAmenazas = repoAme;
            CUAltaEco = repoEco;
            CUBuscarEstado = cUBuscarEstado;
            CUBuscarPais = cUBuscarPais;
            CUListarEcosistemas = cUListarEcosistemas;
            CUBuscarEco = buscarEco;
            CUBorrarEco = borrarEco;
        }


        public ActionResult Index()
        {
            IEnumerable<Ecosistema> Ecosistemas = CUListarEcosistemas.ListarEcosistemas();
            return View(Ecosistemas);
        }

        public ActionResult CrearEcosistema()
        {
            if(HttpContext.Session.GetString("Usuario") == null)
            {
                Redirect("/Inicio/Login");
            }

            IEnumerable<Pais> paises = CUBuscarPaises.TraerPaises();
            IEnumerable<EstadoConservacion> estadosConservacion = CUEstadosCons.TraerEstados();
            IEnumerable<Amenaza> amenazas = CUBuscarAmenazas.TraerAmenazas();
            
            EcosistemaViewModel ecoVM = new EcosistemaViewModel()
            {
                Eco = new Ecosistema(),
                Paises = paises,
                amenazaS = amenazas,    
                estadosCons = estadosConservacion
            };
            
            /*
            ViewBag.Paises = paises;
            ViewBag.Estados = estadosConservacion;
            ViewBag.Amenazas = amenazas;
            */
            return View(ecoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEcosistema(EcosistemaViewModel ecoVM)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                Redirect("/Inicio/Login");
            }
        
              EstadoConservacion est = new EstadoConservacion() { idEstado = ecoVM.estadoSeleccionado };
              
              IEnumerable<Amenaza> ame = new List<Amenaza>() { new Amenaza() { idAmenaza = ecoVM.amenazaSeleccionada } };
              Nombre nombreEco = new Nombre(ecoVM.nombreEco);
              Ubicacion ubiEco = new Ubicacion(decimal.Parse(ecoVM.latitud), decimal.Parse(ecoVM.longitud));
              DescripcionEcosistema descEco = new DescripcionEcosistema(ecoVM.descrip);
              Pais p = new Pais() { idPais = ecoVM.idPaisSeleccionado };
                    
              ecoVM.Eco.nombreEcosistema = nombreEco;
              ecoVM.Eco.ubicacion = ubiEco;
              ecoVM.Eco.descEco = descEco;
              ecoVM.Eco.estado = est;
              ecoVM.Eco.amenazas = ame;
              ecoVM.Eco.pais = p;

              try
               {
                  ecoVM.Eco.Validar();
                  CUAltaEco.CrearEcosistema(ecoVM.Eco);
                  return Redirect("/Inicio/Index");

               }
               catch (Exception ex)
               {
              
                ViewBag.Error = ex;                 
               }


            ecoVM.Paises = CUBuscarPaises.TraerPaises();
            ecoVM.amenazaS = CUBuscarAmenazas.TraerAmenazas();
            ecoVM.estadosCons = CUEstadosCons.TraerEstados();
            return View(ecoVM);
        }



        public ActionResult BorrarEcosistema()
        {
            IEnumerable<Ecosistema> ListaEco = CUListarEcosistemas.ListarEcosistemas();
            return View(ListaEco);
        }

        [HttpPost]

        public ActionResult BorrarEcosistema(int idEco)
        {
            Ecosistema eco = CUBuscarEco.BuscarEcosistema(idEco);

            try
            {
                CUBorrarEco.BorrarEcosistema(eco);
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
