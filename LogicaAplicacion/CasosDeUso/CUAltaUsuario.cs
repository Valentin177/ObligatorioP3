using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUAltaUsuario: IAltaUsuario
    {   
        public IRepositorioUsuarios repoUsu { get; set; }

        public CUAltaUsuario(IRepositorioUsuarios usuarios)
        {
            repoUsu = usuarios;
        }

        public void Alta(Usuario usu)
        {
            repoUsu.Agregar(usu);
        }
    }
}
