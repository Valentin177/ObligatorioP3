using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioAmenazas : IRepositorioAmenazas
    {
        public PlataformaContext Contexto { get; set; }

        public RepositorioAmenazas(PlataformaContext context)
        {
            Contexto = context;
        }
        public void Agregar(Amenaza obj)
        {
            if(obj != null)
            {
                obj.Validar();
                Contexto.Amenazas.Add(obj);
                Contexto.SaveChanges();
            }
        }

        public IEnumerable<Amenaza> FindAll()
        {
            return Contexto.Amenazas.ToList();
        }

        public Amenaza FindById(int id)
        {
            return Contexto.Amenazas.Find(id);
        }

        public void Remove(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Amenaza obj)
        {
            throw new NotImplementedException();
        }
    }
}
