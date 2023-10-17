using LogicaNegocio.Dominio.Interfaces_Validaciones;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Amenaza: IValidable
    {
        [Key]
        public int idAmenaza { get; set; }

        public string NombreAmenaza { get; set; }
        public Descripcion desc { get; set; }
        public int gradoPeligrosidad { get; set; }

       // public IEnumerable<Ecosistema> Ecosistemas { get; set; }


        public Amenaza() { }

        public void Validar()
        {
           
            ValidarGrado();
        }


        private void ValidarGrado()
        {
            if (gradoPeligrosidad < 1 || gradoPeligrosidad > 10) throw new Exception("Rango debe ser valor entre 1 y 10.");
        }
    }
}
