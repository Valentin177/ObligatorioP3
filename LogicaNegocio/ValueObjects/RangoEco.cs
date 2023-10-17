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
    public class RangoEco : IValidable
    {
        [Column("Estado")]
        public string? nombreRango { get; private set; }

        [Column("RangoDesde")]
        public int rangoDesde { get; set; }

        [Column("RangoHasta")]
        public int rangoHasta { get; set; }

        public RangoEco(int rangoD, int rangoH)
        {
            rangoDesde = rangoD;
            rangoHasta = rangoH;
            Validar();
            //nombreRango = CrearRango();
        }
        
        private RangoEco()
        {

        }

        public void Validar()
        {
            if(rangoDesde < 0 || rangoDesde > 100 || rangoHasta < 0 || rangoHasta > 100 || rangoDesde > rangoHasta)
            {
                throw new InvalidOperationException("Rangos invalidos.");
            } 
        }

        /*
        private string CrearRango()
        {
            if(rangoDesde >= 0 && rangoHasta < 60)
            {
                return "En peligro";
            }else if(rangoDesde >= 60 && rangoHasta <= 70)
            {
                return "Aceptable";
            }else if(rangoDesde > 70 && rangoHasta < 95){
                return "Muy bueno";
            }else if(rangoDesde >= 95 && rangoHasta <= 100){
                return "Optimo";
            }
            else
            {
                throw new Exception("Rango invalido. De 0 a 100;");
            }
        }
        */
    }
}
