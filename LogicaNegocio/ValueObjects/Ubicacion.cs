using LogicaNegocio.Dominio.Interfaces_Validaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Ubicacion: IValidable
    {
        [Column("Ubicacion")]
        public string ubi { get ; set; }

        [Column("Latitud")]
        public decimal latitud { get; private set; }

        [Column("Longitud")]
        public decimal longitud { get; private set; }

        public Ubicacion(decimal lat, decimal lng)
        {
            latitud = lat;
            longitud = lng;
            Validar();
            ubi = CrearUbicacion();
        }

        private Ubicacion() { }

        public void Validar()
        {
            ValidarLongitud();
            ValidarLatitud();
        }

        private void ValidarLatitud()
        {
            if (latitud < -90 || latitud > 90) throw new Exception("La latitud ingresada no es correcta.");
        }

        private void ValidarLongitud()
        {
            if (longitud < -180 || longitud > 180) throw new Exception("La longitud ingresada no es correcta.");
        }

        private string CrearUbicacion()
        {
            return $"Latitud: {this.latitud} Longitud: {this.longitud}";
        }
    }
}
