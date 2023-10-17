using LogicaNegocio.Dominio.Interfaces_Validaciones;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Especie: IValidable
    {
        [Key]
        public int idEspecie { get; set; }
        public string nombreCientifico { get; set; }
        public string nombreVulgar { get; set; }
        public DescripcionEspecie descripcion { get; set; }
        public RangoPesoEspecie rangoPeso { get; set; }
        public RangoLongitudEspecie rangoLongitud {get; set; }
        public EstadoConservacion estadoConservacionEspecie { get; set; }

 
        public IEnumerable<Amenaza>? AmenazasEspecie { get; set; }


        public IEnumerable<Ecosistema>? ecosistemasHabitados { get; set; }
        public Especie()
        {

        }

        public void Validar()
        {
            ValidarNombres();
        }

        private void ValidarNombres()
        {
            if(string.IsNullOrEmpty(nombreCientifico) || string.IsNullOrEmpty(nombreVulgar))
            {
                throw new Exception("Nombres de la especie no pueden ser nulos.");
            }
        }
        
    }
}
