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
    public class CUTraerEcosistemas : ITraerEcosistemas
    {
        IRepositorioEcosistemas repo { get ; set; }

        public CUTraerEcosistemas(IRepositorioEcosistemas repox)
        {
            repo = repox;
        }

        public IEnumerable<Ecosistema> TraerEcosistemas()
        {
            return repo.FindAll();
        }
    }
}
