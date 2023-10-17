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
    public class CUBuscarEcoPorId : IBuscarEcosistemaPorId
    {
        public IRepositorioEcosistemas repo { get; set; }
        
        public CUBuscarEcoPorId(IRepositorioEcosistemas repositorioEcosistemas)
        {
            repo = repositorioEcosistemas;
        }
        public Ecosistema BuscarEcosistema(int id)
        {
            return repo.FindById(id);
        }
    }
}
