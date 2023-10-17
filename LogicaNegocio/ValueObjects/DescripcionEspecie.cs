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
    public class DescripcionEspecie
    {
        [Column("Descripcion")]
        public string desc { get; private set; }
        public static int topeMaxDesc { get; set; }
        public static int topeMinDesc { get; set; }

        public DescripcionEspecie(string descripcion)
        {
            desc = descripcion;
            Validar();
        }

        private DescripcionEspecie() { }

        public void Validar()
        {
            if (string.IsNullOrEmpty(desc)) throw new Exception("Descripcion es un campo obligatorio.");

            if (desc.Length < topeMinDesc || desc.Length > topeMaxDesc) throw new InvalidOperationException("Descripcion es minimo " + topeMinDesc + " y " + topeMaxDesc + " Caracteres.");

            if (topeMinDesc > topeMaxDesc) throw new InvalidOperationException("Tope minimo no puede ser mayor a tope maximo.");

            //TODO: Validar que la descripcion minima o maxima nueva no interfiera con los valores ya por defecto.
        }
    }


}
