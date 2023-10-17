using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso
{
    public class CULogin : ILoginUsuario
    {
        public IRepositorioUsuarios repo { get ; set; }

        public CULogin(IRepositorioUsuarios repoUsu)
        {
            repo = repoUsu;
        }

        public void Login(string username, string password)
        {
              repo.CheckLogin(username, password);
        }
    }
}
