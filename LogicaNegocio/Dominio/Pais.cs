using LogicaNegocio.Dominio.Interfaces_Validaciones;
using LogicaNegocio.ExcepcionesDominio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{

    public class Pais: IValidable
    {
        [Key]
        public int idPais { get; set; }
        public Nombre nombrePais { get; set; }

        [MaxLength(3)]
        public string codigoIsoAlpha { get; set; }

        public Pais()
        {
            
        }

        public void Validar()
        {
            ValidarCampos();
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrEmpty(codigoIsoAlpha))
            {
                throw new PaisException("Codigo IsoAplha son obligatorios");
            }
        }
    }
}
