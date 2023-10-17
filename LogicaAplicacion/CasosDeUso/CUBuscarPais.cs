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
    public class CUBuscarPais : IBuscarPais
    {
        public IRepositorioPaises repo { get; set; }

        public CUBuscarPais(IRepositorioPaises repox)
        {
            repo = repox;
        }

        public Pais BuscarPais(int id)
        {
            return repo.FindById(id);
        }
    }
}
