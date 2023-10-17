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
    public class CUBorrarEcosistema : IBorrarEcosistema
    {
        public IRepositorioEcosistemas repo { get; set; }

        public CUBorrarEcosistema(IRepositorioEcosistemas repoX)
        {
            repo = repoX;
        }
        public void BorrarEcosistema(Ecosistema eco)
        {
            repo.Remove(eco);
        }
    }
}
