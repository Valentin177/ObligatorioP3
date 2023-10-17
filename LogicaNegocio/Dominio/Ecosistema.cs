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
    public class Ecosistema: IValidable
    {
        [Key]
        public int idEcosistema { get; set; }

        [Display(Name = "Nombre")]
        public Nombre nombreEcosistema { get; set; }

        [Display(Name = "Ubicacion")]
        public Ubicacion ubicacion { get; set; }

        [Display(Name = "Descripcion")]
        public DescripcionEcosistema descEco { get ; set; }
        public int area { get; set; }
        public Pais? pais { get; set; }
        public IEnumerable<Especie>? especies { get; set; }

        public IEnumerable<Amenaza>? amenazas { get; set; } 
        public EstadoConservacion? estado { get; set; }

        public Ecosistema() { }

        public void Validar()
        {

        }

    }
}
