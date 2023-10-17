using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class RepositorioEcosistemas : IRepositorioEcosistemas
    {
        public PlataformaContext contexto { get ; set; }

        public RepositorioEcosistemas(PlataformaContext context)
        {
            contexto = context;
        }

        public void Agregar(Ecosistema obj)
        {
            if (obj != null)
            {
                try
                {
                    obj.Validar();
                    contexto.Entry(obj.estado).State = EntityState.Unchanged;
                    contexto.Entry(obj.pais).State = EntityState.Unchanged;
                    contexto.Entry(obj.amenazas).State = EntityState.Unchanged;
                    contexto.Ecosistemas.Add(obj);
                    contexto.SaveChanges();
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new InvalidOperationException("Ecosistema es nulo");
            }
        }

        public IEnumerable<Ecosistema> FindAll()
        {
           return contexto.Ecosistemas.ToList();
        }

        public Ecosistema FindById(int id)
        {
            return contexto.Ecosistemas.Find(id);
        }

        public void Remove(Ecosistema obj)
        {
            if(obj != null)
            {
                try
                {
                    contexto.Remove(obj);
                    contexto.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new InvalidOperationException("Ecosistema no registrado");
            }
        }

        public void Update(Ecosistema obj)
        {
            throw new NotImplementedException();
        }
    }
}
