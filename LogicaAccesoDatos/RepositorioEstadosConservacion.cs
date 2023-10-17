using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEstadosConservacion : IRepositorioEstadosConservacion
    {
        public PlataformaContext Contexto { get; set; }

        public RepositorioEstadosConservacion(PlataformaContext contexto)
        {
            Contexto = contexto;
        }
        public void Agregar(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoConservacion> FindAll()
        {
            return Contexto.EstadosConservacion.ToList();
        }

        public EstadoConservacion FindById(int id)
        {
            return Contexto.EstadosConservacion.Find(id);
        }

        public void Remove(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }

        public void Update(EstadoConservacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
