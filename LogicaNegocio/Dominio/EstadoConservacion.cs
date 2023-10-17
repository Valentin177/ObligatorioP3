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
    public class EstadoConservacion: IValidable
    {
        [Key]
        public int idEstado { get; set; }
        public string nombreEstado { get; set; }
        
        public RangoEco rango { get ; set; }

        public EstadoConservacion() { }

        public void Validar()
        {
            ValidarNombre();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(nombreEstado)) throw new Exception("Nombre no puede ser nulo");
        }
    }
}
