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
    public class CUBuscarPaises : IBuscarPaises
    {
        IRepositorioPaises repo { get; set; }

        public CUBuscarPaises(IRepositorioPaises repoX)
        {
            repo = repoX;
        }
        public IEnumerable<Pais> TraerPaises()
        {
            return repo.FindAll();
        }
    }
}
