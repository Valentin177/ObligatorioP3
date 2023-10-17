using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioPaises : IRepositorioPaises
    {
        public PlataformaContext contexto { get; set; }

        public RepositorioPaises(PlataformaContext context)
        {
            contexto = context;
        }

        public void Agregar(Pais obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> FindAll()
        {
            return contexto.Paises.ToList();
        }

        public Pais FindById(int id)
        {
            return contexto.Paises.Find(id);
        }

        public void Remove(Pais obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
