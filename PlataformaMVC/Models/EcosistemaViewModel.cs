using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;

namespace PlataformaMVC.Models
{
    
    public class EcosistemaViewModel
    {
       
        public Ecosistema Eco { get; set; }

        public string nombreEco { get; set; }   
        public string descrip { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }


        public int idPaisSeleccionado { get; set; }
        public int estadoSeleccionado { get; set; }
        public int amenazaSeleccionada { get; set; }

        public IEnumerable<Pais>? Paises { get; set; }
        public IEnumerable<Amenaza>? amenazaS { get; set;}
        public IEnumerable<EstadoConservacion>? estadosCons { get; set; }


        
    }
}
