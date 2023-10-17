using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Parametros
{
    [Index(nameof(nombrePar), IsUnique = true)]
    public class Parametro
    {
        [Key]
        public int idParametros {  get; set; }
        public string nombrePar { get; set; }
        public string valorPar { get; set; }

    }
}
