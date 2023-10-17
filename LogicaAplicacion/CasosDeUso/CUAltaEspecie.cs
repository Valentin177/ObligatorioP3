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
    public class CUAltaEspecie : IAltaEspecie
    {
        public IRepositorioEspecies repo { get ; set; }

        public CUAltaEspecie(IRepositorioEspecies repoX)
        {
            repo = repoX;
        }

        public void AltaEspecie(Especie esp)
        {
            repo.Agregar(esp);
        }
    }
}
