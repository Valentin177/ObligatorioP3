using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlataformaMVC.Models;

namespace PlataformaMVC.Controllers
{
    public class EspecieController : Controller
    {
        IBuscarEstadosConservacion CUBuscarEstadosCons { get; set; }
        IBuscarAmenazas CUBuscarAmenazas { get; set; }
        ITraerEcosistemas CUTraerEcos { get; set; }
        IAltaEspecie CUAltaEspecie { get; set; }


        public EspecieController(IBuscarEstadosConservacion cUBuscarEstadosCons, IBuscarAmenazas cUBuscarAmenazas, ITraerEcosistemas cuTraerEcos,
                                  IAltaEspecie altaEspecie )
        {
            CUBuscarEstadosCons = cUBuscarEstadosCons;
            CUBuscarAmenazas = cUBuscarAmenazas;
            CUTraerEcos = cuTraerEcos;
            CUAltaEspecie = altaEspecie;
        }

     
        public IActionResult Index()
        {

            return View();
        }

        public ActionResult CrearEspecie()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                Redirect("/Inicio/Login");
            }

            IEnumerable<Amenaza> ame = CUBuscarAmenazas.TraerAmenazas();
            IEnumerable<Ecosistema> eco = CUTraerEcos.TraerEcosistemas();
            IEnumerable<EstadoConservacion> est = CUBuscarEstadosCons.TraerEstados();

            EspecieViewModel evm = new EspecieViewModel()
            {
                especie = new Especie(),
                Ecosistemas = eco,
                Amenazas = ame,
                EstadosCons = est
            };       
            return View(evm);
        }

        [HttpPost]
        
        public ActionResult CrearEspecie(EspecieViewModel evm)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                Redirect("/Inicio/Login");
            }

            EstadoConservacion est = new EstadoConservacion() { idEstado = evm.estadoEcoSeleccionado };
            IEnumerable<Amenaza> ame = new List<Amenaza>() { new Amenaza() { idAmenaza = evm.amenazaSeleccionada } };
            IEnumerable<Ecosistema> eco = new List<Ecosistema>() { new Ecosistema() { idEcosistema = evm.idEcosistemaVM } };
            RangoPesoEspecie rangoPeso = new RangoPesoEspecie(evm.rangoDesdePeso, evm.rangoHastaPeso);
            RangoLongitudEspecie rangoLongitud = new RangoLongitudEspecie(evm.rangoDesdeLongitud, evm.rangoHastaLongitud);
            DescripcionEspecie descEsp = new DescripcionEspecie(evm.descripcionEVM);

            evm.especie.estadoConservacionEspecie = est;
            evm.especie.AmenazasEspecie = ame;
            evm.especie.ecosistemasHabitados = eco;
            evm.especie.rangoPeso = rangoPeso;
            evm.especie.rangoLongitud = rangoLongitud;
            evm.especie.descripcion = descEsp;
            try
            {
                evm.especie.Validar();
                CUAltaEspecie.AltaEspecie(evm.especie);
                ViewBag.Exito = "Exito al agregar la especie";
            }catch(Exception ex)
            {
                ViewBag.Error = ex;
            }

            evm.Amenazas = CUBuscarAmenazas.TraerAmenazas();
            evm.EstadosCons = CUBuscarEstadosCons.TraerEstados();
            evm.Ecosistemas = CUTraerEcos.TraerEcosistemas();

            return View(evm);
        }
    }
}
