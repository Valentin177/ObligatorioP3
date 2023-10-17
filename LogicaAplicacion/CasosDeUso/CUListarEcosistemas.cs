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
    public class CUListarEcosistemas : IListarEcosistemas
    {
        public IRepositorioEcosistemas repo { get; set; }

        public CUListarEcosistemas(IRepositorioEcosistemas repox)
        {
            repo = repox;
        }

        public IEnumerable<Ecosistema> ListarEcosistemas()
        {
            return repo.FindAll();
        }
    }
}
