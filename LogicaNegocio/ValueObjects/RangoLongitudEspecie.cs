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
    public class RangoLongitudEspecie: IValidable
    {
        [Column("LongDesde")]
        public int rangoDesde { get; private set; }

        [Column("LongHasta")]
        public int rangoHasta { get; private set; }

        public RangoLongitudEspecie(int rangoD, int rangoH)
        {
            rangoDesde = rangoDesde;
            rangoHasta = rangoHasta;
            Validar();
        }

        private RangoLongitudEspecie() { }

        public void Validar()
        {
            if (int.IsNegative(rangoDesde) || int.IsNegative(rangoHasta)) throw new Exception("Rangos deben ser characteres validos.");
        }
    }
}
