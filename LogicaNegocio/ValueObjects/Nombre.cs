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
    [Index(nameof(nombre), IsUnique = true)]
    [Owned]
    public class Nombre: IValidable
    {
        [Column("Nombre")]
        public string nombre {  get; private set; }
        public Nombre(string name)
        {
            nombre = name;
            Validar();
        }
        private Nombre() { }

        public void Validar()
        {
            if(nombre.Length < 0 || nombre.Length > 50) throw new InvalidOperationException("Nombre debe ser entre 2 y 50 caracteres.");
        }
    }
}
