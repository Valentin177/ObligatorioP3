using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioParametros : IRepositorioParametros
    {
        public PlataformaContext Contexto { get; set; }

        public RepositorioParametros(PlataformaContext contexto)
        {
            Contexto = contexto;
        }

        public void Agregar(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public Parametro buscarParametroPorNombre(string nombre)
        {
            return Contexto.Parametros.Where(par => par.nombrePar == nombre).SingleOrDefault();
        }

        public string buscarValorPorNombre(string nombre)
        {
            var param = Contexto.Parametros
                            .Where(par => par.nombrePar == nombre)
                            .Select(par => par.valorPar)
                            .SingleOrDefault();
            return param;
        }

        public IEnumerable<Parametro> FindAll()
        {
            throw new NotImplementedException();
        }

        public Parametro FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Parametro obj)
        {
            throw new NotImplementedException();
        }
    }
}
