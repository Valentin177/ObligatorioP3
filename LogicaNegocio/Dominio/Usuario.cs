using LogicaNegocio.Dominio.Interfaces_Validaciones;
using LogicaNegocio.ExcepcionesDominio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogicaNegocio.Dominio
{
    [Index(nameof(alias), IsUnique = true)]
    public class Usuario: IValidable
    {
        [Key]
        public int idUsuario { get; set; }
        public string alias { get; set; }
        public string password { get; set; }
        public string? passwordEncriptada { get; set; }
        public DateTime? fechaAlta { get; set; }

        public Usuario()
        {
            fechaAlta = DateTime.Now;
        }

        public void Validar()
        {
            ValidarAlias();
            ValidarPassword();
        }

        private void ValidarAlias()
        {
            if (alias.Length < 6) throw new UsuarioException("Nombre no puede ser menor a seis caracteres.");
        }

        private void ValidarPassword()
        {
           Regex regPassword =  new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[.,;:#!]).{8,}$");

            bool esValida = regPassword.IsMatch(password);

            if (!esValida) throw new UsuarioException("El password no es valido.");
        }

        // Utilizo base64 para encriptar (o codificar el password)
        
        public void passwordEncrypt(string passwordX)
        {
            byte[] pass = System.Text.Encoding.UTF8.GetBytes(passwordX);
            this.passwordEncriptada = Convert.ToBase64String(pass);
        }
        
    }
}
