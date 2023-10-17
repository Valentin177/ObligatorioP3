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
    public class CUTraerAmenzas : IBuscarAmenazas
    {
        public IRepositorioAmenazas repo { get ; set; }

        public CUTraerAmenzas(IRepositorioAmenazas repoX)
        {
            repo = repoX;
        }
    
        public IEnumerable<Amenaza> TraerAmenazas()
        {
            return repo.FindAll();
        }
    }
}
