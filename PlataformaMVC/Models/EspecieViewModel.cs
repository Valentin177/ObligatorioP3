using LogicaNegocio.Dominio;

namespace PlataformaMVC.Models
{
    public class EspecieViewModel
    {
        public Especie especie { get; set; }

        public string descripcionEVM { get ; set; }
        public int rangoDesdePeso { get; set; }
        public int rangoHastaPeso { get; set; }
        public int rangoDesdeLongitud { get; set; }
        public int rangoHastaLongitud { get; set; }
        public int idEcosistemaVM { get; set; }
        public int estadoEcoSeleccionado { get; set; }
        public int amenazaSeleccionada { get; set; }




        public IEnumerable<Ecosistema>? Ecosistemas { get; set; }
        public IEnumerable<Amenaza>? Amenazas { get; set; }
        public IEnumerable<EstadoConservacion>? EstadosCons { get; set; }

    }
}
