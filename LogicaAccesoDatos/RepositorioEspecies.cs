using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioEspecies : IRepositorioEspecies
    {
        public PlataformaContext contexto { get; set; }

        public RepositorioEspecies(PlataformaContext context)
        {
            contexto = context;
        }
        public void Agregar(Especie obj)
        {
            if(obj != null)
            {
                obj.Validar();
                contexto.Entry(obj.estadoConservacionEspecie).State = EntityState.Unchanged;
               // contexto.Entry(obj.ecosistemasHabitados).State = EntityState.Unchanged;
                contexto.Entry(obj.AmenazasEspecie).State = EntityState.Unchanged;
                contexto.Add(obj);
                contexto.SaveChanges();
            }
            else
            {
                throw new Exception("Error al dar de alta la Especie");
            }
        }

        public IEnumerable<Especie> FindAll()
        {
            throw new NotImplementedException();
        }

        public Especie FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Especie obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Especie obj)
        {
            throw new NotImplementedException();
        }
    }
}
