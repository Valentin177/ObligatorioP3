using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CUBuscarEstadoC : IBuscarEstadoConservacion
    {
        public IRepositorioEstadosConservacion repo { get ; set; }

        public CUBuscarEstadoC(IRepositorioEstadosConservacion repoX)
        {
            repo = repoX;
        }

        public EstadoConservacion BuscarEstadoPorId(int id)
        {
            return repo.FindById(id);
        }
    }
}
