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
    public class CUTraerEstados : IBuscarEstadosConservacion
    {
        public IRepositorioEstadosConservacion repo { get; set; }

        public CUTraerEstados(IRepositorioEstadosConservacion repositorioEstados)
        {
            repo = repositorioEstados;
        }
        public IEnumerable<EstadoConservacion> TraerEstados()
        {
           return repo.FindAll();
        }
    }
}
