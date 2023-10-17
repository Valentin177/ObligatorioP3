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
    public class CUAltaEcosistema : ICrearEcosistema
    {
        public IRepositorioEcosistemas repo { get ; set; }

        public CUAltaEcosistema(IRepositorioEcosistemas repoX)
        {
            repo = repoX;
        }
        public void CrearEcosistema(Ecosistema eco)
        {
            repo.Agregar(eco);
        }
    }
}
