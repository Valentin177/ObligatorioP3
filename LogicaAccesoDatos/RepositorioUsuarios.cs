using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        public PlataformaContext Contexto { get; set; }

        public RepositorioUsuarios(PlataformaContext context)
        {
            Contexto = context;
        }
        public void Agregar(Usuario obj)
        {
            if(obj != null)
            {
                try
                {
                    if(!ValidarNombreUsuario(obj.alias))
                    {
                        obj.Validar();
                        obj.passwordEncrypt(obj.password);
                        Contexto.Usuarios.Add(obj);
                        Contexto.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Ya existe un usuario con ese nombre.");
                    }
                 
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
             
            }
            else
            {
                throw new InvalidOperationException("Error al crear el usuario");
            }
        }

        public bool ValidarNombreUsuario(string nombre)
        {
            var nom = Contexto.Usuarios
                      .Where(n => n.alias == nombre)
                      .Select(n => n.alias)
                      .SingleOrDefault();
            return nombre == nom;
        }

        public IEnumerable<Usuario> FindAll()
        {   
            //return Contexto.Usuarios.ToList();
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            // return Contexto.Usuarios.Find(id);
            throw new NotImplementedException();
        }

        public void Remove(Usuario obj)
        {
            if(obj != null)
            {
                Contexto.Remove(obj);
                Contexto.SaveChanges();
            }

        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string username, string password)
        {
            try
            {
                var user = Contexto.Usuarios
                           .Where(us => us.alias == username)
                           .Select(us => us.alias)
                           .Single();
                var pass = Contexto.Usuarios
                           .Where(us => us.password == password)
                           .Select(us => us.password)
                           .Single();
                return true;
            }catch (Exception ex)
            {
                throw new InvalidOperationException("Usuario no encontrado");
            }

                  
        }
    }
}
